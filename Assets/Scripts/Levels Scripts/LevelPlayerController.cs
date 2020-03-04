using UnityEngine;
using UnityEngine.UI;

public class LevelPlayerController : MonoBehaviour {

    public Text timerText;
    private Rigidbody rb;
    private Matrix4x4 calibrationMatrix;
    public float speed;
    public float timeSetting;
    public float pickUps;
    private int count;
    private float time;
    public static bool gameActive;
    private bool started = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.MovePosition(new Vector3(-8, 0.5f, 0));
        rb.velocity = Vector3.zero;
        timerText.text = "Tempo: 10.0";
        time = timeSetting;
        count = 0;
    }
	
	private void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        if (gameActive && started)
        {
            time -= Time.deltaTime;
            string str = time.ToString();
            str = str.Substring(0, str.IndexOf('.') + 2);
            timerText.text = "Tempo: " + str;
            Vector3 rawAccel = Input.acceleration;
            Vector3 movement = getAccelerometer(rawAccel);
            rb.AddForce(movement.y * speed, 0, -movement.x * speed);
            if (time <= 0)
            {
                Send("GameOver");
                gameActive = false;
                timerText.text = "Tempo: 0.0";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.transform.localScale = Vector3.zero;
            count++;
            if (count == pickUps)
            {
                Send("LevelCompleted");
                gameActive = false;
            }
        }
    }

    public void Calibrate()
    {
        Vector3 wantedDeadZone = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0f, -1f), wantedDeadZone);
        Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f, 1f, 1f));
        calibrationMatrix = matrix.inverse;
    }

    private Vector3 getAccelerometer(Vector3 accelerator)
    {
        Vector3 accel = calibrationMatrix.MultiplyVector(accelerator);
        return accel;
    }

    private void Send(string message)
    {
        GameObject go = GameObject.Find("Container");
        go.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
    }

    private void Stopped()
    {
        gameActive = false;
    }

    private void Restarted()
    {
        gameActive = true;
    }

    private void Started()
    {
        started = true;
        Calibrate();
    }

    //IMPOSTARE PLYERPREFS PER I LIVELLI COMPLETATI

}
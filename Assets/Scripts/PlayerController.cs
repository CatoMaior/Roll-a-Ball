using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text recordText;
    public Text winText;
    public Text timer;
    public Text startMessage;
    public GameObject activating1;
    public GameObject activating2;
    public GameObject activating3;
    public GameObject activating4;
    public GameObject activating5;
    public GameObject activating6;
    public GameObject activating7;
    public GameObject activating8;
    public GameObject activating9;
    public GameObject activating10;
    public GameObject activating11;
    public GameObject pauseButton;
    public GameObject calibrateButton;
    public GameObject restartButton;
    public GameObject startMessageObject;
    public GameObject timerObject;
    public GameObject pickUps;
    public GameObject menuButton;
    public Text pauseButtonText;
    public Text calibrateButtonText;
    public Text goText;
    public GameObject activateRecordText;
    public GameObject pauseBackground;
    private Rigidbody rb;
    private Matrix4x4 calibrationMatrix;
    public float speed;
    private int count;
    private float calibrationY;
    private float accelY;
    private float calibrationX;
    private float accelX;
    private float coordMin = -9;
    private float coordMax = 9;
    private float rndX;
    private float rndY;
    private string str;
    private float time;
    public static bool pause;

    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        pause = false;
        calibrateButton.SetActive(false);
        pauseBackground.SetActive(false);
        menuButton.SetActive(false);
        rb = GetComponent<Rigidbody>();
        rb.MovePosition(new Vector3(0, 0, 0));
        rb.velocity = Vector3.zero;
        count = 0;
        time = -5.0f;
        winText.text = "";
        goText.text = "";
        startMessage.text = "Raccogli tutti gli oggetti nel minor tempo possibile !\n" +
                "Muovi il telefono per spostarti";
        Calibrate();
        SetRecordText();
        SetCountText();
        SetActive();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.zero;
        if (!pause)
        {
            if (time >= 0.0f)
            {
                timer.color = Color.white;
                Vector3 rawAccel = Input.acceleration;
                Vector3 movement = getAccelerometer(rawAccel);
                rb.AddForce(movement.x * speed, 0, movement.y * speed);
            }
            else
            {
                timer.color = Color.red;
            }
            if (count < 11)
            {
                time += Time.deltaTime;
                str = time.ToString();
                str = str.Substring(0, str.IndexOf('.') + 2);
                timer.text = "Tempo: " + str;
            }
            if (time >= 0)
            {
                startMessage.text = "";
                goText.text = "V i a !";
            }
            if (time >= 2)
            {
                goText.text = "";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        if (count >= 11)
        {
            if (PlayerPrefs.GetFloat("Record") == 0 || PlayerPrefs.GetFloat("Record") > float.Parse(str))
            {
                PlayerPrefs.SetFloat("Record", float.Parse(str));
                winText.text = "Hai vinto!\n Nuovo record: " + str + " sec!";
            }
            else
            {
                winText.text = "Hai vinto!\n" + "Gioco completato in " + str + " sec!";
            }
            SetRecordText();
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

    public void SetActive()
    {
        activating1.SetActive(true);
        activating2.SetActive(true);
        activating3.SetActive(true);
        activating4.SetActive(true);
        activating5.SetActive(true);
        activating6.SetActive(true);
        activating7.SetActive(true);
        activating8.SetActive(true);
        activating9.SetActive(true);
        activating10.SetActive(true);
        activating11.SetActive(true);
        generateRnds();
        activating1.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating2.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating3.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating4.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating5.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating6.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating7.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating8.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating9.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating10.transform.position = new Vector3(rndX, 0.5f, rndY);
        generateRnds();
        activating11.transform.position = new Vector3(rndX, 0.5f, rndY);
    }
    
    private void SetRecordText()
    {
        if (PlayerPrefs.GetFloat("Record") != 0)
        {
            recordText.text = "Record: " + PlayerPrefs.GetFloat("Record").ToString();
        }
        else
        {
            recordText.text = "";
        }
    }

    private void generateRnds()
    {
        rndX = Random.Range(coordMin, coordMax);
        rndY = Random.Range(coordMin, coordMax);
    }

    public void ClickPauseButton()
    {
        if (!pause)
        {
            pauseButtonText.text = "Riprendi";
            pauseBackground.SetActive(true);
            calibrateButton.SetActive(true);
            restartButton.SetActive(false);
            activateRecordText.SetActive(false);
            startMessageObject.SetActive(false);
            menuButton.SetActive(true);
            pause = true;
        }
        else
        {
            pauseButtonText.text = "Pausa";
            pauseBackground.SetActive(false);
            calibrateButton.SetActive(false);
            restartButton.SetActive(true);
            activateRecordText.SetActive(true);
            startMessageObject.SetActive(true);
            menuButton.SetActive(false);
            pause = false;
        }
    }
}
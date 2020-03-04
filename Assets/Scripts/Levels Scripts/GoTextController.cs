using UnityEngine;
using UnityEngine.UI;

public class GoTextController : MonoBehaviour {

    private Text goText;
    private float time;
    private bool started;
    private bool active;

	private void Start()
    {
        SendPlayer("Stopped");
        goText = GetComponent<Text>();
        goText.text = "";
        time = 3.2f;
        started = false;
        active = true;
    }
	
	private void Update()
    {
        if (active)
        {
            if (!started)
            {
                time -= Time.deltaTime;
                setText();
            }

        }
    }

    private void setText()
    {
        if (time < 3 && time > 2)
        {
            goText.text = "3";
        }
        else if(time < 2 && time > 1)
        {
            goText.text = "2";
        }
        else if (time < 1 && time > 0)
        {
            goText.text = "1";
        }
        else if (time < 0 && time > -1)
        {
            goText.text = "V i a !";
            SendPlayer("Started");
            SendPlayer("Restarted");
        }
        else if (time < -1 && time > -2)
        {
            goText.text = "";
            started = true;
        }
    }

    private void LevelCompleted()
    {
        goText.text = "L i v e l l o\nc o m p l e t a t o !";
    }

    private void GameOver()
    {
        goText.text = "G a m e  o v e r";
    }

    private void Send(string message)
    {
        GameObject go = GameObject.Find("Container");
        go.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
    }

    private void SendPlayer(string message)
    {
        GameObject player = GameObject.Find("Player");
        player.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
    }

    private void Stopped()
    {
        active = false;
    }

    private void Restarted()
    {
        active = true;
    }


}

using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour {

    private Text pauseButtonText;
    private bool paused = false;
    private Vector3 hidden = Vector3.zero;
    private Vector3 shown;
    private bool setted = false;

    private void Start()
    {
        pauseButtonText = GetComponentInChildren<Text>();
        pauseButtonText.text = "Pausa";
        if (!setted)
        {
            shown = transform.localScale;
            setted = true;
        }
        transform.localScale = shown;
    }
	
	public void Clicking()
    {
        if (!paused)
        {
            Send("Stopped");
            pauseButtonText.text = "Riprendi";
            paused = true;
        }
        else
        {
            Send("Restarted");
            pauseButtonText.text = "Pausa";
            paused = false;
        }
	}

    private void Send(string message)
    {
        GameObject go = GameObject.Find("Container");
        go.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
    }

    private void GameOver()
    {
        transform.localScale = hidden;
    }

    private void LevelCompleted()
    {
        transform.localScale = hidden;
    }



}

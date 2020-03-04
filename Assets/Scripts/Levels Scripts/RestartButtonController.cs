using UnityEngine;

public class RestartButtonController : MonoBehaviour {

    private Vector3 hidden = Vector3.zero;
    private Vector3 shown;

	private void Start()
    {
        shown = transform.localScale;
	}

    private void Stopped()
    {
        transform.localScale = hidden;
    }

    private void Restarted()
    {
        transform.localScale = shown;
    }

    public void Send(string message)
    {
        GameObject go = GameObject.Find("Container");
        go.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
    }

}

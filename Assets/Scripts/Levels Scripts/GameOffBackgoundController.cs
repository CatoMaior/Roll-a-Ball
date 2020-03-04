using UnityEngine;

public class GameOffBackgoundController : MonoBehaviour {

    private void Stopped()
    {
        transform.Rotate(-120, 0, 0);
    }

    private void Restarted()
    {
        transform.Rotate(120, 0, 0);
    }

    private void Send(string message)
    {
        GameObject go = GameObject.Find("Container");
        go.BroadcastMessage(message, SendMessageOptions.DontRequireReceiver);
    }

}

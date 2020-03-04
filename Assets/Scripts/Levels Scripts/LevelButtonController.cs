using UnityEngine;

public class LevelButtonController : MonoBehaviour {

    private Vector3 hidden = Vector3.zero;
    private Vector3 shown;
    private bool setted = false;

	private void Start()
    {
        if (!setted)
        {
            shown = transform.localScale;
            setted = true;
        }
        transform.localScale = hidden;
	}

    private void Stopped()
    {
        transform.localScale = shown;
    }

    private void Restarted()
    {
        transform.localScale = hidden;
    }
	
}

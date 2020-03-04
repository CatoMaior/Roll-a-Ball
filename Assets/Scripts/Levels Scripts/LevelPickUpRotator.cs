using UnityEngine;

public class LevelPickUpRotator : MonoBehaviour {

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
        transform.localScale = shown;
    }

    private void Update()
    {
        if (LevelPlayerController.gameActive)
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
    }
}

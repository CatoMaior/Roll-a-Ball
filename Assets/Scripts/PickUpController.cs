using UnityEngine;

public class PickUpController : MonoBehaviour {

    private void Start()
    {
        gameObject.SetActive(true);
    }

    private void Update ()
    {
        if (!PlayerController.pause || LevelPlayerController.gameActive)
        {
            transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        }
    }
}

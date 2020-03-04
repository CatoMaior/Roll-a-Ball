using UnityEngine;

public class NextLevelButtonController : MonoBehaviour {

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

    //AGGIUNGERE APPARSA E SCOMPARIZIONE CON GAMEOVER E LEVEL COMPLETED
}

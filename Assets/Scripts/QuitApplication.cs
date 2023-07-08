using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    
    void Update()
    {
        RespondToEscKey();
    }

    void RespondToEscKey()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ESCAPE");
            Application.Quit();
        }
    }

}

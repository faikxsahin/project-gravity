using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly fire!");
                break;

            case "Finish":
                Debug.Log("Congratulations, you finished!");
                break;

            case "Fuel":
                Debug.Log("Fuel obtained!");
                break;

            default:
                // Debug.Log("GAME OVER");
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex); // Respawn to current active scene
    }

}

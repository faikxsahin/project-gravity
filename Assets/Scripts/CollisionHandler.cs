using UnityEngine;

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
                Debug.Log("GAME OVER");
                break;
        }
    }

}

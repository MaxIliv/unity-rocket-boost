using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                AddFuel();
                break;
            case "Friendly":
                Debug.Log("this is friendly");
                break;
            case "Finish":
                LevelFinish();
                break;
            default:
                Debug.Log("Blew Up");
                break;
        }
    }

    void LevelFinish()
    {
        Debug.Log("Finishhhhh!");
    }

    void AddFuel()
    {
        Debug.Log("Fuel +10");
    }
}

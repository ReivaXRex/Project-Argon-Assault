using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    void StartDeathSequence()
    {
        // deathSFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        StartCoroutine(GameManager.Instance.LevelLoad());
    }
}
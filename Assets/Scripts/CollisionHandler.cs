using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // [SerializeField] GameObject deathSFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        // deathSFX.SetActive(true);
        SendMessage("OnPlayerDeath");
        StartCoroutine(GameManager.Instance.LevelLoad());
    }
}
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathSFX;
    [SerializeField] private int scorePerHit = 12;

    private Scoreboard scoreBoard;

    private bool isAlive = true;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (isAlive)
        {
            scoreBoard.ScoreHit(scorePerHit);
        }

        isAlive = false;
        print("Particles collided with enemy " + gameObject.name);
        deathSFX.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}
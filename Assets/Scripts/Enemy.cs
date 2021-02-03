using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathSFX;
    [SerializeField] private int scorePerHit = 12;
    [SerializeField] private int health;

    private Scoreboard scoreBoard;

    // [SerializeField] bool isAlive = true;

    private void Start()
    {
        scoreBoard = FindObjectOfType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (health >= 0)
        {
            health--;
            scoreBoard.ScoreHit(scorePerHit);
        } 
        else if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        // print("Particles collided with enemy " + gameObject.name);
        deathSFX.SetActive(true);
        Destroy(this.gameObject, 1f);
    }
}
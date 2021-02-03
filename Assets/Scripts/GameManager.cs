using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Game Manager doesn't exist");
            }

            return _instance;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Invoke("LoadLevel", 2f);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public IEnumerator LevelLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
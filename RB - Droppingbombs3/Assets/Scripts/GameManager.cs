using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Spawner spawner;
    public GameObject title;
    private Vector2 screenBounds;
    public GameObject playerPrefab;
    private GameObject player;
    private bool gameStarted = false;
<<<<<<< HEAD
    public GameObject splash;
=======
>>>>>>> 59ae817b774442a38ff2ddfc25c76879eb514a94
    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
<<<<<<< HEAD
=======
        player = playerPrefab;
>>>>>>> 59ae817b774442a38ff2ddfc25c76879eb514a94
    }
    // Start is called before the first frame update
    void Start()
    {
        spawner.active = false;
        title.SetActive(true);
        splash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            if (Input.anyKeyDown)
            {
                ResetGame();
            }
        } else
        {
            if (!player)
            {
                OnPlayerKilled();
            }
        }
<<<<<<< HEAD

=======
>>>>>>> 59ae817b774442a38ff2ddfc25c76879eb514a94
        var nextBomb = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject bombObject in nextBomb)
        {
            if (bombObject.transform.position.y < (-screenBounds.y) - 12 || !gameStarted)
            {
                Destroy(bombObject);
            }
        }
    }

    void ResetGame()
    {
        spawner.active = true;
        title.SetActive(false);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotation);
        gameStarted = true;
    }
     void OnPlayerKilled()
    {
        // when player killed
        spawner.active = false;
        gameStarted = false;

        splash.SetActive(true);
    }
}

void ResetGame()
{
    spawner.active = true;
    title.SetActive(false);
    splash.SetActive(false);
    player.Instantiate(playerPrefab, new Vector3(0, 0, 0), playerPrefab.transform.rotate);
    gameStarted = true;
}

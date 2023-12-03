
using UnityEngine;

//
// Atlantis v2021.03.04
//
// 2021.02.27
//

public class RightShipSpawner2 : MonoBehaviour
{
    public static RightShipSpawner2 spawner;

    public Transform[] ship;

    private float delayTimer;

    private float spawnTimer;

    [HideInInspector] public int randomShip;


    private void Awake()
    {
        spawner = this;
    }


    private void Start()
    {
        Initialise();
    }


    private void Update()
    {
        if (GameController.gameController.canPlay)
        {
            RunSpawnTimer();
        }
    }


    private void Initialise()
    {
        delayTimer = 3f;
    }


    private void RunSpawnTimer()
    {
        if (EnemyController.enemyController.leftShipActive2 || EnemyController.enemyController.rightShipActive2)
        {
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnShip();

            spawnTimer = delayTimer;
        }
    }


    private void SpawnShip()
    {
        randomShip = Random.Range(0, ship.Length);

        ship[randomShip].position = transform.position;

        ship[randomShip].gameObject.SetActive(true);

        EnemyController.enemyController.rightShipActive2 = true;
    }


} // end of class


using UnityEngine;

//
// Atlantis v2021.03.04
//
// 2021.02.27
//

public class LeftShipSpawner4 : MonoBehaviour
{
    public static LeftShipSpawner4 spawner;

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
        if (EnemyController.enemyController.leftShipActive4 || EnemyController.enemyController.rightShipActive4)
        {
            return;
        }

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            if (Random.Range(0, 100) > 75)
            {
                SpawnShip();
            }

            spawnTimer = delayTimer;
        }
    }


    private void SpawnShip()
    {
        randomShip = Random.Range(0, ship.Length);

        ship[randomShip].position = transform.position;

        ship[randomShip].gameObject.SetActive(true);

        EnemyController.enemyController.leftShipActive4 = true;

        AtlantisController.atlantisController.enemyDestroyedBase = false;
    }


} // end of class

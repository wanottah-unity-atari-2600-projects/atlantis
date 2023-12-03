
using UnityEngine;

//
// Atlantis v2021.03.07
//
// 2021.02.27
//

public class RightShipController2 : MonoBehaviour
{
    public static RightShipController2 rightShipController2;

    private float shipSpeed;


    private void Awake()
    {
        rightShipController2 = this;
    }



    private void Start()
    {
        Initialise();
    }


    private void Update()
    {
        if (GameController.gameController.canPlay)
        {
            MoveEnemy();
        }
    }


    private void Initialise()
    {
        shipSpeed = Random.Range(EnemyController.MINIMUM_ENEMY_SPEED, EnemyController.MAXIMUM_ENEMY_SPEED);
    }


    private void MoveEnemy()
    {
        Vector3 enemyShip = transform.position;

        enemyShip.x -= shipSpeed * Time.deltaTime;

        transform.position = enemyShip;

        if (transform.position.x < -2.5f)
        {
            DisableShip();
        }
    }


    private void DisableShip()
    {
        gameObject.SetActive(false);

        EnemyController.enemyController.rightShipActive2 = false;
    }


    private void DestroyShip(int shipPoints)
    {
        DisableShip();

        GameController.gameController.UpdatePlayer1Score(shipPoints);

        GameController.gameController.numberOfEnemiesDestroyed += 1;

        if (GameController.gameController.numberOfEnemiesDestroyed >= GameController.gameController.enemiesInWave)
        {
            GameController.gameController.NextWave();
        }
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        if (gameObject.CompareTag("Enemy 3"))
        {
            if (target.collider.CompareTag("Left Torpedo"))
            {
                //EnemyController.enemyController.DestroyAllEnemyShips();

                DestroyShip(EnemyController.ENEMY_3_POINTS);
            }

            if (target.collider.CompareTag("Centre Torpedo"))
            {
                //EnemyController.enemyController.DestroyAllEnemyShips();

                DestroyShip(EnemyController.ENEMY_3_POINTS);
            }

            if (target.collider.CompareTag("Right Torpedo"))
            {
                //EnemyController.enemyController.DestroyAllEnemyShips();

                DestroyShip(EnemyController.ENEMY_3_POINTS);
            }
        }

        else
        {
            if (target.collider.CompareTag("Left Torpedo"))
            {
                DestroyShip(GameController.LEFT_TORPEDO_SHIP_POINTS);
            }

            if (target.collider.CompareTag("Centre Torpedo"))
            {
                DestroyShip(GameController.CENTRE_TORPEDO_SHIP_POINTS);
            }

            if (target.collider.CompareTag("Right Torpedo"))
            {
                DestroyShip(GameController.RIGHT_TORPEDO_SHIP_POINTS);
            }
        }
    }


} // end of class

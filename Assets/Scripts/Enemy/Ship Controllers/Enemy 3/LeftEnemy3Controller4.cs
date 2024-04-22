
using UnityEngine;

//
// Atlantis v2021.03.06
//
// 2021.02.27
//

public class LeftEnemy3Controller4 : MonoBehaviour
{
    public static LeftEnemy3Controller4 leftEnemy3Controller4;

    public Transform laserBeam;

    private float shipSpeed;


    private void Awake()
    {
        leftEnemy3Controller4 = this;
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

            FireLaserBeam();
        }
    }


    private void Initialise()
    {
        shipSpeed = EnemyController.MAXIMUM_ENEMY_SPEED;
    }


    private void MoveEnemy()
    {
        Vector3 enemyShip = transform.position;

        enemyShip.x += shipSpeed * Time.deltaTime;

        transform.position = enemyShip;

        if (transform.position.x > 2.5f)
        {
            DisableShip();
        }
    }


    private void FireLaserBeam()
    {
        AttackShieldController();

        AttackBase();
    }


    private void AttackShieldController()
    {
        if (AtlantisController.atlantisController.shieldControllerDestroyed)
        {
            laserBeam.gameObject.SetActive(false);

            return;
        }

        if (transform.position.x > -1.45f && transform.position.x < 1.45f)
        {
            laserBeam.gameObject.SetActive(true);
        }
    }


    private void AttackBase()
    {
        if (!AtlantisController.atlantisController.baseCanBeDestroyed)
        {
            return;
        }

        if (!AtlantisController.atlantisController.enemyDestroyedBase)
        {
            if (transform.position.x > -1.45f && transform.position.x < 1.45f)
            {
                laserBeam.gameObject.SetActive(true);
            }

            else
            {
                laserBeam.gameObject.SetActive(false);
            }
        }
    }


    private void DisableShip()
    {
        gameObject.SetActive(false);

        EnemyController.enemyController.leftShipActive4 = false;

        if (AtlantisController.atlantisController.shieldControllerDestroyed)
        {
            AtlantisController.atlantisController.baseCanBeDestroyed = true;
        }
    }


    private void DestroyShip(int shipPoints)
    {
        DisableShip();

        EnemyController.enemyController.DestroyAllEnemyShips();

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
                DestroyShip(EnemyController.ENEMY_3_POINTS);
            }

            if (target.collider.CompareTag("Centre Torpedo"))
            {
                DestroyShip(EnemyController.ENEMY_3_POINTS);
            }

            if (target.collider.CompareTag("Right Torpedo"))
            {
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

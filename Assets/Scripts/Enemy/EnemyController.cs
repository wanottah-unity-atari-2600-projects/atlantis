
using UnityEngine;

//
// Atlantis v2021.03.06
//
// 2021.02.27
//

public class EnemyController : MonoBehaviour
{
    public static EnemyController enemyController;

    public const int WAVE_START_ENEMY_COUNT = 10;
    public const int MINIMUM_WAVE_ENEMY_INCREASE = 1;
    public const int MAXIMUM_WAVE_ENEMY_INCREASE = 6;
    public const int MAXIMUM_ENEMIES = 30;

    public const float MINIMUM_ENEMY_SPEED = 0.8f;
    public const float MAXIMUM_ENEMY_SPEED = 1.8f;

    public const int ENEMY_3_POINTS = 500;

    private const int NUMBER_OF_ENEMY_SHIPS = 4;

    public bool leftShipActive1;
    public bool leftShipActive2;
    public bool leftShipActive3;
    public bool leftShipActive4;

    public bool rightShipActive1;
    public bool rightShipActive2;
    public bool rightShipActive3;
    public bool rightShipActive4;


    private void Awake()
    {
        enemyController = this;
    }


    private void SetShipFlags()
    {
        leftShipActive1 = false;
        leftShipActive2 = false;
        leftShipActive3 = false;
        leftShipActive4 = false;

        rightShipActive1 = false;
        rightShipActive2 = false;
        rightShipActive3 = false;
        rightShipActive4 = false;
    }


    public void DisableEnemyShips()
    {
        SetShipFlags();

        for (int i = 0; i < NUMBER_OF_ENEMY_SHIPS; i++)
        {
            LeftShipSpawner1.spawner.ship[i].gameObject.SetActive(false);
            LeftShipSpawner2.spawner.ship[i].gameObject.SetActive(false);
            LeftShipSpawner3.spawner.ship[i].gameObject.SetActive(false);
            LeftShipSpawner4.spawner.ship[i].gameObject.SetActive(false);

            RightShipSpawner1.spawner.ship[i].gameObject.SetActive(false);
            RightShipSpawner2.spawner.ship[i].gameObject.SetActive(false);
            RightShipSpawner3.spawner.ship[i].gameObject.SetActive(false);
            RightShipSpawner4.spawner.ship[i].gameObject.SetActive(false);
        }
    }


    public void DestroyAllEnemyShips()
    {
        LeftShipController1.leftShipController1.gameObject.SetActive(false);
        LeftShipController2.leftShipController2.gameObject.SetActive(false);
        LeftShipController3.leftShipController3.gameObject.SetActive(false);
        LeftShipController4.leftShipController4.gameObject.SetActive(false);

        RightShipController1.rightShipController1.gameObject.SetActive(false);
        RightShipController2.rightShipController2.gameObject.SetActive(false);
        RightShipController3.rightShipController3.gameObject.SetActive(false);
        RightShipController4.rightShipController4.gameObject.SetActive(false);
       
        SetShipFlags();
    }


} // end of class

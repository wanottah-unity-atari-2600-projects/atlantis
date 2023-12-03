
using UnityEngine;

//
// Atlantis v2021.03.06
//
// 2021.02.27
//

public class AtlantisController : MonoBehaviour
{
    public static AtlantisController atlantisController;

    public Transform[] atlantisBase;

    public Transform shieldController;
    public Transform shield;

    public Transform motherShip;
    public Transform motherShipLaunchPlatform;

    public const int SHIELD_CONTROLLER_BONUS_POINTS = 1000;
    public const int BASE_BONUS_POINTS = 250;

    public const int BASE_1 = 0;
    public const int BASE_2 = 1;
    public const int BASE_3 = 2;
    public const int BASE_4 = 3;
    public const int BASE_5 = 4;
    public const int BASE_6 = 5;

    [HideInInspector] public int numberOfBases;

    [HideInInspector] public bool shieldControllerDestroyed;
    [HideInInspector] public bool baseCanBeDestroyed;
    [HideInInspector] public bool enemyDestroyedBase;
    [HideInInspector] public bool[] baseActive;



    private void Awake()
    {
        atlantisController = this;
    }


    public void EscapeAtlantis()
    {
        motherShip.gameObject.SetActive(true);
    }


    public void BuildAtlantis()
    {
        ActivateShield();

        for (int i = 0; i < atlantisBase.Length; i++)
        {
            atlantisBase[i].gameObject.SetActive(true);

            baseActive[i] = true;
        }

        DockMotherShip();
    }


    private void DockMotherShip()
    {
        motherShip.position = motherShipLaunchPlatform.position;
    }


    private void ActivateShield()
    {
        shieldController.gameObject.SetActive(true);

        shieldControllerDestroyed = false;

        baseCanBeDestroyed = false;

        shield.gameObject.SetActive(true);
    }


    public void RebuildAtlantis()
    {
        if (GameController.gameController.player1ExtraLives == 0)
        {
            return;
        }

        if (shieldControllerDestroyed)
        {
            ActivateShield();

            GameController.gameController.player1ExtraLives -= 1;

            if (GameController.gameController.player1ExtraLives == 0) { return; }
        }

        if (!baseActive[BASE_1])
        {
            ActivateBase(BASE_1);

            if (GameController.gameController.player1ExtraLives == 0) { return; }
        }

        if (!baseActive[BASE_2])
        {
            ActivateBase(BASE_2);

            if (GameController.gameController.player1ExtraLives == 0) { return; }
        }

        if (!baseActive[BASE_3])
        {
            ActivateBase(BASE_3);

            if (GameController.gameController.player1ExtraLives == 0) { return; }
        }

        if (!baseActive[BASE_4])
        {
            ActivateBase(BASE_4);

            if (GameController.gameController.player1ExtraLives == 0) { return; }
        }

        if (!baseActive[BASE_5])
        {
            ActivateBase(BASE_5);

            if (GameController.gameController.player1ExtraLives == 0) { return; }
        }

        if (!baseActive[BASE_6])
        {
            ActivateBase(BASE_6);
        }
    }


    private void ActivateBase(int baseNumber)
    {
        atlantisBase[baseNumber].gameObject.SetActive(true);

        GameController.gameController.player1ExtraLives -= 1;

        numberOfBases += 1;
    }


} // end of class

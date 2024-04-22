
using UnityEngine;

//
// Atlantis v2021.03.06
//
// 2021.02.27
//

public class BaseController : MonoBehaviour
{
    private void DestroyBase(string baseNumber)
    {
        switch (baseNumber)
        {
            case "Base 1":

                AtlantisController.atlantisController.atlantisBase[AtlantisController.BASE_1].gameObject.SetActive(false);

                AtlantisController.atlantisController.baseActive[AtlantisController.BASE_1] = false;
                
                break;

            case "Base 2":

                AtlantisController.atlantisController.atlantisBase[AtlantisController.BASE_2].gameObject.SetActive(false);

                AtlantisController.atlantisController.baseActive[AtlantisController.BASE_2] = false;

                break;

            case "Base 3":

                AtlantisController.atlantisController.atlantisBase[AtlantisController.BASE_3].gameObject.SetActive(false);

                AtlantisController.atlantisController.baseActive[AtlantisController.BASE_3] = false;

                break;

            case "Base 4":

                AtlantisController.atlantisController.atlantisBase[AtlantisController.BASE_4].gameObject.SetActive(false);

                AtlantisController.atlantisController.baseActive[AtlantisController.BASE_4] = false;

                break;

            case "Base 5":

                AtlantisController.atlantisController.atlantisBase[AtlantisController.BASE_5].gameObject.SetActive(false);

                AtlantisController.atlantisController.baseActive[AtlantisController.BASE_5] = false;

                break;

            case "Base 6":

                AtlantisController.atlantisController.atlantisBase[AtlantisController.BASE_6].gameObject.SetActive(false);

                AtlantisController.atlantisController.baseActive[AtlantisController.BASE_6] = false;

                break;
        }

        AtlantisController.atlantisController.enemyDestroyedBase = true;

        AtlantisController.atlantisController.numberOfBases -= 1;

        if (AtlantisController.atlantisController.numberOfBases == 0)
        {
            GameController.gameController.GameOver();
        }
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (AtlantisController.atlantisController.shieldControllerDestroyed)
        {
            if (target.CompareTag("Left Enemy 1 Laser Beam")) { DestroyBase(gameObject.tag); }

            if (target.CompareTag("Left Enemy 2 Laser Beam")) { DestroyBase(gameObject.tag); }

            if (target.CompareTag("Left Enemy 3 Laser Beam")) { DestroyBase(gameObject.tag); }

            if (target.CompareTag("Left Enemy 4 Laser Beam")) { DestroyBase(gameObject.tag); }

            if (target.CompareTag("Right Enemy 1 Laser Beam")) { DestroyBase(gameObject.tag); }

            if (target.CompareTag("Right Enemy 2 Laser Beam")) { DestroyBase(gameObject.tag); }

            if (target.CompareTag("Right Enemy 3 Laser Beam")) { DestroyBase(gameObject.tag); }

            if (target.CompareTag("Right Enemy 4 Laser Beam")) { DestroyBase(gameObject.tag); }
        }
    }


} // end of class

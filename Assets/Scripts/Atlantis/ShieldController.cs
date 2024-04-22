
using UnityEngine;

//
// Atlantis v2021.03.06
//
// 2021.02.27
//

public class ShieldController : MonoBehaviour
{
    private void DestroyShieldController()
    {
        // disable the shield controller / centre laser cannon
        gameObject.SetActive(false);

        // disable the shield
        AtlantisController.atlantisController.shield.gameObject.SetActive(false);

        AtlantisController.atlantisController.shieldControllerDestroyed = true;

        //GameController.gameController.baseCanBeDestroyed = true;
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Left Enemy 1 Laser Beam"))
        {
            DestroyShieldController();
        }
        
        if (target.CompareTag("Left Enemy 2 Laser Beam"))
        {
            DestroyShieldController();
        }

        if (target.CompareTag("Left Enemy 3 Laser Beam"))
        {
            DestroyShieldController();
        }

        if (target.CompareTag("Left Enemy 4 Laser Beam"))
        {
            DestroyShieldController();
        }

        if (target.CompareTag("Right Enemy 1 Laser Beam"))
        {
            DestroyShieldController();
        }
        
        if (target.CompareTag("Right Enemy 2 Laser Beam"))
        {
            DestroyShieldController();
        }

        if (target.CompareTag("Right Enemy 3 Laser Beam"))
        {
            DestroyShieldController();
        }

        if (target.CompareTag("Right Enemy 4 Laser Beam"))
        {
            DestroyShieldController();
        }
    }


} // end of class


using UnityEngine;

//
// Atlantis v2021.03.06
//
// 2021.02.27
//

public class Player1Controller : MonoBehaviour
{
    public static Player1Controller player1Controller;

    public Transform leftTorpedoLauncherTransform;
    public Transform centreTorpedoLauncherTransform;
    public Transform rightTorpedoLauncherTransform;

    public Transform leftTorpedoTargetTransform;
    public Transform centreTorpedoTargetTransform;
    public Transform rightTorpedoTargetTransform;

    private bool firingLeftLaserCannon;
    private bool firingRightLaserCannon;


    private void Awake()
    {
        player1Controller = this;
    }


    private void Update()
    {
        if (GameController.gameController.canPlay)
        {
            KeyboardController();
        }
    }


    public void Initialise()
    {
        firingLeftLaserCannon = false;
        firingRightLaserCannon = false;
    }


    private void KeyboardController()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            firingLeftLaserCannon = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            firingRightLaserCannon = true;
        }

        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyUp(KeyCode.Z))
        {
            firingLeftLaserCannon = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyUp(KeyCode.X))
        {
            firingRightLaserCannon = false;
        }

        // fire laser cannon
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!AtlantisController.atlantisController.shieldControllerDestroyed && !firingLeftLaserCannon && !firingRightLaserCannon)
            {
                LaunchCentreTorpedo();
            }

            if (firingLeftLaserCannon)
            {
                LaunchLeftTorpedo();
            }

            if (firingRightLaserCannon)
            {
                LaunchRightTorpedo();
            }
        }
    }


    private void LaunchLeftTorpedo()
    {
        GameObject leftTorpedoGameObject = Player1LeftCannonObjectPooler.player1LeftCannonObjectPooler.GetPooledObject();

        if (leftTorpedoGameObject != null)
        {
            leftTorpedoGameObject.transform.position = leftTorpedoLauncherTransform.position;

            leftTorpedoGameObject.SetActive(true);
        }
    }


    private void LaunchCentreTorpedo()
    {
        GameObject centreTorpedoGameObject = Player1CentreCannonObjectPooler.player1CentreCannonObjectPooler.GetPooledObject();

        if (centreTorpedoGameObject != null)
        {
            centreTorpedoGameObject.transform.position = centreTorpedoLauncherTransform.position;

            centreTorpedoGameObject.SetActive(true);
        }
    }


    private void LaunchRightTorpedo()
    {
        GameObject rightTorpedoGameObject = Player1RightCannonObjectPooler.player1RightCannonObjectPooler.GetPooledObject();

        if (rightTorpedoGameObject != null)
        {
            rightTorpedoGameObject.transform.position = rightTorpedoLauncherTransform.position;

            rightTorpedoGameObject.SetActive(true);
        }
    }


} // end of class


using UnityEngine;

//
// Atlantis v2021.03.05
//
// 2021.02.27
//

public class MotherShipController : MonoBehaviour
{
    private float motherShipSpeed;



    private void Start()
    {
        Initialise();
    }


    void Update()
    {
        MoveMotherShip();
    }


    private void Initialise()
    {
        motherShipSpeed = 0.5f;
    }


    private void MoveMotherShip()
    {
        Vector3 direction = (Player1Controller.player1Controller.leftTorpedoTargetTransform.position - transform.position).normalized;

        transform.position += direction * motherShipSpeed * Time.deltaTime;

        if (Vector3.Distance(Player1Controller.player1Controller.leftTorpedoTargetTransform.position, transform.position) <= 0.1f)
        {
            GameOver();
        }
    }


    private void GameOver()
    {
        gameObject.SetActive(false);

        GameController.gameController.gameOver = true;

        GameController.gameController.UpdateHighScore();

        GameController.gameController.gameOverText.gameObject.SetActive(true);
    }


} // end of class

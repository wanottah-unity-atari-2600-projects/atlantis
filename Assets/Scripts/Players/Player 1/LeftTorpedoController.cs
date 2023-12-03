
using UnityEngine;

//
// Atlantis v2021.03.05
//
// 2021.02.27
//

public class LeftTorpedoController : MonoBehaviour
{
    private float torpedoSpeed;


    private void Start()
    {
        Initialise();
    }


    void Update()
    {
        MoveTorpedo();
    }


    private void Initialise()
    {
        torpedoSpeed = 3f;
    }


    private void MoveTorpedo()
    {
        Vector3 direction = (Player1Controller.player1Controller.rightTorpedoTargetTransform.position - transform.position).normalized;

        transform.position += direction * torpedoSpeed * Time.deltaTime;

        if (Vector3.Distance(Player1Controller.player1Controller.rightTorpedoTargetTransform.position, transform.position) <= 0.1f)
        {
            gameObject.SetActive(false);
        }
    }


    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.collider.CompareTag("Enemy 1"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Enemy 2"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Enemy 3"))
        {
            gameObject.SetActive(false);
        }

        if (target.collider.CompareTag("Enemy 4"))
        {
            gameObject.SetActive(false);
        }
    }


} // end of class

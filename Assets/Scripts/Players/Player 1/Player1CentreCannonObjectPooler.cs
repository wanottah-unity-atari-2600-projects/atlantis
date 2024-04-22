
using System.Collections.Generic;
using UnityEngine;

//
// Atlantis v2021.03.02
//
// 2021.02.27
//

public class Player1CentreCannonObjectPooler : MonoBehaviour
{
    public static Player1CentreCannonObjectPooler player1CentreCannonObjectPooler;


    public List<GameObject> pooledObject;

    public GameObject objectToPool;

    private GameObject pooledGameObject;

    private int amountToPool;

    private bool objectPoolCanExpand;



    private void Awake()
    {
        player1CentreCannonObjectPooler = this;
    }


    private void Start()
    {
        Initialise();
    }


    private void Initialise()
    {
        pooledObject = new List<GameObject>();

        amountToPool = 2;

        for (int i = 0; i < amountToPool; i++)
        {
            CreatePooledObject();
        }

        objectPoolCanExpand = false;
    }


    private void CreatePooledObject()
    {
        pooledGameObject = Instantiate(objectToPool);

        pooledGameObject.name = "Player 1 Centre Torpedo";

        pooledGameObject.transform.SetParent(transform);

        pooledGameObject.SetActive(false);

        pooledObject.Add(pooledGameObject);
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObject.Count; i++)
        {
            if (!pooledObject[i].activeInHierarchy)
            {
                return pooledObject[i];
            }
        }

        if (objectPoolCanExpand)
        {
            CreatePooledObject();

            return pooledGameObject;
        }

        return null;
    }


} // end of class

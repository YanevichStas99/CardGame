using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public GameObject[] objects;
    void Start()
    {
        for (int i = 0; i> 36; i++)
        {
            GameObject tempObject;
            int rand = Random.Range(1,37);
            tempObject = objects[i];
            objects[i] = objects[rand];
            objects[rand] = tempObject;
           
        }
        
    }

    
}

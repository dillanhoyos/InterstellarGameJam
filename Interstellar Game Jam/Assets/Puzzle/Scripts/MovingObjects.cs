using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Moving; 
   
    [SerializeField] 
    private GameObject[] PlaceHolders;

    public float speed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MovetoTrophy()
    {
        StartCoroutine(MoveAtoB(Moving, PlaceHolders, speed));

    }

   IEnumerator MoveAtoB(GameObject[] gameObjectA, GameObject[] gameObjectB,float speedTranslation)
   {
    for(int i = 0; i < Moving.Length; i++){

    while(gameObjectA[i].transform.position != gameObjectB[i].transform.position)
    {
        gameObjectA[i].transform.position = Vector3.MoveTowards(gameObjectA[i].transform.position, gameObjectB[i].transform.position, speedTranslation*Time.deltaTime);
        yield return null;   
    }

    }
        

   }
}

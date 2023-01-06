using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Triggerforlever : MonoBehaviour
{
   
    public Material triggered; 
    public Material notTriggered; 
    public UnityEvent OpenLadder;
    public UnityEvent CloseLadder;
    private Renderer thisRend;

    void Start()
    {
        thisRend = this.GetComponent<Renderer>();

    }


    private void OnTriggerEnter(Collider other)
    {
       Debug.Log(other.gameObject);

        if(other.CompareTag("Puzzle Switch"))
        {
            Debug.Log("WTF");
            thisRend.material = triggered;
            OpenLadder.Invoke();
        }   
        else
        {
              Debug.Log("1WTF");
            
            thisRend.material = notTriggered;

        }
      
        

    }
    private void OnTriggerExit(Collider other)
    {
      if(other.CompareTag("Puzzle Switch"))
        {
            
            thisRend.material = notTriggered;
            CloseLadder.Invoke();
        }   
      
    }
}

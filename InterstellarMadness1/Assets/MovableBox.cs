using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBox : MonoBehaviour
{

    public bool canPressE;
    // Start is called before the first frame update
   private void onTriggerEnter(Collider other)
   {
        if(other.gameObject.tag == "Player")
        {
            canPressE = true;
        }
   }

   private void OnTriggerExit(Collider other)
   {
        if(other.gameObject.tag == "Player")
        {
            canPressE = false;
        }
   }
   }


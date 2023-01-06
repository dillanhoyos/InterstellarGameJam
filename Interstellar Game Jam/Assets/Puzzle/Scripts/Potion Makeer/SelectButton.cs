using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour
{
    //public AK.Wwise.Event ButtonSound;
    
    public Material lMat;
    public Material nMat;
    private Renderer myR; 
    private Vector3 myTransform;

    public RobotLogic myLogic;

    public int myNumber = 99;

    public delegate void ClickEv(int number);
    public event ClickEv onClick;

    private void Awake()
    {
        myR = GetComponent<Renderer>();
        myR.enabled = true;

        myTransform = transform.position;
    }


    public void OnInteractStart()
    {
        if(myLogic.Player){
            ClickedColor();
        // transform.position = new Vector3 (myTransform.x, -0.001f,myTransform.z);

        onClick.Invoke(myNumber);
        }
        
    }

    public void OnInteractStop()
    {
        UnClickedColor();
        // transform.position = new Vector3 (myTransform.x, myTransform.y ,myTransform.z);

    }

    public void ClickedColor()
    {
            myR.sharedMaterial = nMat;
            //ButtonSound.Post(gameObject);

    }

    public void UnClickedColor()
    {
            myR.sharedMaterial = lMat;
    }
}

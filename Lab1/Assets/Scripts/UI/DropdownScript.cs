using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownScript : MonoBehaviour
{
    public TextMeshProUGUI menuText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePhysics()
    {
        //Debug.Log("Changing Physics Equations");
        if (menuText.text == "EulerPosition")
        {
            //Debug.Log("EulerPosition");
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateEuler = true;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateEuler = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateKinematic = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateKinematic = false;
        }
        else if (menuText.text == "KinematicPosition")
        {
            //Debug.Log("KinematicPosition");
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateEuler = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateEuler = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateKinematic = true;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateKinematic = false;
        }
        else if (menuText.text == "EulerRotation")
        {
            //Debug.Log("EulerRotation");
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateEuler = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateEuler = true;
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateKinematic = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateKinematic = false;
        }
        else if (menuText.text == "KinematicRotation")
        {
            //Debug.Log("KinematicRotation");
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateEuler = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateEuler = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().positionUpdateKinematic = false;
            GameObject.Find("Cube").GetComponent<Particle2D>().rotationUpdateKinematic = true;
        }
    }
}

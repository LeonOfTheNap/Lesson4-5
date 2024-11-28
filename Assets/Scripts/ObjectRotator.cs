using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float rotationSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        //uzmi nasumičan broj u postoku od 50% do 150% od rotationSpeed
        rotationSpeed = Random.Range(0.5f * rotationSpeed, 1.5f * rotationSpeed);
        var noviBroj = Random.Range(0, 2); //0, 1
    }

    public void FixedUpdate()
    {
        //rotiraj oko Z osi (onoj kojoj izlazi iz ekrana)
        transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
    }
}

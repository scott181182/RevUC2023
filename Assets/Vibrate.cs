using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrate : MonoBehaviour
{
private Vector3 initialPosition;
private Vector3 directionOfShake;
public float amplitude = 0.01f; // the amount it moves
public float frequency = 2f; // the period of the earthquake

void Start(){
    initialPosition = transform.position; // store this to avoid floating point error drift
    directionOfShake = transform.right;
}



void Update(){
     transform.position = initialPosition + directionOfShake*Mathf.Sin(frequency * Time.time)*amplitude;
}
}

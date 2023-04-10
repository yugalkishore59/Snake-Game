using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    int xMin=-24,xMax=24,yMin=-13,yMax=13;

    private void Start() {
        GoRandomPos();
    }

    void GoRandomPos(){
        int x = Random.Range(xMin,xMax);
        int y = Random.Range(yMin,yMax);
        transform.position = new Vector3(x,y,0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag=="Snake"){
            GoRandomPos();
        }
    }

}

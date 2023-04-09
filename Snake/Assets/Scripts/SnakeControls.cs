using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControls : MonoBehaviour
{
    Vector2 direction = Vector2.right;
    //Rigidbody2D rb;
    [SerializeField] GameObject body;
    List<GameObject> bodyList = new List<GameObject>();

    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>();
        bodyList.Add(gameObject);
    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate() {
        Move();
    }

    void GetInput(){
        if(Input.GetKeyDown("w")){
            direction = (direction==Vector2.down?direction:Vector2.up);
        }
        else if(Input.GetKeyDown("s")){
            direction = (direction==Vector2.up?direction:Vector2.down);
        }
        else if(Input.GetKeyDown("a")){
            direction = (direction==Vector2.right?direction:Vector2.left);
        }
        else if(Input.GetKeyDown("d")){
            direction = (direction==Vector2.left?direction:Vector2.right);
        }
    }

    void Move(){
        for(int i=bodyList.Count-1;i>0;i--){
            bodyList[i].transform.position = bodyList[i-1].transform.position;
        }
        gameObject.transform.position += new Vector3(direction.x,direction.y,0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Apple"){
            SpawnBody();
        }
    }

    void SpawnBody(){
        bodyList.Add(Instantiate(body,bodyList[bodyList.Count-1].transform.position,transform.rotation));
    }
}

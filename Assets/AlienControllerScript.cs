using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienControllerScript : MonoBehaviour
{
    public Rigidbody2D alien;
    private Rigidbody2D[] aliens;
    private Vector3 direction;
    void Start()
    {
        direction = Vector3.left;
        aliens = new Rigidbody2D[45];
        for(int i =0; i < 9; i++){
            for(int j = 0; j < 5; j++){
                Vector3 tempVector = new Vector3(i,j,1);
                aliens[i*5+j] = Instantiate(alien, Vector3.zero+tempVector, Quaternion.identity);
            }
        }
    }
  
    bool pushDownNextUpdate = false;
    void Update()
    {
        float edgeMostAlienPosition = -100;
        Vector3 currentDirection = direction;

        for(int i =0; i < 9; i++){
            for(int j = 0; j < 5; j++){
                if(!aliens[i*5+j])continue;
                aliens[i*5+j].transform.position += currentDirection * Time.deltaTime;
                if(pushDownNextUpdate){
                    aliens[i*5+j].transform.position += Vector3.down * 30 * Time.deltaTime;
                }
                if(currentDirection == Vector3.left){
                    if(edgeMostAlienPosition == -100 || aliens[i*5+j].transform.position.x < edgeMostAlienPosition){
                        edgeMostAlienPosition =aliens[i*5+j].transform.position.x;
                    }
                }else{
                    if(edgeMostAlienPosition == -100 || aliens[i*5+j].transform.position.x > edgeMostAlienPosition){
                        edgeMostAlienPosition = aliens[i*5+j].transform.position.x;
                    }
                }
                
            }
        }
        pushDownNextUpdate = false;
        
        if(currentDirection == Vector3.left){
            
            if(edgeMostAlienPosition < -8){
                Debug.Log("Switching to right"); 
                direction = Vector3.right;
                pushDownNextUpdate = true;
            }
        }else{
            if(edgeMostAlienPosition > 8){ 
                Debug.Log("Switching to left"); 
                direction = Vector3.left;
                pushDownNextUpdate = true;
            }
        }
    }
    
    
}

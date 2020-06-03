using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D projectile;

    void Start()
    {
        
    }
    // Update is called once per frame
    bool shotOnScreen = false;
    Rigidbody2D clone = null;
    void Update()
    {
        if(clone == null){
            shotOnScreen = false;
        }
        if(clone != null && !clone.GetComponent<Renderer>().isVisible){
            Destroy (clone.gameObject);
            shotOnScreen = false;
            clone = null;
        }
        if (Input.GetKey(KeyCode.Space) && !shotOnScreen){
            shotOnScreen = true;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector2.up * 5);
        }
        
     
    }
}

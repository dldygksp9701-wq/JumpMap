using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opstacle : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public float jumpUp;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            _rigidbody.AddForce(Vector3.up * jumpUp ,ForceMode.Impulse);
        }
    }
}

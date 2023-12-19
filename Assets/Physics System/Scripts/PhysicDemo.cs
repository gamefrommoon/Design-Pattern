using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicDemo : MonoBehaviour
{
    public string nameID;
    public Rigidbody myRigidbody;
    public float velocity = 10f;
    public float force = 10f;
    public ForceMode forceMode;
    public Vector3 physicDir = Vector3.right;

    // Start is called before the first frame update
    private void Start()
    {
        nameID = gameObject.name;
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            AddVelocity();
        if (Input.GetKeyDown(KeyCode.F))
            AddForce();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PhysicDemo.DevLog($"My name is {nameID}, TRIGGER ENTER with {other.gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        //PhysicDemo.DevLog($"My name is {nameID}, TRIGGER EXIT with {other.gameObject.name}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        PhysicDemo.DevLog($"My name is {nameID}, COLLISION ENTER with {collision.gameObject.name}");
    }

    private void OnCollisionExit(Collision collision)
    {
        //PhysicDemo.DevLog($"My name is {nameID}, COLLISION EXIT with {collision.gameObject.name}");
    }

    public void AddVelocity()
    {
        //DevLog($"My name is {nameID}, ADD VELOCITY");
        if (!myRigidbody)
            return;
        myRigidbody.velocity = physicDir * velocity;
        DevLog($"My name is {nameID}, ADD VELOCITY");
    }

    public void AddForce()
    {
        //DevLog($"My name is {nameID}, ADD VELOCITY");
        if (!myRigidbody)
            return;
        myRigidbody.AddForce(force * physicDir, forceMode);
        DevLog($"My name is {nameID}, ADD FORCE");
    }

    public static void DevLog(string str)
    {
        Debug.Log(str);
    }
}

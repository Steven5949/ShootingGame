using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float mSpeed, mTorque;
    private Rigidbody mRB;
    private void Awake()
    {
        mRB = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        mRB.velocity = Vector3.back * mSpeed;
        mRB.angularVelocity = Random.onUnitSphere * mTorque;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}

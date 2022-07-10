using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float mSpeed;
    private Rigidbody mRB;

    void Start()
    {
        mRB = GetComponent<Rigidbody>();
        mRB.velocity = transform.forward * mSpeed;
    }
}

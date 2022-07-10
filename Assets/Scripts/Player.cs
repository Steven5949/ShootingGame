using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float mSpeed;
    private Rigidbody mRB;

    [SerializeField]
    private float mXMax, mXMin, mZMax, mZMin;
    [SerializeField]
    private float mTilt;

    [SerializeField]
    private BulletPool mPool;
    [SerializeField]
    private Transform mBulletPos;

    [SerializeField]
    private float mFireRate;
    private float mCurrentFireRate;

    void Start()
    {
        mRB = GetComponent<Rigidbody>();
        mCurrentFireRate = 0;
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        mRB.velocity = new Vector3(horizontal,0,vertical).normalized *mSpeed;
        mRB.rotation = Quaternion.Euler(0, 0, mTilt * -horizontal);
        mRB.position = new Vector3(Mathf.Clamp(transform.position.x, mXMin, mXMax)
                                   , transform.position.y
                                   , Mathf.Clamp(transform.position.z, mZMin, mZMax));
        
        if (0>= mCurrentFireRate && Input.GetButtonDown("Fire1"))
        {
            Bullet newBullet = mPool.GetFromPool();
            newBullet.transform.position = mBulletPos.position;
            mCurrentFireRate = mFireRate;
        }
        mCurrentFireRate -= Time.deltaTime;
    }
}

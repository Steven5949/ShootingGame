using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScrolling : MonoBehaviour
{
    private Renderer mRend;
    private Material mMeterial;

    [SerializeField]
    private float mSpeed;
    private float mOffset;
    void Start()
    {
        mRend = GetComponent<Renderer>();
        mMeterial = mRend.material;
        mOffset = 0;
    }
    void Update()
    {
        mOffset += mSpeed * Time.deltaTime;
        mMeterial.SetTextureOffset("_MainTex", new Vector2(0, mOffset));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private T[] mOrigin;
    private List<T>[] mPool;
    void Start()
    {
        mPool = new List<T>[mOrigin.Length];
        for (int i = 0; i < mPool.Length; i++)
        {
            mPool[i] = new List<T>();
        }
    }
    public T GetFromPool(int index = 0)
    {
        for (int i = 0; i < mPool[index].Count; i++)
        {
            if (!mPool[index][i].gameObject.activeInHierarchy)
            {
                mPool[index][i].gameObject.SetActive(true);
                return mPool[index][i];
            }
        }
        T newObj = Instantiate(mOrigin[index]);
        mPool[index].Add(newObj);
        return newObj;
    }
}

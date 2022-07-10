using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private AsteroidPool mAsteroidPool;
    [SerializeField]
    private float mPeriod;
    [SerializeField]
    private float mSpawnCount;
    void Start()
    {
        StartCoroutine(spawnHazard());
    }

    private IEnumerator spawnHazard()
    {
        while (true)
        {
            //wait
            yield return new WaitForSeconds(mPeriod);
            //execute
            for (int i = 0; i < mSpawnCount; i++)
            {
                Asteroid ast = mAsteroidPool.GetFromPool(Random.Range(0,3));
                ast.transform.position = new Vector3(Random.Range(-5.6f, 5.6f), 0, 16);
                yield return new WaitForSeconds(.3f);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLimit : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}

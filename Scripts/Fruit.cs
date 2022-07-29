using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject effectCollect;

    public void Collect()
    {
        Debug.Log("Esta fruta foi coletada!");

        GameObject ec = Instantiate(effectCollect, transform.position, transform.rotation);

        Destroy(this.gameObject);
    }
}

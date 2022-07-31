using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject projectil;
    public void Shot()
    {
        GameObject p = Instantiate(projectil, transform.position, transform.rotation);
    }
}

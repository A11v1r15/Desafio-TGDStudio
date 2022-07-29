using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIn : MonoBehaviour
{
    [SerializeField] private float time;
    void Start()
    {
        Destruct(Time);
    }
    public void Destruct(float time = 0)
    {
        Destroy(this.gameObject, time);
    }

    public float Time
    {
        get { return this.time;  }
        set { this.time = value; }
    }
}

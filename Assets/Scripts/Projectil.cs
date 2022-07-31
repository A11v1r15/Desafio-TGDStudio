using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField] private float velocity;
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Velocity;
    }

    public void Hit()
    {
        Destroy(this.gameObject);
    }

    public float Velocity
    {
        get { return this.velocity;  }
        set { this.velocity = value; }
    }
}

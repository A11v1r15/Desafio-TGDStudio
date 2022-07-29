using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool active;
    [SerializeField] private float timeShot;
    [SerializeField] private float currentTime;
    [SerializeField] private float timeOutActive;

    [SerializeField] private Spawn _sp;

    void Start()
    {
        Active = false;
        CurrentTime = 0;
        _sp = GetComponentInChildren<Spawn>();
    }

    void Update()
    {
        Shot();
    }

    public void Shot()
    {
        if (Active)
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= TimeShot)
            {
                CurrentTime = 0;
                _sp.Shot();
            }
        }
    }

    public void Hit()
    {
        Destroy(this.gameObject);
    }

    public void ActiveTrigger()
    {
        StartCoroutine(Trigger(TimeOutActive));
    }

    private IEnumerator Trigger(float waitTime)
    {
        Active = true;
        yield return new WaitForSeconds(waitTime);
        Active = false;
        
    }

    public bool Active
    {
        get { return this.active;  }
        set { this.active = value; }
    }

    public float TimeShot
    {
        get { return this.timeShot;  }
        set { this.timeShot = value; }
    }

    public float CurrentTime
    {
        get { return this.currentTime;  }
        set { this.currentTime = value; }
    }

    public float TimeOutActive
    {
        get { return this.timeOutActive;  }
        set { this.timeOutActive = value; }
    }
}

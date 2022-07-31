using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [SerializeField] private Player    _player;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private LayerMask _whatIsEnemy;
    [SerializeField] private LayerMask _whatIsTrigger;
    void Start()
    {
        _player = GetComponentInParent<Player>();
    }

    void Update()
    {
        _player.Jumping = !(Physics2D.OverlapCircle(this.transform.position, 0.2f, _whatIsGround)); //Se está no chão, não está pulando

        if (Physics2D.OverlapCircle(this.transform.position, 0.2f, _whatIsEnemy))
        {
            (Physics2D.OverlapCircle(this.transform.position, 0.2f, _whatIsEnemy)).gameObject.GetComponent<Enemy>().Hit();
            _player.Jumping = false;
            _player.ForceTo(_player.transform.up * (_player.Force));
        }

        if(Physics2D.OverlapCircle(this.transform.position, 0.2f, _whatIsTrigger))
        {
            if (!(Physics2D.OverlapCircle(this.transform.position, 0.2f, _whatIsTrigger).gameObject.GetComponentInParent<Enemy>().Active))
            {
                Physics2D.OverlapCircle(this.transform.position, 0.2f, _whatIsTrigger).gameObject.GetComponentInParent<Enemy>().ActiveTrigger();
            }
           
        }
      
    }


}

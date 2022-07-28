using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
	[SerializeField] public Player _player;

	private void Start()
	{
		_player = GetComponentInParent<Player>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		string tag = collision.tag;

		if (tag == "Ground")
		{
			_player.Jumping = false;
			Debug.Log("Está no chão!");
		}
	}
}

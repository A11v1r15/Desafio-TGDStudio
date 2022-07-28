﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] private float velocity;
	[SerializeField] private float force;
	[SerializeField] private bool flip;
	[SerializeField] private bool jumping;

	[SerializeField] private Rigidbody2D _rigidbody2d;
	[SerializeField] private SpriteRenderer _spriteRenderer;

	// Start is called before the first frame update
	void Start()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();

		Flip = false; //Inicia olhando para direita

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey("a")) Left();
		if (Input.GetKey("d")) Right();
		if (Input.GetKeyDown("space")) Jump();

		//Verificações
		VerifyFlip();

	}

	public void Left()
	{
		HorizontalMove(-Velocity);
		Flip = true;
	}

	public void Right()
	{
		HorizontalMove(Velocity);
		Flip = false;
	}

	public void HorizontalMove(float velocity)
	{
		transform.position += transform.right * Time.deltaTime * velocity;
	}

	public void Jump()
	{
		if(!Jumping) ForceTo(transform.up * Force);
	}

	private void ForceTo(Vector2 v)
	{
		_rigidbody2d.AddForce(v, ForceMode2D.Impulse);
	}

	private void VerifyFlip()
	{
		if (Flip) _spriteRenderer.flipX = true;
		else _spriteRenderer.flipX = false;
	}

	//Getters e Setters
	public float Velocity
	{
		get { return this.velocity; }
		set { this.velocity = value; }
	}

	public float Force
	{
		get { return this.force; }
		set { this.force = value; }
	}

	public bool Flip
	{
		get { return this.flip; }
		set { this.flip = value; }
	}

	public bool Jumping
	{
		get { return this.jumping; }
		set { this.jumping = value; }
	}
}
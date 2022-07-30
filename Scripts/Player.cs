using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField] private bool  active;
	[SerializeField] private float velocity;
	[SerializeField] private float force;
	[SerializeField] private bool  flip;
	[SerializeField] private bool  jumping;

	[SerializeField] private Rigidbody2D    _rigidbody2d;
	[SerializeField] private SpriteRenderer _spriteRenderer;
	[SerializeField] private Animator		_animator;

	[SerializeField] private int fruits;

	[SerializeField] private Text txtFrutas;

	[SerializeField] private GameObject gameWin;

	// Start is called before the first frame update
	void Start()
	{
		_rigidbody2d    = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_animator		= GetComponent<Animator>();

		Flip = false; //Inicia olhando para direita

		Fruits = 0;

		active = true;
	}

	// Update is called once per frame
	void Update()
	{
        if (active)
        {
			if (Input.GetKey("a")) Left();
			if (Input.GetKey("d")) Right();
			if (Input.GetKeyDown("space")) Jump();
		}
		

		//Verificações
		VerifyFlip();
		VerifyAnimation();

		txtFrutas.text = "Fruits: " + Fruits.ToString() + "/35";

		if (Fruits >= 35) {
			active = false;
			GameObject gw = Instantiate(gameWin, new Vector3(0,0,0), transform.rotation);
			Destroy(this.gameObject);
		}
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

	public void ForceTo(Vector2 v)
	{
		_rigidbody2d.AddForce(v, ForceMode2D.Impulse);
	}

	private void VerifyFlip()
	{
		if (Flip) _spriteRenderer.flipX = true;
		else _spriteRenderer.flipX = false;
	}

	private void VerifyAnimation()
    {
		_animator.SetBool("Jumping", Jumping);
    }

    //Colisões
    void OnTriggerEnter2D(Collider2D collision)
    {
		string tag = collision.gameObject.tag;

		Debug.Log(tag);

        if (tag == "Fruit")
        {
			collision.gameObject.GetComponent<Fruit>().Collect();
        } else if(tag == "Enemy")
        {
			//collision.gameObject.GetComponent<Projectil>().Hit();
			SceneManager.LoadScene("Desafio");
			Destroy(this.gameObject);
        }
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

	public int Fruits
	{
		get { return this.fruits; }
		set { this.fruits = value; }
	}
}

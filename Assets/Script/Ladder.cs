using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{
	public bool Button_atas,Button_bawah;
	private float vertical;
	private float speed = 4f;
	private bool Ladders;
	private bool Climb;
	Animator anim;
	
	[SerializeField] private Rigidbody2D rb;
	
    // Start is called before the first frame update
    void Start()
    {
		anim=GetComponent<Animator>(); //Inisialisasi Componen Animasi
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
		
		if (Ladders && Mathf.Abs(vertical)>0f)
		{
			Climb = true;
		}
		
		if(Ladders==true &&  (Button_atas==true))
        {
			Climb=true;
			rb.gravityScale = 0f;
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else if (Ladders==true &&  (Button_bawah==true))
		{
			Climb=true;
			rb.gravityScale = 0f;
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}
    }

	void FixedUpdate()
    {
		if (Climb)
		{
			rb.gravityScale = 0f;
			rb.velocity = new Vector2(rb.velocity.x,vertical*speed);
		}
		else
		{
			rb.gravityScale = 1f;
		}
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
			
			Ladders = true;
			anim.SetBool("lompat", false);
			anim.SetBool("climb", true);
		}
	}
	
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ladder"))
		{
			Ladders = false;
			Climb = false;
			anim.SetBool("lompat", true);
			anim.SetBool("climb", false);
		}
	}
	
	public void tekan_atas()
	{
		Button_atas=true;
	}
		
		public void lepas_atas()
	{
		Button_atas=false;
	}
	
	//
	
	public void tekan_bawah()
	{
		Button_bawah=true;
	}
		
		public void lepas_bawah()
	{
		Button_bawah=false;
	}
}
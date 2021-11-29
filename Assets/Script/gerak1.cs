using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gerak1 : MonoBehaviour
{
	public bool Button_kanan,Button_kiri,Button_atas,Button_bawah,Button_jump,Button_slide;
	
    public int kecepatan; //kecepatan gerak
    public int kekuatanlompat; //variabel kekuatan lompat
    public bool balik;
    public int pindah;
    Rigidbody2D lompat; //lompat sebagai nama dari Rigidbody2D
    //Variabel sensor tanah
    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;
	//public int koin;
	public int jumlah;
	
	// Start is called before the first frame update
    //Animasi
    Animator anim; //sebagai vaiabel Animator

	//Text info_koin;
	
	
    void Start()
    {
        lompat=GetComponent<Rigidbody2D>(); //inisialisasi awal untuk lompat
        anim=GetComponent<Animator>(); //Inisialisasi Componen Animasi
		jumlah=0;
    }

    // Update is called once per frame
	void Update()
    {
		//info_koin.text=koin.ToString();
		
        //Logik untuk Animasi
        if(tanah == false)
        {
            anim.SetBool("lompat", true);
        }
        else
        {
            anim.SetBool("lompat", false);
        }

        //sensor tanah
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);
        //control player
        if (Input.GetKey (KeyCode.D) || (Button_kanan==true)) //Key D untuk bergerak ke kanan
        {
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime); 
            pindah=-1;
            anim.SetBool("lari", true); //animasi lari
        }
        else if (Input.GetKey (KeyCode.A)|| (Button_kiri==true)) //key A untuk bergerak ke kiri
        {
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah=1;
            anim.SetBool("lari", true); //aimasi lari
        }
		else if (tanah==true && Input.GetKey(KeyCode.LeftShift)|| (Button_slide==true)) //Sliding
		{
			if (pindah==-1)
			{
				transform.Translate(Vector2.right*kecepatan*Time.deltaTime);
			}
			else if (pindah==1)
			{
				transform.Translate(Vector2.left*kecepatan*Time.deltaTime);
			}				
			anim.SetBool("sliding",true); // animasi sliding
		}
        else
        {
			anim.SetBool("sliding",false); //stop sliding
            anim.SetBool("lari", false); //Tidak Berlari
        }


        //lompat dengan klik window
        // if(tanah == true && Input.GetKey(KeyCode.Space)) //Mouse0 = klik kiri Mouse1=Klik Kanan
        // {
        //     lompat.AddForce(new Vector2(0,kekuatanlompat));
        // }
        //Lompat dengan Button Lompat mobile
        if(tanah==true &&  (Button_jump==true))
        {
            lompat.AddForce(new Vector2(0,kekuatanlompat));
        }
        
        //logik balik badan
        if(pindah > 0 && !balik)
        {
            flip();
        }
        else if(pindah < 0 && balik)
        {
            flip();
        }

    }
	
    //fungsi balik badan
    void flip()
    {
        balik = !balik;
        Vector3 Player = transform.localScale;
        Player.x *= -1;
        transform.localScale = Player;
    }
	
	//fungsi tombol
	public void tekan_kiri()
	{
		Button_kiri=true;
	}
		
	public void lepas_kiri()
	{
		Button_kiri=false;
	}
	
	//
	
	public void tekan_kanan()
	{
		Button_kanan=true;
	}
		
		public void lepas_kanan()
	{
		Button_kanan=false;
	}
	
	//
	
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
	
	//
	
	public void tekan_jump()
	{
		Button_jump=true;
	}
		
		public void lepas_jump()
	{
		Button_jump=false;
	}
	
	//
	
	public void tekan_slide()
	{
		Button_slide=true;
	}
		
		public void lepas_slide()
	{
		Button_slide=false;
	}
}

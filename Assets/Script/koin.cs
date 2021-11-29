using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class koin : MonoBehaviour
{
	public int coinValue=1;

    //Fungsi ketika menyentuh
    void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("Karakter"))
		{
			ScoreManager.instance.ChangeScore(coinValue);
			Destroy (gameObject);
		}
    }
	
}

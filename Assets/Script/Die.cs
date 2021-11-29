using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{
	public GameObject panelOver;
	
    // Start is called before the first frame update
	void OnCollisionEnter2D(Collision2D target)
	{
		if (target.gameObject.tag == "Enemy")
		{
			Died();
		}
	}
	public void Died()
	{
		if (Time.timeScale == 1)
		{
			panelOver.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
			panelOver.SetActive(false);
		}
	}

}

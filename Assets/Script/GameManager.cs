using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject panelPause;
	public GameObject panelOver;
	public GameObject panelTutor;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void PauseControl()
	{
		if (Time.timeScale == 1)
		{
			panelPause.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
			panelPause.SetActive(false);
		}
	}
	
	public void Tutor()
	{
		if (Time.timeScale == 1)
		{
			panelTutor.SetActive(true);
		}
	}
	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
		panelPause.SetActive(false);
	}
	
	public void MenuUtama()
	{
		Application.LoadLevel(0);
		Time.timeScale = 1;
	}
	
	public void Play()
	{
		Application.LoadLevel(1);
		Time.timeScale = 1;
	}
	
	public void Exit()
	{
		Application.Quit();
	}
	
}

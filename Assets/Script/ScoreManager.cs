using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;
	public Text text;
	public int score;
	public GameObject panelWin;
	
    // Start is called before the first frame update
    void Start()
    {
        if(instance==null)
		{
			instance=this;
		}
    }

    // Update is called once per frame
	public void ChangeScore(int coinValue)
	{
		score+= coinValue;
		text.text=score.ToString();
		
		if (score==10)
		{
			panelWin.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
			panelWin.SetActive(false);
		}
	}
	
	//public void ScoreWin()
	//{
	//	if (score==1)
	//	{
	//		Winning();
	//	}
	//}
	
	//public void Winning()
	//{
	//		panelWin.SetActive(true);
	//		Time.timeScale = 0;
	//}
}

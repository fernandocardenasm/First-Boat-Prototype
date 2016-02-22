﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinText : MonoBehaviour {

	public Text winText;
	public float fadeSpeed = 1f;
	public bool endscene;
	public GameObject Canvas;

	private bool finish;

	private int firstlevel = 1;
	private int _endscene = 2;
    public AudioSource gameWin;

    void Awake () 

	{
		winText = Canvas.GetComponentInChildren<Text> ();
		winText.color = Color.clear;

    }

	void Update () 

	{
		//print (finish);
		ColorChange();
	}

	void OnTriggerEnter (Collider col)
	{
		if (!endscene) 
		{
			print ("player hit trigger cube");
			finish = true;
			StartCoroutine (WaitAndRestart (3F));
		}

		if (endscene) 
		{
            
            SceneManager.LoadScene(_endscene);	
		}

	}

	void ColorChange () 
	{
		if (finish)
		{
			winText.color = Color.Lerp (winText.color, Color.red, fadeSpeed * Time.deltaTime);
		}
	}

	IEnumerator WaitAndRestart(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		print ("waiting...");
		SceneManager.LoadScene(firstlevel);
	}
}

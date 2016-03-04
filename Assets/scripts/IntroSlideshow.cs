using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSlideshow : MonoBehaviour {
	public Canvas canvas;
	public RawImage ImageOnPanel;
	public RawImage textbox;
	public Text text;
	public Texture2D[] introPics = new Texture2D [4]; 
	public string[] introTexts = new string[4];

	private RawImage img;
	private int picNumber = 0;
	private int textNumber = 0;
	private float currentTime = 0;
	// Use this for initialization
	void Start () {

		img = (RawImage)ImageOnPanel.GetComponent<RawImage> ();
		img.texture = introPics[picNumber];
		text.text = introTexts [textNumber];
		img.CrossFadeAlpha (0.0F, 0.01F, false);
		text.CrossFadeAlpha (0.0F, 0.01F, false);
		textbox.CrossFadeAlpha(0.0F,0.01F, false);
		StartCoroutine (WaittoLoad (0.2F));

	}

	// Update is called once per frame
	void Update () {

		currentTime += Time.deltaTime;
		if (currentTime >= 12.0 && picNumber < 4) {
			picNumber++;
			textNumber++;
			ChangeSlide (picNumber);
			currentTime = 0;
		}

		if (picNumber > 3) {
			SceneManager.LoadScene (1);
		}



	}

	void ChangeSlide(int picNumber)
	{
		img.CrossFadeAlpha (0F, 1.5F, false);
		text.CrossFadeAlpha (0.0F, 1.5F, false);
		textbox.CrossFadeAlpha(0.0F, 1.5F, false);
		StartCoroutine(WaittoLoad (2F));



	}

	void LoadImage(int picNumber) {
		img.texture = introPics[picNumber];
		//text.text = introTexts [textNumber];
		img.CrossFadeAlpha (1.0F, 1F, false);
		text.CrossFadeAlpha (1.0F, 1F, false);
		textbox.CrossFadeAlpha (1.0F, 1F, false);
		StartCoroutine (AnimateText( introTexts [textNumber]));
	}

	IEnumerator WaittoLoad(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		LoadImage (picNumber);

	}

	IEnumerator AnimateText(string completeStr)
	{
		int i = 0;
		string str = "";
		while (i< completeStr.Length) {
			str += completeStr[i++];
			yield return new WaitForSeconds(0.1F);
			text.text = str;
		}
	}


}

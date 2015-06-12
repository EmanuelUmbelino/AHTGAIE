using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static int donePeople;
	public static float acidentsTotal;
	public int people;
	public int maxAcidents;
	public Text childText;
	public Text timeText;
	public Text acidentText;
	int seg;
	int min;
	void Start () {
		childText.text = donePeople + "/" + people;
		acidentText.text = Mathf.Floor(acidentsTotal) + "/" + maxAcidents;
		donePeople = 0;
		StartCoroutine(Timer());
	}
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(1f);
		seg ++;
		if (seg > 59) 
		{
			seg = 0;
			min ++;
		}
		if(min < 10)timeText.text = "0" + min + ":";
		else timeText.text = min + ":";
		if(seg < 10)timeText.text += "0" + seg;
		else timeText.text += seg;
		StartCoroutine(Timer());
	}
	void Update () {
		childText.text = donePeople + "/" + people;
		acidentText.text = acidentsTotal + "/" + maxAcidents;
        if (donePeople.Equals(people))
            print("YOU WIN");
	}



}

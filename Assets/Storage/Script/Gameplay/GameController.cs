using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public int people;
    public static int donePeople;
	public Text time;
	int seg;
	int min;
	void Start () {
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
		if(min < 10)time.text = "0" + min + ":";
		else time.text = min + ":";
		if(seg < 10)time.text += "0" + seg;
		else time.text += seg;
		StartCoroutine(Timer());
	}
	void Update () {
        if (donePeople.Equals(people))
            print("YOU WIN");
	}



}

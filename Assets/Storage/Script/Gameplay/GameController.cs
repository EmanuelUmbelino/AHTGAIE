using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public int people;
    public static int donePeople;
	void Start () {
        donePeople = 0;
	}
	
	void Update () {
        if (donePeople.Equals(people))
            print("YOU WIN");
	}
}

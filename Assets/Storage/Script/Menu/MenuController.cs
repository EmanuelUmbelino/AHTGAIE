using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController: MonoBehaviour {

	private GameObject Play;
	private GameObject Options;
	private GameObject Credits;
	private GameObject Instructions;
	private GameObject Back;

	void Start () 
    {
        if (Application.loadedLevel.Equals(0))
        {
            Play = GameObject.Find("TextPlay");
            Options = GameObject.Find("TextOptions");
            Credits = GameObject.Find("TextCredits");
            Instructions = GameObject.Find("TextInstructions");
        }

		if(Application.loadedLevel != 0 && Application.loadedLevel != 1) Back = GameObject.Find("TextBack");
	}

	void FixedUpdate () {
		if(Application.loadedLevel.Equals(0)){
			if (!Play.activeSelf)
				Application.LoadLevel("Game");
			else if(!Options.activeSelf)
				Application.LoadLevel("Options");
			else if(!Credits.activeSelf)
				Application.LoadLevel("Credits");
			else if(!Instructions.activeSelf)
				Application.LoadLevel("Instructions");
		}
		if(Application.loadedLevel != 0 && Application.loadedLevel != 1 && !Back.activeSelf)Application.LoadLevel("Menu");
	}
}

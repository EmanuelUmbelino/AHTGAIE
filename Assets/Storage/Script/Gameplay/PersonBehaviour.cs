using UnityEngine;
using System.Collections;

public class PersonBehaviour : MonoBehaviour {

    string moveState;
    public Animator animationPlayer;
    void Start()
    {
        moveState = "Go";
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Finish"))
        {
            GameController.donePeople += 1;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Light"))
        {
            if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(255, 0, 0)))
                moveState = "Go";

            else
                moveState = "DontGo";
        }
        if (col.tag.Equals("Up"))
            transform.eulerAngles = new Vector3(0,0,0);
        else if (col.tag.Equals("Down"))
            transform.eulerAngles = new Vector3(0, 0, 180);
        else if (col.tag.Equals("Left"))
            transform.eulerAngles = new Vector3(0, 0, 90);
        else if (col.tag.Equals("Right"))
            transform.eulerAngles = new Vector3(0, 0, 270);
        else if(col.tag.Equals("Player"))
                moveState = "DontGo";
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
            moveState = "Go";
    }
    void Move()
    {
        if (moveState.Equals("Go"))
        {
            transform.Translate(Vector3.up * 100 * Time.deltaTime);
            animationPlayer.SetBool("Moving", true);
        }
        else
        {
            transform.Translate(new Vector3(0, 0, 0));
            animationPlayer.SetBool("Moving", false);
        }

    }
	void Update () {
        Move();
	}
}

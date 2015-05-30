using UnityEngine;
using System.Collections;

public class PersonBehaviour : MonoBehaviour {

    string moveState;
    void Start()
    {
        moveState = "Go";
	
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
    }
    void Move()
    {
        if (moveState.Equals("Go"))
        {
            transform.Translate(Vector3.up * 2);
            GetComponent<Animator>().SetBool("Moving", true);
        }
        else
        {
            transform.Translate(new Vector3(0, 0, 0));
            GetComponent<Animator>().SetBool("Moving", false);
        }

    }
	void Update () {
        Move();
	}
}

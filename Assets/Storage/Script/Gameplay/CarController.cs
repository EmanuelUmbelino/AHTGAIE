using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

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
                moveState = "DontGo";
            else if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(0, 255, 0)))
                moveState = "Go";
            else if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(255, 255, 0)))
            {
                moveState = "RUN";
                StartCoroutine(Slow());
            }
        } 
        if (col.tag.Equals("Car"))
        {
            moveState = "DontGo";
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag.Equals("Car"))
        {
            moveState = "Go";
        }
    }
    IEnumerator Slow()
    {
        yield return new WaitForSeconds(1);
        moveState = "Go";
    }
    void Move()
    {
        if(moveState.Equals("Go"))
            transform.Translate(Vector3.right * 4);
        else if (moveState.Equals("DontGo"))
            transform.Translate(new Vector3(0,0,0));
        else
            transform.Translate(Vector3.right * 10);

    }

	void FixedUpdate () 
    {
        Move();
	}
}

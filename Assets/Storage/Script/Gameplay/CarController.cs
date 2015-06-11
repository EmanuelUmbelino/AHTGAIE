using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    string moveState;
    public SpriteRenderer sprite;

    void Start()
    {
        sprite.color = new Color(0, 0, 0);
        sprite.color = new Color(Random.Range(0, 255) / 100, Random.Range(0, 255) / 100, Random.Range(0, 255) / 100);
        moveState = "Go";
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Car"))
        {
            moveState = "DontGo";
        }
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

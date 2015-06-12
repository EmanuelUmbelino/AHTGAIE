using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	string moveState;		
	int rotation;
	int goYellow;
	private int stressLvl;
	private string stateDirection;
	private string nextDirection;
    public SpriteRenderer sprite;

    void Start()
	{
		stressLvl = Random.Range (0, 31);
		nextDirection = "";
        sprite.color = new Color(0, 0, 0);
        sprite.color = new Color(Random.Range(0, 255) / 100, Random.Range(0, 255) / 100, Random.Range(0, 255) / 100);
		moveState = "Go";
		rotation = int.Parse (Mathf.Floor(transform.localEulerAngles.z).ToString());
		switch (rotation) 
		{
		case 0:
			stateDirection = "Right";
			break;
		case 90:
			stateDirection = "Up";
			break;
		case 180:
			stateDirection = "Left";
			break;
		case 270:
			stateDirection = "Down";
			break;
			
		}
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Car"))
        {
            moveState = "DontGo";
        }
		if (col.tag.Equals("CarChanger") && nextDirection.Equals(""))
		{
			nextDirection = col.gameObject.GetComponent<CarChangerController>().directions[Random.Range(0,col.gameObject.GetComponent<CarChangerController>().directions.Length)];
			StartCoroutine(ToNull());
		}
		if (col.tag.Equals ("Light")) 
		{
			goYellow = Random.Range(0, stressLvl);
		}

    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag.Equals("Light"))
        {
            if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(255, 0, 0)))
			{
				moveState = "DontGo";
			}

            else if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(0, 255, 0)))
			{
                moveState = "Go";
			}

            else if (col.GetComponent<SpriteRenderer>().color.Equals(new Color(255, 255, 0)))
            {
				if(goYellow.Equals(0))
				{
		            moveState = "RUN";
		            StartCoroutine(Slow());
				}
				else 
				{
					moveState = "DontGo";
				}
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
	IEnumerator ToNull()
	{
		yield return new WaitForSeconds(0.5f);
		nextDirection = "";
	}
    IEnumerator Slow()
    {
        yield return new WaitForSeconds(0.3f);
        moveState = "Go";
    }
    void Move()
    {
        if(moveState.Equals("Go"))
            transform.Translate(Vector3.right * 4);
        else if (moveState.Equals("DontGo"))
            transform.Translate(new Vector3(0,0,0));
        else
            transform.Translate(Vector3.right * 7);

    }
	void StateRotation()
	{
		rotation = int.Parse (Mathf.Floor(transform.localEulerAngles.z).ToString());
		switch (rotation) 
		{
		case 0:
			stateDirection = "Right";
			break;
		case 90:
			stateDirection = "Up";
			break;
		case 180:
			stateDirection = "Left";
			break;
		case 270:
			stateDirection = "Down";
			break;
		}
		if (nextDirection != null && stateDirection != nextDirection)
		{
			if(nextDirection.Equals("Up"))
			{
				if(stateDirection.Equals("Right") && rotation < 90)
				{
					transform.Rotate(new Vector3(0,0,3.7f));
					if(transform.localEulerAngles.z >= 90)
						transform.eulerAngles = new Vector3(0,0,90);
				}
			}
			else if(nextDirection.Equals("Right"))
			{
				if(stateDirection.Equals("Up") && rotation > 0)
				{
					transform.Rotate(new Vector3(0,0,-4));
					if(transform.localEulerAngles.z > 180)
						transform.eulerAngles = new Vector3(0,0,0);
				}
			}
			
		}

	}
	void FixedUpdate () 
    {
		StateRotation();
        Move();
	}
}

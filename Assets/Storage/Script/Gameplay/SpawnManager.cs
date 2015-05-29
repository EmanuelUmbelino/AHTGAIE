using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public GameObject car;
    public string direction;

	void Start () 
    {
        StartCoroutine(Spawn());
	}
    IEnumerator Spawn()
    {
        if (direction.Equals("Down"))
            Instantiate(car, transform.position, Quaternion.EulerAngles(0, 0, (3*Mathf.PI)/2));
        else if (direction.Equals("Up"))
            Instantiate(car, transform.position, new Quaternion(0, 0, 270, 270));
        else if (direction.Equals("Left"))
            Instantiate(car, transform.position, new Quaternion(0, 0, 180, 0));
        else if (direction.Equals("Right"))
            Instantiate(car, transform.position, new Quaternion(0, 0, 0, 0));
        yield return new WaitForSeconds(Random.Range(3, 15));
        StartCoroutine(Spawn());
    }
	void Update ()
    {
	
	}
}

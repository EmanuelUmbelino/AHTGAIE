using UnityEngine;
using System.Collections;

public class TrafficLightManager : MonoBehaviour {

    public Light light;
    private string actualLight;
    private SpriteRenderer sprite;

	void Start () 
    {
        actualLight = "Green";
        sprite = GetComponent<SpriteRenderer>();
	}
    void OnMouseDown()
    {
        if (actualLight.Equals("Green"))
            StartCoroutine(ToRedLight());
        else
        {
            actualLight = "Green";
            sprite.color = new Color(0, 255, 0);
            light.color = new Color(0, 1, 0);
        }
    }
    IEnumerator ToRedLight()
    {
        actualLight = "Yellow";
        sprite.color = new Color(255, 255, 0);
        light.color = new Color(1, 1, 0);
        yield return new WaitForSeconds(2);
        actualLight = "Red";
        sprite.color = new Color(255, 0, 0);
        light.color = new Color(1, 0, 0);
    }
	void FixedUpdate () 
    {
	}
}

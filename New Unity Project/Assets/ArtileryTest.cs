using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtileryTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject startpoint;
    public GameObject endpoint;

    public GameObject sprite;
    void Start()
    {
        
    }

    public float shooting_time;
    public float shooting_height;
   
    
    public void ArtileryShoot()
    {
        this.transform.position = startpoint.transform.position;
        StartCoroutine(SmoothLerp(shooting_time));
        StartCoroutine(VerticalMove(shooting_time, shooting_height));
    }

    
    private IEnumerator SmoothLerp(float time)
    {
        Vector3 startingPos = startpoint.transform.position;
        Vector3 finalPos = endpoint.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
        
    private IEnumerator VerticalMove(float time, float height)
    {
        float elapsedTime = 0;
        float delta_y = height * Mathf.Pow((elapsedTime - time / 2), 2);
        Debug.Log(delta_y);
        while (elapsedTime < time)
        {
            //sprite.transform.localPosition = new Vector3(0, -1 * Mathf.Pow((elapsedTime - time / 2), 2) + Mathf.Pow((time / 2), 2) ,0);
            sprite.transform.localPosition = new Vector3(0, (-1 * height * Mathf.Pow((elapsedTime - time/2), 2)) + delta_y ,0);
            Debug.Log(sprite.transform.localPosition.y);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockpoints : MonoBehaviour {

    public float BounceHeight = 0.5f;
    public float BounceSpeed = 4.0f;

    private Vector2 OriginalPosition;
    private bool CanBounce = true;

	// Use this for initialization
	void Start ()
    {
        OriginalPosition = transform.localPosition;
	}


    public void QuestionBlockBounce()
    { 
        if(CanBounce)
        {
            CanBounce = false;

            StartCoroutine(Bounce());

        }
    }

    void Update(){
    }

    private IEnumerator Bounce()
    {
        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + BounceSpeed * Time.deltaTime);

            if(transform.localPosition.y >= OriginalPosition.y + BounceHeight)
            
                break;
                yield return null;
            
        }

        while(true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - BounceSpeed * Time.deltaTime);
            
            if(transform.localPosition.y >= OriginalPosition.y)
            {
                transform.localPosition = OriginalPosition;
                break;

            }
            yield return null;
        }
    }
}

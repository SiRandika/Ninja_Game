using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // Start is called before the first frame update
	public float speed = .5f;
    private Rigidbody2D rigidbody2D;
	
	void Start()
	{
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2 (transform.localScale.x,0) * speed;
    }
}

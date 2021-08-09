using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public bool isStolknovenie = false;
    public float timer_down = 12;
    public float speed = 0.1f;

    void Start() { }

    void Update()
    {
        if (timer_down > 0) { timer_down -= speed; } else 
        { 
            timer_down = 12.0f;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.4f);
        }
    }

    public void Left() 
    {
        if (transform.position.x - (GetComponent<BoxCollider2D>().size.x / 2) > -1.8f) { transform.position = new Vector2(transform.position.x - 0.4f, transform.position.y); }
    }

    public void Right()
    {
        if (transform.position.x + (GetComponent<BoxCollider2D>().size.x / 2) < 1.8f) { transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y); }
    }

    private void OnTriggerEnter2D(Collider2D Cool) { if (Cool.gameObject.tag == "Block") { isStolknovenie = true; } }

    public void Down() { speed = 1.5f; }
}

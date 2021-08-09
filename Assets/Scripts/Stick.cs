using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public bool isStolknovenie = false;
    public float timer_down = 12;
    public int angle = 0;
    public float speed = 0.1f;
    
    void Start() { }

    void Update()
    {
        Correct();
        if (timer_down > 0) { timer_down -= speed; }
        else
        {
            timer_down = 12.0f;
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.4f);
        }
    }
    void Correct() 
    { 
        if (angle == 0 && (transform.position.x - (GetComponent<BoxCollider2D>().size.x / 2) < -2.1f))
            { transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y); }
        if (angle == 90 && (transform.position.x - (GetComponent<BoxCollider2D>().size.y / 2) < -2.1f))
            { transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y); }
        if (angle == 0 && (transform.position.x + (GetComponent<BoxCollider2D>().size.x / 2) > 2.1f))
        { transform.position = new Vector2(transform.position.x - 0.4f, transform.position.y); }
        if(angle == 90 && (transform.position.x + (GetComponent<BoxCollider2D>().size.y / 2) > 2.1f))
            { transform.position = new Vector2(transform.position.x - 0.4f, transform.position.y); }
    }

    public void Left()
    {
        if (angle == 0)
        {
            if (transform.position.x - (GetComponent<BoxCollider2D>().size.x / 2) > -1.8f) { transform.position = new Vector2(transform.position.x - 0.4f, transform.position.y); }
        }
        else
        {
            if (transform.position.x - (GetComponent<BoxCollider2D>().size.y / 2) > -1.8f) { transform.position = new Vector2(transform.position.x - 0.4f, transform.position.y); }
        }
    }

    public void Right()
    {
        if (angle == 0)
        {
            if (transform.position.x + (GetComponent<BoxCollider2D>().size.x / 2) < 1.8f) { transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y); }
        }
        else
        {
            if (transform.position.x + (GetComponent<BoxCollider2D>().size.y / 2) < 1.8f) { transform.position = new Vector2(transform.position.x + 0.4f, transform.position.y); }
        }
    }

    private void OnTriggerEnter2D(Collider2D Cool) { if (Cool.gameObject.tag == "Block") { isStolknovenie = true; } }

    public void Rotate() 
    {
        if (angle == 0)
        {
            angle = 90;
            transform.eulerAngles = new Vector3(0, 0, angle);
            if (transform.position.x < 0) { transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f); }
            else { transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y - 0.2f); }
        }
        else
        {
            angle = 0;
            transform.eulerAngles = new Vector3(0, 0, angle);
            if (transform.position.x < 0) { transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f); }
            else { transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y - 0.2f); }
        }
    }

    public void Down() { speed = 1.5f; }
}

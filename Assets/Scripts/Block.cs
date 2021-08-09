using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject Ob;
    public float scale = 1.0f;
    public bool isDeath = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (isDeath) 
        {
            if (scale <= 0)
            {
                scale = 0;
                Ob.gameObject.SetActive(false);
                isDeath = false;
            }
            scale -= 0.015f;
            transform.localScale = new Vector3(scale, scale, 1f);
            
        }
    }
}

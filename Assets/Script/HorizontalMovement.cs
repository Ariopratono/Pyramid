using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    static float t = 0.0f;
    public float distance;
    public float speed;

    [Header("Flip Postition")]
    public float posXL;
    public float posXR;

    private float originalPos;
    private SpriteRenderer sprite;
    void Start()
    {
        originalPos = transform.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }

    void SpriteFlip()
    {
        if (transform.localPosition.x < posXL)
        {
            sprite.flipX = true;
           
        } 
        else if (transform.localPosition.x > posXR)
        {
            sprite.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ms = Mathf.Sin(t)*distance; 
        var x = originalPos + ms; 
        transform.position = new Vector3(x,transform.position.y,transform.position.z);
        t+=speed * Time.deltaTime;
        SpriteFlip();
    }
}

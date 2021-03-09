using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Move : MonoBehaviour
{
    public Sprite[] imgs;
    public float speed;
    private SpriteRenderer currentSprite;
    private int x, y;
    private Random rand;
    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        currentSprite = GetComponent<SpriteRenderer>();
        rand = new Random();
        x = rand.Next(0, 2) > 0 ? 1 : -1;
        y = rand.Next(0, 2) > 0 ? 1 : -1;
        transform.position = new Vector2(getPos(-7.5, 7.5), getPos(-4.3, 4.3));
    }

    float getPos(double min, double max)
    {
        return (float)(min + (rand.NextDouble() * (max - min)));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x / speed, y / speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        index = rand.Next(0, imgs.Length);
        currentSprite.sprite = imgs[index];
        
        if (other.CompareTag("TB Boarder"))
            y *= -1;
        else
            x *= -1;
    }
}

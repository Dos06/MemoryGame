using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private GameObject CardBack;
    public void OnMouseDown()
    {
        if (CardBack.activeSelf)
        {
            CardBack.SetActive(false);
            
        }
    }

    private int _id;

    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
}

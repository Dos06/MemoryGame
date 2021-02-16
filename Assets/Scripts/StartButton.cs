using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;

    public void OnMouseOver()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
    }

    public void OnMouseExit()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.4f, 0.4f, 1.0f);
    }

    public void OnMouseUp()
    {
        transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}

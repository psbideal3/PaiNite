using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_FadeOut : MonoBehaviour
{
    private SpriteRenderer Sr;
    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        StartCoroutine("FadeStart");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FadeStart()
    {
        for (int i = 20; i >= 0; i--)
        {
            float f = i / 20.0f;
            Color c = Sr.material.color;
            c.a = f;
            Sr.material.color = c;
            yield return new WaitForSeconds(0.04f);
        }
    }
}

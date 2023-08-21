using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Move : MonoBehaviour
{
    [SerializeField] Transform toPos;
    private SpriteRenderer Sr;
    [SerializeField] GameObject[] Fade;
    void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        Tweener tweener = transform.DOMove(toPos.position, 2f);
        tweener.OnUpdate(delegate () {
            if (Vector3.Distance(transform.position, toPos.position) > 0.1f)
            {
                tweener.ChangeEndValue(toPos.position, true);
            }
        });

        Invoke("FadeOutStart", 2f);
        Invoke("DestroyOn", 3f);
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

    void FadeOutStart()
    {
        //StartCoroutine("FadeStart");
        for (int i = 0; i < Fade.Length; i++)
        {
            Fade[i].GetComponent<Item_FadeOut>().enabled = true;
        }
    }

    void DestroyOn()
    {
        Destroy(gameObject);
    }
}

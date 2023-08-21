using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Bullet : MonoBehaviour
{
    public GameObject Effect;
    public float speed;

    [SerializeField] float EffectX, EffectY;

    [SerializeField] int count = 1;

    void Start()
    {
        Invoke("DestroyBullet", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            transform.position += transform.right * speed * Time.deltaTime; // 좌우변경시 변경
        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void EffectOn()
    {
        Instantiate(Effect, transform.position + new Vector3(EffectX, EffectY, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D triggered)
    {
        if (count == 1 && triggered.gameObject.tag == "R")
        {
            count = 0;
            Destroy(gameObject);
            EffectOn();
        }
    }
}

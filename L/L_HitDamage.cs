using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_HitDamage : MonoBehaviour
{
    public List<GameObject> Collisions = new List<GameObject>(new GameObject[1]);
    public R_OnDamage R_OnDamage;
    [SerializeField] int count = 1;
    [SerializeField] int Damage;

    [SerializeField] int DamageMode;

    [SerializeField] bool KnuckBack;
    [SerializeField] float x, y;
    public Rigidbody2D rb;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (count == 1 && collision.name != "R_Base")
        {
            Collisions[0] = collision.gameObject;
            count = 0;
            StartCoroutine(DamageOn2());
        }
    }


    IEnumerator DamageOn2()
    {
        R_OnDamage = Collisions[0].GetComponent<R_OnDamage>();
        R_OnDamage.currentHP -= Damage;
        if (DamageMode == 1)
        {
            R_OnDamage.TextAppear(Damage);
        }
        if (DamageMode == 2)
        {
            R_OnDamage.TextAppearCrit(Damage);
        }
        if (DamageMode == 3)
        {
            R_OnDamage.TextAppearMercenary(Damage);
        }
        if (DamageMode == 4)
        {
            R_OnDamage.TextAppearUlt(Damage);
        }

        if (KnuckBack)
        {
            rb = Collisions[0].GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(x, y), ForceMode2D.Force);
        }

        Collisions[0].GetComponent<R_OnDamage>().FlickerCount = 1;      //피격 대상만 피격효과 나게 하기 위해 설정

        yield return new WaitForSeconds(0.05f);
        count = 1;
    }
}

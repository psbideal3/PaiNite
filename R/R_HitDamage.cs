using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_HitDamage : MonoBehaviour
{
    public List<GameObject> Collisions = new List<GameObject>(new GameObject[1]);
    public L_OnDamage L_OnDamage;
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

        if (count == 1 && collision.name != "L_Base")
        {
            Collisions[0] = collision.gameObject;
            count = 0;
            StartCoroutine(DamageOn2());
        }
    }


    IEnumerator DamageOn2()
    {
        L_OnDamage = Collisions[0].GetComponent<L_OnDamage>();
        L_OnDamage.currentHP -= Damage;
        if (DamageMode == 1)
        {
            L_OnDamage.TextAppear(Damage);
        }
        if (DamageMode == 2)
        {
            L_OnDamage.TextAppearCrit(Damage);
        }
        if (DamageMode == 3)
        {
            L_OnDamage.TextAppearMercenary(Damage);
        }
        if (DamageMode == 4)
        {
            L_OnDamage.TextAppearUlt(Damage);
        }

        if (KnuckBack)
        {
            rb = Collisions[0].GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(x, y), ForceMode2D.Force);
        }


        Collisions[0].GetComponent<L_OnDamage>().FlickerCount = 1;      //피격 대상만 피격효과 나게 하기 위해 설정 + 기지는 Flick 안되니까 전체 Flick 켜야함. 다음 프로젝트에서 수정해라


        yield return new WaitForSeconds(0.05f);
        count = 1;
    }
}

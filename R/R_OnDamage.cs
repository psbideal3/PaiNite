using DamageNumbersPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_OnDamage : MonoBehaviour
{
    [SerializeField] int hp = 0;
    public int currentHP = 0;
    [SerializeField] Vector3 TextPos;
    [SerializeField] float x, y;

    private Rigidbody2D rb;

    int damage;

    public DamageNumber DamageText;
    public DamageNumber DamageCritText;
    public DamageNumber DamageMercenaryText;
    public DamageNumber DamageUltText;

    [SerializeField] GameObject Money;
    [SerializeField] GameObject Money_2;
    [SerializeField] GameObject Money_3;
    [SerializeField] GameObject Money_4;
    [SerializeField] GameObject Money_5;
    [SerializeField] GameObject BombMoney;

    [SerializeField] GameObject Death;
    int count = 1;

    [SerializeField] GameObject[] FlickerList;

    public int FlickerCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "L_Weapon")
        {
            if (collision.name == "L_Turret(Clone)")
            {
                damage = 3;
                currentHP -= damage;
                TextAppear(damage);
                DamageFlick();
            }
            if (collision.name == "L_Turret_2(Clone)")
            {
                damage = 5;
                currentHP -= damage;
                TextAppear(damage);
                DamageFlick();
            }


            if (collision.name == "V_Tier01_Collider01")
            {
                damage = 3;
                if (FlickerCount == 1)
                {
                    DamageFlick();
                    FlickerCount -= 1;
                }
            }


            if (collision.name == "V_Tier02_Bullet(Clone)")
            {
                damage = 3;
                if (FlickerCount == 1)
                {
                    DamageFlick();
                    FlickerCount -= 1;
                }
            }


            if (collision.name == "V_Tier03_Collider01")
            {
                damage = 5;
                if (FlickerCount == 1)
                {
                    DamageFlick();
                    FlickerCount -= 1;
                }
            }
            if (collision.name == "V_Tier03_Collider02")
            {
                damage = 15;
                currentHP -= damage;
                rb.AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
                TextAppearCrit(damage);
                DamageFlick();
            }


            if (collision.name == "Void04_Attack(Clone)")
            {
                damage = 7;
                if (FlickerCount == 1)
                {
                    DamageFlick();
                    FlickerCount -= 1;
                }
            }


            if (collision.name == "Void05_Collider_01")
            {
                damage = 20;
                currentHP -= damage;
                TextAppear(damage);
                DamageFlick();
            }
            if (collision.name == "Void05_Collider_02")
            {
                damage = 40;
                currentHP -= damage;
                rb.AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
                TextAppearCrit(damage);
                DamageFlick();
            }
            if (collision.name == "Void05_CritCollider_01")
            {
                damage = 10;
                currentHP -= damage;
                TextAppearCrit(damage);
                DamageFlick();
            }
            if (collision.name == "Void05_CritCollider_02")
            {
                damage = 90;
                currentHP -= damage;
                rb.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
                TextAppearCrit(damage);
                DamageFlick();
            }

            if (collision.name == "V_Mer01_Collider_01")
            {
                damage = 16;
                if (FlickerCount == 1)
                {
                    DamageFlick();
                    FlickerCount -= 1;
                }
            }
            if (collision.name == "V_Mer01_Collider_02")
            {
                damage = 2;
                if (FlickerCount == 1)
                {
                    DamageFlick();
                    FlickerCount -= 1;
                }
            }
            if (collision.name == "V_Mer01_Collider_03_1")
            {
                damage = 10;
                currentHP -= damage;
                rb.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
                TextAppearUlt(damage);
                DamageFlick();
            }
            if (collision.name == "V_Mer01_Collider_03_2")
            {
                damage = 90;
                currentHP -= damage;
                rb.AddForce(new Vector2(2.5f, 0), ForceMode2D.Impulse);
                TextAppearUlt(damage);
                DamageFlick();
            }


            if (collision.name == "V_Mer02_Bullet(Clone)")
            {
                damage = 30;
                currentHP -= damage;
                TextAppearMercenary(damage);
                DamageFlick();
            }
            if (collision.name == "V_Mer02_Collider_02")
            {
                damage = 50;
                currentHP -= damage;
                rb.AddForce(new Vector2(2.5f, 0), ForceMode2D.Impulse);
                TextAppearMercenary(damage);
                DamageFlick();
            }
            if (collision.name == "V_Mer02_Collider_03")
            {
                damage = 10;
                currentHP -= damage;
                TextAppearMercenary(damage);
                DamageFlick();
            }
            if (collision.name == "Spike")
            {
                damage = 50;
                currentHP -= damage;
                TextAppearUlt(damage);
                DamageFlick();
            }

            //DamageFlick();
        }

        if (collision.name == "C_Bombard")
        {
            damage = 1000;
            currentHP -= damage;
            TextAppearCrit(damage);
        }
        if (collision.name == "V_Bombard")
        {
            damage = 1000;
            currentHP -= damage;
            TextAppearCrit(damage);
        }

        
        Invoke("OnDamage", 0.03f);
    }

    public void TextAppear(int damage)
    {
        DamageNumber damageNumber = DamageText.Spawn(transform.position + TextPos, damage);
    }
    public void TextAppearCrit(int damage)
    {
        DamageNumber damageNumber = DamageCritText.Spawn(transform.position + TextPos, damage);
    }
    public void TextAppearMercenary(int damage)
    {
        DamageNumber damageNumber = DamageMercenaryText.Spawn(transform.position + TextPos, damage);
    }
    public void TextAppearUlt(int damage)
    {
        DamageNumber damageNumber = DamageUltText.Spawn(transform.position + TextPos, damage);
    }

    
    void DamageFlick()
    {
        for (int i = 0; i < FlickerList.Length; i++)
        {
            if (FlickerList[i].GetComponent<Flick>().enabled == false)
            {
                FlickerList[i].GetComponent<Flick>().enabled = true;
            }
            else
            {
                FlickerList[i].GetComponent<Flick>().enabled = false;
                FlickerList[i].GetComponent<Flick>().enabled = true;
            }
        }
    }


    void OnDamage()
    {
        if (currentHP < 1 && count == 1)
        {
            count -= 1;
            if (damage <= 5)
            {
                if (gameObject.name == "C_Tier01(Clone)")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Instantiate(Money, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier02(Clone)")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(Money, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier03(Clone)")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Instantiate(Money, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier04(Clone)")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Instantiate(Money, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier05(Clone)")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Instantiate(Money, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer01(Clone)")
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Instantiate(Money, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer02(Clone)")
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Instantiate(Money, transform.position, transform.rotation);
                    }
                }
            }


            else if (damage <= 8)
            {
                if (gameObject.name == "C_Tier01(Clone)")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Instantiate(Money_2, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier02(Clone)")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(Money_2, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier03(Clone)")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Instantiate(Money_2, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier04(Clone)")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Instantiate(Money_2, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier05(Clone)")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Instantiate(Money_2, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer01(Clone)")
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Instantiate(Money_2, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer02(Clone)")
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Instantiate(Money_2, transform.position, transform.rotation);
                    }
                }
            }


            else if (damage <= 20)
            {
                if (gameObject.name == "C_Tier01(Clone)")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Instantiate(Money_3, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier02(Clone)")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(Money_3, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier03(Clone)")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Instantiate(Money_3, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier04(Clone)")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Instantiate(Money_3, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier05(Clone)")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Instantiate(Money_3, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer01(Clone)")
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Instantiate(Money_3, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer02(Clone)")
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Instantiate(Money_3, transform.position, transform.rotation);
                    }
                }
            }


            else if (damage <= 40)
            {
                if (gameObject.name == "C_Tier01(Clone)")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Instantiate(Money_4, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier02(Clone)")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(Money_4, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier03(Clone)")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Instantiate(Money_4, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier04(Clone)")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Instantiate(Money_4, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier05(Clone)")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Instantiate(Money_4, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer01(Clone)")
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Instantiate(Money_4, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer02(Clone)")
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Instantiate(Money_4, transform.position, transform.rotation);
                    }
                }
            }

            else if (damage <= 300)
            {
                if (gameObject.name == "C_Tier01(Clone)")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Instantiate(Money_5, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier02(Clone)")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(Money_5, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier03(Clone)")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Instantiate(Money_5, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier04(Clone)")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Instantiate(Money_5, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier05(Clone)")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Instantiate(Money_5, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer01(Clone)")
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Instantiate(Money_5, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer02(Clone)")
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Instantiate(Money_5, transform.position, transform.rotation);
                    }
                }
            }

            else
            {
                if (gameObject.name == "C_Tier01(Clone)")
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Instantiate(BombMoney, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier02(Clone)")
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Instantiate(BombMoney, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier03(Clone)")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Instantiate(BombMoney, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier04(Clone)")
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Instantiate(BombMoney, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Tier05(Clone)")
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Instantiate(BombMoney, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer01(Clone)")
                {
                    for (int i = 0; i < 30; i++)
                    {
                        Instantiate(BombMoney, transform.position, transform.rotation);
                    }
                }
                else if (gameObject.name == "C_Mer02(Clone)")
                {
                    for (int i = 0; i < 50; i++)
                    {
                        Instantiate(BombMoney, transform.position, transform.rotation);
                    }
                }
            }

            Instantiate(Death, transform.position + new Vector3(x, y, 0), transform.rotation);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TextMeshPro LScoreText;
    public TextMeshPro LPriceText;
    public TextMeshPro RScoreText;
    public TextMeshPro RPriceText;

    public GameObject CameraMove;

    [SerializeField] int L_ShopProcedure;
    [SerializeField] int L_Point;
    [SerializeField] int R_ShopProcedure;
    [SerializeField] int R_Point;

    [SerializeField] GameObject L_Key_Tier02;
    [SerializeField] GameObject L_Block_02;

    [SerializeField] GameObject L_Tier_01;
    [SerializeField] GameObject L_Tier_02;
    [SerializeField] GameObject L_Tier01N02_Item;

    [SerializeField] GameObject L_Key_Tier03;
    [SerializeField] GameObject L_Block_03;

    [SerializeField] GameObject L_Key_Tier04;
    [SerializeField] GameObject L_Block_04;

    [SerializeField] GameObject L_Key_Tier05;
    [SerializeField] GameObject L_Block_05;

    [SerializeField] GameObject L_BallAdd;
    [SerializeField] GameObject L_Ball;

    [SerializeField] GameObject L_Mer_01;
    [SerializeField] GameObject L_Mer_01_Unit;

    [SerializeField] GameObject L_Mer_02;
    [SerializeField] GameObject L_Mer_02_Unit;

    /*[SerializeField] GameObject L_Mer_03;
    [SerializeField] GameObject L_Mer_03_Unit;*/


    [SerializeField] GameObject L_Tier_05Item01;
    [SerializeField] GameObject L_Tier_05Item02;
    [SerializeField] GameObject L_Tier_05Item03;
    [SerializeField] GameObject L_Tier_05Item04;
    [SerializeField] GameObject L_Tier_05;


    /*[SerializeField] GameObject L_Tier_06Item01;
    [SerializeField] GameObject L_Tier_06Item02;
    [SerializeField] GameObject L_Tier_06Item03;
    [SerializeField] GameObject L_Tier_06Item04;
    [SerializeField] GameObject L_Tier_06Item05;
    [SerializeField] GameObject L_Tier_06Item06;
    [SerializeField] GameObject L_Tier_06;*/



    [SerializeField] GameObject R_Key_Tier02;
    [SerializeField] GameObject R_Block_02;

    [SerializeField] GameObject R_Tier_01;
    [SerializeField] GameObject R_Tier_02;
    [SerializeField] GameObject R_Tier01N02_Item;

    [SerializeField] GameObject R_Key_Tier03;
    [SerializeField] GameObject R_Block_03;

    [SerializeField] GameObject R_Key_Tier04;
    [SerializeField] GameObject R_Block_04;

    [SerializeField] GameObject R_Key_Tier05;
    [SerializeField] GameObject R_Block_05;

    [SerializeField] GameObject R_BallAdd;
    [SerializeField] GameObject R_Ball;

    [SerializeField] GameObject R_Mer_01;
    [SerializeField] GameObject R_Mer_01_Unit;

    [SerializeField] GameObject R_Mer_02;
    [SerializeField] GameObject R_Mer_02_Unit;

    /*[SerializeField] GameObject R_Mer_03;
    [SerializeField] GameObject R_Mer_03_Unit;*/

    [SerializeField] GameObject R_Tier_05;
    [SerializeField] GameObject R_Tier_05Item01;
    [SerializeField] GameObject R_Tier_05Item02;
    [SerializeField] GameObject R_Tier_05Item03;
    [SerializeField] GameObject R_Tier_05Item04;


    /*[SerializeField] GameObject R_Tier_06Item01;
    [SerializeField] GameObject R_Tier_06Item02;
    [SerializeField] GameObject R_Tier_06Item03;
    [SerializeField] GameObject R_Tier_06Item04;
    [SerializeField] GameObject R_Tier_06Item05;
    [SerializeField] GameObject R_Tier_06Item06;
    [SerializeField] GameObject R_Tier_06;*/


    [SerializeField] Transform L_Base_InstPos, R_Base_InstPos, Middle_InstPos;
    public bool L_Base, R_Base;

    void Start()
    {

    }

    void Update()
    {

    }

    void CheckLNum()
    {
        L_Point = int.Parse(LScoreText.text);
        if (L_Point >= 20 && L_ShopProcedure == 0)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 20);
            LPriceText.text = "" + 40;
            L_ShopProcedure = 1;
            L_Key_Tier02.GetComponent<Item_Move>().enabled = true;
            L_Block_02.GetComponent<Block_Off>().enabled = true;
        }

        else if (L_Point >= 40 && L_ShopProcedure == 1)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 40);
            LPriceText.text = "" + 60;
            L_ShopProcedure = 2;
            L_Tier01N02_Item.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstLTier1N2");
        }

        else if (L_Point >= 60 && L_ShopProcedure == 2)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 60);
            LPriceText.text = "" + 50;
            L_ShopProcedure = 3;
            L_Mer_01.GetComponent<Item_Move>().enabled = true;
            Invoke("LMer01_On", 3);
        }

        else if (L_Point >= 50 && L_ShopProcedure == 3)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 50);
            LPriceText.text = "" + 60;
            L_ShopProcedure = 4;
            L_Key_Tier03.GetComponent<Item_Move>().enabled = true;
            L_Block_03.GetComponent<Block_Off>().enabled = true;
        }

        else if (L_Point >= 60 && L_ShopProcedure == 4)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 60);
            LPriceText.text = "" + 80;
            L_ShopProcedure = 5;
            L_BallAdd.GetComponent<Item_Move>().enabled = true;
            Invoke("AddLBall", 3);
        }
        else if (L_Point >= 80 && L_ShopProcedure == 5)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 80);
            LPriceText.text = "" + 150;
            L_ShopProcedure = 6;
            L_Key_Tier04.GetComponent<Item_Move>().enabled = true;
            L_Block_04.GetComponent<Block_Off>().enabled = true;
        }

        else if (L_Point >= 150 && L_ShopProcedure == 6)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 150);
            LPriceText.text = "" + 200;
            L_ShopProcedure = 7;
            L_Key_Tier05.GetComponent<Item_Move>().enabled = true;
            L_Block_05.GetComponent<Block_Off>().enabled = true;
        }

        else if (L_Point >= 200 && L_ShopProcedure == 7)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 200);
            LPriceText.text = "" + 150;
            L_ShopProcedure = 8;
            L_Mer_02.GetComponent<Item_Move>().enabled = true;
            Invoke("LMer02_On", 3);
        }
        else if (L_Point >= 150 && L_ShopProcedure == 8)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 150);
            LPriceText.text = "" + 150;
            L_ShopProcedure = 9;
            L_Tier_05Item01.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstL_05");
        }
        else if (L_Point >= 150 && L_ShopProcedure == 9)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 150);
            LPriceText.text = "" + 150;
            L_ShopProcedure = 10;
            L_Tier_05Item02.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstL_05");
        }
        else if (L_Point >= 150 && L_ShopProcedure == 10)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 150);
            LPriceText.text = "" + 150;
            L_ShopProcedure = 11;
            L_Tier_05Item03.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstL_05");
        }
        else if (L_Point >= 150 && L_ShopProcedure == 11)
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) - 150);
            LPriceText.text = "" + 150;
            L_ShopProcedure = 12;
            L_Tier_05Item04.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstL_05");
        }
    }

    void CheckRNum()
    {
        R_Point = int.Parse(RScoreText.text);
        if (R_Point >= 20 && R_ShopProcedure == 0)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 20);
            RPriceText.text = "" + 40;
            R_ShopProcedure = 1;
            R_Key_Tier02.GetComponent<Item_Move>().enabled = true;
            R_Block_02.GetComponent<Block_Off>().enabled = true;
        }
        else if (R_Point >= 40 && R_ShopProcedure == 1)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 40);
            RPriceText.text = "" + 60;
            R_ShopProcedure = 2;
            R_Tier01N02_Item.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstRTier1N2");
        }

        else if (R_Point >= 60 && R_ShopProcedure == 2)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 60);
            RPriceText.text = "" + 50;
            R_ShopProcedure = 3;
            R_Mer_01.GetComponent<Item_Move>().enabled = true;
            Invoke("RMer01_On", 3);
        }

        else if (R_Point >= 50 && R_ShopProcedure == 3)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 50);
            RPriceText.text = "" + 60;
            R_ShopProcedure = 4;
            R_Key_Tier03.GetComponent<Item_Move>().enabled = true;
            R_Block_03.GetComponent<Block_Off>().enabled = true;
        }

        else if (R_Point >= 60 && R_ShopProcedure == 4)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 60);
            RPriceText.text = "" + 80;
            R_ShopProcedure = 5;
            R_BallAdd.GetComponent<Item_Move>().enabled = true;
            Invoke("AddRBall", 3);
        }
        else if (R_Point >= 80 && R_ShopProcedure == 5)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 80);
            RPriceText.text = "" + 150;
            R_ShopProcedure = 6;
            R_Key_Tier04.GetComponent<Item_Move>().enabled = true;
            R_Block_04.GetComponent<Block_Off>().enabled = true;
        }

        else if (R_Point >= 150 && R_ShopProcedure == 6)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 150);
            RPriceText.text = "" + 200;
            R_ShopProcedure = 7;
            R_Key_Tier05.GetComponent<Item_Move>().enabled = true;
            R_Block_05.GetComponent<Block_Off>().enabled = true;
        }

        else if (R_Point >= 200 && R_ShopProcedure == 7)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 200);
            RPriceText.text = "" + 150;
            R_ShopProcedure = 8;
            R_Mer_02.GetComponent<Item_Move>().enabled = true;
            Invoke("RMer02_On", 3);
        }
        else if (R_Point >= 150 && R_ShopProcedure == 8)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 150);
            RPriceText.text = "" + 150;
            R_ShopProcedure = 9;
            R_Tier_05Item01.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstR_05");
        }
        else if (R_Point >= 150 && R_ShopProcedure == 9)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 150);
            RPriceText.text = "" + 150;
            R_ShopProcedure = 10;
            R_Tier_05Item02.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstR_05");
        }
        else if (R_Point >= 150 && R_ShopProcedure == 10)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 150);
            RPriceText.text = "" + 150;
            R_ShopProcedure = 11;
            R_Tier_05Item03.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstR_05");
        }
        else if (R_Point >= 150 && R_ShopProcedure == 11)
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) - 150);
            RPriceText.text = "" + 150;
            R_ShopProcedure = 12;
            R_Tier_05Item04.GetComponent<Item_Move>().enabled = true;
            StartCoroutine("InstR_05");
        }
    }
    //돈 모았을 때 아이템 구매

    IEnumerator InstLTier1N2()
    {
        yield return new WaitForSeconds(3);
        float LTier01_Count = 0;
        if (L_Base)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(L_Tier_01, L_Base_InstPos.position + new Vector3(0, 0, LTier01_Count), L_Base_InstPos.rotation);
                LTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }

            for (int j = 0; j < 3; j++)
            {
                Instantiate(L_Tier_01, L_Base_InstPos.position + new Vector3(0, 0, LTier01_Count), L_Base_InstPos.rotation);
                LTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(L_Tier_01, Middle_InstPos.position + new Vector3(0, 0, LTier01_Count), Middle_InstPos.rotation);
                LTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }

            for (int j = 0; j < 3; j++)
            {
                Instantiate(L_Tier_01, Middle_InstPos.position + new Vector3(0, 0, LTier01_Count), Middle_InstPos.rotation);
                LTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
    IEnumerator InstRTier1N2()
    {
        yield return new WaitForSeconds(3);
        float RTier01_Count = 0;
        if (R_Base)
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(R_Tier_01, R_Base_InstPos.position + new Vector3(0, 0, RTier01_Count), R_Base_InstPos.rotation);
                RTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }
            for (int j = 0; j < 3; j++)
            {
                Instantiate(R_Tier_02, R_Base_InstPos.position + new Vector3(0, 0, RTier01_Count), R_Base_InstPos.rotation);
                RTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                Instantiate(R_Tier_01, Middle_InstPos.position + new Vector3(0, 0, RTier01_Count), Middle_InstPos.rotation);
                RTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }
            for (int j = 0; j < 3; j++)
            {
                Instantiate(R_Tier_02, Middle_InstPos.position + new Vector3(0, 0, RTier01_Count), Middle_InstPos.rotation);
                RTier01_Count -= 0.1f;
                yield return new WaitForSeconds(0.4f);
            }
        }
    }

    void LMer01_On()
    {
        if (L_Base)
        {
            Instantiate(L_Mer_01_Unit, L_Base_InstPos.position, L_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(L_Mer_01_Unit, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }
    void RMer01_On()
    {
        if (R_Base)
        {
            Instantiate(R_Mer_01_Unit, R_Base_InstPos.position, R_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(R_Mer_01_Unit, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }
    //용병 1티어 소환

    void AddLBall()
    {
        L_Ball.SetActive(true);
    }
    void AddRBall()
    {
        R_Ball.SetActive(true);
    }

    void LMer02_On()
    {
        if (L_Base)
        {
            Instantiate(L_Mer_02_Unit, L_Base_InstPos.position, L_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(L_Mer_02_Unit, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }
    void RMer02_On()
    {
        if (R_Base)
        {
            Instantiate(R_Mer_02_Unit, R_Base_InstPos.position, R_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(R_Mer_02_Unit, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }
    //용병 2티어 소환


    /*void LMer03_On()
    {
        *//*if (L_Base)
        {
            Instantiate(L_Mer_03_Unit, L_Base_InstPos.position, L_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(L_Mer_03_Unit, Middle_InstPos.position, Middle_InstPos.rotation);
        }*//*

        Instantiate(L_Mer_03_Unit, L_Base_InstPos.position + new Vector3(1.9f, 0, 0), L_Base_InstPos.rotation);
    }
    void RMer03_On()
    {
        *//*if (R_Base)
        {
            Instantiate(R_Mer_03_Unit, R_Base_InstPos.position, R_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(R_Mer_03_Unit, Middle_InstPos.position, Middle_InstPos.rotation);
        }*//*
        Instantiate(R_Mer_03_Unit, R_Base_InstPos.position + new Vector3(-6.9f, 0, 0), R_Base_InstPos.rotation);
    }
    //용병 3티어 소환*/

    IEnumerator InstL_05()
    {
        yield return new WaitForSeconds(3);
        if (L_Base)
        {
            Instantiate(L_Tier_05, L_Base_InstPos.position, L_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(L_Tier_05, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }
    IEnumerator InstR_05()
    {
        yield return new WaitForSeconds(3);
        if (R_Base)
        {
            Instantiate(R_Tier_05, R_Base_InstPos.position, R_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(R_Tier_05, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }

    /*IEnumerator InstL_06()
    {
        yield return new WaitForSeconds(3);
        if (L_Base)
        {
            Instantiate(L_Tier_06, L_Base_InstPos.position, L_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(L_Tier_06, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }
    IEnumerator InstR_06()
    {
        yield return new WaitForSeconds(3);
        if (R_Base)
        {
            Instantiate(R_Tier_06, R_Base_InstPos.position, R_Base_InstPos.rotation);
        }
        else
        {
            Instantiate(R_Tier_06, Middle_InstPos.position, Middle_InstPos.rotation);
        }
    }
    //6티어 소환*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "L_Coin")
        {
            LScoreText.text = "" + (int.Parse(LScoreText.text) + 1);
        }
        if (collision.gameObject.tag == "R_Coin")
        {
            RScoreText.text = "" + (int.Parse(RScoreText.text) + 1);
        }
        CheckLNum();
        CheckRNum();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cultist_Mer02 : MonoBehaviour
{
    private Animator Ani;

    [SerializeField] GameObject Knowledge;

    [SerializeField] GameObject Door;
    [SerializeField] GameObject Eye;
    [SerializeField] GameObject Body;
    [SerializeField] GameObject Swirl;

    [SerializeField] GameObject Laser;
    [SerializeField] GameObject Hand_Normal, Hand_Point;

    [SerializeField] GameObject Bullet_1, Bullet_2, Bullet_3, Bullet_4;
    [SerializeField] Transform Pos_01, Pos_02, Pos_04_1, Pos_04_2;

    [SerializeField] GameObject Universe;

    void Start()
    {
        Ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Count01()
    {
        int CurrentCount = Ani.GetInteger("Attack01_Count");
        Ani.SetInteger("Attack01_Count", CurrentCount + 1);
    }
    void Count02()
    {
        int CurrentCount = Ani.GetInteger("Attack02_Count");
        Ani.SetInteger("Attack02_Count", CurrentCount + 1);
    }
    void Count03()
    {
        int CurrentCount = Ani.GetInteger("Attack03_Count");
        Ani.SetInteger("Attack03_Count", CurrentCount + 1);
    }
    void Count01Return()
    {
        Ani.SetInteger("Attack01_Count", 0);
    }
    void Count02Return()
    {
        Ani.SetInteger("Attack02_Count", 0);
    }
    void Count03Return()
    {
        Ani.SetInteger("Attack03_Count", 0);
    }

    void KnowledgeOn()
    {
        Knowledge.GetComponent<Mat_DissolveGlow_Glow>().enabled = !Knowledge.GetComponent<Mat_DissolveGlow_Glow>().enabled;
    }
    void KnowledgeOff()
    {
        Knowledge.GetComponent<Mat_DissolveGlow_Fade>().enabled = !Knowledge.GetComponent<Mat_DissolveGlow_Fade>().enabled;
    }

    //Opening
    void Door_AlphaIn()
    {
        Door.GetComponent<Mat_AlphaDissolve_Glow>().enabled = !Door.GetComponent<Mat_AlphaDissolve_Glow>().enabled;
    }
    void Eye_FadeIn()
    {
        Eye.GetComponent<Color_AlphaFade_In>().enabled = !Eye.GetComponent<Color_AlphaFade_In>().enabled;
    }
    void Body_GlowIn()
    {
        Body.GetComponent<Mat_DissolveGlow_Glow>().enabled = !Body.GetComponent<Mat_DissolveGlow_Glow>().enabled;
    }
    void Swirl_AlphaIn()
    {
        Swirl.GetComponent<Mat_AlphaDissolve_Glow>().enabled = !Swirl.GetComponent<Mat_AlphaDissolve_Glow>().enabled;
    }
    void Eye_GlowOff()
    {
        Eye.GetComponent<Mat_AddColorFade>().enabled = !Eye.GetComponent<Mat_AddColorFade>().enabled;
    }

    //Attack_1
    void Shoot_01()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Bullet_1, Pos_01.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-1f, 1f)), Pos_01.rotation);
        }
    }

    //Attack_2
    void Shoot_02()
    {
        Instantiate(Bullet_2, Pos_02.position, Pos_02.rotation);
    }

    //Attack_3
    void PointHandOnOff()
    {
        Hand_Normal.GetComponent<Mat_AlphaDissolve_Fade>().enabled = !Hand_Normal.GetComponent<Mat_AlphaDissolve_Fade>().enabled;
        Hand_Point.GetComponent<Mat_AlphaDissolve_Glow>().enabled = !Hand_Point.GetComponent<Mat_AlphaDissolve_Glow>().enabled;
    }
    void LaserOnOff()
    {
        Laser.SetActive(!Laser.activeInHierarchy);
    }
    void LaserGlow()
    {
        Laser.GetComponent<Mat_AlphaDissolve_Glow>().enabled = !Laser.GetComponent<Mat_AlphaDissolve_Glow>().enabled;
    }
    void LaserFade()
    {
        Laser.GetComponent<Mat_AlphaDissolve_Fade>().enabled = !Laser.GetComponent<Mat_AlphaDissolve_Fade>().enabled;
    }
    void NormalHandOnOff()
    {
        Hand_Normal.GetComponent<Mat_AlphaDissolve_Glow>().enabled = !Hand_Normal.GetComponent<Mat_AlphaDissolve_Glow>().enabled;
        Hand_Point.GetComponent<Mat_AlphaDissolve_Fade>().enabled = !Hand_Point.GetComponent<Mat_AlphaDissolve_Fade>().enabled;
    }

    //Attack_4
    void UniverseOnOff()
    {
        Universe.SetActive(!Universe.activeInHierarchy);
    }

    void UniverseFadeIn()
    {
        Universe.GetComponent<Map_ColorFadeIn>().enabled = !Universe.GetComponent<Map_ColorFadeIn>().enabled;
    }

    void Eye_Glow()
    {
        Eye.GetComponent<Mat_AddColorGlow>().enabled = !Eye.GetComponent<Mat_AddColorGlow>().enabled;
    }

    void Shoot_03()
    {
        StartCoroutine(SpawnBullet04_1());
    }

    IEnumerator SpawnBullet04_1()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(Bullet_3, Pos_04_1.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1f, 1f), 0), Pos_04_1.rotation * Quaternion.Euler(0, 0, Random.Range(-9f, 9f)));
            yield return new WaitForSeconds(0.15f);
        }
    }

    void Astroid()
    {
        Instantiate(Bullet_4, Pos_04_2.position, Pos_04_2.rotation);
    }

    void UniverseFadeOut()
    {
        Universe.GetComponent<Map_ColorFadeOut>().enabled = !Universe.GetComponent<Map_ColorFadeOut>().enabled;
    }
}

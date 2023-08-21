using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Off : MonoBehaviour
{
    [SerializeField] GameObject ExtraBlock;
    void Start()
    {
        Invoke("Off", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*IEnumerator FadeStart()
    {
        yield return new WaitForSeconds(0.04f);
        
    }*/

    void Off()
    {
        if (ExtraBlock != null)
        {
            ExtraBlock.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}

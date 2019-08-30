using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 草莓被玩家碰撞时检测的相关类
/// </summary>
public class collectible : MonoBehaviour
{
    public ParticleSystem collectEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
       
    }
    ///碰撞检测相关
    void OnTriggerEnter2D(Collider2D other)
    {
       playercontrol  pc = other.gameObject .GetComponent<playercontrol >();
        if (pc != null)
        {
            if (pc.MyCurrentHealth < pc.MyMaxHealth)
            {   
                pc.ChangeHealth(1);
                Instantiate(collectEffect, transform.position, Quaternion.identity);//生成特效
                Destroy(this.gameObject);
                
            }

        }

    }
}

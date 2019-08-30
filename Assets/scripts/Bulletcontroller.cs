using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制子弹的移动和碰撞
/// </summary>
public class Bulletcontroller : MonoBehaviour
{
    Rigidbody2D rbody;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1f);//生成2秒后自动消失
    }


    void Update()
    {

    }
    public void Move(Vector2 moveDirection, float moveForce) {
        rbody.AddForce(moveDirection * moveForce);

    }
    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="collision"></param>  

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemycontroller bc = other.gameObject.GetComponent<Enemycontroller>();
        if (bc != null) {
            bc.Fixed ();//修复敌人
        }
        Destroy(this.gameObject);//碰到物体子弹消失

    }

   

}

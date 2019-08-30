using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敌人控制相关
/// </summary>
public class Enemycontroller : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3;//速度为3

    private Rigidbody2D rbody;//取刚体

    public bool isVertical;//是否垂直方向移动

    private Vector2 moveDirection;

    public float changeDirectionTime=2f;//改变方向的时间

    private float changeTimer;//计时器

    private Animator anim;

    private bool isFixed;//是否被修复

    public ParticleSystem brokenEffect;//损坏特效



    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();  //获取变量 ，比预先保存其引用后再调用要慢，尽量少用  

        anim = GetComponent<Animator >();//获取变量

        moveDirection = isVertical ? Vector2.up:Vector2.right;

        changeTimer = changeDirectionTime;

        isFixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFixed) return;//如果被修复了，直接返回，不执行以下所有代码

        changeTimer -= Time.deltaTime;

        if (changeTimer < 0)
        {

            moveDirection *= -1;

            changeTimer = changeDirectionTime;


        }

        Vector2 position = rbody.position;

        position.x += moveDirection.x * speed * Time.deltaTime;

        position.y += moveDirection.y * speed * Time.deltaTime;

        rbody.MovePosition(position);

        anim.SetFloat("moveX", moveDirection.x);//设置命名的浮点值

        anim.SetFloat("moveY", moveDirection.y);

    }
    void OnCollisionEnter2D(Collision2D other )//赋予碰撞检测属性

    {
        playercontrol pc = other.gameObject.GetComponent<playercontrol>();

        if (pc != null) {

            pc.ChangeHealth(-1);
        }

    }
    public void Fixed()
    {
        isFixed = true;
        if (brokenEffect.isPlaying==true  ) {
            brokenEffect.Stop();
        }
        rbody.simulated = false;//禁用物理
        anim.SetTrigger("fixed"); //播放被修复的动画
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 控制角色的移动，生命，动画等
/// </summary>
public class playercontrol : MonoBehaviour
{


    public float speed = 5f;

    Rigidbody2D rbody;

    private int MaxHealth = 5;

    private int currentHealth = 5;


    private float  invincibleTime = 2f;//无敌时间2s

    private float   invincibleTimer;//无敌计时器

    private bool isInvincible;//是否无敌

    public GameObject bulletPrefab;//子弹

    
    //=========================玩家朝向=============================

    private Vector2 lookDirection = new Vector2(1, 0);//默认朝向右方




    public int MyMaxHealth { get { return MaxHealth; } }

    public int MyCurrentHealth { get { return currentHealth; } }

      Animator anim;

 
    // Start is called before the first frame update
    void Start()
    {
        invincibleTimer = 0;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator >();
        UIManager.instance.Updateblood(currentHealth, MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 position = rbody.position;
        //position.x += moveX * speed * Time.deltaTime;
        //position.y += moveY * speed * Time.deltaTime;可以删去
       
        Vector2 moveVector = new Vector2(moveX ,moveY);
        if (moveVector.x != 0||moveVector .y !=0) {
            lookDirection = moveVector;

        }

        if (isInvincible)

        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer  <0)
            {
                isInvincible = false;
            }

        }
        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        anim.SetFloat("Speed", moveVector.magnitude);

        position += moveVector * speed * Time.deltaTime;
        rbody.MovePosition(position);

        //==================子弹按下J键进行攻击=====================
        if (Input.GetKeyDown(KeyCode.J)) {
            anim.SetTrigger("Launch");//播放攻击动画
           
         
            GameObject bullet = Instantiate(bulletPrefab, rbody.position+Vector2 .up*0.5f, Quaternion.identity);
            Bulletcontroller bc = bullet.GetComponent<Bulletcontroller>();
            if (bc != null) {
                bc.Move(lookDirection, 300);
            }

        }

    }






    public void ChangeHealth(int amount)
    {
        if (amount < 0)

        {
            anim.SetTrigger("Hit");
            Debug.Log(currentHealth + "/" + MaxHealth);
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
            Debug.Log(currentHealth + "/" + MaxHealth);
            UIManager.instance.Updateblood(currentHealth, MaxHealth);//更新血条
        }
        if (amount > 0)

        {
            Debug.Log(currentHealth + "/" + MaxHealth);
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, MaxHealth);
            Debug.Log(currentHealth + "/" + MaxHealth);
            UIManager.instance.Updateblood(currentHealth, MaxHealth);//更新血条
        }
    }



}

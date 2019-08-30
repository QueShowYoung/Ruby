using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 伤害陷阱
/// </summary>
public class DamageArea : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)

    {
        playercontrol pc = other.GetComponent<playercontrol >();

        if (pc != null)
        {
            pc.ChangeHealth(-1);
        }
    }
}

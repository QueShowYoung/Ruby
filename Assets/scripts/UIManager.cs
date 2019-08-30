using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI管理相关
/// </summary>
public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    private void Start()
    {
        instance = this;
    }
    public Image blood;
    public void Updateblood(float curAmount,int maxAmount)
    {
        blood.fillAmount = (float)curAmount /(float) maxAmount;
    }
}   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    private float time = 0;

    public Image uivar;

    [Header("Option")]
    public float curValue;
    public float maxValue;
    public float minValue;
    


    private void Awake()
    {
        curValue = maxValue;
    }
    void Start()
    {
        CharacterManager.instance.player.controller.onJumped += JumpDamage;
    }

    
    void Update()
    {
        minute();
        uivar.fillAmount = Getpercentage();
    }

    void minute()
    {
        for(int i = 0; i <= Time.deltaTime ; i++)
        {
            time++;
            i = 0;
        }
    }

    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, minValue);
    }

    public void subtrack(float amount)
    {
        curValue = Mathf.Max(curValue - amount, maxValue);
    }

    public float Getpercentage()
    {
        return curValue / maxValue;
    }

    public void JumpDamage()
    {
        curValue -= 1;
    }

    //최대체력 설정
    //최대 배고픔 설정
    //체력 설정
    //시간 설정
}

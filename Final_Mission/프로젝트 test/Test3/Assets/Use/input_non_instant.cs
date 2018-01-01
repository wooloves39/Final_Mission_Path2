using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_non_instant : MonoBehaviour
{
    public PointCheck MainPoint;
    public PointCheck[] Points;
    public PointCheck MyPoint;
    //현제 포인트 수
    public int count;
    //각 스킬 순서
    public int[] skill1;
    public int[] skill2;
    public int[] skill3;
    public int[] skill4;
    public int[] skill5;

    //완료 타이머
    private bool TimerOn;
    private float completeTimer;
    public GameObject Complete;
    // Use this for initialization
    void Start()
    {
        reset();
    }
    public bool getTimerOn(){ return TimerOn; }
    public void reset()
    {
        MainPoint.turnon();
        count = -1;
        MyPoint = MainPoint;
        completeTimer = 0.0f;
        TimerOn = false;
        
    }
    public void PointRestart()
    {
        for (int i = 0; i < Points.Length; ++i)
        {
            Points[i].reset();
        }
    }
    private void SkillTime()
    {
        if (TimerOn == true)
        {
            completeTimer += Time.deltaTime;
            if (completeTimer > 2.0f)
            {
                PointRestart();
                TimerOn = false;
                Complete.SetActive(false);
                reset();
                gameObject.SetActive(false);
                
            }
        }
    }
    private void PointReset()
    {
        for (int i = 0; i < Points.Length; ++i)
        {
            Points[i].turnoff();
        }
    }
    private void SkillChecks(int[] skill,int index)
    {
        if (skill.Length >= count + 1)
            if (Points[skill[count]] == MyPoint)
            {
                if (skill.Length == count + 1)
                {
                    Debug.Log(index);
                    Debug.Log("마법 발동!!");
                    Complete.SetActive(true);
                    TimerOn = true;
                }
                else
                {
                    for (int i = 0; i <= count + 1; ++i)
                    {
                        Points[skill[i]].turnon();
                    }
                }

            }
    }
    private void SkillCheck()
    {
        if (count >= 0)
        {
            PointReset();
            SkillChecks(skill1,1);
            SkillChecks(skill2,2);
            SkillChecks(skill3,3);
            SkillChecks(skill4,4);
            SkillChecks(skill5,5);
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        SkillTime();
        SkillCheck();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSleepingController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public static bool StatingPositionDone = false;
    public static bool InRight = false;
    public static bool StartTiringMechanic=false;
    public float turnCd;
    [SerializeField]
    private float _tiringMultipler;
    [SerializeField]
    private float _tiringPoint;
    [SerializeField]
    private float _maxTiringPoint;
    public float TiringPoint
    {
        get { return _tiringPoint; }
        set { _tiringPoint = value; }
    }
    public float MaxTiringPoint
    {
        get { return _maxTiringPoint; }
        set { _maxTiringPoint = value; }
    }
    public float TiringMultipler
    {
        get { return _tiringMultipler; }
        set { _tiringMultipler = value; }
    }
   
    void Start()
    {
        turnCd = 2;
        StatingPositionDone = false;
        StartTiringMechanic = false;
        animator = GetComponent<Animator>();
        animator.SetBool("StartLeft", false);
        animator.SetBool("StartRight", false);
    }

    // Update is called once per frame
    void Update()
    {
        TurningMechanic();
        TiringPointMechanic();
    }
    void TurningMechanic()
    {

        /////////
        ///Turning mechanic
        ////////
        turnCd-=Time.deltaTime*1f;
        if(turnCd<0)
        {
            turnCd = 0;
        }
        //starting position set if done starting up then once play anim
        
        if (StatingPositionDone == false)
        {
            if (Input.GetKeyDown(KeyCode.A)&&turnCd==0)
            {
                animator.SetBool("StartLeft", true);
                animator.SetBool("StartRight", false);
                Invoke("SetStartingStatus", 2f);
                InRight = false;
                turnCd = 2.5f;
            }
            if (Input.GetKeyDown(KeyCode.D)&&turnCd == 0)
            {
                animator.SetBool("StartLeft", false);
                animator.SetBool("StartRight", true);
                Invoke("SetStartingStatus", 2f);
                InRight = true;
                turnCd = 2.5f;
            }
        }
        //if done setting the starting position this section control player turn
        if (StatingPositionDone == true)
        {
            if (Input.GetKeyDown(KeyCode.D) && turnCd == 0)
            {
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
                InRight = true;
                turnCd = 2.5f;

            }
            if (Input.GetKeyDown(KeyCode.A) && turnCd == 0)
            {
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
                InRight = false;
                turnCd = 2.5f;

            }
        }
        

    }
    void TiringPointMechanic()
    {
        /////////
        //tiring point mechanic
        /////////

        if (StartTiringMechanic == true)
        {
            IncreaseTiringPoint();
            if (TiringPoint >= MaxTiringPoint)
            {
                TiringPoint = MaxTiringPoint;
            }
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            ResetTiringPoint();
        }

    }
    void SetStartingStatus()
    {
        StatingPositionDone = true;
        StartTiringMechanic = true;
        Debug.Log("Starting the mechanic");
    }
    void IncreaseTiringPoint()
    {
        _tiringPoint += Time.deltaTime * TiringMultipler;
    }
    void ResetTiringPoint()
    {
            _tiringPoint = 0;
            
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScript : MonoBehaviour
{


    public int Frame;



    #region UnityOneTimeLifeCycle
    //Awake calls before Start
    //Awake is called Even if Component is Disabled
    private void Awake()
    {
        Debug.Log("Awake Is Called");
    }

    //Start calls after Awake
    //Awake is called  ONLY  if Component is Enabled
    private void Start()
    {
        Debug.Log("Start Is Called");
    }

    //EveryTime Component gets Active
    private void OnEnable()
    {
        Debug.Log("OnEnabled Is Called");
    }

    //EveryTime Component is Deactive
    private void OnDisable()
    {
        Debug.Log("OnDisabled Is Called");
    }

    //Called When Object is Deleted
    private void OnDestroy()
    {
        Debug.Log("OnDestroy Is Called");
    }

    #endregion

    #region UnityRepeatLifeCycle



    //Called EveryFrame
    //Dependent on the RENDER CYCLE
    private void Update()
    {
        Debug.Log("Update is Called");
        //Rotate();
    }

    //DO Things here which Depeds on Update
    //Dependent on the RENDER CYCLE
    private void LateUpdate()
    {
        Debug.Log("Late Update is Called");
        //Rotate();
    }

    //Physics CYCLE Update 
    //Independent from the RENDER CYCLE
    private void FixedUpdate()
    {
        Debug.Log("Fixed Update is Called"+ Time.fixedDeltaTime); //0.02 Second is the fixed Interval
        Rotate();
    }



    void Rotate() {
        transform.rotation = Quaternion.Euler(new Vector3(0, Frame, 0));
        Frame++;
    }

    #endregion

}

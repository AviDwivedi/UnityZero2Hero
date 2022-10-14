using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveTypeA2B : MonoBehaviour
{
    public Tween.EaseType motionType;
    public float motionTime;
    public Transform targetA;
    public Transform targetB;
    public AnimationCurve animCurve;

    public UIMotion uiOutput => GetComponent<UIMotion>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            StartCoroutine(Animate());
            Debug.Log("Move");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToA();
            Debug.Log("Reset");
        }
    }

    void MoveToA()
    {
        float yValue = transform.position.y;
        transform.position = new Vector3(targetA.position.x, yValue, targetA.position.z);
    }

    IEnumerator Animate() {
        Vector3 from = targetA.position;
        Vector3 to = targetB.position;
        float yValue = transform.position.y;
        float tick = 0;

        while (tick <= motionTime) {
            tick += Time.deltaTime;
            float perc = tick / motionTime;

            Vector3 point; 

            if(motionType == Tween.EaseType.Custom)
                point = Tween.GetSmoothPointWithEase(from, to, perc, animCurve);
            else
                point = Tween.GetSmoothPointWithEase(from, to, perc, motionType);

            point.y = yValue;

            transform.position = point;
            uiOutput.UpdateLable(Mathf.Clamp(perc, 0.0f, 1.0f).ToString("0.00"), Enum.GetName(typeof(Tween.EaseType), motionType));

            yield return new WaitForEndOfFrame();
        }
        
    }



    
}

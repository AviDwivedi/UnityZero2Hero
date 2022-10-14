using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectA2B : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;

    public Transform target;

    public float MotionTime;




    private void Update()
    {
        TakeInput();


    }

    void TakeInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(AnimateObjectType1());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(AnimateObjectType2());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(AnimateObjectType3());
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(AnimateObjectType4());
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine(AnimateObjectType5());
        }
    }


    
    IEnumerator AnimateObjectType1() {

        float tick = 0;
        while (tick <= MotionTime) {
            tick += Time.deltaTime;

            float perc = tick / MotionTime;

            Vector3 newPos = Vector3.Lerp(PointA.position, PointB.position, perc); // Perc => 0 = A, 1 = B, 0.5= (A+B)/2;4
            newPos.y = target.position.y;
            target.position = newPos;

            //UI Update
            if(UIMotion.Instance != null)
                UIMotion.Instance.UpdateLable("Time: ", tick, "Linear: ", perc);
            yield return new WaitForEndOfFrame();
        
        }

    }

    const float curve = Mathf.PI * 2;
    public int frequency = 1;
    IEnumerator AnimateObjectType2()
    {
        float yValue = target.position.y;
        float tick = 0;
        while (tick <= MotionTime)
        {
            tick += Time.deltaTime;

            float perc = tick / MotionTime;

            Vector3 newPos = Vector3.Lerp(PointA.position, PointB.position, perc); // Perc => 0 = A, 1 = B, 0.5= (A+B)/2;4

            //zig zag Moves
            newPos.y = yValue + Mathf.Sin(perc * curve * frequency);
            target.position = newPos;

            //UI Update
            if (UIMotion.Instance != null)
                UIMotion.Instance.UpdateLable("Sin: ", Mathf.Sin(perc * curve), "Perc: ", perc);
            yield return new WaitForEndOfFrame();

        }

    }

    ///"EaseOut Curve"
    IEnumerator AnimateObjectType3()
    {

        float tick = 0;
        while (tick <= MotionTime)
        {
            tick += Time.deltaTime;

            float perc = tick / MotionTime;
            perc = Mathf.Sin( perc * Mathf.PI * 0.5f );//easeOut

            Vector3 newPos = Vector3.Lerp(PointA.position, PointB.position, perc); // Perc => 0 = A, 1 = B, 0.5= (A+B)/2;4
            newPos.y = target.position.y;
            target.position = newPos;

            //UI Update
            if (UIMotion.Instance != null)
                UIMotion.Instance.UpdateLable("Time: ", tick, "EaseOut: ", perc);
            yield return new WaitForEndOfFrame();

        }

    }

    //EaseIn
    IEnumerator AnimateObjectType4()
    {

        float tick = 0;
        while (tick <= MotionTime)
        {
            tick += Time.deltaTime;

            float perc = tick / MotionTime;
            perc = 1 - Mathf.Cos(perc * Mathf.PI * 0.5f);//easeIn

            Vector3 newPos = Vector3.Lerp(PointA.position, PointB.position, perc); // Perc => 0 = A, 1 = B, 0.5= (A+B)/2;4
            newPos.y = target.position.y;
            target.position = newPos;

            //UI Update
            if (UIMotion.Instance != null)
                UIMotion.Instance.UpdateLable("Time: ", tick, "EaseIn: ", perc);
            yield return new WaitForEndOfFrame();

        }

    }

    //Expocurve
    IEnumerator AnimateObjectType5()
    {

        float tick = 0;
        while (tick <= MotionTime)
        {
            tick += Time.deltaTime;

            float perc = tick / MotionTime;
            perc = perc * perc;//ExpoCurve

            Vector3 newPos = Vector3.Lerp(PointA.position, PointB.position, perc); // Perc => 0 = A, 1 = B, 0.5= (A+B)/2;4
            newPos.y = target.position.y;
            target.position = newPos;

            //UI Update
            if (UIMotion.Instance != null)
                UIMotion.Instance.UpdateLable("Time: ", tick, "EaseIn: ", perc);
            yield return new WaitForEndOfFrame();

        }

    }

}

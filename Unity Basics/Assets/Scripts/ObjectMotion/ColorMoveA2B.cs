using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMoveA2B : MonoBehaviour
{
    public Renderer PointA;
    public Renderer PointB;

    public Renderer target;

    public float MotionTime;




    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AnimateObject());
        }
    }



    IEnumerator AnimateObject()
    {

        float tick = 0;
        while (tick <= MotionTime)
        {
            tick += Time.deltaTime;

            float perc = tick / MotionTime;

            //Motion Code
            Vector3 newPos = Vector3.Lerp(PointA.transform.position, PointB.transform.position, perc); // Perc => 0 = A, 1 = B, 0.5= (A+B)/2;4
            newPos.y = target.transform.position.y;
            target.transform.position = newPos;

            //Color Animate
            Color A = PointA.material.color;
            Color B = PointB.material.color;

            Color C = Color.Lerp(A, B, perc);
            target.material.color = C;



            //UI Update
            if (UIMotion.Instance != null)
                UIMotion.Instance.UpdateLable("C: " + C.ToString(), tick, "Prec: ", perc); ;
            yield return new WaitForEndOfFrame();

        }

    }
}

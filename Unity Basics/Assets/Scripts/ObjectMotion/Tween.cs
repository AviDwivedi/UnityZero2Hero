using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{
    public enum EaseType
    {
        Linear,
        Square,
        Cubic,
        EaseIn,
        EaseOut,
        EaseInOut,
        Custom
    };

    public static Vector3 GetSmoothPointWithEase(Vector3 from, Vector3 to, float perc, EaseType type)
    {
        Vector3 point;

        if (type == EaseType.Linear)
            perc = perc;

        if (type == EaseType.Square)
            perc = perc * perc;

        if (type == EaseType.Cubic)
            perc = perc * perc * perc;

        if (type == EaseType.EaseIn)
            perc = 1 - Mathf.Cos(perc * Mathf.PI * 0.5f);

        if (type == EaseType.EaseOut)
            perc = Mathf.Sin(perc * Mathf.PI * 0.5f);

        if (type == EaseType.EaseInOut)
            perc = perc * perc * (3.0f - 2.0f * perc);



        point = Vector3.Lerp(from, to, perc);

        return point;
    }

    public static Vector3 GetSmoothPointWithEase(Vector3 from, Vector3 to, float perc, AnimationCurve curve)
    {
        Vector3 point;

        perc = curve.Evaluate(perc);
        point = LerpUnclamped(from, to, perc);

        return point;
    }

    public static Vector3 LerpUnclamped(Vector3 from, Vector3 to, float t) {
        Vector3 point;

        Vector3 dir = to - from;
        point = from + dir * t;
        return point;
    }
}
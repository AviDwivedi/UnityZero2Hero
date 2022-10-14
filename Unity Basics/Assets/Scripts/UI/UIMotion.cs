using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMotion : MonoBehaviour
{
    public static UIMotion Instance;

    public Text timeLable;
    public Text percLable;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateLable(string prefixV1, float t, string prefixV2, float p) {
        timeLable.text = prefixV1 + t;
        percLable.text = prefixV2 + p;
    }

    public void UpdateLable(string prefixV1, string prefixV2)
    {
        timeLable.text = prefixV1;
        percLable.text = prefixV2;
    }
}

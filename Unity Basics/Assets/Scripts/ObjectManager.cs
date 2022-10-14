using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject Object;
    public int CopyNumber;


    GameObject A;
    GameObject B;
    GameObject C;
    GameObject D;

    private void Start()
    {
        A = MakeCopy(Object);
        B = MakeCopy(Object);
        C = MakeCopy(Object);
        D = MakeCopy(Object);
    }

    //Take Input
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            AddRotationToObject(A);
            AddRotationToObject(B);
            AddRotationToObject(C);
            AddRotationToObject(D);
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            RemoveRotaionFromObject(A);
            RemoveRotaionFromObject(C);
        }
    }


    //Introduce GameOject at Runtime
    GameObject MakeCopy(GameObject obj) {
        CopyNumber++;
        return Instantiate(obj, new Vector3(CopyNumber * 2, 1, 0), Quaternion.identity);
    }

    //Remove GameOject at Runtime
    void DestroyObject(GameObject obj) {
        Destroy(obj);
    }


    void AddRotationToObject(GameObject obj) {

        Rotator rot = obj.GetComponent<Rotator>();
        if(rot==null)
            rot = obj.AddComponent<Rotator>();

        rot.rotationVec.y = 5;//Speed of 5
    }

    void RemoveRotaionFromObject(GameObject obj)
    {
        Destroy(obj.GetComponent<Rotator>());
    }

}

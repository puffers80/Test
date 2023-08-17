using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatStepHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public List<FloatStep> steps;
    void Start()
    {
        //GameRoomManager.instance.InitFloatStepHandler(this);
    }
    public void Init()
    {
        foreach (FloatStep item in steps)
            item.Init();
    }
    public void StopMove()
    {
        foreach (FloatStep item in steps)
            item.StopMoving();
    }
    // Update is called once per frame
    public Transform GetFloatStepTrans(string id)
    {
        FloatStep temp = steps.Find(q => q.id == id);
        return temp == null ? null : temp.transform;
    }
}

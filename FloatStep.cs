using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum MoveType
{
    X,
    Y,
    Z,
}
public class FloatStep : MonoBehaviour
{
    public string id;
    public MoveType move;
    public float distance;
    public float time;
    private float end;
    // Start is called before the first frame update
    public Vector3 orginPos;
    public Vector3 orginScale;
    public Quaternion orginRotate;
    private Tween mTween;
    private void Start()
    {
        orginPos = this.transform.localPosition;
        orginScale = this.transform.localScale;
        orginRotate = this.transform.localRotation;
    }
    public void StopMoving()
    {
        if (mTween != null)
        {
            mTween.Pause();
            mTween.Kill(true);
        }
        transform.localPosition = orginPos;
        transform.localRotation = orginRotate;
        transform.localScale = orginScale;
    }
    public void Init()
    {
        if (time == 0 || distance == 0) return;
        if(move == MoveType.X)
        {
            end = transform.localPosition.x + distance;
            mTween = transform.DOLocalMoveX(end, time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);
        }
        else if(move == MoveType.Y)
        {
            end = transform.localPosition.y + distance;
            mTween = transform.DOLocalMoveY(end, time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);
        }
        else if(move == MoveType.Z)
        {
            end = transform.localPosition.z + distance;
            mTween = transform.DOLocalMoveZ(end, time).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutExpo);
        }
    }
    public void OnPlayerExit(PlayerBase player)
    {
        player.transform.parent = null;
    }
    public void OnPlayerEnter(PlayerBase player)
    {
        player.transform.parent = this.transform;
    }
    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("=ente====" + other.transform.name);
        LocalPlayerController local = other.transform.GetComponent<LocalPlayerController>();
        if (local != null)
        {
            if(local.transform.parent != this.transform)
            {
                local.UseRootMotion(true);
                local.transform.parent = this.transform;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("=exit====" + other.transform.name);
        LocalPlayerController local = other.transform.GetComponent<LocalPlayerController>();
        if (local != null)
        {
            local.UseRootMotion(false);
            local.transform.parent = null;
        }
    }*/
   
}

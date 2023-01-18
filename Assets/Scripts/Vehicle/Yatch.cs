using DG.Tweening;
using UnityEngine;

public class Yatch : Vehicle
{
    [SerializeField] private StashDischarger discharger;
    private Vector3 startPos;
    private Quaternion startRot;
    private void Start()
    {
        startPos = movement.transform.position;
        startRot = movement.transform.rotation;
        movement.enabled = false;
        collector.enabled = false;
    }
    public override void Leave()
    {
        
        movement.transform.DOMove(startPos, 1f).SetId(this).OnComplete(()=>
        {
            discharger.Discharge();
            base.Leave();
        });
        movement.transform.DORotateQuaternion(startRot, .7f);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening.Plugins.Core.PathCore;

public class Train : MonoBehaviour
{
    [SerializeField] List<Transform> roadPoints;
    [SerializeField] StashDischarger stash;
    [SerializeField] float speed;
    private void OnEnable()
    {
        Movement();
    }
    private void Movement()
    {
        
        List<Vector3> roadPositions = new List<Vector3>();
        roadPoints.ForEach(r => roadPositions.Add(r.position));
        Path path = new Path(PathType.CatmullRom, roadPositions.ToArray(), 2, Color.green);
        transform.DOPath(path, speed).SetLookAt(0, true)
            .SetOptions(true).SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartPoint"))
        {
            stash.Discharge();
        }
    }
}

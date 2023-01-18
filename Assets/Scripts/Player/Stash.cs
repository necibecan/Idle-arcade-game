using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stash : MonoBehaviour
{
    public int CollectedCount => CollectedObjects.Count;
    public Vector3 StashParentPos => stashParent.transform.position;
    [SerializeField] Transform stashParent;
    [SerializeField] List<Stashable> CollectedObjects;
    [SerializeField] float collectionHeight = 1;
    [SerializeField] int maxCollectableCount = 5;

    public void AddStash(Collectable collectedObject)
    {
        if (CollectedCount >= maxCollectableCount)
            return;

        var yLocalPosition = CollectedCount * collectionHeight;

        var stashable = collectedObject.Collect(); 
        stashable.CollectStashable(stashParent, yLocalPosition, null);
        CollectedObjects.Add(stashable);
         
    }

    public Stashable RemoveStash()
    {
        if (CollectedCount <= 0)
            return null;

        var stashable = CollectedObjects[CollectedCount - 1];

        CollectedObjects.Remove(stashable);
        stashable.transform.parent = null;

        return stashable;

    }


}

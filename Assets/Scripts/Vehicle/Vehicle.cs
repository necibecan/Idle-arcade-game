using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vehicle : MonoBehaviour
{
    [SerializeField] protected Movement movement;
    [SerializeField] protected Collector collector;
    [SerializeField] protected Transform leavePos;
    [SerializeField] protected Button leaveButton;
    [SerializeField] protected CameraController cameraController;
    protected GameObject player;

    private void Start()
    {
        movement.enabled = false;
        collector.enabled = false;
    }

    public virtual void Leave()
    {
        movement.enabled = false;
        leaveButton.onClick.RemoveAllListeners();
        leaveButton.gameObject.SetActive(false);
        player.transform.position = new Vector3(leavePos.position.x, 0, leavePos.position.z);
        player.SetActive(true);
        cameraController.TargetTransform = player.transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DOTween.Complete(this);
            player = other.gameObject;
            leaveButton.onClick.RemoveAllListeners();
            leaveButton.onClick.AddListener(Leave);
            leaveButton.gameObject.SetActive(true);
            cameraController.TargetTransform = movement.transform;
            player.SetActive(false);
            movement.enabled = true;
            collector.enabled = true;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCam;
    [SerializeField] float zoomedOut = 60f;
    [SerializeField] float zoomedIn = 20f;
    [SerializeField] float zoomedInSensitivity = 0.5f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    RigidbodyFirstPersonController fpsController;

    bool zoomInToggle = false;
    public bool ZoomInToggle()
    {
        return zoomInToggle;
    }

    private void OnDisable()
    {
        ZoomOut();
    }

    private void Start()
    {
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (zoomInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomInToggle = false;
        fpsCam.fieldOfView = zoomedOut;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomInToggle = true;
        fpsCam.fieldOfView = zoomedIn;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }
}



using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class OcculusGazeInputModule : PointerInputModule
{
    //1
    public GameObject reticle;
    //2
    public Transform centerEyeTransform;
    //3
    public float reticleSizeMultiplier = 0.02f; 
    private PointerEventData pointerEventData;
    //5
    private RaycastResult currentRaycast;
    //6
    private GameObject currentLookAtHandler;


    public override void Process()
    {
        HandleLook();
        HandleSelection();
    }

    void HandleLook()
    {
        if (pointerEventData == null)
        {
            pointerEventData = new PointerEventData(eventSystem);
        }

        pointerEventData.position = Camera.main.ViewportToScreenPoint(new Vector3(.5f, .5f)); 
        List<RaycastResult> raycastResults = new List<RaycastResult>(); 
        eventSystem.RaycastAll(pointerEventData, raycastResults); 
        currentRaycast = pointerEventData.pointerCurrentRaycast = FindFirstRaycast(raycastResults); 

        reticle.transform.position = centerEyeTransform.position + (centerEyeTransform.forward * currentRaycast.distance); 
        float reticleSize = currentRaycast.distance * reticleSizeMultiplier;
        reticle.transform.localScale = new Vector3(reticleSize, reticleSize, reticleSize); 

        ProcessMove(pointerEventData);
    }

    void HandleSelection()
    {
        if (pointerEventData.pointerEnter != null)
        {
           
            currentLookAtHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(pointerEventData.pointerEnter);

            if (currentLookAtHandler != null && OVRInput.GetDown(OVRInput.Button.One))
            {
              
                ExecuteEvents.ExecuteHierarchy(currentLookAtHandler, pointerEventData, ExecuteEvents.pointerClickHandler);
            }
        }
        else
        {
            currentLookAtHandler = null;
        }
    }

}
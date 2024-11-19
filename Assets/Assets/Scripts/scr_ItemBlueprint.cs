using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

interface IInteractable
{
    public void Interact();
}

interface IUsable
{
    public void Use();
}

public class scr_ItemBlueprint : MonoBehaviour
{


    private string itemName;
    private GameObject selectedGameObject;
    private GameObject holdingGameObject;
    private IPickupable holdingIPickupable;

    public float InteractRange = 100;
    public static bool canInteract = false;

    public scr_PlayerMovement playerScript;
    private itemPickupManager itemPickupManager;
    public Transform IKTarget;



    void Start()
    {
        itemPickupManager = GameObject.Find("ItemHolder").GetComponent<itemPickupManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(Keybinds.interact)/*  | Input.GetMouseButtonDown(0) */ && playerScript.hit.transform != null)
        {
            selectedGameObject = playerScript.hit.transform.gameObject;

            if (selectedGameObject.TryGetComponent(out IInteractable interactObj) && playerScript.hit.distance <= InteractRange)
            {
                interactObj.Interact();
            }
            if (selectedGameObject.TryGetComponent(out IPickupable pickupObj) && playerScript.hit.distance <= InteractRange)
            {
                if (!itemPickupManager.isHolding)
                {
                    holdingIPickupable = pickupObj;
                    holdingGameObject = selectedGameObject;
                    bool pickupItem = pickupObj.Pickup();
                    if (pickupItem) itemPickupManager.PickupItem(holdingGameObject.transform);
                    pickupObj.AfterPickup();
                }
            }
            if (selectedGameObject.TryGetComponent(out IUsable useObj) && playerScript.hit.distance <= InteractRange)
            {
                useObj.Use();
                Destroy(selectedGameObject);
            }
        }
        if (Input.GetKeyDown(Keybinds.drop) && itemPickupManager.isHolding)
        {
            bool useDrop = holdingIPickupable.Drop();
            if (useDrop) itemPickupManager.DropItem();
            holdingIPickupable.AfterDrop();
            
        }

        if (itemPickupManager.isHolding)
        {
            IKTarget.position = holdingGameObject.transform.position;
            IKTarget.rotation = holdingGameObject.transform.rotation;
            IKTarget.parent.GetComponent<TwoBoneIKConstraint>().weight = 1;
        }
        else
        {
            IKTarget.localPosition = Vector3.zero;
            IKTarget.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
            IKTarget.parent.GetComponent<TwoBoneIKConstraint>().weight = 0;
        }


    }


}

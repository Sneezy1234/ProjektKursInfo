using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class schlüssel_1 : MonoBehaviour, IInteractable
{

    public scr_PlayerMovement playerScript;
    private itemPickupManager itemPickupManager;

    // Start is called before the first frame update
    public int schlüsselnummer;
    void Start()
    {
        itemPickupManager = GameObject.Find("ItemHolder").GetComponent<itemPickupManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            itemPickupManager.DropItem(this.gameObject);
        }
    }
    public void Interact()
    {
        playerScript.currentItem = schlüsselnummer;
        itemPickupManager.PickupItem(this.gameObject);

    }
}

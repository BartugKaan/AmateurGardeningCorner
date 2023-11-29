using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E;
    public KeyCode dropKey = KeyCode.Q; // Use a different key for dropping
    public Transform pickupPoint; // Reference to the pickup point

    void Update()
    {
        if (Input.GetKeyDown(pickupKey))
        {
            TryPickup();
        }

        // Check if the player is holding an item and pressed the drop key
        if (Input.GetKeyDown(dropKey) && pickupPoint.childCount > 0)
        {
            Transform heldItem = pickupPoint.GetChild(0);
            PickableItem pickableItem = heldItem.GetComponent<PickableItem>();
            
            if (pickableItem != null && pickableItem.IsHeld())
            {
                Debug.Log("Dropping item");
                pickableItem.Drop();
            }
        }
    }

    void TryPickup()
    {
        // Check if pickupPoint is not null
        if (pickupPoint != null)
        {
            // Create a layer mask for the "Pickable" layer
            int layerMask = 1 << LayerMask.NameToLayer("Pickable");

            // Raycast to check if there's a pickable object in front of the player
            RaycastHit hit;
            if (Physics.Raycast(pickupPoint.position, pickupPoint.forward, out hit, 2f, layerMask))
            {
                // Check if the hit object has the PickableItem script
                PickableItem pickableItem = hit.collider.GetComponent<PickableItem>();

                if (pickableItem != null && !pickableItem.IsHeld())
                {
                    pickableItem.PickUp(pickupPoint);
                }
            }
        }
    }
}

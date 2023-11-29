using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    private bool isHeld = false;
    public Transform pickupPoint;

    public void PickUp(Transform parent)
    {
        isHeld = true;
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero; // Adjust the local position as needed
        transform.rotation = pickupPoint.rotation;
        GetComponent<Rigidbody>().isKinematic = true; // Disable physics while held
    }

    public void Drop()
    {
        isHeld = false;
        transform.SetParent(null);
        GetComponent<Rigidbody>().isKinematic = false; // Enable physics when dropped
    }

    public bool IsHeld()
    {
        return isHeld;
    }
}

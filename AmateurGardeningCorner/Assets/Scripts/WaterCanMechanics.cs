using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanMechanics : MonoBehaviour
{
    public KeyCode useKey = KeyCode.Mouse0; // Left mouse button
    public Transform playerTransform; // Reference to the player's transform
    public float scaleAmount = 1.2f; // Amount to scale the plant

    void Update()
    {
        if (Input.GetKey(useKey))
        {
            WaterPlants();
        }
    }

    void WaterPlants()
    {
        // Create a layer mask for the "Plantable" layer
        int layerMask = 1 << LayerMask.NameToLayer("Plantable");

        // Raycast to check if there's a plantable object in front of the player
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position, playerTransform.forward, out hit, 2f, layerMask))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);

            // Check if the hit object has the PlantablePlot script
            PlantablePlot plantablePlot = hit.collider.GetComponent<PlantablePlot>();

            if (plantablePlot != null)
            {
                // Scale up the plant if the player is using the water can
                Transform plantTransform = plantablePlot.plantPrefab.transform;
                plantTransform.localScale *= scaleAmount;
            }
        }
    }
}

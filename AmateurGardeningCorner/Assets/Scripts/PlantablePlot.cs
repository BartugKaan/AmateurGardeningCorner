using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantablePlot : MonoBehaviour
{
    public KeyCode plantKey = KeyCode.F;
    public Transform plantingPoint; // Reference to the point where the seed will be planted
    public GameObject plantPrefab;
    public Vector3 originalScale = Vector3.one;// The prefab of the plant
    public GameObject newPlant;

    void Update()
    {
        if (Input.GetKeyDown(plantKey))
        {
            PlantSeed();
        }

        if (newPlant != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                newPlant.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                
            }
        }
    }

    void PlantSeed()
    {
        if (plantPrefab != null)
        {
            // Instantiate the plant prefab at the planting point
            newPlant = Instantiate(plantPrefab, plantingPoint.position, plantingPoint.rotation);

            // Set the original scale of the new plant
            newPlant.transform.localScale = new Vector3(0.1f,0.1f,0.1f);

            
        }
    }

}

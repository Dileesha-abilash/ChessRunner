using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPlacement : MonoBehaviour
{
    [SerializeField]private GameObject pawn;
    [SerializeField]private GameObject pawnbox;
    [SerializeField] private GameObject ReferenceObject;
    List<(int, int)> pairs = new List<(int, int)>
            {
                (6, 11), (5, 9), (9, 3), (11, 2), (1, 9), (1, 3), (6, 1), (0, 4),
                (11, 5), (2, 10), (7, 8), (7, 10), (4, 8), (10, 0), (3, 8), (7, 9),
                (6, 10), (4, 3), (5, 1), (7, 6), (1, 11), (0, 7), (4, 5), (2, 0),
                (3, 10), (6, 7), (11, 0), (7, 11), (4, 11), (8, 11), (8, 10), (1, 8),
                (3, 7), (8, 3), (6, 6), (0, 3), (6, 0), (5, 2), (9, 11), (10, 3),
                (11, 10), (6, 9), (7, 0), (7, 7), (2, 3), (2, 7), (1, 0), (10, 7),
                (9, 6), (11, 1), (9, 0), (7, 3), (9, 4), (9, 2), (11, 11), (1, 1),
                (11, 3), (3, 1), (4, 10), (10, 6), (11, 6), (0, 9), (2, 6), (4, 7),
                (5, 4)
            };

         
  
void PlaceObjects(GameObject pawn, Vector3 start, List<(int, int)> array)
{
    Debug.Log("Start Position: " + start);
    foreach (var singleElement in array)
    {
        Vector3 output = start;
        Debug.Log("Before Rotation: " + output);

        // Ensure pawnbox is assigned
        if (pawnbox != null)
        {
            // Calculate rotation around pawnbox
            float angle = 360f / 12 * singleElement.Item1; // Adjust angle for element
            Quaternion rotation = Quaternion.AngleAxis(angle, pawnbox.transform.up); // Rotation Quaternion
            Vector3 direction = output - pawnbox.transform.position; // Vector from pivot
            Vector3 rotatedDirection = rotation * direction; // Apply rotation
            output = pawnbox.transform.position + rotatedDirection; // Get new position
        }
        else
        {
            Debug.LogError("Pawnbox is not assigned!");
        }

        // Adjust y-coordinate based on the current element
        output.y = start.y + singleElement.Item2;

        Debug.Log("After Rotation: " + output);

        // Instantiate the object
        Instantiate(pawn, output, Quaternion.identity);
    }
}

    // Start is called before the first frame update
    void Start()
    {
       PlaceObjects(pawn,ReferenceObject.transform.position,pairs); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

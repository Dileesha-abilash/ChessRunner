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
    foreach (var singleElement in array)
    {
        // Calculate angle in degrees and convert to radians
        float angle = 360f / 12 * singleElement.Item1;
        float radians = angle * Mathf.Deg2Rad;

        Vector3 output = start;

        if (pawnbox != null)
        {
            // Calculate position on the cylinder surface
            float NewX = start.x * Mathf.Cos(radians) - start.z * Mathf.Sin(radians);
            float NewZ = start.x * Mathf.Sin(radians) + start.z * Mathf.Cos(radians);

            output.x = NewX;
            output.z = NewZ;
        }
        else
        {
            Debug.LogError("Pawnbox is not assigned!");
        }

        // Adjust y-coordinate based on the current element
        output.y = start.y + (singleElement.Item2*2f);

        // Calculate the normal direction at this position (pointing outward from the cylinder)
        Vector3 normalDirection = new Vector3(output.x, 0, output.z).normalized;

        // Create a rotation where the forward vector points outward (normalDirection)
        Quaternion rotation = Quaternion.LookRotation(normalDirection, Vector3.up);

        // Instantiate the object with correct position and orientation
        GameObject gg = Instantiate(pawnbox, output, rotation);
        GameObject parent= gg.transform.GetChild(0).gameObject;
        parent.transform.Rotate(0,90f,90f);
        //Debug.Log(parent.name);
            
    }
}

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log((float)ReferenceObject.transform.localScale.x/2);
       // Instantiate(pawn,new Vector3((float)ReferenceObject.transform.localScale.x /2, (float)ReferenceObject.transform.localScale.y ,
         //       (float)0),Quaternion.identity);
        Vector3 StartingPostion = new Vector3((float)ReferenceObject.transform.localScale.x/2,(float)-ReferenceObject.transform.localScale.y,(float)0);
       PlaceObjects(pawn,StartingPostion,pairs); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

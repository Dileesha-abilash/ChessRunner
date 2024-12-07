
using UnityEngine;

public class CylinderRadius : MonoBehaviour
{
    void Start()
    {
        // Reference the GameObject with the cylinder
        Transform cylinderTransform = transform;

        // Unity's default cylinder is oriented with the diameter along the X-axis or Z-axis
        // Assuming the cylinder's radius is based on the X scale (diameter)
        float diameter = cylinderTransform.localScale.x; // Adjust this if the diameter is along Z-axis
        float radius = diameter / 2;

        // Print the radius to the console
        Debug.Log("Radius of the cylinder: " + radius);
    }
}

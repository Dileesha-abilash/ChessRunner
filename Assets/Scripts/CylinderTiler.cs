
using UnityEngine;

public class CylinderTiler : MonoBehaviour
{
    public int rows = 8;       // Number of rows (vertical divisions)
    public int cols = 16;      // Number of columns (horizontal divisions)
    public float radius = 5f;  // Radius of the cylinder
    public float height = 10f; // Height of the cylinder
    public GameObject tilePrefab; // Prefab for each tile (e.g., a cube or quad)

    void Start()
    {
        GenerateCylinder();
    }

    void GenerateCylinder()
    {
        if (tilePrefab == null)
        {
            Debug.LogError("Please assign a tile prefab to the CylinderTiler script.");
            return;
        }

        float tileHeight = height / rows;          // Height of each tile
        float angleStep = 360f / cols;             // Angle between each column
        float yOffset = -height / 2f + tileHeight / 2f; // Start offset to center the cylinder

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                // Calculate position and rotation for the tile
                float angle = col * angleStep;         // Angle in degrees
                float radian = angle * Mathf.Deg2Rad; // Convert to radians

                // Position of the tile on the cylinder surface
                float x = radius * Mathf.Cos(radian);
                float z = radius * Mathf.Sin(radian);
                float y = yOffset + row * tileHeight;

                Vector3 tilePosition = new Vector3(x, y, z);

                // Rotation to make the tile face outward
                Quaternion tileRotation = Quaternion.Euler(0, -angle, 0);

                // Instantiate the tile
                GameObject tile = Instantiate(tilePrefab, tilePosition, tileRotation, transform);

                // Scale the tile to fit the cylinder
                tile.transform.localScale = new Vector3(angleStep * Mathf.Deg2Rad * radius, tileHeight, 1f);
            }
        }
    }
}

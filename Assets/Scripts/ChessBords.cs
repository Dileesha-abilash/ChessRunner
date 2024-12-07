
using UnityEngine;

public class ChessboardMaterial : MonoBehaviour
{
    public int size = 8; // Number of squares in one row/column
    public Color color1 = Color.black;
    public Color color2 = Color.white;

    void Start()
    {
        // Create a new texture
        Texture2D texture = new Texture2D(size * 2, size * 2);

        // Generate the chessboard pattern
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                // Check if the square should be color1 or color2
                bool isEven = (x / size + y / size) % 2 == 0;
                texture.SetPixel(x, y, isEven ? color1 : color2);
            }
        }

        texture.Apply(); // Apply the changes to the texture

        // Assign the texture to the material
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.mainTexture = texture;
        }
    }
}

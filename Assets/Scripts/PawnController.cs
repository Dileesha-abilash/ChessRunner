using System;
using UnityEngine;

public class PawnController : MonoBehaviour
{
    public Transform cylinder; // Reference to the cylinder chessboard
    public int rows = 8;       // Number of rows
    public int cols = 8;       // Number of columns
    public float radius = 5f;  // Radius of the cylinder
    public float verticalSpeed = 105f; // Speed of upward movement

    private int currentRow = 0; // Starting row
    private int currentCol = 0; // Starting column
    private CharacterController ChessCharacterLocation;

    private void Start()
    {
        ChessCharacterLocation = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Move straight up endlessly
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;

        // Optional: Retain left and right movement for the pawn
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        currentCol = (currentCol - 1 + cols) % cols;
        UpdatePawnPosition();
    }

    void MoveRight()
    {
        currentCol = (currentCol + 1) % cols;
        UpdatePawnPosition();
    }

    void UpdatePawnPosition()
    {
        // Calculate angle and position
        float angle = (360f / cols) * currentCol;
        float radian = angle * Mathf.Deg2Rad;

        float x = radius * Mathf.Cos(radian);
        float z = radius * Mathf.Sin(radian);
        float y = transform.position.y; // Keep the current y position for upward movement

        transform.position = new Vector3(x, y, z);
    }
}

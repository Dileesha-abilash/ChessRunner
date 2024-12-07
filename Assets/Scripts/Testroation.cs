using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    public GameObject pivitCylinder;

    private bool isRotating = false;

    private IEnumerator SwipeLeftRight(float angle)
    {
        if (isRotating) yield break; // Prevent starting another rotation while one is ongoing
        isRotating = true;

        float elapsed = 0f;
        float duration = 0.3f; // Total duration for the swipe (rotation + jump)
        float upwardDuration = duration / 2; // Duration for upward movement
        float jumpHeight = 2.13f; // Total height to jump away from the pivot
        float durationUnit = duration / 6; // Divide duration into six equal parts

        // Define rotations for different segments
        float firstHalfRotation = 43f; // 0-43f (1*durationUnit)
        float secondHalfRotation = 145f; // 43f-188f (2*durationUnit)
        float lastHalfRotation = 172f; // 188f-360f (3*durationUnit)

        float startAngle = 0f;
        float currentRotation = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float progress = elapsed / duration;

            // Calculate the target angle for the rotation around the pivot
            float targetAngle = Mathf.Lerp(startAngle, angle, progress);
            float deltaAngle = targetAngle - currentRotation;

            // Calculate upward or downward movement
            if (elapsed <= upwardDuration)
            {
                // Move upward during the first half
                float upwardProgress = elapsed / upwardDuration;
                float upwardOffset = Mathf.Lerp(0, jumpHeight, upwardProgress);
                transform.position += (transform.position - pivitCylinder.transform.position).normalized *
                                      Time.deltaTime * upwardOffset;
            }
            else
            {
                // Move downward during the second half
                float downwardProgress = (elapsed - upwardDuration) / upwardDuration;
                float downwardOffset = Mathf.Lerp(jumpHeight, 0, downwardProgress);
                transform.position -= (transform.position - pivitCylinder.transform.position).normalized *
                                      Time.deltaTime * downwardOffset;
            }

            // Perform self-rotation based on the elapsed time
            if (elapsed <= durationUnit)
            {
                // First segment rotation
                float deltaRotFirst = firstHalfRotation / durationUnit * Time.deltaTime;
                transform.Rotate(0f, deltaRotFirst, 0f);
            }
            else if (elapsed <= 3 * durationUnit)
            {
                // Second segment rotation
                float deltaRotSecond = secondHalfRotation / (2 * durationUnit) * Time.deltaTime;
                transform.Rotate(0f, deltaRotSecond, 0f);
            }
            else
            {
                // Last segment rotation
                float deltaRotLast = lastHalfRotation / (3 * durationUnit) * Time.deltaTime;
                transform.Rotate(0f, deltaRotLast, 0f);
            }

            // Perform rotation around the pivot
            transform.RotateAround(pivitCylinder.transform.position, Vector3.up, deltaAngle);
            currentRotation = targetAngle;

            yield return null;
        }

        // Ensure it ends exactly at the target angle
        float finalDelta = angle - currentRotation;
        transform.RotateAround(pivitCylinder.transform.position, Vector3.up, finalDelta);

        isRotating = false;
    }

    void Update()
    {
        // Check for input and rotate around the pivotCylinder if necessary
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(SwipeLeftRight(120f));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(SwipeLeftRight(-120f));
        }
    }
}

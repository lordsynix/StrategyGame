using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    // TODO: Fix Movement for y-positions

    public float moveSpeed = 5f; // Geschwindigkeit der Bewegung

    private bool inPosition = true;
    private Vector3 targetPosition; // Zielposition

    void Update()
    {
        // Bewege das Gameobject zur Zielposition mit der festgelegten Geschwindigkeit
        if (inPosition) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Aktiviert inPosition wenn die Unit richtig positioniert ist
        if (transform.position.x == targetPosition.x && transform.position.z == targetPosition.z)
            inPosition = true;
    }

    // Methode, um die Zielposition festzulegen
    public void SetTargetPosition(Vector3 position)
    {
        inPosition = false;
        targetPosition = new(position.x, 1, position.z);
    }
}

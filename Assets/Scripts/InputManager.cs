using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string targetTag = "Ground"; // Das Tag des Gameobjects "Ground"

    public GameObject unit;

    void Update()
    {
        // Wenn die rechte Maustaste gedrückt wird
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Überprüfe, ob der Raycast das Gameobject mit dem Tag "Ground" trifft
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(targetTag))
            {
                // Ermittle die Position des Treffers auf dem Gameobject "Ground"
                Vector3 groundPosition = hit.point;

                // Übergibt die Zielposition an die Unit
                unit.GetComponent<UnitMovement>().SetTargetPosition(groundPosition);
            }
        }
    }
}


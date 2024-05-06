using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool placementMode;
    public LayerMask groundLayer; // Der Layer des Gameobjects "Ground"
    
    public SelectedUnitDictionary selectedUnitDictionary;
    public UnitManager unitManager;
    

    void Update()
    {
        // Wenn die rechte Maustaste gedrückt wird
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Überprüfe, ob der Raycast das Gameobject mit dem Layer "Ground" trifft
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                // Ermittle die Position des Treffers auf dem Gameobject "Ground"
                Vector3 groundPosition = hit.point;

                if (!placementMode)
                {
                    // Übergibt die Zielposition an die Unit
                    foreach (var kvp in selectedUnitDictionary.selectedTable)
                    {
                        kvp.Value.GetComponent<UnitMovement>().SetTargetPosition(groundPosition);
                    }
                }
                else
                {
                    // Erstellt die Start-Unit
                    unitManager.PlaceStartUnits(groundPosition);
                    placementMode = false;
                }
                
            }
        }
    }
}


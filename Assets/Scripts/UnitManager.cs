using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public GameObject unit;
    public GameObject unitParent;

    public int startUnitCount = 9;

    private List<Vector3> unitOffsets = new List<Vector3>()
    {
        new(-3, 0,  3), new(0, 0,  3), new(3, 0,  3),
        new(-3, 0,  0), new(0, 0,  0), new(3, 0,  0),
        new(-3, 0, -3), new(0, 0, -3), new(3, 0, -3)
    };

    public void PlaceStartUnits(Vector3 inputPosition)
    {
        var targetPosition = new Vector3(inputPosition.x, 1, inputPosition.z);

        for (int i = 0; i < startUnitCount; i++)
        {
            var newUnit = Instantiate(unit, unitParent.transform, true);
            newUnit.transform.position = targetPosition + unitOffsets[i];
        }
    }
}

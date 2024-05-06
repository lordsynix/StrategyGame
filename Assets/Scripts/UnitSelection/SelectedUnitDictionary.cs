using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class SelectedUnitDictionary : MonoBehaviour
{
    public Dictionary<int, GameObject> selectedTable = new Dictionary<int, GameObject>();

    [Header("Selected Unit Text")]
    public GameObject selectedUnits;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            selectedUnits.SetActive(true);
        if (Input.GetKeyUp(KeyCode.Tab))
            selectedUnits.SetActive(false);
    }

    public void AddSelected(GameObject addedObject)
    {
        if (addedObject.layer != 3)
        {
            int id = addedObject.GetInstanceID();

            if (!(selectedTable.ContainsKey(id)))
            {
                selectedTable.Add(id, addedObject);
                addedObject.AddComponent<Selected>();
            }
        }
    }

    public void Deselect(int id)
    {
        Destroy(selectedTable[id].GetComponent<Selected>());
        selectedTable.Remove(id);
    }

    public void DeselectAll()
    {
        foreach (KeyValuePair<int, GameObject> pair in selectedTable)
        {
            if (pair.Value != null)
            {
                Destroy(selectedTable[pair.Key].GetComponent<Selected>());
            }
        }
        selectedTable.Clear();
    }
}
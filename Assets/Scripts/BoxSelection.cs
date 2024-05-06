using UnityEngine;

public class BoxSelection : MonoBehaviour
{
    public string targetTag = "Unit"; // Das Tag der auswählbaren Gameobjects

    private Vector3 startPoint;
    private Vector3 endPoint;

    void Update()
    {
        // Wenn die linke Maustaste gedrückt wird, speichere den Startpunkt der Boxauswahl
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition;
        }

        // Wenn die linke Maustaste losgelassen wird, beende die Boxauswahl und wähle die Gameobjects aus
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition;
            SelectObjectsInBox();
        }
    }

    void SelectObjectsInBox()
    {
        // Berechne die Boxauswahl im Weltkoordinatensystem basierend auf Start- und Endpunkt
        Bounds selectionBounds = GetSelectionBounds(startPoint, endPoint);

        Debug.Log("Bound Min: " + selectionBounds.min + " : Max: " + selectionBounds.max);
        // Finde alle Gameobjects mit dem angegebenen Tag innerhalb der Boxauswahl
        GameObject[] selectableObjects = GameObject.FindGameObjectsWithTag(targetTag);
        foreach (GameObject obj in selectableObjects)
        {
            Debug.Log("Obj: " + obj.transform.position);
            if (selectionBounds.Contains(obj.transform.position))
            {
                // Füge das ausgewählte Gameobject zur Auswahl hinzu
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    Bounds GetSelectionBounds(Vector3 startPoint, Vector3 endPoint)
    {
        // Berechne die Boxauswahl im Bildschirmkoordinatensystem
        Vector3 minScreenPoint = Vector3.Min(startPoint, endPoint);
        Vector3 maxScreenPoint = Vector3.Max(startPoint, endPoint);
        minScreenPoint.z = Camera.main.nearClipPlane;
        maxScreenPoint.z = Camera.main.farClipPlane;

        // Konvertiere die Bildschirmkoordinaten in Weltkoordinaten
        Vector3 minWorldPoint = Camera.main.ScreenToWorldPoint(minScreenPoint);
        Vector3 maxWorldPoint = Camera.main.ScreenToWorldPoint(maxScreenPoint);

        // Berechne die Boxauswahl im Weltkoordinatensystem
        Bounds selectionBounds = new Bounds();
        selectionBounds.SetMinMax(minWorldPoint, maxWorldPoint);

        return selectionBounds;
    }
}


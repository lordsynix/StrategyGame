using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f; // Bewegungsgeschwindigkeit der Kamera
    public float zoomSpeed = 5f; // Zoomgeschwindigkeit der Kamera
    public float minY = 1f; // Mindest-Zoom-Grenze
    public float maxY = 15f; // Maximale Zoom-Grenze

    void Update()
    {
        // Kamerabewegung mit den Tasten WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection, Space.World);

        // Kamerazoom mit Mausrad
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 zoomDirection = scroll * Time.deltaTime * zoomSpeed * transform.forward;
        transform.Translate(zoomDirection, Space.World);

        // Begrenze den Zoom, um sicherzustellen, dass die Kamera nicht zu nah oder zu weit weg ist
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = newPosition;
    }
}

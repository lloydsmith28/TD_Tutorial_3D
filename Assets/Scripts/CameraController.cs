using UnityEngine;

public class CameraController : MonoBehaviour {

    [Header("Panning")]
    public float panSpeed = 30f;
    public float panBoarderThickness = 10f;

    [Header("Scrolling")]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    private bool allowMovement = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Mainly for testing
        if (Input.GetKeyDown(KeyCode.Escape)) {
            allowMovement = !allowMovement;
        }

        if (!allowMovement) {
            return;
        }
		
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarderThickness) {
            panCamera(Vector3.forward);
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBoarderThickness) {
            panCamera(Vector3.back);
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarderThickness) {
            panCamera(Vector3.right);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panBoarderThickness) {
            panCamera(Vector3.left);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }


    void panCamera(Vector3 dir) {
        transform.Translate(dir * panSpeed * Time.deltaTime, Space.World);
    }
}

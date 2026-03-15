using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 10f;
    public float[] lookLimits = { -90, 90 };
    private Vector2 mouseLook = Vector2.zero;

    private GameObject head;
    private Camera camera;
    private Rigidbody rigidbody;
    private CharacterController controller;

    void Start()
    {
        // Initialise Components
        head = GetChildByName(gameObject, "Head");
        camera = head.GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>(); 
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Mouse Move
        mouseLook.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseLook.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseLook.y = Mathf.Clamp(mouseLook.y, lookLimits[0], lookLimits[1]);

        // Apply Mouse Movements
        transform.rotation = Quaternion.Euler(mouseLook.x, 0, 0);
        head.transform.rotation = Quaternion.Euler(0, mouseLook.y, 0);
        
    }


    // Gets children initially
    public GameObject GetChildByName(GameObject obj, string name)
    {
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (obj.transform.GetChild(i).name == name)
            {
                return obj.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }

}

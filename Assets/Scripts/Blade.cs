using UnityEngine;

public class Blade : MonoBehaviour
{

    //public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = .001f;

    public float followSpeed = 8.0f;
    public float distanceFromCamera = 5.0f;


    bool isCutting = false;

    Vector3 previousPosition;

    //GameObject currentBladeTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    public Vector3 Velocity
    {
        get;
        private set;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }




    }


    void StartCutting()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseScreenToWorld = cam.ScreenToWorldPoint(mousePosition);
        isCutting = true;
        previousPosition = Vector3.Lerp(previousPosition, mouseScreenToWorld, 1.0f - Mathf.Exp(-followSpeed * Time.deltaTime));
        circleCollider.enabled = false;
        mousePosition.z = distanceFromCamera;


    }

    void StopCutting()
    {
        isCutting = false;
        circleCollider.enabled = false;
    }
    void UpdateCut()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseScreenToWorld = cam.ScreenToWorldPoint(mousePosition);
        Vector3 newPosition = Vector3.Lerp(previousPosition, mouseScreenToWorld, 1.0f - Mathf.Exp(-followSpeed * Time.deltaTime));
        rb.position = newPosition;
        mousePosition.z = distanceFromCamera;


        Velocity = (newPosition - previousPosition);
        float distance = Velocity.magnitude;
        float speed = distance / Time.deltaTime;
        if (speed > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;

    }
}

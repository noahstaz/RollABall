using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody sphereRigidbody;
    [SerializeField] private float ballSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero; // initialize to zero
        if (Input.GetKey(KeyCode.W))
        {
            inputVector = Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector = Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector = Vector2.right;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector = Vector2.left;
        }

        //make the ball jump only if touching the ground
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(sphereRigidbody.linearVelocity.y) < 0.01f)
        {
            sphereRigidbody.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
       
        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed);
        Debug.Log("Resultant Vector: " + inputVector);
        Debug.Log("Resultant 3D Vector: " + inputXZPlane);
    }
}

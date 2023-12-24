using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rig;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    private FloatingJoystick joystick;
    private Vector3 moveVector;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        joystick = JoystickManager.Instance.joystick;
    }


    private void Update()
    {        
            Move();  
    }

    private void Move()
    {
        
            moveVector = Vector3.zero;
            moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
            moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

            if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            {
                Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(direction);
            }

            rig.MovePosition(rig.position + moveVector);   

    }

}

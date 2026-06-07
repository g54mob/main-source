using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	public float sensitivity = 1f;

	public float moveSpeed = 3f;

	public float jumpHeight = 3f;

	[SerializeField]
	private LayerMask myGround;

	[SerializeField]
	private Transform orientation;

	[SerializeField]
	private Transform cameraPositionHolder;

	private float xRotation;

	private float yRotation;

	[SerializeField]
	private Rigidbody rb;

	private float hInput;

	private float vInput;

	private bool grounded = true;

	private bool cursorLocked;

	private void Start()
	{
	}

	private void Update()
	{
		if (CameraController.instance.firstPersonMode)
		{
			CursorLock();
			FirstPersonRotation();
			FirstPersonMovementInput();
			JumpCheck();
		}
	}

	private void FixedUpdate()
	{
		if (CameraController.instance.firstPersonMode)
		{
			FirstPersonMovement();
			GroundCheck();
			DeathBoxCheck();
		}
	}

	private void JumpCheck()
	{
		if (Input.GetKey(KeyCode.Space) && grounded)
		{
			rb.velocity = new Vector3(rb.velocity.x, Mathf.Sqrt(jumpHeight * 9.81f * 2f), rb.velocity.z);
		}
	}

	private void GroundCheck()
	{
		grounded = Physics.Raycast(base.transform.position, Vector3.down, 0.6f, myGround, QueryTriggerInteraction.Ignore);
	}

	private void FirstPersonRotation()
	{
		if (!PauseMenu.instance.paused && cursorLocked)
		{
			float num = Input.GetAxisRaw("Mouse X") * sensitivity;
			float num2 = Input.GetAxisRaw("Mouse Y") * sensitivity;
			yRotation += num;
			xRotation -= num2;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);
			cameraPositionHolder.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
			orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
		}
	}

	private void FirstPersonMovementInput()
	{
		hInput = Input.GetAxisRaw("Horizontal");
		vInput = Input.GetAxisRaw("Vertical");
	}

	private void FirstPersonMovement()
	{
		Vector3 vector = orientation.forward * vInput + orientation.right * hInput;
		rb.velocity = vector.normalized * moveSpeed + Vector3.up * rb.velocity.y;
	}

	private void CursorLock()
	{
		if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift) && !PauseMenu.instance.paused)
		{
			Cursor.lockState = CursorLockMode.Locked;
			cursorLocked = true;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
			cursorLocked = false;
		}
	}

	private void DeathBoxCheck()
	{
		if (base.transform.position.y < -10f || Input.GetKey(KeyCode.C))
		{
			rb.velocity = Vector3.zero;
			base.transform.position = new Vector3(0f, 4.5f, 0f);
		}
	}
}

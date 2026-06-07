using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class RotateMoveCamera_InputSystem : MonoBehaviour
{
	[Header("Rotación")]
	public float minX = -360f;

	public float maxX = 360f;

	public float minY = -89f;

	public float maxY = 89f;

	public float sensitivityX = 100f;

	public float sensitivityY = 100f;

	[Header("Movimiento")]
	public float moveSpeed = 5f;

	private float rotationY;

	private float rotationX;

	private Vector2 moveInput;

	private Vector2 lookInput;

	private Camera cam;

	[SerializeField]
	private InputActionAsset inputActions;

	private InputAction moveAction;

	private InputAction lookAction;

	private void Awake()
	{
		cam = GetComponent<Camera>();
		moveAction = inputActions.FindActionMap("Player").FindAction("Move");
		lookAction = inputActions.FindActionMap("Player").FindAction("Look");
		moveAction.Enable();
		lookAction.Enable();
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		Rotate();
		Move();
	}

	private void Rotate()
	{
		lookInput = lookAction.ReadValue<Vector2>();
		rotationX += lookInput.x * sensitivityX * Time.deltaTime;
		rotationY += lookInput.y * sensitivityY * Time.deltaTime;
		rotationY = Mathf.Clamp(rotationY, minY, maxY);
		base.transform.localEulerAngles = new Vector3(0f - rotationY, rotationX, 0f);
	}

	private void Move()
	{
		moveInput = moveAction.ReadValue<Vector2>();
		Vector3 vector = base.transform.forward * moveInput.y + base.transform.right * moveInput.x;
		vector *= moveSpeed * Time.deltaTime;
		base.transform.position += vector;
	}
}

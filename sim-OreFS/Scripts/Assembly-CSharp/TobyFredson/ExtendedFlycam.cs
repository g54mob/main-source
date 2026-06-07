using UnityEngine;
using UnityEngine.InputSystem;

namespace TobyFredson
{
	public class ExtendedFlycam : MonoBehaviour
	{
		public float cameraSensitivity = 3f;

		public float climbSpeed = 4f;

		public float normalMoveSpeed = 10f;

		public float slowMoveFactor = 0.25f;

		public float fastMoveFactor = 3f;

		private float rotationX;

		private float rotationY;

		private InputAction moveAction;

		private InputAction lookAction;

		private InputAction climbUpAction;

		private InputAction climbDownAction;

		private InputAction fastAction;

		private InputAction slowAction;

		private void Awake()
		{
			moveAction = new InputAction("Move");
			moveAction.AddCompositeBinding("2DVector").With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s")
				.With("Left", "<Keyboard>/a")
				.With("Right", "<Keyboard>/d");
			lookAction = new InputAction("Look", InputActionType.Value, "<Mouse>/delta");
			climbUpAction = new InputAction("ClimbUp", InputActionType.Button, "<Keyboard>/e");
			climbDownAction = new InputAction("ClimbDown", InputActionType.Button, "<Keyboard>/q");
			fastAction = new InputAction("Fast", InputActionType.Button, "<Keyboard>/leftShift");
			fastAction.AddBinding("<Keyboard>/rightShift");
			slowAction = new InputAction("Slow", InputActionType.Button, "<Keyboard>/leftCtrl");
			slowAction.AddBinding("<Keyboard>/rightCtrl");
		}

		private void OnEnable()
		{
			moveAction.Enable();
			lookAction.Enable();
			climbUpAction.Enable();
			climbDownAction.Enable();
			fastAction.Enable();
			slowAction.Enable();
		}

		private void OnDisable()
		{
			moveAction.Disable();
			lookAction.Disable();
			climbUpAction.Disable();
			climbDownAction.Disable();
			fastAction.Disable();
			slowAction.Disable();
		}

		private void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void Update()
		{
			HandleMouseLook();
			HandleMovement();
			HandleClimb();
		}

		private void HandleMouseLook()
		{
			Vector2 vector = lookAction.ReadValue<Vector2>() * cameraSensitivity;
			rotationX += vector.x;
			rotationY -= vector.y;
			rotationY = Mathf.Clamp(rotationY, -90f, 90f);
			base.transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up) * Quaternion.AngleAxis(rotationY, Vector3.right);
		}

		private void HandleMovement()
		{
			Vector2 vector = moveAction.ReadValue<Vector2>();
			float num = normalMoveSpeed;
			if (fastAction.IsPressed())
			{
				num *= fastMoveFactor;
			}
			else if (slowAction.IsPressed())
			{
				num *= slowMoveFactor;
			}
			Vector3 vector2 = base.transform.forward * vector.y + base.transform.right * vector.x;
			base.transform.position += vector2 * num * Time.deltaTime;
		}

		private void HandleClimb()
		{
			if (climbUpAction.IsPressed())
			{
				base.transform.position += base.transform.up * climbSpeed * Time.deltaTime;
			}
			if (climbDownAction.IsPressed())
			{
				base.transform.position -= base.transform.up * climbSpeed * Time.deltaTime;
			}
		}
	}
}

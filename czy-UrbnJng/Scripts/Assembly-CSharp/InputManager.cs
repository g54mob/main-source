using System;
using System.Collections.Generic;
using System.Linq;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	public class OnMouseScrollEventArgs : EventArgs
	{
		public float mouseScrollDeltaY;
	}

	public class OnCameraMoveEventArgs : EventArgs
	{
		public Vector2 inputVector;
	}

	public class OnCameraRotationEventArgs : EventArgs
	{
		public Vector2 rotationVector;
	}

	[SerializeField]
	private Camera sceneCamera;

	private Vector3 lastPosition;

	private PlacedObject lastSelectedObject;

	public bool gamePause = true;

	[SerializeField]
	private LayerMask placementLayermask;

	[SerializeField]
	private LayerMask plantsLayermask;

	[SerializeField]
	private LayerMask potsLayermask;

	[SerializeField]
	private LayerMask surfaceToPlaceLayermask;

	private PlayerInputActions playerInputActions;

	private float moveSpeed = 250f;

	private Mouse mouse;

	private InputAction moveMouseAction;

	private Vector2 moveDirection;

	public Action OnNewPlant;

	public Action OnNextRoom;

	public Action OnFloorUp;

	public Action OnFloorDown;

	public Action OnPlantScrollRight;

	public Action OnPlantScrollLeft;

	public Action OnSelectPlant;

	public Action OnInfoPlant;

	private float dragHoldTime;

	private float rotateHoldTime;

	private float holdThreshold = 0.2f;

	private const float ROTATE_INDEX = 0.2f;

	private const float CAMERA_MOVEMENT_INDEX = 0.15f;

	public static InputManager Instance { get; private set; }

	public event EventHandler OnEscape;

	public event EventHandler OnJournal;

	public event EventHandler<OnMouseScrollEventArgs> OnMouseScroll;

	public event EventHandler<OnCameraMoveEventArgs> OnCameraMove;

	public event EventHandler<OnCameraRotationEventArgs> OnCameraRotation;

	public event EventHandler OnInteract;

	public event EventHandler OnInteractAlternate;

	public event EventHandler OnSpace;

	private void Awake()
	{
		Instance = this;
		playerInputActions = new PlayerInputActions();
		playerInputActions.Camera.Enable();
		playerInputActions.Player.Enable();
		playerInputActions.UI.Enable();
		InputSystem.onDeviceChange += OnDeviceChange;
	}

	private void Start()
	{
		playerInputActions.Player.Interact.performed += Interact_Performed;
		playerInputActions.Player.InteractAlternate.performed += InteractAlternate_Performed;
		playerInputActions.UI.Escape.performed += Escape_Performed;
		playerInputActions.UI.Journal.performed += Journal_performed;
		playerInputActions.UI.NewPlant.performed += NewPlant_performed;
		playerInputActions.UI.NextRoom.performed += NewRoom_performed;
		playerInputActions.UI.FloorUp.performed += FloorUp_performed;
		playerInputActions.UI.FloorDown.performed += FloorDown_performed;
		playerInputActions.UI.MoveMouse.performed += MoveMouse_performed;
		playerInputActions.UI.PlantScrollLeft.performed += PlantScrollLeft_performed;
		playerInputActions.UI.PlantScrollRight.performed += PlantScrollRight_performed;
		playerInputActions.UI.Space.performed += Space_performed;
		playerInputActions.UI.SelectPlant.performed += SelectPlant_performed;
		playerInputActions.UI.InfoPlant.performed += InfoPlant_performed;
		mouse = Mouse.current;
		GamepadCheck();
	}

	private void Update()
	{
		if (!gamePause)
		{
			Vector2 vector = playerInputActions.Camera.Move.ReadValue<Vector2>();
			Vector2 vector2 = playerInputActions.Camera.Rotate.ReadValue<Vector2>();
			float y = playerInputActions.Camera.Zoom.ReadValue<Vector2>().normalized.y;
			if (vector != Vector2.zero)
			{
				this.OnCameraMove?.Invoke(this, new OnCameraMoveEventArgs
				{
					inputVector = vector
				});
			}
			if (vector2 != Vector2.zero)
			{
				this.OnCameraRotation?.Invoke(this, new OnCameraRotationEventArgs
				{
					rotationVector = vector2
				});
			}
			if (y != 0f)
			{
				this.OnMouseScroll?.Invoke(this, new OnMouseScrollEventArgs
				{
					mouseScrollDeltaY = y
				});
			}
			bool num = playerInputActions.Camera.HoldDrag.IsPressed();
			Vector2 vector3 = playerInputActions.Camera.Drag.ReadValue<Vector2>();
			bool flag = playerInputActions.Camera.HoldRotate.IsPressed();
			if (num)
			{
				dragHoldTime += Time.deltaTime;
			}
			else
			{
				dragHoldTime = 0f;
			}
			if (flag)
			{
				rotateHoldTime += Time.deltaTime;
			}
			else
			{
				rotateHoldTime = 0f;
			}
			if (num && dragHoldTime >= holdThreshold && vector3 != Vector2.zero)
			{
				Vector2 inputVector = new Vector2(0f - vector3.x, 0f - vector3.y) * 0.15f;
				this.OnCameraMove?.Invoke(this, new OnCameraMoveEventArgs
				{
					inputVector = inputVector
				});
			}
			if (flag && rotateHoldTime >= holdThreshold && vector3 != Vector2.zero)
			{
				Vector2 rotationVector = new Vector2(0f - vector3.x, vector3.y) * 0.2f;
				this.OnCameraRotation?.Invoke(this, new OnCameraRotationEventArgs
				{
					rotationVector = rotationVector
				});
			}
		}
	}

	private void FixedUpdate()
	{
		if (!(moveDirection == Vector2.zero))
		{
			Vector2 vector = moveDirection * (moveSpeed * Time.fixedDeltaTime);
			Vector3 mousePosition = Input.mousePosition;
			Vector3 vector2 = new Vector3(mousePosition.x + vector.x, mousePosition.y + vector.y, mousePosition.z);
			mouse.WarpCursorPosition(new Vector2(vector2.x, vector2.y));
		}
	}

	private void MoveMouse_performed(InputAction.CallbackContext context)
	{
		if (mouse != null)
		{
			moveDirection = context.ReadValue<Vector2>().normalized;
		}
	}

	private void OnDeviceChange(InputDevice arg1, InputDeviceChange arg2)
	{
		GamepadCheck();
	}

	private void Interact_Performed(InputAction.CallbackContext obj)
	{
		if (!DialogueManager.Instance.IsActive())
		{
			if (!gamePause)
			{
				this.OnInteract?.Invoke(this, EventArgs.Empty);
			}
		}
		else
		{
			this.OnInteract?.Invoke(this, EventArgs.Empty);
		}
	}

	private void InteractAlternate_Performed(InputAction.CallbackContext obj)
	{
		if (!gamePause)
		{
			this.OnInteractAlternate?.Invoke(this, EventArgs.Empty);
		}
	}

	private void Escape_Performed(InputAction.CallbackContext obj)
	{
		if (!gamePause)
		{
			this.OnEscape?.Invoke(this, EventArgs.Empty);
			SoundManager.Instance.OnButtonClick();
		}
	}

	private void Journal_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause && !IsMouseOverUI() && !MovementSystem.Instance.IsMoving())
		{
			this.OnJournal?.Invoke(this, EventArgs.Empty);
			SoundManager.Instance.OnButtonClick();
		}
	}

	private void NewPlant_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause && !IsMouseOverUI())
		{
			OnNewPlant?.Invoke();
		}
	}

	private void NewRoom_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause && !IsMouseOverUI())
		{
			OnNextRoom?.Invoke();
		}
	}

	private void FloorUp_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause && !IsMouseOverUI())
		{
			OnFloorUp?.Invoke();
		}
	}

	private void FloorDown_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause && !IsMouseOverUI())
		{
			OnFloorDown?.Invoke();
		}
	}

	private void SelectPlant_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause && !IsMouseOverUI() && !MovementSystem.Instance.IsMoving())
		{
			OnSelectPlant?.Invoke();
		}
	}

	private void PlantScrollRight_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause)
		{
			OnPlantScrollRight?.Invoke();
		}
	}

	private void PlantScrollLeft_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause)
		{
			OnPlantScrollLeft?.Invoke();
		}
	}

	private void Space_performed(InputAction.CallbackContext obj)
	{
		if (!DialogueManager.Instance.IsActive())
		{
			if (!gamePause)
			{
				this.OnSpace?.Invoke(this, EventArgs.Empty);
			}
		}
		else
		{
			this.OnSpace?.Invoke(this, EventArgs.Empty);
		}
	}

	private void InfoPlant_performed(InputAction.CallbackContext obj)
	{
		if (!gamePause)
		{
			OnInfoPlant?.Invoke();
		}
	}

	private bool IsMouseOverUI()
	{
		PointerEventData eventData = new PointerEventData(EventSystem.current)
		{
			position = Input.mousePosition
		};
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, list);
		return list.Any((RaycastResult result) => result.gameObject.layer == LayerMask.NameToLayer("UI"));
	}

	public Vector3 GetMousePosition()
	{
		return Mouse.current.position.ReadValue();
	}

	public Vector3 GetSelectedMapPosition(out Transform selectedTransform)
	{
		selectedTransform = null;
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = sceneCamera.nearClipPlane;
		Ray ray = sceneCamera.ScreenPointToRay(mousePosition);
		if (Physics.Raycast(ray, out var hitInfo, 100f, placementLayermask))
		{
			lastPosition = hitInfo.point;
		}
		if (Physics.Raycast(ray, out hitInfo, 100f, surfaceToPlaceLayermask))
		{
			selectedTransform = hitInfo.transform;
			if (Physics.Raycast(hitInfo.point, -Vector3.up, out var hitInfo2, 100f, placementLayermask))
			{
				lastPosition = hitInfo2.point;
			}
		}
		return lastPosition;
	}

	public Transform GetSurfaceToPlace()
	{
		Transform result = null;
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = sceneCamera.nearClipPlane;
		if (Physics.Raycast(sceneCamera.ScreenPointToRay(mousePosition), out var hitInfo, 100f, surfaceToPlaceLayermask))
		{
			result = hitInfo.transform;
		}
		return result;
	}

	public PlacedObject GetSelectedObject()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = sceneCamera.nearClipPlane;
		Ray ray = sceneCamera.ScreenPointToRay(mousePosition);
		if (Physics.Raycast(ray, out var hitInfo, 100f, plantsLayermask) || Physics.Raycast(ray, out hitInfo, 100f, potsLayermask))
		{
			lastSelectedObject = hitInfo.transform.GetComponentInParent<Transform>().GetComponentInParent<PlacedObject>();
		}
		return lastSelectedObject;
	}

	public bool IsInteractingWithUI()
	{
		return EventSystem.current.IsPointerOverGameObject();
	}

	private void GamepadCheck()
	{
		if (Gamepad.all.Count <= 0)
		{
			return;
		}
		foreach (Gamepad item in Gamepad.all)
		{
			if (item.device.device.description.manufacturer.Contains("Sony"))
			{
				Debug.Log("Sony");
			}
			else if (item.device.device.description.manufacturer.Contains("Microsoft"))
			{
				Debug.Log("Xbox");
			}
		}
	}

	private void OnDestroy()
	{
		playerInputActions.Player.Interact.performed -= Interact_Performed;
		playerInputActions.Player.InteractAlternate.performed -= InteractAlternate_Performed;
		playerInputActions.UI.Escape.performed -= Escape_Performed;
		playerInputActions.UI.Journal.performed -= Journal_performed;
		playerInputActions.UI.NewPlant.performed -= NewPlant_performed;
		playerInputActions.UI.NextRoom.performed -= NewRoom_performed;
		playerInputActions.UI.FloorUp.performed -= FloorUp_performed;
		playerInputActions.UI.FloorDown.performed -= FloorDown_performed;
		playerInputActions.UI.MoveMouse.performed -= MoveMouse_performed;
		playerInputActions.UI.PlantScrollLeft.performed -= PlantScrollLeft_performed;
		playerInputActions.UI.PlantScrollRight.performed -= PlantScrollRight_performed;
		playerInputActions.UI.InfoPlant.performed += InfoPlant_performed;
		playerInputActions.Camera.Disable();
		playerInputActions.Player.Disable();
		playerInputActions.UI.Disable();
		InputSystem.onDeviceChange -= OnDeviceChange;
	}
}

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CraftingController : MonoBehaviour
{
	public GameObject rocket;

	public GameObject transformGizmo;

	public float sensitivity = 1.5f;

	private InputSystem_Actions input;

	private float rotationY;

	private float rotationX;

	private LayerMask installableLayer;

	private bool isDragging;

	private bool clickBlankedSpace;

	private bool isWingInstalling;

	private bool isCpuInstalling;

	private bool isWingGizmoConnecting;

	private bool wingInstalling;

	private int mask;

	private int gizmoMask;

	private int numOfWings = 1;

	private GameObject wing;

	private GameObject cpu;

	private WingGizmo wingGizmo;

	private WingGizmo lastHoveredGizmo;

	public GameObject wingLineGizmoPrefab;

	public static event Action OnWingGizmoSelected;

	private void OnRightClickStarted(InputAction.CallbackContext ctx)
	{
		clickBlankedSpace = true;
	}

	private void OnRightClickCanceled(InputAction.CallbackContext ctx)
	{
		clickBlankedSpace = false;
		isDragging = false;
	}

	private void OnLeftClickStarted(InputAction.CallbackContext ctx)
	{
		wingInstalling = true;
	}

	private void OnLeftClickCanceled(InputAction.CallbackContext ctx)
	{
		wingInstalling = false;
	}

	private void Awake()
	{
		input = GameManager.S.player.playerInput;
		input.Player.MouseRightClick.started += OnRightClickStarted;
		input.Player.MouseRightClick.canceled += OnRightClickCanceled;
		input.Player.MouseLeftClick.started += OnLeftClickStarted;
		input.Player.MouseLeftClick.canceled += OnLeftClickCanceled;
		GameManager.S.OnPartInstallBtnPressed += GameManager_OnPartInstallBtnPressed;
		CraftingUI.OnNumOfWings += CraftingUI_OnNumOfWings;
		GameManager.S.OnCancelWingInstalling += S_OnCancelWingInstalling;
		CraftingUI.OnWingConnectBtn += CraftingUI_OnWingConnectBtn;
		mask = ~LayerMask.GetMask("Player");
		gizmoMask = LayerMask.GetMask("Gizmo");
	}

	private void CraftingUI_OnWingConnectBtn()
	{
		isWingGizmoConnecting = true;
	}

	private void CraftingUI_OnNumOfWings(int obj)
	{
		numOfWings = obj;
	}

	private void S_OnCancelWingInstalling()
	{
		isWingGizmoConnecting = false;
		isCpuInstalling = false;
		isWingInstalling = false;
		cpu = null;
		wing = null;
		if (wingGizmo != null)
		{
			wingGizmo.DoneConnecting();
			wingGizmo = null;
		}
		GameManager.S.DeleteWingBluePrint();
		GameManager.S.DeleteBluePrint();
	}

	private void OnDestroy()
	{
		if (input != null)
		{
			input.Player.MouseRightClick.started -= OnRightClickStarted;
			input.Player.MouseRightClick.canceled -= OnRightClickCanceled;
			input.Player.MouseLeftClick.started -= OnLeftClickStarted;
			input.Player.MouseLeftClick.canceled -= OnLeftClickCanceled;
		}
		GameManager.S.OnPartInstallBtnPressed -= GameManager_OnPartInstallBtnPressed;
		GameManager.S.OnCancelWingInstalling -= S_OnCancelWingInstalling;
		CraftingUI.OnNumOfWings -= CraftingUI_OnNumOfWings;
		CraftingUI.OnWingConnectBtn -= CraftingUI_OnWingConnectBtn;
	}

	private void GameManager_OnPartInstallBtnPressed(object sender, GameManager.OnPartInstallBtnPressedArg e)
	{
		if (e.partType == 2f)
		{
			isWingInstalling = true;
			numOfWings = e.numOfWings;
			wing = e.part;
			return;
		}
		if (e.partType == 5f)
		{
			if (e.part.GetComponent<RocketChip>().type == RocketChip.ChipType.WingController)
			{
				isCpuInstalling = true;
				cpu = e.part;
			}
			return;
		}
		isWingInstalling = false;
		isCpuInstalling = false;
		isWingGizmoConnecting = false;
		cpu = null;
		wing = null;
		if (wingGizmo != null)
		{
			wingGizmo.DoneConnecting();
			wingGizmo = null;
		}
	}

	private void Start()
	{
		installableLayer = LayerMask.GetMask("Interactable");
	}

	private void Update()
	{
		if (!isDragging && clickBlankedSpace && !EventSystem.current.IsPointerOverGameObject())
		{
			isDragging = true;
		}
		if (isDragging)
		{
			TouchRocket();
		}
		if (isWingInstalling)
		{
			RocketWingRayCast(wing);
		}
		if (isCpuInstalling)
		{
			CpuRaycast(cpu);
		}
		if (isWingGizmoConnecting)
		{
			Debug.Log("A");
			wingGizmoRayCast();
		}
	}

	private void TouchRocket()
	{
		Vector2 mouseInput = GameManager.S.player.GetMouseInput();
		float angle = (0f - mouseInput.x) * sensitivity;
		float num = (0f - mouseInput.y) * sensitivity;
		rocket.transform.Rotate(Vector3.up, angle, Space.World);
		rocket.transform.Rotate(Camera.main.transform.right, 0f - num, Space.World);
	}

	private void wingGizmoRayCast()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		Ray ray = Camera.main.ScreenPointToRay(vector);
		if (wingGizmo != null && Physics.Raycast(ray, out var hitInfo, 3f, mask))
		{
			wingGizmo.Connecting(hitInfo.point);
		}
		Debug.Log("B");
		if (Physics.Raycast(ray, out var hitInfo2, 3f, gizmoMask))
		{
			Debug.Log("C");
			if (hitInfo2.collider.TryGetComponent<WingGizmo>(out var component))
			{
				if (lastHoveredGizmo != component)
				{
					if (lastHoveredGizmo != null)
					{
						lastHoveredGizmo.SetHover(isHovered: false);
					}
					component.SetHover(isHovered: true);
					lastHoveredGizmo = component;
				}
				if (FirstPersonController.S.playerInput.Player.MouseLeftClick.WasPressedThisFrame())
				{
					if (wingGizmo != null)
					{
						wingGizmo.DoneConnecting();
					}
					wingGizmo = component;
					wingGizmo.StartConneting(wingLineGizmoPrefab);
				}
			}
			else
			{
				Debug.Log("D");
				if (wingGizmo != null)
				{
					wingGizmo.Connecting(hitInfo2.collider.transform.position);
				}
				if (FirstPersonController.S.playerInput.Player.MouseLeftClick.WasPressedThisFrame() && wingGizmo != null)
				{
					wingGizmo.ConnectWing(hitInfo2.collider.gameObject);
					wingGizmo = null;
				}
			}
		}
		else
		{
			Debug.Log("E");
			Debug.Log(gizmoMask);
			if (lastHoveredGizmo != null)
			{
				lastHoveredGizmo.SetHover(isHovered: false);
				lastHoveredGizmo = null;
			}
		}
	}

	private void CpuRaycast(GameObject cpu)
	{
		_ = Camera.main.transform.position;
		_ = Camera.main.transform.forward;
		float maxDistance = 3f;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out var hitInfo, maxDistance, mask))
		{
			if (hitInfo.collider.transform.GetComponentInParent<RocketBody>() != null)
			{
				Vector3 perpendicularPoint = GetPerpendicularPoint(hitInfo.point, rocket.transform);
				GameManager.S.DrawCpuBluePrint(cpu, perpendicularPoint, rocket.transform);
				if (wingInstalling)
				{
					Rocket componentInChildren = rocket.GetComponentInChildren<Rocket>();
					GameManager.S.InstallCpuBluePrint(cpu, componentInChildren.rocketVisualPos);
					isCpuInstalling = false;
				}
			}
			else
			{
				GameManager.S.DeleteBluePrint();
			}
		}
		else
		{
			GameManager.S.DeleteBluePrint();
		}
	}

	private void RocketWingRayCast(GameObject wing)
	{
		_ = Camera.main.transform.position;
		_ = Camera.main.transform.forward;
		float maxDistance = 3f;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out var hitInfo, maxDistance, mask))
		{
			if (hitInfo.collider.transform.GetComponentInParent<RocketBody>() != null)
			{
				GetPerpendicularPoint(hitInfo.point, rocket.transform);
				Quaternion rotation = AlignObjectToProjection(hitInfo.normal, rocket.transform);
				GameManager.S.DrawWingBluePrint(wing, hitInfo.point, rotation, rocket.transform, numOfWings, canInstall: true);
				if (wingInstalling)
				{
					Rocket componentInChildren = rocket.GetComponentInChildren<Rocket>();
					GameManager.S.InstallWingBluePrint(wing, componentInChildren.rocketVisualPos);
					isWingInstalling = false;
				}
			}
			else
			{
				GameManager.S.DeleteWingBluePrint();
			}
		}
		else
		{
			GameManager.S.DeleteWingBluePrint();
		}
	}

	private bool IsInLayerMask(GameObject obj, LayerMask mask)
	{
		return ((1 << obj.layer) & (int)mask) != 0;
	}

	private Vector3 GetPerpendicularPoint(Vector3 point, Transform target)
	{
		Vector3 position = target.position;
		Vector3 normalized = target.forward.normalized;
		Vector3 vector = Vector3.Dot(point - position, normalized) * normalized;
		return position + vector;
	}

	private Quaternion AlignObjectToProjection(Vector3 normal, Transform target)
	{
		Vector3 normalized = Vector3.Cross(Vector3.Cross(normal, target.forward), normal).normalized;
		return Quaternion.LookRotation(-normal, normalized);
	}
}

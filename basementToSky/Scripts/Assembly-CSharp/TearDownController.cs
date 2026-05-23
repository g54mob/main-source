using System;
using System.Collections.Generic;
using RainbowArt.CleanFlatUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TearDownController : MonoBehaviour
{
	private Dictionary<GameObject, Vector3> originPosMap = new Dictionary<GameObject, Vector3>();

	private Dictionary<GameObject, Quaternion> originRotMap = new Dictionary<GameObject, Quaternion>();

	private Dictionary<GameObject, float> screwProgressMap = new Dictionary<GameObject, float>();

	public GameObject device;

	private DetailedDevice detailedDevice;

	public float sensitivity = 0.8f;

	public TearDownTable table;

	public ProgressBarPattern desolderGage;

	private InputSystem_Actions input;

	private float rotationY;

	private float rotationX;

	private int mask;

	private bool isDragging;

	private bool clickBlankedSpace;

	private bool mouseHolding;

	private bool spaced;

	private DetailedDevice.TearDownType processType;

	private LayerMask stackableLayerMask;

	private GameObject currentGrabPart;

	private HeatGun currentHeatgun;

	private Rigidbody currentGrabPartRb;

	private Vector3 targetPos;

	private Vector3 posTemp;

	private Quaternion rotationTemp;

	private int currentIndex;

	private GameObject lastDetachedPart;

	private int currentCoverShellIndex;

	public static event Action OnUnscrewDone;

	public static event Action<GameObject> OnDesolderStart;

	public static event Action<Chips> OnTeardownComplete;

	private void Awake()
	{
		input = GameManager.S.player.playerInput;
		input.Player.MouseRightClick.started += delegate
		{
			clickBlankedSpace = true;
		};
		input.Player.MouseRightClick.canceled += delegate
		{
			clickBlankedSpace = false;
		};
		input.Player.MouseRightClick.canceled += delegate
		{
			isDragging = false;
		};
		input.Player.MouseLeftClick.started += delegate
		{
			mouseHolding = true;
		};
		input.Player.MouseLeftClick.canceled += delegate
		{
			mouseHolding = false;
		};
		input.Player.Jump.started += delegate
		{
			spaced = true;
		};
		input.Player.Jump.canceled += delegate
		{
			spaced = false;
		};
		mask = LayerMask.GetMask("Device");
		mask &= ~(1 << LayerMask.NameToLayer("Player"));
		stackableLayerMask = LayerMask.GetMask("Stackable");
	}

	private void Start()
	{
		detailedDevice = device.GetComponent<DetailedDevice>();
		foreach (Transform item in device.transform)
		{
			if (item.gameObject != detailedDevice.baseShell)
			{
				originPosMap[item.gameObject] = item.localPosition;
				originRotMap[item.gameObject] = item.localRotation;
			}
		}
		originPosMap[detailedDevice.chips] = detailedDevice.chips.transform.localPosition;
		originRotMap[detailedDevice.chips] = detailedDevice.chips.transform.localRotation;
		GameObject[] screws = detailedDevice.screws;
		foreach (GameObject key in screws)
		{
			screwProgressMap[key] = 0f;
		}
		screws = detailedDevice.coverShell;
		for (int i = 0; i < screws.Length; i++)
		{
			screws[i].GetComponent<Collider>().enabled = false;
		}
		detailedDevice.coverShell[0].GetComponent<Collider>().enabled = true;
		currentIndex = 0;
		NextProgress(currentIndex);
	}

	private void OnEnable()
	{
		TearDownUI.OnNextBtnPressed += TearDownUI_OnNextBtnPressed;
		HeatGun.OnDesolderDone += HeatGun_OnDesolderDone;
		TearDownUI.OnDoneBtnPressed += TearDownUI_OnDoneBtnPressed;
	}

	private void OnDisable()
	{
		TearDownUI.OnNextBtnPressed -= TearDownUI_OnNextBtnPressed;
		HeatGun.OnDesolderDone -= HeatGun_OnDesolderDone;
		TearDownUI.OnDoneBtnPressed -= TearDownUI_OnDoneBtnPressed;
	}

	private void TearDownUI_OnDoneBtnPressed()
	{
		UnityEngine.Object.Destroy(this);
	}

	private void HeatGun_OnDesolderDone()
	{
		currentIndex++;
		NextProgress(currentIndex);
	}

	private void TearDownUI_OnNextBtnPressed()
	{
		currentIndex++;
		NextProgress(currentIndex);
	}

	private void NextProgress(int i)
	{
		AudioManager.S.StopSFX();
		if (i >= detailedDevice.progress.Count)
		{
			Chips component = detailedDevice.chips.GetComponent<Chips>();
			TearDownController.OnTeardownComplete?.Invoke(component);
			AudioManager.S.PlaySFX(AudioManager.S.tutorialUIOn);
			component.gameObject.transform.parent = table.pcbMount.transform;
			component.gameObject.transform.localPosition = Vector3.zero;
			component.gameObject.transform.localRotation = Quaternion.identity;
			detailedDevice.pcb.SetActive(value: false);
			UnityEngine.Object.Destroy(this);
			return;
		}
		processType = detailedDevice.progress[i];
		Debug.Log(i);
		if (processType == DetailedDevice.TearDownType.Unscrew)
		{
			GameObject[] screws = detailedDevice.screws;
			foreach (GameObject obj in screws)
			{
				obj.GetComponent<Collider>().enabled = true;
				obj.GetComponent<Outline>().enabled = true;
			}
			detailedDevice.baseShell.GetComponent<Collider>().enabled = true;
			screws = detailedDevice.coverShell;
			for (int j = 0; j < screws.Length; j++)
			{
				screws[j].GetComponent<Collider>().enabled = true;
			}
		}
		else if (processType == DetailedDevice.TearDownType.TearDown)
		{
			GameObject[] screws = detailedDevice.coverShell;
			for (int j = 0; j < screws.Length; j++)
			{
				screws[j].GetComponent<Collider>().enabled = false;
			}
			detailedDevice.coverShell[0].GetComponent<Collider>().enabled = true;
			detailedDevice.pcb.GetComponent<Collider>().enabled = true;
			detailedDevice.coverShell[0].GetComponent<Outline>().enabled = true;
		}
		else if (processType == DetailedDevice.TearDownType.Desolder)
		{
			Cursor.visible = true;
			GameObject[] screws = detailedDevice.screws;
			for (int j = 0; j < screws.Length; j++)
			{
				screws[j].SetActive(value: false);
			}
			TearDownController.OnDesolderStart?.Invoke(detailedDevice.chips);
			detailedDevice.baseShell.SetActive(value: false);
			screws = detailedDevice.coverShell;
			for (int j = 0; j < screws.Length; j++)
			{
				screws[j].SetActive(value: false);
			}
			detailedDevice.pcb.transform.parent = table.pcbMount.transform;
			detailedDevice.pcb.transform.localPosition = Vector3.zero;
			detailedDevice.pcb.transform.localRotation = Quaternion.identity;
			detailedDevice.pcb.GetComponent<Collider>().enabled = false;
			detailedDevice.pcb.GetComponent<Rigidbody>().isKinematic = true;
			detailedDevice.chips.GetComponent<Collider>().enabled = true;
		}
		else if (processType == DetailedDevice.TearDownType.RemoveChip)
		{
			detailedDevice.pcb.GetComponent<Collider>().enabled = true;
			if (currentHeatgun != null)
			{
				isDragging = false;
				currentHeatgun.isOn = false;
				currentHeatgun.isHandled = false;
			}
			detailedDevice.chips.GetComponent<Outline>().enabled = true;
			currentHeatgun = null;
			Cursor.visible = true;
		}
	}

	private void Update()
	{
		if (!isDragging && clickBlankedSpace && !EventSystem.current.IsPointerOverGameObject())
		{
			isDragging = true;
		}
		if (processType == DetailedDevice.TearDownType.Unscrew)
		{
			UnScrewControl();
		}
		else if (processType == DetailedDevice.TearDownType.TearDown)
		{
			TearDownControl();
		}
		else if (processType == DetailedDevice.TearDownType.Desolder)
		{
			DesolderControl();
		}
		else if (processType == DetailedDevice.TearDownType.RemoveChip)
		{
			ChipRemoveControl();
		}
		if (currentGrabPart == null && isDragging)
		{
			RotateParts();
		}
	}

	private void ChipRemoveControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			TryPickChip();
		}
		if (currentGrabPart != null)
		{
			DragChip();
			if (input.Player.MouseLeftClick.WasReleasedThisFrame())
			{
				DropChip();
			}
		}
	}

	private void TryPickChip()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 3f, mask) && hitInfo.collider.gameObject == detailedDevice.chips)
		{
			currentGrabPart = hitInfo.transform.gameObject;
			currentGrabPart.GetComponent<Collider>().enabled = false;
			posTemp = originPosMap[currentGrabPart];
			rotationTemp = originRotMap[currentGrabPart];
			currentGrabPartRb = currentGrabPart.GetComponent<Rigidbody>();
			if (currentGrabPartRb != null)
			{
				currentGrabPartRb.isKinematic = true;
			}
			AudioManager.S.PlaySFX(AudioManager.S.uiToggle);
			Cursor.visible = false;
		}
	}

	private void DragChip()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f))
		{
			int layer = hitInfo.collider.gameObject.layer;
			if (1 << layer != 0)
			{
				currentGrabPart.transform.parent = null;
				targetPos = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.1f, hitInfo.point.z);
				currentGrabPart.transform.position = Vector3.Lerp(currentGrabPart.transform.position, targetPos, Time.deltaTime * 5f);
			}
		}
	}

	private void DropChip()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f) && hitInfo.collider.gameObject != detailedDevice.baseShell)
		{
			if (currentGrabPartRb != null)
			{
				currentGrabPartRb.isKinematic = false;
				currentGrabPartRb = null;
			}
			currentGrabPart.transform.parent = null;
		}
		currentGrabPart.GetComponent<Collider>().enabled = true;
		currentGrabPart = null;
		Cursor.visible = true;
	}

	private void DesolderControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, float.PositiveInfinity, LayerMask.GetMask("Interactable")))
			{
				if (hitInfo.transform.TryGetComponent<HeatGun>(out var component))
				{
					currentHeatgun = component;
					component.isHandled = true;
					Cursor.visible = false;
					isDragging = true;
				}
				else
				{
					currentHeatgun = null;
				}
			}
			else
			{
				currentHeatgun = null;
			}
		}
		if (!(currentHeatgun != null) || !isDragging)
		{
			return;
		}
		Vector2 vector2 = Mouse.current.position.ReadValue();
		Ray ray = Camera.main.ScreenPointToRay(vector2);
		float y = table.pcbMount.transform.position.y + 0.1f;
		if (new Plane(Vector3.up, new Vector3(0f, y, 0f)).Raycast(ray, out var enter))
		{
			Vector3 point = ray.GetPoint(enter);
			currentHeatgun.transform.position = Vector3.Lerp(currentHeatgun.transform.position, point, Time.deltaTime * 10f);
		}
		if (!currentHeatgun.isOn)
		{
			if (spaced)
			{
				AudioManager.S.PlaySFXLoop(AudioManager.S.desolder);
			}
		}
		else if (!spaced)
		{
			AudioManager.S.StopSFX();
		}
		currentHeatgun.isOn = spaced;
		if (input.Player.MouseLeftClick.WasReleasedThisFrame())
		{
			isDragging = false;
			currentHeatgun.isOn = false;
			currentHeatgun.isHandled = false;
			currentHeatgun = null;
			Cursor.visible = true;
		}
	}

	private void RotateParts()
	{
		Vector2 mouseInput = GameManager.S.player.GetMouseInput();
		float angle = (0f - mouseInput.x) * sensitivity;
		float num = (0f - mouseInput.y) * sensitivity;
		device.transform.Rotate(Vector3.up, angle, Space.World);
		device.transform.Rotate(Camera.main.transform.right, 0f - num, Space.World);
	}

	private void UnScrewControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			TryPickScrew();
		}
		if (currentGrabPart != null)
		{
			HoldScrew();
			if (input.Player.MouseLeftClick.WasReleasedThisFrame())
			{
				DropScrew();
			}
		}
	}

	private void TryPickScrew()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 3f, mask) && hitInfo.collider.CompareTag("Bolt") && screwProgressMap.ContainsKey(hitInfo.transform.gameObject))
		{
			currentGrabPart = hitInfo.transform.gameObject;
			currentGrabPart.GetComponent<Collider>().enabled = false;
			posTemp = originPosMap[currentGrabPart];
			rotationTemp = originRotMap[currentGrabPart];
			currentGrabPartRb = currentGrabPart.GetComponent<Rigidbody>();
			if (currentGrabPartRb != null)
			{
				currentGrabPartRb.isKinematic = true;
			}
			AudioManager.S.PlaySFXLoop(AudioManager.S.unScrew);
			Cursor.visible = false;
		}
	}

	private void HoldScrew()
	{
		screwProgressMap[currentGrabPart] += Time.deltaTime;
		Vector3 vector = currentGrabPart.transform.localRotation * Vector3.up;
		Vector3 b = originPosMap[currentGrabPart] - vector * 0.005f;
		currentGrabPart.transform.localPosition = Vector3.Lerp(originPosMap[currentGrabPart], b, screwProgressMap[currentGrabPart]);
		currentGrabPart.transform.Rotate(Vector3.up * 720f * Time.deltaTime, Space.Self);
		if (screwProgressMap[currentGrabPart] > 1f)
		{
			AudioManager.S.StopSFX();
			currentGrabPart.GetComponent<Collider>().enabled = true;
			currentGrabPartRb = currentGrabPart.GetComponent<Rigidbody>();
			if (currentGrabPartRb != null)
			{
				currentGrabPartRb.isKinematic = false;
			}
			currentGrabPart.GetComponent<Outline>().enabled = false;
			currentGrabPartRb = null;
			currentGrabPart.transform.parent = null;
			screwProgressMap.Remove(currentGrabPart);
			Cursor.visible = true;
			if (screwProgressMap.Count == 0)
			{
				TearDownController.OnUnscrewDone?.Invoke();
				currentIndex++;
				NextProgress(currentIndex);
			}
			currentGrabPart = null;
		}
	}

	private void DropScrew()
	{
		currentGrabPart.GetComponent<Collider>().enabled = true;
		currentGrabPartRb = currentGrabPart.GetComponent<Rigidbody>();
		if (currentGrabPartRb != null)
		{
			currentGrabPartRb.isKinematic = true;
		}
		currentGrabPartRb = null;
		currentGrabPart = null;
		AudioManager.S.StopSFX();
		Cursor.visible = true;
	}

	private void TearDownControl()
	{
		if (input.Player.MouseLeftClick.WasPressedThisFrame())
		{
			TryPickObject();
		}
		if (currentGrabPart != null)
		{
			DragObject();
			if (input.Player.MouseLeftClick.WasReleasedThisFrame())
			{
				DropObject();
			}
		}
	}

	private void TryPickObject()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 3f, mask) && hitInfo.collider.gameObject != detailedDevice.baseShell)
		{
			currentGrabPart = hitInfo.collider.gameObject;
			currentGrabPart.GetComponent<Collider>().enabled = false;
			posTemp = originPosMap[currentGrabPart];
			rotationTemp = originRotMap[currentGrabPart];
			Debug.Log(currentCoverShellIndex);
			if (currentGrabPart.GetComponent<Outline>().enabled)
			{
				currentGrabPart.GetComponent<Outline>().enabled = false;
				currentCoverShellIndex++;
			}
			currentGrabPartRb = currentGrabPart.GetComponent<Rigidbody>();
			if (currentGrabPartRb != null)
			{
				currentGrabPartRb.isKinematic = true;
			}
			AudioManager.S.PlaySFX(AudioManager.S.uiToggle);
			Cursor.visible = false;
		}
	}

	private void DragObject()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (!Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f))
		{
			return;
		}
		int layer = hitInfo.collider.gameObject.layer;
		if (hitInfo.collider.gameObject == detailedDevice.baseShell)
		{
			if (Array.IndexOf(detailedDevice.coverShell, currentGrabPart) == currentCoverShellIndex - 1)
			{
				currentGrabPart.transform.parent = device.transform;
				currentGrabPart.transform.localPosition = Vector3.Lerp(currentGrabPart.transform.localPosition, posTemp, Time.deltaTime * 10f);
				currentGrabPart.transform.localRotation = Quaternion.Lerp(currentGrabPart.transform.localRotation, rotationTemp, Time.deltaTime * 10f);
			}
			else
			{
				currentGrabPart.transform.parent = null;
				targetPos = new Vector3(hitInfo.point.x, table.mount.transform.position.y, hitInfo.point.z);
				currentGrabPart.transform.position = Vector3.Lerp(currentGrabPart.transform.position, targetPos, Time.deltaTime * 5f);
			}
		}
		else if (1 << layer != 0)
		{
			currentGrabPart.transform.parent = null;
			targetPos = new Vector3(hitInfo.point.x, table.mount.transform.position.y, hitInfo.point.z);
			currentGrabPart.transform.position = Vector3.Lerp(currentGrabPart.transform.position, targetPos, Time.deltaTime * 5f);
		}
	}

	private void DropObject()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		if (Physics.Raycast(Camera.main.ScreenPointToRay(vector), out var hitInfo, 2f))
		{
			if (hitInfo.collider.gameObject != detailedDevice.baseShell)
			{
				if (currentGrabPartRb != null)
				{
					currentGrabPartRb.isKinematic = false;
					currentGrabPartRb = null;
				}
				currentGrabPart.transform.parent = null;
				if (detailedDevice.coverShell.Length > currentCoverShellIndex)
				{
					detailedDevice.coverShell[currentCoverShellIndex].GetComponent<Outline>().enabled = true;
					detailedDevice.coverShell[currentCoverShellIndex].GetComponent<Collider>().enabled = true;
				}
				else
				{
					detailedDevice.pcb.GetComponent<Outline>().enabled = true;
				}
			}
			else if (Array.IndexOf(detailedDevice.coverShell, currentGrabPart) == currentCoverShellIndex - 1)
			{
				if (currentCoverShellIndex > 0)
				{
					if (detailedDevice.coverShell.Length > currentCoverShellIndex)
					{
						detailedDevice.coverShell[currentCoverShellIndex].GetComponent<Outline>().enabled = false;
						detailedDevice.coverShell[currentCoverShellIndex].GetComponent<Collider>().enabled = false;
					}
					else
					{
						detailedDevice.pcb.GetComponent<Outline>().enabled = false;
					}
					currentCoverShellIndex--;
				}
				currentGrabPart.GetComponent<Outline>().enabled = true;
			}
			else
			{
				if (currentGrabPartRb != null)
				{
					currentGrabPartRb.isKinematic = false;
					currentGrabPartRb = null;
				}
				currentGrabPart.transform.parent = null;
				if (detailedDevice.coverShell.Length > currentCoverShellIndex)
				{
					detailedDevice.coverShell[currentCoverShellIndex].GetComponent<Outline>().enabled = true;
					detailedDevice.coverShell[currentCoverShellIndex].GetComponent<Collider>().enabled = true;
				}
				else
				{
					detailedDevice.pcb.GetComponent<Outline>().enabled = true;
				}
			}
		}
		else
		{
			if (currentGrabPartRb != null)
			{
				currentGrabPartRb.isKinematic = false;
				currentGrabPartRb = null;
			}
			currentGrabPart.transform.parent = null;
			if (detailedDevice.coverShell.Length > currentCoverShellIndex)
			{
				detailedDevice.coverShell[currentCoverShellIndex].GetComponent<Outline>().enabled = true;
			}
			else
			{
				detailedDevice.pcb.GetComponent<Outline>().enabled = true;
			}
		}
		currentGrabPart.GetComponent<Collider>().enabled = true;
		currentGrabPart = null;
		Cursor.visible = true;
	}
}

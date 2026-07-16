using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseCursor : MonoBehaviour
{
	private Image image;

	[SerializeField]
	private Sprite mouseSprite;

	[SerializeField]
	private Sprite crosshairSprite;

	[SerializeField]
	private Sprite reloadingSprite;

	[SerializeField]
	private Sprite outOfAmmoSprite;

	private bool isCannonReloading;

	private bool isAiming;

	private bool isCannonOutOfAmmo;

	public static MouseCursor Instance;

	private bool cursorBlocked;

	public bool IsVisible { get; private set; } = true;

	private void Awake()
	{
		Instance = this;
		image = GetComponent<Image>();
	}

	private void Start()
	{
		InputManager.Instance.OnDeviceChanged += delegate(int _, ControllerType isGamepad)
		{
			DeviceChangedHandler(isGamepad);
		};
		PlayerManager.Instance.OnCoopStarted += HandleCoopStarted;
	}

	private void Update()
	{
		Vector2 mousePos = GetMousePos();
		base.transform.position = mousePos;
		if (Time.timeScale != 0f)
		{
			Cursor.lockState = CursorLockMode.Confined;
		}
		else
		{
			Cursor.lockState = CursorLockMode.None;
		}
		if (Mouse.current.delta.magnitude > 0.1f && !cursorBlocked)
		{
			ShowCursor();
		}
		Cursor.visible = mousePos.x < 0f || mousePos.x > (float)Screen.width || mousePos.y < 0f || mousePos.y > (float)Screen.height;
	}

	public Vector2 GetMousePos()
	{
		return Mouse.current.position.ReadValue();
	}

	public void SetMousePos(Vector2 newMousePos)
	{
		Mouse.current.WarpCursorPosition(newMousePos);
	}

	private void DeviceChangedHandler(ControllerType controllerType)
	{
		if (controllerType == ControllerType.GamepadXBox || controllerType == ControllerType.GamepadPS4 || controllerType == ControllerType.GamepadPS5)
		{
			HideCursor();
		}
		else
		{
			ShowCursor();
		}
	}

	public void ShowCursor(bool unblockCursor = true)
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		image.enabled = true;
		IsVisible = true;
		cursorBlocked = !unblockCursor;
	}

	public void HideCursor(bool blockCursor = false)
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		image.enabled = false;
		IsVisible = false;
		cursorBlocked = blockCursor;
	}

	private void HandleCoopStarted(PlayerController controller)
	{
		ShowCursor();
	}

	public void SetCursorAiming(bool isAiming)
	{
		this.isAiming = isAiming;
		if (isAiming)
		{
			if (isCannonReloading)
			{
				image.sprite = reloadingSprite;
			}
			else if (isCannonOutOfAmmo)
			{
				image.sprite = outOfAmmoSprite;
			}
			else
			{
				image.sprite = crosshairSprite;
			}
		}
		else
		{
			image.sprite = mouseSprite;
		}
	}

	public void CannonReloadStart()
	{
		isCannonReloading = true;
		SetCursorAiming(isAiming);
	}

	public void CannonReloadEnd()
	{
		isCannonReloading = false;
		SetCursorAiming(isAiming);
	}

	public void CannonOutOfAmmo()
	{
		isCannonOutOfAmmo = true;
		SetCursorAiming(isAiming);
	}

	public void CannonHasAmmo()
	{
		isCannonOutOfAmmo = false;
		SetCursorAiming(isAiming);
	}
}

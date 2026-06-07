using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : Controller
{
	public delegate void OnSpawnHUD(HUD hud);

	public enum EInputControlScheme
	{
		None = 0,
		KeyboardMouse = 1,
		Gamepad = 2
	}

	public Action<EInputControlScheme> onControlChanged;

	[SerializeField]
	protected PlayerCamera playerCamera;

	private PlayerInput playerInput;

	[SerializeField]
	private HUD HUD;

	private HUD currentHUD;

	[SerializeField]
	private EventSystem eventSystem;

	private EventSystem currentEventSystem;

	public virtual HUD CurrentHUD => currentHUD;

	public PlayerCamera PlayerCamera
	{
		get
		{
			return playerCamera;
		}
		protected set
		{
			playerCamera = value;
		}
	}

	public PlayerInput PlayerInput
	{
		get
		{
			if (!playerInput)
			{
				playerInput = GetComponent<PlayerInput>();
			}
			return playerInput;
		}
		private set
		{
			playerInput = value;
		}
	}

	public event OnSpawnHUD onSpawnHUD;

	protected override void Awake()
	{
		base.Awake();
		PlayerInput = GetComponent<PlayerInput>();
	}

	protected override void Start()
	{
		base.Start();
		SpawnCamera();
		ActivateEventSystem();
		ShowHUD();
	}

	public EInputControlScheme GetCurrentInputControlScheme()
	{
		if (PlayerInput == null)
		{
			return EInputControlScheme.None;
		}
		string currentControlScheme = PlayerInput.currentControlScheme;
		if (!(currentControlScheme == "Keyboard&Mouse"))
		{
			if (currentControlScheme == "Gamepad")
			{
				return EInputControlScheme.Gamepad;
			}
			return EInputControlScheme.None;
		}
		return EInputControlScheme.KeyboardMouse;
	}

	protected virtual void SpawnCamera()
	{
		if ((bool)PlayerCamera)
		{
			PlayerCamera = UnityEngine.Object.Instantiate(PlayerCamera.gameObject).GetComponent<PlayerCamera>();
			PlayerCamera.Target = base.ControlledCharacter.gameObject;
		}
	}

	private void ShowHUD(bool show = true)
	{
		if ((bool)HUD && !CurrentHUD)
		{
			currentHUD = UnityEngine.Object.Instantiate(HUD.gameObject).GetComponent<HUD>();
			currentHUD.PlayerController = this;
			this.onSpawnHUD?.Invoke(currentHUD);
		}
		if ((bool)currentHUD)
		{
			currentHUD.gameObject.SetActive(show);
		}
	}

	private void ActivateEventSystem(bool activate = true)
	{
		if (activate && (bool)eventSystem && !currentEventSystem)
		{
			currentEventSystem = UnityEngine.Object.Instantiate(eventSystem.gameObject).GetComponent<EventSystem>();
		}
		else if (!activate && (bool)currentEventSystem)
		{
			UnityEngine.Object.Destroy(currentEventSystem.gameObject);
		}
	}

	public void OnControlsChanged(PlayerInput pInput)
	{
		onControlChanged?.Invoke(GetCurrentInputControlScheme());
		if (GetCurrentInputControlScheme() == EInputControlScheme.KeyboardMouse)
		{
			Cursor.visible = true;
		}
		else if (GetCurrentInputControlScheme() == EInputControlScheme.Gamepad)
		{
			Cursor.visible = false;
		}
	}
}

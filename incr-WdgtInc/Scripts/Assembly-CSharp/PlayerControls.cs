using System.Collections;
using Assets.Behaviour.UI.Construction;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
	public static bool RightClickUtilized;

	private static PlayerControls _instance;

	private GameControls _controls;

	private GameControls _menuControls;

	public static bool Enabled
	{
		get
		{
			if ((bool)_instance)
			{
				return _instance.gameObject.activeSelf;
			}
			return false;
		}
	}

	public static Vector2 MousePosition { get; private set; }

	public static Vector2 MouseWorld { get; private set; }

	public static float MouseScroll => Mouse.current.scroll.y.value;

	public static Vector2 TraversalDelta => _instance._controls.Default.TraverseMap.ReadValue<Vector2>();

	public static Vector2 MouseControllerDelta => _instance._controls.Default.TraverseMouse.ReadValue<Vector2>();

	public static Vector2 MenuDelta => _instance._menuControls.Default.TraverseMap.ReadValue<Vector2>();

	public static bool InteractPressed => _instance._controls.Default.Interact.WasPressedThisFrame();

	public static bool InteractRelease => _instance._controls.Default.Interact.WasReleasedThisFrame();

	public static bool InputCancel
	{
		get
		{
			bool triggered = _instance._controls.Default.Cancel.triggered;
			if (triggered)
			{
				RightClickUtilized = true;
			}
			return triggered;
		}
	}

	public static bool ModifierShift => Keyboard.current.shiftKey.isPressed;

	public static bool ModifierControl => Keyboard.current.ctrlKey.isPressed;

	public static bool ModifierAlt => Keyboard.current.altKey.isPressed;

	public static bool Escape => Keyboard.current.escapeKey.wasPressedThisFrame;

	public static bool Return => Keyboard.current.enterKey.wasPressedThisFrame;

	public static bool HasInput
	{
		get
		{
			if (!Keyboard.current.anyKey.wasPressedThisFrame && !Mouse.current.leftButton.wasPressedThisFrame)
			{
				return Mouse.current.rightButton.wasPressedThisFrame;
			}
			return true;
		}
	}

	private void Awake()
	{
		_instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
		_menuControls = new GameControls();
		_menuControls.Enable();
		_controls = new GameControls();
		_controls.Default.ToggleBuild.performed += ToggleBuild;
		_controls.Default.ToggleMap.performed += ToggleMap;
		_controls.Default.ToggleInventory.performed += ToggleInventory;
		_controls.Default.ToggleTech.performed += ToggleTech;
		_controls.Default.ToggleConstruction.performed += ToggleConstruction;
		_controls.Default.ToggleUI.performed += ToggleUI;
		_controls.Default.Escape.performed += ProcessEscape;
		_controls.Default.Cancel.performed += ProcessCancel;
		_controls.Default.TogglePicker.performed += ProcessPicker;
		_controls.Default.Ability1.performed += Ability1;
		_controls.Default.Ability2.performed += Ability2;
		_controls.Default.Ability3.performed += Ability3;
		_controls.Default.Ability4.performed += Ability4;
	}

	private void Update()
	{
		MousePosition = Mouse.current.position.value;
		MouseWorld = Camera.main.ScreenToWorldPoint(MousePosition);
	}

	private void OnEnable()
	{
		_controls.Enable();
	}

	private void OnDisable()
	{
		_controls.Disable();
	}

	private void ToggleBuild(InputAction.CallbackContext obj)
	{
		OverviewUI.Instance.ToggleBuildMenu();
	}

	private void ToggleMap(InputAction.CallbackContext obj)
	{
		GameUI.Instance.ToggleFullScreenUI(OverviewUI.Instance);
	}

	private void ToggleInventory(InputAction.CallbackContext obj)
	{
		GameUI.Instance.ToggleInventory();
	}

	private void ToggleTech(InputAction.CallbackContext obj)
	{
		GameUI.Instance.ToggleFullScreenUI(TechTreeUI.Instance);
	}

	private void ToggleConstruction(InputAction.CallbackContext obj)
	{
		GameUI.Instance.ToggleConstructionWindow();
	}

	private void ToggleUI(InputAction.CallbackContext obj)
	{
		GameUI.Instance.ToggleHideUI();
	}

	private void ProcessEscape(InputAction.CallbackContext obj)
	{
		GameUI.Instance.ProcessEscape();
	}

	private void ProcessCancel(InputAction.CallbackContext obj)
	{
		StartCoroutine(_processCancelCoroutine());
	}

	private void ProcessPicker(InputAction.CallbackContext obj)
	{
		if ((bool)OverviewUI.Instance)
		{
			OverviewUI.Instance.TogglePicker();
		}
	}

	private void DoAbility(int ability)
	{
		if ((bool)GameUI.Instance)
		{
			GameUI.Instance.SelectAbility(ability);
		}
	}

	private void Ability1(InputAction.CallbackContext obj)
	{
		DoAbility(1);
	}

	private void Ability2(InputAction.CallbackContext obj)
	{
		DoAbility(2);
	}

	private void Ability3(InputAction.CallbackContext obj)
	{
		DoAbility(3);
	}

	private void Ability4(InputAction.CallbackContext obj)
	{
		DoAbility(4);
	}

	private IEnumerator _processCancelCoroutine()
	{
		yield return null;
		if (!RightClickUtilized)
		{
			GameUI.Instance.ProcessCancel();
		}
		RightClickUtilized = false;
	}

	public static void Enable()
	{
		if ((bool)_instance)
		{
			_instance.gameObject.SetActive(value: true);
		}
	}

	public static void Disable()
	{
		if ((bool)_instance)
		{
			_instance.gameObject.SetActive(value: false);
		}
	}

	public static void Init()
	{
		if (!_instance)
		{
			new GameObject("Player Controls").AddComponent<PlayerControls>();
		}
	}

	public static bool CanWASDMove()
	{
		if (!GameUI.Inventory.isActiveAndEnabled)
		{
			ConstructionUI instance = ConstructionUI.Instance;
			if ((object)instance == null || !instance.isActiveAndEnabled)
			{
				return !OverviewUI.Instance.BuildMenuActive;
			}
		}
		return false;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Dorfromantik;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputManager : Singleton<InputManager>
{
	private sealed class _003CResetMovedDistanceAtEndOfFrame_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InputManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CResetMovedDistanceAtEndOfFrame_003Ed__41(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			InputManager inputManager = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				inputManager.movedCameraDistance = 0f;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class _003CResetRotatedDistanceAtEndOfFrame_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public InputManager _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CResetRotatedDistanceAtEndOfFrame_003Ed__43(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			InputManager inputManager = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				inputManager.rotatedCameraDistance = 0f;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	public GamepadInputType gamepadInputType;

	[SerializeField]
	private float mouseMoveThreshold = 0.1f;

	[SerializeField]
	private float mouseRotationThreshold = 3f;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private InputActionReference pointerPosAction;

	[SerializeField]
	private EventSystem menuEventSystem;

	private Dorfromantik.InputDevice _003CCurrentInputDevice_003Ek__BackingField;

	private string _003CCurrentControlScheme_003Ek__BackingField;

	private PlayerInput playerInput;

	private float movedCameraDistance;

	private float rotatedCameraDistance;

	private Vector2 currentPointerPos;

	private Vector2 lastFramePointerPos;

	private Dictionary<string, Dorfromantik.InputDevice> inputDeviceByControlScheme = new Dictionary<string, Dorfromantik.InputDevice>
	{
		{
			"Mouse & Keyboard",
			Dorfromantik.InputDevice.MouseKeyboard
		},
		{
			"Gamepad",
			Dorfromantik.InputDevice.Gamepad
		},
		{
			"Nintendo Switch",
			Dorfromantik.InputDevice.NintendoSwitch
		},
		{
			"Switch Pro Controller",
			Dorfromantik.InputDevice.NintendoSwitch
		}
	};

	private Dorfromantik.InputDevice debug_overrideInputDevice;

	public Dorfromantik.InputDevice CurrentInputDevice
	{
		get
		{
			return _003CCurrentInputDevice_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentInputDevice_003Ek__BackingField = value;
		}
	}

	public string CurrentControlScheme
	{
		get
		{
			return _003CCurrentControlScheme_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentControlScheme_003Ek__BackingField = value;
		}
	}

	public bool TilePlacementAllowed => movedCameraDistance <= mouseMoveThreshold;

	public bool TileRotationAllowed => rotatedCameraDistance <= mouseRotationThreshold;

	public event Action<GamepadInputType> OnGamepadInputTypeChanged;

	public event Action<Dorfromantik.InputDevice> OnInputDeviceChanged;

	protected override void Awake()
	{
		base.Awake();
		playerInput = GetComponent<PlayerInput>();
		playerInput.onControlsChanged += ChangeInputType;
		inputRouter.OnInputStateChanged += ChangeInputState;
		ChangeInputType(playerInput);
	}

	private void Start()
	{
		sceneLoader.OnSceneLoaded += UpdateInputCameraReference;
		UpdateInputCameraReference(default(Scene));
	}

	private void ChangeInputType(PlayerInput playerInput)
	{
		if (debug_overrideInputDevice != Dorfromantik.InputDevice.Undefined)
		{
			CurrentInputDevice = debug_overrideInputDevice;
			this.OnInputDeviceChanged?.Invoke(CurrentInputDevice);
		}
		else if (inputDeviceByControlScheme.ContainsKey(playerInput.currentControlScheme))
		{
			CurrentInputDevice = inputDeviceByControlScheme[playerInput.currentControlScheme];
			CurrentControlScheme = playerInput.currentControlScheme;
			Cursor.visible = CurrentInputDevice == Dorfromantik.InputDevice.MouseKeyboard;
			Cursor.lockState = ((CurrentInputDevice != Dorfromantik.InputDevice.MouseKeyboard) ? CursorLockMode.Locked : CursorLockMode.None);
			this.OnInputDeviceChanged?.Invoke(CurrentInputDevice);
		}
		else
		{
			Debug.Log("No InputDevice defined for controlScheme " + playerInput.currentControlScheme);
		}
	}

	private void UpdateInputCameraReference(Scene obj)
	{
		if (!(playerInput == null) && (bool)OverwritingSingleton<IngameUi>.Instance)
		{
			playerInput.camera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		}
	}

	private void ChangeInputState(GameState newInputState)
	{
	}

	public void ChangeGamepadInputMethod()
	{
		gamepadInputType = gamepadInputType switch
		{
			GamepadInputType.SearchCone => GamepadInputType.CrossHairs, 
			GamepadInputType.CrossHairs => GamepadInputType.SearchCone, 
			_ => gamepadInputType, 
		};
		this.OnGamepadInputTypeChanged?.Invoke(gamepadInputType);
	}

	public void AddMovedDistance(Vector2 moveDelta)
	{
		movedCameraDistance += moveDelta.magnitude;
	}

	public void AddRotatedDistance(Vector2 delta)
	{
		rotatedCameraDistance += Mathf.Abs(delta.x);
	}

	public void ResetMovedDistance()
	{
		StartCoroutine(ResetMovedDistanceAtEndOfFrame());
	}

	private IEnumerator ResetMovedDistanceAtEndOfFrame()
	{
		return new _003CResetMovedDistanceAtEndOfFrame_003Ed__41(0)
		{
			_003C_003E4__this = this
		};
	}

	public void ResetRotatedDistance()
	{
		StartCoroutine(ResetRotatedDistanceAtEndOfFrame());
	}

	private IEnumerator ResetRotatedDistanceAtEndOfFrame()
	{
		return new _003CResetRotatedDistanceAtEndOfFrame_003Ed__43(0)
		{
			_003C_003E4__this = this
		};
	}
}

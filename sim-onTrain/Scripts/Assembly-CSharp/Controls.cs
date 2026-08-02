using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PlayerActions
	{
		private Controls m_Wrapper;

		public InputAction Jump => m_Wrapper.m_Player_Jump;

		public InputAction Move => m_Wrapper.m_Player_Move;

		public InputAction Look => m_Wrapper.m_Player_Look;

		public InputAction Sprint => m_Wrapper.m_Player_Sprint;

		public InputAction ToggleWalk => m_Wrapper.m_Player_ToggleWalk;

		public InputAction Aim => m_Wrapper.m_Player_Aim;

		public InputAction Crouch => m_Wrapper.m_Player_Crouch;

		public InputAction LockOn => m_Wrapper.m_Player_LockOn;

		public bool enabled => Get().enabled;

		public PlayerActions(Controls wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Player;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(PlayerActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IPlayerActions instance)
		{
			if (instance != null && !m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
				Jump.started += instance.OnJump;
				Jump.performed += instance.OnJump;
				Jump.canceled += instance.OnJump;
				Move.started += instance.OnMove;
				Move.performed += instance.OnMove;
				Move.canceled += instance.OnMove;
				Look.started += instance.OnLook;
				Look.performed += instance.OnLook;
				Look.canceled += instance.OnLook;
				Sprint.started += instance.OnSprint;
				Sprint.performed += instance.OnSprint;
				Sprint.canceled += instance.OnSprint;
				ToggleWalk.started += instance.OnToggleWalk;
				ToggleWalk.performed += instance.OnToggleWalk;
				ToggleWalk.canceled += instance.OnToggleWalk;
				Aim.started += instance.OnAim;
				Aim.performed += instance.OnAim;
				Aim.canceled += instance.OnAim;
				Crouch.started += instance.OnCrouch;
				Crouch.performed += instance.OnCrouch;
				Crouch.canceled += instance.OnCrouch;
				LockOn.started += instance.OnLockOn;
				LockOn.performed += instance.OnLockOn;
				LockOn.canceled += instance.OnLockOn;
			}
		}

		private void UnregisterCallbacks(IPlayerActions instance)
		{
			Jump.started -= instance.OnJump;
			Jump.performed -= instance.OnJump;
			Jump.canceled -= instance.OnJump;
			Move.started -= instance.OnMove;
			Move.performed -= instance.OnMove;
			Move.canceled -= instance.OnMove;
			Look.started -= instance.OnLook;
			Look.performed -= instance.OnLook;
			Look.canceled -= instance.OnLook;
			Sprint.started -= instance.OnSprint;
			Sprint.performed -= instance.OnSprint;
			Sprint.canceled -= instance.OnSprint;
			ToggleWalk.started -= instance.OnToggleWalk;
			ToggleWalk.performed -= instance.OnToggleWalk;
			ToggleWalk.canceled -= instance.OnToggleWalk;
			Aim.started -= instance.OnAim;
			Aim.performed -= instance.OnAim;
			Aim.canceled -= instance.OnAim;
			Crouch.started -= instance.OnCrouch;
			Crouch.performed -= instance.OnCrouch;
			Crouch.canceled -= instance.OnCrouch;
			LockOn.started -= instance.OnLockOn;
			LockOn.performed -= instance.OnLockOn;
			LockOn.canceled -= instance.OnLockOn;
		}

		public void RemoveCallbacks(IPlayerActions instance)
		{
			if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IPlayerActions instance)
		{
			foreach (IPlayerActions playerActionsCallbackInterface in m_Wrapper.m_PlayerActionsCallbackInterfaces)
			{
				UnregisterCallbacks(playerActionsCallbackInterface);
			}
			m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IPlayerActions
	{
		void OnJump(InputAction.CallbackContext context);

		void OnMove(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnSprint(InputAction.CallbackContext context);

		void OnToggleWalk(InputAction.CallbackContext context);

		void OnAim(InputAction.CallbackContext context);

		void OnCrouch(InputAction.CallbackContext context);

		void OnLockOn(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Player;

	private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();

	private readonly InputAction m_Player_Jump;

	private readonly InputAction m_Player_Move;

	private readonly InputAction m_Player_Look;

	private readonly InputAction m_Player_Sprint;

	private readonly InputAction m_Player_ToggleWalk;

	private readonly InputAction m_Player_Aim;

	private readonly InputAction m_Player_Crouch;

	private readonly InputAction m_Player_LockOn;

	private int m_KeyboardandMouseSchemeIndex = -1;

	private int m_GamepadSchemeIndex = -1;

	public InputActionAsset asset { get; }

	public InputBinding? bindingMask
	{
		get
		{
			return asset.bindingMask;
		}
		set
		{
			asset.bindingMask = value;
		}
	}

	public ReadOnlyArray<InputDevice>? devices
	{
		get
		{
			return asset.devices;
		}
		set
		{
			asset.devices = value;
		}
	}

	public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

	public IEnumerable<InputBinding> bindings => asset.bindings;

	public PlayerActions Player => new PlayerActions(this);

	public InputControlScheme KeyboardandMouseScheme
	{
		get
		{
			if (m_KeyboardandMouseSchemeIndex == -1)
			{
				m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
			}
			return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
		}
	}

	public InputControlScheme GamepadScheme
	{
		get
		{
			if (m_GamepadSchemeIndex == -1)
			{
				m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
			}
			return asset.controlSchemes[m_GamepadSchemeIndex];
		}
	}

	public Controls()
	{
		asset = InputActionAsset.FromJson("{\r\n    \"name\": \"Controls\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Player\",\r\n            \"id\": \"2c49ff3e-ee54-41db-a904-9d6a34278604\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Jump\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"9c4baf7e-dd4a-45cb-b8b5-518f23ef2f3f\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Move\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"105f8ab6-711b-48c9-afe5-81516e9a23b4\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Look\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"c7314668-554f-4d3e-9860-066f89d79485\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Sprint\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8a1c0259-4ff4-47ce-8b18-87fa6457e43a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ToggleWalk\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"81a5840a-1451-4af7-b390-f2f1e3099eb9\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Aim\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"e440026d-b50a-4df1-ba03-48302673e522\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Crouch\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0a2dd0bc-e6ed-4515-b034-169169050ceb\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"LockOn\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"a87fb759-f0bc-4a42-9e92-7f6bdec29e48\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4973493d-c628-41b1-8283-30a38a35726a\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Jump\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"42025cc3-3d37-4b12-a885-8eca8f556f97\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Jump\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1ab14112-e754-49ce-9d7a-515a9ab24396\",\r\n                    \"path\": \"<Gamepad>/leftStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"2D Vector WASD\",\r\n                    \"id\": \"d68d1f5f-0e48-4c97-943a-5200d814ba4c\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"4601556f-fe76-459e-833c-8424f28ccfaf\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"0758e0d3-c53f-4406-b0c5-6b65928f6495\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"34ab6656-510b-4543-a02c-457d9d87d373\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"861a3c64-a95a-4fb2-90f1-2f7fc3994ebd\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"2D Vector Arrowkeys\",\r\n                    \"id\": \"cd992d5a-4846-4403-aad0-3c9049a191e5\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"35439dc7-4c62-4730-a600-57bd079992aa\",\r\n                    \"path\": \"<Keyboard>/upArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"8a40e7f9-06f6-4fea-82c8-a9bbfa9f3a45\",\r\n                    \"path\": \"<Keyboard>/downArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"a529365f-0079-4cdd-ad19-c2176ebc12a7\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"032d5647-9197-4ab1-b0ed-73f9c573abaa\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fd44343a-ca07-4f0a-95d7-29164ac381f0\",\r\n                    \"path\": \"<Mouse>/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Look\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8a2bfa46-4ead-4a8f-aac0-c0bc4f585928\",\r\n                    \"path\": \"<Gamepad>/rightStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"ScaleVector2(x=4,y=4)\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Look\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"354b4cd8-944c-4d23-87b4-d26e6403b2a7\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Sprint\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"13547036-1d58-45f2-a2d8-c9f0706a8fb9\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Sprint\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ab91ddfe-c482-4b55-aa59-bf1974a526b3\",\r\n                    \"path\": \"<Keyboard>/capsLock\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"ToggleWalk\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b5d9ab6f-92ae-4d6a-85ce-20210c1efe16\",\r\n                    \"path\": \"<Gamepad>/leftStickPress\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"ToggleWalk\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2d594f48-6585-4401-95f6-10f27afb0d84\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Aim\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9f00b84c-77a0-4264-88a7-aa6ace188e6e\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Aim\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"73eda66d-2118-4a22-9d70-18cc9ea08e74\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"Crouch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"78facee1-242d-43a5-b71f-75bfdb0ed6e1\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Crouch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9f68216e-e598-4037-a000-2ca8be91e0ba\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard and Mouse\",\r\n                    \"action\": \"LockOn\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bab278b9-2663-41cb-9167-ffb39759d9a9\",\r\n                    \"path\": \"<Gamepad>/rightStickPress\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"LockOn\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": [\r\n        {\r\n            \"name\": \"Keyboard and Mouse\",\r\n            \"bindingGroup\": \"Keyboard and Mouse\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Keyboard>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                },\r\n                {\r\n                    \"devicePath\": \"<Mouse>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Gamepad\",\r\n            \"bindingGroup\": \"Gamepad\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<DualShockGamepad>\",\r\n                    \"isOptional\": true,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        }\r\n    ]\r\n}");
		m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
		m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
		m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
		m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
		m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
		m_Player_ToggleWalk = m_Player.FindAction("ToggleWalk", throwIfNotFound: true);
		m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
		m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
		m_Player_LockOn = m_Player.FindAction("LockOn", throwIfNotFound: true);
	}

	public void Dispose()
	{
		UnityEngine.Object.Destroy(asset);
	}

	public bool Contains(InputAction action)
	{
		return asset.Contains(action);
	}

	public IEnumerator<InputAction> GetEnumerator()
	{
		return asset.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Enable()
	{
		asset.Enable();
	}

	public void Disable()
	{
		asset.Disable();
	}

	public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
	{
		return asset.FindAction(actionNameOrId, throwIfNotFound);
	}

	public int FindBinding(InputBinding bindingMask, out InputAction action)
	{
		return asset.FindBinding(bindingMask, out action);
	}
}

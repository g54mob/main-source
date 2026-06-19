using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class DefaultInput : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PlayerActions
	{
		private DefaultInput m_Wrapper;

		public InputAction Move => m_Wrapper.m_Player_Move;

		public InputAction Look => m_Wrapper.m_Player_Look;

		public InputAction Jump => m_Wrapper.m_Player_Jump;

		public InputAction Sprint => m_Wrapper.m_Player_Sprint;

		public InputAction Inventory => m_Wrapper.m_Player_Inventory;

		public InputAction Interact => m_Wrapper.m_Player_Interact;

		public InputAction Drop => m_Wrapper.m_Player_Drop;

		public InputAction Use => m_Wrapper.m_Player_Use;

		public InputAction Zoom => m_Wrapper.m_Player_Zoom;

		public InputAction Rotate => m_Wrapper.m_Player_Rotate;

		public InputAction Pause => m_Wrapper.m_Player_Pause;

		public InputAction Mount => m_Wrapper.m_Player_Mount;

		public InputAction RotateHolder => m_Wrapper.m_Player_RotateHolder;

		public InputAction HideHud => m_Wrapper.m_Player_HideHud;

		public InputAction Push => m_Wrapper.m_Player_Push;

		public InputAction Crouch => m_Wrapper.m_Player_Crouch;

		public bool enabled => Get().enabled;

		public PlayerActions(DefaultInput wrapper)
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
				Move.started += instance.OnMove;
				Move.performed += instance.OnMove;
				Move.canceled += instance.OnMove;
				Look.started += instance.OnLook;
				Look.performed += instance.OnLook;
				Look.canceled += instance.OnLook;
				Jump.started += instance.OnJump;
				Jump.performed += instance.OnJump;
				Jump.canceled += instance.OnJump;
				Sprint.started += instance.OnSprint;
				Sprint.performed += instance.OnSprint;
				Sprint.canceled += instance.OnSprint;
				Inventory.started += instance.OnInventory;
				Inventory.performed += instance.OnInventory;
				Inventory.canceled += instance.OnInventory;
				Interact.started += instance.OnInteract;
				Interact.performed += instance.OnInteract;
				Interact.canceled += instance.OnInteract;
				Drop.started += instance.OnDrop;
				Drop.performed += instance.OnDrop;
				Drop.canceled += instance.OnDrop;
				Use.started += instance.OnUse;
				Use.performed += instance.OnUse;
				Use.canceled += instance.OnUse;
				Zoom.started += instance.OnZoom;
				Zoom.performed += instance.OnZoom;
				Zoom.canceled += instance.OnZoom;
				Rotate.started += instance.OnRotate;
				Rotate.performed += instance.OnRotate;
				Rotate.canceled += instance.OnRotate;
				Pause.started += instance.OnPause;
				Pause.performed += instance.OnPause;
				Pause.canceled += instance.OnPause;
				Mount.started += instance.OnMount;
				Mount.performed += instance.OnMount;
				Mount.canceled += instance.OnMount;
				RotateHolder.started += instance.OnRotateHolder;
				RotateHolder.performed += instance.OnRotateHolder;
				RotateHolder.canceled += instance.OnRotateHolder;
				HideHud.started += instance.OnHideHud;
				HideHud.performed += instance.OnHideHud;
				HideHud.canceled += instance.OnHideHud;
				Push.started += instance.OnPush;
				Push.performed += instance.OnPush;
				Push.canceled += instance.OnPush;
				Crouch.started += instance.OnCrouch;
				Crouch.performed += instance.OnCrouch;
				Crouch.canceled += instance.OnCrouch;
			}
		}

		private void UnregisterCallbacks(IPlayerActions instance)
		{
			Move.started -= instance.OnMove;
			Move.performed -= instance.OnMove;
			Move.canceled -= instance.OnMove;
			Look.started -= instance.OnLook;
			Look.performed -= instance.OnLook;
			Look.canceled -= instance.OnLook;
			Jump.started -= instance.OnJump;
			Jump.performed -= instance.OnJump;
			Jump.canceled -= instance.OnJump;
			Sprint.started -= instance.OnSprint;
			Sprint.performed -= instance.OnSprint;
			Sprint.canceled -= instance.OnSprint;
			Inventory.started -= instance.OnInventory;
			Inventory.performed -= instance.OnInventory;
			Inventory.canceled -= instance.OnInventory;
			Interact.started -= instance.OnInteract;
			Interact.performed -= instance.OnInteract;
			Interact.canceled -= instance.OnInteract;
			Drop.started -= instance.OnDrop;
			Drop.performed -= instance.OnDrop;
			Drop.canceled -= instance.OnDrop;
			Use.started -= instance.OnUse;
			Use.performed -= instance.OnUse;
			Use.canceled -= instance.OnUse;
			Zoom.started -= instance.OnZoom;
			Zoom.performed -= instance.OnZoom;
			Zoom.canceled -= instance.OnZoom;
			Rotate.started -= instance.OnRotate;
			Rotate.performed -= instance.OnRotate;
			Rotate.canceled -= instance.OnRotate;
			Pause.started -= instance.OnPause;
			Pause.performed -= instance.OnPause;
			Pause.canceled -= instance.OnPause;
			Mount.started -= instance.OnMount;
			Mount.performed -= instance.OnMount;
			Mount.canceled -= instance.OnMount;
			RotateHolder.started -= instance.OnRotateHolder;
			RotateHolder.performed -= instance.OnRotateHolder;
			RotateHolder.canceled -= instance.OnRotateHolder;
			HideHud.started -= instance.OnHideHud;
			HideHud.performed -= instance.OnHideHud;
			HideHud.canceled -= instance.OnHideHud;
			Push.started -= instance.OnPush;
			Push.performed -= instance.OnPush;
			Push.canceled -= instance.OnPush;
			Crouch.started -= instance.OnCrouch;
			Crouch.performed -= instance.OnCrouch;
			Crouch.canceled -= instance.OnCrouch;
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

	public struct InventoryActions
	{
		private DefaultInput m_Wrapper;

		public InputAction Use => m_Wrapper.m_Inventory_Use;

		public InputAction Look => m_Wrapper.m_Inventory_Look;

		public InputAction Interact => m_Wrapper.m_Inventory_Interact;

		public bool enabled => Get().enabled;

		public InventoryActions(DefaultInput wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Inventory;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(InventoryActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IInventoryActions instance)
		{
			if (instance != null && !m_Wrapper.m_InventoryActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_InventoryActionsCallbackInterfaces.Add(instance);
				Use.started += instance.OnUse;
				Use.performed += instance.OnUse;
				Use.canceled += instance.OnUse;
				Look.started += instance.OnLook;
				Look.performed += instance.OnLook;
				Look.canceled += instance.OnLook;
				Interact.started += instance.OnInteract;
				Interact.performed += instance.OnInteract;
				Interact.canceled += instance.OnInteract;
			}
		}

		private void UnregisterCallbacks(IInventoryActions instance)
		{
			Use.started -= instance.OnUse;
			Use.performed -= instance.OnUse;
			Use.canceled -= instance.OnUse;
			Look.started -= instance.OnLook;
			Look.performed -= instance.OnLook;
			Look.canceled -= instance.OnLook;
			Interact.started -= instance.OnInteract;
			Interact.performed -= instance.OnInteract;
			Interact.canceled -= instance.OnInteract;
		}

		public void RemoveCallbacks(IInventoryActions instance)
		{
			if (m_Wrapper.m_InventoryActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IInventoryActions instance)
		{
			foreach (IInventoryActions inventoryActionsCallbackInterface in m_Wrapper.m_InventoryActionsCallbackInterfaces)
			{
				UnregisterCallbacks(inventoryActionsCallbackInterface);
			}
			m_Wrapper.m_InventoryActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IPlayerActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnJump(InputAction.CallbackContext context);

		void OnSprint(InputAction.CallbackContext context);

		void OnInventory(InputAction.CallbackContext context);

		void OnInteract(InputAction.CallbackContext context);

		void OnDrop(InputAction.CallbackContext context);

		void OnUse(InputAction.CallbackContext context);

		void OnZoom(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);

		void OnPause(InputAction.CallbackContext context);

		void OnMount(InputAction.CallbackContext context);

		void OnRotateHolder(InputAction.CallbackContext context);

		void OnHideHud(InputAction.CallbackContext context);

		void OnPush(InputAction.CallbackContext context);

		void OnCrouch(InputAction.CallbackContext context);
	}

	public interface IInventoryActions
	{
		void OnUse(InputAction.CallbackContext context);

		void OnLook(InputAction.CallbackContext context);

		void OnInteract(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Player;

	private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();

	private readonly InputAction m_Player_Move;

	private readonly InputAction m_Player_Look;

	private readonly InputAction m_Player_Jump;

	private readonly InputAction m_Player_Sprint;

	private readonly InputAction m_Player_Inventory;

	private readonly InputAction m_Player_Interact;

	private readonly InputAction m_Player_Drop;

	private readonly InputAction m_Player_Use;

	private readonly InputAction m_Player_Zoom;

	private readonly InputAction m_Player_Rotate;

	private readonly InputAction m_Player_Pause;

	private readonly InputAction m_Player_Mount;

	private readonly InputAction m_Player_RotateHolder;

	private readonly InputAction m_Player_HideHud;

	private readonly InputAction m_Player_Push;

	private readonly InputAction m_Player_Crouch;

	private readonly InputActionMap m_Inventory;

	private List<IInventoryActions> m_InventoryActionsCallbackInterfaces = new List<IInventoryActions>();

	private readonly InputAction m_Inventory_Use;

	private readonly InputAction m_Inventory_Look;

	private readonly InputAction m_Inventory_Interact;

	private int m_KeyboardMouseSchemeIndex = -1;

	private int m_GamepadSchemeIndex = -1;

	private int m_XboxControllerSchemeIndex = -1;

	private int m_PS4ControllerSchemeIndex = -1;

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

	public InventoryActions Inventory => new InventoryActions(this);

	public InputControlScheme KeyboardMouseScheme
	{
		get
		{
			if (m_KeyboardMouseSchemeIndex == -1)
			{
				m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
			}
			return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
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

	public InputControlScheme XboxControllerScheme
	{
		get
		{
			if (m_XboxControllerSchemeIndex == -1)
			{
				m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
			}
			return asset.controlSchemes[m_XboxControllerSchemeIndex];
		}
	}

	public InputControlScheme PS4ControllerScheme
	{
		get
		{
			if (m_PS4ControllerSchemeIndex == -1)
			{
				m_PS4ControllerSchemeIndex = asset.FindControlSchemeIndex("PS4 Controller");
			}
			return asset.controlSchemes[m_PS4ControllerSchemeIndex];
		}
	}

	public DefaultInput()
	{
		asset = InputActionAsset.FromJson("{\n    \"name\": \"StarterAssets\",\n    \"maps\": [\n        {\n            \"name\": \"Player\",\n            \"id\": \"f62a4b92-ef5e-4175-8f4c-c9075429d32c\",\n            \"actions\": [\n                {\n                    \"name\": \"Move\",\n                    \"type\": \"Value\",\n                    \"id\": \"6bc1aaf4-b110-4ff7-891e-5b9fe6f32c4d\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Look\",\n                    \"type\": \"Value\",\n                    \"id\": \"2690c379-f54d-45be-a724-414123833eb4\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Jump\",\n                    \"type\": \"Button\",\n                    \"id\": \"8c4abdf8-4099-493a-aa1a-129acec7c3df\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Sprint\",\n                    \"type\": \"Button\",\n                    \"id\": \"980e881e-182c-404c-8cbf-3d09fdb48fef\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Inventory\",\n                    \"type\": \"Button\",\n                    \"id\": \"fd50b105-a92b-4ec2-b6f4-a3abbbcc3fce\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Interact\",\n                    \"type\": \"Button\",\n                    \"id\": \"7f6e00fa-5a80-43cd-b346-65dc16627783\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Drop\",\n                    \"type\": \"Button\",\n                    \"id\": \"df764ccd-f06b-4368-98bb-3df4d8c77ebb\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Use\",\n                    \"type\": \"Button\",\n                    \"id\": \"400bd845-b517-4111-8637-2b75de4c8043\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Zoom\",\n                    \"type\": \"Button\",\n                    \"id\": \"94f0c916-2b3f-4a30-a262-2fdacaa90de4\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Rotate\",\n                    \"type\": \"Value\",\n                    \"id\": \"10a2b905-7965-4e44-b153-49413a87fb53\",\n                    \"expectedControlType\": \"Axis\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Pause\",\n                    \"type\": \"Button\",\n                    \"id\": \"99a57c11-b20f-498f-b448-934ff418075b\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Mount\",\n                    \"type\": \"Button\",\n                    \"id\": \"a3f80897-0b90-45e2-a898-f6b16ad89518\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"RotateHolder\",\n                    \"type\": \"Button\",\n                    \"id\": \"e72f6328-0adb-420d-9377-62a2413cab4b\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"HideHud\",\n                    \"type\": \"Button\",\n                    \"id\": \"7ce6cff7-1854-4472-a838-176b39deafc5\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Push\",\n                    \"type\": \"Button\",\n                    \"id\": \"fa223ca9-9593-49e3-b43e-0842a0909cb3\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Crouch\",\n                    \"type\": \"Button\",\n                    \"id\": \"bc932ba5-0227-4bbd-8892-e06143968ae0\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"WASD\",\n                    \"id\": \"b7594ddb-26c9-4ba2-bd5a-901468929edc\",\n                    \"path\": \"2DVector(mode=1)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Move\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"2063a8b5-6a45-43de-851b-65f3d46e7b58\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"64e4d037-32e1-4fb9-80e4-fc7330404dfe\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"0fce8b11-5eab-4e4e-a741-b732e7b20873\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"7bdda0d6-57a8-47c8-8238-8aecf3110e47\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"bb94b405-58d3-4998-8535-d705c1218a98\",\n                    \"path\": \"<Keyboard>/upArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"929d9071-7dd0-4368-9743-6793bb98087e\",\n                    \"path\": \"<Keyboard>/downArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"28abadba-06ff-4d37-bb70-af2f1e35a3b9\",\n                    \"path\": \"<Keyboard>/leftArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"45f115b6-9b4f-4ba8-b500-b94c93bf7d7e\",\n                    \"path\": \"<Keyboard>/rightArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e2f9aa65-db06-4c5b-a2e9-41bc8acb9517\",\n                    \"path\": \"<Gamepad>/leftStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"StickDeadzone\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Move\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ed66cbff-2900-4a62-8896-696503cfcd31\",\n                    \"path\": \"<Pointer>/delta\",\n                    \"interactions\": \"\",\n                    \"processors\": \"InvertVector2(invertX=false),ScaleVector2(x=0.05,y=0.05)\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Look\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d1d171b6-19d8-47a6-ba3a-71b6a8e7b3c0\",\n                    \"path\": \"<Gamepad>/rightStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"InvertVector2(invertX=false),StickDeadzone,ScaleVector2(x=300,y=300)\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Look\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1bd55a0b-761e-4ae4-89ae-8ec127e08a29\",\n                    \"path\": \"<Keyboard>/space\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"9f973413-5e27-4239-acee-38c4a63feeba\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Jump\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"dc65b89f-9bd3-43fb-92af-d0d87ba5faa4\",\n                    \"path\": \"<Keyboard>/leftShift\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Sprint\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c8fcd86e-dcfd-4f88-8e93-b638cdbf3320\",\n                    \"path\": \"<Gamepad>/leftTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Sprint\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b38f0e97-0869-4254-950f-5ae0a01c48b9\",\n                    \"path\": \"<Keyboard>/tab\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Inventory\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"db1d1d3f-9432-4c87-b0c5-2cb10eca6b5c\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Inventory\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4412eeb3-0549-49d1-aa40-08bf6ab263e2\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"70c56af1-381e-47d7-8eac-b453bf5a7fb8\",\n                    \"path\": \"<Mouse>/rightButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Drop\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"459717f3-c218-4295-909e-3944c6b74795\",\n                    \"path\": \"<Keyboard>/e\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Use\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"46b66de8-95cf-43bf-8de2-dc575b0d395a\",\n                    \"path\": \"<Keyboard>/z\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Zoom\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"1D Axis\",\n                    \"id\": \"42835226-67d2-4595-8f34-496db02e7d3f\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"b82ca59b-d3d4-495a-8054-ea168e779b9e\",\n                    \"path\": \"<Mouse>/scroll/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"cb84da51-807d-4e0c-b6ee-772380a9eb81\",\n                    \"path\": \"<Mouse>/scroll/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"5b1795a7-62e9-471a-a8d4-deee45314317\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Pause\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"973248e6-a632-47af-857e-6398c088ccd1\",\n                    \"path\": \"<Keyboard>/f\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Mount\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c91c864f-9bf0-4f8c-b20d-4987101f3118\",\n                    \"path\": \"<Keyboard>/r\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"RotateHolder\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"cb8b747a-606f-4cf3-b3f6-9ad5f2a5f333\",\n                    \"path\": \"<Keyboard>/f1\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"HideHud\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"fd47c574-33df-417a-a1cf-b91d923e1ced\",\n                    \"path\": \"<Keyboard>/j\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Push\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"f210c50a-9f96-4e61-8038-3735b73f08d4\",\n                    \"path\": \"<Keyboard>/ctrl\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Crouch\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Inventory\",\n            \"id\": \"44657e66-fcba-40f6-a076-50d06f61183f\",\n            \"actions\": [\n                {\n                    \"name\": \"Use\",\n                    \"type\": \"Button\",\n                    \"id\": \"ad044c66-dba3-44e5-ae3b-d6159deb060f\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Look\",\n                    \"type\": \"Value\",\n                    \"id\": \"8d488f24-540d-4d9c-a9b6-6baa1abef546\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Interact\",\n                    \"type\": \"Button\",\n                    \"id\": \"05d39d5a-dcc2-4ccb-801c-1e2bbef02f20\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"95dee48a-8de0-47c5-86f7-7ac4149e7362\",\n                    \"path\": \"<Keyboard>/e\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Use\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d24cfba4-171d-4d56-9a20-c7aa23e537c9\",\n                    \"path\": \"<Pointer>/delta\",\n                    \"interactions\": \"\",\n                    \"processors\": \"InvertVector2(invertX=false),ScaleVector2(x=0.05,y=0.05)\",\n                    \"groups\": \"KeyboardMouse\",\n                    \"action\": \"Look\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"bdb6b368-c27d-4ffe-965f-f2bf7bf9a62d\",\n                    \"path\": \"<Gamepad>/rightStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"InvertVector2(invertX=false),StickDeadzone,ScaleVector2(x=300,y=300)\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Look\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d0d4df31-9afc-4780-9b93-90b92181613d\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \";KeyboardMouse\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": [\n        {\n            \"name\": \"KeyboardMouse\",\n            \"bindingGroup\": \"KeyboardMouse\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Keyboard>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                },\n                {\n                    \"devicePath\": \"<Mouse>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Gamepad\",\n            \"bindingGroup\": \"Gamepad\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Gamepad>\",\n                    \"isOptional\": true,\n                    \"isOR\": false\n                },\n                {\n                    \"devicePath\": \"<XInputController>\",\n                    \"isOptional\": true,\n                    \"isOR\": false\n                },\n                {\n                    \"devicePath\": \"<DualShockGamepad>\",\n                    \"isOptional\": true,\n                    \"isOR\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Xbox Controller\",\n            \"bindingGroup\": \"Xbox Controller\",\n            \"devices\": []\n        },\n        {\n            \"name\": \"PS4 Controller\",\n            \"bindingGroup\": \"PS4 Controller\",\n            \"devices\": []\n        }\n    ]\n}");
		m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
		m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
		m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
		m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
		m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
		m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
		m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
		m_Player_Drop = m_Player.FindAction("Drop", throwIfNotFound: true);
		m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
		m_Player_Zoom = m_Player.FindAction("Zoom", throwIfNotFound: true);
		m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
		m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
		m_Player_Mount = m_Player.FindAction("Mount", throwIfNotFound: true);
		m_Player_RotateHolder = m_Player.FindAction("RotateHolder", throwIfNotFound: true);
		m_Player_HideHud = m_Player.FindAction("HideHud", throwIfNotFound: true);
		m_Player_Push = m_Player.FindAction("Push", throwIfNotFound: true);
		m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
		m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
		m_Inventory_Use = m_Inventory.FindAction("Use", throwIfNotFound: true);
		m_Inventory_Look = m_Inventory.FindAction("Look", throwIfNotFound: true);
		m_Inventory_Interact = m_Inventory.FindAction("Interact", throwIfNotFound: true);
	}

	~DefaultInput()
	{
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

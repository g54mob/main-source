using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class InputMap : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct CharacterActions
	{
		private InputMap m_Wrapper;

		public InputAction Movement => m_Wrapper.m_Character_Movement;

		public InputAction Running => m_Wrapper.m_Character_Running;

		public InputAction Interact => m_Wrapper.m_Character_Interact;

		public InputAction HoldInteraction => m_Wrapper.m_Character_HoldInteraction;

		public InputAction Action => m_Wrapper.m_Character_Action;

		public InputAction Place => m_Wrapper.m_Character_Place;

		public InputAction RotatePlaceable => m_Wrapper.m_Character_RotatePlaceable;

		public InputAction ToolbarHotkey => m_Wrapper.m_Character_ToolbarHotkey;

		public InputAction Rotate => m_Wrapper.m_Character_Rotate;

		public InputAction OpenCharacterMenu => m_Wrapper.m_Character_OpenCharacterMenu;

		public bool enabled => Get().enabled;

		public CharacterActions(InputMap wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Character;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(CharacterActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(ICharacterActions instance)
		{
			if (instance != null && !m_Wrapper.m_CharacterActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_CharacterActionsCallbackInterfaces.Add(instance);
				Movement.started += instance.OnMovement;
				Movement.performed += instance.OnMovement;
				Movement.canceled += instance.OnMovement;
				Running.started += instance.OnRunning;
				Running.performed += instance.OnRunning;
				Running.canceled += instance.OnRunning;
				Interact.started += instance.OnInteract;
				Interact.performed += instance.OnInteract;
				Interact.canceled += instance.OnInteract;
				HoldInteraction.started += instance.OnHoldInteraction;
				HoldInteraction.performed += instance.OnHoldInteraction;
				HoldInteraction.canceled += instance.OnHoldInteraction;
				Action.started += instance.OnAction;
				Action.performed += instance.OnAction;
				Action.canceled += instance.OnAction;
				Place.started += instance.OnPlace;
				Place.performed += instance.OnPlace;
				Place.canceled += instance.OnPlace;
				RotatePlaceable.started += instance.OnRotatePlaceable;
				RotatePlaceable.performed += instance.OnRotatePlaceable;
				RotatePlaceable.canceled += instance.OnRotatePlaceable;
				ToolbarHotkey.started += instance.OnToolbarHotkey;
				ToolbarHotkey.performed += instance.OnToolbarHotkey;
				ToolbarHotkey.canceled += instance.OnToolbarHotkey;
				Rotate.started += instance.OnRotate;
				Rotate.performed += instance.OnRotate;
				Rotate.canceled += instance.OnRotate;
				OpenCharacterMenu.started += instance.OnOpenCharacterMenu;
				OpenCharacterMenu.performed += instance.OnOpenCharacterMenu;
				OpenCharacterMenu.canceled += instance.OnOpenCharacterMenu;
			}
		}

		private void UnregisterCallbacks(ICharacterActions instance)
		{
			Movement.started -= instance.OnMovement;
			Movement.performed -= instance.OnMovement;
			Movement.canceled -= instance.OnMovement;
			Running.started -= instance.OnRunning;
			Running.performed -= instance.OnRunning;
			Running.canceled -= instance.OnRunning;
			Interact.started -= instance.OnInteract;
			Interact.performed -= instance.OnInteract;
			Interact.canceled -= instance.OnInteract;
			HoldInteraction.started -= instance.OnHoldInteraction;
			HoldInteraction.performed -= instance.OnHoldInteraction;
			HoldInteraction.canceled -= instance.OnHoldInteraction;
			Action.started -= instance.OnAction;
			Action.performed -= instance.OnAction;
			Action.canceled -= instance.OnAction;
			Place.started -= instance.OnPlace;
			Place.performed -= instance.OnPlace;
			Place.canceled -= instance.OnPlace;
			RotatePlaceable.started -= instance.OnRotatePlaceable;
			RotatePlaceable.performed -= instance.OnRotatePlaceable;
			RotatePlaceable.canceled -= instance.OnRotatePlaceable;
			ToolbarHotkey.started -= instance.OnToolbarHotkey;
			ToolbarHotkey.performed -= instance.OnToolbarHotkey;
			ToolbarHotkey.canceled -= instance.OnToolbarHotkey;
			Rotate.started -= instance.OnRotate;
			Rotate.performed -= instance.OnRotate;
			Rotate.canceled -= instance.OnRotate;
			OpenCharacterMenu.started -= instance.OnOpenCharacterMenu;
			OpenCharacterMenu.performed -= instance.OnOpenCharacterMenu;
			OpenCharacterMenu.canceled -= instance.OnOpenCharacterMenu;
		}

		public void RemoveCallbacks(ICharacterActions instance)
		{
			if (m_Wrapper.m_CharacterActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(ICharacterActions instance)
		{
			foreach (ICharacterActions characterActionsCallbackInterface in m_Wrapper.m_CharacterActionsCallbackInterfaces)
			{
				UnregisterCallbacks(characterActionsCallbackInterface);
			}
			m_Wrapper.m_CharacterActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct CameraActions
	{
		private InputMap m_Wrapper;

		public InputAction Turn => m_Wrapper.m_Camera_Turn;

		public InputAction MousePosition => m_Wrapper.m_Camera_MousePosition;

		public bool enabled => Get().enabled;

		public CameraActions(InputMap wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Camera;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(CameraActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(ICameraActions instance)
		{
			if (instance != null && !m_Wrapper.m_CameraActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_CameraActionsCallbackInterfaces.Add(instance);
				Turn.started += instance.OnTurn;
				Turn.performed += instance.OnTurn;
				Turn.canceled += instance.OnTurn;
				MousePosition.started += instance.OnMousePosition;
				MousePosition.performed += instance.OnMousePosition;
				MousePosition.canceled += instance.OnMousePosition;
			}
		}

		private void UnregisterCallbacks(ICameraActions instance)
		{
			Turn.started -= instance.OnTurn;
			Turn.performed -= instance.OnTurn;
			Turn.canceled -= instance.OnTurn;
			MousePosition.started -= instance.OnMousePosition;
			MousePosition.performed -= instance.OnMousePosition;
			MousePosition.canceled -= instance.OnMousePosition;
		}

		public void RemoveCallbacks(ICameraActions instance)
		{
			if (m_Wrapper.m_CameraActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(ICameraActions instance)
		{
			foreach (ICameraActions cameraActionsCallbackInterface in m_Wrapper.m_CameraActionsCallbackInterfaces)
			{
				UnregisterCallbacks(cameraActionsCallbackInterface);
			}
			m_Wrapper.m_CameraActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct MenuActions
	{
		private InputMap m_Wrapper;

		public InputAction Cancel => m_Wrapper.m_Menu_Cancel;

		public InputAction Settings => m_Wrapper.m_Menu_Settings;

		public InputAction DragAndDrop => m_Wrapper.m_Menu_DragAndDrop;

		public InputAction FPSToggle => m_Wrapper.m_Menu_FPSToggle;

		public bool enabled => Get().enabled;

		public MenuActions(InputMap wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Menu;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(MenuActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IMenuActions instance)
		{
			if (instance != null && !m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
				Cancel.started += instance.OnCancel;
				Cancel.performed += instance.OnCancel;
				Cancel.canceled += instance.OnCancel;
				Settings.started += instance.OnSettings;
				Settings.performed += instance.OnSettings;
				Settings.canceled += instance.OnSettings;
				DragAndDrop.started += instance.OnDragAndDrop;
				DragAndDrop.performed += instance.OnDragAndDrop;
				DragAndDrop.canceled += instance.OnDragAndDrop;
				FPSToggle.started += instance.OnFPSToggle;
				FPSToggle.performed += instance.OnFPSToggle;
				FPSToggle.canceled += instance.OnFPSToggle;
			}
		}

		private void UnregisterCallbacks(IMenuActions instance)
		{
			Cancel.started -= instance.OnCancel;
			Cancel.performed -= instance.OnCancel;
			Cancel.canceled -= instance.OnCancel;
			Settings.started -= instance.OnSettings;
			Settings.performed -= instance.OnSettings;
			Settings.canceled -= instance.OnSettings;
			DragAndDrop.started -= instance.OnDragAndDrop;
			DragAndDrop.performed -= instance.OnDragAndDrop;
			DragAndDrop.canceled -= instance.OnDragAndDrop;
			FPSToggle.started -= instance.OnFPSToggle;
			FPSToggle.performed -= instance.OnFPSToggle;
			FPSToggle.canceled -= instance.OnFPSToggle;
		}

		public void RemoveCallbacks(IMenuActions instance)
		{
			if (m_Wrapper.m_MenuActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IMenuActions instance)
		{
			foreach (IMenuActions menuActionsCallbackInterface in m_Wrapper.m_MenuActionsCallbackInterfaces)
			{
				UnregisterCallbacks(menuActionsCallbackInterface);
			}
			m_Wrapper.m_MenuActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface ICharacterActions
	{
		void OnMovement(InputAction.CallbackContext context);

		void OnRunning(InputAction.CallbackContext context);

		void OnInteract(InputAction.CallbackContext context);

		void OnHoldInteraction(InputAction.CallbackContext context);

		void OnAction(InputAction.CallbackContext context);

		void OnPlace(InputAction.CallbackContext context);

		void OnRotatePlaceable(InputAction.CallbackContext context);

		void OnToolbarHotkey(InputAction.CallbackContext context);

		void OnRotate(InputAction.CallbackContext context);

		void OnOpenCharacterMenu(InputAction.CallbackContext context);
	}

	public interface ICameraActions
	{
		void OnTurn(InputAction.CallbackContext context);

		void OnMousePosition(InputAction.CallbackContext context);
	}

	public interface IMenuActions
	{
		void OnCancel(InputAction.CallbackContext context);

		void OnSettings(InputAction.CallbackContext context);

		void OnDragAndDrop(InputAction.CallbackContext context);

		void OnFPSToggle(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Character;

	private List<ICharacterActions> m_CharacterActionsCallbackInterfaces = new List<ICharacterActions>();

	private readonly InputAction m_Character_Movement;

	private readonly InputAction m_Character_Running;

	private readonly InputAction m_Character_Interact;

	private readonly InputAction m_Character_HoldInteraction;

	private readonly InputAction m_Character_Action;

	private readonly InputAction m_Character_Place;

	private readonly InputAction m_Character_RotatePlaceable;

	private readonly InputAction m_Character_ToolbarHotkey;

	private readonly InputAction m_Character_Rotate;

	private readonly InputAction m_Character_OpenCharacterMenu;

	private readonly InputActionMap m_Camera;

	private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();

	private readonly InputAction m_Camera_Turn;

	private readonly InputAction m_Camera_MousePosition;

	private readonly InputActionMap m_Menu;

	private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();

	private readonly InputAction m_Menu_Cancel;

	private readonly InputAction m_Menu_Settings;

	private readonly InputAction m_Menu_DragAndDrop;

	private readonly InputAction m_Menu_FPSToggle;

	private int m_DefaultSchemeSchemeIndex = -1;

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

	public CharacterActions Character => new CharacterActions(this);

	public CameraActions Camera => new CameraActions(this);

	public MenuActions Menu => new MenuActions(this);

	public InputControlScheme DefaultSchemeScheme
	{
		get
		{
			if (m_DefaultSchemeSchemeIndex == -1)
			{
				m_DefaultSchemeSchemeIndex = asset.FindControlSchemeIndex("DefaultScheme");
			}
			return asset.controlSchemes[m_DefaultSchemeSchemeIndex];
		}
	}

	public InputMap()
	{
		asset = InputActionAsset.FromJson("{\n    \"version\": 1,\n    \"name\": \"InputMap\",\n    \"maps\": [\n        {\n            \"name\": \"Character\",\n            \"id\": \"d0145d6b-9a43-4df4-bde7-b26d3e55d18d\",\n            \"actions\": [\n                {\n                    \"name\": \"Movement\",\n                    \"type\": \"Value\",\n                    \"id\": \"01d53a37-eadc-405c-ab9a-3d632eee71f6\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Running\",\n                    \"type\": \"Button\",\n                    \"id\": \"3934eab4-7f67-4aa0-8b14-e02fdcab2346\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Interact\",\n                    \"type\": \"Button\",\n                    \"id\": \"cc0029b5-80af-4103-8861-be46c4f51725\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"HoldInteraction\",\n                    \"type\": \"Button\",\n                    \"id\": \"6ad190d8-8e43-4fd5-b58d-8c9b7ed58fa4\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Action\",\n                    \"type\": \"Button\",\n                    \"id\": \"de9e390b-5a19-4bc3-a53a-60cf1bef39ab\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Place\",\n                    \"type\": \"Button\",\n                    \"id\": \"b44105bf-8d29-4762-8cfe-8b83fcdc3a34\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"RotatePlaceable\",\n                    \"type\": \"Value\",\n                    \"id\": \"c49e3405-1b7b-4b36-ad97-3132e7beb277\",\n                    \"expectedControlType\": \"Axis\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"ToolbarHotkey\",\n                    \"type\": \"Value\",\n                    \"id\": \"1189f2a7-341a-4d35-bbc6-ed7ecd1c5a46\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Rotate\",\n                    \"type\": \"Value\",\n                    \"id\": \"d8c17d77-70cb-41b5-b2e0-a2781ebab751\",\n                    \"expectedControlType\": \"Axis\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"OpenCharacterMenu\",\n                    \"type\": \"Button\",\n                    \"id\": \"78baae01-d765-4b4a-aa1a-48af8053c7a6\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"Axis\",\n                    \"id\": \"9636380d-b887-4526-92eb-ffb285b30620\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"6649b007-930a-4b08-847e-5acca88de279\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"f59377fd-705d-49c7-b190-5071647fb360\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"92a9b194-ba1d-4af5-bb38-e4f8819a8dc2\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"1e47405d-6ff0-4294-939e-b40496839c85\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"7390bdaf-3c01-49d2-8adf-3c88d8a8a29f\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"7540d513-54d0-4b16-8bf5-1afb1964aaa0\",\n                    \"path\": \"<Gamepad>/leftStick/y\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"77f6bc1a-777a-4c5a-9478-241360f2ac84\",\n                    \"path\": \"<Gamepad>/leftStick/y\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"31583b2c-cb2a-4c09-8b88-8e7a878680de\",\n                    \"path\": \"<Gamepad>/leftStick/x\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"e13ee0b3-cd84-4144-aa47-ca01119b868b\",\n                    \"path\": \"<Gamepad>/leftStick/x\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3e1fda9b-20dd-4be2-b09d-c514d05968ae\",\n                    \"path\": \"<Gamepad>/leftStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Movement\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"44450140-938c-4d8a-9321-5463c88be07e\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Place\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c080733e-4b31-4958-8eaf-8a0a6bc1bf09\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Place\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"491ec75f-ffe1-47cd-b7a4-065f5bb3f5a0\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"829f2825-7a4a-4e3a-b08d-df26baee17a5\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1d41c069-6bd5-4cf0-ab8b-843dfb8683ed\",\n                    \"path\": \"<Keyboard>/leftShift\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Running\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c6f16b6c-a457-4ee4-8c9d-1a7336b40860\",\n                    \"path\": \"<Gamepad>/rightTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Running\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1d127f09-0931-44d3-a005-cc6af1398c96\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"HoldInteraction\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"03e03cc6-e252-4a0e-995b-57c10f095d02\",\n                    \"path\": \"<Gamepad>/leftShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"HoldInteraction\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7b9d5b9c-c4e6-4a59-babe-903e67447681\",\n                    \"path\": \"<Mouse>/rightButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4468705c-7024-48cc-a9b3-f8d4a1244ca8\",\n                    \"path\": \"<Gamepad>/rightShoulder\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Action\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"1D Axis\",\n                    \"id\": \"cffcd8eb-773b-45d5-ad84-e538d1e310f0\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RotatePlaceable\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"b62ec178-0577-411c-9226-2879008f41fe\",\n                    \"path\": \"<Mouse>/scroll/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RotatePlaceable\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"1614ef0c-3a21-4e79-8724-9bce0ddbc1e0\",\n                    \"path\": \"<Mouse>/scroll/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RotatePlaceable\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"1D Axis\",\n                    \"id\": \"ff3bb239-525a-439e-8c47-aa51663014af\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RotatePlaceable\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"4b3de46d-01a0-48af-beea-3c0ff062ef75\",\n                    \"path\": \"<Gamepad>/dpad/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RotatePlaceable\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"06447ce8-750d-4d29-a547-7cb97a868833\",\n                    \"path\": \"<Gamepad>/dpad/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"RotatePlaceable\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"1D Axis\",\n                    \"id\": \"38bd7f7a-d870-4946-9eda-f00feb3bd6d4\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"39aca387-452c-42a4-b772-c4823b01af91\",\n                    \"path\": \"<Mouse>/scroll/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"565ce27f-af84-4901-bead-63c6f9675867\",\n                    \"path\": \"<Mouse>/scroll/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"1D Axis\",\n                    \"id\": \"14f08d80-9baa-43d0-9e58-a78a2db4524d\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"1f38fb31-a3f6-4938-83ab-bd67cbd867f8\",\n                    \"path\": \"<Gamepad>/dpad/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"48990567-3ba7-41e8-a62c-fcef22681f9d\",\n                    \"path\": \"<Gamepad>/dpad/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Rotate\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"975187ac-04e2-424f-8ac2-83c69265b408\",\n                    \"path\": \"<Keyboard>/r\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"OpenCharacterMenu\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a2b75f0b-8557-48aa-90a5-a6ed708be69e\",\n                    \"path\": \"<Keyboard>/1\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=0)\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"702b66d1-01a8-46ce-b787-c1a512a91618\",\n                    \"path\": \"<Keyboard>/2\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"5ab6c2ac-6dd5-4ef7-9578-a9413ffd0258\",\n                    \"path\": \"<Keyboard>/3\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=2)\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"261770fa-1177-45c8-a99f-936779bce06c\",\n                    \"path\": \"<Keyboard>/4\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=3)\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"7ccd8b5b-fd8c-4c3c-ae31-e1f8cb6e69f0\",\n                    \"path\": \"<Keyboard>/5\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=4)\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"cad961a8-ef67-488b-ba9e-680d801c3cab\",\n                    \"path\": \"<Keyboard>/6\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=5)\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0ab1b0c1-55ac-4f8c-9be5-32c55163f262\",\n                    \"path\": \"<Keyboard>/7\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=6)\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"9ff0e955-6964-4478-a107-33cdfc6ff482\",\n                    \"path\": \"<Keyboard>/8\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=7)\",\n                    \"groups\": \"\",\n                    \"action\": \"ToolbarHotkey\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Camera\",\n            \"id\": \"7ba0b281-3118-4db1-96c2-b9eaf13679ac\",\n            \"actions\": [\n                {\n                    \"name\": \"Turn\",\n                    \"type\": \"Value\",\n                    \"id\": \"317a569d-b3ba-4589-99b7-db4e797de317\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"MousePosition\",\n                    \"type\": \"Value\",\n                    \"id\": \"694427c6-5a05-4a37-8eac-615b4f284ac6\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"16ae9917-a1fd-4a54-b71a-053289559447\",\n                    \"path\": \"<Mouse>/delta\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Turn\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4ccfbf4a-b9de-4de9-8ade-e32fa3a53981\",\n                    \"path\": \"<Gamepad>/rightStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"ScaleVector2(x=10,y=10)\",\n                    \"groups\": \"\",\n                    \"action\": \"Turn\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"00910674-258d-4a89-b4b9-5f3e9dc1a8ee\",\n                    \"path\": \"<Mouse>/position\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"MousePosition\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"512c71de-6af5-4a02-9499-207aa39665d3\",\n                    \"path\": \"<VirtualMouse>/position\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"MousePosition\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Menu\",\n            \"id\": \"6d35db45-7bc0-4689-9c54-91a41ee48353\",\n            \"actions\": [\n                {\n                    \"name\": \"Cancel\",\n                    \"type\": \"Button\",\n                    \"id\": \"c8ecf023-b387-4503-8d3f-434de72b6d40\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Settings\",\n                    \"type\": \"Button\",\n                    \"id\": \"68f85103-9166-41c5-924b-f1a6c48ec542\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"DragAndDrop\",\n                    \"type\": \"Button\",\n                    \"id\": \"3bde58a3-a236-4cf2-95ca-de1b51975e31\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"FPSToggle\",\n                    \"type\": \"Button\",\n                    \"id\": \"31325a0c-8e1a-4528-9b5a-e042694a16f0\",\n                    \"expectedControlType\": \"\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"a0cedade-28cc-48cc-b75a-1f767f73c1d9\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Cancel\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6f3d3668-76d4-44ea-b0af-2e7ad1d1de2a\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Cancel\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"9a3cf2d3-196f-49a6-86ad-5e9aac38ec65\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Settings\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1bdc5c03-10ee-4b7e-9860-c5f740361ed1\",\n                    \"path\": \"<Gamepad>/start\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Settings\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"054fd20a-d530-46f5-9c77-3b1f28dc13c9\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"DragAndDrop\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"017963f5-8e63-4c65-aed0-ab875b6cba8e\",\n                    \"path\": \"<Keyboard>/f1\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"FPSToggle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"fa416cc1-e509-450d-9bb7-32c4156651c3\",\n                    \"path\": \"<Gamepad>/select\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"FPSToggle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": [\n        {\n            \"name\": \"DefaultScheme\",\n            \"bindingGroup\": \"DefaultScheme\",\n            \"devices\": []\n        }\n    ]\n}");
		m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
		m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
		m_Character_Running = m_Character.FindAction("Running", throwIfNotFound: true);
		m_Character_Interact = m_Character.FindAction("Interact", throwIfNotFound: true);
		m_Character_HoldInteraction = m_Character.FindAction("HoldInteraction", throwIfNotFound: true);
		m_Character_Action = m_Character.FindAction("Action", throwIfNotFound: true);
		m_Character_Place = m_Character.FindAction("Place", throwIfNotFound: true);
		m_Character_RotatePlaceable = m_Character.FindAction("RotatePlaceable", throwIfNotFound: true);
		m_Character_ToolbarHotkey = m_Character.FindAction("ToolbarHotkey", throwIfNotFound: true);
		m_Character_Rotate = m_Character.FindAction("Rotate", throwIfNotFound: true);
		m_Character_OpenCharacterMenu = m_Character.FindAction("OpenCharacterMenu", throwIfNotFound: true);
		m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
		m_Camera_Turn = m_Camera.FindAction("Turn", throwIfNotFound: true);
		m_Camera_MousePosition = m_Camera.FindAction("MousePosition", throwIfNotFound: true);
		m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
		m_Menu_Cancel = m_Menu.FindAction("Cancel", throwIfNotFound: true);
		m_Menu_Settings = m_Menu.FindAction("Settings", throwIfNotFound: true);
		m_Menu_DragAndDrop = m_Menu.FindAction("DragAndDrop", throwIfNotFound: true);
		m_Menu_FPSToggle = m_Menu.FindAction("FPSToggle", throwIfNotFound: true);
	}

	~InputMap()
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

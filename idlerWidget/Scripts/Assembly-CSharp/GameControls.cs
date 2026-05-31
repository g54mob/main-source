using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GameControls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct DefaultActions
	{
		private GameControls m_Wrapper;

		public InputAction ToggleMap => m_Wrapper.m_Default_ToggleMap;

		public InputAction ToggleBuild => m_Wrapper.m_Default_ToggleBuild;

		public InputAction ToggleInventory => m_Wrapper.m_Default_ToggleInventory;

		public InputAction ToggleTech => m_Wrapper.m_Default_ToggleTech;

		public InputAction ToggleConstruction => m_Wrapper.m_Default_ToggleConstruction;

		public InputAction TraverseMap => m_Wrapper.m_Default_TraverseMap;

		public InputAction TraverseMouse => m_Wrapper.m_Default_TraverseMouse;

		public InputAction Interact => m_Wrapper.m_Default_Interact;

		public InputAction Cancel => m_Wrapper.m_Default_Cancel;

		public InputAction ToggleUI => m_Wrapper.m_Default_ToggleUI;

		public InputAction Escape => m_Wrapper.m_Default_Escape;

		public InputAction Return => m_Wrapper.m_Default_Return;

		public bool enabled => Get().enabled;

		public DefaultActions(GameControls wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Default;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(DefaultActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IDefaultActions instance)
		{
			if (instance != null && !m_Wrapper.m_DefaultActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_DefaultActionsCallbackInterfaces.Add(instance);
				ToggleMap.started += instance.OnToggleMap;
				ToggleMap.performed += instance.OnToggleMap;
				ToggleMap.canceled += instance.OnToggleMap;
				ToggleBuild.started += instance.OnToggleBuild;
				ToggleBuild.performed += instance.OnToggleBuild;
				ToggleBuild.canceled += instance.OnToggleBuild;
				ToggleInventory.started += instance.OnToggleInventory;
				ToggleInventory.performed += instance.OnToggleInventory;
				ToggleInventory.canceled += instance.OnToggleInventory;
				ToggleTech.started += instance.OnToggleTech;
				ToggleTech.performed += instance.OnToggleTech;
				ToggleTech.canceled += instance.OnToggleTech;
				ToggleConstruction.started += instance.OnToggleConstruction;
				ToggleConstruction.performed += instance.OnToggleConstruction;
				ToggleConstruction.canceled += instance.OnToggleConstruction;
				TraverseMap.started += instance.OnTraverseMap;
				TraverseMap.performed += instance.OnTraverseMap;
				TraverseMap.canceled += instance.OnTraverseMap;
				TraverseMouse.started += instance.OnTraverseMouse;
				TraverseMouse.performed += instance.OnTraverseMouse;
				TraverseMouse.canceled += instance.OnTraverseMouse;
				Interact.started += instance.OnInteract;
				Interact.performed += instance.OnInteract;
				Interact.canceled += instance.OnInteract;
				Cancel.started += instance.OnCancel;
				Cancel.performed += instance.OnCancel;
				Cancel.canceled += instance.OnCancel;
				ToggleUI.started += instance.OnToggleUI;
				ToggleUI.performed += instance.OnToggleUI;
				ToggleUI.canceled += instance.OnToggleUI;
				Escape.started += instance.OnEscape;
				Escape.performed += instance.OnEscape;
				Escape.canceled += instance.OnEscape;
				Return.started += instance.OnReturn;
				Return.performed += instance.OnReturn;
				Return.canceled += instance.OnReturn;
			}
		}

		private void UnregisterCallbacks(IDefaultActions instance)
		{
			ToggleMap.started -= instance.OnToggleMap;
			ToggleMap.performed -= instance.OnToggleMap;
			ToggleMap.canceled -= instance.OnToggleMap;
			ToggleBuild.started -= instance.OnToggleBuild;
			ToggleBuild.performed -= instance.OnToggleBuild;
			ToggleBuild.canceled -= instance.OnToggleBuild;
			ToggleInventory.started -= instance.OnToggleInventory;
			ToggleInventory.performed -= instance.OnToggleInventory;
			ToggleInventory.canceled -= instance.OnToggleInventory;
			ToggleTech.started -= instance.OnToggleTech;
			ToggleTech.performed -= instance.OnToggleTech;
			ToggleTech.canceled -= instance.OnToggleTech;
			ToggleConstruction.started -= instance.OnToggleConstruction;
			ToggleConstruction.performed -= instance.OnToggleConstruction;
			ToggleConstruction.canceled -= instance.OnToggleConstruction;
			TraverseMap.started -= instance.OnTraverseMap;
			TraverseMap.performed -= instance.OnTraverseMap;
			TraverseMap.canceled -= instance.OnTraverseMap;
			TraverseMouse.started -= instance.OnTraverseMouse;
			TraverseMouse.performed -= instance.OnTraverseMouse;
			TraverseMouse.canceled -= instance.OnTraverseMouse;
			Interact.started -= instance.OnInteract;
			Interact.performed -= instance.OnInteract;
			Interact.canceled -= instance.OnInteract;
			Cancel.started -= instance.OnCancel;
			Cancel.performed -= instance.OnCancel;
			Cancel.canceled -= instance.OnCancel;
			ToggleUI.started -= instance.OnToggleUI;
			ToggleUI.performed -= instance.OnToggleUI;
			ToggleUI.canceled -= instance.OnToggleUI;
			Escape.started -= instance.OnEscape;
			Escape.performed -= instance.OnEscape;
			Escape.canceled -= instance.OnEscape;
			Return.started -= instance.OnReturn;
			Return.performed -= instance.OnReturn;
			Return.canceled -= instance.OnReturn;
		}

		public void RemoveCallbacks(IDefaultActions instance)
		{
			if (m_Wrapper.m_DefaultActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IDefaultActions instance)
		{
			foreach (IDefaultActions defaultActionsCallbackInterface in m_Wrapper.m_DefaultActionsCallbackInterfaces)
			{
				UnregisterCallbacks(defaultActionsCallbackInterface);
			}
			m_Wrapper.m_DefaultActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IDefaultActions
	{
		void OnToggleMap(InputAction.CallbackContext context);

		void OnToggleBuild(InputAction.CallbackContext context);

		void OnToggleInventory(InputAction.CallbackContext context);

		void OnToggleTech(InputAction.CallbackContext context);

		void OnToggleConstruction(InputAction.CallbackContext context);

		void OnTraverseMap(InputAction.CallbackContext context);

		void OnTraverseMouse(InputAction.CallbackContext context);

		void OnInteract(InputAction.CallbackContext context);

		void OnCancel(InputAction.CallbackContext context);

		void OnToggleUI(InputAction.CallbackContext context);

		void OnEscape(InputAction.CallbackContext context);

		void OnReturn(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Default;

	private List<IDefaultActions> m_DefaultActionsCallbackInterfaces = new List<IDefaultActions>();

	private readonly InputAction m_Default_ToggleMap;

	private readonly InputAction m_Default_ToggleBuild;

	private readonly InputAction m_Default_ToggleInventory;

	private readonly InputAction m_Default_ToggleTech;

	private readonly InputAction m_Default_ToggleConstruction;

	private readonly InputAction m_Default_TraverseMap;

	private readonly InputAction m_Default_TraverseMouse;

	private readonly InputAction m_Default_Interact;

	private readonly InputAction m_Default_Cancel;

	private readonly InputAction m_Default_ToggleUI;

	private readonly InputAction m_Default_Escape;

	private readonly InputAction m_Default_Return;

	private int m_MKBSchemeIndex = -1;

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

	public DefaultActions Default => new DefaultActions(this);

	public InputControlScheme MKBScheme
	{
		get
		{
			if (m_MKBSchemeIndex == -1)
			{
				m_MKBSchemeIndex = asset.FindControlSchemeIndex("MKB");
			}
			return asset.controlSchemes[m_MKBSchemeIndex];
		}
	}

	public GameControls()
	{
		asset = InputActionAsset.FromJson("{\n    \"version\": 1,\n    \"name\": \"GameControls\",\n    \"maps\": [\n        {\n            \"name\": \"Default\",\n            \"id\": \"bc599378-4300-4b00-8eba-e83485d4051d\",\n            \"actions\": [\n                {\n                    \"name\": \"ToggleMap\",\n                    \"type\": \"Button\",\n                    \"id\": \"2e5a7784-291c-4c75-ab0d-5333a229dbe6\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ToggleBuild\",\n                    \"type\": \"Button\",\n                    \"id\": \"fce4af82-2673-4844-86a0-2e837ad0a2b1\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ToggleInventory\",\n                    \"type\": \"Button\",\n                    \"id\": \"970e2091-055c-401e-a52a-89873c04e76d\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ToggleTech\",\n                    \"type\": \"Button\",\n                    \"id\": \"331c6ed5-0283-4861-8a92-7c835fc30343\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ToggleConstruction\",\n                    \"type\": \"Button\",\n                    \"id\": \"09caa526-6cdb-4390-b83d-c9cf73867cbf\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"TraverseMap\",\n                    \"type\": \"Value\",\n                    \"id\": \"278b222b-251a-4850-90cf-88e73d39bba8\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"TraverseMouse\",\n                    \"type\": \"Value\",\n                    \"id\": \"f05bd4fa-1ec0-4c63-9f30-e7a95444f07c\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Interact\",\n                    \"type\": \"Button\",\n                    \"id\": \"516cf3be-57fd-4dff-967a-e03e13889875\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Cancel\",\n                    \"type\": \"Button\",\n                    \"id\": \"b27611b3-8cd4-4278-8bf2-189694358051\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"Press(behavior=1)\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"ToggleUI\",\n                    \"type\": \"Button\",\n                    \"id\": \"4e59a712-f434-49b4-9d54-c97d23106078\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Escape\",\n                    \"type\": \"Button\",\n                    \"id\": \"9dc562a6-5ed6-4408-80b8-a93ce2d7cbb3\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                },\n                {\n                    \"name\": \"Return\",\n                    \"type\": \"Button\",\n                    \"id\": \"7ced7db7-8bc3-462e-9fd2-7945b802d1f8\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"4ba7cae3-537e-42a4-9e25-812b4bc0088d\",\n                    \"path\": \"<Keyboard>/#(M)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d4542704-729c-4e28-9080-15641e5a769b\",\n                    \"path\": \"<Gamepad>/select\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"1bdacf3e-79b6-4318-b078-98d1cb974fb3\",\n                    \"path\": \"<Keyboard>/#(B)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleBuild\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e0374037-6c4b-45d2-ab26-e9e57d53d572\",\n                    \"path\": \"<Gamepad>/dpad/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleBuild\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"5be36cda-40bc-4857-9b0f-5635bce76d71\",\n                    \"path\": \"<Keyboard>/#(I)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleInventory\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d24c6fde-7f59-476b-9ca6-43409d2def74\",\n                    \"path\": \"<Gamepad>/dpad/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleInventory\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"2ea95369-8522-4627-9563-03ec67f1a7a5\",\n                    \"path\": \"<Keyboard>/#(T)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleTech\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"0001a2f0-89af-4a79-9595-c063230f44f6\",\n                    \"path\": \"<Gamepad>/dpad/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleTech\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"c5b916e7-1eb0-408e-8c90-18953d2d89b3\",\n                    \"path\": \"<Keyboard>/#(O)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleConstruction\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"5542a738-e78d-45de-8f84-ca907b112ca4\",\n                    \"path\": \"<Gamepad>/dpad/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleConstruction\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"d63f0ff1-3698-4a1d-82b0-25a2624405b0\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"43089edd-5f56-46e9-bd8b-155580fdc93b\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"c7925e33-fb15-4cc6-b5ec-b5d6aad976b2\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"ee3ea912-dede-4713-aa4b-05b8963c30af\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"8148546d-aab7-4e6c-af6e-8edbda4d8f54\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"2D Vector\",\n                    \"id\": \"225bb2bf-9471-4dbb-9e83-da0e92307011\",\n                    \"path\": \"2DVector\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"4447b837-80a3-46ad-9fc5-04c0efe832ab\",\n                    \"path\": \"<Keyboard>/upArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"d335a03c-d43b-4583-a19a-f1ab83bbe2ef\",\n                    \"path\": \"<Keyboard>/downArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"a0b362b5-f1c6-4d36-a119-8d5078f67e93\",\n                    \"path\": \"<Keyboard>/leftArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"0a8ac8d4-34b7-4798-80e4-82aaed766fa9\",\n                    \"path\": \"<Keyboard>/rightArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"d134b72c-b504-497a-9706-1a27d2cce235\",\n                    \"path\": \"<Gamepad>/rightStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMap\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"8cf245ac-77e4-46ea-aa0c-176bbdb13a52\",\n                    \"path\": \"<Gamepad>/leftStick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"TraverseMouse\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"92d43f08-5b30-40ae-b9cb-bb56efac4282\",\n                    \"path\": \"<Mouse>/leftButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"047591f1-534e-4ab1-83c5-f44d982001fd\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"Press(behavior=1)\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Interact\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"51e5e341-3021-4f52-ade7-a512bccda570\",\n                    \"path\": \"<Mouse>/rightButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Cancel\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"6730daa1-b257-437b-814e-b6461acdbc0c\",\n                    \"path\": \"<Gamepad>/buttonEast\",\n                    \"interactions\": \"Press(behavior=1)\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Cancel\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"One Modifier\",\n                    \"id\": \"42bee87a-6b2b-45fd-b3e8-85aaf3a0f8c3\",\n                    \"path\": \"OneModifier\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleUI\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"modifier\",\n                    \"id\": \"b9536ecd-ad1c-438e-b501-f4589c3af2d8\",\n                    \"path\": \"<Keyboard>/alt\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleUI\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"binding\",\n                    \"id\": \"e79bc825-6135-4fc3-aa55-c7c2d025c5b8\",\n                    \"path\": \"<Keyboard>/#(V)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"ToggleUI\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"ccfe1261-96d7-4832-b9a7-7e74ba6a219e\",\n                    \"path\": \"<Keyboard>/escape\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Escape\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"e745cd91-2644-4b69-87ce-239d73115ffe\",\n                    \"path\": \"<Keyboard>/enter\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Return\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": [\n        {\n            \"name\": \"MKB\",\n            \"bindingGroup\": \"MKB\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Keyboard>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                },\n                {\n                    \"devicePath\": \"<Mouse>\",\n                    \"isOptional\": true,\n                    \"isOR\": false\n                }\n            ]\n        }\n    ]\n}");
		m_Default = asset.FindActionMap("Default", throwIfNotFound: true);
		m_Default_ToggleMap = m_Default.FindAction("ToggleMap", throwIfNotFound: true);
		m_Default_ToggleBuild = m_Default.FindAction("ToggleBuild", throwIfNotFound: true);
		m_Default_ToggleInventory = m_Default.FindAction("ToggleInventory", throwIfNotFound: true);
		m_Default_ToggleTech = m_Default.FindAction("ToggleTech", throwIfNotFound: true);
		m_Default_ToggleConstruction = m_Default.FindAction("ToggleConstruction", throwIfNotFound: true);
		m_Default_TraverseMap = m_Default.FindAction("TraverseMap", throwIfNotFound: true);
		m_Default_TraverseMouse = m_Default.FindAction("TraverseMouse", throwIfNotFound: true);
		m_Default_Interact = m_Default.FindAction("Interact", throwIfNotFound: true);
		m_Default_Cancel = m_Default.FindAction("Cancel", throwIfNotFound: true);
		m_Default_ToggleUI = m_Default.FindAction("ToggleUI", throwIfNotFound: true);
		m_Default_Escape = m_Default.FindAction("Escape", throwIfNotFound: true);
		m_Default_Return = m_Default.FindAction("Return", throwIfNotFound: true);
	}

	~GameControls()
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

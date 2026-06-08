using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PanelControls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct PanelActions
	{
		private PanelControls m_Wrapper;

		public InputAction Enter => m_Wrapper.m_Panel_Enter;

		public InputAction Undo => m_Wrapper.m_Panel_Undo;

		public InputAction Redo => m_Wrapper.m_Panel_Redo;

		public InputAction UndoHold => m_Wrapper.m_Panel_UndoHold;

		public InputAction RedoHold => m_Wrapper.m_Panel_RedoHold;

		public InputAction PageMove => m_Wrapper.m_Panel_PageMove;

		public InputAction EnterQuery => m_Wrapper.m_Panel_EnterQuery;

		public bool enabled => Get().enabled;

		public PanelActions(PanelControls wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Panel;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(PanelActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IPanelActions instance)
		{
			if (instance != null && !m_Wrapper.m_PanelActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_PanelActionsCallbackInterfaces.Add(instance);
				Enter.started += instance.OnEnter;
				Enter.performed += instance.OnEnter;
				Enter.canceled += instance.OnEnter;
				Undo.started += instance.OnUndo;
				Undo.performed += instance.OnUndo;
				Undo.canceled += instance.OnUndo;
				Redo.started += instance.OnRedo;
				Redo.performed += instance.OnRedo;
				Redo.canceled += instance.OnRedo;
				UndoHold.started += instance.OnUndoHold;
				UndoHold.performed += instance.OnUndoHold;
				UndoHold.canceled += instance.OnUndoHold;
				RedoHold.started += instance.OnRedoHold;
				RedoHold.performed += instance.OnRedoHold;
				RedoHold.canceled += instance.OnRedoHold;
				PageMove.started += instance.OnPageMove;
				PageMove.performed += instance.OnPageMove;
				PageMove.canceled += instance.OnPageMove;
				EnterQuery.started += instance.OnEnterQuery;
				EnterQuery.performed += instance.OnEnterQuery;
				EnterQuery.canceled += instance.OnEnterQuery;
			}
		}

		private void UnregisterCallbacks(IPanelActions instance)
		{
			Enter.started -= instance.OnEnter;
			Enter.performed -= instance.OnEnter;
			Enter.canceled -= instance.OnEnter;
			Undo.started -= instance.OnUndo;
			Undo.performed -= instance.OnUndo;
			Undo.canceled -= instance.OnUndo;
			Redo.started -= instance.OnRedo;
			Redo.performed -= instance.OnRedo;
			Redo.canceled -= instance.OnRedo;
			UndoHold.started -= instance.OnUndoHold;
			UndoHold.performed -= instance.OnUndoHold;
			UndoHold.canceled -= instance.OnUndoHold;
			RedoHold.started -= instance.OnRedoHold;
			RedoHold.performed -= instance.OnRedoHold;
			RedoHold.canceled -= instance.OnRedoHold;
			PageMove.started -= instance.OnPageMove;
			PageMove.performed -= instance.OnPageMove;
			PageMove.canceled -= instance.OnPageMove;
			EnterQuery.started -= instance.OnEnterQuery;
			EnterQuery.performed -= instance.OnEnterQuery;
			EnterQuery.canceled -= instance.OnEnterQuery;
		}

		public void RemoveCallbacks(IPanelActions instance)
		{
			if (m_Wrapper.m_PanelActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IPanelActions instance)
		{
			foreach (IPanelActions panelActionsCallbackInterface in m_Wrapper.m_PanelActionsCallbackInterfaces)
			{
				UnregisterCallbacks(panelActionsCallbackInterface);
			}
			m_Wrapper.m_PanelActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IPanelActions
	{
		void OnEnter(InputAction.CallbackContext context);

		void OnUndo(InputAction.CallbackContext context);

		void OnRedo(InputAction.CallbackContext context);

		void OnUndoHold(InputAction.CallbackContext context);

		void OnRedoHold(InputAction.CallbackContext context);

		void OnPageMove(InputAction.CallbackContext context);

		void OnEnterQuery(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Panel;

	private List<IPanelActions> m_PanelActionsCallbackInterfaces = new List<IPanelActions>();

	private readonly InputAction m_Panel_Enter;

	private readonly InputAction m_Panel_Undo;

	private readonly InputAction m_Panel_Redo;

	private readonly InputAction m_Panel_UndoHold;

	private readonly InputAction m_Panel_RedoHold;

	private readonly InputAction m_Panel_PageMove;

	private readonly InputAction m_Panel_EnterQuery;

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

	public PanelActions Panel => new PanelActions(this);

	public PanelControls()
	{
		asset = InputActionAsset.FromJson("{\r\n    \"version\": 1,\r\n    \"name\": \"PanelControls\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Panel\",\r\n            \"id\": \"b9123d08-b67a-4d94-9c78-5f361c8243b4\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Enter\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0111c7c6-7ee1-45e8-8b02-21ab063fc540\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Undo\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2d12becc-b10b-4447-8b67-c43c77e1a4b3\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Redo\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"fd238798-44ed-41fc-8084-9bc6da6379ef\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Undo Hold\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"555a54a2-9bcd-4dc8-a648-a9aa9c03108e\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Redo Hold\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"bd9751ff-631c-4e15-bb25-0bb3473bc560\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Page Move\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"af585242-67b6-414e-a275-b0da39341629\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Enter Query\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"368f1c08-8e26-44ab-8278-1e877f3ce5d5\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0d1f57d9-1e88-47af-8b0e-f8979f584f4c\",\r\n                    \"path\": \"<Keyboard>/enter\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Enter\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Ctrl+Y\",\r\n                    \"id\": \"cab35378-e9d5-4f87-bc08-1676a8fc3044\",\r\n                    \"path\": \"ButtonWithOneModifier\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Redo\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"modifier\",\r\n                    \"id\": \"fe8b8410-2200-465a-964e-5af30ffe78bf\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Redo\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"button\",\r\n                    \"id\": \"42c11f47-62ea-49df-a61a-e7f93e11458a\",\r\n                    \"path\": \"<Keyboard>/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Redo\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Ctrl+Z\",\r\n                    \"id\": \"50042688-89eb-4a7f-8a00-38cb2efbe224\",\r\n                    \"path\": \"OneModifier\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Undo\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"modifier\",\r\n                    \"id\": \"dab20ce1-ff0a-42bf-9dfb-6c90c47db3f3\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Undo\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"binding\",\r\n                    \"id\": \"4d52369e-13d3-49c9-916f-7376d4735952\",\r\n                    \"path\": \"<Keyboard>/z\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Undo\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Ctrl+Z\",\r\n                    \"id\": \"2f32a77b-3eb6-4064-a3c6-a8f52fc9f54d\",\r\n                    \"path\": \"OneModifier\",\r\n                    \"interactions\": \"Hold(duration=1)\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Undo Hold\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"modifier\",\r\n                    \"id\": \"9d7ca05c-b857-4ddb-b9ef-7803513c36c2\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Undo Hold\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"binding\",\r\n                    \"id\": \"939cb84e-7800-4c5f-bb50-87fe95552a6a\",\r\n                    \"path\": \"<Keyboard>/z\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Undo Hold\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Ctrl+Y\",\r\n                    \"id\": \"d6af19e6-0038-4dbf-a171-a047a751ca75\",\r\n                    \"path\": \"OneModifier\",\r\n                    \"interactions\": \"Hold(duration=1)\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Redo Hold\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"modifier\",\r\n                    \"id\": \"7fd0ddc3-aa64-4b4b-a1d4-04cb7d00adb1\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Redo Hold\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"binding\",\r\n                    \"id\": \"e45fcfbf-478b-4546-a99f-e504b6fd713e\",\r\n                    \"path\": \"<Keyboard>/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Redo Hold\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4db4f565-0644-4f3a-aeeb-8dc4e2e2c81b\",\r\n                    \"path\": \"<Keyboard>/pageUp\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Page Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"713a1f60-e56d-4d3b-a984-089676565fdf\",\r\n                    \"path\": \"<Keyboard>/pageDown\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Page Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Ctrl+Enter\",\r\n                    \"id\": \"77cf12b6-4b5a-4bc5-80e2-20bc6b993626\",\r\n                    \"path\": \"OneModifier\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Enter Query\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"modifier\",\r\n                    \"id\": \"31a6dd52-70f3-44c0-8f2c-42829d62dc84\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Enter Query\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"binding\",\r\n                    \"id\": \"5f1f8120-dc85-4f7a-991a-76909d1d899a\",\r\n                    \"path\": \"<Keyboard>/enter\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Enter Query\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": []\r\n}");
		m_Panel = asset.FindActionMap("Panel", throwIfNotFound: true);
		m_Panel_Enter = m_Panel.FindAction("Enter", throwIfNotFound: true);
		m_Panel_Undo = m_Panel.FindAction("Undo", throwIfNotFound: true);
		m_Panel_Redo = m_Panel.FindAction("Redo", throwIfNotFound: true);
		m_Panel_UndoHold = m_Panel.FindAction("Undo Hold", throwIfNotFound: true);
		m_Panel_RedoHold = m_Panel.FindAction("Redo Hold", throwIfNotFound: true);
		m_Panel_PageMove = m_Panel.FindAction("Page Move", throwIfNotFound: true);
		m_Panel_EnterQuery = m_Panel.FindAction("Enter Query", throwIfNotFound: true);
	}

	~PanelControls()
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class DemoInputControls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct DemoActionMapActions
	{
		private DemoInputControls m_Wrapper;

		public InputAction Horizontal => m_Wrapper.m_DemoActionMap_Horizontal;

		public InputAction Vertical => m_Wrapper.m_DemoActionMap_Vertical;

		public InputAction Fire1 => m_Wrapper.m_DemoActionMap_Fire1;

		public bool enabled => Get().enabled;

		public DemoActionMapActions(DemoInputControls wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_DemoActionMap;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(DemoActionMapActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IDemoActionMapActions instance)
		{
			if (instance != null && !m_Wrapper.m_DemoActionMapActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_DemoActionMapActionsCallbackInterfaces.Add(instance);
				Horizontal.started += instance.OnHorizontal;
				Horizontal.performed += instance.OnHorizontal;
				Horizontal.canceled += instance.OnHorizontal;
				Vertical.started += instance.OnVertical;
				Vertical.performed += instance.OnVertical;
				Vertical.canceled += instance.OnVertical;
				Fire1.started += instance.OnFire1;
				Fire1.performed += instance.OnFire1;
				Fire1.canceled += instance.OnFire1;
			}
		}

		private void UnregisterCallbacks(IDemoActionMapActions instance)
		{
			Horizontal.started -= instance.OnHorizontal;
			Horizontal.performed -= instance.OnHorizontal;
			Horizontal.canceled -= instance.OnHorizontal;
			Vertical.started -= instance.OnVertical;
			Vertical.performed -= instance.OnVertical;
			Vertical.canceled -= instance.OnVertical;
			Fire1.started -= instance.OnFire1;
			Fire1.performed -= instance.OnFire1;
			Fire1.canceled -= instance.OnFire1;
		}

		public void RemoveCallbacks(IDemoActionMapActions instance)
		{
			if (m_Wrapper.m_DemoActionMapActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IDemoActionMapActions instance)
		{
			foreach (IDemoActionMapActions demoActionMapActionsCallbackInterface in m_Wrapper.m_DemoActionMapActionsCallbackInterfaces)
			{
				UnregisterCallbacks(demoActionMapActionsCallbackInterface);
			}
			m_Wrapper.m_DemoActionMapActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IDemoActionMapActions
	{
		void OnHorizontal(InputAction.CallbackContext context);

		void OnVertical(InputAction.CallbackContext context);

		void OnFire1(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_DemoActionMap;

	private List<IDemoActionMapActions> m_DemoActionMapActionsCallbackInterfaces = new List<IDemoActionMapActions>();

	private readonly InputAction m_DemoActionMap_Horizontal;

	private readonly InputAction m_DemoActionMap_Vertical;

	private readonly InputAction m_DemoActionMap_Fire1;

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

	public DemoActionMapActions DemoActionMap => new DemoActionMapActions(this);

	public DemoInputControls()
	{
		asset = InputActionAsset.FromJson("{\r\n    \"name\": \"DemoInputControls\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"DemoActionMap\",\r\n            \"id\": \"41649a10-fe04-42dc-b834-7b0e6b8f6f8e\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Horizontal\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"ef3929c6-b315-4851-8f3e-ae170992d312\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Vertical\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"74bfe387-c2ec-4a2e-9b81-cd1c81ee069b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Fire1\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"804b48fe-6035-4b70-a3b4-877f04982d7d\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"A-D\",\r\n                    \"id\": \"988324e0-d947-4fa7-825f-8c22a3d5a9cd\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Horizontal\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"096967ca-ee92-45be-9f93-fc5e3a4f109d\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Horizontal\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"fbfca6ac-a78f-40e1-b53a-27a6570672c4\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Horizontal\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Left-Right\",\r\n                    \"id\": \"80a8ea42-1404-4111-b927-3d3e018469dd\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Horizontal\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"bd31e001-3b16-4b7e-865c-dc188bb61918\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Horizontal\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"98dc1df3-8219-4687-a480-47c71a1953df\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Horizontal\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"S-W\",\r\n                    \"id\": \"5fe719fc-bbc5-4091-b418-91c9a8699b54\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Vertical\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"5d7cca19-57a8-4a09-ab88-7dcac3570e64\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Vertical\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"6a6517d3-50c7-4c54-b86e-4dec04733436\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Vertical\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Down-Up\",\r\n                    \"id\": \"8ae87a3c-1197-4725-baf0-9be8746497fb\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Vertical\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"5f943101-e079-4c5e-93f1-1602b61d2418\",\r\n                    \"path\": \"<Keyboard>/downArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Vertical\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"8322cbd3-368e-43ed-b41e-f7ce51f1f189\",\r\n                    \"path\": \"<Keyboard>/upArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Vertical\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6de4a513-0301-4138-972a-db7bccc7e316\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Fire1\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e5a158a9-f419-43dc-912d-97f01d68c681\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Fire1\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": []\r\n}");
		m_DemoActionMap = asset.FindActionMap("DemoActionMap", throwIfNotFound: true);
		m_DemoActionMap_Horizontal = m_DemoActionMap.FindAction("Horizontal", throwIfNotFound: true);
		m_DemoActionMap_Vertical = m_DemoActionMap.FindAction("Vertical", throwIfNotFound: true);
		m_DemoActionMap_Fire1 = m_DemoActionMap.FindAction("Fire1", throwIfNotFound: true);
	}

	~DemoInputControls()
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

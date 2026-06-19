using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerGrabInteractionSystem : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct MoveActions
	{
		private PlayerGrabInteractionSystem m_Wrapper;

		public InputAction Move => m_Wrapper.m_Move_Move;

		public InputAction Crouch => m_Wrapper.m_Move_Crouch;

		public bool enabled => Get().enabled;

		public MoveActions(PlayerGrabInteractionSystem wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Move;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(MoveActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IMoveActions instance)
		{
			if (instance != null && !m_Wrapper.m_MoveActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_MoveActionsCallbackInterfaces.Add(instance);
				Move.started += instance.OnMove;
				Move.performed += instance.OnMove;
				Move.canceled += instance.OnMove;
				Crouch.started += instance.OnCrouch;
				Crouch.performed += instance.OnCrouch;
				Crouch.canceled += instance.OnCrouch;
			}
		}

		private void UnregisterCallbacks(IMoveActions instance)
		{
			Move.started -= instance.OnMove;
			Move.performed -= instance.OnMove;
			Move.canceled -= instance.OnMove;
			Crouch.started -= instance.OnCrouch;
			Crouch.performed -= instance.OnCrouch;
			Crouch.canceled -= instance.OnCrouch;
		}

		public void RemoveCallbacks(IMoveActions instance)
		{
			if (m_Wrapper.m_MoveActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IMoveActions instance)
		{
			foreach (IMoveActions moveActionsCallbackInterface in m_Wrapper.m_MoveActionsCallbackInterfaces)
			{
				UnregisterCallbacks(moveActionsCallbackInterface);
			}
			m_Wrapper.m_MoveActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct LookActions
	{
		private PlayerGrabInteractionSystem m_Wrapper;

		public InputAction Look => m_Wrapper.m_Look_Look;

		public bool enabled => Get().enabled;

		public LookActions(PlayerGrabInteractionSystem wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Look;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(LookActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(ILookActions instance)
		{
			if (instance != null && !m_Wrapper.m_LookActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_LookActionsCallbackInterfaces.Add(instance);
				Look.started += instance.OnLook;
				Look.performed += instance.OnLook;
				Look.canceled += instance.OnLook;
			}
		}

		private void UnregisterCallbacks(ILookActions instance)
		{
			Look.started -= instance.OnLook;
			Look.performed -= instance.OnLook;
			Look.canceled -= instance.OnLook;
		}

		public void RemoveCallbacks(ILookActions instance)
		{
			if (m_Wrapper.m_LookActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(ILookActions instance)
		{
			foreach (ILookActions lookActionsCallbackInterface in m_Wrapper.m_LookActionsCallbackInterfaces)
			{
				UnregisterCallbacks(lookActionsCallbackInterface);
			}
			m_Wrapper.m_LookActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct InteractionActions
	{
		private PlayerGrabInteractionSystem m_Wrapper;

		public InputAction Grab => m_Wrapper.m_Interaction_Grab;

		public InputAction Throw => m_Wrapper.m_Interaction_Throw;

		public InputAction Interact => m_Wrapper.m_Interaction_Interact;

		public InputAction RotateObject => m_Wrapper.m_Interaction_RotateObject;

		public InputAction StartRotate => m_Wrapper.m_Interaction_StartRotate;

		public InputAction ZoomOut => m_Wrapper.m_Interaction_ZoomOut;

		public InputAction ZoomIn => m_Wrapper.m_Interaction_ZoomIn;

		public InputAction Push => m_Wrapper.m_Interaction_Push;

		public bool enabled => Get().enabled;

		public InteractionActions(PlayerGrabInteractionSystem wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Interaction;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(InteractionActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IInteractionActions instance)
		{
			if (instance != null && !m_Wrapper.m_InteractionActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_InteractionActionsCallbackInterfaces.Add(instance);
				Grab.started += instance.OnGrab;
				Grab.performed += instance.OnGrab;
				Grab.canceled += instance.OnGrab;
				Throw.started += instance.OnThrow;
				Throw.performed += instance.OnThrow;
				Throw.canceled += instance.OnThrow;
				Interact.started += instance.OnInteract;
				Interact.performed += instance.OnInteract;
				Interact.canceled += instance.OnInteract;
				RotateObject.started += instance.OnRotateObject;
				RotateObject.performed += instance.OnRotateObject;
				RotateObject.canceled += instance.OnRotateObject;
				StartRotate.started += instance.OnStartRotate;
				StartRotate.performed += instance.OnStartRotate;
				StartRotate.canceled += instance.OnStartRotate;
				ZoomOut.started += instance.OnZoomOut;
				ZoomOut.performed += instance.OnZoomOut;
				ZoomOut.canceled += instance.OnZoomOut;
				ZoomIn.started += instance.OnZoomIn;
				ZoomIn.performed += instance.OnZoomIn;
				ZoomIn.canceled += instance.OnZoomIn;
				Push.started += instance.OnPush;
				Push.performed += instance.OnPush;
				Push.canceled += instance.OnPush;
			}
		}

		private void UnregisterCallbacks(IInteractionActions instance)
		{
			Grab.started -= instance.OnGrab;
			Grab.performed -= instance.OnGrab;
			Grab.canceled -= instance.OnGrab;
			Throw.started -= instance.OnThrow;
			Throw.performed -= instance.OnThrow;
			Throw.canceled -= instance.OnThrow;
			Interact.started -= instance.OnInteract;
			Interact.performed -= instance.OnInteract;
			Interact.canceled -= instance.OnInteract;
			RotateObject.started -= instance.OnRotateObject;
			RotateObject.performed -= instance.OnRotateObject;
			RotateObject.canceled -= instance.OnRotateObject;
			StartRotate.started -= instance.OnStartRotate;
			StartRotate.performed -= instance.OnStartRotate;
			StartRotate.canceled -= instance.OnStartRotate;
			ZoomOut.started -= instance.OnZoomOut;
			ZoomOut.performed -= instance.OnZoomOut;
			ZoomOut.canceled -= instance.OnZoomOut;
			ZoomIn.started -= instance.OnZoomIn;
			ZoomIn.performed -= instance.OnZoomIn;
			ZoomIn.canceled -= instance.OnZoomIn;
			Push.started -= instance.OnPush;
			Push.performed -= instance.OnPush;
			Push.canceled -= instance.OnPush;
		}

		public void RemoveCallbacks(IInteractionActions instance)
		{
			if (m_Wrapper.m_InteractionActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IInteractionActions instance)
		{
			foreach (IInteractionActions interactionActionsCallbackInterface in m_Wrapper.m_InteractionActionsCallbackInterfaces)
			{
				UnregisterCallbacks(interactionActionsCallbackInterface);
			}
			m_Wrapper.m_InteractionActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public interface IMoveActions
	{
		void OnMove(InputAction.CallbackContext context);

		void OnCrouch(InputAction.CallbackContext context);
	}

	public interface ILookActions
	{
		void OnLook(InputAction.CallbackContext context);
	}

	public interface IInteractionActions
	{
		void OnGrab(InputAction.CallbackContext context);

		void OnThrow(InputAction.CallbackContext context);

		void OnInteract(InputAction.CallbackContext context);

		void OnRotateObject(InputAction.CallbackContext context);

		void OnStartRotate(InputAction.CallbackContext context);

		void OnZoomOut(InputAction.CallbackContext context);

		void OnZoomIn(InputAction.CallbackContext context);

		void OnPush(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Move;

	private List<IMoveActions> m_MoveActionsCallbackInterfaces = new List<IMoveActions>();

	private readonly InputAction m_Move_Move;

	private readonly InputAction m_Move_Crouch;

	private readonly InputActionMap m_Look;

	private List<ILookActions> m_LookActionsCallbackInterfaces = new List<ILookActions>();

	private readonly InputAction m_Look_Look;

	private readonly InputActionMap m_Interaction;

	private List<IInteractionActions> m_InteractionActionsCallbackInterfaces = new List<IInteractionActions>();

	private readonly InputAction m_Interaction_Grab;

	private readonly InputAction m_Interaction_Throw;

	private readonly InputAction m_Interaction_Interact;

	private readonly InputAction m_Interaction_RotateObject;

	private readonly InputAction m_Interaction_StartRotate;

	private readonly InputAction m_Interaction_ZoomOut;

	private readonly InputAction m_Interaction_ZoomIn;

	private readonly InputAction m_Interaction_Push;

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

	public MoveActions Move => new MoveActions(this);

	public LookActions Look => new LookActions(this);

	public InteractionActions Interaction => new InteractionActions(this);

	public PlayerGrabInteractionSystem()
	{
		asset = InputActionAsset.FromJson("{\r\n    \"name\": \"PlayerGrabInteractionSystem\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Move\",\r\n            \"id\": \"9f6129f2-fae1-4b58-96bf-94b1103f92b2\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Move\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"8c01e6a3-8ff5-4e74-a962-a079a240689a\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Crouch\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"49fa532d-c9a0-46fe-adca-18736f074e68\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"0926d310-3be2-4b04-b06a-5dabe63c5f13\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"6b62d192-9f92-4c3f-9af5-67563bceb8dd\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"c24c115d-7ec0-4971-a0a9-091f7db5fd51\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"c1219817-4e05-48bf-a8bd-5b7594f1a758\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"22d3935f-7afb-472a-ae24-0472a3abbb96\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"aefb01be-1e6c-4f53-a3ec-e5f52cc9a871\",\r\n                    \"path\": \"<Keyboard>/leftCtrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Crouch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b6901e74-8799-43dd-b325-de8438b8a2a0\",\r\n                    \"path\": \"<Keyboard>/c\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Crouch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Look\",\r\n            \"id\": \"c4824b70-50c1-4d7d-a1d7-ba1190802b00\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Look\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"2e965793-9b58-4592-92ac-abda51472a39\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6ff39ba3-050a-4787-bfe7-1788e49605e5\",\r\n                    \"path\": \"<Mouse>/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Look\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Interaction\",\r\n            \"id\": \"49985f20-a173-4045-b935-44a8b8446244\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Grab\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"45530201-3048-44b0-a09f-338df7751573\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Throw\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"93c8658d-34f2-4657-9b6c-a407ee382d37\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Interact\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"5b19b8d4-b151-4359-bbd8-3e5d74e545dd\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RotateObject\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"5915ce51-9c0a-430f-841d-9a818f508794\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"StartRotate\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8dfbaa1f-ec9c-4e20-8e49-880de8695aa7\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ZoomOut\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"fb35ad79-3158-473a-8228-ca5f7ae4e1da\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ZoomIn\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"517f80e2-295f-4891-891e-352760d7ca63\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Push\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"3a28119b-a756-4a6c-8a7a-498adc5f134a\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ff4132aa-7761-4c16-b378-e819caf0fe97\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Grab\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c6d99a5d-1a77-46a0-9dd9-0fb3fdb95ae7\",\r\n                    \"path\": \"<Mouse>/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"RotateObject\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ef404bf5-3dc7-4ee7-abff-ee7fdeeae1a1\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Throw\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"5afbbf1d-0184-4aa2-9d29-2e4b1410b920\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Interact\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f74420f9-a2e0-4365-9651-da604fafe3e1\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"StartRotate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"46e1ae96-e980-43d4-81f6-7fb6bdc7fb7f\",\r\n                    \"path\": \"<Keyboard>/g\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Push\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9fe617e6-6d13-48eb-9a76-f5faff9be748\",\r\n                    \"path\": \"<Mouse>/scroll/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ZoomOut\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0676f014-9ab5-4dae-b957-6150462d1eb2\",\r\n                    \"path\": \"<Mouse>/scroll/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ZoomIn\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": []\r\n}");
		m_Move = asset.FindActionMap("Move", throwIfNotFound: true);
		m_Move_Move = m_Move.FindAction("Move", throwIfNotFound: true);
		m_Move_Crouch = m_Move.FindAction("Crouch", throwIfNotFound: true);
		m_Look = asset.FindActionMap("Look", throwIfNotFound: true);
		m_Look_Look = m_Look.FindAction("Look", throwIfNotFound: true);
		m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
		m_Interaction_Grab = m_Interaction.FindAction("Grab", throwIfNotFound: true);
		m_Interaction_Throw = m_Interaction.FindAction("Throw", throwIfNotFound: true);
		m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
		m_Interaction_RotateObject = m_Interaction.FindAction("RotateObject", throwIfNotFound: true);
		m_Interaction_StartRotate = m_Interaction.FindAction("StartRotate", throwIfNotFound: true);
		m_Interaction_ZoomOut = m_Interaction.FindAction("ZoomOut", throwIfNotFound: true);
		m_Interaction_ZoomIn = m_Interaction.FindAction("ZoomIn", throwIfNotFound: true);
		m_Interaction_Push = m_Interaction.FindAction("Push", throwIfNotFound: true);
	}

	~PlayerGrabInteractionSystem()
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

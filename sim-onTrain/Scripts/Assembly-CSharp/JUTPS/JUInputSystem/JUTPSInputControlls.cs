using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace JUTPS.JUInputSystem
{
	public class JUTPSInputControlls : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
	{
		public struct PlayerActions
		{
			private JUTPSInputControlls m_Wrapper;

			public InputAction Move => m_Wrapper.m_Player_Move;

			public InputAction Look => m_Wrapper.m_Player_Look;

			public InputAction Jump => m_Wrapper.m_Player_Jump;

			public InputAction Fire => m_Wrapper.m_Player_Fire;

			public InputAction Aim => m_Wrapper.m_Player_Aim;

			public InputAction Run => m_Wrapper.m_Player_Run;

			public InputAction Punch => m_Wrapper.m_Player_Punch;

			public InputAction Roll => m_Wrapper.m_Player_Roll;

			public InputAction Prone => m_Wrapper.m_Player_Prone;

			public InputAction Crouch => m_Wrapper.m_Player_Crouch;

			public InputAction Reload => m_Wrapper.m_Player_Reload;

			public InputAction Interact => m_Wrapper.m_Player_Interact;

			public InputAction Pickup => m_Wrapper.m_Player_Pickup;

			public InputAction OpenInventory => m_Wrapper.m_Player_OpenInventory;

			public InputAction Next => m_Wrapper.m_Player_Next;

			public InputAction Previous => m_Wrapper.m_Player_Previous;

			public InputAction MousePosition => m_Wrapper.m_Player_MousePosition;

			public InputAction Slot1 => m_Wrapper.m_Player_Slot1;

			public InputAction Slot2 => m_Wrapper.m_Player_Slot2;

			public InputAction Slot3 => m_Wrapper.m_Player_Slot3;

			public InputAction Slot4 => m_Wrapper.m_Player_Slot4;

			public InputAction Slot5 => m_Wrapper.m_Player_Slot5;

			public InputAction Slot6 => m_Wrapper.m_Player_Slot6;

			public InputAction Slot7 => m_Wrapper.m_Player_Slot7;

			public InputAction Slot8 => m_Wrapper.m_Player_Slot8;

			public InputAction Slot9 => m_Wrapper.m_Player_Slot9;

			public InputAction Slot10 => m_Wrapper.m_Player_Slot10;

			public bool enabled => Get().enabled;

			public PlayerActions(JUTPSInputControlls wrapper)
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
					Fire.started += instance.OnFire;
					Fire.performed += instance.OnFire;
					Fire.canceled += instance.OnFire;
					Aim.started += instance.OnAim;
					Aim.performed += instance.OnAim;
					Aim.canceled += instance.OnAim;
					Run.started += instance.OnRun;
					Run.performed += instance.OnRun;
					Run.canceled += instance.OnRun;
					Punch.started += instance.OnPunch;
					Punch.performed += instance.OnPunch;
					Punch.canceled += instance.OnPunch;
					Roll.started += instance.OnRoll;
					Roll.performed += instance.OnRoll;
					Roll.canceled += instance.OnRoll;
					Prone.started += instance.OnProne;
					Prone.performed += instance.OnProne;
					Prone.canceled += instance.OnProne;
					Crouch.started += instance.OnCrouch;
					Crouch.performed += instance.OnCrouch;
					Crouch.canceled += instance.OnCrouch;
					Reload.started += instance.OnReload;
					Reload.performed += instance.OnReload;
					Reload.canceled += instance.OnReload;
					Interact.started += instance.OnInteract;
					Interact.performed += instance.OnInteract;
					Interact.canceled += instance.OnInteract;
					Pickup.started += instance.OnPickup;
					Pickup.performed += instance.OnPickup;
					Pickup.canceled += instance.OnPickup;
					OpenInventory.started += instance.OnOpenInventory;
					OpenInventory.performed += instance.OnOpenInventory;
					OpenInventory.canceled += instance.OnOpenInventory;
					Next.started += instance.OnNext;
					Next.performed += instance.OnNext;
					Next.canceled += instance.OnNext;
					Previous.started += instance.OnPrevious;
					Previous.performed += instance.OnPrevious;
					Previous.canceled += instance.OnPrevious;
					MousePosition.started += instance.OnMousePosition;
					MousePosition.performed += instance.OnMousePosition;
					MousePosition.canceled += instance.OnMousePosition;
					Slot1.started += instance.OnSlot1;
					Slot1.performed += instance.OnSlot1;
					Slot1.canceled += instance.OnSlot1;
					Slot2.started += instance.OnSlot2;
					Slot2.performed += instance.OnSlot2;
					Slot2.canceled += instance.OnSlot2;
					Slot3.started += instance.OnSlot3;
					Slot3.performed += instance.OnSlot3;
					Slot3.canceled += instance.OnSlot3;
					Slot4.started += instance.OnSlot4;
					Slot4.performed += instance.OnSlot4;
					Slot4.canceled += instance.OnSlot4;
					Slot5.started += instance.OnSlot5;
					Slot5.performed += instance.OnSlot5;
					Slot5.canceled += instance.OnSlot5;
					Slot6.started += instance.OnSlot6;
					Slot6.performed += instance.OnSlot6;
					Slot6.canceled += instance.OnSlot6;
					Slot7.started += instance.OnSlot7;
					Slot7.performed += instance.OnSlot7;
					Slot7.canceled += instance.OnSlot7;
					Slot8.started += instance.OnSlot8;
					Slot8.performed += instance.OnSlot8;
					Slot8.canceled += instance.OnSlot8;
					Slot9.started += instance.OnSlot9;
					Slot9.performed += instance.OnSlot9;
					Slot9.canceled += instance.OnSlot9;
					Slot10.started += instance.OnSlot10;
					Slot10.performed += instance.OnSlot10;
					Slot10.canceled += instance.OnSlot10;
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
				Fire.started -= instance.OnFire;
				Fire.performed -= instance.OnFire;
				Fire.canceled -= instance.OnFire;
				Aim.started -= instance.OnAim;
				Aim.performed -= instance.OnAim;
				Aim.canceled -= instance.OnAim;
				Run.started -= instance.OnRun;
				Run.performed -= instance.OnRun;
				Run.canceled -= instance.OnRun;
				Punch.started -= instance.OnPunch;
				Punch.performed -= instance.OnPunch;
				Punch.canceled -= instance.OnPunch;
				Roll.started -= instance.OnRoll;
				Roll.performed -= instance.OnRoll;
				Roll.canceled -= instance.OnRoll;
				Prone.started -= instance.OnProne;
				Prone.performed -= instance.OnProne;
				Prone.canceled -= instance.OnProne;
				Crouch.started -= instance.OnCrouch;
				Crouch.performed -= instance.OnCrouch;
				Crouch.canceled -= instance.OnCrouch;
				Reload.started -= instance.OnReload;
				Reload.performed -= instance.OnReload;
				Reload.canceled -= instance.OnReload;
				Interact.started -= instance.OnInteract;
				Interact.performed -= instance.OnInteract;
				Interact.canceled -= instance.OnInteract;
				Pickup.started -= instance.OnPickup;
				Pickup.performed -= instance.OnPickup;
				Pickup.canceled -= instance.OnPickup;
				OpenInventory.started -= instance.OnOpenInventory;
				OpenInventory.performed -= instance.OnOpenInventory;
				OpenInventory.canceled -= instance.OnOpenInventory;
				Next.started -= instance.OnNext;
				Next.performed -= instance.OnNext;
				Next.canceled -= instance.OnNext;
				Previous.started -= instance.OnPrevious;
				Previous.performed -= instance.OnPrevious;
				Previous.canceled -= instance.OnPrevious;
				MousePosition.started -= instance.OnMousePosition;
				MousePosition.performed -= instance.OnMousePosition;
				MousePosition.canceled -= instance.OnMousePosition;
				Slot1.started -= instance.OnSlot1;
				Slot1.performed -= instance.OnSlot1;
				Slot1.canceled -= instance.OnSlot1;
				Slot2.started -= instance.OnSlot2;
				Slot2.performed -= instance.OnSlot2;
				Slot2.canceled -= instance.OnSlot2;
				Slot3.started -= instance.OnSlot3;
				Slot3.performed -= instance.OnSlot3;
				Slot3.canceled -= instance.OnSlot3;
				Slot4.started -= instance.OnSlot4;
				Slot4.performed -= instance.OnSlot4;
				Slot4.canceled -= instance.OnSlot4;
				Slot5.started -= instance.OnSlot5;
				Slot5.performed -= instance.OnSlot5;
				Slot5.canceled -= instance.OnSlot5;
				Slot6.started -= instance.OnSlot6;
				Slot6.performed -= instance.OnSlot6;
				Slot6.canceled -= instance.OnSlot6;
				Slot7.started -= instance.OnSlot7;
				Slot7.performed -= instance.OnSlot7;
				Slot7.canceled -= instance.OnSlot7;
				Slot8.started -= instance.OnSlot8;
				Slot8.performed -= instance.OnSlot8;
				Slot8.canceled -= instance.OnSlot8;
				Slot9.started -= instance.OnSlot9;
				Slot9.performed -= instance.OnSlot9;
				Slot9.canceled -= instance.OnSlot9;
				Slot10.started -= instance.OnSlot10;
				Slot10.performed -= instance.OnSlot10;
				Slot10.canceled -= instance.OnSlot10;
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

		public struct UIActions
		{
			private JUTPSInputControlls m_Wrapper;

			public InputAction Navigate => m_Wrapper.m_UI_Navigate;

			public InputAction Submit => m_Wrapper.m_UI_Submit;

			public InputAction Cancel => m_Wrapper.m_UI_Cancel;

			public InputAction Point => m_Wrapper.m_UI_Point;

			public InputAction Click => m_Wrapper.m_UI_Click;

			public InputAction ScrollWheel => m_Wrapper.m_UI_ScrollWheel;

			public InputAction MiddleClick => m_Wrapper.m_UI_MiddleClick;

			public InputAction RightClick => m_Wrapper.m_UI_RightClick;

			public InputAction TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;

			public InputAction TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;

			public bool enabled => Get().enabled;

			public UIActions(JUTPSInputControlls wrapper)
			{
				m_Wrapper = wrapper;
			}

			public InputActionMap Get()
			{
				return m_Wrapper.m_UI;
			}

			public void Enable()
			{
				Get().Enable();
			}

			public void Disable()
			{
				Get().Disable();
			}

			public static implicit operator InputActionMap(UIActions set)
			{
				return set.Get();
			}

			public void AddCallbacks(IUIActions instance)
			{
				if (instance != null && !m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance))
				{
					m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
					Navigate.started += instance.OnNavigate;
					Navigate.performed += instance.OnNavigate;
					Navigate.canceled += instance.OnNavigate;
					Submit.started += instance.OnSubmit;
					Submit.performed += instance.OnSubmit;
					Submit.canceled += instance.OnSubmit;
					Cancel.started += instance.OnCancel;
					Cancel.performed += instance.OnCancel;
					Cancel.canceled += instance.OnCancel;
					Point.started += instance.OnPoint;
					Point.performed += instance.OnPoint;
					Point.canceled += instance.OnPoint;
					Click.started += instance.OnClick;
					Click.performed += instance.OnClick;
					Click.canceled += instance.OnClick;
					ScrollWheel.started += instance.OnScrollWheel;
					ScrollWheel.performed += instance.OnScrollWheel;
					ScrollWheel.canceled += instance.OnScrollWheel;
					MiddleClick.started += instance.OnMiddleClick;
					MiddleClick.performed += instance.OnMiddleClick;
					MiddleClick.canceled += instance.OnMiddleClick;
					RightClick.started += instance.OnRightClick;
					RightClick.performed += instance.OnRightClick;
					RightClick.canceled += instance.OnRightClick;
					TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
					TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
					TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
					TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
					TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
					TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
				}
			}

			private void UnregisterCallbacks(IUIActions instance)
			{
				Navigate.started -= instance.OnNavigate;
				Navigate.performed -= instance.OnNavigate;
				Navigate.canceled -= instance.OnNavigate;
				Submit.started -= instance.OnSubmit;
				Submit.performed -= instance.OnSubmit;
				Submit.canceled -= instance.OnSubmit;
				Cancel.started -= instance.OnCancel;
				Cancel.performed -= instance.OnCancel;
				Cancel.canceled -= instance.OnCancel;
				Point.started -= instance.OnPoint;
				Point.performed -= instance.OnPoint;
				Point.canceled -= instance.OnPoint;
				Click.started -= instance.OnClick;
				Click.performed -= instance.OnClick;
				Click.canceled -= instance.OnClick;
				ScrollWheel.started -= instance.OnScrollWheel;
				ScrollWheel.performed -= instance.OnScrollWheel;
				ScrollWheel.canceled -= instance.OnScrollWheel;
				MiddleClick.started -= instance.OnMiddleClick;
				MiddleClick.performed -= instance.OnMiddleClick;
				MiddleClick.canceled -= instance.OnMiddleClick;
				RightClick.started -= instance.OnRightClick;
				RightClick.performed -= instance.OnRightClick;
				RightClick.canceled -= instance.OnRightClick;
				TrackedDevicePosition.started -= instance.OnTrackedDevicePosition;
				TrackedDevicePosition.performed -= instance.OnTrackedDevicePosition;
				TrackedDevicePosition.canceled -= instance.OnTrackedDevicePosition;
				TrackedDeviceOrientation.started -= instance.OnTrackedDeviceOrientation;
				TrackedDeviceOrientation.performed -= instance.OnTrackedDeviceOrientation;
				TrackedDeviceOrientation.canceled -= instance.OnTrackedDeviceOrientation;
			}

			public void RemoveCallbacks(IUIActions instance)
			{
				if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
				{
					UnregisterCallbacks(instance);
				}
			}

			public void SetCallbacks(IUIActions instance)
			{
				foreach (IUIActions uIActionsCallbackInterface in m_Wrapper.m_UIActionsCallbackInterfaces)
				{
					UnregisterCallbacks(uIActionsCallbackInterface);
				}
				m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
				AddCallbacks(instance);
			}
		}

		public interface IPlayerActions
		{
			void OnMove(InputAction.CallbackContext context);

			void OnLook(InputAction.CallbackContext context);

			void OnJump(InputAction.CallbackContext context);

			void OnFire(InputAction.CallbackContext context);

			void OnAim(InputAction.CallbackContext context);

			void OnRun(InputAction.CallbackContext context);

			void OnPunch(InputAction.CallbackContext context);

			void OnRoll(InputAction.CallbackContext context);

			void OnProne(InputAction.CallbackContext context);

			void OnCrouch(InputAction.CallbackContext context);

			void OnReload(InputAction.CallbackContext context);

			void OnInteract(InputAction.CallbackContext context);

			void OnPickup(InputAction.CallbackContext context);

			void OnOpenInventory(InputAction.CallbackContext context);

			void OnNext(InputAction.CallbackContext context);

			void OnPrevious(InputAction.CallbackContext context);

			void OnMousePosition(InputAction.CallbackContext context);

			void OnSlot1(InputAction.CallbackContext context);

			void OnSlot2(InputAction.CallbackContext context);

			void OnSlot3(InputAction.CallbackContext context);

			void OnSlot4(InputAction.CallbackContext context);

			void OnSlot5(InputAction.CallbackContext context);

			void OnSlot6(InputAction.CallbackContext context);

			void OnSlot7(InputAction.CallbackContext context);

			void OnSlot8(InputAction.CallbackContext context);

			void OnSlot9(InputAction.CallbackContext context);

			void OnSlot10(InputAction.CallbackContext context);
		}

		public interface IUIActions
		{
			void OnNavigate(InputAction.CallbackContext context);

			void OnSubmit(InputAction.CallbackContext context);

			void OnCancel(InputAction.CallbackContext context);

			void OnPoint(InputAction.CallbackContext context);

			void OnClick(InputAction.CallbackContext context);

			void OnScrollWheel(InputAction.CallbackContext context);

			void OnMiddleClick(InputAction.CallbackContext context);

			void OnRightClick(InputAction.CallbackContext context);

			void OnTrackedDevicePosition(InputAction.CallbackContext context);

			void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
		}

		private readonly InputActionMap m_Player;

		private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();

		private readonly InputAction m_Player_Move;

		private readonly InputAction m_Player_Look;

		private readonly InputAction m_Player_Jump;

		private readonly InputAction m_Player_Fire;

		private readonly InputAction m_Player_Aim;

		private readonly InputAction m_Player_Run;

		private readonly InputAction m_Player_Punch;

		private readonly InputAction m_Player_Roll;

		private readonly InputAction m_Player_Prone;

		private readonly InputAction m_Player_Crouch;

		private readonly InputAction m_Player_Reload;

		private readonly InputAction m_Player_Interact;

		private readonly InputAction m_Player_Pickup;

		private readonly InputAction m_Player_OpenInventory;

		private readonly InputAction m_Player_Next;

		private readonly InputAction m_Player_Previous;

		private readonly InputAction m_Player_MousePosition;

		private readonly InputAction m_Player_Slot1;

		private readonly InputAction m_Player_Slot2;

		private readonly InputAction m_Player_Slot3;

		private readonly InputAction m_Player_Slot4;

		private readonly InputAction m_Player_Slot5;

		private readonly InputAction m_Player_Slot6;

		private readonly InputAction m_Player_Slot7;

		private readonly InputAction m_Player_Slot8;

		private readonly InputAction m_Player_Slot9;

		private readonly InputAction m_Player_Slot10;

		private readonly InputActionMap m_UI;

		private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();

		private readonly InputAction m_UI_Navigate;

		private readonly InputAction m_UI_Submit;

		private readonly InputAction m_UI_Cancel;

		private readonly InputAction m_UI_Point;

		private readonly InputAction m_UI_Click;

		private readonly InputAction m_UI_ScrollWheel;

		private readonly InputAction m_UI_MiddleClick;

		private readonly InputAction m_UI_RightClick;

		private readonly InputAction m_UI_TrackedDevicePosition;

		private readonly InputAction m_UI_TrackedDeviceOrientation;

		private int m_KeyboardMouseSchemeIndex = -1;

		private int m_GamepadSchemeIndex = -1;

		private int m_TouchSchemeIndex = -1;

		private int m_JoystickSchemeIndex = -1;

		private int m_XRSchemeIndex = -1;

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

		public UIActions UI => new UIActions(this);

		public InputControlScheme KeyboardMouseScheme
		{
			get
			{
				if (m_KeyboardMouseSchemeIndex == -1)
				{
					m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
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

		public InputControlScheme TouchScheme
		{
			get
			{
				if (m_TouchSchemeIndex == -1)
				{
					m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
				}
				return asset.controlSchemes[m_TouchSchemeIndex];
			}
		}

		public InputControlScheme JoystickScheme
		{
			get
			{
				if (m_JoystickSchemeIndex == -1)
				{
					m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
				}
				return asset.controlSchemes[m_JoystickSchemeIndex];
			}
		}

		public InputControlScheme XRScheme
		{
			get
			{
				if (m_XRSchemeIndex == -1)
				{
					m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
				}
				return asset.controlSchemes[m_XRSchemeIndex];
			}
		}

		public JUTPSInputControlls()
		{
			asset = InputActionAsset.FromJson("{\r\n    \"name\": \"JUTPSInputControlls\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Player\",\r\n            \"id\": \"a0ae23dc-5c67-45d9-aa9d-86252c3e29ed\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Move\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"1af53fb5-c3f1-4dd9-885d-36b2d48cb125\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Look\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"1159d54a-8fff-471f-98c6-5e9f84ae0a87\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Jump\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2e0a2b0c-040c-4c24-90cf-b562c9aaab28\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Fire\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"063a1f26-d998-4f20-a2ef-b58ca11b97f6\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Aim\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"0fe379eb-95b9-42c9-b8ce-c165f2e234d1\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Run\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"43dff8ee-059e-4507-a5d4-af99ddb26ad9\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Punch\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"5f047d5e-39c4-44e6-87e0-fed3d9ec84cf\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Roll\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"9fef2ff8-82a6-4f02-923a-6c1247f8b315\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Prone\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"d8a90877-774e-4da6-b1fd-9cbf561ac7e7\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Crouch\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"d01232a0-e5cf-472f-bc24-dbeb27faa604\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Reload\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"550f5b6c-c6e1-43c9-a6f7-ddd9bfbea7cf\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Interact\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c3ad9ef6-a316-4ad5-872a-b858b5113526\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Pickup\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c64e5fc8-3955-473f-ba3c-27d58fb79fc5\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Open Inventory\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"cb8b467b-7be1-4fbe-aced-26c48cb470f5\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Next\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"10e867c8-9219-49c6-834f-27cd04dbae6e\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Previous\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8f361267-a454-4933-9d26-43a75045d8cb\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Mouse Position\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"c5027329-b8f0-4b9c-aab3-29f32248c0f6\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Slot1\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"3a8fa994-9689-468c-b9b2-a56a62be1009\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot2\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"5b3b77b4-c751-4746-b875-621600be6fa3\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot3\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2e63e1b3-e963-41ad-89d5-71a985b750cf\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot4\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"f8c8567c-b5b0-47d7-977c-439703445940\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot5\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"be1a5f0a-90ff-4dc9-9cc5-d4484610b6a3\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot6\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"71646eb1-67bc-40b6-a003-486f1ba4bcf7\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot7\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"9d1226da-79de-49c9-abfc-c235994a5bd0\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot8\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"49b6634a-6e85-41b9-94a2-9da690729edb\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot9\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"283a8134-f860-486f-8d9c-86b01afae96f\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Slot10\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"7747d8b0-72ae-4d36-997f-8ed9e5ee10f7\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"978bfe49-cc26-4a3d-ab7b-7d7a29327403\",\r\n                    \"path\": \"<Gamepad>/leftStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"StickDeadzone(max=1)\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"WASD\",\r\n                    \"id\": \"00ca640b-d935-4593-8157-c05846ea39b3\",\r\n                    \"path\": \"Dpad\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"StickDeadzone(max=1)\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"e2062cb9-1b15-46a2-838c-2f8d72a0bdd9\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"8180e8bd-4097-4f4e-ab88-4523101a6ce9\",\r\n                    \"path\": \"<Keyboard>/upArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"320bffee-a40b-4347-ac70-c210eb8bc73a\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"1c5327b5-f71c-4f60-99c7-4e737386f1d1\",\r\n                    \"path\": \"<Keyboard>/downArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"d2581a9b-1d11-4566-b27d-b92aff5fabbc\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"2e46982e-44cc-431b-9f0b-c11910bf467a\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"fcfe95b8-67b9-4526-84b5-5d0bc98d6400\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"77bff152-3580-4b21-b6de-dcd0c7e41164\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1635d3fe-58b6-4ba9-a4e2-f4b964f6b5c8\",\r\n                    \"path\": \"<XRController>/{Primary2DAxis}\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"StickDeadzone(max=1)\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3ea4d645-4504-4529-b061-ab81934c3752\",\r\n                    \"path\": \"<Joystick>/stick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"StickDeadzone(max=0.925)\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Move\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8c8e490b-c610-4785-884f-f04217b23ca4\",\r\n                    \"path\": \"<Pointer>/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"ScaleVector2(x=0.1,y=0.05)\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Look\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"143bb1cd-cc10-4eca-a2f0-a3664166fe91\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Fire\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"05f6913d-c316-48b2-a6bb-e225f14c7960\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Fire\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"886e731e-7071-4ae4-95c0-e61739dad6fd\",\r\n                    \"path\": \"<Touchscreen>/primaryTouch/tap\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Touch\",\r\n                    \"action\": \"Fire\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ee3d0cd2-254e-47a7-a8cb-bc94d9658c54\",\r\n                    \"path\": \"<Joystick>/trigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Fire\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8255d333-5683-4943-a58a-ccb207ff1dce\",\r\n                    \"path\": \"<XRController>/{PrimaryAction}\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"Fire\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"15e7598f-0be5-401f-ba62-d73688ffd6d4\",\r\n                    \"path\": \"<Keyboard>/ctrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Roll\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9314414d-1863-4870-a58f-c88f145ff9ac\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Roll\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b004e5a1-8718-488a-ac2c-ecb4869bb379\",\r\n                    \"path\": \"<Keyboard>/z\",\r\n                    \"interactions\": \"Press\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Prone\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3bc6585a-8a4f-4148-95ff-48e23442f5a9\",\r\n                    \"path\": \"<Gamepad>/dpad/down\",\r\n                    \"interactions\": \"Hold\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Prone\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"582d0972-ef75-4ed6-b02d-b9b3bd0fd5bd\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Next\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"85263253-7c28-49d6-b635-e30de38c2e35\",\r\n                    \"path\": \"<Gamepad>/dpad/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Next\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d9220014-5c73-49d9-89e7-1df1713b2f9c\",\r\n                    \"path\": \"<Gamepad>/leftStickPress\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Run\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"98b8ec44-dab3-4568-9d0d-30ee13e2de9a\",\r\n                    \"path\": \"<Keyboard>/shift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Run\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3937fa9f-e0e8-4b81-95df-0cf78f8a2b04\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Aim\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"faafef29-a726-4bfd-8a8e-39903fe003f6\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Aim\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b5cad117-7102-4851-ace6-623948d8821a\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Jump\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"57f0506a-d74f-40e0-bf2f-57f96752a816\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Jump\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4e88c8cb-397c-49c5-934f-c065b242d94d\",\r\n                    \"path\": \"<Gamepad>/rightStick\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"ScaleVector2(y=0.6)\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Look\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e12f5761-ce34-4374-9f36-50a073244524\",\r\n                    \"path\": \"<Gamepad>/dpad/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Crouch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8861427a-6783-4fd9-aa51-bb6b42119c8a\",\r\n                    \"path\": \"<Keyboard>/c\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Crouch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bb2e1b62-f2da-4e99-ae9d-dce1c14fb686\",\r\n                    \"path\": \"<Gamepad>/dpad/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Open Inventory\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"81837eca-ed82-4ea8-b91f-38b756f50fde\",\r\n                    \"path\": \"<Keyboard>/tab\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Open Inventory\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2399d236-ae65-4246-bffe-7f663ecefc24\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Reload\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"49ae7e10-899d-4c08-bf59-3d05f1b90d12\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Reload\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0aaffed9-1326-42fb-af8f-85bc87db9d42\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Interact\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7c54eaf6-da0a-4a1c-a211-d062cf51a94d\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Interact\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ee131511-dfd4-4c7f-ba48-ba10bdee46b4\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Pickup\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bc75d438-efd5-4482-98bc-93bd833eae42\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Pickup\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"eb65d9b1-7224-45d8-bbba-70dffba128ed\",\r\n                    \"path\": \"<Mouse>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Mouse Position\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2c61d3cb-499a-4d99-aa46-f39b322ec9ea\",\r\n                    \"path\": \"<Keyboard>/q\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Previous\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"f361e82c-d17c-46a8-8b94-0770971476a9\",\r\n                    \"path\": \"<Gamepad>/dpad/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Previous\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9c9b9a8b-227a-43de-a1cc-7c6df536e553\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Punch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6f40e7f8-5aeb-49ab-8ccf-d4f5a6317a40\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Gamepad\",\r\n                    \"action\": \"Punch\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e33cee41-cbb5-4335-a045-9b6d09b9663b\",\r\n                    \"path\": \"<Keyboard>/1\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot1\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"383dfe37-bb08-4fbb-8776-83c6c1fd097e\",\r\n                    \"path\": \"<Keyboard>/2\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot2\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"0e8cf112-f918-4c30-b8fd-778735bab97c\",\r\n                    \"path\": \"<Keyboard>/3\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot3\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c2900dbe-19c8-4f2f-9582-dc4420ed7ed8\",\r\n                    \"path\": \"<Keyboard>/4\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot4\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9dbd0cce-ca21-459a-bf72-454361263029\",\r\n                    \"path\": \"<Keyboard>/5\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot5\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"03a9d4a5-96a4-4fa0-a81e-55234b0ef25a\",\r\n                    \"path\": \"<Keyboard>/6\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot6\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a55a90b4-662a-47f6-87c1-64508c53ad21\",\r\n                    \"path\": \"<Keyboard>/7\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot7\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b3408c46-9a72-4a21-b4e9-ff1298d0b949\",\r\n                    \"path\": \"<Keyboard>/8\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot8\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"1312fe50-0cfa-424d-9494-78bca16b3666\",\r\n                    \"path\": \"<Keyboard>/9\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot9\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"68b6b30a-79a0-49f0-82ee-c4bf25db758c\",\r\n                    \"path\": \"<Keyboard>/0\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Slot10\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"UI\",\r\n            \"id\": \"de720d52-7ecb-445a-9bbe-1e80559bca8b\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Navigate\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"25b7f957-93a6-474b-9684-29b3e1ad7784\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Submit\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"7fcd0736-3054-4c6c-a227-d8fd423dad40\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Cancel\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"205ed331-a95a-4d1b-b3f8-7bb9ee51c6d5\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Point\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"d9b10c3a-1698-4838-951f-6e965445abc8\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Click\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"753b30ee-302e-4144-a15d-ca44dd678594\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ScrollWheel\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"e9c66422-6426-4cda-870f-25c78f6cffad\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"MiddleClick\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"a2988bcf-8134-46bc-b6c8-8c1c90fef2f3\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RightClick\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"0b22c352-47f4-47d5-9eb9-e129e1f55d89\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TrackedDevicePosition\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"ce4419a5-4aef-49a8-878a-2dc5679c9a5c\",\r\n                    \"expectedControlType\": \"Vector3\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TrackedDeviceOrientation\",\r\n                    \"type\": \"PassThrough\",\r\n                    \"id\": \"2445883b-1464-4fdf-ac97-01c3460be12b\",\r\n                    \"expectedControlType\": \"Quaternion\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"809f371f-c5e2-4e7a-83a1-d867598f40dd\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"14a5d6e8-4aaf-4119-a9ef-34b8c2c548bf\",\r\n                    \"path\": \"<Gamepad>/leftStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"9144cbe6-05e1-4687-a6d7-24f99d23dd81\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"2db08d65-c5fb-421b-983f-c71163608d67\",\r\n                    \"path\": \"<Gamepad>/leftStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"58748904-2ea9-4a80-8579-b500e6a76df8\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"8ba04515-75aa-45de-966d-393d9bbd1c14\",\r\n                    \"path\": \"<Gamepad>/leftStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"712e721c-bdfb-4b23-a86c-a0d9fcfea921\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"fcd248ae-a788-4676-a12e-f4d81205600b\",\r\n                    \"path\": \"<Gamepad>/leftStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"1f04d9bc-c50b-41a1-bfcc-afb75475ec20\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"fb8277d4-c5cd-4663-9dc7-ee3f0b506d90\",\r\n                    \"path\": \"<Gamepad>/dpad\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Gamepad\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Joystick\",\r\n                    \"id\": \"e25d9774-381c-4a61-b47c-7b6b299ad9f9\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"3db53b26-6601-41be-9887-63ac74e79d19\",\r\n                    \"path\": \"<Joystick>/stick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"0cb3e13e-3d90-4178-8ae6-d9c5501d653f\",\r\n                    \"path\": \"<Joystick>/stick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"0392d399-f6dd-4c82-8062-c1e9c0d34835\",\r\n                    \"path\": \"<Joystick>/stick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"942a66d9-d42f-43d6-8d70-ecb4ba5363bc\",\r\n                    \"path\": \"<Joystick>/stick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Joystick\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"ff527021-f211-4c02-933e-5976594c46ed\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"563fbfdd-0f09-408d-aa75-8642c4f08ef0\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"eb480147-c587-4a33-85ed-eb0ab9942c43\",\r\n                    \"path\": \"<Keyboard>/upArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"2bf42165-60bc-42ca-8072-8c13ab40239b\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"85d264ad-e0a0-4565-b7ff-1a37edde51ac\",\r\n                    \"path\": \"<Keyboard>/downArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"74214943-c580-44e4-98eb-ad7eebe17902\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"cea9b045-a000-445b-95b8-0c171af70a3b\",\r\n                    \"path\": \"<Keyboard>/leftArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"8607c725-d935-4808-84b1-8354e29bab63\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"4cda81dc-9edd-4e03-9d7c-a71a14345d0b\",\r\n                    \"path\": \"<Keyboard>/rightArrow\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Navigate\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9e92bb26-7e3b-4ec4-b06b-3c8f8e498ddc\",\r\n                    \"path\": \"*/{Submit}\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Submit\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"82627dcc-3b13-4ba9-841d-e4b746d6553e\",\r\n                    \"path\": \"*/{Cancel}\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Cancel\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c52c8e0b-8179-41d3-b8a1-d149033bbe86\",\r\n                    \"path\": \"<Mouse>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Point\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"e1394cbc-336e-44ce-9ea8-6007ed6193f7\",\r\n                    \"path\": \"<Pen>/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Keyboard&Mouse\",\r\n                    \"action\": \"Point\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"5693e57a-238a-46ed-b5ae-e64e6e574302\",\r\n                    \"path\": \"<Touchscreen>/touch*/position\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Touch\",\r\n                    \"action\": \"Point\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4faf7dc9-b979-4210-aa8c-e808e1ef89f5\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8d66d5ba-88d7-48e6-b1cd-198bbfef7ace\",\r\n                    \"path\": \"<Pen>/tip\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"47c2a644-3ebc-4dae-a106-589b7ca75b59\",\r\n                    \"path\": \"<Touchscreen>/touch*/press\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"Touch\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"bb9e6b34-44bf-4381-ac63-5aa15d19f677\",\r\n                    \"path\": \"<XRController>/trigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"Click\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"38c99815-14ea-4617-8627-164d27641299\",\r\n                    \"path\": \"<Mouse>/scroll\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"ScrollWheel\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"24066f69-da47-44f3-a07e-0015fb02eb2e\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"MiddleClick\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4c191405-5738-4d4b-a523-c6a301dbf754\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \";Keyboard&Mouse\",\r\n                    \"action\": \"RightClick\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"7236c0d9-6ca3-47cf-a6ee-a97f5b59ea77\",\r\n                    \"path\": \"<XRController>/devicePosition\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"TrackedDevicePosition\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"23e01e3a-f935-4948-8d8b-9bcac77714fb\",\r\n                    \"path\": \"<XRController>/deviceRotation\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"XR\",\r\n                    \"action\": \"TrackedDeviceOrientation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": [\r\n        {\r\n            \"name\": \"Keyboard&Mouse\",\r\n            \"bindingGroup\": \"Keyboard&Mouse\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Keyboard>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                },\r\n                {\r\n                    \"devicePath\": \"<Mouse>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Gamepad\",\r\n            \"bindingGroup\": \"Gamepad\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Gamepad>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Touch\",\r\n            \"bindingGroup\": \"Touch\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Touchscreen>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"Joystick\",\r\n            \"bindingGroup\": \"Joystick\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<Joystick>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"XR\",\r\n            \"bindingGroup\": \"XR\",\r\n            \"devices\": [\r\n                {\r\n                    \"devicePath\": \"<XRController>\",\r\n                    \"isOptional\": false,\r\n                    \"isOR\": false\r\n                }\r\n            ]\r\n        }\r\n    ]\r\n}");
			m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
			m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
			m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
			m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
			m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
			m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
			m_Player_Run = m_Player.FindAction("Run", throwIfNotFound: true);
			m_Player_Punch = m_Player.FindAction("Punch", throwIfNotFound: true);
			m_Player_Roll = m_Player.FindAction("Roll", throwIfNotFound: true);
			m_Player_Prone = m_Player.FindAction("Prone", throwIfNotFound: true);
			m_Player_Crouch = m_Player.FindAction("Crouch", throwIfNotFound: true);
			m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
			m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
			m_Player_Pickup = m_Player.FindAction("Pickup", throwIfNotFound: true);
			m_Player_OpenInventory = m_Player.FindAction("Open Inventory", throwIfNotFound: true);
			m_Player_Next = m_Player.FindAction("Next", throwIfNotFound: true);
			m_Player_Previous = m_Player.FindAction("Previous", throwIfNotFound: true);
			m_Player_MousePosition = m_Player.FindAction("Mouse Position", throwIfNotFound: true);
			m_Player_Slot1 = m_Player.FindAction("Slot1", throwIfNotFound: true);
			m_Player_Slot2 = m_Player.FindAction("Slot2", throwIfNotFound: true);
			m_Player_Slot3 = m_Player.FindAction("Slot3", throwIfNotFound: true);
			m_Player_Slot4 = m_Player.FindAction("Slot4", throwIfNotFound: true);
			m_Player_Slot5 = m_Player.FindAction("Slot5", throwIfNotFound: true);
			m_Player_Slot6 = m_Player.FindAction("Slot6", throwIfNotFound: true);
			m_Player_Slot7 = m_Player.FindAction("Slot7", throwIfNotFound: true);
			m_Player_Slot8 = m_Player.FindAction("Slot8", throwIfNotFound: true);
			m_Player_Slot9 = m_Player.FindAction("Slot9", throwIfNotFound: true);
			m_Player_Slot10 = m_Player.FindAction("Slot10", throwIfNotFound: true);
			m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
			m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
			m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
			m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
			m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
			m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
			m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
			m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
			m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
			m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
			m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
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
}

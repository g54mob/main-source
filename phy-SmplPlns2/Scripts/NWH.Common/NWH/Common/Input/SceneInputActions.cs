using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NWH.Common.Input
{
	public class SceneInputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
	{
		public struct CameraControlsActions
		{
			private SceneInputActions m_Wrapper;

			public InputAction ChangeCamera => m_Wrapper.m_CameraControls_ChangeCamera;

			public InputAction CameraRotation => m_Wrapper.m_CameraControls_CameraRotation;

			public InputAction CameraPanning => m_Wrapper.m_CameraControls_CameraPanning;

			public InputAction CameraRotationModifier => m_Wrapper.m_CameraControls_CameraRotationModifier;

			public InputAction CameraPanningModifier => m_Wrapper.m_CameraControls_CameraPanningModifier;

			public InputAction CameraZoom => m_Wrapper.m_CameraControls_CameraZoom;

			public bool enabled => Get().enabled;

			public CameraControlsActions(SceneInputActions wrapper)
			{
				m_Wrapper = wrapper;
			}

			public InputActionMap Get()
			{
				return m_Wrapper.m_CameraControls;
			}

			public void Enable()
			{
				Get().Enable();
			}

			public void Disable()
			{
				Get().Disable();
			}

			public static implicit operator InputActionMap(CameraControlsActions set)
			{
				return set.Get();
			}

			public void AddCallbacks(ICameraControlsActions instance)
			{
				if (instance != null && !m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Contains(instance))
				{
					m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Add(instance);
					ChangeCamera.started += instance.OnChangeCamera;
					ChangeCamera.performed += instance.OnChangeCamera;
					ChangeCamera.canceled += instance.OnChangeCamera;
					CameraRotation.started += instance.OnCameraRotation;
					CameraRotation.performed += instance.OnCameraRotation;
					CameraRotation.canceled += instance.OnCameraRotation;
					CameraPanning.started += instance.OnCameraPanning;
					CameraPanning.performed += instance.OnCameraPanning;
					CameraPanning.canceled += instance.OnCameraPanning;
					CameraRotationModifier.started += instance.OnCameraRotationModifier;
					CameraRotationModifier.performed += instance.OnCameraRotationModifier;
					CameraRotationModifier.canceled += instance.OnCameraRotationModifier;
					CameraPanningModifier.started += instance.OnCameraPanningModifier;
					CameraPanningModifier.performed += instance.OnCameraPanningModifier;
					CameraPanningModifier.canceled += instance.OnCameraPanningModifier;
					CameraZoom.started += instance.OnCameraZoom;
					CameraZoom.performed += instance.OnCameraZoom;
					CameraZoom.canceled += instance.OnCameraZoom;
				}
			}

			private void UnregisterCallbacks(ICameraControlsActions instance)
			{
				ChangeCamera.started -= instance.OnChangeCamera;
				ChangeCamera.performed -= instance.OnChangeCamera;
				ChangeCamera.canceled -= instance.OnChangeCamera;
				CameraRotation.started -= instance.OnCameraRotation;
				CameraRotation.performed -= instance.OnCameraRotation;
				CameraRotation.canceled -= instance.OnCameraRotation;
				CameraPanning.started -= instance.OnCameraPanning;
				CameraPanning.performed -= instance.OnCameraPanning;
				CameraPanning.canceled -= instance.OnCameraPanning;
				CameraRotationModifier.started -= instance.OnCameraRotationModifier;
				CameraRotationModifier.performed -= instance.OnCameraRotationModifier;
				CameraRotationModifier.canceled -= instance.OnCameraRotationModifier;
				CameraPanningModifier.started -= instance.OnCameraPanningModifier;
				CameraPanningModifier.performed -= instance.OnCameraPanningModifier;
				CameraPanningModifier.canceled -= instance.OnCameraPanningModifier;
				CameraZoom.started -= instance.OnCameraZoom;
				CameraZoom.performed -= instance.OnCameraZoom;
				CameraZoom.canceled -= instance.OnCameraZoom;
			}

			public void RemoveCallbacks(ICameraControlsActions instance)
			{
				if (m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Remove(instance))
				{
					UnregisterCallbacks(instance);
				}
			}

			public void SetCallbacks(ICameraControlsActions instance)
			{
				foreach (ICameraControlsActions cameraControlsActionsCallbackInterface in m_Wrapper.m_CameraControlsActionsCallbackInterfaces)
				{
					UnregisterCallbacks(cameraControlsActionsCallbackInterface);
				}
				m_Wrapper.m_CameraControlsActionsCallbackInterfaces.Clear();
				AddCallbacks(instance);
			}
		}

		public struct SceneControlsActions
		{
			private SceneInputActions m_Wrapper;

			public InputAction ChangeVehicle => m_Wrapper.m_SceneControls_ChangeVehicle;

			public InputAction FPSMovement => m_Wrapper.m_SceneControls_FPSMovement;

			public InputAction ToggleGUI => m_Wrapper.m_SceneControls_ToggleGUI;

			public InputAction DragObjectModifier => m_Wrapper.m_SceneControls_DragObjectModifier;

			public InputAction ShowCursor => m_Wrapper.m_SceneControls_ShowCursor;

			public bool enabled => Get().enabled;

			public SceneControlsActions(SceneInputActions wrapper)
			{
				m_Wrapper = wrapper;
			}

			public InputActionMap Get()
			{
				return m_Wrapper.m_SceneControls;
			}

			public void Enable()
			{
				Get().Enable();
			}

			public void Disable()
			{
				Get().Disable();
			}

			public static implicit operator InputActionMap(SceneControlsActions set)
			{
				return set.Get();
			}

			public void AddCallbacks(ISceneControlsActions instance)
			{
				if (instance != null && !m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Contains(instance))
				{
					m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Add(instance);
					ChangeVehicle.started += instance.OnChangeVehicle;
					ChangeVehicle.performed += instance.OnChangeVehicle;
					ChangeVehicle.canceled += instance.OnChangeVehicle;
					FPSMovement.started += instance.OnFPSMovement;
					FPSMovement.performed += instance.OnFPSMovement;
					FPSMovement.canceled += instance.OnFPSMovement;
					ToggleGUI.started += instance.OnToggleGUI;
					ToggleGUI.performed += instance.OnToggleGUI;
					ToggleGUI.canceled += instance.OnToggleGUI;
					DragObjectModifier.started += instance.OnDragObjectModifier;
					DragObjectModifier.performed += instance.OnDragObjectModifier;
					DragObjectModifier.canceled += instance.OnDragObjectModifier;
					ShowCursor.started += instance.OnShowCursor;
					ShowCursor.performed += instance.OnShowCursor;
					ShowCursor.canceled += instance.OnShowCursor;
				}
			}

			private void UnregisterCallbacks(ISceneControlsActions instance)
			{
				ChangeVehicle.started -= instance.OnChangeVehicle;
				ChangeVehicle.performed -= instance.OnChangeVehicle;
				ChangeVehicle.canceled -= instance.OnChangeVehicle;
				FPSMovement.started -= instance.OnFPSMovement;
				FPSMovement.performed -= instance.OnFPSMovement;
				FPSMovement.canceled -= instance.OnFPSMovement;
				ToggleGUI.started -= instance.OnToggleGUI;
				ToggleGUI.performed -= instance.OnToggleGUI;
				ToggleGUI.canceled -= instance.OnToggleGUI;
				DragObjectModifier.started -= instance.OnDragObjectModifier;
				DragObjectModifier.performed -= instance.OnDragObjectModifier;
				DragObjectModifier.canceled -= instance.OnDragObjectModifier;
				ShowCursor.started -= instance.OnShowCursor;
				ShowCursor.performed -= instance.OnShowCursor;
				ShowCursor.canceled -= instance.OnShowCursor;
			}

			public void RemoveCallbacks(ISceneControlsActions instance)
			{
				if (m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Remove(instance))
				{
					UnregisterCallbacks(instance);
				}
			}

			public void SetCallbacks(ISceneControlsActions instance)
			{
				foreach (ISceneControlsActions sceneControlsActionsCallbackInterface in m_Wrapper.m_SceneControlsActionsCallbackInterfaces)
				{
					UnregisterCallbacks(sceneControlsActionsCallbackInterface);
				}
				m_Wrapper.m_SceneControlsActionsCallbackInterfaces.Clear();
				AddCallbacks(instance);
			}
		}

		public interface ICameraControlsActions
		{
			void OnChangeCamera(InputAction.CallbackContext context);

			void OnCameraRotation(InputAction.CallbackContext context);

			void OnCameraPanning(InputAction.CallbackContext context);

			void OnCameraRotationModifier(InputAction.CallbackContext context);

			void OnCameraPanningModifier(InputAction.CallbackContext context);

			void OnCameraZoom(InputAction.CallbackContext context);
		}

		public interface ISceneControlsActions
		{
			void OnChangeVehicle(InputAction.CallbackContext context);

			void OnFPSMovement(InputAction.CallbackContext context);

			void OnToggleGUI(InputAction.CallbackContext context);

			void OnDragObjectModifier(InputAction.CallbackContext context);

			void OnShowCursor(InputAction.CallbackContext context);
		}

		private readonly InputActionMap m_CameraControls;

		private List<ICameraControlsActions> m_CameraControlsActionsCallbackInterfaces = new List<ICameraControlsActions>();

		private readonly InputAction m_CameraControls_ChangeCamera;

		private readonly InputAction m_CameraControls_CameraRotation;

		private readonly InputAction m_CameraControls_CameraPanning;

		private readonly InputAction m_CameraControls_CameraRotationModifier;

		private readonly InputAction m_CameraControls_CameraPanningModifier;

		private readonly InputAction m_CameraControls_CameraZoom;

		private readonly InputActionMap m_SceneControls;

		private List<ISceneControlsActions> m_SceneControlsActionsCallbackInterfaces = new List<ISceneControlsActions>();

		private readonly InputAction m_SceneControls_ChangeVehicle;

		private readonly InputAction m_SceneControls_FPSMovement;

		private readonly InputAction m_SceneControls_ToggleGUI;

		private readonly InputAction m_SceneControls_DragObjectModifier;

		private readonly InputAction m_SceneControls_ShowCursor;

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

		public CameraControlsActions CameraControls => new CameraControlsActions(this);

		public SceneControlsActions SceneControls => new SceneControlsActions(this);

		public SceneInputActions()
		{
			asset = InputActionAsset.FromJson("{\r\n    \"version\": 1,\r\n    \"name\": \"SceneInputActions\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"CameraControls\",\r\n            \"id\": \"f9b2c2eb-8265-4430-a0ac-4cf8495a2002\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"ChangeCamera\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"71ec0b0c-0911-4b04-a2cc-424b01ebe88e\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"CameraRotation\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"8f870466-b390-4fae-a439-ccb19a4537c2\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"CameraPanning\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"08d3e09d-7ab8-4f42-976a-530f947fe4c8\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"CameraRotationModifier\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"124e3374-e4a2-4e74-b0cf-c8959a11ac39\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"CameraPanningModifier\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"ce8eda53-b48a-45c4-83c7-3f0b44ad36f7\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"CameraZoom\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"018cdf61-e865-49da-9064-33dc2ae63580\",\r\n                    \"expectedControlType\": \"Analog\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"24fa1b4b-fa43-49bc-ba60-3aedbe8d6c1f\",\r\n                    \"path\": \"<Keyboard>/c\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChangeCamera\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"530b85ac-4cae-49f9-804b-3a0dbaeb4a7b\",\r\n                    \"path\": \"<Gamepad>/start\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChangeCamera\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6d0ae04c-f252-4dd6-824a-27baa3d26db7\",\r\n                    \"path\": \"<Mouse>/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"ScaleVector2(x=0.2,y=0.2)\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"2cb8a8bc-5e28-4393-bc30-fe55c9d9ffc7\",\r\n                    \"path\": \"2DVector(mode=2)\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"InvertVector2\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"a144950a-0314-41fb-b0a3-0fa7943d12f1\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"a039c90a-129d-43ea-b2ec-bffde20e618a\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"e78f01bc-414a-4ba8-83e0-02deb5f631c6\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"3cd6cbde-a6f8-4da4-8cc2-9c8c1edc133e\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotation\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9e78c527-4641-4f9b-98e4-fb7f87edf64d\",\r\n                    \"path\": \"<Mouse>/delta\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"ScaleVector2(x=0.2,y=0.2)\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanning\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3968d956-a143-403b-87e5-0b91afb999eb\",\r\n                    \"path\": \"<Mouse>/leftButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotationModifier\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8f3a4e0e-6782-4b53-8c26-e06e68d8e1ee\",\r\n                    \"path\": \"<Gamepad>/rightStickPress\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraRotationModifier\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"8a15b75c-fd20-4def-8b73-5d8273fe3364\",\r\n                    \"path\": \"<Mouse>/rightButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanningModifier\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"dee7ac85-80d0-4018-bbe7-114eecc930ae\",\r\n                    \"path\": \"<Gamepad>/leftStickPress\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanningModifier\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"93e86e22-3ea3-4e7f-b800-9fc9575e9190\",\r\n                    \"path\": \"2DVector\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"InvertVector2\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanning\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"9e35bef4-dec2-47ce-a040-063273bd2183\",\r\n                    \"path\": \"<Gamepad>/rightStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanning\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"ca312712-12f3-438c-a542-d998b4fca387\",\r\n                    \"path\": \"<Gamepad>/rightStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanning\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"16a19e86-eb75-40ef-a937-cc69f5c57971\",\r\n                    \"path\": \"<Gamepad>/rightStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanning\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"338131ba-47f8-4fc8-b137-39be986200ed\",\r\n                    \"path\": \"<Gamepad>/rightStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraPanning\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2553a5ac-0892-4d77-a408-8b5fced329a8\",\r\n                    \"path\": \"<Mouse>/scroll/y\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"Scale(factor=0.1)\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"aeaabcc3-6825-4a24-b1b3-13b3a70fff59\",\r\n                    \"path\": \"1DAxis(whichSideWins=1)\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"d55890ea-00d2-483e-9b0a-e2ba85f4b2dd\",\r\n                    \"path\": \"<Gamepad>/dpad/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"3ce859ed-6297-4bab-b40b-d6436bacd5ab\",\r\n                    \"path\": \"<Gamepad>/dpad/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CameraZoom\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                }\r\n            ]\r\n        },\r\n        {\r\n            \"name\": \"SceneControls\",\r\n            \"id\": \"abb87e97-bffa-439c-a42d-7b1a9497c4cc\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"ChangeVehicle\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"a6ddd2a4-de73-4949-8b79-fef6d4b4bc3f\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"FPSMovement\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"347a1c7d-d6ca-4838-9d67-ca3bece4074f\",\r\n                    \"expectedControlType\": \"Vector2\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"ToggleGUI\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"420fdb48-6cea-444b-8cd6-256097129d3b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"DragObjectModifier\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"1fd9ef37-8fcf-43c4-9b96-ed432f843af4\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShowCursor\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4566d436-6301-4d31-bd9b-984b19b6cc9b\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"02e5b759-a74a-41e1-af72-80c6990f0d95\",\r\n                    \"path\": \"<Keyboard>/v\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChangeVehicle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"01597fdb-29e0-4e77-a920-ba59240fe6d6\",\r\n                    \"path\": \"<Gamepad>/select\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ChangeVehicle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"59431748-63e9-4210-8dd9-590e23bcdf0c\",\r\n                    \"path\": \"2DVector(mode=1)\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"e0b8875d-06d4-467d-b8f0-61da2e804895\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"87e4ea7c-c07f-491e-8dc6-36f79dbf9805\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"9bba77a1-921c-493d-b881-6f14f1eb377b\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"cfa4cf6d-3fe9-4930-847f-b59a8277a8fc\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"208efade-fdb9-49b9-a679-eb44b6ed6ac2\",\r\n                    \"path\": \"2DVector(mode=2)\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"up\",\r\n                    \"id\": \"8087e701-d9e1-454b-8b70-50813a31516b\",\r\n                    \"path\": \"<Gamepad>/leftStick/up\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"down\",\r\n                    \"id\": \"0b594ea6-b48c-4805-9cea-77058ade6d6a\",\r\n                    \"path\": \"<Gamepad>/leftStick/down\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"left\",\r\n                    \"id\": \"e7548400-0520-4980-aded-b6d0ac753e4a\",\r\n                    \"path\": \"<Gamepad>/leftStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"right\",\r\n                    \"id\": \"b46be990-1176-4948-8642-dddc1bf5ee6c\",\r\n                    \"path\": \"<Gamepad>/leftStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FPSMovement\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"9f9f8d86-cd0b-4953-8490-e72ab4b7d8f0\",\r\n                    \"path\": \"<Keyboard>/tab\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ToggleGUI\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2d06a9ed-570c-45df-ae1b-aec7652096fd\",\r\n                    \"path\": \"<Mouse>/middleButton\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"DragObjectModifier\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"2685a4d7-beae-479c-a63b-f7cd494f9c8a\",\r\n                    \"path\": \"<Keyboard>/leftCtrl\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShowCursor\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": []\r\n}");
			m_CameraControls = asset.FindActionMap("CameraControls", throwIfNotFound: true);
			m_CameraControls_ChangeCamera = m_CameraControls.FindAction("ChangeCamera", throwIfNotFound: true);
			m_CameraControls_CameraRotation = m_CameraControls.FindAction("CameraRotation", throwIfNotFound: true);
			m_CameraControls_CameraPanning = m_CameraControls.FindAction("CameraPanning", throwIfNotFound: true);
			m_CameraControls_CameraRotationModifier = m_CameraControls.FindAction("CameraRotationModifier", throwIfNotFound: true);
			m_CameraControls_CameraPanningModifier = m_CameraControls.FindAction("CameraPanningModifier", throwIfNotFound: true);
			m_CameraControls_CameraZoom = m_CameraControls.FindAction("CameraZoom", throwIfNotFound: true);
			m_SceneControls = asset.FindActionMap("SceneControls", throwIfNotFound: true);
			m_SceneControls_ChangeVehicle = m_SceneControls.FindAction("ChangeVehicle", throwIfNotFound: true);
			m_SceneControls_FPSMovement = m_SceneControls.FindAction("FPSMovement", throwIfNotFound: true);
			m_SceneControls_ToggleGUI = m_SceneControls.FindAction("ToggleGUI", throwIfNotFound: true);
			m_SceneControls_DragObjectModifier = m_SceneControls.FindAction("DragObjectModifier", throwIfNotFound: true);
			m_SceneControls_ShowCursor = m_SceneControls.FindAction("ShowCursor", throwIfNotFound: true);
		}

		~SceneInputActions()
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
}

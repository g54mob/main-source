using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace NWH.VehiclePhysics2.Input
{
	public class VehicleInputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
	{
		public struct VehicleControlsActions
		{
			private VehicleInputActions m_Wrapper;

			public InputAction Steering => m_Wrapper.m_VehicleControls_Steering;

			public InputAction Throttle => m_Wrapper.m_VehicleControls_Throttle;

			public InputAction Brakes => m_Wrapper.m_VehicleControls_Brakes;

			public InputAction Clutch => m_Wrapper.m_VehicleControls_Clutch;

			public InputAction Handbrake => m_Wrapper.m_VehicleControls_Handbrake;

			public InputAction EngineStartStop => m_Wrapper.m_VehicleControls_EngineStartStop;

			public InputAction ShiftUp => m_Wrapper.m_VehicleControls_ShiftUp;

			public InputAction ShiftDown => m_Wrapper.m_VehicleControls_ShiftDown;

			public InputAction LeftBlinker => m_Wrapper.m_VehicleControls_LeftBlinker;

			public InputAction RightBlinker => m_Wrapper.m_VehicleControls_RightBlinker;

			public InputAction LowBeamLights => m_Wrapper.m_VehicleControls_LowBeamLights;

			public InputAction HighBeamLights => m_Wrapper.m_VehicleControls_HighBeamLights;

			public InputAction HazardLights => m_Wrapper.m_VehicleControls_HazardLights;

			public InputAction ExtraLights => m_Wrapper.m_VehicleControls_ExtraLights;

			public InputAction TrailerAttachDetach => m_Wrapper.m_VehicleControls_TrailerAttachDetach;

			public InputAction Horn => m_Wrapper.m_VehicleControls_Horn;

			public InputAction ShiftIntoR1 => m_Wrapper.m_VehicleControls_ShiftIntoR1;

			public InputAction ShiftInto0 => m_Wrapper.m_VehicleControls_ShiftInto0;

			public InputAction ShiftInto1 => m_Wrapper.m_VehicleControls_ShiftInto1;

			public InputAction ShiftInto2 => m_Wrapper.m_VehicleControls_ShiftInto2;

			public InputAction ShiftInto3 => m_Wrapper.m_VehicleControls_ShiftInto3;

			public InputAction ShiftInto4 => m_Wrapper.m_VehicleControls_ShiftInto4;

			public InputAction ShiftInto5 => m_Wrapper.m_VehicleControls_ShiftInto5;

			public InputAction ShiftInto6 => m_Wrapper.m_VehicleControls_ShiftInto6;

			public InputAction ShiftInto7 => m_Wrapper.m_VehicleControls_ShiftInto7;

			public InputAction ShiftInto8 => m_Wrapper.m_VehicleControls_ShiftInto8;

			public InputAction FlipOver => m_Wrapper.m_VehicleControls_FlipOver;

			public InputAction Boost => m_Wrapper.m_VehicleControls_Boost;

			public InputAction CruiseControl => m_Wrapper.m_VehicleControls_CruiseControl;

			public bool enabled => Get().enabled;

			public VehicleControlsActions(VehicleInputActions wrapper)
			{
				m_Wrapper = wrapper;
			}

			public InputActionMap Get()
			{
				return m_Wrapper.m_VehicleControls;
			}

			public void Enable()
			{
				Get().Enable();
			}

			public void Disable()
			{
				Get().Disable();
			}

			public static implicit operator InputActionMap(VehicleControlsActions set)
			{
				return set.Get();
			}

			public void AddCallbacks(IVehicleControlsActions instance)
			{
				if (instance != null && !m_Wrapper.m_VehicleControlsActionsCallbackInterfaces.Contains(instance))
				{
					m_Wrapper.m_VehicleControlsActionsCallbackInterfaces.Add(instance);
					Steering.started += instance.OnSteering;
					Steering.performed += instance.OnSteering;
					Steering.canceled += instance.OnSteering;
					Throttle.started += instance.OnThrottle;
					Throttle.performed += instance.OnThrottle;
					Throttle.canceled += instance.OnThrottle;
					Brakes.started += instance.OnBrakes;
					Brakes.performed += instance.OnBrakes;
					Brakes.canceled += instance.OnBrakes;
					Clutch.started += instance.OnClutch;
					Clutch.performed += instance.OnClutch;
					Clutch.canceled += instance.OnClutch;
					Handbrake.started += instance.OnHandbrake;
					Handbrake.performed += instance.OnHandbrake;
					Handbrake.canceled += instance.OnHandbrake;
					EngineStartStop.started += instance.OnEngineStartStop;
					EngineStartStop.performed += instance.OnEngineStartStop;
					EngineStartStop.canceled += instance.OnEngineStartStop;
					ShiftUp.started += instance.OnShiftUp;
					ShiftUp.performed += instance.OnShiftUp;
					ShiftUp.canceled += instance.OnShiftUp;
					ShiftDown.started += instance.OnShiftDown;
					ShiftDown.performed += instance.OnShiftDown;
					ShiftDown.canceled += instance.OnShiftDown;
					LeftBlinker.started += instance.OnLeftBlinker;
					LeftBlinker.performed += instance.OnLeftBlinker;
					LeftBlinker.canceled += instance.OnLeftBlinker;
					RightBlinker.started += instance.OnRightBlinker;
					RightBlinker.performed += instance.OnRightBlinker;
					RightBlinker.canceled += instance.OnRightBlinker;
					LowBeamLights.started += instance.OnLowBeamLights;
					LowBeamLights.performed += instance.OnLowBeamLights;
					LowBeamLights.canceled += instance.OnLowBeamLights;
					HighBeamLights.started += instance.OnHighBeamLights;
					HighBeamLights.performed += instance.OnHighBeamLights;
					HighBeamLights.canceled += instance.OnHighBeamLights;
					HazardLights.started += instance.OnHazardLights;
					HazardLights.performed += instance.OnHazardLights;
					HazardLights.canceled += instance.OnHazardLights;
					ExtraLights.started += instance.OnExtraLights;
					ExtraLights.performed += instance.OnExtraLights;
					ExtraLights.canceled += instance.OnExtraLights;
					TrailerAttachDetach.started += instance.OnTrailerAttachDetach;
					TrailerAttachDetach.performed += instance.OnTrailerAttachDetach;
					TrailerAttachDetach.canceled += instance.OnTrailerAttachDetach;
					Horn.started += instance.OnHorn;
					Horn.performed += instance.OnHorn;
					Horn.canceled += instance.OnHorn;
					ShiftIntoR1.started += instance.OnShiftIntoR1;
					ShiftIntoR1.performed += instance.OnShiftIntoR1;
					ShiftIntoR1.canceled += instance.OnShiftIntoR1;
					ShiftInto0.started += instance.OnShiftInto0;
					ShiftInto0.performed += instance.OnShiftInto0;
					ShiftInto0.canceled += instance.OnShiftInto0;
					ShiftInto1.started += instance.OnShiftInto1;
					ShiftInto1.performed += instance.OnShiftInto1;
					ShiftInto1.canceled += instance.OnShiftInto1;
					ShiftInto2.started += instance.OnShiftInto2;
					ShiftInto2.performed += instance.OnShiftInto2;
					ShiftInto2.canceled += instance.OnShiftInto2;
					ShiftInto3.started += instance.OnShiftInto3;
					ShiftInto3.performed += instance.OnShiftInto3;
					ShiftInto3.canceled += instance.OnShiftInto3;
					ShiftInto4.started += instance.OnShiftInto4;
					ShiftInto4.performed += instance.OnShiftInto4;
					ShiftInto4.canceled += instance.OnShiftInto4;
					ShiftInto5.started += instance.OnShiftInto5;
					ShiftInto5.performed += instance.OnShiftInto5;
					ShiftInto5.canceled += instance.OnShiftInto5;
					ShiftInto6.started += instance.OnShiftInto6;
					ShiftInto6.performed += instance.OnShiftInto6;
					ShiftInto6.canceled += instance.OnShiftInto6;
					ShiftInto7.started += instance.OnShiftInto7;
					ShiftInto7.performed += instance.OnShiftInto7;
					ShiftInto7.canceled += instance.OnShiftInto7;
					ShiftInto8.started += instance.OnShiftInto8;
					ShiftInto8.performed += instance.OnShiftInto8;
					ShiftInto8.canceled += instance.OnShiftInto8;
					FlipOver.started += instance.OnFlipOver;
					FlipOver.performed += instance.OnFlipOver;
					FlipOver.canceled += instance.OnFlipOver;
					Boost.started += instance.OnBoost;
					Boost.performed += instance.OnBoost;
					Boost.canceled += instance.OnBoost;
					CruiseControl.started += instance.OnCruiseControl;
					CruiseControl.performed += instance.OnCruiseControl;
					CruiseControl.canceled += instance.OnCruiseControl;
				}
			}

			private void UnregisterCallbacks(IVehicleControlsActions instance)
			{
				Steering.started -= instance.OnSteering;
				Steering.performed -= instance.OnSteering;
				Steering.canceled -= instance.OnSteering;
				Throttle.started -= instance.OnThrottle;
				Throttle.performed -= instance.OnThrottle;
				Throttle.canceled -= instance.OnThrottle;
				Brakes.started -= instance.OnBrakes;
				Brakes.performed -= instance.OnBrakes;
				Brakes.canceled -= instance.OnBrakes;
				Clutch.started -= instance.OnClutch;
				Clutch.performed -= instance.OnClutch;
				Clutch.canceled -= instance.OnClutch;
				Handbrake.started -= instance.OnHandbrake;
				Handbrake.performed -= instance.OnHandbrake;
				Handbrake.canceled -= instance.OnHandbrake;
				EngineStartStop.started -= instance.OnEngineStartStop;
				EngineStartStop.performed -= instance.OnEngineStartStop;
				EngineStartStop.canceled -= instance.OnEngineStartStop;
				ShiftUp.started -= instance.OnShiftUp;
				ShiftUp.performed -= instance.OnShiftUp;
				ShiftUp.canceled -= instance.OnShiftUp;
				ShiftDown.started -= instance.OnShiftDown;
				ShiftDown.performed -= instance.OnShiftDown;
				ShiftDown.canceled -= instance.OnShiftDown;
				LeftBlinker.started -= instance.OnLeftBlinker;
				LeftBlinker.performed -= instance.OnLeftBlinker;
				LeftBlinker.canceled -= instance.OnLeftBlinker;
				RightBlinker.started -= instance.OnRightBlinker;
				RightBlinker.performed -= instance.OnRightBlinker;
				RightBlinker.canceled -= instance.OnRightBlinker;
				LowBeamLights.started -= instance.OnLowBeamLights;
				LowBeamLights.performed -= instance.OnLowBeamLights;
				LowBeamLights.canceled -= instance.OnLowBeamLights;
				HighBeamLights.started -= instance.OnHighBeamLights;
				HighBeamLights.performed -= instance.OnHighBeamLights;
				HighBeamLights.canceled -= instance.OnHighBeamLights;
				HazardLights.started -= instance.OnHazardLights;
				HazardLights.performed -= instance.OnHazardLights;
				HazardLights.canceled -= instance.OnHazardLights;
				ExtraLights.started -= instance.OnExtraLights;
				ExtraLights.performed -= instance.OnExtraLights;
				ExtraLights.canceled -= instance.OnExtraLights;
				TrailerAttachDetach.started -= instance.OnTrailerAttachDetach;
				TrailerAttachDetach.performed -= instance.OnTrailerAttachDetach;
				TrailerAttachDetach.canceled -= instance.OnTrailerAttachDetach;
				Horn.started -= instance.OnHorn;
				Horn.performed -= instance.OnHorn;
				Horn.canceled -= instance.OnHorn;
				ShiftIntoR1.started -= instance.OnShiftIntoR1;
				ShiftIntoR1.performed -= instance.OnShiftIntoR1;
				ShiftIntoR1.canceled -= instance.OnShiftIntoR1;
				ShiftInto0.started -= instance.OnShiftInto0;
				ShiftInto0.performed -= instance.OnShiftInto0;
				ShiftInto0.canceled -= instance.OnShiftInto0;
				ShiftInto1.started -= instance.OnShiftInto1;
				ShiftInto1.performed -= instance.OnShiftInto1;
				ShiftInto1.canceled -= instance.OnShiftInto1;
				ShiftInto2.started -= instance.OnShiftInto2;
				ShiftInto2.performed -= instance.OnShiftInto2;
				ShiftInto2.canceled -= instance.OnShiftInto2;
				ShiftInto3.started -= instance.OnShiftInto3;
				ShiftInto3.performed -= instance.OnShiftInto3;
				ShiftInto3.canceled -= instance.OnShiftInto3;
				ShiftInto4.started -= instance.OnShiftInto4;
				ShiftInto4.performed -= instance.OnShiftInto4;
				ShiftInto4.canceled -= instance.OnShiftInto4;
				ShiftInto5.started -= instance.OnShiftInto5;
				ShiftInto5.performed -= instance.OnShiftInto5;
				ShiftInto5.canceled -= instance.OnShiftInto5;
				ShiftInto6.started -= instance.OnShiftInto6;
				ShiftInto6.performed -= instance.OnShiftInto6;
				ShiftInto6.canceled -= instance.OnShiftInto6;
				ShiftInto7.started -= instance.OnShiftInto7;
				ShiftInto7.performed -= instance.OnShiftInto7;
				ShiftInto7.canceled -= instance.OnShiftInto7;
				ShiftInto8.started -= instance.OnShiftInto8;
				ShiftInto8.performed -= instance.OnShiftInto8;
				ShiftInto8.canceled -= instance.OnShiftInto8;
				FlipOver.started -= instance.OnFlipOver;
				FlipOver.performed -= instance.OnFlipOver;
				FlipOver.canceled -= instance.OnFlipOver;
				Boost.started -= instance.OnBoost;
				Boost.performed -= instance.OnBoost;
				Boost.canceled -= instance.OnBoost;
				CruiseControl.started -= instance.OnCruiseControl;
				CruiseControl.performed -= instance.OnCruiseControl;
				CruiseControl.canceled -= instance.OnCruiseControl;
			}

			public void RemoveCallbacks(IVehicleControlsActions instance)
			{
				if (m_Wrapper.m_VehicleControlsActionsCallbackInterfaces.Remove(instance))
				{
					UnregisterCallbacks(instance);
				}
			}

			public void SetCallbacks(IVehicleControlsActions instance)
			{
				foreach (IVehicleControlsActions vehicleControlsActionsCallbackInterface in m_Wrapper.m_VehicleControlsActionsCallbackInterfaces)
				{
					UnregisterCallbacks(vehicleControlsActionsCallbackInterface);
				}
				m_Wrapper.m_VehicleControlsActionsCallbackInterfaces.Clear();
				AddCallbacks(instance);
			}
		}

		public interface IVehicleControlsActions
		{
			void OnSteering(InputAction.CallbackContext context);

			void OnThrottle(InputAction.CallbackContext context);

			void OnBrakes(InputAction.CallbackContext context);

			void OnClutch(InputAction.CallbackContext context);

			void OnHandbrake(InputAction.CallbackContext context);

			void OnEngineStartStop(InputAction.CallbackContext context);

			void OnShiftUp(InputAction.CallbackContext context);

			void OnShiftDown(InputAction.CallbackContext context);

			void OnLeftBlinker(InputAction.CallbackContext context);

			void OnRightBlinker(InputAction.CallbackContext context);

			void OnLowBeamLights(InputAction.CallbackContext context);

			void OnHighBeamLights(InputAction.CallbackContext context);

			void OnHazardLights(InputAction.CallbackContext context);

			void OnExtraLights(InputAction.CallbackContext context);

			void OnTrailerAttachDetach(InputAction.CallbackContext context);

			void OnHorn(InputAction.CallbackContext context);

			void OnShiftIntoR1(InputAction.CallbackContext context);

			void OnShiftInto0(InputAction.CallbackContext context);

			void OnShiftInto1(InputAction.CallbackContext context);

			void OnShiftInto2(InputAction.CallbackContext context);

			void OnShiftInto3(InputAction.CallbackContext context);

			void OnShiftInto4(InputAction.CallbackContext context);

			void OnShiftInto5(InputAction.CallbackContext context);

			void OnShiftInto6(InputAction.CallbackContext context);

			void OnShiftInto7(InputAction.CallbackContext context);

			void OnShiftInto8(InputAction.CallbackContext context);

			void OnFlipOver(InputAction.CallbackContext context);

			void OnBoost(InputAction.CallbackContext context);

			void OnCruiseControl(InputAction.CallbackContext context);
		}

		private readonly InputActionMap m_VehicleControls;

		private List<IVehicleControlsActions> m_VehicleControlsActionsCallbackInterfaces = new List<IVehicleControlsActions>();

		private readonly InputAction m_VehicleControls_Steering;

		private readonly InputAction m_VehicleControls_Throttle;

		private readonly InputAction m_VehicleControls_Brakes;

		private readonly InputAction m_VehicleControls_Clutch;

		private readonly InputAction m_VehicleControls_Handbrake;

		private readonly InputAction m_VehicleControls_EngineStartStop;

		private readonly InputAction m_VehicleControls_ShiftUp;

		private readonly InputAction m_VehicleControls_ShiftDown;

		private readonly InputAction m_VehicleControls_LeftBlinker;

		private readonly InputAction m_VehicleControls_RightBlinker;

		private readonly InputAction m_VehicleControls_LowBeamLights;

		private readonly InputAction m_VehicleControls_HighBeamLights;

		private readonly InputAction m_VehicleControls_HazardLights;

		private readonly InputAction m_VehicleControls_ExtraLights;

		private readonly InputAction m_VehicleControls_TrailerAttachDetach;

		private readonly InputAction m_VehicleControls_Horn;

		private readonly InputAction m_VehicleControls_ShiftIntoR1;

		private readonly InputAction m_VehicleControls_ShiftInto0;

		private readonly InputAction m_VehicleControls_ShiftInto1;

		private readonly InputAction m_VehicleControls_ShiftInto2;

		private readonly InputAction m_VehicleControls_ShiftInto3;

		private readonly InputAction m_VehicleControls_ShiftInto4;

		private readonly InputAction m_VehicleControls_ShiftInto5;

		private readonly InputAction m_VehicleControls_ShiftInto6;

		private readonly InputAction m_VehicleControls_ShiftInto7;

		private readonly InputAction m_VehicleControls_ShiftInto8;

		private readonly InputAction m_VehicleControls_FlipOver;

		private readonly InputAction m_VehicleControls_Boost;

		private readonly InputAction m_VehicleControls_CruiseControl;

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

		public VehicleControlsActions VehicleControls => new VehicleControlsActions(this);

		public VehicleInputActions()
		{
			asset = InputActionAsset.FromJson("{\r\n    \"version\": 1,\r\n    \"name\": \"VehicleInputActions\",\r\n    \"maps\": [\r\n        {\r\n            \"name\": \"Vehicle Controls\",\r\n            \"id\": \"200a0048-834b-4c46-8e58-cb0180a3f09b\",\r\n            \"actions\": [\r\n                {\r\n                    \"name\": \"Steering\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"4c14d84a-48f6-429e-9111-d009cff86527\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Throttle\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"067e3728-8c0e-4c68-8b07-765ef5a0b2ff\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Brakes\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"063dcbbf-0a3c-4282-90a5-ec46c6b1db95\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Clutch\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"036104a2-f1da-429a-b3bf-75c4e539a58d\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"Handbrake\",\r\n                    \"type\": \"Value\",\r\n                    \"id\": \"6502904b-df3b-4a12-b9ca-b365d43db960\",\r\n                    \"expectedControlType\": \"Axis\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": true\r\n                },\r\n                {\r\n                    \"name\": \"EngineStartStop\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"aa0a9858-ed3f-472c-96f9-4fdf0346726d\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftUp\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4fa6a7ca-d894-4cd6-8592-7e34c66a8190\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftDown\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"180cb808-2f04-48c7-9551-a2859fff6752\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"LeftBlinker\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8f13ab7c-233f-4736-bbfa-c5f202240ad1\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"RightBlinker\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"62880158-789b-43bb-bd49-c3bf25e94c87\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"LowBeamLights\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"6536d934-38cf-48a6-afa1-16d6ed8f421c\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"HighBeamLights\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8af605a2-5581-4c32-9e35-2f80d0250a3e\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"HazardLights\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4e80b995-afae-4eb7-bd57-c2685a0c4388\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ExtraLights\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"47c64239-6f45-41be-ba39-f8b1966b4170\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"TrailerAttachDetach\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"d1143207-7243-4236-95d0-54b07f8caaf1\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Horn\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2a4bc293-16f8-47c1-8532-bc82b3905f77\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftIntoR1\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"fdf654af-5894-4876-9565-8e64e1f53efa\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto0\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"2ee85004-4812-4a6a-bb27-7c535a276c1a\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto1\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"b6f6becb-e7c2-4a15-8288-797cf992242c\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto2\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4e82356c-b972-494a-9c0b-6031cd291630\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto3\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"aae19f07-e299-427a-8033-23a590c791d2\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto4\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4e5032a3-39df-4dc8-a307-485c7a996b50\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto5\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"93decc9e-67a4-4d2e-a2aa-02cae173ffbf\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto6\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"8a253467-ad3e-4c6c-b0dd-fc030cf1db5c\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto7\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"cf66f6fe-1e63-45fc-a7dc-732882ca95fa\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"ShiftInto8\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"4e7aa765-fdc6-4098-b90d-a2017111fafd\",\r\n                    \"expectedControlType\": \"Button\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"FlipOver\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"238902b2-609f-4842-bd46-b5b15a8bd829\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"Boost\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"6de7528e-5f55-46a1-8fc6-bd19214b263c\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                },\r\n                {\r\n                    \"name\": \"CruiseControl\",\r\n                    \"type\": \"Button\",\r\n                    \"id\": \"c2c193e5-0ba5-4cdc-a189-84ccae17d118\",\r\n                    \"expectedControlType\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"interactions\": \"\",\r\n                    \"initialStateCheck\": false\r\n                }\r\n            ],\r\n            \"bindings\": [\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"35b97d96-fd20-4097-8fb3-e4a275703cfd\",\r\n                    \"path\": \"<Keyboard>/e\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"EngineStartStop\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"3cb1f792-d862-4891-8e4f-156d57a4829e\",\r\n                    \"path\": \"<Keyboard>/r\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftUp\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"dc3a7a67-1f90-4e7c-b07c-18f1dc7d6902\",\r\n                    \"path\": \"<Gamepad>/rightShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftUp\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"6c4a4e7e-d035-447e-aaae-a5fb5f586cce\",\r\n                    \"path\": \"<Keyboard>/f\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftDown\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"b3d427b4-5535-4cde-93b8-39952f11604f\",\r\n                    \"path\": \"<Gamepad>/leftShoulder\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftDown\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c80687f6-73d6-4d12-a7ec-bfd5f70b9c1f\",\r\n                    \"path\": \"<Keyboard>/z\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"LeftBlinker\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"685cee63-e7f3-4a07-a8e3-bf34b04f0b47\",\r\n                    \"path\": \"<Keyboard>/x\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"RightBlinker\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d2ec8fbe-9683-4987-931d-57ea5713d264\",\r\n                    \"path\": \"<Keyboard>/l\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"LowBeamLights\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c49dc91a-be6d-4a78-ae0c-cfd55da21347\",\r\n                    \"path\": \"<Gamepad>/buttonNorth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"LowBeamLights\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ba07cb72-8b32-40a6-b7b7-49fda5a5696a\",\r\n                    \"path\": \"<Keyboard>/k\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"HighBeamLights\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"47963c3f-83fc-444f-be98-2c2ad7dd5898\",\r\n                    \"path\": \"<Keyboard>/j\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"HazardLights\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c0f9f750-4f64-4408-9d29-295d1fd9c54e\",\r\n                    \"path\": \"<Keyboard>/semicolon\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ExtraLights\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"95f029b5-d826-4702-888f-47f7e793f787\",\r\n                    \"path\": \"<Keyboard>/t\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"TrailerAttachDetach\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"cbddc214-430c-4d0b-8003-11f10876d005\",\r\n                    \"path\": \"<Gamepad>/buttonWest\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"TrailerAttachDetach\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"67c9fe69-ff40-4fe2-8412-6d8f476f5d93\",\r\n                    \"path\": \"<Keyboard>/h\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Horn\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"81844531-f08f-4aa7-8e3f-26f755bc62f3\",\r\n                    \"path\": \"<Keyboard>/minus\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftIntoR1\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c2489f77-0bdb-4561-a6b7-45708fd8b7dc\",\r\n                    \"path\": \"<Keyboard>/0\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto0\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"c57a7e33-e49e-4bd9-b5a1-a33861f506d9\",\r\n                    \"path\": \"<Keyboard>/1\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto1\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"abcd6d75-1316-4eda-87e5-9644bd935300\",\r\n                    \"path\": \"<Keyboard>/2\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto2\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"669d3a9c-c9fe-42f5-9057-8f0cb31e0b96\",\r\n                    \"path\": \"<Keyboard>/3\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto3\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"d4d8b40a-ee7f-495f-be9a-20d75f9e8a04\",\r\n                    \"path\": \"<Keyboard>/4\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto4\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"a2c47890-4ff7-4795-8d55-20fb2e40a543\",\r\n                    \"path\": \"<Keyboard>/5\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto5\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"aeff3f22-e375-486e-a67e-b88f1bd384e5\",\r\n                    \"path\": \"<Keyboard>/6\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto6\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"4e7e74b3-942e-4649-b2d3-8bb7d139bf5e\",\r\n                    \"path\": \"<Keyboard>/7\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto7\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"ac654d38-d65d-40e4-9796-8c17eede2112\",\r\n                    \"path\": \"<Keyboard>/8\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"ShiftInto8\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"074547a7-a3ea-4b53-a88f-599e9a8004b0\",\r\n                    \"path\": \"<Keyboard>/m\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"FlipOver\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"76b93c66-3dac-4d90-ac1f-aae6a399a31e\",\r\n                    \"path\": \"<Keyboard>/leftShift\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Boost\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"68e6d03c-1dd8-4b1b-9a6e-bbe32edef279\",\r\n                    \"path\": \"<Gamepad>/buttonSouth\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Boost\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"\",\r\n                    \"id\": \"86494961-cebe-49ae-bbfe-950e9a17c5f9\",\r\n                    \"path\": \"<Keyboard>/n\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"CruiseControl\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"1bff6693-e128-4d74-ad2f-ad4e229608a8\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"Negative\",\r\n                    \"id\": \"6a4beedd-9d33-48f8-ab0b-2fa4835b56d5\",\r\n                    \"path\": \"<Keyboard>/a\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Positive\",\r\n                    \"id\": \"3ce20f4e-6e04-4810-b8c6-829ced054390\",\r\n                    \"path\": \"<Keyboard>/d\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"acf664f4-dde0-4367-8e3a-7fbdf293bc0c\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"AxisDeadzone(min=0.005,max=1)\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"negative\",\r\n                    \"id\": \"0332ccc4-b818-41e6-8455-330ec56c13de\",\r\n                    \"path\": \"<Gamepad>/leftStick/left\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"89725913-86df-4c0b-893e-7dab71609463\",\r\n                    \"path\": \"<Gamepad>/leftStick/right\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Steering\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"866afad4-aa6f-444a-8122-260b6292b1d2\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Handbrake\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"1ca21924-c96b-474a-a54b-b585c2e71ec2\",\r\n                    \"path\": \"<Keyboard>/space\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Handbrake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"e484e077-2222-4195-b4c0-92d2608ae41c\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Handbrake\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"2d33c1e7-80af-4289-b8fa-c30c539b46bf\",\r\n                    \"path\": \"<Gamepad>/buttonEast\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Handbrake\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"68c44959-158f-4a90-a301-94ab2339beee\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Throttle\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"8601f7ae-fd79-42d3-bd51-c0054d12b6f7\",\r\n                    \"path\": \"<Keyboard>/w\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Throttle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"405ba6f9-74dd-4b74-8687-7dda1bc905d3\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Throttle\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"7d163169-2e04-49bb-8dad-3fa803f4201e\",\r\n                    \"path\": \"<Gamepad>/rightTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Throttle\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Keyboard\",\r\n                    \"id\": \"079d6648-edd9-46d8-ae9b-ab8fced71ba4\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Brakes\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"8d444115-e1a0-4c2a-864c-fbd63db53c90\",\r\n                    \"path\": \"<Keyboard>/s\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Brakes\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                },\r\n                {\r\n                    \"name\": \"Gamepad\",\r\n                    \"id\": \"4c6d18cf-e9dc-4ffd-a439-ed257cb0c16a\",\r\n                    \"path\": \"1DAxis\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Brakes\",\r\n                    \"isComposite\": true,\r\n                    \"isPartOfComposite\": false\r\n                },\r\n                {\r\n                    \"name\": \"positive\",\r\n                    \"id\": \"cf160faf-0e28-4998-94ee-ce086b4b76c5\",\r\n                    \"path\": \"<Gamepad>/leftTrigger\",\r\n                    \"interactions\": \"\",\r\n                    \"processors\": \"\",\r\n                    \"groups\": \"\",\r\n                    \"action\": \"Brakes\",\r\n                    \"isComposite\": false,\r\n                    \"isPartOfComposite\": true\r\n                }\r\n            ]\r\n        }\r\n    ],\r\n    \"controlSchemes\": []\r\n}");
			m_VehicleControls = asset.FindActionMap("Vehicle Controls", throwIfNotFound: true);
			m_VehicleControls_Steering = m_VehicleControls.FindAction("Steering", throwIfNotFound: true);
			m_VehicleControls_Throttle = m_VehicleControls.FindAction("Throttle", throwIfNotFound: true);
			m_VehicleControls_Brakes = m_VehicleControls.FindAction("Brakes", throwIfNotFound: true);
			m_VehicleControls_Clutch = m_VehicleControls.FindAction("Clutch", throwIfNotFound: true);
			m_VehicleControls_Handbrake = m_VehicleControls.FindAction("Handbrake", throwIfNotFound: true);
			m_VehicleControls_EngineStartStop = m_VehicleControls.FindAction("EngineStartStop", throwIfNotFound: true);
			m_VehicleControls_ShiftUp = m_VehicleControls.FindAction("ShiftUp", throwIfNotFound: true);
			m_VehicleControls_ShiftDown = m_VehicleControls.FindAction("ShiftDown", throwIfNotFound: true);
			m_VehicleControls_LeftBlinker = m_VehicleControls.FindAction("LeftBlinker", throwIfNotFound: true);
			m_VehicleControls_RightBlinker = m_VehicleControls.FindAction("RightBlinker", throwIfNotFound: true);
			m_VehicleControls_LowBeamLights = m_VehicleControls.FindAction("LowBeamLights", throwIfNotFound: true);
			m_VehicleControls_HighBeamLights = m_VehicleControls.FindAction("HighBeamLights", throwIfNotFound: true);
			m_VehicleControls_HazardLights = m_VehicleControls.FindAction("HazardLights", throwIfNotFound: true);
			m_VehicleControls_ExtraLights = m_VehicleControls.FindAction("ExtraLights", throwIfNotFound: true);
			m_VehicleControls_TrailerAttachDetach = m_VehicleControls.FindAction("TrailerAttachDetach", throwIfNotFound: true);
			m_VehicleControls_Horn = m_VehicleControls.FindAction("Horn", throwIfNotFound: true);
			m_VehicleControls_ShiftIntoR1 = m_VehicleControls.FindAction("ShiftIntoR1", throwIfNotFound: true);
			m_VehicleControls_ShiftInto0 = m_VehicleControls.FindAction("ShiftInto0", throwIfNotFound: true);
			m_VehicleControls_ShiftInto1 = m_VehicleControls.FindAction("ShiftInto1", throwIfNotFound: true);
			m_VehicleControls_ShiftInto2 = m_VehicleControls.FindAction("ShiftInto2", throwIfNotFound: true);
			m_VehicleControls_ShiftInto3 = m_VehicleControls.FindAction("ShiftInto3", throwIfNotFound: true);
			m_VehicleControls_ShiftInto4 = m_VehicleControls.FindAction("ShiftInto4", throwIfNotFound: true);
			m_VehicleControls_ShiftInto5 = m_VehicleControls.FindAction("ShiftInto5", throwIfNotFound: true);
			m_VehicleControls_ShiftInto6 = m_VehicleControls.FindAction("ShiftInto6", throwIfNotFound: true);
			m_VehicleControls_ShiftInto7 = m_VehicleControls.FindAction("ShiftInto7", throwIfNotFound: true);
			m_VehicleControls_ShiftInto8 = m_VehicleControls.FindAction("ShiftInto8", throwIfNotFound: true);
			m_VehicleControls_FlipOver = m_VehicleControls.FindAction("FlipOver", throwIfNotFound: true);
			m_VehicleControls_Boost = m_VehicleControls.FindAction("Boost", throwIfNotFound: true);
			m_VehicleControls_CruiseControl = m_VehicleControls.FindAction("CruiseControl", throwIfNotFound: true);
		}

		~VehicleInputActions()
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class SCC_InputActions : IInputActionCollection2, IInputActionCollection, IEnumerable<InputAction>, IEnumerable, IDisposable
{
	public struct VehicleActions
	{
		private SCC_InputActions m_Wrapper;

		public InputAction Throttle => m_Wrapper.m_Vehicle_Throttle;

		public InputAction Brake => m_Wrapper.m_Vehicle_Brake;

		public InputAction Steering => m_Wrapper.m_Vehicle_Steering;

		public InputAction Handbrake => m_Wrapper.m_Vehicle_Handbrake;

		public bool enabled => Get().enabled;

		public VehicleActions(SCC_InputActions wrapper)
		{
			m_Wrapper = wrapper;
		}

		public InputActionMap Get()
		{
			return m_Wrapper.m_Vehicle;
		}

		public void Enable()
		{
			Get().Enable();
		}

		public void Disable()
		{
			Get().Disable();
		}

		public static implicit operator InputActionMap(VehicleActions set)
		{
			return set.Get();
		}

		public void AddCallbacks(IVehicleActions instance)
		{
			if (instance != null && !m_Wrapper.m_VehicleActionsCallbackInterfaces.Contains(instance))
			{
				m_Wrapper.m_VehicleActionsCallbackInterfaces.Add(instance);
				Throttle.started += instance.OnThrottle;
				Throttle.performed += instance.OnThrottle;
				Throttle.canceled += instance.OnThrottle;
				Brake.started += instance.OnBrake;
				Brake.performed += instance.OnBrake;
				Brake.canceled += instance.OnBrake;
				Steering.started += instance.OnSteering;
				Steering.performed += instance.OnSteering;
				Steering.canceled += instance.OnSteering;
				Handbrake.started += instance.OnHandbrake;
				Handbrake.performed += instance.OnHandbrake;
				Handbrake.canceled += instance.OnHandbrake;
			}
		}

		private void UnregisterCallbacks(IVehicleActions instance)
		{
			Throttle.started -= instance.OnThrottle;
			Throttle.performed -= instance.OnThrottle;
			Throttle.canceled -= instance.OnThrottle;
			Brake.started -= instance.OnBrake;
			Brake.performed -= instance.OnBrake;
			Brake.canceled -= instance.OnBrake;
			Steering.started -= instance.OnSteering;
			Steering.performed -= instance.OnSteering;
			Steering.canceled -= instance.OnSteering;
			Handbrake.started -= instance.OnHandbrake;
			Handbrake.performed -= instance.OnHandbrake;
			Handbrake.canceled -= instance.OnHandbrake;
		}

		public void RemoveCallbacks(IVehicleActions instance)
		{
			if (m_Wrapper.m_VehicleActionsCallbackInterfaces.Remove(instance))
			{
				UnregisterCallbacks(instance);
			}
		}

		public void SetCallbacks(IVehicleActions instance)
		{
			foreach (IVehicleActions vehicleActionsCallbackInterface in m_Wrapper.m_VehicleActionsCallbackInterfaces)
			{
				UnregisterCallbacks(vehicleActionsCallbackInterface);
			}
			m_Wrapper.m_VehicleActionsCallbackInterfaces.Clear();
			AddCallbacks(instance);
		}
	}

	public struct CameraActions
	{
		private SCC_InputActions m_Wrapper;

		public InputAction Orbit => m_Wrapper.m_Camera_Orbit;

		public bool enabled => Get().enabled;

		public CameraActions(SCC_InputActions wrapper)
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
				Orbit.started += instance.OnOrbit;
				Orbit.performed += instance.OnOrbit;
				Orbit.canceled += instance.OnOrbit;
			}
		}

		private void UnregisterCallbacks(ICameraActions instance)
		{
			Orbit.started -= instance.OnOrbit;
			Orbit.performed -= instance.OnOrbit;
			Orbit.canceled -= instance.OnOrbit;
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

	public interface IVehicleActions
	{
		void OnThrottle(InputAction.CallbackContext context);

		void OnBrake(InputAction.CallbackContext context);

		void OnSteering(InputAction.CallbackContext context);

		void OnHandbrake(InputAction.CallbackContext context);
	}

	public interface ICameraActions
	{
		void OnOrbit(InputAction.CallbackContext context);
	}

	private readonly InputActionMap m_Vehicle;

	private List<IVehicleActions> m_VehicleActionsCallbackInterfaces = new List<IVehicleActions>();

	private readonly InputAction m_Vehicle_Throttle;

	private readonly InputAction m_Vehicle_Brake;

	private readonly InputAction m_Vehicle_Steering;

	private readonly InputAction m_Vehicle_Handbrake;

	private readonly InputActionMap m_Camera;

	private List<ICameraActions> m_CameraActionsCallbackInterfaces = new List<ICameraActions>();

	private readonly InputAction m_Camera_Orbit;

	private int m_KeyboardMouseSchemeIndex = -1;

	private int m_GamepadSchemeIndex = -1;

	private int m_G920SchemeIndex = -1;

	private int m_OculusQuestSchemeIndex = -1;

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

	public VehicleActions Vehicle => new VehicleActions(this);

	public CameraActions Camera => new CameraActions(this);

	public InputControlScheme KeyboardMouseScheme
	{
		get
		{
			if (m_KeyboardMouseSchemeIndex == -1)
			{
				m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard Mouse");
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

	public InputControlScheme G920Scheme
	{
		get
		{
			if (m_G920SchemeIndex == -1)
			{
				m_G920SchemeIndex = asset.FindControlSchemeIndex("G920");
			}
			return asset.controlSchemes[m_G920SchemeIndex];
		}
	}

	public InputControlScheme OculusQuestScheme
	{
		get
		{
			if (m_OculusQuestSchemeIndex == -1)
			{
				m_OculusQuestSchemeIndex = asset.FindControlSchemeIndex("Oculus Quest");
			}
			return asset.controlSchemes[m_OculusQuestSchemeIndex];
		}
	}

	public SCC_InputActions()
	{
		asset = InputActionAsset.FromJson("{\n    \"version\": 1,\n    \"name\": \"SCC_InputActions\",\n    \"maps\": [\n        {\n            \"name\": \"Vehicle\",\n            \"id\": \"dab82b1c-787e-4a36-b968-b40e68121a11\",\n            \"actions\": [\n                {\n                    \"name\": \"Throttle\",\n                    \"type\": \"Value\",\n                    \"id\": \"90dd0b16-b17c-4e2f-816d-3f6f472fbe4d\",\n                    \"expectedControlType\": \"Axis\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Brake\",\n                    \"type\": \"Value\",\n                    \"id\": \"fd45c78a-8d28-433b-938d-216a05e39978\",\n                    \"expectedControlType\": \"Axis\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Steering\",\n                    \"type\": \"Value\",\n                    \"id\": \"07554ee5-17d2-4f02-a18b-c167de4685b5\",\n                    \"expectedControlType\": \"Axis\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                },\n                {\n                    \"name\": \"Handbrake\",\n                    \"type\": \"Button\",\n                    \"id\": \"862a1da3-327a-425f-bc3a-c144667b0f07\",\n                    \"expectedControlType\": \"Button\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": false\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"arrows\",\n                    \"id\": \"f11f01e4-cf2c-47ed-ab18-9f957fe8913a\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"e0cd1536-dbc9-4a1c-85e1-a1a092c6d2dc\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"a1ba4f3e-7db4-494b-94a9-609e76725d20\",\n                    \"path\": \"<Keyboard>/upArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"wasd\",\n                    \"id\": \"3fdb6416-2def-4c85-8aaa-8bc786eee672\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"20f6ae90-cf5c-4fdf-a3b2-156ecb775171\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"1f637e88-9cd0-42a6-93cf-ce55b89ff212\",\n                    \"path\": \"<Keyboard>/w\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"gamepads\",\n                    \"id\": \"34d118d2-ab65-4ccd-bb89-78a9a042d4de\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"af0c3935-4ef0-4f3b-8a8d-13853137f6db\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"e323a5f2-36c3-459c-813e-d6bbb9e3bac7\",\n                    \"path\": \"<Gamepad>/rightTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"G29/920\",\n                    \"id\": \"917fc2f9-b027-48ea-a670-9f4f3cb137af\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"be73745b-397e-4185-9283-ea2f38bf4f84\",\n                    \"path\": \"<Joystick>/stick/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"G920\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"24631aa9-3d4f-4a4c-9348-c76dc524a7bf\",\n                    \"path\": \"<Joystick>/stick/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"G920\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"b7f469da-1f0b-4649-a1d2-d5c6795d48b5\",\n                    \"path\": \"<OculusTouchController>{RightHand}/trigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Oculus Quest\",\n                    \"action\": \"Throttle\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"keyboard\",\n                    \"id\": \"719ca6b9-d323-4341-8e55-caa156a602e8\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"4d2b585c-6f0c-4907-8009-b23e2a8bfce1\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"ebd5b62c-f128-414b-8280-7decced19010\",\n                    \"path\": \"<Keyboard>/space\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"gamepads\",\n                    \"id\": \"3d7e56ad-b8c0-434a-8415-72fa857776ac\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"bab83804-84b2-4e39-9fc1-9bb9787d2a60\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"3db07aa2-78b1-4e62-869e-5540b1d2ea11\",\n                    \"path\": \"<Gamepad>/buttonSouth\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"5aaefde0-b9f2-4263-ada8-08c4754560fc\",\n                    \"path\": \"<HID::Logitech G920 Driving Force Racing Wheel for Xbox One>/button2\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"G920\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"3cbd8e1e-8b86-4741-8cb2-876fb108b2a3\",\n                    \"path\": \"<OculusTouchController>{RightHand}/primaryButton\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Oculus Quest\",\n                    \"action\": \"Handbrake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"wasd\",\n                    \"id\": \"a135f3bc-f45c-479f-ad28-b4581890cd28\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"b1647269-c5f0-41dc-b651-b4e2f87d8fdb\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"f7d779b9-21fe-4e3d-9744-a94e504b04fc\",\n                    \"path\": \"<Keyboard>/s\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"arrows\",\n                    \"id\": \"c8307ec0-22ef-43bb-8351-b6aef882fa5f\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"b17286eb-c31a-424d-97bc-ffc8ee35b47a\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"9ee6ed4f-8f71-47d6-af83-3d0b1e20860c\",\n                    \"path\": \"<Keyboard>/downArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"gamepads\",\n                    \"id\": \"885ad1e3-b856-4be1-a7cb-32bb8bfb2b88\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"6a9790aa-c6f0-48b7-b93c-c2d033442261\",\n                    \"path\": \"\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"positive\",\n                    \"id\": \"69462041-e882-40fd-bed8-deff21837f89\",\n                    \"path\": \"<Gamepad>/leftTrigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"aaf2efcb-4c14-4b5f-8669-de517f4ad583\",\n                    \"path\": \"<OculusTouchController>{LeftHand}/trigger\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Oculus Quest\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"G29/920\",\n                    \"id\": \"ea42dd76-8279-4357-8568-5591d76a5189\",\n                    \"path\": \"1DAxis(minValue=0)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale(factor=2)\",\n                    \"groups\": \"\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"c803aabc-d4e4-43bd-8c6f-ada81a3a4ce8\",\n                    \"path\": \"<HID::Logitech G920 Driving Force Racing Wheel for Xbox One>/z\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"G920\",\n                    \"action\": \"Brake\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"wasd\",\n                    \"id\": \"b84118c6-f280-4827-aec2-23b358ff2839\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"Negative\",\n                    \"id\": \"e39a68f9-d10f-4dfb-9c23-4911299ada81\",\n                    \"path\": \"<Keyboard>/a\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"Positive\",\n                    \"id\": \"95b1dcb4-e179-495b-9829-2441e822fa9c\",\n                    \"path\": \"<Keyboard>/d\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"arrows\",\n                    \"id\": \"c9265635-9301-4f28-857f-f8c35c3aeaa3\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"negative\",\n                    \"id\": \"0efc1b5a-a2af-4412-9c79-657c31d182ad\",\n                    \"path\": \"<Keyboard>/leftArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"Positive\",\n                    \"id\": \"f8373c7a-eb6c-4d91-afe6-1f8f9db75611\",\n                    \"path\": \"<Keyboard>/rightArrow\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"gamepads\",\n                    \"id\": \"c33597ed-2d60-4495-acd6-1898c0c03435\",\n                    \"path\": \"1DAxis\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"Negative\",\n                    \"id\": \"2605240c-dc7a-4c85-a40f-3976962910e4\",\n                    \"path\": \"<Gamepad>/leftStick/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"Positive\",\n                    \"id\": \"dfa77fc0-a4e7-4963-ba95-c84d55d9166b\",\n                    \"path\": \"<Gamepad>/leftStick/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a72b71b3-a5a9-476e-ba2f-303039d7d7f9\",\n                    \"path\": \"<HID::Logitech G920 Driving Force Racing Wheel for Xbox One>/stick/x\",\n                    \"interactions\": \"\",\n                    \"processors\": \"Scale\",\n                    \"groups\": \"G920\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"4f884a2c-fc71-409f-85a6-58868973caca\",\n                    \"path\": \"<OculusTouchController>{LeftHand}/thumbstick/x\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Oculus Quest\",\n                    \"action\": \"Steering\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Camera\",\n            \"id\": \"9833443b-7a36-43d9-b723-68beac1a943a\",\n            \"actions\": [\n                {\n                    \"name\": \"Orbit\",\n                    \"type\": \"Value\",\n                    \"id\": \"36c3b66b-e716-43bf-8b0f-d41f0459994b\",\n                    \"expectedControlType\": \"Vector2\",\n                    \"processors\": \"\",\n                    \"interactions\": \"\",\n                    \"initialStateCheck\": true\n                }\n            ],\n            \"bindings\": [\n                {\n                    \"name\": \"\",\n                    \"id\": \"10705ed5-34a8-40b6-afab-e3723c412fd4\",\n                    \"path\": \"<Mouse>/delta\",\n                    \"interactions\": \"\",\n                    \"processors\": \"ScaleVector2(x=0.25,y=0.25)\",\n                    \"groups\": \"Keyboard Mouse\",\n                    \"action\": \"Orbit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"gamepads\",\n                    \"id\": \"adf39205-15ba-43f3-9a61-30694bdff208\",\n                    \"path\": \"2DVector(mode=2)\",\n                    \"interactions\": \"\",\n                    \"processors\": \"StickDeadzone\",\n                    \"groups\": \"\",\n                    \"action\": \"Orbit\",\n                    \"isComposite\": true,\n                    \"isPartOfComposite\": false\n                },\n                {\n                    \"name\": \"up\",\n                    \"id\": \"e88670fd-67e0-46a4-93ff-edfecf9d387a\",\n                    \"path\": \"<Gamepad>/rightStick/up\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Orbit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"down\",\n                    \"id\": \"bed807c8-3819-4858-bbef-fc3a524d09fe\",\n                    \"path\": \"<Gamepad>/rightStick/down\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Orbit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"left\",\n                    \"id\": \"6ca2a81c-e237-4897-90c2-2430527a1da7\",\n                    \"path\": \"<Gamepad>/rightStick/left\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Orbit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"right\",\n                    \"id\": \"858ac0f9-c985-4d92-a793-44c779f559ab\",\n                    \"path\": \"<Gamepad>/rightStick/right\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Gamepad\",\n                    \"action\": \"Orbit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": true\n                },\n                {\n                    \"name\": \"\",\n                    \"id\": \"a8ebc1cc-3aa1-4d4b-88d3-f03fd85805ef\",\n                    \"path\": \"<OculusTouchController>{RightHand}/thumbstick\",\n                    \"interactions\": \"\",\n                    \"processors\": \"\",\n                    \"groups\": \"Oculus Quest\",\n                    \"action\": \"Orbit\",\n                    \"isComposite\": false,\n                    \"isPartOfComposite\": false\n                }\n            ]\n        }\n    ],\n    \"controlSchemes\": [\n        {\n            \"name\": \"Keyboard Mouse\",\n            \"bindingGroup\": \"Keyboard Mouse\",\n            \"devices\": [\n                {\n                    \"devicePath\": \"<Keyboard>\",\n                    \"isOptional\": false,\n                    \"isOR\": false\n                }\n            ]\n        },\n        {\n            \"name\": \"Gamepad\",\n            \"bindingGroup\": \"Gamepad\",\n            \"devices\": []\n        },\n        {\n            \"name\": \"G920\",\n            \"bindingGroup\": \"G920\",\n            \"devices\": []\n        },\n        {\n            \"name\": \"Oculus Quest\",\n            \"bindingGroup\": \"Oculus Quest\",\n            \"devices\": []\n        }\n    ]\n}");
		m_Vehicle = asset.FindActionMap("Vehicle", throwIfNotFound: true);
		m_Vehicle_Throttle = m_Vehicle.FindAction("Throttle", throwIfNotFound: true);
		m_Vehicle_Brake = m_Vehicle.FindAction("Brake", throwIfNotFound: true);
		m_Vehicle_Steering = m_Vehicle.FindAction("Steering", throwIfNotFound: true);
		m_Vehicle_Handbrake = m_Vehicle.FindAction("Handbrake", throwIfNotFound: true);
		m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
		m_Camera_Orbit = m_Camera.FindAction("Orbit", throwIfNotFound: true);
	}

	~SCC_InputActions()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Assets.Scripts.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Assets.Scripts.Input.XR
{
	[InputControlLayout(displayName = "XR Virtual Input", stateType = typeof(XRVirtualInputDeviceState), canRunInBackground = true)]
	public class XRVirtualInputDevice : InputDevice
	{
		[StructLayout(LayoutKind.Explicit, Size = 2)]
		public struct XRVirtualInputDeviceState : IInputStateTypeInfo
		{
			[FieldOffset(0)]
			[InputControl(name = "Left Hand Default", offset = 0u, bit = 0u, layout = "Button", defaultState = true)]
			[InputControl(name = "Left Hand Flight Stick", offset = 0u, bit = 1u, layout = "Button")]
			[InputControl(name = "Left Hand Throttle", offset = 0u, bit = 2u, layout = "Button")]
			public byte LeftHand;

			[FieldOffset(1)]
			[InputControl(name = "Right Hand Default", offset = 1u, bit = 0u, layout = "Button", defaultState = true)]
			[InputControl(name = "Right Hand Flight Stick", offset = 1u, bit = 1u, layout = "Button")]
			[InputControl(name = "Right Hand Throttle", offset = 1u, bit = 2u, layout = "Button")]
			public byte RightHand;

			public FourCC format => new FourCC("SPVR");
		}

		public static class ControlNames
		{
			public const string LeftHandDefault = "Left Hand Default";

			public const string LeftHandFlightStick = "Left Hand Flight Stick";

			public const string LeftHandThrottle = "Left Hand Throttle";

			public const string RightHandDefault = "Right Hand Default";

			public const string RightHandFlightStick = "Right Hand Flight Stick";

			public const string RightHandThrottle = "Right Hand Throttle";
		}

		private static List<XRVirtualInputDevice> _allDevices;

		private XRControlGripType _leftHandGripType;

		private XRControlGripType _rightHandGripType;

		public static IReadOnlyList<XRVirtualInputDevice> All => _allDevices;

		public static XRVirtualInputDevice Current { get; private set; }

		public ButtonControl LeftHandDefaultControl { get; private set; }

		public ButtonControl LeftHandFlightStickControl { get; private set; }

		public XRControlGripType LeftHandGripType
		{
			get
			{
				return _leftHandGripType;
			}
			set
			{
				_leftHandGripType = value;
				UpdateControlState();
			}
		}

		public ButtonControl LeftHandThrottleControl { get; private set; }

		public ButtonControl RightHandDefaultControl { get; private set; }

		public ButtonControl RightHandFlightStickControl { get; private set; }

		public XRControlGripType RightHandGripType
		{
			get
			{
				return _rightHandGripType;
			}
			set
			{
				_rightHandGripType = value;
				UpdateControlState();
			}
		}

		public ButtonControl RightHandThrottleControl { get; private set; }

		public event EventHandler<EventArgs> OnStateChanged;

		static XRVirtualInputDevice()
		{
			_allDevices = new List<XRVirtualInputDevice>();
			UnityEngine.InputSystem.InputSystem.RegisterLayout<XRVirtualInputDevice>();
			foreach (InputDevice item in UnityEngine.InputSystem.InputSystem.devices.Where((InputDevice x) => x is XRVirtualInputDevice))
			{
				UnityEngine.InputSystem.InputSystem.RemoveDevice(item);
			}
			UnityEngine.InputSystem.InputSystem.AddDevice<XRVirtualInputDevice>();
		}

		public static void UpdateGrip(XRHandType handType, XRControlGripType gripType)
		{
			if (handType == XRHandType.Left)
			{
				Current.LeftHandGripType = gripType;
			}
			else
			{
				Current.RightHandGripType = gripType;
			}
		}

		public ButtonControl GetControl(XRHandType handType, XRControlGripType gripType)
		{
			return handType switch
			{
				XRHandType.Left => gripType switch
				{
					XRControlGripType.Default => LeftHandDefaultControl, 
					XRControlGripType.FlightStick => LeftHandFlightStickControl, 
					XRControlGripType.Throttle => LeftHandThrottleControl, 
					_ => throw new NotSupportedException(), 
				}, 
				XRHandType.Right => gripType switch
				{
					XRControlGripType.Default => RightHandDefaultControl, 
					XRControlGripType.FlightStick => RightHandFlightStickControl, 
					XRControlGripType.Throttle => RightHandThrottleControl, 
					_ => throw new NotSupportedException(), 
				}, 
				_ => throw new NotSupportedException(), 
			};
		}

		public XRControlGripType GetGrip(XRHandType handType)
		{
			return handType switch
			{
				XRHandType.Left => LeftHandGripType, 
				XRHandType.Right => RightHandGripType, 
				_ => throw new NotSupportedException(), 
			};
		}

		public override void MakeCurrent()
		{
			base.MakeCurrent();
			Current = this;
			this.OnStateChanged?.Invoke(this, EventArgs.Empty);
		}

		public void UpdateControlState()
		{
			UnityEngine.InputSystem.InputSystem.QueueStateEvent(this, new XRVirtualInputDeviceState
			{
				LeftHand = (byte)_leftHandGripType,
				RightHand = (byte)_rightHandGripType
			});
		}

		protected override void FinishSetup()
		{
			base.FinishSetup();
			LeftHandDefaultControl = GetChildControl<ButtonControl>("Left Hand Default");
			LeftHandFlightStickControl = GetChildControl<ButtonControl>("Left Hand Flight Stick");
			LeftHandThrottleControl = GetChildControl<ButtonControl>("Left Hand Throttle");
			RightHandDefaultControl = GetChildControl<ButtonControl>("Right Hand Default");
			RightHandFlightStickControl = GetChildControl<ButtonControl>("Right Hand Flight Stick");
			RightHandThrottleControl = GetChildControl<ButtonControl>("Right Hand Throttle");
		}

		protected override void OnAdded()
		{
			base.OnAdded();
			_allDevices.Add(this);
		}

		protected override void OnRemoved()
		{
			base.OnRemoved();
			_allDevices.Remove(this);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeInPlayer()
		{
		}
	}
}

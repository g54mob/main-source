using System.Collections.Generic;
using Assets.Scripts.Craft;
using MoonSharp.Interpreter;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class CraftControlsProxy
	{
		private AircraftControls _controls;

		private Dictionary<string, AircraftControls.InputOverride> _inputOverrides = new Dictionary<string, AircraftControls.InputOverride>();

		public float Brake
		{
			get
			{
				return _controls.Brake;
			}
			set
			{
				_controls.Brake = value;
			}
		}

		public float Flaps
		{
			get
			{
				return _controls.Flaps;
			}
			set
			{
				_controls.Flaps = value;
			}
		}

		public bool LandingGearDown
		{
			get
			{
				return _controls.LandingGearDown;
			}
			set
			{
				_controls.LandingGearDown = value;
			}
		}

		public bool ParkingBrake
		{
			get
			{
				return _controls.ParkingBrake;
			}
			set
			{
				_controls.ParkingBrake = value;
			}
		}

		public float Pitch => _controls.Pitch;

		public float Roll => _controls.Roll;

		public float TargetingPodSlewLeftRight => _controls.TargetingPodSlewLeftRight;

		public float TargetingPodSlewUpDown => _controls.TargetingPodSlewUpDown;

		public float TargetingPodZoom => _controls.TargetingPodZoom;

		public float Throttle
		{
			get
			{
				return _controls.Throttle;
			}
			set
			{
				_controls.Throttle = value;
			}
		}

		public float Trim
		{
			get
			{
				return _controls.Trim;
			}
			set
			{
				_controls.Trim = value;
			}
		}

		public float Vtol
		{
			get
			{
				return _controls.Vtol;
			}
			set
			{
				_controls.Vtol = value;
			}
		}

		public float Yaw => _controls.Yaw;

		[MoonSharpHidden]
		public CraftControlsProxy(AircraftControls controls, ProxyFactory proxyFactory)
		{
			_controls = controls;
		}

		public bool GetActivationState(int activationGroup)
		{
			return _controls.GetActivationState(activationGroup);
		}

		public void OverrideInput(string inputName, float value)
		{
			if (!_inputOverrides.TryGetValue(inputName, out var value2))
			{
				value2 = new AircraftControls.InputOverride();
				_inputOverrides[inputName] = value2;
				_controls.AddRawOverrideInput(inputName, value2);
			}
			value2.Active = true;
			value2.Value = value;
		}

		public void ReleaseInput(string inputName)
		{
			if (_inputOverrides.TryGetValue(inputName, out var value))
			{
				value.Active = false;
			}
		}

		public void ToggleActivationGroup(int activationGroup)
		{
			_controls.ActivateGroup(activationGroup - 1);
		}
	}
}

using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	public sealed class RailDriverExtension : Controller.Extension
	{
		private class SmcNMxHmxSXHbsxjiCjmRwbEeBwm : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver tUbwAYgqoHOTqkEWMKDLeIYLNEVA;

			public SmcNMxHmxSXHbsxjiCjmRwbEeBwm(IDriver_RailDriver P_0)
			{
				tUbwAYgqoHOTqkEWMKDLeIYLNEVA = P_0;
			}
		}

		private SmcNMxHmxSXHbsxjiCjmRwbEeBwm mkRqMnCrdxNVPWCGurjgXitpUroJ;

		private Joystick FJepiLOmPuYqwHfbonnqjFfGODvP => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA == null)
				{
					return false;
				}
				return mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA != null)
				{
					mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA.SpeakerEnabled = value;
				}
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new SmcNMxHmxSXHbsxjiCjmRwbEeBwm(P_0))
		{
		}

		private RailDriverExtension(RailDriverExtension P_0)
			: base(P_0)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA != null && base.enabled)
			{
				mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA != null && base.enabled)
			{
				mkRqMnCrdxNVPWCGurjgXitpUroJ.tUbwAYgqoHOTqkEWMKDLeIYLNEVA.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal void hVfhBoWsuTMAnJQSYaGZhOKriDDx(UpdateLoopType P_0)
		{
		}

		internal void FGVzPhiwEgiQwbNdkZjmUHRXiWBV(IControllerExtensionSource P_0)
		{
			mkRqMnCrdxNVPWCGurjgXitpUroJ = P_0 as SmcNMxHmxSXHbsxjiCjmRwbEeBwm;
		}

		internal Controller.Extension nVfKmKxWQFLGXpyjYuTzqpxRDSGhA()
		{
			return new RailDriverExtension(this);
		}
	}
}

using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public abstract class NintendoSwitchGamepadExtension : Controller.Extension, IControllerVibrator, IHIDControllerExtension
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		internal class ExtSource_Base : IControllerExtensionSource
		{
			private readonly IDriver_NintendoSwitchController _driver;

			public IDriver_NintendoSwitchController driver => _driver;

			public ExtSource_Base(IDriver_NintendoSwitchController P_0)
			{
				_driver = P_0;
			}
		}

		private ExtSource_Base CLFHWOuPSRLahPSSrSHZoiqMbYrk;

		private bool khVRRDZeyAQMCtyEScaUzBYcNoig;

		protected bool isValid => khVRRDZeyAQMCtyEScaUzBYcNoig;

		protected Joystick joystick => GetController<Joystick>();

		protected object source => CLFHWOuPSRLahPSSrSHZoiqMbYrk;

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					return 0;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.vibrationMotorCount;
			}
		}

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.vendorId;
			}
		}

		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.productId;
			}
		}

		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.productName;
			}
		}

		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.manufacturer;
			}
		}

		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.usagePage;
			}
		}

		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.usage;
			}
		}

		internal NintendoSwitchGamepadExtension(ExtSource_Base P_0)
			: base(P_0)
		{
		}

		protected NintendoSwitchGamepadExtension(NintendoSwitchGamepadExtension P_0)
			: base(P_0)
		{
		}

		public NintendoSwitchGamepadVibration GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return NintendoSwitchGamepadVibration.sXWuVAMffXAEbESiUTBSmHuZETpbA;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
			{
				return NintendoSwitchGamepadVibration.sXWuVAMffXAEbESiUTBSmHuZETpbA;
			}
			CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.GetVibration(motorIndex, out var amplitudeLow, out var frequencyLow, out var amplitudeHigh, out var frequencyHigh);
			return new NintendoSwitchGamepadVibration(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
			}
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, stopOtherMotors);
			}
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
			}
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, duration);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, duration, stopOtherMotors);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, stopOtherMotors);
			}
		}

		public void StopVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.StopVibration(motorIndex);
			}
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver.StopVibration();
			}
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, 0f);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, duration);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, 0f);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 160f, motorLevel, 320f, duration);
		}

		float IControllerVibrator.GetVibration(int motorIndex)
		{
			NintendoSwitchGamepadVibration vibration = GetVibration(motorIndex);
			return MathTools.Max(vibration.amplitudeLow, vibration.amplitudeHigh);
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = source as ExtSource_Base;
			khVRRDZeyAQMCtyEScaUzBYcNoig = CLFHWOuPSRLahPSSrSHZoiqMbYrk != null && CLFHWOuPSRLahPSSrSHZoiqMbYrk.driver != null;
		}
	}
}

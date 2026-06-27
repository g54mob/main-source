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

		private ExtSource_Base RaElwmdjFWESFhvjrJGFTwgJzwMG;

		private bool gLuOlSdBydYuZBWDpeEgGheMjBpF;

		protected bool isValid => gLuOlSdBydYuZBWDpeEgGheMjBpF;

		protected Joystick joystick => GetController<Joystick>();

		protected object source => RaElwmdjFWESFhvjrJGFTwgJzwMG;

		int IControllerVibrator.vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!gLuOlSdBydYuZBWDpeEgGheMjBpF)
				{
					return 0;
				}
				return RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.vibrationMotorCount;
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
				return RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.vendorId;
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
				return RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.productId;
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
				return RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.productName;
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
				return RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.manufacturer;
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
				return RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.usagePage;
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
				return RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.usage;
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
				return NintendoSwitchGamepadVibration.SjYfRcyoSgVGriXUhZbsJFPfIQhV;
			}
			if (!gLuOlSdBydYuZBWDpeEgGheMjBpF || !base.enabled)
			{
				return NintendoSwitchGamepadVibration.SjYfRcyoSgVGriXUhZbsJFPfIQhV;
			}
			RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.GetVibration(motorIndex, out var amplitudeLow, out var frequencyLow, out var amplitudeHigh, out var frequencyHigh);
			return new NintendoSwitchGamepadVibration(amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh);
			}
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, stopOtherMotors);
			}
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration);
			}
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, amplitudeLow, frequencyLow, amplitudeHigh, frequencyHigh, duration, stopOtherMotors);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, duration);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, duration, stopOtherMotors);
			}
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF && base.enabled)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.SetVibration(motorIndex, vibration.amplitudeLow, vibration.frequencyLow, vibration.amplitudeHigh, vibration.frequencyHigh, stopOtherMotors);
			}
		}

		public void StopVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.StopVibration(motorIndex);
			}
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (gLuOlSdBydYuZBWDpeEgGheMjBpF)
			{
				RaElwmdjFWESFhvjrJGFTwgJzwMG.driver.StopVibration();
			}
		}

		void IControllerVibrator.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
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
			RaElwmdjFWESFhvjrJGFTwgJzwMG = source as ExtSource_Base;
			gLuOlSdBydYuZBWDpeEgGheMjBpF = RaElwmdjFWESFhvjrJGFTwgJzwMG != null && RaElwmdjFWESFhvjrJGFTwgJzwMG.driver != null;
		}
	}
}

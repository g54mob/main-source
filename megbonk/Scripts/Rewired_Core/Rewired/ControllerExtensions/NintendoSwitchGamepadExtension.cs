using Rewired.HID.Drivers;
using Rewired.Interfaces;

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

			public IDriver_NintendoSwitchController driver => null;

			public ExtSource_Base(IDriver_NintendoSwitchController P_0)
			{
			}
		}

		private ExtSource_Base HIAOLRKKoTjvhfzIadJoFaDKrjGW;

		private bool yjoQkrShssApbZBjuCcVbAIDQtnBb;

		protected bool isValid => false;

		protected Joystick joystick => null;

		protected object source => null;

		public int vibrationMotorCount => 0;

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		internal NintendoSwitchGamepadExtension(ExtSource_Base P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		protected NintendoSwitchGamepadExtension(NintendoSwitchGamepadExtension P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		public NintendoSwitchGamepadVibration GetVibration(int motorIndex)
		{
			return default(NintendoSwitchGamepadVibration);
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration)
		{
		}

		public void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors)
		{
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration)
		{
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration)
		{
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, float duration, bool stopOtherMotors)
		{
		}

		public void SetVibration(int motorIndex, NintendoSwitchGamepadVibration vibration, bool stopOtherMotors)
		{
		}

		public void StopVibration(int motorIndex)
		{
		}

		public void StopVibration()
		{
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel)
		{
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration)
		{
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
		}

		float IControllerVibrator.GetVibration(int motorIndex)
		{
			return 0f;
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
		}
	}
}

using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		private class PLZIEKCRwbukyaJnQCOZtQncyLYt : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver gWjyUnnJhDthWicKkDleKzYoADwS;

			public PLZIEKCRwbukyaJnQCOZtQncyLYt(IDriver_RailDriver P_0)
			{
				gWjyUnnJhDthWicKkDleKzYoADwS = P_0;
			}
		}

		private PLZIEKCRwbukyaJnQCOZtQncyLYt EErnZwTCkOqxnCirSgAiBGfWDaZn;

		private Joystick joystick => GetController<Joystick>();

		public bool speakerEnabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS == null)
				{
					return false;
				}
				return EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS != null)
				{
					EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.SpeakerEnabled = value;
				}
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
				return EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.vendorId;
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
				return EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.productId;
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
				return EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.productName;
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
				return EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.manufacturer;
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
				return EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.usagePage;
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
				return EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.usage;
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new PLZIEKCRwbukyaJnQCOZtQncyLYt(P_0))
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
			else if (EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS != null && base.enabled)
			{
				EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS != null && base.enabled)
			{
				EErnZwTCkOqxnCirSgAiBGfWDaZn.gWjyUnnJhDthWicKkDleKzYoADwS.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			EErnZwTCkOqxnCirSgAiBGfWDaZn = source as PLZIEKCRwbukyaJnQCOZtQncyLYt;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}

using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		private class hUAberBcwdcFYhAuHtTsAsRpFrqr : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver EsqFVYiUnHcSqenDjoyRYzctphQeA;

			public hUAberBcwdcFYhAuHtTsAsRpFrqr(IDriver_RailDriver P_0)
			{
				EsqFVYiUnHcSqenDjoyRYzctphQeA = P_0;
			}
		}

		private hUAberBcwdcFYhAuHtTsAsRpFrqr aQmFYLEgmGKXBDMiTfrZqJNNTCpN;

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
				if (aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA == null)
				{
					return false;
				}
				return aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA != null)
				{
					aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.SpeakerEnabled = value;
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
				return aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.vendorId;
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
				return aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.productId;
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
				return aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.productName;
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
				return aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.manufacturer;
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
				return aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.usagePage;
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
				return aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.usage;
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new hUAberBcwdcFYhAuHtTsAsRpFrqr(P_0))
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
			else if (aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA != null && base.enabled)
			{
				aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA != null && base.enabled)
			{
				aQmFYLEgmGKXBDMiTfrZqJNNTCpN.EsqFVYiUnHcSqenDjoyRYzctphQeA.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			aQmFYLEgmGKXBDMiTfrZqJNNTCpN = source as hUAberBcwdcFYhAuHtTsAsRpFrqr;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}

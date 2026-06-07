using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		private class TzMZzmgwRPvMrNigLHcWDhyxaCsl : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver yDAUNClHHiAuOvIuDIwdGGkWSXRe;

			public TzMZzmgwRPvMrNigLHcWDhyxaCsl(IDriver_RailDriver P_0)
			{
				yDAUNClHHiAuOvIuDIwdGGkWSXRe = P_0;
			}
		}

		private TzMZzmgwRPvMrNigLHcWDhyxaCsl CLFHWOuPSRLahPSSrSHZoiqMbYrk;

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
				if (CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe == null)
				{
					return false;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.SpeakerEnabled;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe != null)
				{
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.SpeakerEnabled = value;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.vendorId;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.productId;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.productName;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.manufacturer;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.usagePage;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.usage;
			}
		}

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base(new TzMZzmgwRPvMrNigLHcWDhyxaCsl(P_0))
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
			else if (CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe != null && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.SetLEDDisplay(digitIndex, digitBitValues);
			}
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe != null && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.SetLEDDisplay(digit1BitValues, digit2BitValues, digit3BitValues);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = source as TzMZzmgwRPvMrNigLHcWDhyxaCsl;
		}

		internal override Controller.Extension Clone()
		{
			return new RailDriverExtension(this);
		}
	}
}

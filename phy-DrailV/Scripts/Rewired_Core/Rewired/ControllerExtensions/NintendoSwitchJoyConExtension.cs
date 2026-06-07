using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IAxisCalibrationIndexMap, IHIDControllerExtension
	{
		private class kZbhiyAvRcscQmECfpKXIvHcqrUGc : ExtSource_Base
		{
			public IDriver_NintendoSwitchJoyCon yDAUNClHHiAuOvIuDIwdGGkWSXRe => base.driver as IDriver_NintendoSwitchJoyCon;

			public kZbhiyAvRcscQmECfpKXIvHcqrUGc(IDriver_NintendoSwitchJoyCon P_0)
				: base(P_0)
			{
			}
		}

		private new kZbhiyAvRcscQmECfpKXIvHcqrUGc source => base.source as kZbhiyAvRcscQmECfpKXIvHcqrUGc;

		public NintendoSwitchJoyConType joyConType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return NintendoSwitchJoyConType.Right;
				}
				if (!base.isValid)
				{
					return NintendoSwitchJoyConType.Left;
				}
				return source.yDAUNClHHiAuOvIuDIwdGGkWSXRe.joyConType;
			}
		}

		public NintendoSwitchJoyConGripStyle joyConGripStyle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return NintendoSwitchJoyConGripStyle.Horizontal;
				}
				if (!base.isValid)
				{
					return NintendoSwitchJoyConGripStyle.Horizontal;
				}
				return source.yDAUNClHHiAuOvIuDIwdGGkWSXRe.joyConGripStyle;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (base.isValid)
				{
					source.yDAUNClHHiAuOvIuDIwdGGkWSXRe.joyConGripStyle = value;
				}
			}
		}

		internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon P_0)
			: base(new kZbhiyAvRcscQmECfpKXIvHcqrUGc(P_0))
		{
		}

		private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension P_0)
			: base(P_0)
		{
		}

		private int YBIzxDzcyfYChMyrWPUQcYmRrqJV(int P_0)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return P_0;
			}
			if (!base.isValid)
			{
				return P_0;
			}
			return source.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetMappedAxisIndex(P_0);
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in YBIzxDzcyfYChMyrWPUQcYmRrqJV
			return this.YBIzxDzcyfYChMyrWPUQcYmRrqJV(P_0);
		}

		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchJoyConExtension(this);
		}
	}
}

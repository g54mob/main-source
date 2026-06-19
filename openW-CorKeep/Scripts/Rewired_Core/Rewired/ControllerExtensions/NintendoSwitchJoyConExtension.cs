using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private class hvRglWgiwIMXQNcfIdvlllLnppTAA : ExtSource_Base
		{
			public IDriver_NintendoSwitchJoyCon TppOliNpqOWTsANXTuulKSoTIzTo => base.driver as IDriver_NintendoSwitchJoyCon;

			public hvRglWgiwIMXQNcfIdvlllLnppTAA(IDriver_NintendoSwitchJoyCon P_0)
				: base(P_0)
			{
			}
		}

		private new hvRglWgiwIMXQNcfIdvlllLnppTAA source => base.source as hvRglWgiwIMXQNcfIdvlllLnppTAA;

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
				return source.TppOliNpqOWTsANXTuulKSoTIzTo.joyConType;
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
				return source.TppOliNpqOWTsANXTuulKSoTIzTo.joyConGripStyle;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (base.isValid)
				{
					source.TppOliNpqOWTsANXTuulKSoTIzTo.joyConGripStyle = value;
				}
			}
		}

		internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon P_0)
			: base(new hvRglWgiwIMXQNcfIdvlllLnppTAA(P_0))
		{
		}

		private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension P_0)
			: base(P_0)
		{
		}

		private int GHvbSVgKZlIqZdvKfyISYenrEpsGc(int P_0)
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
			return source.TppOliNpqOWTsANXTuulKSoTIzTo.GetMappedAxisIndex(P_0);
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GHvbSVgKZlIqZdvKfyISYenrEpsGc
			return this.GHvbSVgKZlIqZdvKfyISYenrEpsGc(P_0);
		}

		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchJoyConExtension(this);
		}
	}
}

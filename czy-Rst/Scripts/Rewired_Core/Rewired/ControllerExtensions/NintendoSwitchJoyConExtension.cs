using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private class cswrQKXuPQzOLvkVwDlUFlUxUjcI : ExtSource_Base
		{
			public IDriver_NintendoSwitchJoyCon MOvncgeRMcrrtDfxOSAZibPEMqCb => base.driver as IDriver_NintendoSwitchJoyCon;

			public cswrQKXuPQzOLvkVwDlUFlUxUjcI(IDriver_NintendoSwitchJoyCon P_0)
				: base(P_0)
			{
			}
		}

		private new cswrQKXuPQzOLvkVwDlUFlUxUjcI source => base.source as cswrQKXuPQzOLvkVwDlUFlUxUjcI;

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
				return source.MOvncgeRMcrrtDfxOSAZibPEMqCb.joyConType;
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
				return source.MOvncgeRMcrrtDfxOSAZibPEMqCb.joyConGripStyle;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (base.isValid)
				{
					source.MOvncgeRMcrrtDfxOSAZibPEMqCb.joyConGripStyle = value;
				}
			}
		}

		internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon P_0)
			: base(new cswrQKXuPQzOLvkVwDlUFlUxUjcI(P_0))
		{
		}

		private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension P_0)
			: base(P_0)
		{
		}

		private int DAWURJbtcdQqGgciAgydUVuGMRTI(int P_0)
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
			return source.MOvncgeRMcrrtDfxOSAZibPEMqCb.GetMappedAxisIndex(P_0);
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DAWURJbtcdQqGgciAgydUVuGMRTI
			return this.DAWURJbtcdQqGgciAgydUVuGMRTI(P_0);
		}

		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchJoyConExtension(this);
		}
	}
}

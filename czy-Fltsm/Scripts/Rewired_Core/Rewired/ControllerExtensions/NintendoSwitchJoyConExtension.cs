using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private class bqVgrDUvGOPHiJSPREyMsDZWQoDn : ExtSource_Base
		{
			public IDriver_NintendoSwitchJoyCon FurxtjhoQChLGjdlYdxUZHamoqRyA => base.driver as IDriver_NintendoSwitchJoyCon;

			public bqVgrDUvGOPHiJSPREyMsDZWQoDn(IDriver_NintendoSwitchJoyCon P_0)
				: base(P_0)
			{
			}
		}

		private new bqVgrDUvGOPHiJSPREyMsDZWQoDn source => base.source as bqVgrDUvGOPHiJSPREyMsDZWQoDn;

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
				return source.FurxtjhoQChLGjdlYdxUZHamoqRyA.joyConType;
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
				return source.FurxtjhoQChLGjdlYdxUZHamoqRyA.joyConGripStyle;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (base.isValid)
				{
					source.FurxtjhoQChLGjdlYdxUZHamoqRyA.joyConGripStyle = value;
				}
			}
		}

		internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon P_0)
			: base(new bqVgrDUvGOPHiJSPREyMsDZWQoDn(P_0))
		{
		}

		private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension P_0)
			: base(P_0)
		{
		}

		private int GctIIAqWtfPihUjyrDZtzQxfEemCA(int P_0)
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
			return source.FurxtjhoQChLGjdlYdxUZHamoqRyA.GetMappedAxisIndex(P_0);
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GctIIAqWtfPihUjyrDZtzQxfEemCA
			return this.GctIIAqWtfPihUjyrDZtzQxfEemCA(P_0);
		}

		internal override Controller.Extension Clone()
		{
			return new NintendoSwitchJoyConExtension(this);
		}
	}
}

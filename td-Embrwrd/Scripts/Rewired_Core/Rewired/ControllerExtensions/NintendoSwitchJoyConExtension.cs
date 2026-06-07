using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private class lPtHKbzAWCtjpJjlCtrJRdhCEcbk : ExtSource_Base
		{
			public IDriver_NintendoSwitchJoyCon DOTRrDOEGGKhVtMFDCyNipSoHCnM => null;

			public lPtHKbzAWCtjpJjlCtrJRdhCEcbk(IDriver_NintendoSwitchJoyCon P_0)
				: base(null)
			{
			}
		}

		private new lPtHKbzAWCtjpJjlCtrJRdhCEcbk source => null;

		public NintendoSwitchJoyConType joyConType => default(NintendoSwitchJoyConType);

		public NintendoSwitchJoyConGripStyle joyConGripStyle
		{
			get
			{
				return default(NintendoSwitchJoyConGripStyle);
			}
			set
			{
			}
		}

		internal NintendoSwitchJoyConExtension(IDriver_NintendoSwitchJoyCon P_0)
			: base((ExtSource_Base)null)
		{
		}

		private NintendoSwitchJoyConExtension(NintendoSwitchJoyConExtension P_0)
			: base((ExtSource_Base)null)
		{
		}

		private int IBXwKeDpkrKImCOguCrwENOhEOOE(int P_0)
		{
			return 0;
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IBXwKeDpkrKImCOguCrwENOhEOOE
			return this.IBXwKeDpkrKImCOguCrwENOhEOOE(P_0);
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}
	}
}

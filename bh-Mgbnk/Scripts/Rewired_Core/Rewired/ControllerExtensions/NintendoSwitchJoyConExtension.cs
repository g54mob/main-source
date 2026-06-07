using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class NintendoSwitchJoyConExtension : NintendoSwitchGamepadExtension, IControllerVibrator, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		private class kkauNtuyeXRYdhayjRZhNEdoiQiO : ExtSource_Base
		{
			public IDriver_NintendoSwitchJoyCon IHSJLFFPqVWUPLrOiwKniNUWhYmo => null;

			public kkauNtuyeXRYdhayjRZhNEdoiQiO(IDriver_NintendoSwitchJoyCon P_0)
				: base(null)
			{
			}
		}

		private new kkauNtuyeXRYdhayjRZhNEdoiQiO source => null;

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

		private int DOWYuuCxLopzemsHPrmQQzDXGEZO(int P_0)
		{
			return 0;
		}

		int IAxisCalibrationIndexMap.GetMappedAxisIndex(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in DOWYuuCxLopzemsHPrmQQzDXGEZO
			return this.DOWYuuCxLopzemsHPrmQQzDXGEZO(P_0);
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}
	}
}

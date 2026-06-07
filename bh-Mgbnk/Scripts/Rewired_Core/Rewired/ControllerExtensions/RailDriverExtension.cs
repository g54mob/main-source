using Rewired.HID.Drivers;
using Rewired.Interfaces;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class RailDriverExtension : Controller.Extension, IHIDControllerExtension
	{
		private class LCVyxVtTEqVKmsMbLGDenKslHvWd : IControllerExtensionSource
		{
			public readonly IDriver_RailDriver sJxOWMAkKStUayWjbivTSDxhjBmW;

			public LCVyxVtTEqVKmsMbLGDenKslHvWd(IDriver_RailDriver P_0)
			{
			}
		}

		private LCVyxVtTEqVKmsMbLGDenKslHvWd AXrvFTqBBRyTLCTKRVgJDWCNOaDw;

		private Joystick joystick => null;

		public bool speakerEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		ushort IHIDControllerExtension.vendorId => 0;

		ushort IHIDControllerExtension.productId => 0;

		string IHIDControllerExtension.productName => null;

		string IHIDControllerExtension.manufacturer => null;

		ushort IHIDControllerExtension.usagePage => 0;

		ushort IHIDControllerExtension.usage => 0;

		internal RailDriverExtension(IDriver_RailDriver P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		private RailDriverExtension(RailDriverExtension P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}
	}
}

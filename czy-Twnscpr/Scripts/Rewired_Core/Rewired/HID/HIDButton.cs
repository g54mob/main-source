using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class HIDButton : HIDControllerElement
	{
		public bool rawValue;

		public double timestamp;

		public HIDButton(byte reportId, HIDInfo hidInfo)
			: base(0, null)
		{
		}

		public void SetValue(bool rawValue, double timestamp)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}
	}
}

using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class HIDAxis : HIDControllerElement
	{
		public int rawValue;

		public double timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly bool isSigned;

		public readonly int minValue;

		public readonly int maxValue;

		public readonly int zeroValue;

		public HIDAxis(byte reportId, HIDInfo hidInfo, bool isSigned, int zeroValue)
			: base(0, null)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}
	}
}

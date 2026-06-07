using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation]
	[CustomObfuscation]
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

		public HIDAxis(byte P_0, HIDInfo P_1, bool P_2, int P_3)
			: base(0, null)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}
	}
}

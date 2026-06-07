using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class HIDHat : HIDControllerElement
	{
		[CustomObfuscation]
		public enum Type
		{
			rtZeaGYdnxErDlhHCATYxlVGdfR = 0,
			QDEXJJzRtksYzHMOOjNdCBndUcp = 1
		}

		public int rawValue;

		public double timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly Type type;

		private Func<int, int> aBkwvBxNjKIXVZOKpRDdtzLzPtG;

		public HIDHat(byte reportId, HIDInfo hidInfo, Type type)
			: base(0, null)
		{
		}

		public HIDHat(byte reportId, HIDInfo hidInfo, Func<int, int> calcValueDelegate)
			: base(0, null)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}
	}
}

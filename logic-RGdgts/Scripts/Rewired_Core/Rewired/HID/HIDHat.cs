using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal class HIDHat : HIDControllerElement
	{
		[CustomObfuscation]
		public enum Type
		{
			Default = 0,
			Custom = 1
		}

		public int rawValue;

		public double timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly Type type;

		private Func<int, int> beJEcrXOTGYSxTusyERABNLRUOHi;

		public HIDHat(byte P_0, HIDInfo P_1, Type P_2)
			: base(0, null)
		{
		}

		public HIDHat(byte P_0, HIDInfo P_1, Func<int, int> P_2)
			: base(0, null)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}
	}
}

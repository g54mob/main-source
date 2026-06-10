using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDHat : HIDControllerElement
	{
		[CustomObfuscation(rename = false)]
		public enum Type
		{
			soslOrkvDFHDBhrHGqawPholAxZ = 0,
			RgddFgBdHUHnpTAUAyBTcTKWcrd = 1
		}

		public int rawValue;

		public double timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly Type type;

		private Func<int, int> vrTNvuHNfsMeNBJMfsKFDavSbwO;

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

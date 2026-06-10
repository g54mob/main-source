using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDAccelerometer : HIDControllerElement
	{
		public readonly float[] rawValue;

		public double timestamp;

		public readonly int valueLength;

		private readonly byte[] WjBTdtDZYvedQWLAVjzWrYaSrtg;

		private readonly int JWdDdMAsITCbxvmnBhcXhjuxyZY;

		private readonly int HLXnQkKonzrsPAIAVEMWIUZSZmJK;

		private readonly Action<byte[], float[]> vrTNvuHNfsMeNBJMfsKFDavSbwO;

		public HIDAccelerometer(byte reportId, HIDInfo hidInfo, int valueLength, Action<byte[], float[]> calcValueDelegate)
			: base(0, null)
		{
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
		}
	}
}

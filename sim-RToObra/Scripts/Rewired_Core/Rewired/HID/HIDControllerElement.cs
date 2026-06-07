using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDControllerElement
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal class HIDInfo
		{
			public ushort usagePage;

			public ushort usage;

			public int dataIndex;

			public int bitSize;

			public int logicalMin;

			public int logicalMax;

			public int physicalMin;

			public int physicalMax;

			public uint units;

			public uint unitsExp;
		}

		public readonly byte reportId;

		public readonly HIDInfo hidInfo;

		public HIDControllerElement(byte reportId, HIDInfo hidInfo)
		{
			this.reportId = reportId;
			this.hidInfo = hidInfo;
		}

		public abstract void UpdateValue(NativeBuffer inputReport, float timestamp);
	}
}

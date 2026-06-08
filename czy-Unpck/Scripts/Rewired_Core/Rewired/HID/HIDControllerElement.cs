using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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
			while (true)
			{
				int num = 844143711;
				while (true)
				{
					switch (num ^ 0x32509C5E)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 0:
						return;
					}
					break;
					IL_0024:
					this.reportId = reportId;
					this.hidInfo = hidInfo;
					num = 844143710;
				}
			}
		}

		public abstract void UpdateValue(NativeBuffer inputReport, double timestamp);
	}
}

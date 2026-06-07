using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal abstract class HIDControllerElement
	{
		[CustomClassObfuscation]
		[CustomObfuscation]
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

		public HIDControllerElement(byte P_0, HIDInfo P_1)
		{
		}

		public abstract void UpdateValue(NativeBuffer inputReport, double timestamp);
	}
}

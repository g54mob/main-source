using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDAxis : HIDControllerElement
	{
		public int rawValue;

		public float timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly bool isSigned;

		public readonly int minValue;

		public readonly int maxValue;

		public readonly int zeroValue;

		public HIDAxis(byte reportId, HIDInfo hidInfo, bool isSigned, int zeroValue)
			: base(reportId, hidInfo)
		{
			byteLength = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			startIndex = hidInfo.dataIndex;
			this.isSigned = isSigned;
			minValue = hidInfo.logicalMin;
			maxValue = hidInfo.logicalMax;
			this.zeroValue = zeroValue;
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			int num2 = default(int);
			int num3 = default(int);
			while (inputReport[0] == reportId)
			{
				while (true)
				{
					this.timestamp = timestamp;
					int num = -1462975582;
					while (true)
					{
						switch (num ^ -1462975582)
						{
						case 6:
							num = -1462975577;
							continue;
						case 7:
							num2 |= inputReport[startIndex + num3] << 8 * num3;
							num3++;
							num = -1462975578;
							continue;
						case 0:
							num2 = 0;
							num = -1462975583;
							continue;
						case 2:
							break;
						case 3:
							if (byteLength > 1)
							{
								num3 = 0;
								num = -1462975578;
								continue;
							}
							goto case 8;
						case 4:
							if (num3 >= byteLength)
							{
								num = -1462975581;
								continue;
							}
							goto case 7;
						case 5:
							goto end_IL_006c;
						case 8:
							num2 = inputReport[startIndex];
							num = -1462975581;
							continue;
						default:
							rawValue = num2;
							return;
						}
						break;
					}
					continue;
					end_IL_006c:
					break;
				}
			}
		}
	}
}

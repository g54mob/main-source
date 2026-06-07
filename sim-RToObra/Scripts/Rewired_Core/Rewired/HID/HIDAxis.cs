using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
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
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (inputReport[0] != reportId)
				{
					num = -1673453612;
					num2 = num;
				}
				else
				{
					num = -1673453610;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1673453613)
					{
					case 3:
						num = -1673453605;
						continue;
					case 2:
						num3 |= inputReport[startIndex + num4] << 8 * num4;
						num = -1673453607;
						continue;
					case 7:
						return;
					case 5:
						this.timestamp = timestamp;
						num3 = 0;
						num = -1673453609;
						continue;
					case 4:
						if (byteLength > 1)
						{
							num4 = 0;
							num = -1673453613;
							continue;
						}
						goto case 9;
					case 10:
						num4++;
						num = -1673453613;
						continue;
					case 0:
					{
						int num5;
						if (num4 >= byteLength)
						{
							num = -1673453614;
							num5 = num;
						}
						else
						{
							num = -1673453615;
							num5 = num;
						}
						continue;
					}
					case 9:
						num3 = inputReport[startIndex];
						num = -1673453611;
						continue;
					case 8:
						break;
					case 1:
						num = -1673453611;
						continue;
					default:
						rawValue = num3;
						return;
					}
					break;
				}
			}
		}
	}
}

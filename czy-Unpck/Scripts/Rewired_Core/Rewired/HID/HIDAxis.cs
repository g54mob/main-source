using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
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

		public HIDAxis(byte reportId, HIDInfo hidInfo, bool isSigned, int zeroValue)
			: base(reportId, hidInfo)
		{
			while (true)
			{
				int num = 352397440;
				while (true)
				{
					switch (num ^ 0x15012881)
					{
					case 3:
						break;
					case 1:
						byteLength = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
						num = 352397441;
						continue;
					case 0:
						startIndex = hidInfo.dataIndex;
						num = 352397443;
						continue;
					default:
						this.isSigned = isSigned;
						minValue = hidInfo.logicalMin;
						maxValue = hidInfo.logicalMax;
						this.zeroValue = zeroValue;
						return;
					}
					break;
				}
			}
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			int num3 = default(int);
			while (inputReport[0] == reportId)
			{
				while (true)
				{
					this.timestamp = timestamp;
					int num = 0;
					int num2 = 578224568;
					while (true)
					{
						switch (num2 ^ 0x227701B1)
						{
						case 7:
							num2 = 578224565;
							continue;
						case 0:
							num = inputReport[startIndex];
							num2 = 578224563;
							continue;
						case 8:
							break;
						case 6:
							num2 = 578224564;
							continue;
						case 9:
							if (byteLength > 1)
							{
								num3 = 0;
								num2 = 578224567;
								continue;
							}
							goto case 0;
						case 4:
							goto end_IL_0055;
						case 3:
							num2 = 578224563;
							continue;
						case 5:
							goto IL_00a2;
						case 1:
							num |= inputReport[startIndex + num3] << 8 * num3;
							num3++;
							num2 = 578224564;
							continue;
						default:
							rawValue = num;
							return;
						}
						break;
						IL_00a2:
						int num4;
						if (num3 >= byteLength)
						{
							num2 = 578224562;
							num4 = num2;
						}
						else
						{
							num2 = 578224560;
							num4 = num2;
						}
					}
					continue;
					end_IL_0055:
					break;
				}
			}
		}
	}
}

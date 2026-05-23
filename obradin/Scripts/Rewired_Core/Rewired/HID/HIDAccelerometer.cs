using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDAccelerometer : HIDControllerElement
	{
		public readonly float[] rawValue;

		public float timestamp;

		public readonly int valueLength;

		private readonly byte[] gFAMGFphEQAPPIsOqIUOiYImMxyK;

		private readonly int bzosNyaAYkqqmjdsmYcZCYXPqkG;

		private readonly int bKUWnIefrIOAGALIeelSjbpyaaDm;

		private readonly Action<byte[], float[]> LpQqRQdQRXwpWRSAKJEFyQEozHE;

		public HIDAccelerometer(byte reportId, HIDInfo hidInfo, int valueLength, Action<byte[], float[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			this.valueLength = valueLength;
			LpQqRQdQRXwpWRSAKJEFyQEozHE = calcValueDelegate;
			bzosNyaAYkqqmjdsmYcZCYXPqkG = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			bKUWnIefrIOAGALIeelSjbpyaaDm = hidInfo.dataIndex;
			gFAMGFphEQAPPIsOqIUOiYImMxyK = new byte[bzosNyaAYkqqmjdsmYcZCYXPqkG];
			rawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (inputReport[0] != reportId)
				{
					num = -1801465495;
					num2 = num;
				}
				else
				{
					num = -1801465494;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1801465496)
					{
					case 0:
						num = -1801465492;
						continue;
					default:
						return;
					case 4:
						break;
					case 5:
						if (num3 >= bzosNyaAYkqqmjdsmYcZCYXPqkG)
						{
							if (LpQqRQdQRXwpWRSAKJEFyQEozHE != null)
							{
								LpQqRQdQRXwpWRSAKJEFyQEozHE(gFAMGFphEQAPPIsOqIUOiYImMxyK, rawValue);
								num = -1801465493;
								continue;
							}
							return;
						}
						goto case 6;
					case 1:
						return;
					case 2:
						this.timestamp = timestamp;
						num3 = 0;
						num = -1801465491;
						continue;
					case 6:
						gFAMGFphEQAPPIsOqIUOiYImMxyK[num3] = inputReport[bKUWnIefrIOAGALIeelSjbpyaaDm + num3];
						num3++;
						num = -1801465491;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}
	}
}

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

		private readonly byte[] ybAmuZnIfWhorLsqFnPHtbotknK;

		private readonly int noaSAguGveQGKaOFNqtKfOcYBgaj;

		private readonly int xrQLQGuApYmYgXwMFUFFCIVdarb;

		private readonly Action<byte[], float[]> PqMrIShMeNFMoGUmfXsQkHylWpwc;

		public HIDAccelerometer(byte reportId, HIDInfo hidInfo, int valueLength, Action<byte[], float[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			this.valueLength = valueLength;
			PqMrIShMeNFMoGUmfXsQkHylWpwc = calcValueDelegate;
			noaSAguGveQGKaOFNqtKfOcYBgaj = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			xrQLQGuApYmYgXwMFUFFCIVdarb = hidInfo.dataIndex;
			ybAmuZnIfWhorLsqFnPHtbotknK = new byte[noaSAguGveQGKaOFNqtKfOcYBgaj];
			rawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport == null)
			{
				goto IL_0006;
			}
			goto IL_0095;
			IL_0006:
			int num = 1834486006;
			goto IL_000b;
			IL_000b:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x6D5808F3)
				{
				case 7:
					break;
				default:
					return;
				case 4:
					if (num2 >= noaSAguGveQGKaOFNqtKfOcYBgaj)
					{
						if (PqMrIShMeNFMoGUmfXsQkHylWpwc != null)
						{
							PqMrIShMeNFMoGUmfXsQkHylWpwc(ybAmuZnIfWhorLsqFnPHtbotknK, rawValue);
							num = 1834486005;
							continue;
						}
						return;
					}
					goto case 0;
				case 0:
					ybAmuZnIfWhorLsqFnPHtbotknK[num2] = inputReport[xrQLQGuApYmYgXwMFUFFCIVdarb + num2];
					num = 1834486001;
					continue;
				case 5:
					return;
				case 3:
					goto IL_0095;
				case 2:
					num2++;
					num = 1834486007;
					continue;
				case 1:
					goto IL_00bd;
				case 6:
					return;
				}
				break;
			}
			goto IL_0006;
			IL_00bd:
			this.timestamp = timestamp;
			num2 = 0;
			num = 1834486007;
			goto IL_000b;
			IL_0095:
			if (inputReport[0] != reportId)
			{
				return;
			}
			goto IL_00bd;
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			int num2 = default(int);
			while (true)
			{
				int num = 701974620;
				while (true)
				{
					switch (num ^ 0x29D7485E)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						num2 = 0;
						num = 701974623;
						continue;
					case 3:
						rawValue[num2] = value[num2];
						num2++;
						num = 701974623;
						continue;
					case 1:
					{
						int num3;
						if (num2 >= valueLength)
						{
							num = 701974618;
							num3 = num;
						}
						else
						{
							num = 701974621;
							num3 = num;
						}
						continue;
					}
					case 4:
						return;
					}
					break;
				}
			}
		}
	}
}

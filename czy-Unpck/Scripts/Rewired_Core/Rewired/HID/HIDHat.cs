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
			MmjTFHSDiyTigcMhWyazRFaMhlp = 0,
			nWmlkIpvopTHEIQiYbcEoLWzsmD = 1
		}

		public int rawValue;

		public double timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly Type type;

		private Func<int, int> PqMrIShMeNFMoGUmfXsQkHylWpwc;

		public HIDHat(byte reportId, HIDInfo hidInfo, Type type)
			: base(reportId, hidInfo)
		{
			this.type = type;
			byteLength = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			startIndex = hidInfo.dataIndex;
		}

		public HIDHat(byte reportId, HIDInfo hidInfo, Func<int, int> calcValueDelegate)
			: this(reportId, hidInfo, Type.nWmlkIpvopTHEIQiYbcEoLWzsmD)
		{
			PqMrIShMeNFMoGUmfXsQkHylWpwc = calcValueDelegate;
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			Type type = default(Type);
			int num2 = default(int);
			while (inputReport[0] == reportId)
			{
				while (true)
				{
					IL_00e4:
					this.timestamp = timestamp;
					int num;
					if (byteLength == 1)
					{
						rawValue = inputReport[startIndex];
						num = -655665870;
						goto IL_000c;
					}
					goto IL_006c;
					IL_000c:
					while (true)
					{
						switch (num ^ -655665872)
						{
						case 6:
							num = -655665868;
							continue;
						default:
							return;
						case 2:
							type = this.type;
							num = -655665872;
							continue;
						case 8:
							break;
						case 7:
							goto end_IL_000c;
						case 1:
							rawValue |= inputReport[startIndex + num2] << 8 * num2;
							num2++;
							num = -655665864;
							continue;
						case 0:
							if (type != Type.nWmlkIpvopTHEIQiYbcEoLWzsmD)
							{
								return;
							}
							goto case 5;
						case 5:
							if (PqMrIShMeNFMoGUmfXsQkHylWpwc != null)
							{
								rawValue = PqMrIShMeNFMoGUmfXsQkHylWpwc(rawValue);
								num = -655665863;
								continue;
							}
							return;
						case 3:
							goto IL_00e4;
						case 4:
							goto end_IL_00e4;
						case 9:
							return;
						}
						int num3;
						if (num2 >= byteLength)
						{
							num = -655665870;
							num3 = num;
						}
						else
						{
							num = -655665871;
							num3 = num;
						}
						continue;
						end_IL_000c:
						break;
					}
					goto IL_006c;
					IL_006c:
					rawValue = 0;
					num2 = 0;
					num = -655665864;
					goto IL_000c;
					continue;
					end_IL_00e4:
					break;
				}
			}
		}
	}
}

using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDHat : HIDControllerElement
	{
		[CustomObfuscation(rename = false)]
		public enum Type
		{
			lovekWDeNaySbPLGHuFoaPKBTySM = 0,
			OSoXKRRBZfHUVjWFHAZRkYacHta = 1
		}

		public int rawValue;

		public float timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly Type type;

		private Func<int, int> mrYChTVqXTCVxhzNiXVDRNAiSmHs;

		public HIDHat(byte reportId, HIDInfo hidInfo, Type type)
			: base(reportId, hidInfo)
		{
			while (true)
			{
				int num = -346064336;
				while (true)
				{
					switch (num ^ -346064334)
					{
					case 0:
						break;
					case 2:
						goto IL_0026;
					default:
						byteLength = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
						startIndex = hidInfo.dataIndex;
						return;
					}
					break;
					IL_0026:
					this.type = type;
					num = -346064333;
				}
			}
		}

		public HIDHat(byte reportId, HIDInfo hidInfo, Func<int, int> calcValueDelegate)
			: this(reportId, hidInfo, Type.OSoXKRRBZfHUVjWFHAZRkYacHta)
		{
			mrYChTVqXTCVxhzNiXVDRNAiSmHs = calcValueDelegate;
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			int num2 = default(int);
			while (inputReport[0] == reportId)
			{
				while (true)
				{
					IL_0056:
					this.timestamp = timestamp;
					int num;
					if (byteLength == 1)
					{
						rawValue = inputReport[startIndex];
						num = 425034857;
						goto IL_000c;
					}
					goto IL_0048;
					IL_000c:
					while (true)
					{
						switch (num ^ 0x1955846A)
						{
						case 5:
							num = 425034848;
							continue;
						default:
							return;
						case 9:
							break;
						case 8:
							goto IL_0056;
						case 6:
							if (mrYChTVqXTCVxhzNiXVDRNAiSmHs != null)
							{
								rawValue = mrYChTVqXTCVxhzNiXVDRNAiSmHs(rawValue);
								num = 425034859;
								continue;
							}
							return;
						case 2:
							rawValue |= inputReport[startIndex + num2] << 8 * num2;
							num = 425034858;
							continue;
						case 0:
							num2++;
							num = 425034861;
							continue;
						case 7:
							goto IL_00e5;
						case 3:
						{
							Type type = this.type;
							if (type != Type.OSoXKRRBZfHUVjWFHAZRkYacHta)
							{
								return;
							}
							goto case 6;
						}
						case 4:
							num2 = 0;
							num = 425034861;
							continue;
						case 10:
							goto end_IL_0056;
						case 1:
							return;
						}
						break;
						IL_00e5:
						int num3;
						if (num2 < byteLength)
						{
							num = 425034856;
							num3 = num;
						}
						else
						{
							num = 425034857;
							num3 = num;
						}
					}
					goto IL_0048;
					IL_0048:
					rawValue = 0;
					num = 425034862;
					goto IL_000c;
					continue;
					end_IL_0056:
					break;
				}
			}
		}
	}
}

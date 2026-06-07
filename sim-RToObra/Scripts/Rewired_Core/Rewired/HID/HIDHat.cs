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
			ArjUpFKKDkOtOldZpRLmmMUFaxP = 0,
			djmWmEhmVdfksZwGfNzZHFuqaoh = 1
		}

		public int rawValue;

		public float timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly Type type;

		private Func<int, int> LpQqRQdQRXwpWRSAKJEFyQEozHE;

		public HIDHat(byte reportId, HIDInfo hidInfo, Type type)
			: base(reportId, hidInfo)
		{
			this.type = type;
			byteLength = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			startIndex = hidInfo.dataIndex;
		}

		public HIDHat(byte reportId, HIDInfo hidInfo, Func<int, int> calcValueDelegate)
			: this(reportId, hidInfo, Type.djmWmEhmVdfksZwGfNzZHFuqaoh)
		{
			while (true)
			{
				int num = -1473219522;
				while (true)
				{
					switch (num ^ -1473219521)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0027;
					case 0:
						return;
					}
					break;
					IL_0027:
					LpQqRQdQRXwpWRSAKJEFyQEozHE = calcValueDelegate;
					num = -1473219521;
				}
			}
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (inputReport == null)
			{
				goto IL_0003;
			}
			goto IL_0059;
			IL_0003:
			int num = 1983634073;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x763BDA94)
				{
				case 2:
					break;
				default:
					return;
				case 0:
					num2 = 0;
					num = 1983634067;
					continue;
				case 5:
					goto IL_0059;
				case 6:
					goto IL_0070;
				case 13:
					return;
				case 3:
				{
					Type type = this.type;
					if (type != Type.djmWmEhmVdfksZwGfNzZHFuqaoh)
					{
						return;
					}
					goto case 11;
				}
				case 10:
					goto IL_00c0;
				case 9:
					rawValue |= inputReport[startIndex + num2] << 8 * num2;
					num = 1983634069;
					continue;
				case 1:
					num2++;
					num = 1983634072;
					continue;
				case 7:
					num = 1983634072;
					continue;
				case 8:
					rawValue = LpQqRQdQRXwpWRSAKJEFyQEozHE(rawValue);
					num = 1983634064;
					continue;
				case 12:
					goto IL_0136;
				case 11:
				{
					int num3;
					if (LpQqRQdQRXwpWRSAKJEFyQEozHE == null)
					{
						num = 1983634064;
						num3 = num;
					}
					else
					{
						num = 1983634076;
						num3 = num;
					}
					continue;
				}
				case 4:
					return;
				}
				break;
				IL_0136:
				int num4;
				if (num2 >= byteLength)
				{
					num = 1983634071;
					num4 = num;
				}
				else
				{
					num = 1983634077;
					num4 = num;
				}
			}
			goto IL_0003;
			IL_0059:
			if (inputReport[0] != reportId)
			{
				return;
			}
			goto IL_0070;
			IL_0070:
			this.timestamp = timestamp;
			if (byteLength == 1)
			{
				rawValue = inputReport[startIndex];
				num = 1983634071;
				goto IL_0008;
			}
			goto IL_00c0;
			IL_00c0:
			rawValue = 0;
			num = 1983634068;
			goto IL_0008;
		}
	}
}

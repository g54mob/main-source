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
			wLCbAjleYPUOhAnzgTfrtJigKYl = 0,
			NWLeGVMpwYQrycduyLxSAFfLdRo = 1
		}

		public int rawValue;

		public double timestamp;

		public readonly int byteLength;

		public readonly int startIndex;

		public readonly Type type;

		private Func<int, int> pqrKeHQWeadJSqleTZRUlVDJKvR;

		public HIDHat(byte reportId, HIDInfo hidInfo, Type type)
			: base(reportId, hidInfo)
		{
			this.type = type;
			byteLength = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			startIndex = hidInfo.dataIndex;
		}

		public HIDHat(byte reportId, HIDInfo hidInfo, Func<int, int> calcValueDelegate)
			: this(reportId, hidInfo, Type.NWLeGVMpwYQrycduyLxSAFfLdRo)
		{
			pqrKeHQWeadJSqleTZRUlVDJKvR = calcValueDelegate;
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport == null || inputReport[0] != reportId)
			{
				return;
			}
			this.timestamp = timestamp;
			if (byteLength == 1)
			{
				rawValue = inputReport[startIndex];
			}
			else
			{
				rawValue = 0;
				for (int i = 0; i < byteLength; i++)
				{
					rawValue |= inputReport[startIndex + i] << 8 * i;
				}
			}
			Type type = this.type;
			if (type == Type.NWLeGVMpwYQrycduyLxSAFfLdRo && pqrKeHQWeadJSqleTZRUlVDJKvR != null)
			{
				rawValue = pqrKeHQWeadJSqleTZRUlVDJKvR(rawValue);
			}
		}
	}
}

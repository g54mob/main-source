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

		private readonly byte[] AdxOwSUcljDyFjRmfEYTVcHFHWn;

		private readonly int DOPAwzeHpXMLiMURxiQQbXTchRDO;

		private readonly int LfdrVVNOhonEGxepQjJXoyTABIg;

		private readonly Action<byte[], float[]> pqrKeHQWeadJSqleTZRUlVDJKvR;

		public HIDAccelerometer(byte reportId, HIDInfo hidInfo, int valueLength, Action<byte[], float[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			this.valueLength = valueLength;
			pqrKeHQWeadJSqleTZRUlVDJKvR = calcValueDelegate;
			DOPAwzeHpXMLiMURxiQQbXTchRDO = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			LfdrVVNOhonEGxepQjJXoyTABIg = hidInfo.dataIndex;
			AdxOwSUcljDyFjRmfEYTVcHFHWn = new byte[DOPAwzeHpXMLiMURxiQQbXTchRDO];
			rawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < DOPAwzeHpXMLiMURxiQQbXTchRDO; i++)
				{
					AdxOwSUcljDyFjRmfEYTVcHFHWn[i] = inputReport[LfdrVVNOhonEGxepQjJXoyTABIg + i];
				}
				if (pqrKeHQWeadJSqleTZRUlVDJKvR != null)
				{
					pqrKeHQWeadJSqleTZRUlVDJKvR(AdxOwSUcljDyFjRmfEYTVcHFHWn, rawValue);
				}
			}
		}

		public void UpdateValueManual(float[] value, double timestamp)
		{
			this.timestamp = timestamp;
			for (int i = 0; i < valueLength; i++)
			{
				rawValue[i] = value[i];
			}
		}
	}
}

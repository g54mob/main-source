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

		private readonly byte[] ygBnhstaMsNZJqoUaYPAJacvJML;

		private readonly int vrjlRLuDGYauaDVzaaERkJgMYFrV;

		private readonly int ldNQcpwSvgIMMslOcdrMkwBpFme;

		private readonly Action<byte[], float[]> LwNYNnvqFdEqEdoUCzJLnqopZQt;

		public HIDAccelerometer(byte reportId, HIDInfo hidInfo, int valueLength, Action<byte[], float[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			this.valueLength = valueLength;
			LwNYNnvqFdEqEdoUCzJLnqopZQt = calcValueDelegate;
			vrjlRLuDGYauaDVzaaERkJgMYFrV = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			ldNQcpwSvgIMMslOcdrMkwBpFme = hidInfo.dataIndex;
			ygBnhstaMsNZJqoUaYPAJacvJML = new byte[vrjlRLuDGYauaDVzaaERkJgMYFrV];
			rawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < vrjlRLuDGYauaDVzaaERkJgMYFrV; i++)
				{
					ygBnhstaMsNZJqoUaYPAJacvJML[i] = inputReport[ldNQcpwSvgIMMslOcdrMkwBpFme + i];
				}
				if (LwNYNnvqFdEqEdoUCzJLnqopZQt != null)
				{
					LwNYNnvqFdEqEdoUCzJLnqopZQt(ygBnhstaMsNZJqoUaYPAJacvJML, rawValue);
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

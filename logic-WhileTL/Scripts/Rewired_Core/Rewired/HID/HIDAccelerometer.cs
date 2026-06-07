using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HIDAccelerometer : HIDControllerElement
	{
		public readonly float[] rawValue;

		public double timestamp;

		public readonly int valueLength;

		private readonly byte[] OvJPmqJRIZNlsGSkQORNnRZZlSxW;

		private readonly int NJbSkPWaMdUdHdXFONlIjAJkDZNm;

		private readonly int NaHbXfYtdHeedcEgOLeXGEoVVVQgA;

		private readonly Action<byte[], float[]> beJEcrXOTGYSxTusyERABNLRUOHi;

		public HIDAccelerometer(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
			: base(P_0, P_1)
		{
			valueLength = P_2;
			beJEcrXOTGYSxTusyERABNLRUOHi = P_3;
			NJbSkPWaMdUdHdXFONlIjAJkDZNm = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
			NaHbXfYtdHeedcEgOLeXGEoVVVQgA = P_1.dataIndex;
			OvJPmqJRIZNlsGSkQORNnRZZlSxW = new byte[NJbSkPWaMdUdHdXFONlIjAJkDZNm];
			rawValue = new float[P_2];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < NJbSkPWaMdUdHdXFONlIjAJkDZNm; i++)
				{
					OvJPmqJRIZNlsGSkQORNnRZZlSxW[i] = inputReport[NaHbXfYtdHeedcEgOLeXGEoVVVQgA + i];
				}
				if (beJEcrXOTGYSxTusyERABNLRUOHi != null)
				{
					beJEcrXOTGYSxTusyERABNLRUOHi(OvJPmqJRIZNlsGSkQORNnRZZlSxW, rawValue);
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

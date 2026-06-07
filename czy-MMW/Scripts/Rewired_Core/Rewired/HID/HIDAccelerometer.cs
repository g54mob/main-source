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

		private readonly byte[] SjTTEaKHIIbNVffTLcCyJllDIgDg;

		private readonly int KIqpWVPeKUBcKfrCYSrWbKgAfFnQb;

		private readonly int CUbGlJifuGQOZPbZWDXywHJwfJAL;

		private readonly Action<byte[], float[]> cQRMxfDkjBPONrgDjNUXHHXUsnpq;

		public HIDAccelerometer(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
			: base(P_0, P_1)
		{
			valueLength = P_2;
			cQRMxfDkjBPONrgDjNUXHHXUsnpq = P_3;
			KIqpWVPeKUBcKfrCYSrWbKgAfFnQb = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
			CUbGlJifuGQOZPbZWDXywHJwfJAL = P_1.dataIndex;
			SjTTEaKHIIbNVffTLcCyJllDIgDg = new byte[KIqpWVPeKUBcKfrCYSrWbKgAfFnQb];
			rawValue = new float[P_2];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < KIqpWVPeKUBcKfrCYSrWbKgAfFnQb; i++)
				{
					SjTTEaKHIIbNVffTLcCyJllDIgDg[i] = inputReport[CUbGlJifuGQOZPbZWDXywHJwfJAL + i];
				}
				if (cQRMxfDkjBPONrgDjNUXHHXUsnpq != null)
				{
					cQRMxfDkjBPONrgDjNUXHHXUsnpq(SjTTEaKHIIbNVffTLcCyJllDIgDg, rawValue);
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

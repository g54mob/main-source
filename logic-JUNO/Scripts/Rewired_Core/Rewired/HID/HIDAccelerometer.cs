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

		private readonly byte[] EgYKRgVhLiGQUpfqtGBttnRCZytk;

		private readonly int SpnCBJHABumHZvlRagSTPcEaHlVYA;

		private readonly int KbkFXHvcloznARaQcDibcEdxlLqFA;

		private readonly Action<byte[], float[]> kxIambJOgdZhQAzCTSxGCflNkNFKA;

		public HIDAccelerometer(byte P_0, HIDInfo P_1, int P_2, Action<byte[], float[]> P_3)
			: base(P_0, P_1)
		{
			valueLength = P_2;
			kxIambJOgdZhQAzCTSxGCflNkNFKA = P_3;
			SpnCBJHABumHZvlRagSTPcEaHlVYA = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
			KbkFXHvcloznARaQcDibcEdxlLqFA = P_1.dataIndex;
			EgYKRgVhLiGQUpfqtGBttnRCZytk = new byte[SpnCBJHABumHZvlRagSTPcEaHlVYA];
			rawValue = new float[P_2];
		}

		public override void UpdateValue(NativeBuffer inputReport, double timestamp)
		{
			if (inputReport != null && inputReport[0] == reportId)
			{
				this.timestamp = timestamp;
				for (int i = 0; i < SpnCBJHABumHZvlRagSTPcEaHlVYA; i++)
				{
					EgYKRgVhLiGQUpfqtGBttnRCZytk[i] = inputReport[KbkFXHvcloznARaQcDibcEdxlLqFA + i];
				}
				if (kxIambJOgdZhQAzCTSxGCflNkNFKA != null)
				{
					kxIambJOgdZhQAzCTSxGCflNkNFKA(EgYKRgVhLiGQUpfqtGBttnRCZytk, rawValue);
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

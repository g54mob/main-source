using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HIDAccelerometer : HIDControllerElement
	{
		public readonly float[] rawValue;

		public float timestamp;

		public readonly int valueLength;

		private readonly byte[] FFOHNCJKQCbkumTZGCQQgbAkMqhU;

		private readonly int OejdrGdMwQDLTmmGAWRtpIFxxJ;

		private readonly int KYCBqRCUzCxlrIcXIRhSJUdgzrAw;

		private readonly Action<byte[], float[]> mrYChTVqXTCVxhzNiXVDRNAiSmHs;

		public HIDAccelerometer(byte reportId, HIDInfo hidInfo, int valueLength, Action<byte[], float[]> calcValueDelegate)
			: base(reportId, hidInfo)
		{
			this.valueLength = valueLength;
			mrYChTVqXTCVxhzNiXVDRNAiSmHs = calcValueDelegate;
			OejdrGdMwQDLTmmGAWRtpIFxxJ = ((hidInfo.bitSize > 0) ? ((hidInfo.bitSize + 8 - 1) / 8) : 0);
			KYCBqRCUzCxlrIcXIRhSJUdgzrAw = hidInfo.dataIndex;
			FFOHNCJKQCbkumTZGCQQgbAkMqhU = new byte[OejdrGdMwQDLTmmGAWRtpIFxxJ];
			rawValue = new float[valueLength];
		}

		public override void UpdateValue(NativeBuffer inputReport, float timestamp)
		{
			if (inputReport == null)
			{
				return;
			}
			while (inputReport[0] == reportId)
			{
				while (true)
				{
					this.timestamp = timestamp;
					int num = 0;
					int num2 = -1699216459;
					while (true)
					{
						switch (num2 ^ -1699216457)
						{
						case 7:
							num2 = -1699216458;
							continue;
						default:
							return;
						case 2:
							break;
						case 3:
							goto IL_0056;
						case 4:
							FFOHNCJKQCbkumTZGCQQgbAkMqhU[num] = inputReport[KYCBqRCUzCxlrIcXIRhSJUdgzrAw + num];
							num++;
							num2 = -1699216459;
							continue;
						case 6:
							mrYChTVqXTCVxhzNiXVDRNAiSmHs(FFOHNCJKQCbkumTZGCQQgbAkMqhU, rawValue);
							num2 = -1699216462;
							continue;
						case 0:
							goto end_IL_000c;
						case 1:
							goto end_IL_00b4;
						case 5:
							return;
						}
						int num3;
						if (num < OejdrGdMwQDLTmmGAWRtpIFxxJ)
						{
							num2 = -1699216461;
							num3 = num2;
						}
						else
						{
							num2 = -1699216460;
							num3 = num2;
						}
						continue;
						IL_0056:
						int num4;
						if (mrYChTVqXTCVxhzNiXVDRNAiSmHs != null)
						{
							num2 = -1699216463;
							num4 = num2;
						}
						else
						{
							num2 = -1699216462;
							num4 = num2;
						}
						continue;
						end_IL_000c:
						break;
					}
					continue;
					end_IL_00b4:
					break;
				}
			}
		}
	}
}

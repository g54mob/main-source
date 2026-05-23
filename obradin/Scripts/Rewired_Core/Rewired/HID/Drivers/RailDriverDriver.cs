using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_RailDriver
	{
		private enum QracSPCsPyjypLuylErVNgwgPOIc
		{
			VLTAlFOdthmtMcdbNzgxULUQxnD = 0,
			PrzqDEmUdilLQcaPTOKOkmrEEkOc = 1
		}

		private const int OzBOELuRLPUKlOrNFGCiqFHhaCEH = 1523;

		private const int WDSsbpKADfaQwwFLUNXAvIDmTzY = 210;

		private const int uoEjKyevFzzSGFeoHwcdjcYUdf = 50;

		private const int erIOlhmHoyENmRVhSmvdxJJwlmY = 44;

		private const int sgqvqfQbPHOkpFUGiniBWVpYrGV = 6;

		private const int ClNOlDmJmojOOVcRwCIVjrtGHVoS = 44;

		private const int HIuGpOHHBFLbaSVscgJrHypeJZDD = 45;

		private const int QcUeyXcAZXNHFayIReqCLxlnXPG = 46;

		private const int DtcilxlfrdnTRltPCSHkvlpsqQv = 47;

		private const int cvnSSnbdwFThplpCvtITshoXjFe = 48;

		private const int JsdNXhXcUwExJtHegYXFDZVCIrB = 49;

		private const int EOioevoPezTDLUeNRjqmjEpgrZFp = 0;

		private const int TLxfyRStjdbQxorNNxHWQyFqJJa = 15;

		private const int YtUYPfPsouiZdjuAzcqYDWFoySx = 9;

		private const int VoSncmAEbfDhJijTXGZfhDSxzBj = 1;

		private const int AWJoPfhCabMWvYXzTylCfYRCMeV = 2;

		private const int uepqNNkJFkItLXpbJdioovwdfJI = 3;

		private const int VUHlxbKeNcnUgHdmFBccvzDSltH = 4;

		private const int quInqWgktTQMQeGChsLrLbegJRT = 5;

		private const int KgfywcfpxrMfyTnrznTPTUVgquD = 6;

		private const int pGxoyjGZsthwduUCxrsNPVqPWVi = 7;

		private const int XaqKvQECfKRLxDBXdBfFcaXIIEoF = 8;

		private const int VGidBvJgUtIHJWnMLhcwJlJMCVD = 14;

		private const int FeBAeCKpHZJqptIzhddRacmOfMpg = 3;

		private const int YhvujCjIgEaZeikOxNJwRYcsOKD = 7;

		private readonly NativeBuffer kBUmUcAyFhoFeddZhyvELUyrNQP;

		private readonly NativeBuffer xQtqlAYhQUqbOGYibktAZaYeTPW;

		private bool TaicJlEaKqSdLHUdtMdCdQQPzpA;

		private byte[] qSfSBFqpCLXbbvukjZgsNRuNsrC = new byte[3];

		private readonly OutputReport wDqsBPZBSKtSLRDQNHWwaHOApvg;

		private readonly Func<OutputReport, bool> KoLbpdtSgwWZhTuekQfZVolIbnZ;

		private readonly Action<OutputReport> beVWMbKDuyboNeDypPMnahQkenTj;

		public bool SpeakerEnabled
		{
			get
			{
				return TaicJlEaKqSdLHUdtMdCdQQPzpA;
			}
			set
			{
				TaicJlEaKqSdLHUdtMdCdQQPzpA = value;
				ACsIgxEitXcAKXzTiBHLxHBNdSep(QracSPCsPyjypLuylErVNgwgPOIc.VLTAlFOdthmtMcdbNzgxULUQxnD, UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa);
			}
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex >= 0)
			{
				if (digitIndex >= 3)
				{
					goto IL_0008;
				}
				goto IL_0032;
			}
			return;
			IL_0032:
			qSfSBFqpCLXbbvukjZgsNRuNsrC[digitIndex] = digitBitValues;
			ACsIgxEitXcAKXzTiBHLxHBNdSep(QracSPCsPyjypLuylErVNgwgPOIc.PrzqDEmUdilLQcaPTOKOkmrEEkOc, UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa);
			int num = 161649964;
			goto IL_000d;
			IL_0008:
			num = 161649965;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x9A2952C)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0032;
			case 0:
				return;
			}
			goto IL_0008;
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			qSfSBFqpCLXbbvukjZgsNRuNsrC[0] = digit1BitValues;
			while (true)
			{
				int num = 799361407;
				while (true)
				{
					switch (num ^ 0x2FA5497D)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0027;
					case 1:
						return;
					}
					break;
					IL_0027:
					qSfSBFqpCLXbbvukjZgsNRuNsrC[1] = digit2BitValues;
					qSfSBFqpCLXbbvukjZgsNRuNsrC[2] = digit3BitValues;
					ACsIgxEitXcAKXzTiBHLxHBNdSep(QracSPCsPyjypLuylErVNgwgPOIc.PrzqDEmUdilLQcaPTOKOkmrEEkOc, UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa);
					num = 799361404;
				}
			}
		}

		public RailDriverDriver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			kBUmUcAyFhoFeddZhyvELUyrNQP = new NativeBuffer(15);
			xQtqlAYhQUqbOGYibktAZaYeTPW = new NativeBuffer(9);
			wDqsBPZBSKtSLRDQNHWwaHOApvg = new OutputReport(xQtqlAYhQUqbOGYibktAZaYeTPW.Pointer, xQtqlAYhQUqbOGYibktAZaYeTPW.Length, 9);
			KoLbpdtSgwWZhTuekQfZVolIbnZ = initArgs.synchronousWriteOutputReportDelegate;
			beVWMbKDuyboNeDypPMnahQkenTj = initArgs.asynchronousWriteOutputReportDelegate;
			buttons = new HIDButton[50];
			for (int i = 0; i < 50; i++)
			{
				buttons[i] = new HIDButton(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 9,
					usage = (ushort)i
				});
			}
			axes = new HIDAxis[4]
			{
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 48,
					dataIndex = 1,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 2,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 49,
					dataIndex = 3,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127),
				new HIDAxis(0, new HIDControllerElement.HIDInfo
				{
					usagePage = 1,
					usage = 50,
					dataIndex = 4,
					bitSize = 8,
					logicalMin = 0,
					logicalMax = 255,
					physicalMin = 0,
					physicalMax = 0,
					units = 0u,
					unitsExp = 0u
				}, false, 127)
			};
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, float timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				goto IL_000d;
			}
			if (inputReportLength < kBUmUcAyFhoFeddZhyvELUyrNQP.Length)
			{
				return false;
			}
			kBUmUcAyFhoFeddZhyvELUyrNQP.Write(inputReportPtr, inputReportLength, kBUmUcAyFhoFeddZhyvELUyrNQP.Length);
			bWqXMuWKIQJCfsxGeWCQkichWXy(kBUmUcAyFhoFeddZhyvELUyrNQP, timestamp);
			int num = -18184552;
			goto IL_0012;
			IL_000d:
			num = -18184551;
			goto IL_0012;
			IL_0012:
			switch (num ^ -18184552)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				TncRWDNnjIHJtHMNjIvXiptqHAB(axes, kBUmUcAyFhoFeddZhyvELUyrNQP, timestamp);
				return true;
			}
			goto IL_000d;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool ACsIgxEitXcAKXzTiBHLxHBNdSep(QracSPCsPyjypLuylErVNgwgPOIc P_0, UNPjxDoysgcOYEVoxVPcTxAqJcM P_1)
		{
			lIqLuvZbhVpBcfGmWiwKUvgnIba(P_0);
			return WkEAduGURWkiggCMBLveDEjiPugA(P_1);
		}

		private void lIqLuvZbhVpBcfGmWiwKUvgnIba(QracSPCsPyjypLuylErVNgwgPOIc P_0)
		{
			int num;
			switch (P_0)
			{
			default:
				num = 782968771;
				goto IL_0015;
			case QracSPCsPyjypLuylErVNgwgPOIc.PrzqDEmUdilLQcaPTOKOkmrEEkOc:
				goto IL_0049;
			case QracSPCsPyjypLuylErVNgwgPOIc.VLTAlFOdthmtMcdbNzgxULUQxnD:
				goto IL_008c;
				IL_0015:
				while (true)
				{
					switch (num ^ 0x2EAB27C6)
					{
					case 4:
						break;
					case 2:
						goto IL_0049;
					case 0:
						xQtqlAYhQUqbOGYibktAZaYeTPW[1] = 133;
						xQtqlAYhQUqbOGYibktAZaYeTPW[7] = (byte)(TaicJlEaKqSdLHUdtMdCdQQPzpA ? 1 : 0);
						return;
					case 8:
						goto IL_008c;
					case 1:
						xQtqlAYhQUqbOGYibktAZaYeTPW[1] = 134;
						xQtqlAYhQUqbOGYibktAZaYeTPW[2] = qSfSBFqpCLXbbvukjZgsNRuNsrC[0];
						num = 782968769;
						continue;
					case 5:
						num = 782968768;
						continue;
					case 7:
						xQtqlAYhQUqbOGYibktAZaYeTPW[3] = qSfSBFqpCLXbbvukjZgsNRuNsrC[1];
						xQtqlAYhQUqbOGYibktAZaYeTPW[4] = qSfSBFqpCLXbbvukjZgsNRuNsrC[2];
						num = 782968773;
						continue;
					case 3:
						return;
					default:
						throw new NotImplementedException();
					}
					break;
				}
				goto default;
				IL_008c:
				xQtqlAYhQUqbOGYibktAZaYeTPW.Clear();
				num = 782968774;
				goto IL_0015;
				IL_0049:
				xQtqlAYhQUqbOGYibktAZaYeTPW.Clear();
				num = 782968775;
				goto IL_0015;
			}
		}

		private bool WkEAduGURWkiggCMBLveDEjiPugA(UNPjxDoysgcOYEVoxVPcTxAqJcM P_0)
		{
			if (P_0 == UNPjxDoysgcOYEVoxVPcTxAqJcM.lTnAdpWaglqAxhztbdqtVMKSoaa)
			{
				if (KoLbpdtSgwWZhTuekQfZVolIbnZ != null)
				{
					return KoLbpdtSgwWZhTuekQfZVolIbnZ(wDqsBPZBSKtSLRDQNHWwaHOApvg);
				}
				goto IL_000b;
			}
			int num;
			if (P_0 == UNPjxDoysgcOYEVoxVPcTxAqJcM.PLXbAAdESbUPAfTXKCgcjTqziVz)
			{
				num = 1721548012;
				goto IL_0010;
			}
			throw new NotImplementedException();
			IL_000b:
			num = 1721548015;
			goto IL_0010;
			IL_0010:
			switch (num ^ 0x669CBCED)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				if (beVWMbKDuyboNeDypPMnahQkenTj == null)
				{
					return false;
				}
				beVWMbKDuyboNeDypPMnahQkenTj(wDqsBPZBSKtSLRDQNHWwaHOApvg);
				return true;
			}
			goto IL_000b;
		}

		private void bWqXMuWKIQJCfsxGeWCQkichWXy(NativeBuffer P_0, float P_1)
		{
			int num = 0;
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			byte b = default(byte);
			byte b2 = default(byte);
			while (true)
			{
				int num2 = 756831505;
				while (true)
				{
					switch (num2 ^ 0x2D1C5515)
					{
					case 9:
						break;
					case 7:
					{
						num4 = num5 + num3;
						int num7;
						if (num4 >= 44)
						{
							num2 = 756831519;
							num7 = num2;
						}
						else
						{
							num2 = 756831517;
							num7 = num2;
						}
						continue;
					}
					case 5:
						buttons[45].SetValue(b >= 95 && b < 161, P_1);
						buttons[46].SetValue(b >= 161, P_1);
						b = P_0[7];
						buttons[47].SetValue(b < 95, P_1);
						buttons[48].SetValue(b >= 95 && b < 161, P_1);
						num2 = 756831507;
						continue;
					case 8:
						buttons[num4].SetValue((b2 & (1 << num3)) != 0, P_1);
						num2 = 756831518;
						continue;
					case 1:
					{
						int num6;
						if (num3 >= 8)
						{
							num2 = 756831519;
							num6 = num2;
						}
						else
						{
							num2 = 756831506;
							num6 = num2;
						}
						continue;
					}
					case 0:
						if (num >= 6)
						{
							b = P_0[6];
							buttons[44].SetValue(b < 95, P_1);
							num2 = 756831504;
							continue;
						}
						goto case 2;
					case 3:
						num3 = 0;
						num2 = 756831508;
						continue;
					case 10:
						num++;
						num2 = 756831509;
						continue;
					case 4:
						num2 = 756831509;
						continue;
					case 2:
						b2 = P_0[8 + num];
						num5 = num * 8;
						num2 = 756831510;
						continue;
					case 11:
						num3++;
						num2 = 756831508;
						continue;
					default:
						buttons[49].SetValue(b >= 161, P_1);
						return;
					}
					break;
				}
			}
		}

		private void TncRWDNnjIHJtHMNjIvXiptqHAB(HIDControllerElement[] P_0, NativeBuffer P_1, float P_2)
		{
			int num = 0;
			while (num < P_0.Length)
			{
				while (true)
				{
					P_0[num].UpdateValue(P_1, P_2);
					num++;
					int num2 = 1873004384;
					while (true)
					{
						switch (num2 ^ 0x6FA3C760)
						{
						case 2:
							num2 = 1873004385;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
		}

		~RailDriverDriver()
		{
			Dispose(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (base.disposed)
			{
				return;
			}
			while (true)
			{
				base.Dispose(disposing);
				int num;
				int num2;
				if (!disposing)
				{
					num = 1301254968;
					num2 = num;
				}
				else
				{
					num = 1301254974;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x4D8F933A)
					{
					case 0:
						num = 1301254969;
						continue;
					default:
						return;
					case 3:
						break;
					case 1:
						if (xQtqlAYhQUqbOGYibktAZaYeTPW != null)
						{
							xQtqlAYhQUqbOGYibktAZaYeTPW.Dispose();
							num = 1301254968;
							continue;
						}
						return;
					case 4:
						if (kBUmUcAyFhoFeddZhyvELUyrNQP != null)
						{
							kBUmUcAyFhoFeddZhyvELUyrNQP.Dispose();
							num = 1301254971;
							continue;
						}
						goto case 1;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public static bool Matches(int vid, int pid)
		{
			if (1523 == vid)
			{
				return 210 == pid;
			}
			return false;
		}
	}
}

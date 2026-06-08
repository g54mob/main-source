using System;
using Rewired.ControllerExtensions;
using Rewired.Drivers.Interfaces;
using Rewired.Utils.Classes.Data;

namespace Rewired.HID.Drivers
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class RailDriverDriver : HIDDeviceDriver, IDisposable, IControllerDriver, IDriver_RailDriver
	{
		private enum KKmkTyiqskUXavKnIMGFJQXvYaA
		{
			RARysJEMCfmMkrdRuAYutwsXbrhE = 0,
			BQrthAwlSwzQihKpyzeFZKFBaUi = 1
		}

		private const int KmPiVHuWuFgCZRylqjwlZTtkQVs = 1523;

		private const int IvCsStEvurLsEhanvamBkIpbJnaL = 210;

		private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 50;

		private const int cVGfcvacswMgxmSlvnZaRYdfUfSC = 44;

		private const int qWsZBeQrCXhsOFGsFqEWDvvFXpxW = 6;

		private const int ATJVdZaLVemBmMArZDlSSrTTRRM = 44;

		private const int DRaXHYBgLXBsSSSnRoToDPNGDBj = 45;

		private const int QWOWVKbaBNtdjWicfFVmEFmSBo = 46;

		private const int TreCHjxfEjlrdyntptgvSRZfYIX = 47;

		private const int okzyqpfzPVNjNuqsUVYQNYMKUdU = 48;

		private const int RodrYjZUnsTOdyEEVAcGoUrBqjd = 49;

		private const int ANaCxrygPnbmhNQpeFnhnHDvCPh = 0;

		private const int LVlEHuSOyjkVZfxqRoHzxxxnZWc = 15;

		private const int SQCzhxHfTmzHVmZyETTPgJnrkHB = 9;

		private const int BrOzZaSfKlKpvjZpogmsMywosJD = 1;

		private const int QIXvSddUZnwmRRhFqRiDQHpTSfp = 2;

		private const int ixjXKNydmceuhAKLwjUbQBWgHhwg = 3;

		private const int HmXoNdILmslTIEdCugejfYjDUnzp = 4;

		private const int wKErFEgxENamwdKwKiHqkrApQZn = 5;

		private const int SyzTMwfsChtsUGFHKgSYiemthmnv = 6;

		private const int rghOWfEfPtCiVrdaGFHYkYUQpDA = 7;

		private const int NYuCZCKcCWnvHAIbYDSIAZpPqQOc = 8;

		private const int ZVsJxpFwzvArvFfgqsVlihzDuDx = 14;

		private const int ZfRPqKMZaZIxVuMTApWGNxIPoWD = 3;

		private const int IxzfKIpsTAfXUxdmMBcngjStFAxc = 7;

		private readonly NativeBuffer aeMwQuQlPtdUYawrQqVFIuMiAPdF;

		private readonly NativeBuffer dPxPlSKThGVfgLiEEKYHuvifCBa;

		private bool VZajfxMxlsFNtSmFYYITSYyQRbs;

		private byte[] sknpgPoMxNjfNuKEScahkyKAicy = new byte[3];

		private readonly OutputReport ivorCZXlhEABpUusmuppDnoRgbCk;

		private readonly Func<OutputReport, bool> MZJGLphQViSbTOKYDaUYCuFBctzd;

		private readonly Action<OutputReport> lBRcRxYTqeMRxCOBUhfkEFojdet;

		public bool SpeakerEnabled
		{
			get
			{
				return VZajfxMxlsFNtSmFYYITSYyQRbs;
			}
			set
			{
				VZajfxMxlsFNtSmFYYITSYyQRbs = value;
				YYoOzKqMeRqjkohwLimEuhYIMWt(KKmkTyiqskUXavKnIMGFJQXvYaA.RARysJEMCfmMkrdRuAYutwsXbrhE, WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
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
			sknpgPoMxNjfNuKEScahkyKAicy[digitIndex] = digitBitValues;
			int num = -1468036856;
			goto IL_000d;
			IL_0008:
			num = -1468036853;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1468036854)
			{
			case 0:
				break;
			case 1:
				return;
			case 3:
				goto IL_0032;
			default:
				YYoOzKqMeRqjkohwLimEuhYIMWt(KKmkTyiqskUXavKnIMGFJQXvYaA.BQrthAwlSwzQihKpyzeFZKFBaUi, WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
				return;
			}
			goto IL_0008;
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			sknpgPoMxNjfNuKEScahkyKAicy[0] = digit1BitValues;
			sknpgPoMxNjfNuKEScahkyKAicy[1] = digit2BitValues;
			sknpgPoMxNjfNuKEScahkyKAicy[2] = digit3BitValues;
			YYoOzKqMeRqjkohwLimEuhYIMWt(KKmkTyiqskUXavKnIMGFJQXvYaA.BQrthAwlSwzQihKpyzeFZKFBaUi, WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd);
		}

		public RailDriverDriver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			aeMwQuQlPtdUYawrQqVFIuMiAPdF = new NativeBuffer(15);
			dPxPlSKThGVfgLiEEKYHuvifCBa = new NativeBuffer(9);
			ivorCZXlhEABpUusmuppDnoRgbCk = new OutputReport(dPxPlSKThGVfgLiEEKYHuvifCBa.Pointer, dPxPlSKThGVfgLiEEKYHuvifCBa.Length, 9);
			MZJGLphQViSbTOKYDaUYCuFBctzd = initArgs.synchronousWriteOutputReportDelegate;
			lBRcRxYTqeMRxCOBUhfkEFojdet = initArgs.asynchronousWriteOutputReportDelegate;
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
				}, isSigned: false, 127),
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
				}, isSigned: false, 127),
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
				}, isSigned: false, 127),
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
				}, isSigned: false, 127)
			};
		}

		public override void Update(UpdateLoopType updateLoop)
		{
		}

		public override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
		{
			if (inputReportPtr == IntPtr.Zero)
			{
				return false;
			}
			if (inputReportLength < aeMwQuQlPtdUYawrQqVFIuMiAPdF.Length)
			{
				return false;
			}
			aeMwQuQlPtdUYawrQqVFIuMiAPdF.Write(inputReportPtr, inputReportLength, aeMwQuQlPtdUYawrQqVFIuMiAPdF.Length);
			nLotdmIEnGDlRjnDZLzPFXYmCSSJ(aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
			RVgcSVBpQMbLHYUtIUJCVyTtCbz(axes, aeMwQuQlPtdUYawrQqVFIuMiAPdF, timestamp);
			return true;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool YYoOzKqMeRqjkohwLimEuhYIMWt(KKmkTyiqskUXavKnIMGFJQXvYaA P_0, WrVEVdhmDaiEyYHhLCqAumPxnFYB P_1)
		{
			hZiLtvTVSJEJKwVGdTRXbyAeDjI(P_0);
			return OIUXarAwCISOJRuamQlSzTKmqCq(P_1);
		}

		private void hZiLtvTVSJEJKwVGdTRXbyAeDjI(KKmkTyiqskUXavKnIMGFJQXvYaA P_0)
		{
			while (true)
			{
				int num = 1681745594;
				while (true)
				{
					switch (num ^ 0x643D66BE)
					{
					case 5:
						break;
					case 0:
						dPxPlSKThGVfgLiEEKYHuvifCBa[3] = sknpgPoMxNjfNuKEScahkyKAicy[1];
						dPxPlSKThGVfgLiEEKYHuvifCBa[4] = sknpgPoMxNjfNuKEScahkyKAicy[2];
						return;
					case 3:
						dPxPlSKThGVfgLiEEKYHuvifCBa.Clear();
						num = 1681745599;
						continue;
					case 6:
						goto IL_0075;
					case 1:
						dPxPlSKThGVfgLiEEKYHuvifCBa[1] = 134;
						dPxPlSKThGVfgLiEEKYHuvifCBa[2] = sknpgPoMxNjfNuKEScahkyKAicy[0];
						num = 1681745598;
						continue;
					case 4:
						switch (P_0)
						{
						case KKmkTyiqskUXavKnIMGFJQXvYaA.BQrthAwlSwzQihKpyzeFZKFBaUi:
							break;
						case KKmkTyiqskUXavKnIMGFJQXvYaA.RARysJEMCfmMkrdRuAYutwsXbrhE:
							goto IL_0075;
						default:
							goto IL_00f1;
						}
						goto case 3;
					default:
						{
							throw new NotImplementedException();
						}
						IL_00f1:
						num = 1681745596;
						continue;
						IL_0075:
						dPxPlSKThGVfgLiEEKYHuvifCBa.Clear();
						dPxPlSKThGVfgLiEEKYHuvifCBa[1] = 133;
						dPxPlSKThGVfgLiEEKYHuvifCBa[7] = (byte)(VZajfxMxlsFNtSmFYYITSYyQRbs ? 1 : 0);
						return;
					}
					break;
				}
			}
		}

		private bool OIUXarAwCISOJRuamQlSzTKmqCq(WrVEVdhmDaiEyYHhLCqAumPxnFYB P_0)
		{
			switch (P_0)
			{
			case WrVEVdhmDaiEyYHhLCqAumPxnFYB.pMrzmpQUTveEXenRCeQwcuyDgaOd:
				if (MZJGLphQViSbTOKYDaUYCuFBctzd == null)
				{
					return false;
				}
				return MZJGLphQViSbTOKYDaUYCuFBctzd(ivorCZXlhEABpUusmuppDnoRgbCk);
			case WrVEVdhmDaiEyYHhLCqAumPxnFYB.RxDhwKbqppIzkwYthdHdClWgNNR:
				while (true)
				{
					int num = 2029829245;
					while (true)
					{
						switch (num ^ 0x78FCBC7C)
						{
						case 0:
							break;
						case 1:
							if (lBRcRxYTqeMRxCOBUhfkEFojdet == null)
							{
								goto IL_0049;
							}
							lBRcRxYTqeMRxCOBUhfkEFojdet(ivorCZXlhEABpUusmuppDnoRgbCk);
							return true;
						default:
							return false;
						}
						break;
						IL_0049:
						num = 2029829246;
					}
				}
			default:
				throw new NotImplementedException();
			}
		}

		private void nLotdmIEnGDlRjnDZLzPFXYmCSSJ(NativeBuffer P_0, double P_1)
		{
			int num = 0;
			byte b2 = default(byte);
			int num3 = default(int);
			int num5 = default(int);
			byte b = default(byte);
			int num6 = default(int);
			while (true)
			{
				int num2 = -1865604829;
				while (true)
				{
					switch (num2 ^ -1865604830)
					{
					case 9:
						break;
					default:
						return;
					case 5:
						if (num >= 6)
						{
							b2 = P_0[6];
							buttons[44].SetValue(b2 < 95, P_1);
							buttons[45].SetValue(b2 >= 95 && b2 < 161, P_1);
							buttons[46].SetValue(b2 >= 161, P_1);
							b2 = P_0[7];
							buttons[47].SetValue(b2 < 95, P_1);
							buttons[48].SetValue(b2 >= 95 && b2 < 161, P_1);
							num2 = -1865604831;
							continue;
						}
						goto case 4;
					case 0:
						num3 = 0;
						num2 = -1865604832;
						continue;
					case 8:
						buttons[num5].SetValue((b & (1 << num3)) != 0, P_1);
						num3++;
						num2 = -1865604832;
						continue;
					case 3:
						buttons[49].SetValue(b2 >= 161, P_1);
						num2 = -1865604824;
						continue;
					case 4:
						b = P_0[8 + num];
						num6 = num * 8;
						num2 = -1865604830;
						continue;
					case 7:
					{
						num5 = num6 + num3;
						int num7;
						if (num5 >= 44)
						{
							num2 = -1865604828;
							num7 = num2;
						}
						else
						{
							num2 = -1865604822;
							num7 = num2;
						}
						continue;
					}
					case 1:
						num2 = -1865604825;
						continue;
					case 6:
						num++;
						num2 = -1865604825;
						continue;
					case 2:
					{
						int num4;
						if (num3 >= 8)
						{
							num2 = -1865604828;
							num4 = num2;
						}
						else
						{
							num2 = -1865604827;
							num4 = num2;
						}
						continue;
					}
					case 10:
						return;
					}
					break;
				}
			}
		}

		private void RVgcSVBpQMbLHYUtIUJCVyTtCbz(HIDControllerElement[] P_0, NativeBuffer P_1, double P_2)
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= P_0.Length)
				{
					num2 = 372411294;
					num3 = num2;
				}
				else
				{
					num2 = 372411292;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x16328B9D)
					{
					case 2:
						num2 = 372411292;
						continue;
					default:
						return;
					case 1:
						P_0[num].UpdateValue(P_1, P_2);
						num++;
						num2 = 372411293;
						continue;
					case 0:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		~RailDriverDriver()
		{
			Dispose(disposing: false);
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
				if (!disposing)
				{
					break;
				}
				int num;
				int num2;
				if (aeMwQuQlPtdUYawrQqVFIuMiAPdF == null)
				{
					num = -297788330;
					num2 = num;
				}
				else
				{
					num = -297788336;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -297788333)
					{
					case 0:
						num = -297788334;
						continue;
					default:
						return;
					case 1:
						break;
					case 3:
						aeMwQuQlPtdUYawrQqVFIuMiAPdF.Dispose();
						num = -297788330;
						continue;
					case 2:
						dPxPlSKThGVfgLiEEKYHuvifCBa.Dispose();
						num = -297788329;
						continue;
					case 5:
					{
						int num3;
						if (dPxPlSKThGVfgLiEEKYHuvifCBa != null)
						{
							num = -297788335;
							num3 = num;
						}
						else
						{
							num = -297788329;
							num3 = num;
						}
						continue;
					}
					case 4:
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

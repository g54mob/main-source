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
		private enum vRcxBEAqDamBCQKhPgzJTHscrFZ
		{
			gTRNYOefbhLxdOylnfzMrQREsGU = 0,
			kUvGEDMYxenejWIYnIGGHlzCEzTE = 1
		}

		private const int jlZjHCSqZLUpEqqInkYiVCPfaPTB = 1523;

		private const int lwOCrswTNtLlBSzUikTMSrVmroD = 210;

		private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 50;

		private const int XoMFmkSKXmnemlNSomDzYGJacsr = 44;

		private const int HPcupfcleFxzVfPNUpAVdLXUuTU = 6;

		private const int hSXEiQMNagknllpSSuGRUMxKzOl = 44;

		private const int uYcZwHxDBJDQTelxAkRlJNzDzGIA = 45;

		private const int nKIUvKohJTNuuGtDxjoYsphfEvV = 46;

		private const int iqoReiRBxrIuuNiMiDBifAnsZTel = 47;

		private const int NdzVHqRmMBcaMJVMPnfBBwpHeIp = 48;

		private const int osfIQyvAOijYmZWfUZTFezTCleQ = 49;

		private const int nroehgSOsjQgqcjAjFmyJnxerGAQ = 0;

		private const int qXxXzSslhjEhMCNGrELAdFVgTMz = 15;

		private const int rSSDScAvcutcMaLLHxiIOmBiUxuk = 9;

		private const int yOIeDtcfQvyEgEGYxHRzIjAzWsa = 1;

		private const int lMLjQiHGmrLtOwTkzdgMSpJYIBWA = 2;

		private const int HvfnfKCVjovvipeKhzFyLcSpePw = 3;

		private const int iiJqusyWZyQIBftvzZxcQNFCeYM = 4;

		private const int HmGdgVWyxFnMhMePRDkxaPwkhAY = 5;

		private const int vlGjtfJtfzfVCxgnTpTBgUTibMv = 6;

		private const int SfhExkmwefJRGIlPDXwDyfqJGCzk = 7;

		private const int yccUaNqPlWNqEdsMFLlTHdZYmPb = 8;

		private const int wWeOCofbQhAscgKJtKykadHIfEO = 14;

		private const int obNaTPgwTFgkYFMuByhTJumUvLa = 3;

		private const int lypdbRVPcKuZVEBDHLSieBemRpI = 7;

		private readonly NativeBuffer RBWbtggyAdLBBLQKDwGIqmFtGqY;

		private readonly NativeBuffer QTvgeNabKIuYngzpDpvGaqKuMlN;

		private bool abkUJayxUkCralsgBraYCIYTgEX;

		private byte[] NgdaJOIjEZLiYHqhHmReqYkFAfV = new byte[3];

		private readonly OutputReport LwwCfYrHYYIqqrfRbeSqPqWCpel;

		private readonly Func<OutputReport, bool> xVVyGgNsqweTIzstWzQJegvUeuI;

		private readonly Action<OutputReport> CjDBJyHuwywJegdtLbKnPIGyviWF;

		public bool SpeakerEnabled
		{
			get
			{
				return abkUJayxUkCralsgBraYCIYTgEX;
			}
			set
			{
				abkUJayxUkCralsgBraYCIYTgEX = value;
				xFqYduKPrLutvTnMCKHHaIHLcTle(vRcxBEAqDamBCQKhPgzJTHscrFZ.gTRNYOefbhLxdOylnfzMrQREsGU, zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh);
			}
		}

		public void SetLEDDisplay(int digitIndex, byte digitBitValues)
		{
			if (digitIndex < 0)
			{
				return;
			}
			if (digitIndex >= 3)
			{
				while (true)
				{
					switch (-2124303700 ^ -2124303698)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			NgdaJOIjEZLiYHqhHmReqYkFAfV[digitIndex] = digitBitValues;
			xFqYduKPrLutvTnMCKHHaIHLcTle(vRcxBEAqDamBCQKhPgzJTHscrFZ.kUvGEDMYxenejWIYnIGGHlzCEzTE, zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh);
		}

		public void SetLEDDisplay(byte digit1BitValues, byte digit2BitValues, byte digit3BitValues)
		{
			NgdaJOIjEZLiYHqhHmReqYkFAfV[0] = digit1BitValues;
			NgdaJOIjEZLiYHqhHmReqYkFAfV[1] = digit2BitValues;
			NgdaJOIjEZLiYHqhHmReqYkFAfV[2] = digit3BitValues;
			xFqYduKPrLutvTnMCKHHaIHLcTle(vRcxBEAqDamBCQKhPgzJTHscrFZ.kUvGEDMYxenejWIYnIGGHlzCEzTE, zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh);
		}

		public RailDriverDriver(InitArgs initArgs)
		{
			if (initArgs == null)
			{
				throw new ArgumentNullException("initArgs");
			}
			RBWbtggyAdLBBLQKDwGIqmFtGqY = new NativeBuffer(15);
			QTvgeNabKIuYngzpDpvGaqKuMlN = new NativeBuffer(9);
			LwwCfYrHYYIqqrfRbeSqPqWCpel = new OutputReport(QTvgeNabKIuYngzpDpvGaqKuMlN.Pointer, QTvgeNabKIuYngzpDpvGaqKuMlN.Length, 9);
			xVVyGgNsqweTIzstWzQJegvUeuI = initArgs.synchronousWriteOutputReportDelegate;
			CjDBJyHuwywJegdtLbKnPIGyviWF = initArgs.asynchronousWriteOutputReportDelegate;
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
			int num;
			if (inputReportLength < RBWbtggyAdLBBLQKDwGIqmFtGqY.Length)
			{
				num = -500476946;
			}
			else
			{
				RBWbtggyAdLBBLQKDwGIqmFtGqY.Write(inputReportPtr, inputReportLength, RBWbtggyAdLBBLQKDwGIqmFtGqY.Length);
				num = -500476945;
			}
			goto IL_0012;
			IL_000d:
			num = -500476947;
			goto IL_0012;
			IL_0012:
			switch (num ^ -500476946)
			{
			case 2:
				break;
			case 3:
				return false;
			case 0:
				return false;
			default:
				OmvEduKEMDwCfGsAUMYnJwvhRxA(RBWbtggyAdLBBLQKDwGIqmFtGqY, timestamp);
				sZiHDSjwxSeuMhlAVhrPPNrmkVY(axes, RBWbtggyAdLBBLQKDwGIqmFtGqY, timestamp);
				return true;
			}
			goto IL_000d;
		}

		public override Controller.Extension CreateControllerExtension()
		{
			return new RailDriverExtension(this);
		}

		private bool xFqYduKPrLutvTnMCKHHaIHLcTle(vRcxBEAqDamBCQKhPgzJTHscrFZ P_0, zpBwNyEewiHFbuFYIFwNwuraOAx P_1)
		{
			SasYrcdYnXAkLJvlqoJSdXavqFx(P_0);
			return fbUvchqVJAMRZmINxLfcrXvFufv(P_1);
		}

		private void SasYrcdYnXAkLJvlqoJSdXavqFx(vRcxBEAqDamBCQKhPgzJTHscrFZ P_0)
		{
			while (true)
			{
				int num = 610917768;
				while (true)
				{
					switch (num ^ 0x2469DD89)
					{
					case 4:
						break;
					case 2:
						QTvgeNabKIuYngzpDpvGaqKuMlN[2] = NgdaJOIjEZLiYHqhHmReqYkFAfV[0];
						QTvgeNabKIuYngzpDpvGaqKuMlN[3] = NgdaJOIjEZLiYHqhHmReqYkFAfV[1];
						num = 610917769;
						continue;
					case 7:
						QTvgeNabKIuYngzpDpvGaqKuMlN[7] = (byte)(abkUJayxUkCralsgBraYCIYTgEX ? 1 : 0);
						return;
					case 5:
						QTvgeNabKIuYngzpDpvGaqKuMlN.Clear();
						QTvgeNabKIuYngzpDpvGaqKuMlN[1] = 134;
						num = 610917771;
						continue;
					case 3:
						goto IL_00ac;
					case 1:
						switch (P_0)
						{
						case vRcxBEAqDamBCQKhPgzJTHscrFZ.kUvGEDMYxenejWIYnIGGHlzCEzTE:
							break;
						case vRcxBEAqDamBCQKhPgzJTHscrFZ.gTRNYOefbhLxdOylnfzMrQREsGU:
							goto IL_00ac;
						default:
							goto IL_00e0;
						}
						goto case 5;
					case 0:
						QTvgeNabKIuYngzpDpvGaqKuMlN[4] = NgdaJOIjEZLiYHqhHmReqYkFAfV[2];
						return;
					default:
						{
							throw new NotImplementedException();
						}
						IL_00e0:
						num = 610917775;
						continue;
						IL_00ac:
						QTvgeNabKIuYngzpDpvGaqKuMlN.Clear();
						QTvgeNabKIuYngzpDpvGaqKuMlN[1] = 133;
						num = 610917774;
						continue;
					}
					break;
				}
			}
		}

		private bool fbUvchqVJAMRZmINxLfcrXvFufv(zpBwNyEewiHFbuFYIFwNwuraOAx P_0)
		{
			int num;
			switch (P_0)
			{
			case zpBwNyEewiHFbuFYIFwNwuraOAx.EKpTeocgxvNCIDckZbLvmCiYrDh:
				if (xVVyGgNsqweTIzstWzQJegvUeuI == null)
				{
					return false;
				}
				return xVVyGgNsqweTIzstWzQJegvUeuI(LwwCfYrHYYIqqrfRbeSqPqWCpel);
			case zpBwNyEewiHFbuFYIFwNwuraOAx.syPJIPLSIxcExZeAaBkiQLsdgAa:
				if (CjDBJyHuwywJegdtLbKnPIGyviWF == null)
				{
					goto IL_002b;
				}
				CjDBJyHuwywJegdtLbKnPIGyviWF(LwwCfYrHYYIqqrfRbeSqPqWCpel);
				num = -657159081;
				goto IL_0030;
			default:
				{
					throw new NotImplementedException();
				}
				IL_0030:
				switch (num ^ -657159082)
				{
				case 0:
					break;
				case 2:
					return false;
				default:
					return true;
				}
				goto IL_002b;
				IL_002b:
				num = -657159084;
				goto IL_0030;
			}
		}

		private void OmvEduKEMDwCfGsAUMYnJwvhRxA(NativeBuffer P_0, float P_1)
		{
			int num = 0;
			byte b2 = default(byte);
			int num5 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			byte b = default(byte);
			while (true)
			{
				int num2;
				int num3;
				if (num >= 6)
				{
					num2 = -2032571659;
					num3 = num2;
				}
				else
				{
					num2 = -2032571661;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -2032571660)
					{
					case 0:
						num2 = -2032571661;
						continue;
					case 7:
						b2 = P_0[8 + num];
						num5 = num * 8;
						num6 = 0;
						num2 = -2032571658;
						continue;
					case 2:
						num2 = -2032571657;
						continue;
					case 9:
						break;
					case 5:
						if (num4 < 44)
						{
							buttons[num4].SetValue((b2 & (1 << num6)) != 0, P_1);
							num6++;
							num2 = -2032571657;
							continue;
						}
						goto case 4;
					case 4:
						num++;
						num2 = -2032571651;
						continue;
					case 8:
						num4 = num5 + num6;
						num2 = -2032571663;
						continue;
					case 1:
						b = P_0[6];
						buttons[44].SetValue(b < 95, P_1);
						buttons[45].SetValue(b >= 95 && b < 161, P_1);
						buttons[46].SetValue(b >= 161, P_1);
						b = P_0[7];
						buttons[47].SetValue(b < 95, P_1);
						num2 = -2032571662;
						continue;
					case 3:
					{
						int num7;
						if (num6 < 8)
						{
							num2 = -2032571652;
							num7 = num2;
						}
						else
						{
							num2 = -2032571664;
							num7 = num2;
						}
						continue;
					}
					default:
						buttons[48].SetValue(b >= 95 && b < 161, P_1);
						buttons[49].SetValue(b >= 161, P_1);
						return;
					}
					break;
				}
			}
		}

		private void sZiHDSjwxSeuMhlAVhrPPNrmkVY(HIDControllerElement[] P_0, NativeBuffer P_1, float P_2)
		{
			int num = 0;
			while (num < P_0.Length)
			{
				while (true)
				{
					P_0[num].UpdateValue(P_1, P_2);
					num++;
					int num2 = 1512169857;
					while (true)
					{
						switch (num2 ^ 0x5A21E183)
						{
						case 0:
							num2 = 1512169858;
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
				if (!disposing)
				{
					break;
				}
				int num;
				int num2;
				if (RBWbtggyAdLBBLQKDwGIqmFtGqY == null)
				{
					num = -1763695862;
					num2 = num;
				}
				else
				{
					num = -1763695857;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1763695857)
					{
					case 3:
						num = -1763695861;
						continue;
					default:
						return;
					case 5:
					{
						int num3;
						if (QTvgeNabKIuYngzpDpvGaqKuMlN == null)
						{
							num = -1763695859;
							num3 = num;
						}
						else
						{
							num = -1763695858;
							num3 = num;
						}
						continue;
					}
					case 0:
						RBWbtggyAdLBBLQKDwGIqmFtGqY.Dispose();
						num = -1763695862;
						continue;
					case 1:
						QTvgeNabKIuYngzpDpvGaqKuMlN.Dispose();
						num = -1763695859;
						continue;
					case 4:
						break;
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

using Rewired.Utils;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	internal class ButtonStateRecorder
	{
		private class vHkTGRyaXQFcVxJncmjppnpVEEvJ
		{
			public bool GQmuXztxHjqMAaBUMWpbxOBsTgO;

			public float fLCQfSIEWdhUOpKQRRCgDeCTcLm;

			public void kLnQybMiVBnKwrnVkGeKjoKJKGa(vHkTGRyaXQFcVxJncmjppnpVEEvJ P_0)
			{
				GQmuXztxHjqMAaBUMWpbxOBsTgO = P_0.GQmuXztxHjqMAaBUMWpbxOBsTgO;
				fLCQfSIEWdhUOpKQRRCgDeCTcLm = P_0.fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}

			public void xaGVjRxEvIdELjjBskoGFDUNmrm()
			{
				GQmuXztxHjqMAaBUMWpbxOBsTgO = false;
				fLCQfSIEWdhUOpKQRRCgDeCTcLm = 0f;
			}
		}

		private const int sreeYNMPzOsNbJTrubGbgiWzzSt = 3;

		private vHkTGRyaXQFcVxJncmjppnpVEEvJ[] KbaDSiCRyndUgELDxxppquzLFodU;

		private vHkTGRyaXQFcVxJncmjppnpVEEvJ[] ZpeMRihXVDlOpPLotEmcIJpwyql;

		private int zlNLVdtHhAbxfCQCASDlrHwPgmrz;

		private int KIpsofIahfQHAVrxAAehbWFddCMI;

		private uint TnwApTdjiRIqMYhcXTpiskBlSziL;

		public float timePressed
		{
			get
			{
				if (!KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO)
				{
					return 0f;
				}
				return ReInput.unscaledTime - KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}
		}

		public float timeUnpressed
		{
			get
			{
				if (KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO)
				{
					return 0f;
				}
				return ReInput.unscaledTime - KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}
		}

		public float lastTimePressed
		{
			get
			{
				if (KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO)
				{
					return ReInput.unscaledTime;
				}
				return KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}
		}

		public float lastTimeUnpressed
		{
			get
			{
				if (!KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO)
				{
					return ReInput.unscaledTime;
				}
				return KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}
		}

		public float lastTimeStateChangedToPressed
		{
			get
			{
				if (KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO)
				{
					return KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
				}
				return KbaDSiCRyndUgELDxxppquzLFodU[kwMEmalPZWSpaugPVVSkBZUjphk(zlNLVdtHhAbxfCQCASDlrHwPgmrz, 1)].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}
		}

		public float lastTimeStateChangedToUnpressed
		{
			get
			{
				if (!KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO)
				{
					return KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
				}
				return KbaDSiCRyndUgELDxxppquzLFodU[kwMEmalPZWSpaugPVVSkBZUjphk(zlNLVdtHhAbxfCQCASDlrHwPgmrz, 1)].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}
		}

		public float lastTimeStateChanged
		{
			get
			{
				return KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm;
			}
		}

		public ButtonStateRecorder()
		{
			KbaDSiCRyndUgELDxxppquzLFodU = new vHkTGRyaXQFcVxJncmjppnpVEEvJ[3];
			ZpeMRihXVDlOpPLotEmcIJpwyql = new vHkTGRyaXQFcVxJncmjppnpVEEvJ[3];
			for (int i = 0; i < 3; i++)
			{
				KbaDSiCRyndUgELDxxppquzLFodU[i] = new vHkTGRyaXQFcVxJncmjppnpVEEvJ();
				ZpeMRihXVDlOpPLotEmcIJpwyql[i] = new vHkTGRyaXQFcVxJncmjppnpVEEvJ();
			}
			zlNLVdtHhAbxfCQCASDlrHwPgmrz = 0;
			KIpsofIahfQHAVrxAAehbWFddCMI = 0;
		}

		public void rdEJYvExbWYUXSDuseVgzyXPBhA(bool P_0, bool P_1, float P_2)
		{
			bool flag = ((!KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO) ? P_0 : P_1);
			while (true)
			{
				int num = 563698283;
				while (true)
				{
					switch (num ^ 0x21995A6F)
					{
					case 0:
						break;
					case 4:
					{
						int num2;
						if (KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO == flag)
						{
							num = 563698284;
							num2 = num;
						}
						else
						{
							num = 563698286;
							num2 = num;
						}
						continue;
					}
					case 1:
						RVtxOwTrHyBUhfNQjOvZOgNRKQA();
						TnwApTdjiRIqMYhcXTpiskBlSziL = ReInput.currentFrame;
						zlNLVdtHhAbxfCQCASDlrHwPgmrz = VxhwWsSUkzWQQwiIOdjkkCmapqlZ(zlNLVdtHhAbxfCQCASDlrHwPgmrz, 1);
						KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].GQmuXztxHjqMAaBUMWpbxOBsTgO = flag;
						num = 563698285;
						continue;
					case 5:
						return;
					case 3:
						if (ReInput.currentFrame != MiscTools.Tick(TnwApTdjiRIqMYhcXTpiskBlSziL))
						{
							return;
						}
						RVtxOwTrHyBUhfNQjOvZOgNRKQA();
						num = 563698282;
						continue;
					default:
						KbaDSiCRyndUgELDxxppquzLFodU[zlNLVdtHhAbxfCQCASDlrHwPgmrz].fLCQfSIEWdhUOpKQRRCgDeCTcLm = P_2;
						return;
					}
					break;
				}
			}
		}

		public bool dtHhNkdqjhiCGFdjTZiGIeVyhiqE(float P_0)
		{
			return dtHhNkdqjhiCGFdjTZiGIeVyhiqE(KbaDSiCRyndUgELDxxppquzLFodU, zlNLVdtHhAbxfCQCASDlrHwPgmrz, P_0);
		}

		public bool hgSrbdcpCAMBqxrIsXAVaoFTMBP(float P_0)
		{
			return dtHhNkdqjhiCGFdjTZiGIeVyhiqE(ZpeMRihXVDlOpPLotEmcIJpwyql, KIpsofIahfQHAVrxAAehbWFddCMI, P_0);
		}

		private static bool dtHhNkdqjhiCGFdjTZiGIeVyhiqE(vHkTGRyaXQFcVxJncmjppnpVEEvJ[] P_0, int P_1, float P_2)
		{
			if (P_2 <= 0f)
			{
				return false;
			}
			if (!P_0[P_1].GQmuXztxHjqMAaBUMWpbxOBsTgO)
			{
				return false;
			}
			int num = kwMEmalPZWSpaugPVVSkBZUjphk(P_1, 2);
			if (!P_0[num].GQmuXztxHjqMAaBUMWpbxOBsTgO)
			{
				return false;
			}
			if (P_0[P_1].fLCQfSIEWdhUOpKQRRCgDeCTcLm - P_0[num].fLCQfSIEWdhUOpKQRRCgDeCTcLm <= P_2)
			{
				return true;
			}
			return false;
		}

		private void RVtxOwTrHyBUhfNQjOvZOgNRKQA()
		{
			if (KIpsofIahfQHAVrxAAehbWFddCMI != zlNLVdtHhAbxfCQCASDlrHwPgmrz)
			{
				goto IL_000e;
			}
			goto IL_004b;
			IL_000e:
			int num = -216402939;
			goto IL_0013;
			IL_0013:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -216402943)
				{
				case 5:
					break;
				case 4:
					KIpsofIahfQHAVrxAAehbWFddCMI = zlNLVdtHhAbxfCQCASDlrHwPgmrz;
					num = -216402941;
					continue;
				case 2:
					goto IL_004b;
				case 1:
					ZpeMRihXVDlOpPLotEmcIJpwyql[num2].kLnQybMiVBnKwrnVkGeKjoKJKGa(KbaDSiCRyndUgELDxxppquzLFodU[num2]);
					num2++;
					num = -216402942;
					continue;
				case 0:
					num = -216402942;
					continue;
				default:
					if (num2 >= 3)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
			goto IL_000e;
			IL_004b:
			num2 = 0;
			num = -216402943;
			goto IL_0013;
		}

		public void xaGVjRxEvIdELjjBskoGFDUNmrm()
		{
			zlNLVdtHhAbxfCQCASDlrHwPgmrz = 0;
			KIpsofIahfQHAVrxAAehbWFddCMI = 0;
			int num = 0;
			while (num < 3)
			{
				while (true)
				{
					KbaDSiCRyndUgELDxxppquzLFodU[num].xaGVjRxEvIdELjjBskoGFDUNmrm();
					ZpeMRihXVDlOpPLotEmcIJpwyql[num].xaGVjRxEvIdELjjBskoGFDUNmrm();
					int num2 = 1860725237;
					while (true)
					{
						switch (num2 ^ 0x6EE869F5)
						{
						case 3:
							num2 = 1860725236;
							continue;
						case 1:
							break;
						case 0:
							num++;
							num2 = 1860725239;
							continue;
						default:
							goto end_IL_0034;
						}
						break;
					}
					continue;
					end_IL_0034:
					break;
				}
			}
			TnwApTdjiRIqMYhcXTpiskBlSziL = 0u;
		}

		public void pnbrdZwKvfGuMdGIxtXIcSwuZSA(float P_0)
		{
			rdEJYvExbWYUXSDuseVgzyXPBhA(false, false, P_0);
		}

		private static int VxhwWsSUkzWQQwiIOdjkkCmapqlZ(int P_0, int P_1)
		{
			if (P_1 < 0)
			{
				P_1 = 0;
				goto IL_0007;
			}
			goto IL_0034;
			IL_0055:
			int num = default(int);
			return num;
			IL_0007:
			int num2 = -1899254218;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num2 ^ -1899254217)
				{
				case 4:
					break;
				case 1:
					num2 = -1899254220;
					continue;
				case 0:
					goto IL_0034;
				case 3:
					goto IL_0042;
				default:
					goto IL_0055;
				}
				break;
			}
			goto IL_0007;
			IL_0034:
			if (P_1 > 3)
			{
				P_1 = 3;
				num2 = -1899254220;
				goto IL_000c;
			}
			goto IL_0042;
			IL_0042:
			num = P_0 + P_1;
			if (num >= 3)
			{
				num -= 3;
				num2 = -1899254219;
				goto IL_000c;
			}
			goto IL_0055;
		}

		private static int kwMEmalPZWSpaugPVVSkBZUjphk(int P_0, int P_1)
		{
			if (P_1 < 0)
			{
				P_1 = 0;
				goto IL_0007;
			}
			goto IL_0040;
			IL_004e:
			int num = P_0 - P_1;
			int num2 = -1016182213;
			goto IL_000c;
			IL_0007:
			num2 = -1016182212;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num2 ^ -1016182216)
				{
				case 5:
					break;
				case 3:
					if (num < 0)
					{
						num += 3;
						num2 = -1016182216;
						continue;
					}
					goto default;
				case 1:
					goto IL_0040;
				case 2:
					goto IL_004e;
				case 4:
					num2 = -1016182214;
					continue;
				default:
					return num;
				}
				break;
			}
			goto IL_0007;
			IL_0040:
			if (P_1 > 3)
			{
				P_1 = 3;
				num2 = -1016182214;
				goto IL_000c;
			}
			goto IL_004e;
		}
	}
}

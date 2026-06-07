using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Interfaces;
using Rewired.Platforms;

internal class ywJkAizTVJIvGNjxsTUDDuEcjbC : IDisposable, IDeviceManager
{
	private static class mCkhkXvyKGOCmcDbPdbKxllMBKwD
	{
		private struct JcSzUBWPPmuOYzPDhjFlkjqgMpHH
		{
			internal int SgJtVUqCMXXZWFYoZOePEhSyhZe;

			internal int scNjJnZniUfEVdkcNenzKOnvOitF;

			internal int fTTimptWpkBUCelRyavQdwCgDAGc;

			internal Guid AFqOiwvOPqZHvvfHRAofUaPDsVh;

			internal short btXDvkJFnUNDqacLvCVOCbwBiSwg;
		}

		private const int cCtTSaPFRnwVpFoPwOJZQbIWjMJa = 5;

		private const int GGjtQKcwuPFycjPrHvAMBgJgcgB = 0;

		private static readonly Guid XCBqwDirnNklPmduIbonOWrmrFi = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");

		private static IntPtr wEFlxBnBPPYClmHNbbFkSdQaggU;

		private static bool KKcJIIEsUsncKYwbOYyHqIBDrfP;

		public static void cbdtreJJBOBWInuuuZdzMmTHAFp(IntPtr P_0)
		{
			JcSzUBWPPmuOYzPDhjFlkjqgMpHH jcSzUBWPPmuOYzPDhjFlkjqgMpHH = new JcSzUBWPPmuOYzPDhjFlkjqgMpHH
			{
				scNjJnZniUfEVdkcNenzKOnvOitF = 5,
				fTTimptWpkBUCelRyavQdwCgDAGc = 0,
				AFqOiwvOPqZHvvfHRAofUaPDsVh = XCBqwDirnNklPmduIbonOWrmrFi,
				btXDvkJFnUNDqacLvCVOCbwBiSwg = 0
			};
			while (true)
			{
				int num = -1851644184;
				while (true)
				{
					switch (num ^ -1851644182)
					{
					case 0:
						break;
					case 2:
						goto IL_004c;
					default:
						KKcJIIEsUsncKYwbOYyHqIBDrfP = true;
						return;
					}
					break;
					IL_004c:
					jcSzUBWPPmuOYzPDhjFlkjqgMpHH.SgJtVUqCMXXZWFYoZOePEhSyhZe = Marshal.SizeOf((object)jcSzUBWPPmuOYzPDhjFlkjqgMpHH);
					IntPtr intPtr = Marshal.AllocHGlobal(jcSzUBWPPmuOYzPDhjFlkjqgMpHH.SgJtVUqCMXXZWFYoZOePEhSyhZe);
					Marshal.StructureToPtr((object)jcSzUBWPPmuOYzPDhjFlkjqgMpHH, intPtr, true);
					wEFlxBnBPPYClmHNbbFkSdQaggU = wqxLUlEiLadYzqFaUmpXRqevXlv(P_0, intPtr, 0);
					num = -1851644181;
				}
			}
		}

		public static void UHVUeQeEjVbRcerPiVxKpznkHuur()
		{
			if (wEFlxBnBPPYClmHNbbFkSdQaggU == IntPtr.Zero)
			{
				return;
			}
			while (true)
			{
				KijAVOondNJxazPGmJbCgmgOCpq(wEFlxBnBPPYClmHNbbFkSdQaggU);
				KKcJIIEsUsncKYwbOYyHqIBDrfP = false;
				int num = -1449020581;
				while (true)
				{
					switch (num ^ -1449020581)
					{
					case 2:
						goto IL_0012;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0012:
					num = -1449020582;
				}
			}
		}

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "RegisterDeviceNotification", SetLastError = true)]
		private static extern IntPtr wqxLUlEiLadYzqFaUmpXRqevXlv(IntPtr P_0, IntPtr P_1, int P_2);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnregisterDeviceNotification")]
		private static extern bool KijAVOondNJxazPGmJbCgmgOCpq(IntPtr P_0);
	}

	private const int ZxCpbvEExEcFIEQisHalbCQryCWp = 32772;

	private const int HXZxFQtEJHgChAEcjyXIOxztkkl = 32768;

	private const int mKMFDziBStQItJEJqNrxawkQQfuZ = 7;

	private const int ebxnijLjaoPuQThoQWTeYdDHaZy = 537;

	private const int EQaFdhmTqrEwMWvgYNcwxYBBlpt = 255;

	private Action<EventArgs> kcWvmAtJmcjxcvKuAkTkpVcMSBv;

	private Action<EventArgs> EtElCzgWNcnVTyjmUqAtLUxdbNl;

	private Action<WsSYQoLcjDhJJICQctaOSeWVJfl, ZsxRzJGagMdpbHQHKZpXdCpvBdnC> jMkzHbJDlkKIvMkXZfodYPUkmaP;

	private IntPtr MRPmakpNtWovDiEpWDkpPdpCqJm;

	private qEnIACTEaVowTZHrdOWusBSvvTe FoUVHveQrzwutlZzKtkaudXhPWR;

	private readonly bool FgHZkoRGNeioFjCybKVqAjFHQgHv;

	private static ypRryIywRrvtKyGzmsiTAVfBgMf UXUVAFvNhzrJpHoHPGdLJpAImsG;

	private qEnIACTEaVowTZHrdOWusBSvvTe YiAClIXCDYbLGJspgLSRyuzBeYc;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public IntPtr windowHandle
	{
		get
		{
			return MRPmakpNtWovDiEpWDkpPdpCqJm;
		}
	}

	public event Action<EventArgs> DeviceConnectedEvent
	{
		add
		{
			kcWvmAtJmcjxcvKuAkTkpVcMSBv = (Action<EventArgs>)Delegate.Combine(kcWvmAtJmcjxcvKuAkTkpVcMSBv, value);
		}
		remove
		{
			kcWvmAtJmcjxcvKuAkTkpVcMSBv = (Action<EventArgs>)Delegate.Remove(kcWvmAtJmcjxcvKuAkTkpVcMSBv, value);
		}
	}

	public event Action<EventArgs> DeviceDisconnectedEvent
	{
		add
		{
			EtElCzgWNcnVTyjmUqAtLUxdbNl = (Action<EventArgs>)Delegate.Combine(EtElCzgWNcnVTyjmUqAtLUxdbNl, value);
		}
		remove
		{
			EtElCzgWNcnVTyjmUqAtLUxdbNl = (Action<EventArgs>)Delegate.Remove(EtElCzgWNcnVTyjmUqAtLUxdbNl, value);
		}
	}

	public event Action<WsSYQoLcjDhJJICQctaOSeWVJfl, ZsxRzJGagMdpbHQHKZpXdCpvBdnC> WindowFocusEvent
	{
		add
		{
			jMkzHbJDlkKIvMkXZfodYPUkmaP = (Action<WsSYQoLcjDhJJICQctaOSeWVJfl, ZsxRzJGagMdpbHQHKZpXdCpvBdnC>)Delegate.Combine(jMkzHbJDlkKIvMkXZfodYPUkmaP, value);
		}
		remove
		{
			jMkzHbJDlkKIvMkXZfodYPUkmaP = (Action<WsSYQoLcjDhJJICQctaOSeWVJfl, ZsxRzJGagMdpbHQHKZpXdCpvBdnC>)Delegate.Remove(jMkzHbJDlkKIvMkXZfodYPUkmaP, value);
		}
	}

	public ywJkAizTVJIvGNjxsTUDDuEcjbC()
	{
		FgHZkoRGNeioFjCybKVqAjFHQgHv = ReInput.editorPlatform != EditorPlatform.None;
		try
		{
			GVPNrpnUrcRcuBVNsoUmnQYWdWW();
		}
		catch
		{
			OnDestroy();
			throw;
		}
	}

	public void OnDestroy()
	{
		Dispose();
	}

	private void GVPNrpnUrcRcuBVNsoUmnQYWdWW()
	{
		xAmovVZaOrgpHoUPBaMgcEWlcnp();
		while (true)
		{
			int num = -658492473;
			while (true)
			{
				switch (num ^ -658492474)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					cbdtreJJBOBWInuuuZdzMmTHAFp();
					num = -658492475;
					continue;
				case 4:
					YiAClIXCDYbLGJspgLSRyuzBeYc.sNUVbIfmUnCXtcPdpvKSKByqonA(HhVpkhNlKFGktBwaNtQESPMqvuD, true);
					num = -658492476;
					continue;
				case 3:
					if (FgHZkoRGNeioFjCybKVqAjFHQgHv)
					{
						YiAClIXCDYbLGJspgLSRyuzBeYc = new qEnIACTEaVowTZHrdOWusBSvvTe();
						num = -658492478;
						continue;
					}
					return;
				case 2:
					return;
				}
				break;
			}
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~ywJkAizTVJIvGNjxsTUDDuEcjbC()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	private void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		while (true)
		{
			int num = 113595246;
			while (true)
			{
				switch (num ^ 0x6C5536B)
				{
				case 0:
					num = 113595244;
					continue;
				case 3:
					if (UXUVAFvNhzrJpHoHPGdLJpAImsG != null)
					{
						UXUVAFvNhzrJpHoHPGdLJpAImsG.Dispose();
						num = 113595242;
						continue;
					}
					goto default;
				case 4:
				{
					UHVUeQeEjVbRcerPiVxKpznkHuur();
					int num2;
					if (FoUVHveQrzwutlZzKtkaudXhPWR == null)
					{
						num = 113595245;
						num2 = num;
					}
					else
					{
						num = 113595241;
						num2 = num;
					}
					continue;
				}
				case 1:
					UXUVAFvNhzrJpHoHPGdLJpAImsG = null;
					num = 113595245;
					continue;
				case 7:
					break;
				case 2:
					FoUVHveQrzwutlZzKtkaudXhPWR.Dispose();
					num = 113595245;
					continue;
				case 5:
					if (FgHZkoRGNeioFjCybKVqAjFHQgHv)
					{
						UHVUeQeEjVbRcerPiVxKpznkHuur();
						if (YiAClIXCDYbLGJspgLSRyuzBeYc != null)
						{
							YiAClIXCDYbLGJspgLSRyuzBeYc.Dispose();
							num = 113595240;
							continue;
						}
						goto case 3;
					}
					goto case 4;
				default:
					nNxUslIcGUpqKgpPZYhuimcvWyC = true;
					return;
				}
				break;
			}
		}
	}

	private void cbdtreJJBOBWInuuuZdzMmTHAFp()
	{
		mCkhkXvyKGOCmcDbPdbKxllMBKwD.cbdtreJJBOBWInuuuZdzMmTHAFp(MRPmakpNtWovDiEpWDkpPdpCqJm);
	}

	private void UHVUeQeEjVbRcerPiVxKpznkHuur()
	{
		mCkhkXvyKGOCmcDbPdbKxllMBKwD.UHVUeQeEjVbRcerPiVxKpznkHuur();
	}

	private void ntDdBFmYMRWoAKaQgYYvuyNDljA(nMvdyvLQEkLRQHBHYCdBihdKBYQ P_0, WsSYQoLcjDhJJICQctaOSeWVJfl P_1, uint P_2, IntPtr P_3)
	{
		int num = default(int);
		if (P_2 == 537)
		{
			num = P_1.EFoPoIegfgaMlAZTYtQqfztfcBXU();
			if (!(P_3 == MRPmakpNtWovDiEpWDkpPdpCqJm))
			{
				return;
			}
			goto IL_0025;
		}
		goto IL_00e8;
		IL_00e8:
		int num2;
		int num3;
		if (P_2 != 8)
		{
			num2 = 157679142;
			num3 = num2;
		}
		else
		{
			num2 = 157679146;
			num3 = num2;
		}
		goto IL_002a;
		IL_0025:
		num2 = 157679145;
		goto IL_002a;
		IL_002a:
		int num4 = default(int);
		while (true)
		{
			switch (num2 ^ 0x965FE20)
			{
			case 2:
				break;
			default:
				return;
			case 9:
				goto IL_0066;
			case 5:
				kcWvmAtJmcjxcvKuAkTkpVcMSBv(null);
				return;
			case 0:
				goto IL_0091;
			case 3:
				if (kcWvmAtJmcjxcvKuAkTkpVcMSBv != null)
				{
					EtElCzgWNcnVTyjmUqAtLUxdbNl(null);
				}
				return;
			case 7:
				goto IL_00cc;
			case 4:
				goto IL_00e8;
			case 10:
				if (jMkzHbJDlkKIvMkXZfodYPUkmaP != null)
				{
					jMkzHbJDlkKIvMkXZfodYPUkmaP(P_1, cHGdLHdUWUiYzPziDkeopfYJjxqa.VyOYFRkHDGhrKrZBponProEudfx(P_2));
					num2 = 157679144;
					continue;
				}
				return;
			case 6:
				goto IL_0124;
			case 1:
				if (num4 != 32772)
				{
					return;
				}
				goto case 3;
			case 8:
				return;
			}
			break;
			IL_0124:
			int num5;
			if (P_2 != 7)
			{
				num2 = 157679144;
				num5 = num2;
			}
			else
			{
				num2 = 157679146;
				num5 = num2;
			}
			continue;
			IL_0091:
			int num6;
			if (num4 == 32768)
			{
				num2 = 157679143;
				num6 = num2;
			}
			else
			{
				num2 = 157679137;
				num6 = num2;
			}
			continue;
			IL_0066:
			num4 = num;
			int num7;
			if (num4 != 7)
			{
				num2 = 157679136;
				num7 = num2;
			}
			else
			{
				num2 = 157679144;
				num7 = num2;
			}
			continue;
			IL_00cc:
			int num8;
			if (kcWvmAtJmcjxcvKuAkTkpVcMSBv == null)
			{
				num2 = 157679144;
				num8 = num2;
			}
			else
			{
				num2 = 157679141;
				num8 = num2;
			}
		}
		goto IL_0025;
	}

	private void HhVpkhNlKFGktBwaNtQESPMqvuD(nMvdyvLQEkLRQHBHYCdBihdKBYQ P_0, WsSYQoLcjDhJJICQctaOSeWVJfl P_1, uint P_2, IntPtr P_3)
	{
		if (P_2 != 8)
		{
			return;
		}
		while (true)
		{
			int num = -2006125145;
			while (true)
			{
				switch (num ^ -2006125146)
				{
				case 3:
					break;
				default:
					return;
				case 1:
				{
					int num2;
					if (jMkzHbJDlkKIvMkXZfodYPUkmaP != null)
					{
						num = -2006125148;
						num2 = num;
					}
					else
					{
						num = -2006125146;
						num2 = num;
					}
					continue;
				}
				case 2:
					jMkzHbJDlkKIvMkXZfodYPUkmaP(P_1, cHGdLHdUWUiYzPziDkeopfYJjxqa.VyOYFRkHDGhrKrZBponProEudfx(P_2));
					num = -2006125146;
					continue;
				case 0:
					return;
				}
				break;
			}
		}
	}

	private void xAmovVZaOrgpHoUPBaMgcEWlcnp()
	{
		if (UXUVAFvNhzrJpHoHPGdLJpAImsG == null)
		{
			UXUVAFvNhzrJpHoHPGdLJpAImsG = new ypRryIywRrvtKyGzmsiTAVfBgMf("RewiredWDMWindow", true, ZijmbIcFjontUJtBTgfaEwleuPx);
			if (UXUVAFvNhzrJpHoHPGdLJpAImsG.Handle == IntPtr.Zero)
			{
				throw new Exception("Error creating window.");
			}
		}
		else
		{
			while (true)
			{
				int num;
				int num2;
				if (!(UXUVAFvNhzrJpHoHPGdLJpAImsG.Handle == IntPtr.Zero))
				{
					num = 112221024;
					num2 = num;
				}
				else
				{
					num = 112221031;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x6B05B63)
					{
					case 2:
						num = 112221026;
						continue;
					case 1:
						break;
					case 4:
						throw new Exception("Message window has invalid handle.");
					case 3:
						UXUVAFvNhzrJpHoHPGdLJpAImsG.BKXMAnXhehZjsngcOWeeasMVARE(ZijmbIcFjontUJtBTgfaEwleuPx);
						num = 112221027;
						continue;
					default:
						goto end_IL_006d;
					}
					break;
				}
				continue;
				end_IL_006d:
				break;
			}
		}
		MRPmakpNtWovDiEpWDkpPdpCqJm = UXUVAFvNhzrJpHoHPGdLJpAImsG.Handle;
	}

	private IntPtr ZijmbIcFjontUJtBTgfaEwleuPx(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		ntDdBFmYMRWoAKaQgYYvuyNDljA(P_3, P_2, P_1, P_0);
		return IntPtr.Zero;
	}
}

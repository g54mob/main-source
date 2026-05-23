using System;
using System.Runtime.InteropServices;
using System.Security;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class oJzlKgBJFvkxDtiZFeeJNOxpEWjF : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate IntPtr hfDaZXAAPxoiaBGsKlTjnWHAqWhT(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct BHBYRfEJPSFXDsNEpQwUdCxCPfq
	{
		public uint mAurSHRzRFZGcUiEkTAHtRUiiOx;

		public IntPtr HniiWKpCyFAuvxtXHynCCFqZwDw;

		public int vbJeZpSvUHCevFtmTGngHfYdhmo;

		public int gvaCNDjZYbsvkaiUysfzyLzxFCB;

		public IntPtr SbrcTNfMafgPRyhoOvDaOOpPIMCH;

		public IntPtr AyimVfCQZkGSIGvutyeAmBnlyNs;

		public IntPtr FTjXLVJONyyJSwytlcbenPuJYKt;

		public IntPtr UpZzRlHosRjuZZjbjAeEeoaSLVKW;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string szJBPPOoxesTzTDEdwUAwYMlGqO;

		[MarshalAs(UnmanagedType.LPWStr)]
		public string vzpfIpONhtIYeiRwZQRwEYhtjyP;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct EsjAYzzJHiLKWZAVReXYgSAJjMhO
	{
		public IntPtr zdQdnopunvIslaAdOVYjcLLHimSS;

		public IntPtr SbrcTNfMafgPRyhoOvDaOOpPIMCH;

		public IntPtr HgQtasieQehTnlnXaOgyUFDAcbV;

		public IntPtr raqAPGegCYKrEixIpkfkvCFPWrb;

		public int uUSDkzQWEYrvqIlECwiObalkVBF;

		public int DIhdyFdJJaALqtzVAMbRiQXXupQ;

		public int PPbqRHFiecbEhHnZAAzNKBrPASea;

		public int dwcksDbKbKTxMUqRtRLrDcsbnSa;

		public int mAurSHRzRFZGcUiEkTAHtRUiiOx;

		public IntPtr ejpqtKLUkJGMXuuoEGFDZHoXxDf;

		public IntPtr IhnggwCUrMdrSPUafiIeyOYHnFc;

		public uint bVgAiOBJWTpJnNWMdPxnaOSZrOTU;
	}

	private const int vImHaEIxbPlIinrkJprMJZxycTz = 20;

	private const int ShSicldombPCEDqoDURxSQIGjeV = 1410;

	private readonly ushort OKHHEsjhsEsPUuOEDDNQbwQqkwpq;

	private readonly string jduEBmBJILhmgPhypmJpyvrysXBB;

	private bool XAEJHkrUDjhJZvohNJmGEOiEojT;

	private IntPtr fvzfYZwKUhsNIlMSeHkduMJOAtN;

	private int IACKqFIHdqoHSNCqrHwEtfbthyKD;

	private uint QWVdvsKoWWfEvuBabBDZBWElfvU;

	private hfDaZXAAPxoiaBGsKlTjnWHAqWhT ComFZQtMnvPrPfGCqlrCWJtHQSQ;

	private hfDaZXAAPxoiaBGsKlTjnWHAqWhT BEnCTLfaiYCGvTTHautDUwSLxUl;

	public IntPtr Handle
	{
		get
		{
			return fvzfYZwKUhsNIlMSeHkduMJOAtN;
		}
	}

	public uint Id
	{
		get
		{
			return QWVdvsKoWWfEvuBabBDZBWElfvU;
		}
	}

	public bool Exists
	{
		get
		{
			if (!(fvzfYZwKUhsNIlMSeHkduMJOAtN != IntPtr.Zero))
			{
				return false;
			}
			return afmLScYaVVFpbIqZjDcpdvLYAuJF(fvzfYZwKUhsNIlMSeHkduMJOAtN);
		}
	}

	[DllImport("user32.dll", EntryPoint = "RegisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern ushort UshdiuubxoAHwRxeaHCJHAeLbpX([In] ref BHBYRfEJPSFXDsNEpQwUdCxCPfq P_0);

	[DllImport("user32.dll", EntryPoint = "UnregisterClassW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool KKGNGfqNNiFniCqXHTSeUOgQtYfs([MarshalAs(UnmanagedType.LPWStr)] string P_0, IntPtr P_1);

	[DllImport("user32.dll", EntryPoint = "CreateWindowExW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr xNMrTPNeXKENTosJWexAKPsOpGf(uint P_0, [MarshalAs(UnmanagedType.LPWStr)] string P_1, [MarshalAs(UnmanagedType.LPWStr)] string P_2, uint P_3, int P_4, int P_5, int P_6, int P_7, IntPtr P_8, IntPtr P_9, IntPtr P_10, IntPtr P_11);

	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern IntPtr bKIXJkDmQtqgIRUkQtoxPoAzxEL(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3);

	[DllImport("user32.dll", EntryPoint = "DestroyWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool JehMNotHFOLsrrqtqsCsWxweptH(IntPtr P_0);

	[DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool afmLScYaVVFpbIqZjDcpdvLYAuJF(IntPtr P_0);

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~oJzlKgBJFvkxDtiZFeeJNOxpEWjF()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	private void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (!XAEJHkrUDjhJZvohNJmGEOiEojT)
		{
			if (P_0)
			{
				ObjectInstanceTracker.Default.Unregister(QWVdvsKoWWfEvuBabBDZBWElfvU);
				goto IL_001e;
			}
			goto IL_008a;
		}
		return;
		IL_0023:
		int num;
		while (true)
		{
			switch (num ^ -656472063)
			{
			case 7:
				break;
			default:
				return;
			case 0:
				fvzfYZwKUhsNIlMSeHkduMJOAtN = IntPtr.Zero;
				num = -656472057;
				continue;
			case 5:
				if (!string.IsNullOrEmpty(jduEBmBJILhmgPhypmJpyvrysXBB))
				{
					KKGNGfqNNiFniCqXHTSeUOgQtYfs(jduEBmBJILhmgPhypmJpyvrysXBB, IntPtr.Zero);
					num = -656472064;
					continue;
				}
				goto case 1;
			case 2:
				goto IL_008a;
			case 4:
				JehMNotHFOLsrrqtqsCsWxweptH(fvzfYZwKUhsNIlMSeHkduMJOAtN);
				num = -656472063;
				continue;
			case 1:
				XAEJHkrUDjhJZvohNJmGEOiEojT = true;
				num = -656472062;
				continue;
			case 6:
				goto IL_00d7;
			case 3:
				return;
			}
			break;
			IL_00d7:
			int num2;
			if (OKHHEsjhsEsPUuOEDDNQbwQqkwpq == 0)
			{
				num = -656472064;
				num2 = num;
			}
			else
			{
				num = -656472060;
				num2 = num;
			}
		}
		goto IL_001e;
		IL_008a:
		int num3;
		if (!(fvzfYZwKUhsNIlMSeHkduMJOAtN != IntPtr.Zero))
		{
			num = -656472057;
			num3 = num;
		}
		else
		{
			num = -656472059;
			num3 = num;
		}
		goto IL_0023;
		IL_001e:
		num = -656472061;
		goto IL_0023;
	}

	public oJzlKgBJFvkxDtiZFeeJNOxpEWjF(string className, bool createMessageOnlyWindow, hfDaZXAAPxoiaBGsKlTjnWHAqWhT staticCustomWndProcDelegate)
	{
		if (string.IsNullOrEmpty(className))
		{
			throw new ArgumentNullException("className");
		}
		if (staticCustomWndProcDelegate == null)
		{
			throw new ArgumentNullException("staticCustomWndProcDelegate");
		}
		QWVdvsKoWWfEvuBabBDZBWElfvU = ObjectInstanceTracker.Default.Register(this);
		jduEBmBJILhmgPhypmJpyvrysXBB = className;
		ComFZQtMnvPrPfGCqlrCWJtHQSQ = lLFcKbgWzECGgeXvJQUbUwfzfMI;
		BEnCTLfaiYCGvTTHautDUwSLxUl = staticCustomWndProcDelegate;
		IACKqFIHdqoHSNCqrHwEtfbthyKD = 0;
		BHBYRfEJPSFXDsNEpQwUdCxCPfq bHBYRfEJPSFXDsNEpQwUdCxCPfq = new BHBYRfEJPSFXDsNEpQwUdCxCPfq
		{
			HniiWKpCyFAuvxtXHynCCFqZwDw = Marshal.GetFunctionPointerForDelegate(ComFZQtMnvPrPfGCqlrCWJtHQSQ)
		};
		while (OKHHEsjhsEsPUuOEDDNQbwQqkwpq == 0 && IACKqFIHdqoHSNCqrHwEtfbthyKD < 20)
		{
			bHBYRfEJPSFXDsNEpQwUdCxCPfq.vzpfIpONhtIYeiRwZQRwEYhtjyP = className;
			OKHHEsjhsEsPUuOEDDNQbwQqkwpq = UshdiuubxoAHwRxeaHCJHAeLbpX(ref bHBYRfEJPSFXDsNEpQwUdCxCPfq);
			if (OKHHEsjhsEsPUuOEDDNQbwQqkwpq != 0)
			{
				break;
			}
			IACKqFIHdqoHSNCqrHwEtfbthyKD++;
			className = jduEBmBJILhmgPhypmJpyvrysXBB + IACKqFIHdqoHSNCqrHwEtfbthyKD;
		}
		if (OKHHEsjhsEsPUuOEDDNQbwQqkwpq == 0)
		{
			throw new Exception("Could not register window class!");
		}
		if (jduEBmBJILhmgPhypmJpyvrysXBB != className)
		{
			jduEBmBJILhmgPhypmJpyvrysXBB = className;
		}
		if (createMessageOnlyWindow)
		{
			fvzfYZwKUhsNIlMSeHkduMJOAtN = jEQHjTBCSSQEWmNbLMWqAevCDGT(className, new IntPtr((int)QWVdvsKoWWfEvuBabBDZBWElfvU));
		}
		else
		{
			fvzfYZwKUhsNIlMSeHkduMJOAtN = lriEHPjGDaqtFEuwERfSNZIQMvq(className, new IntPtr((int)QWVdvsKoWWfEvuBabBDZBWElfvU));
		}
	}

	private IntPtr lriEHPjGDaqtFEuwERfSNZIQMvq(string P_0, IntPtr P_1)
	{
		return xNMrTPNeXKENTosJWexAKPsOpGf(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	private IntPtr jEQHjTBCSSQEWmNbLMWqAevCDGT(string P_0, IntPtr P_1)
	{
		return xNMrTPNeXKENTosJWexAKPsOpGf(0u, P_0, string.Empty, 0u, 0, 0, 0, 0, HVtRggqIPNRqQNXHENoxokIzsuB.OGldKNhdDsQZQNaDjiWlaKmfAIMR, IntPtr.Zero, IntPtr.Zero, P_1);
	}

	[MonoPInvokeCallback(typeof(hfDaZXAAPxoiaBGsKlTjnWHAqWhT))]
	private unsafe static IntPtr lLFcKbgWzECGgeXvJQUbUwfzfMI(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (P_0 == IntPtr.Zero)
		{
			goto IL_0010;
		}
		bool flag = false;
		uint instanceId = 0u;
		int num;
		int num2;
		if (P_1 == 1)
		{
			num = -342774005;
			num2 = num;
		}
		else
		{
			num = -342774001;
			num2 = num;
		}
		goto IL_0015;
		IL_0010:
		num = -342774002;
		goto IL_0015;
		IL_0015:
		EsjAYzzJHiLKWZAVReXYgSAJjMhO* ptr = default(EsjAYzzJHiLKWZAVReXYgSAJjMhO*);
		while (true)
		{
			switch (num ^ -342774007)
			{
			case 8:
				break;
			case 6:
				instanceId = (uint)FTnXWfjUOcgIwWIoVmLFTvfzpAl.lGtbpSctgCOVgjcRZOBtxAHmuAs(P_0, -21).ToInt32();
				flag = true;
				num = -342774007;
				continue;
			case 2:
			{
				ptr = (EsjAYzzJHiLKWZAVReXYgSAJjMhO*)(void*)P_3;
				int num4;
				if (!(ptr->zdQdnopunvIslaAdOVYjcLLHimSS != IntPtr.Zero))
				{
					num = -342774007;
					num4 = num;
				}
				else
				{
					num = -342774008;
					num4 = num;
				}
				continue;
			}
			case 7:
				return bKIXJkDmQtqgIRUkQtoxPoAzxEL(P_0, P_1, P_2, P_3);
			case 5:
				num = -342774007;
				continue;
			case 3:
			{
				oJzlKgBJFvkxDtiZFeeJNOxpEWjF instance;
				if (ObjectInstanceTracker.Default.TryGetInstance<oJzlKgBJFvkxDtiZFeeJNOxpEWjF>(instanceId, out instance))
				{
					instance.BEnCTLfaiYCGvTTHautDUwSLxUl(P_0, P_1, P_2, P_3);
					num = -342774003;
					continue;
				}
				goto default;
			}
			case 0:
			{
				int num3;
				if (flag)
				{
					num = -342774006;
					num3 = num;
				}
				else
				{
					num = -342774003;
					num3 = num;
				}
				continue;
			}
			case 1:
				FTnXWfjUOcgIwWIoVmLFTvfzpAl.UZNlCVZBmfojHyBnPWSLlVNcwin(P_0, -21, ptr->zdQdnopunvIslaAdOVYjcLLHimSS);
				num = -342774004;
				continue;
			default:
				return bKIXJkDmQtqgIRUkQtoxPoAzxEL(P_0, P_1, P_2, P_3);
			}
			break;
		}
		goto IL_0010;
	}

	public void NNjSVLaMvnjCrirYpSSwjcMpKAI(hfDaZXAAPxoiaBGsKlTjnWHAqWhT P_0)
	{
		BEnCTLfaiYCGvTTHautDUwSLxUl = P_0;
	}
}

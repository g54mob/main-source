using System;
using System.Runtime.InteropServices;

internal class ZfLXiaApzRahDcEcREEzUwHQeyYH : IDisposable
{
	public struct IhhvErOGDwlAbSjeAFWIlMlndLXhA
	{
		private byte luMbTOxtPOdvhtedAhYfTlmszxTE;

		private uint JpLeXaxTKxaeJOCPrxTFoJFckWLF;

		private int ezVicsTBCOzScnnrFmEfwPXxCgFkA;

		private static IhhvErOGDwlAbSjeAFWIlMlndLXhA jvPDGushDqkqnaCTxgTXGOlFhxncb;

		public byte bruNptJxtNByxatrPKOMHCynXeHL => luMbTOxtPOdvhtedAhYfTlmszxTE;

		public uint HtYpMhKppxTipdkRjTxaVRgjYsic => JpLeXaxTKxaeJOCPrxTFoJFckWLF;

		public int IsaBjzhehZFfCacBhhqVIEVDjtnQ => ezVicsTBCOzScnnrFmEfwPXxCgFkA;

		public static IhhvErOGDwlAbSjeAFWIlMlndLXhA orybNWumaEfGNJWfetzRFRNSIkPVA => jvPDGushDqkqnaCTxgTXGOlFhxncb;

		public IhhvErOGDwlAbSjeAFWIlMlndLXhA(byte P_0, uint P_1, int P_2)
		{
			luMbTOxtPOdvhtedAhYfTlmszxTE = P_0;
			JpLeXaxTKxaeJOCPrxTFoJFckWLF = P_1;
			ezVicsTBCOzScnnrFmEfwPXxCgFkA = P_2;
			if (ezVicsTBCOzScnnrFmEfwPXxCgFkA < 0)
			{
				ezVicsTBCOzScnnrFmEfwPXxCgFkA = 0;
			}
		}
	}

	private const byte ZZvRRWnHhJIwMfljkzMoWIYEQgDjA = 254;

	private uint xIVbOOrcqLeQkYluCDNxeScRAWrk;

	private int YiLMrhQgTDNtjaYzHKfMkpdWhTiDA;

	private unsafe byte* CZIQjoLeZeCFPdNqHSQxNGpLrMhE;

	private byte UlbXGwKxOCenXcGszjoPdFGULtyL;

	private bool sELMpkkDYziHimWrDUjqidmgppon;

	private bool eZAHHzafizLzvOYaPRlqzCdaAuQc;

	public int mGuQiaKJUeBXmtjsTpKLQIhTtDys => YiLMrhQgTDNtjaYzHKfMkpdWhTiDA;

	public unsafe ZfLXiaApzRahDcEcREEzUwHQeyYH(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		YiLMrhQgTDNtjaYzHKfMkpdWhTiDA = P_0;
		xIVbOOrcqLeQkYluCDNxeScRAWrk = 0u;
		CZIQjoLeZeCFPdNqHSQxNGpLrMhE = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool vHsHrkjTLrkjjcLvBOoTnFVVILcJ(IntPtr P_0, int P_1, out IhhvErOGDwlAbSjeAFWIlMlndLXhA P_2)
	{
		if (CZIQjoLeZeCFPdNqHSQxNGpLrMhE == null || P_1 <= 0)
		{
			P_2 = default(IhhvErOGDwlAbSjeAFWIlMlndLXhA);
			return false;
		}
		if (P_1 > YiLMrhQgTDNtjaYzHKfMkpdWhTiDA)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)xIVbOOrcqLeQkYluCDNxeScRAWrk + P_1) > YiLMrhQgTDNtjaYzHKfMkpdWhTiDA)
		{
			xIVbOOrcqLeQkYluCDNxeScRAWrk = 0u;
			if (UlbXGwKxOCenXcGszjoPdFGULtyL == 254)
			{
				UlbXGwKxOCenXcGszjoPdFGULtyL = 0;
				sELMpkkDYziHimWrDUjqidmgppon = true;
			}
			else
			{
				UlbXGwKxOCenXcGszjoPdFGULtyL++;
			}
		}
		wfRybNWHWOpoyMQsxzdwHdiNgarj.nKdiTfgozSSfAPPIDTVXEexjrvtQ(CZIQjoLeZeCFPdNqHSQxNGpLrMhE + xIVbOOrcqLeQkYluCDNxeScRAWrk, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new IhhvErOGDwlAbSjeAFWIlMlndLXhA(UlbXGwKxOCenXcGszjoPdFGULtyL, xIVbOOrcqLeQkYluCDNxeScRAWrk, P_1);
		xIVbOOrcqLeQkYluCDNxeScRAWrk += (uint)P_1;
		return true;
	}

	public int DEnFsdfBhNdAOrXniGtLBDjAHdAR(IhhvErOGDwlAbSjeAFWIlMlndLXhA P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.IsaBjzhehZFfCacBhhqVIEVDjtnQ)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!uqgzAuEbhJefESdGeSwVxEntbvzx(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(PiifpSPnvMPaUFRLIkKJmsHdurkk(P_0), P_1, 0, P_0.IsaBjzhehZFfCacBhhqVIEVDjtnQ);
		return P_0.IsaBjzhehZFfCacBhhqVIEVDjtnQ;
	}

	public unsafe int xwUtSRwTGulsjrHqWynxPZBQQTyH(IhhvErOGDwlAbSjeAFWIlMlndLXhA P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.IsaBjzhehZFfCacBhhqVIEVDjtnQ)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!uqgzAuEbhJefESdGeSwVxEntbvzx(ref P_0))
		{
			return -1;
		}
		wfRybNWHWOpoyMQsxzdwHdiNgarj.nKdiTfgozSSfAPPIDTVXEexjrvtQ((void*)P_1, (void*)PiifpSPnvMPaUFRLIkKJmsHdurkk(P_0), new UIntPtr((uint)P_0.IsaBjzhehZFfCacBhhqVIEVDjtnQ));
		return P_0.IsaBjzhehZFfCacBhhqVIEVDjtnQ;
	}

	public unsafe IntPtr PiifpSPnvMPaUFRLIkKJmsHdurkk(IhhvErOGDwlAbSjeAFWIlMlndLXhA P_0)
	{
		if (CZIQjoLeZeCFPdNqHSQxNGpLrMhE == null || !uqgzAuEbhJefESdGeSwVxEntbvzx(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(CZIQjoLeZeCFPdNqHSQxNGpLrMhE + P_0.HtYpMhKppxTipdkRjTxaVRgjYsic);
	}

	public unsafe bool SMsiMuenBTTdGWNnBsjnRkDfTTcE(IhhvErOGDwlAbSjeAFWIlMlndLXhA P_0, out IntPtr P_1)
	{
		if (CZIQjoLeZeCFPdNqHSQxNGpLrMhE == null || !uqgzAuEbhJefESdGeSwVxEntbvzx(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(CZIQjoLeZeCFPdNqHSQxNGpLrMhE + P_0.HtYpMhKppxTipdkRjTxaVRgjYsic);
		return true;
	}

	private bool uqgzAuEbhJefESdGeSwVxEntbvzx(ref IhhvErOGDwlAbSjeAFWIlMlndLXhA P_0)
	{
		int num = P_0.IsaBjzhehZFfCacBhhqVIEVDjtnQ;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.bruNptJxtNByxatrPKOMHCynXeHL;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != UlbXGwKxOCenXcGszjoPdFGULtyL)
		{
			if (!sELMpkkDYziHimWrDUjqidmgppon)
			{
				if (num2 + 1 != UlbXGwKxOCenXcGszjoPdFGULtyL)
				{
					return false;
				}
			}
			else if (num2 > UlbXGwKxOCenXcGszjoPdFGULtyL)
			{
				if (UlbXGwKxOCenXcGszjoPdFGULtyL != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != UlbXGwKxOCenXcGszjoPdFGULtyL)
			{
				return false;
			}
			if (P_0.HtYpMhKppxTipdkRjTxaVRgjYsic < xIVbOOrcqLeQkYluCDNxeScRAWrk)
			{
				return false;
			}
		}
		else if (P_0.HtYpMhKppxTipdkRjTxaVRgjYsic + num > xIVbOOrcqLeQkYluCDNxeScRAWrk)
		{
			return false;
		}
		if (P_0.HtYpMhKppxTipdkRjTxaVRgjYsic + num > YiLMrhQgTDNtjaYzHKfMkpdWhTiDA)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		xgPpPSarHdlUiQRJwomyYMdcafYl(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void VMmARHNnVledWvwKCGdQFlrTvWTP()
	{
		try
		{
			xgPpPSarHdlUiQRJwomyYMdcafYl(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void xgPpPSarHdlUiQRJwomyYMdcafYl(bool P_0)
	{
		if (!eZAHHzafizLzvOYaPRlqzCdaAuQc)
		{
			if (CZIQjoLeZeCFPdNqHSQxNGpLrMhE != null)
			{
				Marshal.FreeHGlobal((IntPtr)CZIQjoLeZeCFPdNqHSQxNGpLrMhE);
			}
			eZAHHzafizLzvOYaPRlqzCdaAuQc = true;
		}
	}
}

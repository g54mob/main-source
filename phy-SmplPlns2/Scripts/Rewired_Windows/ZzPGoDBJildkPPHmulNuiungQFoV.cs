using System;
using Rewired.Utils;

internal class ZzPGoDBJildkPPHmulNuiungQFoV : IDisposable
{
	private readonly XDbjydBaRflbbcCWXMsNJdiGwFsu pOCzKentnnebAivkNUtmpCxKVoRl;

	private readonly int AzTmWXqfzrwxCVkeoNBsPkguFlDD;

	private long gpZwEmCddDTGgtDDhjYuAphPuEEWA;

	private long WmMXtsGMpxPFIYXLuHQXUnHXGGNFA;

	private int IHyEJNYqsiKFFjpcaQDerrYTAHDhA;

	private bool VXAeVahNBDEPzBUcgclLclbIaQcP;

	private uint kthBPpGPDOvXYYFpdrtIwJKEnIic;

	private bool TPrQkNyuEHLyNNddiUxwQAQQMncI;

	public int uwrZSIDjjwMnPosdTFvkIndcvdKI => AzTmWXqfzrwxCVkeoNBsPkguFlDD;

	public int jHtVYyyyugDKoNOgcyGxZDonhKsr => IHyEJNYqsiKFFjpcaQDerrYTAHDhA;

	public bool jaijgxTyvYUGHcoHzylEIlmxCYrd => VXAeVahNBDEPzBUcgclLclbIaQcP;

	public ZzPGoDBJildkPPHmulNuiungQFoV(int P_0)
	{
		AzTmWXqfzrwxCVkeoNBsPkguFlDD = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		pOCzKentnnebAivkNUtmpCxKVoRl = new XDbjydBaRflbbcCWXMsNJdiGwFsu(P_0);
	}

	public unsafe int zhIbMFIlOLdppNGAXWmhgXAFORrW(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)gpZwEmCddDTGgtDDhjYuAphPuEEWA;
		P_4 = kthBPpGPDOvXYYFpdrtIwJKEnIic;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = pOCzKentnnebAivkNUtmpCxKVoRl.uxXfzWekZkEErxQMfmOfTlhGaPsw(P_0, P_1, P_2, (int)gpZwEmCddDTGgtDDhjYuAphPuEEWA);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += pOCzKentnnebAivkNUtmpCxKVoRl.uxXfzWekZkEErxQMfmOfTlhGaPsw(P_0 + num, P_1 - num, P_2 - num);
		}
		dhlEAttKmMMhQkrlpVSBdHPBISvhA(num);
		return num;
	}

	public unsafe int dHHPVlakNFdzyxNZaGSeAuDuNpkB(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)gpZwEmCddDTGgtDDhjYuAphPuEEWA;
			P_4 = kthBPpGPDOvXYYFpdrtIwJKEnIic;
			return 0;
		}
		return zhIbMFIlOLdppNGAXWmhgXAFORrW((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int DhJCeNPqpQXslOMEeEURVXbuUJwl(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)gpZwEmCddDTGgtDDhjYuAphPuEEWA;
			P_3 = kthBPpGPDOvXYYFpdrtIwJKEnIic;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return zhIbMFIlOLdppNGAXWmhgXAFORrW(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int rcoFGXasWIdnHrVrRGgBBygHWfQVA(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return zhIbMFIlOLdppNGAXWmhgXAFORrW(P_0, P_1, P_2, out num, out num2);
	}

	public int FPrEmeKrJoRGjOjlSVjBzSQIRtmB(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return dHHPVlakNFdzyxNZaGSeAuDuNpkB(P_0, P_1, P_2, out num, out num2);
	}

	public int tOVowfYdZvrOWRwKzvzzOyfLIIYn(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return DhJCeNPqpQXslOMEeEURVXbuUJwl(P_0, P_1, out num, out num2);
	}

	public unsafe int bvTwTDNxgUPxTsoroHnOJwhtrRFS(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || IHyEJNYqsiKFFjpcaQDerrYTAHDhA == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > IHyEJNYqsiKFFjpcaQDerrYTAHDhA)
		{
			P_2 = IHyEJNYqsiKFFjpcaQDerrYTAHDhA;
		}
		int num = pOCzKentnnebAivkNUtmpCxKVoRl.uTmENDANNVnxYNZlWbDCcQValJGX(P_0, P_1, P_2, (int)WmMXtsGMpxPFIYXLuHQXUnHXGGNFA);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += pOCzKentnnebAivkNUtmpCxKVoRl.uTmENDANNVnxYNZlWbDCcQValJGX(P_0 + num, P_1 - num, P_2 - num);
		}
		yGauryOdRDpUfrvqUTrkkkyvYyQM(num);
		return num;
	}

	public unsafe int mbZiiJKMpleSyWlfMidOugAMlXXp(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return bvTwTDNxgUPxTsoroHnOJwhtrRFS(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int yQVMffEeJGhpQVScBWjsuEfScnAh(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return bvTwTDNxgUPxTsoroHnOJwhtrRFS((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int HVKCRLBIMFdKGAWOcowUIoizIfbQB(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || IHyEJNYqsiKFFjpcaQDerrYTAHDhA == 0 || P_3 < 0 || P_3 >= AzTmWXqfzrwxCVkeoNBsPkguFlDD)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > IHyEJNYqsiKFFjpcaQDerrYTAHDhA)
		{
			P_2 = IHyEJNYqsiKFFjpcaQDerrYTAHDhA;
		}
		int num = pOCzKentnnebAivkNUtmpCxKVoRl.uTmENDANNVnxYNZlWbDCcQValJGX(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += pOCzKentnnebAivkNUtmpCxKVoRl.uTmENDANNVnxYNZlWbDCcQValJGX(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int MJDDprKbzDhLqbtrljnOoqwgNTEOA(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return HVKCRLBIMFdKGAWOcowUIoizIfbQB(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int VocyLeKmVWbXwEfjEHHxQaKuQaQK(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return HVKCRLBIMFdKGAWOcowUIoizIfbQB((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool qcXqOzlxamiSKqZHfrPwCLBtFmYFA(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= AzTmWXqfzrwxCVkeoNBsPkguFlDD)
		{
			return false;
		}
		if (P_0 < gpZwEmCddDTGgtDDhjYuAphPuEEWA)
		{
			if (P_1 == kthBPpGPDOvXYYFpdrtIwJKEnIic)
			{
				return true;
			}
		}
		else if (P_0 >= gpZwEmCddDTGgtDDhjYuAphPuEEWA)
		{
			if (kthBPpGPDOvXYYFpdrtIwJKEnIic == 0)
			{
				return false;
			}
			if (kthBPpGPDOvXYYFpdrtIwJKEnIic - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void DusQZBlMntjuCQSndYSIAlXUrKRP()
	{
		gpZwEmCddDTGgtDDhjYuAphPuEEWA = 0L;
		WmMXtsGMpxPFIYXLuHQXUnHXGGNFA = 0L;
		IHyEJNYqsiKFFjpcaQDerrYTAHDhA = 0;
		VXAeVahNBDEPzBUcgclLclbIaQcP = false;
		kthBPpGPDOvXYYFpdrtIwJKEnIic = 0u;
	}

	private void dhlEAttKmMMhQkrlpVSBdHPBISvhA(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)gpZwEmCddDTGgtDDhjYuAphPuEEWA;
		gpZwEmCddDTGgtDDhjYuAphPuEEWA += P_0;
		bool flag = false;
		if (num < WmMXtsGMpxPFIYXLuHQXUnHXGGNFA)
		{
			if (gpZwEmCddDTGgtDDhjYuAphPuEEWA > WmMXtsGMpxPFIYXLuHQXUnHXGGNFA)
			{
				flag = true;
			}
		}
		else if (num > WmMXtsGMpxPFIYXLuHQXUnHXGGNFA)
		{
			if (gpZwEmCddDTGgtDDhjYuAphPuEEWA - AzTmWXqfzrwxCVkeoNBsPkguFlDD > WmMXtsGMpxPFIYXLuHQXUnHXGGNFA)
			{
				flag = true;
			}
		}
		else if (IHyEJNYqsiKFFjpcaQDerrYTAHDhA > 0)
		{
			flag = true;
		}
		if (flag)
		{
			VXAeVahNBDEPzBUcgclLclbIaQcP = true;
			WmMXtsGMpxPFIYXLuHQXUnHXGGNFA = gpZwEmCddDTGgtDDhjYuAphPuEEWA;
			if (WmMXtsGMpxPFIYXLuHQXUnHXGGNFA >= AzTmWXqfzrwxCVkeoNBsPkguFlDD)
			{
				WmMXtsGMpxPFIYXLuHQXUnHXGGNFA -= AzTmWXqfzrwxCVkeoNBsPkguFlDD;
			}
		}
		if (gpZwEmCddDTGgtDDhjYuAphPuEEWA >= AzTmWXqfzrwxCVkeoNBsPkguFlDD)
		{
			gpZwEmCddDTGgtDDhjYuAphPuEEWA -= AzTmWXqfzrwxCVkeoNBsPkguFlDD;
			yNjIJtVcMfHdZUJQrOsiXjFvogEe();
		}
		IHyEJNYqsiKFFjpcaQDerrYTAHDhA = (int)MathTools.Clamp((long)IHyEJNYqsiKFFjpcaQDerrYTAHDhA + (long)P_0, 0L, AzTmWXqfzrwxCVkeoNBsPkguFlDD);
	}

	private void yGauryOdRDpUfrvqUTrkkkyvYyQM(int P_0)
	{
		if (P_0 > 0)
		{
			if (VXAeVahNBDEPzBUcgclLclbIaQcP)
			{
				VXAeVahNBDEPzBUcgclLclbIaQcP = false;
			}
			WmMXtsGMpxPFIYXLuHQXUnHXGGNFA += P_0;
			if (WmMXtsGMpxPFIYXLuHQXUnHXGGNFA >= AzTmWXqfzrwxCVkeoNBsPkguFlDD)
			{
				WmMXtsGMpxPFIYXLuHQXUnHXGGNFA -= AzTmWXqfzrwxCVkeoNBsPkguFlDD;
			}
			long num = (long)IHyEJNYqsiKFFjpcaQDerrYTAHDhA - (long)P_0;
			IHyEJNYqsiKFFjpcaQDerrYTAHDhA = (int)((num >= 0) ? num : 0);
		}
	}

	private void yNjIJtVcMfHdZUJQrOsiXjFvogEe()
	{
		if (kthBPpGPDOvXYYFpdrtIwJKEnIic == uint.MaxValue)
		{
			kthBPpGPDOvXYYFpdrtIwJKEnIic = 0u;
		}
		else
		{
			kthBPpGPDOvXYYFpdrtIwJKEnIic++;
		}
	}

	public void Dispose()
	{
		mtnWuGMpiYezxKXJLNAVwnmZfBzx(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void FShhyiSKLwlBxxYpDeYqSSimUrLA()
	{
		try
		{
			mtnWuGMpiYezxKXJLNAVwnmZfBzx(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void mtnWuGMpiYezxKXJLNAVwnmZfBzx(bool P_0)
	{
		if (!TPrQkNyuEHLyNNddiUxwQAQQMncI)
		{
			if (P_0 && pOCzKentnnebAivkNUtmpCxKVoRl != null)
			{
				pOCzKentnnebAivkNUtmpCxKVoRl.Dispose();
			}
			TPrQkNyuEHLyNNddiUxwQAQQMncI = true;
		}
	}
}

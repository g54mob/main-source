using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class trECJlapetlXTVHAMaIGvBCOBBsW : IDisposable
{
	public delegate void WsPqOqwkpEBWSFpLqvXRdvTffGSIA(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int waUctIIpoLtkzHsqQABUWlRhvQeEA = 512;

	private const int bDvvPRLokkqYolOqWBkpVqTXnTNC = 250;

	private readonly WsPqOqwkpEBWSFpLqvXRdvTffGSIA ldmZDwHVwBjQbPjWcBkwtcNzqgTp;

	private readonly zNTQhNpludJgufGWmGaBgfsOxMNR ufHlYDnqnEODFKqZPLjsThlueOau;

	private readonly ThreadHelper FHPpHxCnKaLGyCOhYXRXIAfPGNKw;

	private readonly int moHPcSKtVvmTjcdUBqUHWIzRDEwP;

	private readonly int YEUDpEANoKqNlbaKgvuGOngggPIHC;

	private readonly string uPxkUgRfnTWJxPLbVzyfBGevNWoO;

	private readonly byte[] hftEppPxHXeXeDgcdnNwMlvmGSuFb;

	private readonly byte[] JbMiWtHIEBlSfFXxDlwBnudSWHEGc;

	private int erJKFAtyARGYNzYEmwLnaIwTokfc;

	private EPrXCjyNCCNqaaSWeFZDBxPzIadgA ZQeFIhadJWJYqvegokxePrpGLTiH;

	private EPrXCjyNCCNqaaSWeFZDBxPzIadgA mGReTdahYBLYGVtzZPXxkelqBLDC;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public trECJlapetlXTVHAMaIGvBCOBBsW(string P_0, int P_1, string P_2, WsPqOqwkpEBWSFpLqvXRdvTffGSIA P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		YEUDpEANoKqNlbaKgvuGOngggPIHC = P_1;
		if (YEUDpEANoKqNlbaKgvuGOngggPIHC <= 0)
		{
			YEUDpEANoKqNlbaKgvuGOngggPIHC = 512;
		}
		moHPcSKtVvmTjcdUBqUHWIzRDEwP = P_1 + 8;
		uPxkUgRfnTWJxPLbVzyfBGevNWoO = P_2;
		ldmZDwHVwBjQbPjWcBkwtcNzqgTp = P_3;
		int num = moHPcSKtVvmTjcdUBqUHWIzRDEwP * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			ufHlYDnqnEODFKqZPLjsThlueOau = new zNTQhNpludJgufGWmGaBgfsOxMNR(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			ZQeFIhadJWJYqvegokxePrpGLTiH = new EPrXCjyNCCNqaaSWeFZDBxPzIadgA(num);
			mGReTdahYBLYGVtzZPXxkelqBLDC = new EPrXCjyNCCNqaaSWeFZDBxPzIadgA(num);
			hftEppPxHXeXeDgcdnNwMlvmGSuFb = new byte[moHPcSKtVvmTjcdUBqUHWIzRDEwP];
			JbMiWtHIEBlSfFXxDlwBnudSWHEGc = new byte[moHPcSKtVvmTjcdUBqUHWIzRDEwP];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			FHPpHxCnKaLGyCOhYXRXIAfPGNKw = ThreadHelper.Create();
			FHPpHxCnKaLGyCOhYXRXIAfPGNKw.ThreadUpdateEvent += dzbhUNdQxAXwmaJEOPDmDUFfjPaHc;
			FHPpHxCnKaLGyCOhYXRXIAfPGNKw.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void mefhGqvTkcrETnFSidhNngFjAYNV()
	{
		try
		{
			if (fHTCCgqioJHfkGjbJlRcMvxRgJnBb())
			{
				return;
			}
			kXhdKFJOZSmQkpQLIEGzTJqMrgVd();
			int num = 0;
			byte[] array = hftEppPxHXeXeDgcdnNwMlvmGSuFb;
			fixed (byte* ptr = array)
			{
				while (ZQeFIhadJWJYqvegokxePrpGLTiH.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(array, moHPcSKtVvmTjcdUBqUHWIzRDEwP) > 0)
				{
					ldmZDwHVwBjQbPjWcBkwtcNzqgTp((IntPtr)ptr, YEUDpEANoKqNlbaKgvuGOngggPIHC, 1, *(double*)(ptr + YEUDpEANoKqNlbaKgvuGOngggPIHC));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void kXhdKFJOZSmQkpQLIEGzTJqMrgVd()
	{
		lock (ZQeFIhadJWJYqvegokxePrpGLTiH)
		{
			lock (mGReTdahYBLYGVtzZPXxkelqBLDC)
			{
				MiscTools.Swap(ref ZQeFIhadJWJYqvegokxePrpGLTiH, ref mGReTdahYBLYGVtzZPXxkelqBLDC);
			}
		}
	}

	private void dzbhUNdQxAXwmaJEOPDmDUFfjPaHc()
	{
		if (erJKFAtyARGYNzYEmwLnaIwTokfc != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] jbMiWtHIEBlSfFXxDlwBnudSWHEGc = JbMiWtHIEBlSfFXxDlwBnudSWHEGc;
			if (!TchtxzaRFHUkBELuVIijHISZYudk(jbMiWtHIEBlSfFXxDlwBnudSWHEGc))
			{
				return;
			}
			lock (mGReTdahYBLYGVtzZPXxkelqBLDC)
			{
				mGReTdahYBLYGVtzZPXxkelqBLDC.EvDntuhsTubUqbxfRrKDVdXsLcYv(jbMiWtHIEBlSfFXxDlwBnudSWHEGc, jbMiWtHIEBlSfFXxDlwBnudSWHEGc.Length);
			}
		}
		catch
		{
		}
	}

	private bool TchtxzaRFHUkBELuVIijHISZYudk(byte[] P_0)
	{
		switch (ufHlYDnqnEODFKqZPLjsThlueOau.xWPdFkhEuYbKoMqaTzNbLlMyFnpGA(P_0))
		{
		case zNTQhNpludJgufGWmGaBgfsOxMNR.MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Success:
			return true;
		case zNTQhNpludJgufGWmGaBgfsOxMNR.MBgDSvDSNKDYibXRWKLgWbEeWIqPA.Error:
			Thread.Sleep(500);
			break;
		case zNTQhNpludJgufGWmGaBgfsOxMNR.MBgDSvDSNKDYibXRWKLgWbEeWIqPA.CriticalError:
			erJKFAtyARGYNzYEmwLnaIwTokfc = 1;
			break;
		}
		return false;
	}

	private bool fHTCCgqioJHfkGjbJlRcMvxRgJnBb()
	{
		if (erJKFAtyARGYNzYEmwLnaIwTokfc != 0)
		{
			if (erJKFAtyARGYNzYEmwLnaIwTokfc == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + uPxkUgRfnTWJxPLbVzyfBGevNWoO + "\" will not function.");
				erJKFAtyARGYNzYEmwLnaIwTokfc = 2;
				try
				{
					FHPpHxCnKaLGyCOhYXRXIAfPGNKw.Stop(wait: false);
				}
				catch
				{
				}
			}
			return true;
		}
		return false;
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return;
		}
		if (P_0)
		{
			if (FHPpHxCnKaLGyCOhYXRXIAfPGNKw != null)
			{
				FHPpHxCnKaLGyCOhYXRXIAfPGNKw.Dispose();
			}
			if (ufHlYDnqnEODFKqZPLjsThlueOau != null)
			{
				ufHlYDnqnEODFKqZPLjsThlueOau.Dispose();
			}
		}
		JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
	}
}

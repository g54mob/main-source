using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class xZjBEKLLoTmwmhTedOIsAwePDqHx : IDisposable
{
	public delegate void vMlWYdwSqUJdADVckKvgYBiHONPc(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int KqBdilkIHEyplDYHUJcUGoefXVs = 512;

	private const int uUDJQsaRUoZMgYFeFUdvdmQMUGJA = 250;

	private readonly vMlWYdwSqUJdADVckKvgYBiHONPc hpefSkiGOCqsiGDxdgytigGVuCDs;

	private readonly tGsCfcIZaFUYHZmkTOuxFfEHfNif dLutZuhxBdazUEdQReVjcSMLfcZgA;

	private readonly ThreadHelper YgarsObQsRalBiVlawQXDyUUwcafA;

	private readonly int sRPULzKPtkWtZMpDPmhOSdjGIPDF;

	private readonly int LRgfDOdbrbUFpACbprTGKmIozixQ;

	private readonly string CmBWIYWnJQXbvIvuufMxeqahdMLR;

	private readonly byte[] CTJijAdiUYvQQiglITqFQlvlafqFA;

	private readonly byte[] bWEJwplNBUJUxsfJtqbcOBaRDuLT;

	private int FlTIhQEwHyqHAhorRGJvIinGIGErA;

	private AmYESGfNIwJpRvEsPUpxsahyQJMqA GZuDAarxDmgITImridOYPrZAPDGGb;

	private AmYESGfNIwJpRvEsPUpxsahyQJMqA hTaKbpgGienFMCfOckjLPksYEnrr;

	private bool NYCKYUfamglldNSuPYmrIpPLLcNV;

	public xZjBEKLLoTmwmhTedOIsAwePDqHx(string P_0, int P_1, string P_2, vMlWYdwSqUJdADVckKvgYBiHONPc P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		LRgfDOdbrbUFpACbprTGKmIozixQ = P_1;
		if (LRgfDOdbrbUFpACbprTGKmIozixQ <= 0)
		{
			LRgfDOdbrbUFpACbprTGKmIozixQ = 512;
		}
		sRPULzKPtkWtZMpDPmhOSdjGIPDF = P_1 + 8;
		CmBWIYWnJQXbvIvuufMxeqahdMLR = P_2;
		hpefSkiGOCqsiGDxdgytigGVuCDs = P_3;
		int num = sRPULzKPtkWtZMpDPmhOSdjGIPDF * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			dLutZuhxBdazUEdQReVjcSMLfcZgA = new tGsCfcIZaFUYHZmkTOuxFfEHfNif(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			GZuDAarxDmgITImridOYPrZAPDGGb = new AmYESGfNIwJpRvEsPUpxsahyQJMqA(num);
			hTaKbpgGienFMCfOckjLPksYEnrr = new AmYESGfNIwJpRvEsPUpxsahyQJMqA(num);
			CTJijAdiUYvQQiglITqFQlvlafqFA = new byte[sRPULzKPtkWtZMpDPmhOSdjGIPDF];
			bWEJwplNBUJUxsfJtqbcOBaRDuLT = new byte[sRPULzKPtkWtZMpDPmhOSdjGIPDF];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			YgarsObQsRalBiVlawQXDyUUwcafA = ThreadHelper.Create();
			YgarsObQsRalBiVlawQXDyUUwcafA.ThreadUpdateEvent += qYekzFSYWLtiukgZlKRrAxTlHciI;
			YgarsObQsRalBiVlawQXDyUUwcafA.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void tvsdRFmcmvnlaPgbxvaHonjICjyn()
	{
		try
		{
			if (xGaWLYNbEYgvKWVIJelyVUkcFKebA())
			{
				return;
			}
			XjbduPNBBllHjoTBzEVWebwuXVGd();
			int num = 0;
			byte[] cTJijAdiUYvQQiglITqFQlvlafqFA = CTJijAdiUYvQQiglITqFQlvlafqFA;
			fixed (byte* ptr = cTJijAdiUYvQQiglITqFQlvlafqFA)
			{
				while (GZuDAarxDmgITImridOYPrZAPDGGb.lAQwSKSLnoFinJzHtPFEmOfGJjle(cTJijAdiUYvQQiglITqFQlvlafqFA, sRPULzKPtkWtZMpDPmhOSdjGIPDF) > 0)
				{
					hpefSkiGOCqsiGDxdgytigGVuCDs((IntPtr)ptr, LRgfDOdbrbUFpACbprTGKmIozixQ, 1, *(double*)(ptr + LRgfDOdbrbUFpACbprTGKmIozixQ));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void XjbduPNBBllHjoTBzEVWebwuXVGd()
	{
		lock (GZuDAarxDmgITImridOYPrZAPDGGb)
		{
			lock (hTaKbpgGienFMCfOckjLPksYEnrr)
			{
				MiscTools.Swap(ref GZuDAarxDmgITImridOYPrZAPDGGb, ref hTaKbpgGienFMCfOckjLPksYEnrr);
			}
		}
	}

	private void qYekzFSYWLtiukgZlKRrAxTlHciI()
	{
		if (FlTIhQEwHyqHAhorRGJvIinGIGErA != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = bWEJwplNBUJUxsfJtqbcOBaRDuLT;
			if (!tLvutnUvemTGNbNoLMiPuEymEPml(array))
			{
				return;
			}
			lock (hTaKbpgGienFMCfOckjLPksYEnrr)
			{
				hTaKbpgGienFMCfOckjLPksYEnrr.qsCkhsUjteNDWUbQUeJeEndHiAeq(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool tLvutnUvemTGNbNoLMiPuEymEPml(byte[] P_0)
	{
		switch (dLutZuhxBdazUEdQReVjcSMLfcZgA.KxCecyYasVJDPEEjFyFPAmYMHDih(P_0))
		{
		case tGsCfcIZaFUYHZmkTOuxFfEHfNif.GWDTUGgUPsUVJfFjnVfYOpezhWTL.Success:
			return true;
		case tGsCfcIZaFUYHZmkTOuxFfEHfNif.GWDTUGgUPsUVJfFjnVfYOpezhWTL.Error:
			Thread.Sleep(500);
			break;
		case tGsCfcIZaFUYHZmkTOuxFfEHfNif.GWDTUGgUPsUVJfFjnVfYOpezhWTL.CriticalError:
			FlTIhQEwHyqHAhorRGJvIinGIGErA = 1;
			break;
		}
		return false;
	}

	private bool xGaWLYNbEYgvKWVIJelyVUkcFKebA()
	{
		if (FlTIhQEwHyqHAhorRGJvIinGIGErA != 0)
		{
			if (FlTIhQEwHyqHAhorRGJvIinGIGErA == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + CmBWIYWnJQXbvIvuufMxeqahdMLR + "\" will not function.");
				FlTIhQEwHyqHAhorRGJvIinGIGErA = 2;
				try
				{
					YgarsObQsRalBiVlawQXDyUUwcafA.Stop(wait: false);
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
		IfMCVOBVSEjoCghHaeJmuSyIYqad(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void FKzKhMXkpiebxcBytxrWNWQmgzlJ()
	{
		try
		{
			IfMCVOBVSEjoCghHaeJmuSyIYqad(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void IfMCVOBVSEjoCghHaeJmuSyIYqad(bool P_0)
	{
		if (NYCKYUfamglldNSuPYmrIpPLLcNV)
		{
			return;
		}
		if (P_0)
		{
			if (YgarsObQsRalBiVlawQXDyUUwcafA != null)
			{
				YgarsObQsRalBiVlawQXDyUUwcafA.Dispose();
			}
			if (dLutZuhxBdazUEdQReVjcSMLfcZgA != null)
			{
				dLutZuhxBdazUEdQReVjcSMLfcZgA.Dispose();
			}
		}
		NYCKYUfamglldNSuPYmrIpPLLcNV = true;
	}
}

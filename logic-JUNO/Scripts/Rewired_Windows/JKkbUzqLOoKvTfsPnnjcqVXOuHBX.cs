using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class JKkbUzqLOoKvTfsPnnjcqVXOuHBX : IDisposable
{
	public delegate void VLJWvRtyRiMWFseeKbrybeSqvXu(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int uvAlHbCcwjvAwzrZBngHcDpjmNrA = 512;

	private const int IZTBnFallUbzSVwshixNKTJjUOI = 250;

	private readonly VLJWvRtyRiMWFseeKbrybeSqvXu HThrQVHFurlqXEeIdTadUYlWdiNG;

	private readonly NVbYGTjyIoFkaXKVDdqlhebWGYkJ NQxSXNMmzQiazYonFispgOpCALVuA;

	private readonly ThreadHelper srfoahQfEyEmuHRWwVvTNQxXqPoAb;

	private readonly int MCGALOjdMXLFqGhERJzAyoMFxXBj;

	private readonly int xmzEXfYeFImGEYAEllyEoDpdDTtO;

	private readonly string qhCwOlpZrhVcAEwRijjtKmNicrHFA;

	private readonly byte[] uIYkpnMsynSPbcJAQUFZiMOiiAor;

	private readonly byte[] ZrXNuEIRjjYkIwcwtgXeiMDUkFVy;

	private int rZKIrfnJnDaGxJtWRBcxlGGVNpIdb;

	private DvHHuxsqxRwcGFxtArJeHIKLKLNU yEvFKPcQtZNLcjoAmptUZZiJzaCGA;

	private DvHHuxsqxRwcGFxtArJeHIKLKLNU DyzEBEFKANyovITviWkTxMBVMxfh;

	private bool dTLKWhSmQDJmWTpLFaHtfgcCcFVSA;

	public JKkbUzqLOoKvTfsPnnjcqVXOuHBX(string P_0, int P_1, string P_2, VLJWvRtyRiMWFseeKbrybeSqvXu P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		xmzEXfYeFImGEYAEllyEoDpdDTtO = P_1;
		if (xmzEXfYeFImGEYAEllyEoDpdDTtO <= 0)
		{
			xmzEXfYeFImGEYAEllyEoDpdDTtO = 512;
		}
		MCGALOjdMXLFqGhERJzAyoMFxXBj = P_1 + 8;
		qhCwOlpZrhVcAEwRijjtKmNicrHFA = P_2;
		HThrQVHFurlqXEeIdTadUYlWdiNG = P_3;
		int num = MCGALOjdMXLFqGhERJzAyoMFxXBj * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			NQxSXNMmzQiazYonFispgOpCALVuA = new NVbYGTjyIoFkaXKVDdqlhebWGYkJ(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			yEvFKPcQtZNLcjoAmptUZZiJzaCGA = new DvHHuxsqxRwcGFxtArJeHIKLKLNU(num);
			DyzEBEFKANyovITviWkTxMBVMxfh = new DvHHuxsqxRwcGFxtArJeHIKLKLNU(num);
			uIYkpnMsynSPbcJAQUFZiMOiiAor = new byte[MCGALOjdMXLFqGhERJzAyoMFxXBj];
			ZrXNuEIRjjYkIwcwtgXeiMDUkFVy = new byte[MCGALOjdMXLFqGhERJzAyoMFxXBj];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			srfoahQfEyEmuHRWwVvTNQxXqPoAb = ThreadHelper.Create();
			srfoahQfEyEmuHRWwVvTNQxXqPoAb.ThreadUpdateEvent += InliKslliiacZcuurbhdkimejwos;
			srfoahQfEyEmuHRWwVvTNQxXqPoAb.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void ZqldZyLcKAEiLLhKpuVVAhAJiWcX()
	{
		try
		{
			if (XmdwNheMspbwfSWfXHGejpTnNfqdA())
			{
				return;
			}
			fyslregFjGmNAifofCnMWLWdFaUS();
			int num = 0;
			byte[] array = uIYkpnMsynSPbcJAQUFZiMOiiAor;
			fixed (byte* ptr = array)
			{
				while (yEvFKPcQtZNLcjoAmptUZZiJzaCGA.xgntfGYTNFPppWwlKrKwnzNPoHaL(array, MCGALOjdMXLFqGhERJzAyoMFxXBj) > 0)
				{
					HThrQVHFurlqXEeIdTadUYlWdiNG((IntPtr)ptr, xmzEXfYeFImGEYAEllyEoDpdDTtO, 1, *(double*)(ptr + xmzEXfYeFImGEYAEllyEoDpdDTtO));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void fyslregFjGmNAifofCnMWLWdFaUS()
	{
		lock (yEvFKPcQtZNLcjoAmptUZZiJzaCGA)
		{
			lock (DyzEBEFKANyovITviWkTxMBVMxfh)
			{
				MiscTools.Swap(ref yEvFKPcQtZNLcjoAmptUZZiJzaCGA, ref DyzEBEFKANyovITviWkTxMBVMxfh);
			}
		}
	}

	private void InliKslliiacZcuurbhdkimejwos()
	{
		if (rZKIrfnJnDaGxJtWRBcxlGGVNpIdb != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] zrXNuEIRjjYkIwcwtgXeiMDUkFVy = ZrXNuEIRjjYkIwcwtgXeiMDUkFVy;
			if (!VAakIUnGCZGIyrJPDRvPYeBxslus(zrXNuEIRjjYkIwcwtgXeiMDUkFVy))
			{
				return;
			}
			lock (DyzEBEFKANyovITviWkTxMBVMxfh)
			{
				DyzEBEFKANyovITviWkTxMBVMxfh.OxwFLUgEISQkFqpuDkIXkrYXqHNeb(zrXNuEIRjjYkIwcwtgXeiMDUkFVy, zrXNuEIRjjYkIwcwtgXeiMDUkFVy.Length);
			}
		}
		catch
		{
		}
	}

	private bool VAakIUnGCZGIyrJPDRvPYeBxslus(byte[] P_0)
	{
		switch (NQxSXNMmzQiazYonFispgOpCALVuA.sBZcNJvaKiKEsQRSZLoVuAhTqVuh(P_0))
		{
		case NVbYGTjyIoFkaXKVDdqlhebWGYkJ.giAuStDhnZLWodeMhsQUgNJyfUHBA.Success:
			return true;
		case NVbYGTjyIoFkaXKVDdqlhebWGYkJ.giAuStDhnZLWodeMhsQUgNJyfUHBA.Error:
			Thread.Sleep(500);
			break;
		case NVbYGTjyIoFkaXKVDdqlhebWGYkJ.giAuStDhnZLWodeMhsQUgNJyfUHBA.CriticalError:
			rZKIrfnJnDaGxJtWRBcxlGGVNpIdb = 1;
			break;
		}
		return false;
	}

	private bool XmdwNheMspbwfSWfXHGejpTnNfqdA()
	{
		if (rZKIrfnJnDaGxJtWRBcxlGGVNpIdb != 0)
		{
			if (rZKIrfnJnDaGxJtWRBcxlGGVNpIdb == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + qhCwOlpZrhVcAEwRijjtKmNicrHFA + "\" will not function.");
				rZKIrfnJnDaGxJtWRBcxlGGVNpIdb = 2;
				try
				{
					srfoahQfEyEmuHRWwVvTNQxXqPoAb.Stop(wait: false);
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
		caLKsdsvzxgZCeCAkXcaSvcHbAwG(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void vzgSkxoGVLxhSqoRjWcClLbbTRhH()
	{
		try
		{
			caLKsdsvzxgZCeCAkXcaSvcHbAwG(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void caLKsdsvzxgZCeCAkXcaSvcHbAwG(bool P_0)
	{
		if (dTLKWhSmQDJmWTpLFaHtfgcCcFVSA)
		{
			return;
		}
		if (P_0)
		{
			if (srfoahQfEyEmuHRWwVvTNQxXqPoAb != null)
			{
				srfoahQfEyEmuHRWwVvTNQxXqPoAb.Dispose();
			}
			if (NQxSXNMmzQiazYonFispgOpCALVuA != null)
			{
				NQxSXNMmzQiazYonFispgOpCALVuA.Dispose();
			}
		}
		dTLKWhSmQDJmWTpLFaHtfgcCcFVSA = true;
	}
}

using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class pcWYpYFkrPrEQTLnBvmiBsUAQqts : IDisposable
{
	public delegate void vqzNvMiRHmTbBjeWMXezVNxWaCxv(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int WzPMQonGXRyMTJdHjEmgEVIjLBfib = 512;

	private const int eirpgIiXYUiboanCEPuroCKXDEcEA = 250;

	private readonly vqzNvMiRHmTbBjeWMXezVNxWaCxv vrBGMikdHOPCMevyDcMndDiIOCzM;

	private readonly xgNwjoGvjRLepxLlpVshQmgSUfMw jWFcsspaIxhZiucNjmvdnqiIyybu;

	private readonly ThreadHelper ASPBIQvrIZNxdvsVYooLrqKRqZOD;

	private readonly int eHeHxhOTWmMwpqBylbCWJVZLqUdVA;

	private readonly int JMNezKpaAdzjJyJuDrEKDaqrhwHO;

	private readonly string CTkbhOOcWGeLVamnYmyllYYgTUzw;

	private readonly byte[] OrsMmClTUCkagODygGHZZfPmhKQJ;

	private readonly byte[] zklgilcxAKnzJnUSJHWoJVGAacpEb;

	private int XvwWCWMbCulWqBKcbxnjrVZNQzoI;

	private EVrvaKNCRqfFbcZrfjDphsNdAVkW AJNrWatPEwmprMcmOspUkijRTSoG;

	private EVrvaKNCRqfFbcZrfjDphsNdAVkW rLVkvbeibqnVayQHYCDVCpWHBtLIA;

	private bool DGhxnQfbxwZgNlsnfMqtRpxQgupj;

	public pcWYpYFkrPrEQTLnBvmiBsUAQqts(string P_0, int P_1, string P_2, vqzNvMiRHmTbBjeWMXezVNxWaCxv P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		JMNezKpaAdzjJyJuDrEKDaqrhwHO = P_1;
		if (JMNezKpaAdzjJyJuDrEKDaqrhwHO <= 0)
		{
			JMNezKpaAdzjJyJuDrEKDaqrhwHO = 512;
		}
		eHeHxhOTWmMwpqBylbCWJVZLqUdVA = P_1 + 8;
		CTkbhOOcWGeLVamnYmyllYYgTUzw = P_2;
		vrBGMikdHOPCMevyDcMndDiIOCzM = P_3;
		int num = eHeHxhOTWmMwpqBylbCWJVZLqUdVA * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			jWFcsspaIxhZiucNjmvdnqiIyybu = new xgNwjoGvjRLepxLlpVshQmgSUfMw(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			AJNrWatPEwmprMcmOspUkijRTSoG = new EVrvaKNCRqfFbcZrfjDphsNdAVkW(num);
			rLVkvbeibqnVayQHYCDVCpWHBtLIA = new EVrvaKNCRqfFbcZrfjDphsNdAVkW(num);
			OrsMmClTUCkagODygGHZZfPmhKQJ = new byte[eHeHxhOTWmMwpqBylbCWJVZLqUdVA];
			zklgilcxAKnzJnUSJHWoJVGAacpEb = new byte[eHeHxhOTWmMwpqBylbCWJVZLqUdVA];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			ASPBIQvrIZNxdvsVYooLrqKRqZOD = ThreadHelper.Create();
			ASPBIQvrIZNxdvsVYooLrqKRqZOD.ThreadUpdateEvent += wOPBZFeAJLyBSCCEBXslZvhcGPUJA;
			ASPBIQvrIZNxdvsVYooLrqKRqZOD.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void zhJycNkZfpURIvLoDaSXhvTZpxUoA()
	{
		try
		{
			if (zELyhMRdBYaPokFVhMZiCbKrXSYm())
			{
				return;
			}
			TVAhMPTzIpsZNWEIZQsIbUZtGZiK();
			int num = 0;
			byte[] orsMmClTUCkagODygGHZZfPmhKQJ = OrsMmClTUCkagODygGHZZfPmhKQJ;
			fixed (byte* ptr = orsMmClTUCkagODygGHZZfPmhKQJ)
			{
				while (AJNrWatPEwmprMcmOspUkijRTSoG.fExKLKYjIkNlOrFwJbpHibkZnRRYA(orsMmClTUCkagODygGHZZfPmhKQJ, eHeHxhOTWmMwpqBylbCWJVZLqUdVA) > 0)
				{
					vrBGMikdHOPCMevyDcMndDiIOCzM((IntPtr)ptr, JMNezKpaAdzjJyJuDrEKDaqrhwHO, 1, *(double*)(ptr + JMNezKpaAdzjJyJuDrEKDaqrhwHO));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void TVAhMPTzIpsZNWEIZQsIbUZtGZiK()
	{
		lock (AJNrWatPEwmprMcmOspUkijRTSoG)
		{
			lock (rLVkvbeibqnVayQHYCDVCpWHBtLIA)
			{
				MiscTools.Swap(ref AJNrWatPEwmprMcmOspUkijRTSoG, ref rLVkvbeibqnVayQHYCDVCpWHBtLIA);
			}
		}
	}

	private void wOPBZFeAJLyBSCCEBXslZvhcGPUJA()
	{
		if (XvwWCWMbCulWqBKcbxnjrVZNQzoI != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = zklgilcxAKnzJnUSJHWoJVGAacpEb;
			if (!dcEgZldSfioldfPtxTiPZfYlsKKJA(array))
			{
				return;
			}
			lock (rLVkvbeibqnVayQHYCDVCpWHBtLIA)
			{
				rLVkvbeibqnVayQHYCDVCpWHBtLIA.uRzjPkMqaceheDwJkIzkTVBCZCCCA(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool dcEgZldSfioldfPtxTiPZfYlsKKJA(byte[] P_0)
	{
		switch (jWFcsspaIxhZiucNjmvdnqiIyybu.IntkByEItJarlcuotJYXPCcDjFSKA(P_0))
		{
		case xgNwjoGvjRLepxLlpVshQmgSUfMw.KkmhrUuwGszvhHimRNvYNBQinolL.Success:
			return true;
		case xgNwjoGvjRLepxLlpVshQmgSUfMw.KkmhrUuwGszvhHimRNvYNBQinolL.Error:
			Thread.Sleep(500);
			break;
		case xgNwjoGvjRLepxLlpVshQmgSUfMw.KkmhrUuwGszvhHimRNvYNBQinolL.CriticalError:
			XvwWCWMbCulWqBKcbxnjrVZNQzoI = 1;
			break;
		}
		return false;
	}

	private bool zELyhMRdBYaPokFVhMZiCbKrXSYm()
	{
		if (XvwWCWMbCulWqBKcbxnjrVZNQzoI != 0)
		{
			if (XvwWCWMbCulWqBKcbxnjrVZNQzoI == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + CTkbhOOcWGeLVamnYmyllYYgTUzw + "\" will not function.");
				XvwWCWMbCulWqBKcbxnjrVZNQzoI = 2;
				try
				{
					ASPBIQvrIZNxdvsVYooLrqKRqZOD.Stop(wait: false);
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
		KtblfJNnGYrFWEHiGRMszXyZpAIp(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void JzAHpMPpsmwCTQjlLEXIIRmvlyVt()
	{
		try
		{
			KtblfJNnGYrFWEHiGRMszXyZpAIp(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void KtblfJNnGYrFWEHiGRMszXyZpAIp(bool P_0)
	{
		if (DGhxnQfbxwZgNlsnfMqtRpxQgupj)
		{
			return;
		}
		if (P_0)
		{
			if (ASPBIQvrIZNxdvsVYooLrqKRqZOD != null)
			{
				ASPBIQvrIZNxdvsVYooLrqKRqZOD.Dispose();
			}
			if (jWFcsspaIxhZiucNjmvdnqiIyybu != null)
			{
				jWFcsspaIxhZiucNjmvdnqiIyybu.Dispose();
			}
		}
		DGhxnQfbxwZgNlsnfMqtRpxQgupj = true;
	}
}

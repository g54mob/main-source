using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class bqNTaAkjoEdweZReSRZulbMmxSGf : IDisposable
{
	public delegate void pdmVqCNoYhMjfzTPHRKdlWliTWWj(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int YfIkIsArIOxRlBKEsVnipKKNClWJ = 512;

	private const int qWgIxMDGVREIOobNRJZtAVAxlRVm = 250;

	private readonly pdmVqCNoYhMjfzTPHRKdlWliTWWj vAIdyoTGSDodywqxMEhvBVqarNWbA;

	private readonly nnYVActHyYBSThdgoLUrqHycacvi niIgQkYhVmqmKmBMueGtjBkyNlOCb;

	private readonly ThreadHelper InSEtWGUgMGsNghzTQBPADuDlxbjc;

	private readonly int qxtFHvpaFhVQZkDpsitKruZnoRMp;

	private readonly int BhIWEGSJrwBSbmvhCfUIrreHbbgS;

	private readonly string MMfFBIhFFTFklcweRbPxGJSGATEpb;

	private readonly byte[] YdxAyYhMENBDIiErCndLIpVsIcnKc;

	private readonly byte[] vWiAxCIFMJYdeOVgApgglGrupiCD;

	private int BhxXyIxtFtnOERtpeUCvNzLndDBw;

	private ApaQDWoTItssTokgoNghFnZLeADU YwURBwAENhlLBYKbHUHECArnQUPS;

	private ApaQDWoTItssTokgoNghFnZLeADU tTWbHvHymfLuYcMONIoFhmEtgwarA;

	private bool RAazRKAEexTkznmscMnlfHhgOlQS;

	public bqNTaAkjoEdweZReSRZulbMmxSGf(string P_0, int P_1, string P_2, pdmVqCNoYhMjfzTPHRKdlWliTWWj P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		BhIWEGSJrwBSbmvhCfUIrreHbbgS = P_1;
		if (BhIWEGSJrwBSbmvhCfUIrreHbbgS <= 0)
		{
			BhIWEGSJrwBSbmvhCfUIrreHbbgS = 512;
		}
		qxtFHvpaFhVQZkDpsitKruZnoRMp = P_1 + 8;
		MMfFBIhFFTFklcweRbPxGJSGATEpb = P_2;
		vAIdyoTGSDodywqxMEhvBVqarNWbA = P_3;
		int num = qxtFHvpaFhVQZkDpsitKruZnoRMp * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			niIgQkYhVmqmKmBMueGtjBkyNlOCb = new nnYVActHyYBSThdgoLUrqHycacvi(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			YwURBwAENhlLBYKbHUHECArnQUPS = new ApaQDWoTItssTokgoNghFnZLeADU(num);
			tTWbHvHymfLuYcMONIoFhmEtgwarA = new ApaQDWoTItssTokgoNghFnZLeADU(num);
			YdxAyYhMENBDIiErCndLIpVsIcnKc = new byte[qxtFHvpaFhVQZkDpsitKruZnoRMp];
			vWiAxCIFMJYdeOVgApgglGrupiCD = new byte[qxtFHvpaFhVQZkDpsitKruZnoRMp];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			InSEtWGUgMGsNghzTQBPADuDlxbjc = ThreadHelper.Create();
			InSEtWGUgMGsNghzTQBPADuDlxbjc.ThreadUpdateEvent += sKgxDppKKSiaWULICVbMrlWhYbEb;
			InSEtWGUgMGsNghzTQBPADuDlxbjc.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void jUKIdXLawakcmtCzMGzRZtPdmwvm()
	{
		try
		{
			if (pREFMOgiKHmqSouIgFukcTYDRFrs())
			{
				return;
			}
			FGTceXkQDwSmdGeRAXXSJnNHdSPp();
			int num = 0;
			byte[] ydxAyYhMENBDIiErCndLIpVsIcnKc = YdxAyYhMENBDIiErCndLIpVsIcnKc;
			fixed (byte* ptr = ydxAyYhMENBDIiErCndLIpVsIcnKc)
			{
				while (YwURBwAENhlLBYKbHUHECArnQUPS.xMcxgYzPHnGNurktAUgBPBmhGumL(ydxAyYhMENBDIiErCndLIpVsIcnKc, qxtFHvpaFhVQZkDpsitKruZnoRMp) > 0)
				{
					vAIdyoTGSDodywqxMEhvBVqarNWbA((IntPtr)ptr, BhIWEGSJrwBSbmvhCfUIrreHbbgS, 1, *(double*)(ptr + BhIWEGSJrwBSbmvhCfUIrreHbbgS));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void FGTceXkQDwSmdGeRAXXSJnNHdSPp()
	{
		lock (YwURBwAENhlLBYKbHUHECArnQUPS)
		{
			lock (tTWbHvHymfLuYcMONIoFhmEtgwarA)
			{
				MiscTools.Swap(ref YwURBwAENhlLBYKbHUHECArnQUPS, ref tTWbHvHymfLuYcMONIoFhmEtgwarA);
			}
		}
	}

	private void sKgxDppKKSiaWULICVbMrlWhYbEb()
	{
		if (BhxXyIxtFtnOERtpeUCvNzLndDBw != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = vWiAxCIFMJYdeOVgApgglGrupiCD;
			if (!bfDffjzyalYsPZuouTZuTKVDBftb(array))
			{
				return;
			}
			lock (tTWbHvHymfLuYcMONIoFhmEtgwarA)
			{
				tTWbHvHymfLuYcMONIoFhmEtgwarA.cCqEdunWlncGOuTShQQodtTwsNlO(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool bfDffjzyalYsPZuouTZuTKVDBftb(byte[] P_0)
	{
		switch (niIgQkYhVmqmKmBMueGtjBkyNlOCb.MXybvyjxwMIQBsQzgZvPzXsboOjv(P_0))
		{
		case nnYVActHyYBSThdgoLUrqHycacvi.GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Success:
			return true;
		case nnYVActHyYBSThdgoLUrqHycacvi.GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.Error:
			Thread.Sleep(500);
			break;
		case nnYVActHyYBSThdgoLUrqHycacvi.GZlFTCHmVxbAXaLxEQyIUjUKzmGCA.CriticalError:
			BhxXyIxtFtnOERtpeUCvNzLndDBw = 1;
			break;
		}
		return false;
	}

	private bool pREFMOgiKHmqSouIgFukcTYDRFrs()
	{
		if (BhxXyIxtFtnOERtpeUCvNzLndDBw != 0)
		{
			if (BhxXyIxtFtnOERtpeUCvNzLndDBw == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + MMfFBIhFFTFklcweRbPxGJSGATEpb + "\" will not function.");
				BhxXyIxtFtnOERtpeUCvNzLndDBw = 2;
				try
				{
					InSEtWGUgMGsNghzTQBPADuDlxbjc.Stop(wait: false);
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
		YiyBfVuJFVeTgUmxRzseVjozNHdK(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void VHJcDAgAppldnCgqUxkAgMyJRrwU()
	{
		try
		{
			YiyBfVuJFVeTgUmxRzseVjozNHdK(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void YiyBfVuJFVeTgUmxRzseVjozNHdK(bool P_0)
	{
		if (RAazRKAEexTkznmscMnlfHhgOlQS)
		{
			return;
		}
		if (P_0)
		{
			if (InSEtWGUgMGsNghzTQBPADuDlxbjc != null)
			{
				InSEtWGUgMGsNghzTQBPADuDlxbjc.Dispose();
			}
			if (niIgQkYhVmqmKmBMueGtjBkyNlOCb != null)
			{
				niIgQkYhVmqmKmBMueGtjBkyNlOCb.Dispose();
			}
		}
		RAazRKAEexTkznmscMnlfHhgOlQS = true;
	}
}

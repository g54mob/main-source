using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class LuehvADKSgLvalhJAQshXNUmSML : IDisposable
{
	public delegate void KHXzxQPsnHbBXhupfTmyHudjVu(IntPtr reportPointer, int reportByteLength, int reportCount, float timestamp);

	private const int OzgOPtSGaSeqMKhGCDElXAVNNPZ = 512;

	private const int TgHBWyomGbyaXVPLQRWCpDsragw = 250;

	private readonly KHXzxQPsnHbBXhupfTmyHudjVu RWKgBRcQeGxrQbVcckAZRbNJvlm;

	private readonly NNtGhmCyIcTVHHhHsqmkUkyoQZe SGpnikQhRLHSashYVbxLzshKHTP;

	private readonly ThreadHelper tjbaiMrJifoIDiaaEAFkHcnphSvb;

	private readonly int WOxaFrpqdwbiOMLPZaqyDilrjPPu;

	private readonly int gcaUhlsfGNRBIChFtcwbZfyAwCo;

	private readonly string WqJtaJydLKfHMdBaTOkMfyaNjHV;

	private readonly byte[] LzFAaUqArGPmLCXbfZoFXvuQZCV;

	private readonly byte[] xSmfLMpfgOAsEzCghsSwYLpsMon;

	private int CYRttyEUKQeQxDQNchsaFUOvUnPF;

	private BTHrwIBgxFqazDintdmlgnJdIAF jTYDuCDXpPiJDRZpihyXatdclWNa;

	private BTHrwIBgxFqazDintdmlgnJdIAF WlreHYZrySDLntOkHBNIEoyMeMa;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	public LuehvADKSgLvalhJAQshXNUmSML(string hidDevicePath, int reportByteLength, string productName, KHXzxQPsnHbBXhupfTmyHudjVu processReportDelegate)
	{
		if (string.IsNullOrEmpty(hidDevicePath))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (processReportDelegate == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		gcaUhlsfGNRBIChFtcwbZfyAwCo = reportByteLength;
		if (gcaUhlsfGNRBIChFtcwbZfyAwCo <= 0)
		{
			gcaUhlsfGNRBIChFtcwbZfyAwCo = 512;
		}
		WOxaFrpqdwbiOMLPZaqyDilrjPPu = reportByteLength + 4;
		WqJtaJydLKfHMdBaTOkMfyaNjHV = productName;
		RWKgBRcQeGxrQbVcckAZRbNJvlm = processReportDelegate;
		int num = WOxaFrpqdwbiOMLPZaqyDilrjPPu * 25;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + productName + "\" will not function.");
			throw new Exception();
		}
		try
		{
			SGpnikQhRLHSashYVbxLzshKHTP = new NNtGhmCyIcTVHHhHsqmkUkyoQZe(hidDevicePath, reportByteLength, 250);
		}
		catch (Exception ex)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw ex;
		}
		try
		{
			jTYDuCDXpPiJDRZpihyXatdclWNa = new BTHrwIBgxFqazDintdmlgnJdIAF(num);
			WlreHYZrySDLntOkHBNIEoyMeMa = new BTHrwIBgxFqazDintdmlgnJdIAF(num);
			LzFAaUqArGPmLCXbfZoFXvuQZCV = new byte[WOxaFrpqdwbiOMLPZaqyDilrjPPu];
			xSmfLMpfgOAsEzCghsSwYLpsMon = new byte[WOxaFrpqdwbiOMLPZaqyDilrjPPu];
		}
		catch (Exception ex2)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw ex2;
		}
		try
		{
			tjbaiMrJifoIDiaaEAFkHcnphSvb = ThreadHelper.Create();
			tjbaiMrJifoIDiaaEAFkHcnphSvb.ThreadUpdateEvent += JSZvpcfgZVssNtfXMVqTmNXDSqR;
			tjbaiMrJifoIDiaaEAFkHcnphSvb.Start(false);
		}
		catch (Exception ex3)
		{
			Logger.LogError("Error creating thread. This device \"" + productName + "\" will not function.");
			throw ex3;
		}
	}

	public unsafe void OKHZGFMfxtklwLbZuCziRQFTDNac()
	{
		try
		{
			if (FGhsfRDLKSCdHVVsVvDRHMppfYG())
			{
				return;
			}
			KEVbCgKucLzqRvZFKfGOnnHgLaci();
			int num = 0;
			byte[] lzFAaUqArGPmLCXbfZoFXvuQZCV = LzFAaUqArGPmLCXbfZoFXvuQZCV;
			fixed (byte* ptr = lzFAaUqArGPmLCXbfZoFXvuQZCV)
			{
				while (jTYDuCDXpPiJDRZpihyXatdclWNa.NanoMDSNERLILwGbZOVIzaIWByQA(lzFAaUqArGPmLCXbfZoFXvuQZCV, WOxaFrpqdwbiOMLPZaqyDilrjPPu) > 0)
				{
					RWKgBRcQeGxrQbVcckAZRbNJvlm((IntPtr)ptr, gcaUhlsfGNRBIChFtcwbZfyAwCo, 1, *(float*)(ptr + gcaUhlsfGNRBIChFtcwbZfyAwCo));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void KEVbCgKucLzqRvZFKfGOnnHgLaci()
	{
		lock (jTYDuCDXpPiJDRZpihyXatdclWNa)
		{
			lock (WlreHYZrySDLntOkHBNIEoyMeMa)
			{
				MiscTools.Swap(ref jTYDuCDXpPiJDRZpihyXatdclWNa, ref WlreHYZrySDLntOkHBNIEoyMeMa);
			}
		}
	}

	private void JSZvpcfgZVssNtfXMVqTmNXDSqR()
	{
		if (CYRttyEUKQeQxDQNchsaFUOvUnPF != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = xSmfLMpfgOAsEzCghsSwYLpsMon;
			if (!xaZISERVzCWJoaXhLKwSllOpJUW(array))
			{
				return;
			}
			lock (WlreHYZrySDLntOkHBNIEoyMeMa)
			{
				WlreHYZrySDLntOkHBNIEoyMeMa.mszIJNECfxEuJZasPAYwzZDCgpx(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool xaZISERVzCWJoaXhLKwSllOpJUW(byte[] P_0)
	{
		switch (SGpnikQhRLHSashYVbxLzshKHTP.NanoMDSNERLILwGbZOVIzaIWByQA(P_0))
		{
		case NNtGhmCyIcTVHHhHsqmkUkyoQZe.HNFrmcuxsvlQCudJezJFkfgEVpb.mmVARMJeNgPzFhCEbPdQSlTtUNt:
			return true;
		case NNtGhmCyIcTVHHhHsqmkUkyoQZe.HNFrmcuxsvlQCudJezJFkfgEVpb.FWRVKWUtSLvoGvEHthzaKWOjYJH:
			Thread.Sleep(500);
			break;
		case NNtGhmCyIcTVHHhHsqmkUkyoQZe.HNFrmcuxsvlQCudJezJFkfgEVpb.PpIwuxfuETTZCOzlqbWdESbltdW:
			CYRttyEUKQeQxDQNchsaFUOvUnPF = 1;
			break;
		}
		return false;
	}

	private bool FGhsfRDLKSCdHVVsVvDRHMppfYG()
	{
		if (CYRttyEUKQeQxDQNchsaFUOvUnPF != 0)
		{
			if (CYRttyEUKQeQxDQNchsaFUOvUnPF == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + WqJtaJydLKfHMdBaTOkMfyaNjHV + "\" will not function.");
				CYRttyEUKQeQxDQNchsaFUOvUnPF = 2;
				try
				{
					tjbaiMrJifoIDiaaEAFkHcnphSvb.Stop(false);
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
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~LuehvADKSgLvalhJAQshXNUmSML()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return;
		}
		if (P_0)
		{
			if (tjbaiMrJifoIDiaaEAFkHcnphSvb != null)
			{
				tjbaiMrJifoIDiaaEAFkHcnphSvb.Dispose();
			}
			if (SGpnikQhRLHSashYVbxLzshKHTP != null)
			{
				SGpnikQhRLHSashYVbxLzshKHTP.Dispose();
			}
		}
		nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
	}
}

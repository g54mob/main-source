using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class XqGFuGckEYGIQizfBEHTyVwqRMe : IDisposable
{
	public delegate void JWPNtDSmLGFrfKmsMbazJkEixDn(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int EKAFqvvOKscNkNvBFSdHqCbPrGq = 512;

	private const int JBxokcRoOVTixCBfTbfcChSjUjZ = 250;

	private readonly JWPNtDSmLGFrfKmsMbazJkEixDn FCsRILVNSiDYucGpfaExiclHGoPt;

	private readonly VKZVtuhYIUkRvIbtnKBAjACkOxB AgHWHuduRlgcOtIuCLRzCiLMiAmc;

	private readonly ThreadHelper pxZsAIIeiXffxhtGRXzEPyDdJBG;

	private readonly int GRVSzjEzdSSHsFzzEUTIZfXfGQa;

	private readonly int mHYeutVlYdzsmXZlqACNuMKSkBV;

	private readonly string OxvcLFhBJwKckHyUKGIkDUCGJAmu;

	private readonly byte[] LavMuEXPfaYyjHtPePtxayVAPMu;

	private readonly byte[] vgGkDUMosykzkoAIkYYSpNViPJY;

	private int UjvVpgvhWqBpPAXxdfMIzYedKqo;

	private HrbEWQgpebVVqUNyRWFGLjblPkV hpoGvOiWbriEtAABbhUfUGNijVo;

	private HrbEWQgpebVVqUNyRWFGLjblPkV WyVpuKomMasCLyUyOjduhWEYFWN;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	public XqGFuGckEYGIQizfBEHTyVwqRMe(string hidDevicePath, int reportByteLength, string productName, JWPNtDSmLGFrfKmsMbazJkEixDn processReportDelegate)
	{
		if (string.IsNullOrEmpty(hidDevicePath))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (processReportDelegate == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		mHYeutVlYdzsmXZlqACNuMKSkBV = reportByteLength;
		if (mHYeutVlYdzsmXZlqACNuMKSkBV <= 0)
		{
			mHYeutVlYdzsmXZlqACNuMKSkBV = 512;
		}
		GRVSzjEzdSSHsFzzEUTIZfXfGQa = reportByteLength + 8;
		OxvcLFhBJwKckHyUKGIkDUCGJAmu = productName;
		FCsRILVNSiDYucGpfaExiclHGoPt = processReportDelegate;
		int num = GRVSzjEzdSSHsFzzEUTIZfXfGQa * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + productName + "\" will not function.");
			throw new Exception();
		}
		try
		{
			AgHWHuduRlgcOtIuCLRzCiLMiAmc = new VKZVtuhYIUkRvIbtnKBAjACkOxB(hidDevicePath, reportByteLength, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw;
		}
		try
		{
			hpoGvOiWbriEtAABbhUfUGNijVo = new HrbEWQgpebVVqUNyRWFGLjblPkV(num);
			WyVpuKomMasCLyUyOjduhWEYFWN = new HrbEWQgpebVVqUNyRWFGLjblPkV(num);
			LavMuEXPfaYyjHtPePtxayVAPMu = new byte[GRVSzjEzdSSHsFzzEUTIZfXfGQa];
			vgGkDUMosykzkoAIkYYSpNViPJY = new byte[GRVSzjEzdSSHsFzzEUTIZfXfGQa];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw;
		}
		try
		{
			pxZsAIIeiXffxhtGRXzEPyDdJBG = ThreadHelper.Create();
			pxZsAIIeiXffxhtGRXzEPyDdJBG.ThreadUpdateEvent += NGvIPyOvZluZfmopLHzfBsvLuRu;
			pxZsAIIeiXffxhtGRXzEPyDdJBG.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + productName + "\" will not function.");
			throw;
		}
	}

	public unsafe void CWncwVbJhTWISMonvIVEimpDcKXc()
	{
		try
		{
			if (RSZFbLuAokCpjOOXKvMtgPkjHjp())
			{
				return;
			}
			GCdByeJYkbLfbIHhHkegOJlggzFe();
			int num = 0;
			byte[] lavMuEXPfaYyjHtPePtxayVAPMu = LavMuEXPfaYyjHtPePtxayVAPMu;
			fixed (byte* ptr = lavMuEXPfaYyjHtPePtxayVAPMu)
			{
				while (hpoGvOiWbriEtAABbhUfUGNijVo.DTWqTxyQfjlbrIFGzfuUHiIHdt(lavMuEXPfaYyjHtPePtxayVAPMu, GRVSzjEzdSSHsFzzEUTIZfXfGQa) > 0)
				{
					FCsRILVNSiDYucGpfaExiclHGoPt((IntPtr)ptr, mHYeutVlYdzsmXZlqACNuMKSkBV, 1, *(double*)(ptr + mHYeutVlYdzsmXZlqACNuMKSkBV));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void GCdByeJYkbLfbIHhHkegOJlggzFe()
	{
		lock (hpoGvOiWbriEtAABbhUfUGNijVo)
		{
			lock (WyVpuKomMasCLyUyOjduhWEYFWN)
			{
				MiscTools.Swap(ref hpoGvOiWbriEtAABbhUfUGNijVo, ref WyVpuKomMasCLyUyOjduhWEYFWN);
			}
		}
	}

	private void NGvIPyOvZluZfmopLHzfBsvLuRu()
	{
		if (UjvVpgvhWqBpPAXxdfMIzYedKqo != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = vgGkDUMosykzkoAIkYYSpNViPJY;
			if (!zYdotGialobjKpHPOjcoGNodOGd(array))
			{
				return;
			}
			lock (WyVpuKomMasCLyUyOjduhWEYFWN)
			{
				WyVpuKomMasCLyUyOjduhWEYFWN.ujTUoJrkpPHtthAWMneMiOxOImEn(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool zYdotGialobjKpHPOjcoGNodOGd(byte[] P_0)
	{
		switch (AgHWHuduRlgcOtIuCLRzCiLMiAmc.DTWqTxyQfjlbrIFGzfuUHiIHdt(P_0))
		{
		case VKZVtuhYIUkRvIbtnKBAjACkOxB.ZDccNBdADAwvwuoiYFGISscbUcBW.upttnMmIHIUUzuVcmMNcpVfljKM:
			return true;
		case VKZVtuhYIUkRvIbtnKBAjACkOxB.ZDccNBdADAwvwuoiYFGISscbUcBW.HrxGpWgvKdROiCcbsQJYXnqnEDaA:
			Thread.Sleep(500);
			break;
		case VKZVtuhYIUkRvIbtnKBAjACkOxB.ZDccNBdADAwvwuoiYFGISscbUcBW.XmqAEbSiQvCuaTZZhJsLdYHrbeh:
			UjvVpgvhWqBpPAXxdfMIzYedKqo = 1;
			break;
		}
		return false;
	}

	private bool RSZFbLuAokCpjOOXKvMtgPkjHjp()
	{
		if (UjvVpgvhWqBpPAXxdfMIzYedKqo != 0)
		{
			if (UjvVpgvhWqBpPAXxdfMIzYedKqo == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + OxvcLFhBJwKckHyUKGIkDUCGJAmu + "\" will not function.");
				UjvVpgvhWqBpPAXxdfMIzYedKqo = 2;
				try
				{
					pxZsAIIeiXffxhtGRXzEPyDdJBG.Stop(wait: false);
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
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~XqGFuGckEYGIQizfBEHTyVwqRMe()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected virtual void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			return;
		}
		if (P_0)
		{
			if (pxZsAIIeiXffxhtGRXzEPyDdJBG != null)
			{
				pxZsAIIeiXffxhtGRXzEPyDdJBG.Dispose();
			}
			if (AgHWHuduRlgcOtIuCLRzCiLMiAmc != null)
			{
				AgHWHuduRlgcOtIuCLRzCiLMiAmc.Dispose();
			}
		}
		dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
	}
}

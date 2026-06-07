using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class UdbanHapcFOYbQpnojmuGFDpqJyZ : IDisposable
{
	public delegate void MJjQiPQmQeodkWbSJJjtBEBiAXeb(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int JuxCfymgcnAJHlRNyRBiPpEYcEi = 512;

	private const int QoSOKpIWcASVAsBraPFVrZxcLjB = 250;

	private readonly MJjQiPQmQeodkWbSJJjtBEBiAXeb WQNchYMtqfKDFWHfQdgQPcYAKsL;

	private readonly UfuslfcvaBAaWastUJehSfdbgYF NMajXfebrggpvFyefxcAzgQRKfc;

	private readonly ThreadHelper mkmmuLREzAzMCXWZqBwjgaloTtM;

	private readonly int PdiDWmPRoTRcLvrPleWhcyQiAes;

	private readonly int nqtGnuMVmasUTpDbHayaBDlVDNF;

	private readonly string JbSbiCEbMjoIJWYZxsLVlllUSem;

	private readonly byte[] MqSbUXINDbPqUpvFVDVWXSwDEMo;

	private readonly byte[] gvrzwXRVAbfZXKNAJgnpKKyfRLI;

	private int BTEelfonsxxtgqPjKtmlKuFyLqq;

	private AhIGwJhtRkfPmaiXDLmmxmUKsJmG wBFUuDfpNmegGuNFODgKlxyrVXa;

	private AhIGwJhtRkfPmaiXDLmmxmUKsJmG HMoUDHfzCvLicARQvmXNSpjPHPF;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public UdbanHapcFOYbQpnojmuGFDpqJyZ(string hidDevicePath, int reportByteLength, string productName, MJjQiPQmQeodkWbSJJjtBEBiAXeb processReportDelegate)
	{
		if (string.IsNullOrEmpty(hidDevicePath))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (processReportDelegate == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		nqtGnuMVmasUTpDbHayaBDlVDNF = reportByteLength;
		if (nqtGnuMVmasUTpDbHayaBDlVDNF <= 0)
		{
			nqtGnuMVmasUTpDbHayaBDlVDNF = 512;
		}
		PdiDWmPRoTRcLvrPleWhcyQiAes = reportByteLength + 8;
		JbSbiCEbMjoIJWYZxsLVlllUSem = productName;
		WQNchYMtqfKDFWHfQdgQPcYAKsL = processReportDelegate;
		int num = PdiDWmPRoTRcLvrPleWhcyQiAes * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + productName + "\" will not function.");
			throw new Exception();
		}
		try
		{
			NMajXfebrggpvFyefxcAzgQRKfc = new UfuslfcvaBAaWastUJehSfdbgYF(hidDevicePath, reportByteLength, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw;
		}
		try
		{
			wBFUuDfpNmegGuNFODgKlxyrVXa = new AhIGwJhtRkfPmaiXDLmmxmUKsJmG(num);
			HMoUDHfzCvLicARQvmXNSpjPHPF = new AhIGwJhtRkfPmaiXDLmmxmUKsJmG(num);
			MqSbUXINDbPqUpvFVDVWXSwDEMo = new byte[PdiDWmPRoTRcLvrPleWhcyQiAes];
			gvrzwXRVAbfZXKNAJgnpKKyfRLI = new byte[PdiDWmPRoTRcLvrPleWhcyQiAes];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw;
		}
		try
		{
			mkmmuLREzAzMCXWZqBwjgaloTtM = ThreadHelper.Create();
			mkmmuLREzAzMCXWZqBwjgaloTtM.ThreadUpdateEvent += GWCbbdPIhiDNAkQzqeBYraCCVNcS;
			mkmmuLREzAzMCXWZqBwjgaloTtM.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + productName + "\" will not function.");
			throw;
		}
	}

	public unsafe void RMEkOMsGFSFWbHqrAFftMTIKNIHO()
	{
		try
		{
			if (ONwgxYdtujJWKBqUfzNAMTicaVtF())
			{
				return;
			}
			DtIiYlYyIekXUchnstYTblWbhUT();
			int num = 0;
			byte[] mqSbUXINDbPqUpvFVDVWXSwDEMo = MqSbUXINDbPqUpvFVDVWXSwDEMo;
			fixed (byte* ptr = mqSbUXINDbPqUpvFVDVWXSwDEMo)
			{
				while (wBFUuDfpNmegGuNFODgKlxyrVXa.OyoZWUuiamgvSVRBhbJZhjZZxdr(mqSbUXINDbPqUpvFVDVWXSwDEMo, PdiDWmPRoTRcLvrPleWhcyQiAes) > 0)
				{
					WQNchYMtqfKDFWHfQdgQPcYAKsL((IntPtr)ptr, nqtGnuMVmasUTpDbHayaBDlVDNF, 1, *(double*)(ptr + nqtGnuMVmasUTpDbHayaBDlVDNF));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void DtIiYlYyIekXUchnstYTblWbhUT()
	{
		lock (wBFUuDfpNmegGuNFODgKlxyrVXa)
		{
			lock (HMoUDHfzCvLicARQvmXNSpjPHPF)
			{
				MiscTools.Swap(ref wBFUuDfpNmegGuNFODgKlxyrVXa, ref HMoUDHfzCvLicARQvmXNSpjPHPF);
			}
		}
	}

	private void GWCbbdPIhiDNAkQzqeBYraCCVNcS()
	{
		if (BTEelfonsxxtgqPjKtmlKuFyLqq != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = gvrzwXRVAbfZXKNAJgnpKKyfRLI;
			if (!usKyYPzKHdSvtZjXxhWJztBouGx(array))
			{
				return;
			}
			lock (HMoUDHfzCvLicARQvmXNSpjPHPF)
			{
				HMoUDHfzCvLicARQvmXNSpjPHPF.xwyOTGiXUEnQReUfdMBlfOwNgvM(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool usKyYPzKHdSvtZjXxhWJztBouGx(byte[] P_0)
	{
		switch (NMajXfebrggpvFyefxcAzgQRKfc.OyoZWUuiamgvSVRBhbJZhjZZxdr(P_0))
		{
		case UfuslfcvaBAaWastUJehSfdbgYF.lOZxstMQhXgHssEeWAsxHVPDhFFe.lbKFULdzfDWsACyUFlsLCGxoAxA:
			return true;
		case UfuslfcvaBAaWastUJehSfdbgYF.lOZxstMQhXgHssEeWAsxHVPDhFFe.AvMNaPumcgWmPOraZnuhCLouNeq:
			Thread.Sleep(500);
			break;
		case UfuslfcvaBAaWastUJehSfdbgYF.lOZxstMQhXgHssEeWAsxHVPDhFFe.SDVfikFnuiKeZnnTUaKoMwkyTef:
			BTEelfonsxxtgqPjKtmlKuFyLqq = 1;
			break;
		}
		return false;
	}

	private bool ONwgxYdtujJWKBqUfzNAMTicaVtF()
	{
		if (BTEelfonsxxtgqPjKtmlKuFyLqq != 0)
		{
			if (BTEelfonsxxtgqPjKtmlKuFyLqq == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + JbSbiCEbMjoIJWYZxsLVlllUSem + "\" will not function.");
				BTEelfonsxxtgqPjKtmlKuFyLqq = 2;
				try
				{
					mkmmuLREzAzMCXWZqBwjgaloTtM.Stop(wait: false);
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
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~UdbanHapcFOYbQpnojmuGFDpqJyZ()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected virtual void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return;
		}
		if (P_0)
		{
			if (mkmmuLREzAzMCXWZqBwjgaloTtM != null)
			{
				mkmmuLREzAzMCXWZqBwjgaloTtM.Dispose();
			}
			if (NMajXfebrggpvFyefxcAzgQRKfc != null)
			{
				NMajXfebrggpvFyefxcAzgQRKfc.Dispose();
			}
		}
		euujVPFzGztViWDbYvUutBvFQFP = true;
	}
}

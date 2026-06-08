using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class IwfScfutcScWDsyBFBthHolYIWd : IDisposable
{
	public delegate void RQcGvLCmAfXppBjLelJNWPKYrp(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int VbtDXWfcsgtNhBNhLbEtTeanuFn = 512;

	private const int SHWrZZDkwVOZaSxDRESInSHXcQW = 250;

	private readonly RQcGvLCmAfXppBjLelJNWPKYrp ExTxxcHGyeMbfuDLpjkBRTovhJM;

	private readonly QmmXwRrPsMGwaWyZpjTkGiVKEVE FGmeJZrbpniGPtcAWeiThvSiTLb;

	private readonly ThreadHelper irmdVrQGOFlqwdAuFYGyeAWFQiF;

	private readonly int BKqQsYMBXCDVfHaDYlEeyjCDJVr;

	private readonly int zxxcPQFXarVslPfPwjddeVHmiUQZ;

	private readonly string RhQcoRXdcskBpmqtIrKQlXldFal;

	private readonly byte[] QjYHglVELseaoDCliUMNTDEsFXbf;

	private readonly byte[] obnoTbUCSebfjuSmgTheSSEQgGRi;

	private int NAYKqVhdkeInOjUZjZtkQSxBYfv;

	private YnUerdIcJlqTUwUxiPxhDmaKHOjS avXMbhquHxCkqIhddOlVpmMKmUj;

	private YnUerdIcJlqTUwUxiPxhDmaKHOjS JgqXQvcHUeUmMmliIjCKOaTwCAMD;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	public IwfScfutcScWDsyBFBthHolYIWd(string hidDevicePath, int reportByteLength, string productName, RQcGvLCmAfXppBjLelJNWPKYrp processReportDelegate)
	{
		if (string.IsNullOrEmpty(hidDevicePath))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (processReportDelegate == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		zxxcPQFXarVslPfPwjddeVHmiUQZ = reportByteLength;
		if (zxxcPQFXarVslPfPwjddeVHmiUQZ <= 0)
		{
			zxxcPQFXarVslPfPwjddeVHmiUQZ = 512;
		}
		BKqQsYMBXCDVfHaDYlEeyjCDJVr = reportByteLength + 8;
		RhQcoRXdcskBpmqtIrKQlXldFal = productName;
		ExTxxcHGyeMbfuDLpjkBRTovhJM = processReportDelegate;
		int num = BKqQsYMBXCDVfHaDYlEeyjCDJVr * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + productName + "\" will not function.");
			throw new Exception();
		}
		try
		{
			FGmeJZrbpniGPtcAWeiThvSiTLb = new QmmXwRrPsMGwaWyZpjTkGiVKEVE(hidDevicePath, reportByteLength, 250);
		}
		catch (Exception ex)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw ex;
		}
		try
		{
			avXMbhquHxCkqIhddOlVpmMKmUj = new YnUerdIcJlqTUwUxiPxhDmaKHOjS(num);
			JgqXQvcHUeUmMmliIjCKOaTwCAMD = new YnUerdIcJlqTUwUxiPxhDmaKHOjS(num);
			QjYHglVELseaoDCliUMNTDEsFXbf = new byte[BKqQsYMBXCDVfHaDYlEeyjCDJVr];
			obnoTbUCSebfjuSmgTheSSEQgGRi = new byte[BKqQsYMBXCDVfHaDYlEeyjCDJVr];
		}
		catch (Exception ex2)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw ex2;
		}
		try
		{
			irmdVrQGOFlqwdAuFYGyeAWFQiF = ThreadHelper.Create();
			irmdVrQGOFlqwdAuFYGyeAWFQiF.ThreadUpdateEvent += OCYauBCLbvZTkaILZmGLmnynwEf;
			irmdVrQGOFlqwdAuFYGyeAWFQiF.Start(wait: false);
		}
		catch (Exception ex3)
		{
			Logger.LogError("Error creating thread. This device \"" + productName + "\" will not function.");
			throw ex3;
		}
	}

	public unsafe void FFYEDujhZPZIRSsDbLkeXQkxTZI()
	{
		try
		{
			if (SGwAcuccmiUAgAOySZEZTTUDbEiz())
			{
				return;
			}
			BZIFFXTTQxBteYeZZNnQlYmIyRG();
			int num = 0;
			byte[] qjYHglVELseaoDCliUMNTDEsFXbf = QjYHglVELseaoDCliUMNTDEsFXbf;
			fixed (byte* ptr = qjYHglVELseaoDCliUMNTDEsFXbf)
			{
				while (avXMbhquHxCkqIhddOlVpmMKmUj.AFeHJojxqfbjmBllWvAWerjcLiqH(qjYHglVELseaoDCliUMNTDEsFXbf, BKqQsYMBXCDVfHaDYlEeyjCDJVr) > 0)
				{
					ExTxxcHGyeMbfuDLpjkBRTovhJM((IntPtr)ptr, zxxcPQFXarVslPfPwjddeVHmiUQZ, 1, *(double*)(ptr + zxxcPQFXarVslPfPwjddeVHmiUQZ));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void BZIFFXTTQxBteYeZZNnQlYmIyRG()
	{
		lock (avXMbhquHxCkqIhddOlVpmMKmUj)
		{
			lock (JgqXQvcHUeUmMmliIjCKOaTwCAMD)
			{
				MiscTools.Swap(ref avXMbhquHxCkqIhddOlVpmMKmUj, ref JgqXQvcHUeUmMmliIjCKOaTwCAMD);
			}
		}
	}

	private void OCYauBCLbvZTkaILZmGLmnynwEf()
	{
		if (NAYKqVhdkeInOjUZjZtkQSxBYfv != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = obnoTbUCSebfjuSmgTheSSEQgGRi;
			if (!ilItLzcsBmrlLdcfELFItUjVDFm(array))
			{
				return;
			}
			lock (JgqXQvcHUeUmMmliIjCKOaTwCAMD)
			{
				JgqXQvcHUeUmMmliIjCKOaTwCAMD.pqcPIshdVNrBiKWuGFpklSuavkZ(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool ilItLzcsBmrlLdcfELFItUjVDFm(byte[] P_0)
	{
		switch (FGmeJZrbpniGPtcAWeiThvSiTLb.AFeHJojxqfbjmBllWvAWerjcLiqH(P_0))
		{
		case QmmXwRrPsMGwaWyZpjTkGiVKEVE.IQCdOsTGUemNxgADmVUYmoZptuZ.xiCSqbcCtIEKuyUvacFMSGcXNTJ:
			return true;
		case QmmXwRrPsMGwaWyZpjTkGiVKEVE.IQCdOsTGUemNxgADmVUYmoZptuZ.EKrIvDpebmQjWiBgJqqbKnReIbq:
			Thread.Sleep(500);
			break;
		case QmmXwRrPsMGwaWyZpjTkGiVKEVE.IQCdOsTGUemNxgADmVUYmoZptuZ.OKVKpAAgmttazZRhpVPrQlSLena:
			NAYKqVhdkeInOjUZjZtkQSxBYfv = 1;
			break;
		}
		return false;
	}

	private bool SGwAcuccmiUAgAOySZEZTTUDbEiz()
	{
		if (NAYKqVhdkeInOjUZjZtkQSxBYfv != 0)
		{
			if (NAYKqVhdkeInOjUZjZtkQSxBYfv == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + RhQcoRXdcskBpmqtIrKQlXldFal + "\" will not function.");
				NAYKqVhdkeInOjUZjZtkQSxBYfv = 2;
				try
				{
					irmdVrQGOFlqwdAuFYGyeAWFQiF.Stop(wait: false);
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
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~IwfScfutcScWDsyBFBthHolYIWd()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		if (P_0)
		{
			if (irmdVrQGOFlqwdAuFYGyeAWFQiF != null)
			{
				irmdVrQGOFlqwdAuFYGyeAWFQiF.Dispose();
			}
			if (FGmeJZrbpniGPtcAWeiThvSiTLb != null)
			{
				FGmeJZrbpniGPtcAWeiThvSiTLb.Dispose();
			}
		}
		inweGjIgYacXYohFlYRlpMFkgKMi = true;
	}
}

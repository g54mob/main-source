using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class XdImMmsuEaasjeIjrEabONAEGIX : IDisposable
{
	public delegate void DtNOuSNlxPOwZRmEpltYuGokfKsd(IntPtr reportPointer, int reportByteLength, int reportCount, float timestamp);

	private const int AAAFHNhtCIYjRKBJlvZzCGZpSDB = 512;

	private const int BOvHRSNbOxbQCCgjxaHUipoHCcm = 250;

	private readonly DtNOuSNlxPOwZRmEpltYuGokfKsd LqwSdbBOUWqoTcfzNmuVEoTlabeI;

	private readonly PzXskEjtOsMxKUJnFisgTUyOJxw UsHQyEzUPDuOljTwmddZgSrqNPZ;

	private readonly ThreadHelper pkFrzcGUmtiFKdBAvOBotYhXbCn;

	private readonly int YeBRGVMxfyhjBZQvycaivUfFcFT;

	private readonly int kxYeXXBTSXiABMVpWhkfaUkEsCsP;

	private readonly string YHtEuhFNXMbKXkXCmocUmoanfRXI;

	private readonly byte[] BPddXsdVxSsSUSPRMHTZfKhgFFXb;

	private readonly byte[] xUOawseWiEtHNQsUYxsyuRjOTQbP;

	private int MuhwGHjUoMLiGMxIBebiDEPPxEB;

	private XgfhmksxlThdyWjNKixlzEZZYFT nAahGckkbTQMYIcRVkgJsYxMOUN;

	private XgfhmksxlThdyWjNKixlzEZZYFT QMRQvyglkOAdmmqOiBhGVqaaOKu;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public XdImMmsuEaasjeIjrEabONAEGIX(string hidDevicePath, int reportByteLength, string productName, DtNOuSNlxPOwZRmEpltYuGokfKsd processReportDelegate)
	{
		if (string.IsNullOrEmpty(hidDevicePath))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (processReportDelegate == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		kxYeXXBTSXiABMVpWhkfaUkEsCsP = reportByteLength;
		if (kxYeXXBTSXiABMVpWhkfaUkEsCsP <= 0)
		{
			kxYeXXBTSXiABMVpWhkfaUkEsCsP = 512;
		}
		YeBRGVMxfyhjBZQvycaivUfFcFT = reportByteLength + 4;
		YHtEuhFNXMbKXkXCmocUmoanfRXI = productName;
		LqwSdbBOUWqoTcfzNmuVEoTlabeI = processReportDelegate;
		int num = YeBRGVMxfyhjBZQvycaivUfFcFT * 25;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + productName + "\" will not function.");
			throw new Exception();
		}
		try
		{
			UsHQyEzUPDuOljTwmddZgSrqNPZ = new PzXskEjtOsMxKUJnFisgTUyOJxw(hidDevicePath, reportByteLength, 250);
		}
		catch (Exception ex)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw ex;
		}
		try
		{
			nAahGckkbTQMYIcRVkgJsYxMOUN = new XgfhmksxlThdyWjNKixlzEZZYFT(num);
			QMRQvyglkOAdmmqOiBhGVqaaOKu = new XgfhmksxlThdyWjNKixlzEZZYFT(num);
			BPddXsdVxSsSUSPRMHTZfKhgFFXb = new byte[YeBRGVMxfyhjBZQvycaivUfFcFT];
			xUOawseWiEtHNQsUYxsyuRjOTQbP = new byte[YeBRGVMxfyhjBZQvycaivUfFcFT];
		}
		catch (Exception ex2)
		{
			Logger.LogError("Out of memory. This device \"" + productName + "\" will not function.");
			throw ex2;
		}
		try
		{
			pkFrzcGUmtiFKdBAvOBotYhXbCn = ThreadHelper.Create();
			pkFrzcGUmtiFKdBAvOBotYhXbCn.ThreadUpdateEvent += VVbBqMUVXFFvYcoldZTHutTtVAZV;
			pkFrzcGUmtiFKdBAvOBotYhXbCn.Start(false);
		}
		catch (Exception ex3)
		{
			Logger.LogError("Error creating thread. This device \"" + productName + "\" will not function.");
			throw ex3;
		}
	}

	public unsafe void EhlPnfprjfkehAbDLrDcQKRlXmc()
	{
		try
		{
			if (HiDburkpQMPuMEJUawZXGOpTwUU())
			{
				return;
			}
			QdNTGeJuZmzEvYdtdMOquZKIiuf();
			int num = 0;
			byte[] bPddXsdVxSsSUSPRMHTZfKhgFFXb = BPddXsdVxSsSUSPRMHTZfKhgFFXb;
			fixed (byte* ptr = bPddXsdVxSsSUSPRMHTZfKhgFFXb)
			{
				while (nAahGckkbTQMYIcRVkgJsYxMOUN.BzRDvjvAQHKNUfdBiARKBsCcKkSL(bPddXsdVxSsSUSPRMHTZfKhgFFXb, YeBRGVMxfyhjBZQvycaivUfFcFT) > 0)
				{
					LqwSdbBOUWqoTcfzNmuVEoTlabeI((IntPtr)ptr, kxYeXXBTSXiABMVpWhkfaUkEsCsP, 1, *(float*)(ptr + kxYeXXBTSXiABMVpWhkfaUkEsCsP));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void QdNTGeJuZmzEvYdtdMOquZKIiuf()
	{
		lock (nAahGckkbTQMYIcRVkgJsYxMOUN)
		{
			lock (QMRQvyglkOAdmmqOiBhGVqaaOKu)
			{
				MiscTools.Swap(ref nAahGckkbTQMYIcRVkgJsYxMOUN, ref QMRQvyglkOAdmmqOiBhGVqaaOKu);
			}
		}
	}

	private void VVbBqMUVXFFvYcoldZTHutTtVAZV()
	{
		if (MuhwGHjUoMLiGMxIBebiDEPPxEB != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] array = xUOawseWiEtHNQsUYxsyuRjOTQbP;
			if (!hmfFjswMlQXPtbXFcGEEaJSXgFI(array))
			{
				return;
			}
			lock (QMRQvyglkOAdmmqOiBhGVqaaOKu)
			{
				QMRQvyglkOAdmmqOiBhGVqaaOKu.uwRrXbrytlKXYWIOmlUkwmZqEzx(array, array.Length);
			}
		}
		catch
		{
		}
	}

	private bool hmfFjswMlQXPtbXFcGEEaJSXgFI(byte[] P_0)
	{
		switch (UsHQyEzUPDuOljTwmddZgSrqNPZ.BzRDvjvAQHKNUfdBiARKBsCcKkSL(P_0))
		{
		case PzXskEjtOsMxKUJnFisgTUyOJxw.CECgeRugmDBxOeMGrMbkPQKXGIF.oBpsGyqHJqGwGwOgINlQTbBFqRf:
			return true;
		case PzXskEjtOsMxKUJnFisgTUyOJxw.CECgeRugmDBxOeMGrMbkPQKXGIF.LbxGOspuQJicPsndOHdoFgIBrOT:
			Thread.Sleep(500);
			break;
		case PzXskEjtOsMxKUJnFisgTUyOJxw.CECgeRugmDBxOeMGrMbkPQKXGIF.NXkzBMMIVNOJpVVBDOlEZnGJfcS:
			MuhwGHjUoMLiGMxIBebiDEPPxEB = 1;
			break;
		}
		return false;
	}

	private bool HiDburkpQMPuMEJUawZXGOpTwUU()
	{
		if (MuhwGHjUoMLiGMxIBebiDEPPxEB != 0)
		{
			if (MuhwGHjUoMLiGMxIBebiDEPPxEB == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + YHtEuhFNXMbKXkXCmocUmoanfRXI + "\" will not function.");
				MuhwGHjUoMLiGMxIBebiDEPPxEB = 2;
				try
				{
					pkFrzcGUmtiFKdBAvOBotYhXbCn.Stop(false);
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
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~XdImMmsuEaasjeIjrEabONAEGIX()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		if (P_0)
		{
			if (pkFrzcGUmtiFKdBAvOBotYhXbCn != null)
			{
				pkFrzcGUmtiFKdBAvOBotYhXbCn.Dispose();
			}
			if (UsHQyEzUPDuOljTwmddZgSrqNPZ != null)
			{
				UsHQyEzUPDuOljTwmddZgSrqNPZ.Dispose();
			}
		}
		nNxUslIcGUpqKgpPZYhuimcvWyC = true;
	}
}

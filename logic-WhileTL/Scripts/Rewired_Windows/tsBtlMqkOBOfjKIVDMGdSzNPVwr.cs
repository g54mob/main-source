using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class tsBtlMqkOBOfjKIVDMGdSzNPVwr : IDisposable
{
	public delegate void doLdzxnIAneriLodOZEBvQAFIpmV(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);

	private const int aquQGOLDamwRBGyoNInOhKsqxYiu = 512;

	private const int ryTAOJjVeHQHIBZIVbsdJzRMjMBi = 250;

	private readonly doLdzxnIAneriLodOZEBvQAFIpmV rkEhmoxRcimIJfHWhXIotGkmUaNn;

	private readonly vtflDHJsIEycWTAKjEbPucBFQSXF oyfdpPVwdpZsxciVAoRyRqIliUsx;

	private readonly ThreadHelper DCpIopHmGZhjMikhGDdRfIQTMRCMc;

	private readonly int gxhgHIguZIEXDdKWjWEHpKAaAKssB;

	private readonly int QnkRYQhistToVIUAePCGxLBzfTRBA;

	private readonly string maDWdkngdmIyLblbEcOxBPVwLMqLA;

	private readonly byte[] dWZLYdhrRqriMYruiKjybMQnYuwL;

	private readonly byte[] NPaNzrmVAaFxBtrhafKDwyQLTxCL;

	private int wsVhWTXqiwbIeVxQlGAXiczKekoO;

	private xVZwRfIZmhFLiBymkMcWQqrSZgoh ZlIcmlMePlbsSLWopVUsHRKJGPoW;

	private xVZwRfIZmhFLiBymkMcWQqrSZgoh gOdVhoCKRoiwMprGQttTkBgtXXlB;

	private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

	public tsBtlMqkOBOfjKIVDMGdSzNPVwr(string P_0, int P_1, string P_2, doLdzxnIAneriLodOZEBvQAFIpmV P_3)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		QnkRYQhistToVIUAePCGxLBzfTRBA = P_1;
		if (QnkRYQhistToVIUAePCGxLBzfTRBA <= 0)
		{
			QnkRYQhistToVIUAePCGxLBzfTRBA = 512;
		}
		gxhgHIguZIEXDdKWjWEHpKAaAKssB = P_1 + 8;
		maDWdkngdmIyLblbEcOxBPVwLMqLA = P_2;
		rkEhmoxRcimIJfHWhXIotGkmUaNn = P_3;
		int num = gxhgHIguZIEXDdKWjWEHpKAaAKssB * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + P_2 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			oyfdpPVwdpZsxciVAoRyRqIliUsx = new vtflDHJsIEycWTAKjEbPucBFQSXF(P_0, P_1, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			ZlIcmlMePlbsSLWopVUsHRKJGPoW = new xVZwRfIZmhFLiBymkMcWQqrSZgoh(num);
			gOdVhoCKRoiwMprGQttTkBgtXXlB = new xVZwRfIZmhFLiBymkMcWQqrSZgoh(num);
			dWZLYdhrRqriMYruiKjybMQnYuwL = new byte[gxhgHIguZIEXDdKWjWEHpKAaAKssB];
			NPaNzrmVAaFxBtrhafKDwyQLTxCL = new byte[gxhgHIguZIEXDdKWjWEHpKAaAKssB];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + P_2 + "\" will not function.");
			throw;
		}
		try
		{
			DCpIopHmGZhjMikhGDdRfIQTMRCMc = ThreadHelper.Create();
			DCpIopHmGZhjMikhGDdRfIQTMRCMc.ThreadUpdateEvent += bqNOfByhjpBZKhpOZchaNGigBVgIA;
			DCpIopHmGZhjMikhGDdRfIQTMRCMc.Start(wait: false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + P_2 + "\" will not function.");
			throw;
		}
	}

	public unsafe void cmTGFsRmXJEFbLoGhVUXbOoqUnNg()
	{
		try
		{
			if (jptntqSyNcWaWBFbGrJwzMEUVZpD())
			{
				return;
			}
			yFHAoXlOAdBHSDTMTaZvDrkNhGZH();
			int num = 0;
			byte[] array = dWZLYdhrRqriMYruiKjybMQnYuwL;
			fixed (byte* ptr = array)
			{
				while (ZlIcmlMePlbsSLWopVUsHRKJGPoW.lpzCMyRwfnpZCqiMQhipRjGrjZfC(array, gxhgHIguZIEXDdKWjWEHpKAaAKssB) > 0)
				{
					rkEhmoxRcimIJfHWhXIotGkmUaNn((IntPtr)ptr, QnkRYQhistToVIUAePCGxLBzfTRBA, 1, *(double*)(ptr + QnkRYQhistToVIUAePCGxLBzfTRBA));
					num++;
				}
			}
		}
		catch
		{
		}
	}

	private void yFHAoXlOAdBHSDTMTaZvDrkNhGZH()
	{
		lock (ZlIcmlMePlbsSLWopVUsHRKJGPoW)
		{
			lock (gOdVhoCKRoiwMprGQttTkBgtXXlB)
			{
				MiscTools.Swap(ref ZlIcmlMePlbsSLWopVUsHRKJGPoW, ref gOdVhoCKRoiwMprGQttTkBgtXXlB);
			}
		}
	}

	private void bqNOfByhjpBZKhpOZchaNGigBVgIA()
	{
		if (wsVhWTXqiwbIeVxQlGAXiczKekoO != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] nPaNzrmVAaFxBtrhafKDwyQLTxCL = NPaNzrmVAaFxBtrhafKDwyQLTxCL;
			if (!ZNPQpQOJqXzdKqoAMubdHrDIItOc(nPaNzrmVAaFxBtrhafKDwyQLTxCL))
			{
				return;
			}
			lock (gOdVhoCKRoiwMprGQttTkBgtXXlB)
			{
				gOdVhoCKRoiwMprGQttTkBgtXXlB.EGngQqDBRXlpYmNfKVeBqXohueYWA(nPaNzrmVAaFxBtrhafKDwyQLTxCL, nPaNzrmVAaFxBtrhafKDwyQLTxCL.Length);
			}
		}
		catch
		{
		}
	}

	private bool ZNPQpQOJqXzdKqoAMubdHrDIItOc(byte[] P_0)
	{
		switch (oyfdpPVwdpZsxciVAoRyRqIliUsx.lpzCMyRwfnpZCqiMQhipRjGrjZfC(P_0))
		{
		case vtflDHJsIEycWTAKjEbPucBFQSXF.TjecpYQftmnOMpIEpGEZfqoayxlJ.Success:
			return true;
		case vtflDHJsIEycWTAKjEbPucBFQSXF.TjecpYQftmnOMpIEpGEZfqoayxlJ.Error:
			Thread.Sleep(500);
			break;
		case vtflDHJsIEycWTAKjEbPucBFQSXF.TjecpYQftmnOMpIEpGEZfqoayxlJ.CriticalError:
			wsVhWTXqiwbIeVxQlGAXiczKekoO = 1;
			break;
		}
		return false;
	}

	private bool jptntqSyNcWaWBFbGrJwzMEUVZpD()
	{
		if (wsVhWTXqiwbIeVxQlGAXiczKekoO != 0)
		{
			if (wsVhWTXqiwbIeVxQlGAXiczKekoO == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + maDWdkngdmIyLblbEcOxBPVwLMqLA + "\" will not function.");
				wsVhWTXqiwbIeVxQlGAXiczKekoO = 2;
				try
				{
					DCpIopHmGZhjMikhGDdRfIQTMRCMc.Stop(wait: false);
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
		hIlanWXkrCYfgvCyascUuCUOCBcL(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
	{
		try
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
	{
		if (TExNvhkEWsBWipIUjadCDaTpNNDG)
		{
			return;
		}
		if (P_0)
		{
			if (DCpIopHmGZhjMikhGDdRfIQTMRCMc != null)
			{
				DCpIopHmGZhjMikhGDdRfIQTMRCMc.Dispose();
			}
			if (oyfdpPVwdpZsxciVAoRyRqIliUsx != null)
			{
				oyfdpPVwdpZsxciVAoRyRqIliUsx.Dispose();
			}
		}
		TExNvhkEWsBWipIUjadCDaTpNNDG = true;
	}
}

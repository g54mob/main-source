using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class ZXuymswIrYJxBfAZaYgHcxQnsDA : IDisposable
{
	private class joPnHEcKJOELCGSgCxILemmKNcxU
	{
		public int scWElYFnNZSpdvuVTBtGlgtUKbGa;

		public int hUwTEJiTTYCEmBhvJGYVudCpIpve;

		public uint iaglYrQnRgNejmCemARfCJNLcaO;

		public object ITNAyjiIdCLVSdzMuGWXZQQZJNZ;

		public void uWiFSgYCiROiIGGpgcpFqrNJeRm(int P_0, int P_1, uint P_2, object P_3)
		{
			scWElYFnNZSpdvuVTBtGlgtUKbGa = P_0;
			hUwTEJiTTYCEmBhvJGYVudCpIpve = P_1;
			iaglYrQnRgNejmCemARfCJNLcaO = P_2;
			ITNAyjiIdCLVSdzMuGWXZQQZJNZ = P_3;
		}

		public void ibajyEOvcZaAVvqbaVIEPkwcIqx()
		{
			ITNAyjiIdCLVSdzMuGWXZQQZJNZ = null;
		}
	}

	private YnUerdIcJlqTUwUxiPxhDmaKHOjS EAkChchgpneGPakFUTPVByHUjQB;

	private ObjectPool<joPnHEcKJOELCGSgCxILemmKNcxU> pULXUihImJyGMYomoCqqAjClKHNB;

	private Queue<joPnHEcKJOELCGSgCxILemmKNcxU> CjrOBzdFWnMVXYqzCgIRjpInCtEs;

	private Action<object> RgoEesEMOUcwLQuiCoYNnZxzjND;

	private bool inweGjIgYacXYohFlYRlpMFkgKMi;

	[CompilerGenerated]
	private static Func<joPnHEcKJOELCGSgCxILemmKNcxU> JyyGjIsClJZInuqDGBgmToehEhd;

	[CompilerGenerated]
	private static Action<joPnHEcKJOELCGSgCxILemmKNcxU> RqjDagMFkwiNRGhaYIDiBSMEOtcK;

	public bool HasItems => zsLcGCXMkiYhqjOuICZbsjWtWja();

	public ZXuymswIrYJxBfAZaYgHcxQnsDA(int byteCapacity, int startingQueueSize, Action<object> lostCustomDataDisposalDelegate = null)
	{
		if (byteCapacity <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		EAkChchgpneGPakFUTPVByHUjQB = new YnUerdIcJlqTUwUxiPxhDmaKHOjS(byteCapacity);
		pULXUihImJyGMYomoCqqAjClKHNB = new ObjectPool<joPnHEcKJOELCGSgCxILemmKNcxU>(startingQueueSize, () => new joPnHEcKJOELCGSgCxILemmKNcxU(), delegate(joPnHEcKJOELCGSgCxILemmKNcxU P_0)
		{
			P_0.ibajyEOvcZaAVvqbaVIEPkwcIqx();
		});
		CjrOBzdFWnMVXYqzCgIRjpInCtEs = new Queue<joPnHEcKJOELCGSgCxILemmKNcxU>(startingQueueSize);
		RgoEesEMOUcwLQuiCoYNnZxzjND = lostCustomDataDisposalDelegate;
	}

	public unsafe bool LgoJHLCBitFthTodNHJlYroGYaX(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		int num2;
		uint num3;
		int num = EAkChchgpneGPakFUTPVByHUjQB.pqcPIshdVNrBiKWuGFpklSuavkZ(P_0, P_1, P_1, out num2, out num3);
		if (num < P_1)
		{
			return false;
		}
		joPnHEcKJOELCGSgCxILemmKNcxU joPnHEcKJOELCGSgCxILemmKNcxU2 = pULXUihImJyGMYomoCqqAjClKHNB.Get();
		joPnHEcKJOELCGSgCxILemmKNcxU2.uWiFSgYCiROiIGGpgcpFqrNJeRm(num2, P_1, num3, P_2);
		CjrOBzdFWnMVXYqzCgIRjpInCtEs.Enqueue(joPnHEcKJOELCGSgCxILemmKNcxU2);
		return true;
	}

	public unsafe bool LgoJHLCBitFthTodNHJlYroGYaX(byte* P_0, int P_1)
	{
		return LgoJHLCBitFthTodNHJlYroGYaX(P_0, P_1, null);
	}

	public unsafe bool LgoJHLCBitFthTodNHJlYroGYaX(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return LgoJHLCBitFthTodNHJlYroGYaX((byte*)(void*)P_0, P_1, P_2);
	}

	public bool LgoJHLCBitFthTodNHJlYroGYaX(IntPtr P_0, int P_1)
	{
		return LgoJHLCBitFthTodNHJlYroGYaX(P_0, P_1, null);
	}

	public unsafe bool LgoJHLCBitFthTodNHJlYroGYaX(byte[] P_0, int P_1, object P_2, int P_3 = 0)
	{
		if (P_0 == null || P_1 > P_0.Length)
		{
			return false;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_3 + P_1 > P_0.Length)
		{
			return false;
		}
		fixed (byte* ptr = P_0)
		{
			byte* ptr2 = ptr + P_3;
			return LgoJHLCBitFthTodNHJlYroGYaX(ptr2, P_1, P_2);
		}
	}

	public bool LgoJHLCBitFthTodNHJlYroGYaX(byte[] P_0, int P_1, int P_2 = 0)
	{
		return LgoJHLCBitFthTodNHJlYroGYaX(P_0, P_1, null, P_2);
	}

	public unsafe int yoExZBCcxleFYRiLKAdquVTXGEb(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		joPnHEcKJOELCGSgCxILemmKNcxU joPnHEcKJOELCGSgCxILemmKNcxU2 = SfWLDFMwuenhgtJIDfDdYYunmkp(false);
		if (joPnHEcKJOELCGSgCxILemmKNcxU2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < joPnHEcKJOELCGSgCxILemmKNcxU2.hUwTEJiTTYCEmBhvJGYVudCpIpve)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = EAkChchgpneGPakFUTPVByHUjQB.rYbXKtmIcQfPnKoenkNgjULYOFV(P_0, P_1, joPnHEcKJOELCGSgCxILemmKNcxU2.hUwTEJiTTYCEmBhvJGYVudCpIpve, joPnHEcKJOELCGSgCxILemmKNcxU2.scWElYFnNZSpdvuVTBtGlgtUKbGa);
		if (num != joPnHEcKJOELCGSgCxILemmKNcxU2.hUwTEJiTTYCEmBhvJGYVudCpIpve)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = joPnHEcKJOELCGSgCxILemmKNcxU2.ITNAyjiIdCLVSdzMuGWXZQQZJNZ;
		return num;
	}

	public unsafe int yoExZBCcxleFYRiLKAdquVTXGEb(byte* P_0, int P_1)
	{
		object obj;
		return yoExZBCcxleFYRiLKAdquVTXGEb(P_0, P_1, out obj);
	}

	public unsafe int yoExZBCcxleFYRiLKAdquVTXGEb(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return yoExZBCcxleFYRiLKAdquVTXGEb((byte*)(void*)P_0, P_1, out P_2);
	}

	public int yoExZBCcxleFYRiLKAdquVTXGEb(IntPtr P_0, int P_1)
	{
		object obj;
		return yoExZBCcxleFYRiLKAdquVTXGEb(P_0, P_1, out obj);
	}

	public unsafe int yoExZBCcxleFYRiLKAdquVTXGEb(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return yoExZBCcxleFYRiLKAdquVTXGEb(ptr, P_0.Length, out P_1);
		}
	}

	public int yoExZBCcxleFYRiLKAdquVTXGEb(byte[] P_0)
	{
		object obj;
		return yoExZBCcxleFYRiLKAdquVTXGEb(P_0, out obj);
	}

	public int RKQrjVBmbYYlhNtoElroXcsPBTO()
	{
		return SfWLDFMwuenhgtJIDfDdYYunmkp(false)?.hUwTEJiTTYCEmBhvJGYVudCpIpve ?? (-1);
	}

	public unsafe int QddhAWKIUgtyuLearLugGtROnie(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		joPnHEcKJOELCGSgCxILemmKNcxU joPnHEcKJOELCGSgCxILemmKNcxU2 = SfWLDFMwuenhgtJIDfDdYYunmkp(true);
		if (joPnHEcKJOELCGSgCxILemmKNcxU2 == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < joPnHEcKJOELCGSgCxILemmKNcxU2.hUwTEJiTTYCEmBhvJGYVudCpIpve)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			zeifCMFjumnPWxazwPulyUEbhfm(joPnHEcKJOELCGSgCxILemmKNcxU2, true);
			return -1;
		}
		int num = EAkChchgpneGPakFUTPVByHUjQB.rYbXKtmIcQfPnKoenkNgjULYOFV(P_0, P_1, joPnHEcKJOELCGSgCxILemmKNcxU2.hUwTEJiTTYCEmBhvJGYVudCpIpve, joPnHEcKJOELCGSgCxILemmKNcxU2.scWElYFnNZSpdvuVTBtGlgtUKbGa);
		if (num != joPnHEcKJOELCGSgCxILemmKNcxU2.hUwTEJiTTYCEmBhvJGYVudCpIpve)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			zeifCMFjumnPWxazwPulyUEbhfm(joPnHEcKJOELCGSgCxILemmKNcxU2, true);
			return -1;
		}
		P_2 = joPnHEcKJOELCGSgCxILemmKNcxU2.ITNAyjiIdCLVSdzMuGWXZQQZJNZ;
		zeifCMFjumnPWxazwPulyUEbhfm(joPnHEcKJOELCGSgCxILemmKNcxU2, false);
		return num;
	}

	public unsafe int QddhAWKIUgtyuLearLugGtROnie(byte* P_0, int P_1)
	{
		object obj;
		return QddhAWKIUgtyuLearLugGtROnie(P_0, P_1, out obj);
	}

	public unsafe int QddhAWKIUgtyuLearLugGtROnie(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return QddhAWKIUgtyuLearLugGtROnie((byte*)(void*)P_0, P_1, out P_2);
	}

	public int QddhAWKIUgtyuLearLugGtROnie(IntPtr P_0, int P_1)
	{
		object obj;
		return QddhAWKIUgtyuLearLugGtROnie(P_0, P_1, out obj);
	}

	public unsafe int QddhAWKIUgtyuLearLugGtROnie(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return QddhAWKIUgtyuLearLugGtROnie(ptr, P_0.Length, out P_1);
		}
	}

	public int QddhAWKIUgtyuLearLugGtROnie(byte[] P_0)
	{
		object obj;
		return QddhAWKIUgtyuLearLugGtROnie(P_0, out obj);
	}

	public void VxWYhSWcyHtpXhSDbelOvWQxsme()
	{
		EAkChchgpneGPakFUTPVByHUjQB.VxWYhSWcyHtpXhSDbelOvWQxsme();
		while (CjrOBzdFWnMVXYqzCgIRjpInCtEs.Count > 0)
		{
			zeifCMFjumnPWxazwPulyUEbhfm(CjrOBzdFWnMVXYqzCgIRjpInCtEs.Dequeue(), true);
		}
	}

	private joPnHEcKJOELCGSgCxILemmKNcxU SfWLDFMwuenhgtJIDfDdYYunmkp(bool P_0)
	{
		while (CjrOBzdFWnMVXYqzCgIRjpInCtEs.Count > 0)
		{
			joPnHEcKJOELCGSgCxILemmKNcxU joPnHEcKJOELCGSgCxILemmKNcxU2 = (P_0 ? CjrOBzdFWnMVXYqzCgIRjpInCtEs.Dequeue() : CjrOBzdFWnMVXYqzCgIRjpInCtEs.Peek());
			if (EAkChchgpneGPakFUTPVByHUjQB.ckbPgbaOEagjXFRelDQXyZclxuj(joPnHEcKJOELCGSgCxILemmKNcxU2.scWElYFnNZSpdvuVTBtGlgtUKbGa, joPnHEcKJOELCGSgCxILemmKNcxU2.iaglYrQnRgNejmCemARfCJNLcaO))
			{
				return joPnHEcKJOELCGSgCxILemmKNcxU2;
			}
			if (!P_0)
			{
				joPnHEcKJOELCGSgCxILemmKNcxU2 = CjrOBzdFWnMVXYqzCgIRjpInCtEs.Dequeue();
			}
			zeifCMFjumnPWxazwPulyUEbhfm(joPnHEcKJOELCGSgCxILemmKNcxU2, true);
		}
		return null;
	}

	private bool zsLcGCXMkiYhqjOuICZbsjWtWja()
	{
		return SfWLDFMwuenhgtJIDfDdYYunmkp(false) != null;
	}

	private void zeifCMFjumnPWxazwPulyUEbhfm(joPnHEcKJOELCGSgCxILemmKNcxU P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && RgoEesEMOUcwLQuiCoYNnZxzjND != null && P_0.ITNAyjiIdCLVSdzMuGWXZQQZJNZ != null)
			{
				RgoEesEMOUcwLQuiCoYNnZxzjND(P_0.ITNAyjiIdCLVSdzMuGWXZQQZJNZ);
			}
			pULXUihImJyGMYomoCqqAjClKHNB.Return(P_0);
		}
	}

	public void Dispose()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
		GC.SuppressFinalize(this);
	}

	~ZXuymswIrYJxBfAZaYgHcxQnsDA()
	{
		WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
	}

	protected void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
	{
		if (inweGjIgYacXYohFlYRlpMFkgKMi)
		{
			return;
		}
		if (P_0)
		{
			VxWYhSWcyHtpXhSDbelOvWQxsme();
			if (EAkChchgpneGPakFUTPVByHUjQB != null)
			{
				EAkChchgpneGPakFUTPVByHUjQB.Dispose();
			}
		}
		inweGjIgYacXYohFlYRlpMFkgKMi = true;
	}

	public static bool nbhODHzWvwEZfUtrfjhQXTessUA(ZXuymswIrYJxBfAZaYgHcxQnsDA P_0, ZXuymswIrYJxBfAZaYgHcxQnsDA P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.EAkChchgpneGPakFUTPVByHUjQB, ref P_1.EAkChchgpneGPakFUTPVByHUjQB);
		MiscTools.Swap(ref P_0.pULXUihImJyGMYomoCqqAjClKHNB, ref P_1.pULXUihImJyGMYomoCqqAjClKHNB);
		MiscTools.Swap(ref P_0.CjrOBzdFWnMVXYqzCgIRjpInCtEs, ref P_1.CjrOBzdFWnMVXYqzCgIRjpInCtEs);
		return true;
	}

	[CompilerGenerated]
	private static joPnHEcKJOELCGSgCxILemmKNcxU cyjRCVaFXwEvVZDyrfgKBTUahuSP()
	{
		return new joPnHEcKJOELCGSgCxILemmKNcxU();
	}

	[CompilerGenerated]
	private static void wZYVsNHiVzgHSekXMuzkaULkYNf(joPnHEcKJOELCGSgCxILemmKNcxU P_0)
	{
		P_0.ibajyEOvcZaAVvqbaVIEPkwcIqx();
	}
}

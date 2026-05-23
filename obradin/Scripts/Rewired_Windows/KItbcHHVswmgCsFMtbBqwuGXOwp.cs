using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class KItbcHHVswmgCsFMtbBqwuGXOwp : IDisposable
{
	private class ZkmkUUBDDuXSQidZcpmpxWqcoqC
	{
		public int pQJLkxKHdjfUMfoBMxoMyQWuJrk;

		public int qQrMsIBjrmxBFOrAWHTVkrzFtPW;

		public uint bAhqUWvGZSuIKfHipHNfAKihrqi;

		public object VaAVMXBWekyWeewbbHRCHSrbTxf;

		public void pXrImHlfStExpVgddvwXomgjtDU(int P_0, int P_1, uint P_2, object P_3)
		{
			pQJLkxKHdjfUMfoBMxoMyQWuJrk = P_0;
			qQrMsIBjrmxBFOrAWHTVkrzFtPW = P_1;
			bAhqUWvGZSuIKfHipHNfAKihrqi = P_2;
			VaAVMXBWekyWeewbbHRCHSrbTxf = P_3;
		}

		public void fWzuAFjFXxdRoqxypOAIFkBEHOX()
		{
			VaAVMXBWekyWeewbbHRCHSrbTxf = null;
		}
	}

	private BTHrwIBgxFqazDintdmlgnJdIAF RlrDFPWlIVBjihBXNSARRWgibHv;

	private ObjectPool<ZkmkUUBDDuXSQidZcpmpxWqcoqC> ojUGVJODMdpjfBlmlXtcfjrHOXx;

	private Queue<ZkmkUUBDDuXSQidZcpmpxWqcoqC> ZrahAKgCaFnqojZnBAJVOztXbhqa;

	private Action<object> ELbZtNzOoeLVyVaeFHXDcbMDVZlP;

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	[CompilerGenerated]
	private static Func<ZkmkUUBDDuXSQidZcpmpxWqcoqC> SifXhONuihwJlzliJKSgBERDMgZ;

	[CompilerGenerated]
	private static Action<ZkmkUUBDDuXSQidZcpmpxWqcoqC> ObiydVxuKIemyadsFDMcIGxoLjQg;

	public bool HasItems
	{
		get
		{
			return coShlRoALYhBtkkAVTrJadkRAWz();
		}
	}

	public KItbcHHVswmgCsFMtbBqwuGXOwp(int byteCapacity, int startingQueueSize, Action<object> lostCustomDataDisposalDelegate = null)
	{
		if (byteCapacity <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		RlrDFPWlIVBjihBXNSARRWgibHv = new BTHrwIBgxFqazDintdmlgnJdIAF(byteCapacity);
		ojUGVJODMdpjfBlmlXtcfjrHOXx = new ObjectPool<ZkmkUUBDDuXSQidZcpmpxWqcoqC>(startingQueueSize, () => new ZkmkUUBDDuXSQidZcpmpxWqcoqC(), delegate(ZkmkUUBDDuXSQidZcpmpxWqcoqC P_0)
		{
			P_0.fWzuAFjFXxdRoqxypOAIFkBEHOX();
		});
		ZrahAKgCaFnqojZnBAJVOztXbhqa = new Queue<ZkmkUUBDDuXSQidZcpmpxWqcoqC>(startingQueueSize);
		ELbZtNzOoeLVyVaeFHXDcbMDVZlP = lostCustomDataDisposalDelegate;
	}

	public unsafe bool SFnUlcdGONKjYCbrEBAjYDBcYmz(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		int num2;
		uint num3;
		int num = RlrDFPWlIVBjihBXNSARRWgibHv.mszIJNECfxEuJZasPAYwzZDCgpx(P_0, P_1, P_1, out num2, out num3);
		if (num < P_1)
		{
			return false;
		}
		ZkmkUUBDDuXSQidZcpmpxWqcoqC zkmkUUBDDuXSQidZcpmpxWqcoqC = ojUGVJODMdpjfBlmlXtcfjrHOXx.Get();
		zkmkUUBDDuXSQidZcpmpxWqcoqC.pXrImHlfStExpVgddvwXomgjtDU(num2, P_1, num3, P_2);
		ZrahAKgCaFnqojZnBAJVOztXbhqa.Enqueue(zkmkUUBDDuXSQidZcpmpxWqcoqC);
		return true;
	}

	public unsafe bool SFnUlcdGONKjYCbrEBAjYDBcYmz(byte* P_0, int P_1)
	{
		return SFnUlcdGONKjYCbrEBAjYDBcYmz(P_0, P_1, null);
	}

	public unsafe bool SFnUlcdGONKjYCbrEBAjYDBcYmz(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return SFnUlcdGONKjYCbrEBAjYDBcYmz((byte*)(void*)P_0, P_1, P_2);
	}

	public bool SFnUlcdGONKjYCbrEBAjYDBcYmz(IntPtr P_0, int P_1)
	{
		return SFnUlcdGONKjYCbrEBAjYDBcYmz(P_0, P_1, null);
	}

	public unsafe bool SFnUlcdGONKjYCbrEBAjYDBcYmz(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return SFnUlcdGONKjYCbrEBAjYDBcYmz(ptr2, P_1, P_2);
		}
	}

	public bool SFnUlcdGONKjYCbrEBAjYDBcYmz(byte[] P_0, int P_1, int P_2 = 0)
	{
		return SFnUlcdGONKjYCbrEBAjYDBcYmz(P_0, P_1, null, P_2);
	}

	public unsafe int jKZJYylnJFwcxKOBHHmimtmxVUF(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		ZkmkUUBDDuXSQidZcpmpxWqcoqC zkmkUUBDDuXSQidZcpmpxWqcoqC = FiJEYkAfWOwGFamMMWIxmMTPUmNA(false);
		if (zkmkUUBDDuXSQidZcpmpxWqcoqC == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < zkmkUUBDDuXSQidZcpmpxWqcoqC.qQrMsIBjrmxBFOrAWHTVkrzFtPW)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", true);
			P_2 = null;
			return -1;
		}
		int num = RlrDFPWlIVBjihBXNSARRWgibHv.yOFSIdBTmOCZgHOejreZhfdhCWn(P_0, P_1, zkmkUUBDDuXSQidZcpmpxWqcoqC.qQrMsIBjrmxBFOrAWHTVkrzFtPW, zkmkUUBDDuXSQidZcpmpxWqcoqC.pQJLkxKHdjfUMfoBMxoMyQWuJrk);
		if (num != zkmkUUBDDuXSQidZcpmpxWqcoqC.qQrMsIBjrmxBFOrAWHTVkrzFtPW)
		{
			Logger.LogError("Failure reading data from buffer!", true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = zkmkUUBDDuXSQidZcpmpxWqcoqC.VaAVMXBWekyWeewbbHRCHSrbTxf;
		return num;
	}

	public unsafe int jKZJYylnJFwcxKOBHHmimtmxVUF(byte* P_0, int P_1)
	{
		object obj;
		return jKZJYylnJFwcxKOBHHmimtmxVUF(P_0, P_1, out obj);
	}

	public unsafe int jKZJYylnJFwcxKOBHHmimtmxVUF(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return jKZJYylnJFwcxKOBHHmimtmxVUF((byte*)(void*)P_0, P_1, out P_2);
	}

	public int jKZJYylnJFwcxKOBHHmimtmxVUF(IntPtr P_0, int P_1)
	{
		object obj;
		return jKZJYylnJFwcxKOBHHmimtmxVUF(P_0, P_1, out obj);
	}

	public unsafe int jKZJYylnJFwcxKOBHHmimtmxVUF(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return jKZJYylnJFwcxKOBHHmimtmxVUF(ptr, P_0.Length, out P_1);
		}
	}

	public int jKZJYylnJFwcxKOBHHmimtmxVUF(byte[] P_0)
	{
		object obj;
		return jKZJYylnJFwcxKOBHHmimtmxVUF(P_0, out obj);
	}

	public int UjLodsaJZgpoEKeuPqEmNJBjNos()
	{
		ZkmkUUBDDuXSQidZcpmpxWqcoqC zkmkUUBDDuXSQidZcpmpxWqcoqC = FiJEYkAfWOwGFamMMWIxmMTPUmNA(false);
		if (zkmkUUBDDuXSQidZcpmpxWqcoqC == null)
		{
			return -1;
		}
		return zkmkUUBDDuXSQidZcpmpxWqcoqC.qQrMsIBjrmxBFOrAWHTVkrzFtPW;
	}

	public unsafe int JVmxPxdNuGDZDcUugmpqXOqeGeGF(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		ZkmkUUBDDuXSQidZcpmpxWqcoqC zkmkUUBDDuXSQidZcpmpxWqcoqC = FiJEYkAfWOwGFamMMWIxmMTPUmNA(true);
		if (zkmkUUBDDuXSQidZcpmpxWqcoqC == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < zkmkUUBDDuXSQidZcpmpxWqcoqC.qQrMsIBjrmxBFOrAWHTVkrzFtPW)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", true);
			P_2 = null;
			cqpdiloTOMoKfwnvvoOpmxhLffG(zkmkUUBDDuXSQidZcpmpxWqcoqC, true);
			return -1;
		}
		int num = RlrDFPWlIVBjihBXNSARRWgibHv.yOFSIdBTmOCZgHOejreZhfdhCWn(P_0, P_1, zkmkUUBDDuXSQidZcpmpxWqcoqC.qQrMsIBjrmxBFOrAWHTVkrzFtPW, zkmkUUBDDuXSQidZcpmpxWqcoqC.pQJLkxKHdjfUMfoBMxoMyQWuJrk);
		if (num != zkmkUUBDDuXSQidZcpmpxWqcoqC.qQrMsIBjrmxBFOrAWHTVkrzFtPW)
		{
			Logger.LogError("Failure reading data from buffer!", true);
			P_2 = null;
			cqpdiloTOMoKfwnvvoOpmxhLffG(zkmkUUBDDuXSQidZcpmpxWqcoqC, true);
			return -1;
		}
		P_2 = zkmkUUBDDuXSQidZcpmpxWqcoqC.VaAVMXBWekyWeewbbHRCHSrbTxf;
		cqpdiloTOMoKfwnvvoOpmxhLffG(zkmkUUBDDuXSQidZcpmpxWqcoqC, false);
		return num;
	}

	public unsafe int JVmxPxdNuGDZDcUugmpqXOqeGeGF(byte* P_0, int P_1)
	{
		object obj;
		return JVmxPxdNuGDZDcUugmpqXOqeGeGF(P_0, P_1, out obj);
	}

	public unsafe int JVmxPxdNuGDZDcUugmpqXOqeGeGF(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return JVmxPxdNuGDZDcUugmpqXOqeGeGF((byte*)(void*)P_0, P_1, out P_2);
	}

	public int JVmxPxdNuGDZDcUugmpqXOqeGeGF(IntPtr P_0, int P_1)
	{
		object obj;
		return JVmxPxdNuGDZDcUugmpqXOqeGeGF(P_0, P_1, out obj);
	}

	public unsafe int JVmxPxdNuGDZDcUugmpqXOqeGeGF(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return JVmxPxdNuGDZDcUugmpqXOqeGeGF(ptr, P_0.Length, out P_1);
		}
	}

	public int JVmxPxdNuGDZDcUugmpqXOqeGeGF(byte[] P_0)
	{
		object obj;
		return JVmxPxdNuGDZDcUugmpqXOqeGeGF(P_0, out obj);
	}

	public void SyFZKnpdKtjKkalPwEnGerlPEmYq()
	{
		RlrDFPWlIVBjihBXNSARRWgibHv.SyFZKnpdKtjKkalPwEnGerlPEmYq();
		while (ZrahAKgCaFnqojZnBAJVOztXbhqa.Count > 0)
		{
			cqpdiloTOMoKfwnvvoOpmxhLffG(ZrahAKgCaFnqojZnBAJVOztXbhqa.Dequeue(), true);
		}
	}

	private ZkmkUUBDDuXSQidZcpmpxWqcoqC FiJEYkAfWOwGFamMMWIxmMTPUmNA(bool P_0)
	{
		while (ZrahAKgCaFnqojZnBAJVOztXbhqa.Count > 0)
		{
			ZkmkUUBDDuXSQidZcpmpxWqcoqC zkmkUUBDDuXSQidZcpmpxWqcoqC = (P_0 ? ZrahAKgCaFnqojZnBAJVOztXbhqa.Dequeue() : ZrahAKgCaFnqojZnBAJVOztXbhqa.Peek());
			if (RlrDFPWlIVBjihBXNSARRWgibHv.dVqgpUEVoGqAkyEaepBNdkHiJiHI(zkmkUUBDDuXSQidZcpmpxWqcoqC.pQJLkxKHdjfUMfoBMxoMyQWuJrk, zkmkUUBDDuXSQidZcpmpxWqcoqC.bAhqUWvGZSuIKfHipHNfAKihrqi))
			{
				return zkmkUUBDDuXSQidZcpmpxWqcoqC;
			}
			if (!P_0)
			{
				zkmkUUBDDuXSQidZcpmpxWqcoqC = ZrahAKgCaFnqojZnBAJVOztXbhqa.Dequeue();
			}
			cqpdiloTOMoKfwnvvoOpmxhLffG(zkmkUUBDDuXSQidZcpmpxWqcoqC, true);
		}
		return null;
	}

	private bool coShlRoALYhBtkkAVTrJadkRAWz()
	{
		return FiJEYkAfWOwGFamMMWIxmMTPUmNA(false) != null;
	}

	private void cqpdiloTOMoKfwnvvoOpmxhLffG(ZkmkUUBDDuXSQidZcpmpxWqcoqC P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && ELbZtNzOoeLVyVaeFHXDcbMDVZlP != null && P_0.VaAVMXBWekyWeewbbHRCHSrbTxf != null)
			{
				ELbZtNzOoeLVyVaeFHXDcbMDVZlP(P_0.VaAVMXBWekyWeewbbHRCHSrbTxf);
			}
			ojUGVJODMdpjfBlmlXtcfjrHOXx.Return(P_0);
		}
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~KItbcHHVswmgCsFMtbBqwuGXOwp()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return;
		}
		if (P_0)
		{
			SyFZKnpdKtjKkalPwEnGerlPEmYq();
			if (RlrDFPWlIVBjihBXNSARRWgibHv != null)
			{
				RlrDFPWlIVBjihBXNSARRWgibHv.Dispose();
			}
		}
		nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
	}

	public static bool cesjYeFQZWqsMLXtgIqGWPHOvyip(KItbcHHVswmgCsFMtbBqwuGXOwp P_0, KItbcHHVswmgCsFMtbBqwuGXOwp P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.RlrDFPWlIVBjihBXNSARRWgibHv, ref P_1.RlrDFPWlIVBjihBXNSARRWgibHv);
		MiscTools.Swap(ref P_0.ojUGVJODMdpjfBlmlXtcfjrHOXx, ref P_1.ojUGVJODMdpjfBlmlXtcfjrHOXx);
		MiscTools.Swap(ref P_0.ZrahAKgCaFnqojZnBAJVOztXbhqa, ref P_1.ZrahAKgCaFnqojZnBAJVOztXbhqa);
		return true;
	}

	[CompilerGenerated]
	private static ZkmkUUBDDuXSQidZcpmpxWqcoqC tudMwhBpiSMgeCsoafYGFtlScmm()
	{
		return new ZkmkUUBDDuXSQidZcpmpxWqcoqC();
	}

	[CompilerGenerated]
	private static void vQLDxmsezZPgbduBLSkgisgImXX(ZkmkUUBDDuXSQidZcpmpxWqcoqC P_0)
	{
		P_0.fWzuAFjFXxdRoqxypOAIFkBEHOX();
	}
}

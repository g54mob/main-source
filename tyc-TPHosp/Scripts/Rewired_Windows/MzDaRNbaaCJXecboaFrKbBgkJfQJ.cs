using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class MzDaRNbaaCJXecboaFrKbBgkJfQJ : IDisposable
{
	private class PUiBpaAYfrcJgCyFgdUmEaZPXdUD
	{
		public int lMxElehlYLfgycbtVAwYHkiyeXD;

		public int qTZPksemrAcMfHZNTkflHZVBZec;

		public uint xmDuYECXJojJiejIsWfBnfSnppF;

		public object XGmEzTFkqUHXMCdZIcxuEuDWtMUb;

		public void jkNSmPKHAFDYNAMFgsQtdPCvKWfn(int P_0, int P_1, uint P_2, object P_3)
		{
			lMxElehlYLfgycbtVAwYHkiyeXD = P_0;
			qTZPksemrAcMfHZNTkflHZVBZec = P_1;
			xmDuYECXJojJiejIsWfBnfSnppF = P_2;
			XGmEzTFkqUHXMCdZIcxuEuDWtMUb = P_3;
		}

		public void rKJfCRBWFLQsKCjGykmcumzKLPwE()
		{
			XGmEzTFkqUHXMCdZIcxuEuDWtMUb = null;
		}
	}

	private HrbEWQgpebVVqUNyRWFGLjblPkV DBZCtHAzIvFuQOarCKsttoMaNgUG;

	private ObjectPool<PUiBpaAYfrcJgCyFgdUmEaZPXdUD> ouafWDnCaFYSNYWCgBAGIGLHCrO;

	private Queue<PUiBpaAYfrcJgCyFgdUmEaZPXdUD> NrUoLIfVcnPXMWqDClcbOnLJeBD;

	private Action<object> QVHcLNOZqSGyKUYGQGhdEFwHfCQD;

	private bool dkPCbOYSgevDLsWpfwoFAuUOPFV;

	[CompilerGenerated]
	private static Func<PUiBpaAYfrcJgCyFgdUmEaZPXdUD> IZPAxIBugFNHRnaYKJeGsefDXVyg;

	[CompilerGenerated]
	private static Action<PUiBpaAYfrcJgCyFgdUmEaZPXdUD> WmMdHBErSeAJGbTMYGwEazTgqgzH;

	public bool HasItems => iRaqLdJKWugMrpHIOevBHoBZZJn();

	public MzDaRNbaaCJXecboaFrKbBgkJfQJ(int byteCapacity, int startingQueueSize, Action<object> lostCustomDataDisposalDelegate = null)
	{
		if (byteCapacity <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		DBZCtHAzIvFuQOarCKsttoMaNgUG = new HrbEWQgpebVVqUNyRWFGLjblPkV(byteCapacity);
		ouafWDnCaFYSNYWCgBAGIGLHCrO = new ObjectPool<PUiBpaAYfrcJgCyFgdUmEaZPXdUD>(startingQueueSize, () => new PUiBpaAYfrcJgCyFgdUmEaZPXdUD(), delegate(PUiBpaAYfrcJgCyFgdUmEaZPXdUD P_0)
		{
			P_0.rKJfCRBWFLQsKCjGykmcumzKLPwE();
		});
		NrUoLIfVcnPXMWqDClcbOnLJeBD = new Queue<PUiBpaAYfrcJgCyFgdUmEaZPXdUD>(startingQueueSize);
		QVHcLNOZqSGyKUYGQGhdEFwHfCQD = lostCustomDataDisposalDelegate;
	}

	public unsafe bool UyHkmeYMKxbRaLGZZmHNfcnwklW(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		int num2;
		uint num3;
		int num = DBZCtHAzIvFuQOarCKsttoMaNgUG.ujTUoJrkpPHtthAWMneMiOxOImEn(P_0, P_1, P_1, out num2, out num3);
		if (num < P_1)
		{
			return false;
		}
		PUiBpaAYfrcJgCyFgdUmEaZPXdUD pUiBpaAYfrcJgCyFgdUmEaZPXdUD = ouafWDnCaFYSNYWCgBAGIGLHCrO.Get();
		pUiBpaAYfrcJgCyFgdUmEaZPXdUD.jkNSmPKHAFDYNAMFgsQtdPCvKWfn(num2, P_1, num3, P_2);
		NrUoLIfVcnPXMWqDClcbOnLJeBD.Enqueue(pUiBpaAYfrcJgCyFgdUmEaZPXdUD);
		return true;
	}

	public unsafe bool UyHkmeYMKxbRaLGZZmHNfcnwklW(byte* P_0, int P_1)
	{
		return UyHkmeYMKxbRaLGZZmHNfcnwklW(P_0, P_1, null);
	}

	public unsafe bool UyHkmeYMKxbRaLGZZmHNfcnwklW(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return UyHkmeYMKxbRaLGZZmHNfcnwklW((byte*)(void*)P_0, P_1, P_2);
	}

	public bool UyHkmeYMKxbRaLGZZmHNfcnwklW(IntPtr P_0, int P_1)
	{
		return UyHkmeYMKxbRaLGZZmHNfcnwklW(P_0, P_1, null);
	}

	public unsafe bool UyHkmeYMKxbRaLGZZmHNfcnwklW(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return UyHkmeYMKxbRaLGZZmHNfcnwklW(ptr2, P_1, P_2);
		}
	}

	public bool UyHkmeYMKxbRaLGZZmHNfcnwklW(byte[] P_0, int P_1, int P_2 = 0)
	{
		return UyHkmeYMKxbRaLGZZmHNfcnwklW(P_0, P_1, null, P_2);
	}

	public unsafe int dvhsXkCRytJfDZfKQWSAROnzVLw(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		PUiBpaAYfrcJgCyFgdUmEaZPXdUD pUiBpaAYfrcJgCyFgdUmEaZPXdUD = RuzgzkKlEilwbjPuHsCBdmlLbOq(false);
		if (pUiBpaAYfrcJgCyFgdUmEaZPXdUD == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < pUiBpaAYfrcJgCyFgdUmEaZPXdUD.qTZPksemrAcMfHZNTkflHZVBZec)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = DBZCtHAzIvFuQOarCKsttoMaNgUG.qTlgsteogoNhWhAWikNtfEJajJWG(P_0, P_1, pUiBpaAYfrcJgCyFgdUmEaZPXdUD.qTZPksemrAcMfHZNTkflHZVBZec, pUiBpaAYfrcJgCyFgdUmEaZPXdUD.lMxElehlYLfgycbtVAwYHkiyeXD);
		if (num != pUiBpaAYfrcJgCyFgdUmEaZPXdUD.qTZPksemrAcMfHZNTkflHZVBZec)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = pUiBpaAYfrcJgCyFgdUmEaZPXdUD.XGmEzTFkqUHXMCdZIcxuEuDWtMUb;
		return num;
	}

	public unsafe int dvhsXkCRytJfDZfKQWSAROnzVLw(byte* P_0, int P_1)
	{
		object obj;
		return dvhsXkCRytJfDZfKQWSAROnzVLw(P_0, P_1, out obj);
	}

	public unsafe int dvhsXkCRytJfDZfKQWSAROnzVLw(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return dvhsXkCRytJfDZfKQWSAROnzVLw((byte*)(void*)P_0, P_1, out P_2);
	}

	public int dvhsXkCRytJfDZfKQWSAROnzVLw(IntPtr P_0, int P_1)
	{
		object obj;
		return dvhsXkCRytJfDZfKQWSAROnzVLw(P_0, P_1, out obj);
	}

	public unsafe int dvhsXkCRytJfDZfKQWSAROnzVLw(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return dvhsXkCRytJfDZfKQWSAROnzVLw(ptr, P_0.Length, out P_1);
		}
	}

	public int dvhsXkCRytJfDZfKQWSAROnzVLw(byte[] P_0)
	{
		object obj;
		return dvhsXkCRytJfDZfKQWSAROnzVLw(P_0, out obj);
	}

	public int MwvpAsVXNMjUkRPAAZEGcflbSSJ()
	{
		return RuzgzkKlEilwbjPuHsCBdmlLbOq(false)?.qTZPksemrAcMfHZNTkflHZVBZec ?? (-1);
	}

	public unsafe int RGQcvxCliscwbZdGrHJGkbYoPdvF(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		PUiBpaAYfrcJgCyFgdUmEaZPXdUD pUiBpaAYfrcJgCyFgdUmEaZPXdUD = RuzgzkKlEilwbjPuHsCBdmlLbOq(true);
		if (pUiBpaAYfrcJgCyFgdUmEaZPXdUD == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < pUiBpaAYfrcJgCyFgdUmEaZPXdUD.qTZPksemrAcMfHZNTkflHZVBZec)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			mSNVAhLuEySpHfnVkasXVDXPFcf(pUiBpaAYfrcJgCyFgdUmEaZPXdUD, true);
			return -1;
		}
		int num = DBZCtHAzIvFuQOarCKsttoMaNgUG.qTlgsteogoNhWhAWikNtfEJajJWG(P_0, P_1, pUiBpaAYfrcJgCyFgdUmEaZPXdUD.qTZPksemrAcMfHZNTkflHZVBZec, pUiBpaAYfrcJgCyFgdUmEaZPXdUD.lMxElehlYLfgycbtVAwYHkiyeXD);
		if (num != pUiBpaAYfrcJgCyFgdUmEaZPXdUD.qTZPksemrAcMfHZNTkflHZVBZec)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			mSNVAhLuEySpHfnVkasXVDXPFcf(pUiBpaAYfrcJgCyFgdUmEaZPXdUD, true);
			return -1;
		}
		P_2 = pUiBpaAYfrcJgCyFgdUmEaZPXdUD.XGmEzTFkqUHXMCdZIcxuEuDWtMUb;
		mSNVAhLuEySpHfnVkasXVDXPFcf(pUiBpaAYfrcJgCyFgdUmEaZPXdUD, false);
		return num;
	}

	public unsafe int RGQcvxCliscwbZdGrHJGkbYoPdvF(byte* P_0, int P_1)
	{
		object obj;
		return RGQcvxCliscwbZdGrHJGkbYoPdvF(P_0, P_1, out obj);
	}

	public unsafe int RGQcvxCliscwbZdGrHJGkbYoPdvF(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return RGQcvxCliscwbZdGrHJGkbYoPdvF((byte*)(void*)P_0, P_1, out P_2);
	}

	public int RGQcvxCliscwbZdGrHJGkbYoPdvF(IntPtr P_0, int P_1)
	{
		object obj;
		return RGQcvxCliscwbZdGrHJGkbYoPdvF(P_0, P_1, out obj);
	}

	public unsafe int RGQcvxCliscwbZdGrHJGkbYoPdvF(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return RGQcvxCliscwbZdGrHJGkbYoPdvF(ptr, P_0.Length, out P_1);
		}
	}

	public int RGQcvxCliscwbZdGrHJGkbYoPdvF(byte[] P_0)
	{
		object obj;
		return RGQcvxCliscwbZdGrHJGkbYoPdvF(P_0, out obj);
	}

	public void IJzuzpKYWPzhEvGrjeLwYBPHnpv()
	{
		DBZCtHAzIvFuQOarCKsttoMaNgUG.IJzuzpKYWPzhEvGrjeLwYBPHnpv();
		while (NrUoLIfVcnPXMWqDClcbOnLJeBD.Count > 0)
		{
			mSNVAhLuEySpHfnVkasXVDXPFcf(NrUoLIfVcnPXMWqDClcbOnLJeBD.Dequeue(), true);
		}
	}

	private PUiBpaAYfrcJgCyFgdUmEaZPXdUD RuzgzkKlEilwbjPuHsCBdmlLbOq(bool P_0)
	{
		while (NrUoLIfVcnPXMWqDClcbOnLJeBD.Count > 0)
		{
			PUiBpaAYfrcJgCyFgdUmEaZPXdUD pUiBpaAYfrcJgCyFgdUmEaZPXdUD = (P_0 ? NrUoLIfVcnPXMWqDClcbOnLJeBD.Dequeue() : NrUoLIfVcnPXMWqDClcbOnLJeBD.Peek());
			if (DBZCtHAzIvFuQOarCKsttoMaNgUG.fsKXIAurwqhSMRhWnbHdPwdRnbq(pUiBpaAYfrcJgCyFgdUmEaZPXdUD.lMxElehlYLfgycbtVAwYHkiyeXD, pUiBpaAYfrcJgCyFgdUmEaZPXdUD.xmDuYECXJojJiejIsWfBnfSnppF))
			{
				return pUiBpaAYfrcJgCyFgdUmEaZPXdUD;
			}
			if (!P_0)
			{
				pUiBpaAYfrcJgCyFgdUmEaZPXdUD = NrUoLIfVcnPXMWqDClcbOnLJeBD.Dequeue();
			}
			mSNVAhLuEySpHfnVkasXVDXPFcf(pUiBpaAYfrcJgCyFgdUmEaZPXdUD, true);
		}
		return null;
	}

	private bool iRaqLdJKWugMrpHIOevBHoBZZJn()
	{
		return RuzgzkKlEilwbjPuHsCBdmlLbOq(false) != null;
	}

	private void mSNVAhLuEySpHfnVkasXVDXPFcf(PUiBpaAYfrcJgCyFgdUmEaZPXdUD P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && QVHcLNOZqSGyKUYGQGhdEFwHfCQD != null && P_0.XGmEzTFkqUHXMCdZIcxuEuDWtMUb != null)
			{
				QVHcLNOZqSGyKUYGQGhdEFwHfCQD(P_0.XGmEzTFkqUHXMCdZIcxuEuDWtMUb);
			}
			ouafWDnCaFYSNYWCgBAGIGLHCrO.Return(P_0);
		}
	}

	public void Dispose()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(true);
		GC.SuppressFinalize(this);
	}

	~MzDaRNbaaCJXecboaFrKbBgkJfQJ()
	{
		LLOFbzNISIbRkZTwkaVnsPpYig(false);
	}

	protected void LLOFbzNISIbRkZTwkaVnsPpYig(bool P_0)
	{
		if (dkPCbOYSgevDLsWpfwoFAuUOPFV)
		{
			return;
		}
		if (P_0)
		{
			IJzuzpKYWPzhEvGrjeLwYBPHnpv();
			if (DBZCtHAzIvFuQOarCKsttoMaNgUG != null)
			{
				DBZCtHAzIvFuQOarCKsttoMaNgUG.Dispose();
			}
		}
		dkPCbOYSgevDLsWpfwoFAuUOPFV = true;
	}

	public static bool sdMgyqxMBwXKoAFLfCMkcCxShtL(MzDaRNbaaCJXecboaFrKbBgkJfQJ P_0, MzDaRNbaaCJXecboaFrKbBgkJfQJ P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.DBZCtHAzIvFuQOarCKsttoMaNgUG, ref P_1.DBZCtHAzIvFuQOarCKsttoMaNgUG);
		MiscTools.Swap(ref P_0.ouafWDnCaFYSNYWCgBAGIGLHCrO, ref P_1.ouafWDnCaFYSNYWCgBAGIGLHCrO);
		MiscTools.Swap(ref P_0.NrUoLIfVcnPXMWqDClcbOnLJeBD, ref P_1.NrUoLIfVcnPXMWqDClcbOnLJeBD);
		return true;
	}

	[CompilerGenerated]
	private static PUiBpaAYfrcJgCyFgdUmEaZPXdUD bjMlqwqtxorHGRcAxBZaakVCinX()
	{
		return new PUiBpaAYfrcJgCyFgdUmEaZPXdUD();
	}

	[CompilerGenerated]
	private static void jMnXDwBpTbRzZcpQGMBYPMyQAHs(PUiBpaAYfrcJgCyFgdUmEaZPXdUD P_0)
	{
		P_0.rKJfCRBWFLQsKCjGykmcumzKLPwE();
	}
}

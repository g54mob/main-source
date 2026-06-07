using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class KKLkuleVeymbVbciAPZslrYraid : IDisposable
{
	private class DSETxukOswfsPkKJXWMhJknDZtt
	{
		public int bcxenPpetdqFHqthzamUliAQEds;

		public int whPwJIwNtiomGJkXdcTTKttjbnRA;

		public uint jYNNvkIgFWjtVAyAEsFdbJgRUsoe;

		public object HRcfYtusegdrfxRTSAJKcQhDUJnq;

		public void jxLpHlOKCtqycCWHEKeVlpoLGRG(int P_0, int P_1, uint P_2, object P_3)
		{
			bcxenPpetdqFHqthzamUliAQEds = P_0;
			whPwJIwNtiomGJkXdcTTKttjbnRA = P_1;
			jYNNvkIgFWjtVAyAEsFdbJgRUsoe = P_2;
			HRcfYtusegdrfxRTSAJKcQhDUJnq = P_3;
		}

		public void bVJfbjSJHtCUhxVYYaQYFCJuPMDE()
		{
			HRcfYtusegdrfxRTSAJKcQhDUJnq = null;
		}
	}

	private XgfhmksxlThdyWjNKixlzEZZYFT BnTkMddEMRIYxgTpcAWVDYoOLbph;

	private ObjectPool<DSETxukOswfsPkKJXWMhJknDZtt> ciwSUhhlKtkscGRUGxtqkJjlLPr;

	private Queue<DSETxukOswfsPkKJXWMhJknDZtt> TCGDxudcwTvslONzoBAHmxXrlGs;

	private Action<object> SgVmpOEyIqAjbKKzmLxPqKvrVof;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	[CompilerGenerated]
	private static Func<DSETxukOswfsPkKJXWMhJknDZtt> SkHKUuaGmfDhgBaWutSkaMZppUJt;

	[CompilerGenerated]
	private static Action<DSETxukOswfsPkKJXWMhJknDZtt> SUfylBCEcUthjbGDmCcyBrEMnIA;

	public bool HasItems
	{
		get
		{
			return iEawqRLiUGTkGbDAcxHfvctrfMUd();
		}
	}

	public KKLkuleVeymbVbciAPZslrYraid(int byteCapacity, int startingQueueSize, Action<object> lostCustomDataDisposalDelegate = null)
	{
		if (byteCapacity <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		BnTkMddEMRIYxgTpcAWVDYoOLbph = new XgfhmksxlThdyWjNKixlzEZZYFT(byteCapacity);
		ciwSUhhlKtkscGRUGxtqkJjlLPr = new ObjectPool<DSETxukOswfsPkKJXWMhJknDZtt>(startingQueueSize, () => new DSETxukOswfsPkKJXWMhJknDZtt(), delegate(DSETxukOswfsPkKJXWMhJknDZtt P_0)
		{
			P_0.bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
		});
		TCGDxudcwTvslONzoBAHmxXrlGs = new Queue<DSETxukOswfsPkKJXWMhJknDZtt>(startingQueueSize);
		SgVmpOEyIqAjbKKzmLxPqKvrVof = lostCustomDataDisposalDelegate;
	}

	public unsafe bool CNNCNIEIEPKDJVWLdcWrLrRIbyb(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		int num2;
		uint num3;
		int num = BnTkMddEMRIYxgTpcAWVDYoOLbph.uwRrXbrytlKXYWIOmlUkwmZqEzx(P_0, P_1, P_1, out num2, out num3);
		if (num < P_1)
		{
			return false;
		}
		DSETxukOswfsPkKJXWMhJknDZtt dSETxukOswfsPkKJXWMhJknDZtt = ciwSUhhlKtkscGRUGxtqkJjlLPr.Get();
		dSETxukOswfsPkKJXWMhJknDZtt.jxLpHlOKCtqycCWHEKeVlpoLGRG(num2, P_1, num3, P_2);
		TCGDxudcwTvslONzoBAHmxXrlGs.Enqueue(dSETxukOswfsPkKJXWMhJknDZtt);
		return true;
	}

	public unsafe bool CNNCNIEIEPKDJVWLdcWrLrRIbyb(byte* P_0, int P_1)
	{
		return CNNCNIEIEPKDJVWLdcWrLrRIbyb(P_0, P_1, null);
	}

	public unsafe bool CNNCNIEIEPKDJVWLdcWrLrRIbyb(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return CNNCNIEIEPKDJVWLdcWrLrRIbyb((byte*)(void*)P_0, P_1, P_2);
	}

	public bool CNNCNIEIEPKDJVWLdcWrLrRIbyb(IntPtr P_0, int P_1)
	{
		return CNNCNIEIEPKDJVWLdcWrLrRIbyb(P_0, P_1, null);
	}

	public unsafe bool CNNCNIEIEPKDJVWLdcWrLrRIbyb(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return CNNCNIEIEPKDJVWLdcWrLrRIbyb(ptr2, P_1, P_2);
		}
	}

	public bool CNNCNIEIEPKDJVWLdcWrLrRIbyb(byte[] P_0, int P_1, int P_2 = 0)
	{
		return CNNCNIEIEPKDJVWLdcWrLrRIbyb(P_0, P_1, null, P_2);
	}

	public unsafe int jIhRCUKNZThZiXdTucNqnmnXMcF(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		DSETxukOswfsPkKJXWMhJknDZtt dSETxukOswfsPkKJXWMhJknDZtt = DGdRyASGNQNFKbgqrMmhZZBhuqR(false);
		if (dSETxukOswfsPkKJXWMhJknDZtt == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < dSETxukOswfsPkKJXWMhJknDZtt.whPwJIwNtiomGJkXdcTTKttjbnRA)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", true);
			P_2 = null;
			return -1;
		}
		int num = BnTkMddEMRIYxgTpcAWVDYoOLbph.mDbGZXyamQbHzAiWYgtFDajZiMvy(P_0, P_1, dSETxukOswfsPkKJXWMhJknDZtt.whPwJIwNtiomGJkXdcTTKttjbnRA, dSETxukOswfsPkKJXWMhJknDZtt.bcxenPpetdqFHqthzamUliAQEds);
		if (num != dSETxukOswfsPkKJXWMhJknDZtt.whPwJIwNtiomGJkXdcTTKttjbnRA)
		{
			Logger.LogError("Failure reading data from buffer!", true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = dSETxukOswfsPkKJXWMhJknDZtt.HRcfYtusegdrfxRTSAJKcQhDUJnq;
		return num;
	}

	public unsafe int jIhRCUKNZThZiXdTucNqnmnXMcF(byte* P_0, int P_1)
	{
		object obj;
		return jIhRCUKNZThZiXdTucNqnmnXMcF(P_0, P_1, out obj);
	}

	public unsafe int jIhRCUKNZThZiXdTucNqnmnXMcF(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return jIhRCUKNZThZiXdTucNqnmnXMcF((byte*)(void*)P_0, P_1, out P_2);
	}

	public int jIhRCUKNZThZiXdTucNqnmnXMcF(IntPtr P_0, int P_1)
	{
		object obj;
		return jIhRCUKNZThZiXdTucNqnmnXMcF(P_0, P_1, out obj);
	}

	public unsafe int jIhRCUKNZThZiXdTucNqnmnXMcF(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return jIhRCUKNZThZiXdTucNqnmnXMcF(ptr, P_0.Length, out P_1);
		}
	}

	public int jIhRCUKNZThZiXdTucNqnmnXMcF(byte[] P_0)
	{
		object obj;
		return jIhRCUKNZThZiXdTucNqnmnXMcF(P_0, out obj);
	}

	public int SJxShWFTLexgVVuGgoggGPRNLTy()
	{
		DSETxukOswfsPkKJXWMhJknDZtt dSETxukOswfsPkKJXWMhJknDZtt = DGdRyASGNQNFKbgqrMmhZZBhuqR(false);
		if (dSETxukOswfsPkKJXWMhJknDZtt == null)
		{
			return -1;
		}
		return dSETxukOswfsPkKJXWMhJknDZtt.whPwJIwNtiomGJkXdcTTKttjbnRA;
	}

	public unsafe int VUdIPtMuGhSSdTIkNxuNBkyUqYN(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		DSETxukOswfsPkKJXWMhJknDZtt dSETxukOswfsPkKJXWMhJknDZtt = DGdRyASGNQNFKbgqrMmhZZBhuqR(true);
		if (dSETxukOswfsPkKJXWMhJknDZtt == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < dSETxukOswfsPkKJXWMhJknDZtt.whPwJIwNtiomGJkXdcTTKttjbnRA)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", true);
			P_2 = null;
			qEPntPFPCQGByErTGNOpidrbHfCm(dSETxukOswfsPkKJXWMhJknDZtt, true);
			return -1;
		}
		int num = BnTkMddEMRIYxgTpcAWVDYoOLbph.mDbGZXyamQbHzAiWYgtFDajZiMvy(P_0, P_1, dSETxukOswfsPkKJXWMhJknDZtt.whPwJIwNtiomGJkXdcTTKttjbnRA, dSETxukOswfsPkKJXWMhJknDZtt.bcxenPpetdqFHqthzamUliAQEds);
		if (num != dSETxukOswfsPkKJXWMhJknDZtt.whPwJIwNtiomGJkXdcTTKttjbnRA)
		{
			Logger.LogError("Failure reading data from buffer!", true);
			P_2 = null;
			qEPntPFPCQGByErTGNOpidrbHfCm(dSETxukOswfsPkKJXWMhJknDZtt, true);
			return -1;
		}
		P_2 = dSETxukOswfsPkKJXWMhJknDZtt.HRcfYtusegdrfxRTSAJKcQhDUJnq;
		qEPntPFPCQGByErTGNOpidrbHfCm(dSETxukOswfsPkKJXWMhJknDZtt, false);
		return num;
	}

	public unsafe int VUdIPtMuGhSSdTIkNxuNBkyUqYN(byte* P_0, int P_1)
	{
		object obj;
		return VUdIPtMuGhSSdTIkNxuNBkyUqYN(P_0, P_1, out obj);
	}

	public unsafe int VUdIPtMuGhSSdTIkNxuNBkyUqYN(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return VUdIPtMuGhSSdTIkNxuNBkyUqYN((byte*)(void*)P_0, P_1, out P_2);
	}

	public int VUdIPtMuGhSSdTIkNxuNBkyUqYN(IntPtr P_0, int P_1)
	{
		object obj;
		return VUdIPtMuGhSSdTIkNxuNBkyUqYN(P_0, P_1, out obj);
	}

	public unsafe int VUdIPtMuGhSSdTIkNxuNBkyUqYN(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return VUdIPtMuGhSSdTIkNxuNBkyUqYN(ptr, P_0.Length, out P_1);
		}
	}

	public int VUdIPtMuGhSSdTIkNxuNBkyUqYN(byte[] P_0)
	{
		object obj;
		return VUdIPtMuGhSSdTIkNxuNBkyUqYN(P_0, out obj);
	}

	public void AWzoUVGHSxWLxpNvJinAivnlHuG()
	{
		BnTkMddEMRIYxgTpcAWVDYoOLbph.AWzoUVGHSxWLxpNvJinAivnlHuG();
		while (TCGDxudcwTvslONzoBAHmxXrlGs.Count > 0)
		{
			qEPntPFPCQGByErTGNOpidrbHfCm(TCGDxudcwTvslONzoBAHmxXrlGs.Dequeue(), true);
		}
	}

	private DSETxukOswfsPkKJXWMhJknDZtt DGdRyASGNQNFKbgqrMmhZZBhuqR(bool P_0)
	{
		while (TCGDxudcwTvslONzoBAHmxXrlGs.Count > 0)
		{
			DSETxukOswfsPkKJXWMhJknDZtt dSETxukOswfsPkKJXWMhJknDZtt = (P_0 ? TCGDxudcwTvslONzoBAHmxXrlGs.Dequeue() : TCGDxudcwTvslONzoBAHmxXrlGs.Peek());
			if (BnTkMddEMRIYxgTpcAWVDYoOLbph.jeWmRmokDYDPjTWrXHsFdDYnkvH(dSETxukOswfsPkKJXWMhJknDZtt.bcxenPpetdqFHqthzamUliAQEds, dSETxukOswfsPkKJXWMhJknDZtt.jYNNvkIgFWjtVAyAEsFdbJgRUsoe))
			{
				return dSETxukOswfsPkKJXWMhJknDZtt;
			}
			if (!P_0)
			{
				dSETxukOswfsPkKJXWMhJknDZtt = TCGDxudcwTvslONzoBAHmxXrlGs.Dequeue();
			}
			qEPntPFPCQGByErTGNOpidrbHfCm(dSETxukOswfsPkKJXWMhJknDZtt, true);
		}
		return null;
	}

	private bool iEawqRLiUGTkGbDAcxHfvctrfMUd()
	{
		return DGdRyASGNQNFKbgqrMmhZZBhuqR(false) != null;
	}

	private void qEPntPFPCQGByErTGNOpidrbHfCm(DSETxukOswfsPkKJXWMhJknDZtt P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && SgVmpOEyIqAjbKKzmLxPqKvrVof != null && P_0.HRcfYtusegdrfxRTSAJKcQhDUJnq != null)
			{
				SgVmpOEyIqAjbKKzmLxPqKvrVof(P_0.HRcfYtusegdrfxRTSAJKcQhDUJnq);
			}
			ciwSUhhlKtkscGRUGxtqkJjlLPr.Return(P_0);
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~KKLkuleVeymbVbciAPZslrYraid()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		if (P_0)
		{
			AWzoUVGHSxWLxpNvJinAivnlHuG();
			if (BnTkMddEMRIYxgTpcAWVDYoOLbph != null)
			{
				BnTkMddEMRIYxgTpcAWVDYoOLbph.Dispose();
			}
		}
		nNxUslIcGUpqKgpPZYhuimcvWyC = true;
	}

	public static bool wpQBxCtBOErkLMXbLoVKKTMeecc(KKLkuleVeymbVbciAPZslrYraid P_0, KKLkuleVeymbVbciAPZslrYraid P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.BnTkMddEMRIYxgTpcAWVDYoOLbph, ref P_1.BnTkMddEMRIYxgTpcAWVDYoOLbph);
		MiscTools.Swap(ref P_0.ciwSUhhlKtkscGRUGxtqkJjlLPr, ref P_1.ciwSUhhlKtkscGRUGxtqkJjlLPr);
		MiscTools.Swap(ref P_0.TCGDxudcwTvslONzoBAHmxXrlGs, ref P_1.TCGDxudcwTvslONzoBAHmxXrlGs);
		return true;
	}

	[CompilerGenerated]
	private static DSETxukOswfsPkKJXWMhJknDZtt vxYwJEgFtWWDxBWSZdxIIAngOkk()
	{
		return new DSETxukOswfsPkKJXWMhJknDZtt();
	}

	[CompilerGenerated]
	private static void fAjmEAFyjZfcmqWhwccidZagRoP(DSETxukOswfsPkKJXWMhJknDZtt P_0)
	{
		P_0.bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

internal class XeqjOHfSCPNCXLalLJTrsPXIroW : IDisposable
{
	private class VoBctyALiSHgNRUedomrBarNdrF
	{
		public int qIWceshwHQRtLrMtcNaPggZdiqDi;

		public int tBoUpppgZNaGCvLZuJHCmhsItew;

		public uint wSsunRPfXdVaFIEqFTYkMhKybbR;

		public object KrFFYpvWZVNzNZNbLJRuBmGkGWm;

		public void iPqCwAZeDSMUuyZPNmHIebwaSSn(int P_0, int P_1, uint P_2, object P_3)
		{
			qIWceshwHQRtLrMtcNaPggZdiqDi = P_0;
			tBoUpppgZNaGCvLZuJHCmhsItew = P_1;
			wSsunRPfXdVaFIEqFTYkMhKybbR = P_2;
			KrFFYpvWZVNzNZNbLJRuBmGkGWm = P_3;
		}

		public void avkcOhFlGGeHrNSdTQlLZUnJDbw()
		{
			KrFFYpvWZVNzNZNbLJRuBmGkGWm = null;
		}
	}

	private AhIGwJhtRkfPmaiXDLmmxmUKsJmG MGmVOJiswkwnBAbvbGQwLtBdeEt;

	private ObjectPool<VoBctyALiSHgNRUedomrBarNdrF> dNXsBQwIeQjImesELZnpijoQkSID;

	private Queue<VoBctyALiSHgNRUedomrBarNdrF> UCzrGNyqQyIZxyLHfLJAxliISoR;

	private Action<object> NnokrERJUDDgfmAOfDFKCrNOKCKD;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	[CompilerGenerated]
	private static Func<VoBctyALiSHgNRUedomrBarNdrF> HEaLJSdUMATgPAOVvKzcDQWAPaR;

	[CompilerGenerated]
	private static Action<VoBctyALiSHgNRUedomrBarNdrF> DXxIpEROuzKFdJPAfHCtkUctKeju;

	public bool HasItems => lZDxCoAcohECYDQWbDHgAsyUcFrO();

	public XeqjOHfSCPNCXLalLJTrsPXIroW(int byteCapacity, int startingQueueSize, Action<object> lostCustomDataDisposalDelegate = null)
	{
		if (byteCapacity <= 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		MGmVOJiswkwnBAbvbGQwLtBdeEt = new AhIGwJhtRkfPmaiXDLmmxmUKsJmG(byteCapacity);
		dNXsBQwIeQjImesELZnpijoQkSID = new ObjectPool<VoBctyALiSHgNRUedomrBarNdrF>(startingQueueSize, () => new VoBctyALiSHgNRUedomrBarNdrF(), delegate(VoBctyALiSHgNRUedomrBarNdrF P_0)
		{
			P_0.avkcOhFlGGeHrNSdTQlLZUnJDbw();
		});
		UCzrGNyqQyIZxyLHfLJAxliISoR = new Queue<VoBctyALiSHgNRUedomrBarNdrF>(startingQueueSize);
		NnokrERJUDDgfmAOfDFKCrNOKCKD = lostCustomDataDisposalDelegate;
	}

	public unsafe bool HnocEhRkacOxHhLLsmQmCGWhJlU(byte* P_0, int P_1, object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return false;
		}
		int num2;
		uint num3;
		int num = MGmVOJiswkwnBAbvbGQwLtBdeEt.xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0, P_1, P_1, out num2, out num3);
		if (num < P_1)
		{
			return false;
		}
		VoBctyALiSHgNRUedomrBarNdrF voBctyALiSHgNRUedomrBarNdrF = dNXsBQwIeQjImesELZnpijoQkSID.Get();
		voBctyALiSHgNRUedomrBarNdrF.iPqCwAZeDSMUuyZPNmHIebwaSSn(num2, P_1, num3, P_2);
		UCzrGNyqQyIZxyLHfLJAxliISoR.Enqueue(voBctyALiSHgNRUedomrBarNdrF);
		return true;
	}

	public unsafe bool HnocEhRkacOxHhLLsmQmCGWhJlU(byte* P_0, int P_1)
	{
		return HnocEhRkacOxHhLLsmQmCGWhJlU(P_0, P_1, null);
	}

	public unsafe bool HnocEhRkacOxHhLLsmQmCGWhJlU(IntPtr P_0, int P_1, object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			return false;
		}
		return HnocEhRkacOxHhLLsmQmCGWhJlU((byte*)(void*)P_0, P_1, P_2);
	}

	public bool HnocEhRkacOxHhLLsmQmCGWhJlU(IntPtr P_0, int P_1)
	{
		return HnocEhRkacOxHhLLsmQmCGWhJlU(P_0, P_1, null);
	}

	public unsafe bool HnocEhRkacOxHhLLsmQmCGWhJlU(byte[] P_0, int P_1, object P_2, int P_3 = 0)
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
			return HnocEhRkacOxHhLLsmQmCGWhJlU(ptr2, P_1, P_2);
		}
	}

	public bool HnocEhRkacOxHhLLsmQmCGWhJlU(byte[] P_0, int P_1, int P_2 = 0)
	{
		return HnocEhRkacOxHhLLsmQmCGWhJlU(P_0, P_1, null, P_2);
	}

	public unsafe int aiKzSrFLrcdBydnzvsejaUdewXo(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		VoBctyALiSHgNRUedomrBarNdrF voBctyALiSHgNRUedomrBarNdrF = OmIQQfFmmpVdWZNcgoWeCoKCvVw(false);
		if (voBctyALiSHgNRUedomrBarNdrF == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < voBctyALiSHgNRUedomrBarNdrF.tBoUpppgZNaGCvLZuJHCmhsItew)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Peek to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			return -1;
		}
		int num = MGmVOJiswkwnBAbvbGQwLtBdeEt.dXCYFuvCOffJxmSZZzDGbmRkFBM(P_0, P_1, voBctyALiSHgNRUedomrBarNdrF.tBoUpppgZNaGCvLZuJHCmhsItew, voBctyALiSHgNRUedomrBarNdrF.qIWceshwHQRtLrMtcNaPggZdiqDi);
		if (num != voBctyALiSHgNRUedomrBarNdrF.tBoUpppgZNaGCvLZuJHCmhsItew)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			num = 0;
			P_2 = null;
			return -1;
		}
		P_2 = voBctyALiSHgNRUedomrBarNdrF.KrFFYpvWZVNzNZNbLJRuBmGkGWm;
		return num;
	}

	public unsafe int aiKzSrFLrcdBydnzvsejaUdewXo(byte* P_0, int P_1)
	{
		object obj;
		return aiKzSrFLrcdBydnzvsejaUdewXo(P_0, P_1, out obj);
	}

	public unsafe int aiKzSrFLrcdBydnzvsejaUdewXo(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return aiKzSrFLrcdBydnzvsejaUdewXo((byte*)(void*)P_0, P_1, out P_2);
	}

	public int aiKzSrFLrcdBydnzvsejaUdewXo(IntPtr P_0, int P_1)
	{
		object obj;
		return aiKzSrFLrcdBydnzvsejaUdewXo(P_0, P_1, out obj);
	}

	public unsafe int aiKzSrFLrcdBydnzvsejaUdewXo(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return aiKzSrFLrcdBydnzvsejaUdewXo(ptr, P_0.Length, out P_1);
		}
	}

	public int aiKzSrFLrcdBydnzvsejaUdewXo(byte[] P_0)
	{
		object obj;
		return aiKzSrFLrcdBydnzvsejaUdewXo(P_0, out obj);
	}

	public int TeKoSdIohPCSNllYnilxRDIqIBN()
	{
		return OmIQQfFmmpVdWZNcgoWeCoKCvVw(false)?.tBoUpppgZNaGCvLZuJHCmhsItew ?? (-1);
	}

	public unsafe int IxpGHqFwEnAcCnmSShzjKizxbgj(byte* P_0, int P_1, out object P_2)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		VoBctyALiSHgNRUedomrBarNdrF voBctyALiSHgNRUedomrBarNdrF = OmIQQfFmmpVdWZNcgoWeCoKCvVw(true);
		if (voBctyALiSHgNRUedomrBarNdrF == null)
		{
			P_2 = null;
			return -1;
		}
		if (P_1 < voBctyALiSHgNRUedomrBarNdrF.tBoUpppgZNaGCvLZuJHCmhsItew)
		{
			Logger.LogError("The buffer is too small to hold the data. Call PeekDataLength before calling Dequeue to get the data length.", requiredThreadSafety: true);
			P_2 = null;
			byeiEiYemxbGwBeHDAGgksuOocz(voBctyALiSHgNRUedomrBarNdrF, true);
			return -1;
		}
		int num = MGmVOJiswkwnBAbvbGQwLtBdeEt.dXCYFuvCOffJxmSZZzDGbmRkFBM(P_0, P_1, voBctyALiSHgNRUedomrBarNdrF.tBoUpppgZNaGCvLZuJHCmhsItew, voBctyALiSHgNRUedomrBarNdrF.qIWceshwHQRtLrMtcNaPggZdiqDi);
		if (num != voBctyALiSHgNRUedomrBarNdrF.tBoUpppgZNaGCvLZuJHCmhsItew)
		{
			Logger.LogError("Failure reading data from buffer!", requiredThreadSafety: true);
			P_2 = null;
			byeiEiYemxbGwBeHDAGgksuOocz(voBctyALiSHgNRUedomrBarNdrF, true);
			return -1;
		}
		P_2 = voBctyALiSHgNRUedomrBarNdrF.KrFFYpvWZVNzNZNbLJRuBmGkGWm;
		byeiEiYemxbGwBeHDAGgksuOocz(voBctyALiSHgNRUedomrBarNdrF, false);
		return num;
	}

	public unsafe int IxpGHqFwEnAcCnmSShzjKizxbgj(byte* P_0, int P_1)
	{
		object obj;
		return IxpGHqFwEnAcCnmSShzjKizxbgj(P_0, P_1, out obj);
	}

	public unsafe int IxpGHqFwEnAcCnmSShzjKizxbgj(IntPtr P_0, int P_1, out object P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0)
		{
			P_2 = null;
			return -1;
		}
		return IxpGHqFwEnAcCnmSShzjKizxbgj((byte*)(void*)P_0, P_1, out P_2);
	}

	public int IxpGHqFwEnAcCnmSShzjKizxbgj(IntPtr P_0, int P_1)
	{
		object obj;
		return IxpGHqFwEnAcCnmSShzjKizxbgj(P_0, P_1, out obj);
	}

	public unsafe int IxpGHqFwEnAcCnmSShzjKizxbgj(byte[] P_0, out object P_1)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			P_1 = null;
			return -1;
		}
		fixed (byte* ptr = P_0)
		{
			return IxpGHqFwEnAcCnmSShzjKizxbgj(ptr, P_0.Length, out P_1);
		}
	}

	public int IxpGHqFwEnAcCnmSShzjKizxbgj(byte[] P_0)
	{
		object obj;
		return IxpGHqFwEnAcCnmSShzjKizxbgj(P_0, out obj);
	}

	public void JqSXKgZspIzlwNxbIhfPpoqGbbz()
	{
		MGmVOJiswkwnBAbvbGQwLtBdeEt.JqSXKgZspIzlwNxbIhfPpoqGbbz();
		while (UCzrGNyqQyIZxyLHfLJAxliISoR.Count > 0)
		{
			byeiEiYemxbGwBeHDAGgksuOocz(UCzrGNyqQyIZxyLHfLJAxliISoR.Dequeue(), true);
		}
	}

	private VoBctyALiSHgNRUedomrBarNdrF OmIQQfFmmpVdWZNcgoWeCoKCvVw(bool P_0)
	{
		while (UCzrGNyqQyIZxyLHfLJAxliISoR.Count > 0)
		{
			VoBctyALiSHgNRUedomrBarNdrF voBctyALiSHgNRUedomrBarNdrF = (P_0 ? UCzrGNyqQyIZxyLHfLJAxliISoR.Dequeue() : UCzrGNyqQyIZxyLHfLJAxliISoR.Peek());
			if (MGmVOJiswkwnBAbvbGQwLtBdeEt.eDbsbVnTYvcfzlIKIuPEqDQASxg(voBctyALiSHgNRUedomrBarNdrF.qIWceshwHQRtLrMtcNaPggZdiqDi, voBctyALiSHgNRUedomrBarNdrF.wSsunRPfXdVaFIEqFTYkMhKybbR))
			{
				return voBctyALiSHgNRUedomrBarNdrF;
			}
			if (!P_0)
			{
				voBctyALiSHgNRUedomrBarNdrF = UCzrGNyqQyIZxyLHfLJAxliISoR.Dequeue();
			}
			byeiEiYemxbGwBeHDAGgksuOocz(voBctyALiSHgNRUedomrBarNdrF, true);
		}
		return null;
	}

	private bool lZDxCoAcohECYDQWbDHgAsyUcFrO()
	{
		return OmIQQfFmmpVdWZNcgoWeCoKCvVw(false) != null;
	}

	private void byeiEiYemxbGwBeHDAGgksuOocz(VoBctyALiSHgNRUedomrBarNdrF P_0, bool P_1)
	{
		if (P_0 != null)
		{
			if (P_1 && NnokrERJUDDgfmAOfDFKCrNOKCKD != null && P_0.KrFFYpvWZVNzNZNbLJRuBmGkGWm != null)
			{
				NnokrERJUDDgfmAOfDFKCrNOKCKD(P_0.KrFFYpvWZVNzNZNbLJRuBmGkGWm);
			}
			dNXsBQwIeQjImesELZnpijoQkSID.Return(P_0);
		}
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~XeqjOHfSCPNCXLalLJTrsPXIroW()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (euujVPFzGztViWDbYvUutBvFQFP)
		{
			return;
		}
		if (P_0)
		{
			JqSXKgZspIzlwNxbIhfPpoqGbbz();
			if (MGmVOJiswkwnBAbvbGQwLtBdeEt != null)
			{
				MGmVOJiswkwnBAbvbGQwLtBdeEt.Dispose();
			}
		}
		euujVPFzGztViWDbYvUutBvFQFP = true;
	}

	public static bool fvlpIhqMprbPZaZBYcyRDSWBMfF(XeqjOHfSCPNCXLalLJTrsPXIroW P_0, XeqjOHfSCPNCXLalLJTrsPXIroW P_1)
	{
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		MiscTools.Swap(ref P_0.MGmVOJiswkwnBAbvbGQwLtBdeEt, ref P_1.MGmVOJiswkwnBAbvbGQwLtBdeEt);
		MiscTools.Swap(ref P_0.dNXsBQwIeQjImesELZnpijoQkSID, ref P_1.dNXsBQwIeQjImesELZnpijoQkSID);
		MiscTools.Swap(ref P_0.UCzrGNyqQyIZxyLHfLJAxliISoR, ref P_1.UCzrGNyqQyIZxyLHfLJAxliISoR);
		return true;
	}

	[CompilerGenerated]
	private static VoBctyALiSHgNRUedomrBarNdrF grfWgzdrTbzxdffKOfQHZcaLfzH()
	{
		return new VoBctyALiSHgNRUedomrBarNdrF();
	}

	[CompilerGenerated]
	private static void egUvzxGwFgLNkUrzrhgluVbBmYe(VoBctyALiSHgNRUedomrBarNdrF P_0)
	{
		P_0.avkcOhFlGGeHrNSdTQlLZUnJDbw();
	}
}

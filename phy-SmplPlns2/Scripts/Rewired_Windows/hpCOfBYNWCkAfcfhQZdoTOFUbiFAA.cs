using System;
using System.Runtime.InteropServices;

internal class hpCOfBYNWCkAfcfhQZdoTOFUbiFAA : IDisposable
{
	public struct uVwiNWYgxpmOBCthZhzLerBhVuWd
	{
		private byte LQHTJdjmOBaHFnXbNWryCVbyrpWJ;

		private uint taOyKXzueyHWfYQAavUGpHVmeyIaA;

		private int CrQaWDRWdNMuMbSyQQlcvkFbCmEs;

		private static uVwiNWYgxpmOBCthZhzLerBhVuWd ZMWwHRsGafkWFcLMwOeAFrbJKtew;

		public byte LufflKDrOCgtJcngUfvPOIcdjZOBA => LQHTJdjmOBaHFnXbNWryCVbyrpWJ;

		public uint bSoADjGEUczbEBvtSoaggSZapQtkb => taOyKXzueyHWfYQAavUGpHVmeyIaA;

		public int eYvwbItYEYvdkySSgDxYVVHDlrwk => CrQaWDRWdNMuMbSyQQlcvkFbCmEs;

		public static uVwiNWYgxpmOBCthZhzLerBhVuWd KKvjnxwmBJtopKsstnWSUWZShsKS => ZMWwHRsGafkWFcLMwOeAFrbJKtew;

		public uVwiNWYgxpmOBCthZhzLerBhVuWd(byte P_0, uint P_1, int P_2)
		{
			LQHTJdjmOBaHFnXbNWryCVbyrpWJ = P_0;
			taOyKXzueyHWfYQAavUGpHVmeyIaA = P_1;
			CrQaWDRWdNMuMbSyQQlcvkFbCmEs = P_2;
			if (CrQaWDRWdNMuMbSyQQlcvkFbCmEs < 0)
			{
				CrQaWDRWdNMuMbSyQQlcvkFbCmEs = 0;
			}
		}
	}

	private const byte fvkvApdDIWkSotVifxxrXjIQbmKt = 254;

	private uint ThEfLdbAROqiQSpdLlcodfgTIYay;

	private int mIEJgSIMuWRZJkJkIMsZrJbYPtth;

	private unsafe byte* iXJguBaVZpKkvPxECrdatIMTkzaqA;

	private byte uEeEhLGPnPlSlombqFSWmtMKwBjR;

	private bool UJEPgBqMfqtoMwHeGChzhNmodXrI;

	private bool UmLFvaamUgexJQYDOaoccqIqiQhsA;

	public int SBdIVVAUvjjaIjtnIrOAJInLCHvn => mIEJgSIMuWRZJkJkIMsZrJbYPtth;

	public unsafe hpCOfBYNWCkAfcfhQZdoTOFUbiFAA(int P_0)
	{
		if (P_0 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		mIEJgSIMuWRZJkJkIMsZrJbYPtth = P_0;
		ThEfLdbAROqiQSpdLlcodfgTIYay = 0u;
		iXJguBaVZpKkvPxECrdatIMTkzaqA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
	}

	public unsafe bool LMrOxTfyiiQYLwpaQGtYeJDTfEzm(IntPtr P_0, int P_1, out uVwiNWYgxpmOBCthZhzLerBhVuWd P_2)
	{
		if (iXJguBaVZpKkvPxECrdatIMTkzaqA == null || P_1 <= 0)
		{
			P_2 = default(uVwiNWYgxpmOBCthZhzLerBhVuWd);
			return false;
		}
		if (P_1 > mIEJgSIMuWRZJkJkIMsZrJbYPtth)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((uint)((int)ThEfLdbAROqiQSpdLlcodfgTIYay + P_1) > mIEJgSIMuWRZJkJkIMsZrJbYPtth)
		{
			ThEfLdbAROqiQSpdLlcodfgTIYay = 0u;
			if (uEeEhLGPnPlSlombqFSWmtMKwBjR == 254)
			{
				uEeEhLGPnPlSlombqFSWmtMKwBjR = 0;
				UJEPgBqMfqtoMwHeGChzhNmodXrI = true;
			}
			else
			{
				uEeEhLGPnPlSlombqFSWmtMKwBjR++;
			}
		}
		KQKvYsAXvDlLWOZXkMKdMDaTTekW.RmgatSmiYVfTgJTRMYcINwbhozmk(iXJguBaVZpKkvPxECrdatIMTkzaqA + ThEfLdbAROqiQSpdLlcodfgTIYay, (void*)P_0, new UIntPtr((uint)P_1));
		P_2 = new uVwiNWYgxpmOBCthZhzLerBhVuWd(uEeEhLGPnPlSlombqFSWmtMKwBjR, ThEfLdbAROqiQSpdLlcodfgTIYay, P_1);
		ThEfLdbAROqiQSpdLlcodfgTIYay += (uint)P_1;
		return true;
	}

	public int vXkepAjmEAbssClodmlAFYvBQxJVb(uVwiNWYgxpmOBCthZhzLerBhVuWd P_0, byte[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (P_1.Length < P_0.eYvwbItYEYvdkySSgDxYVVHDlrwk)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!EBzxNLCoCEiAmYrTrdrEDqxzbtqdb(ref P_0))
		{
			return -1;
		}
		Marshal.Copy(xMbPNdReQRZvuFhYJJXAjxVdjwto(P_0), P_1, 0, P_0.eYvwbItYEYvdkySSgDxYVVHDlrwk);
		return P_0.eYvwbItYEYvdkySSgDxYVVHDlrwk;
	}

	public unsafe int FbLtXwyHhraFLnidNDHefKPKIYfGb(uVwiNWYgxpmOBCthZhzLerBhVuWd P_0, IntPtr P_1, int P_2)
	{
		if (P_1 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (P_2 <= 0)
		{
			return -1;
		}
		if (P_2 < P_0.eYvwbItYEYvdkySSgDxYVVHDlrwk)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!EBzxNLCoCEiAmYrTrdrEDqxzbtqdb(ref P_0))
		{
			return -1;
		}
		KQKvYsAXvDlLWOZXkMKdMDaTTekW.RmgatSmiYVfTgJTRMYcINwbhozmk((void*)P_1, (void*)xMbPNdReQRZvuFhYJJXAjxVdjwto(P_0), new UIntPtr((uint)P_0.eYvwbItYEYvdkySSgDxYVVHDlrwk));
		return P_0.eYvwbItYEYvdkySSgDxYVVHDlrwk;
	}

	public unsafe IntPtr xMbPNdReQRZvuFhYJJXAjxVdjwto(uVwiNWYgxpmOBCthZhzLerBhVuWd P_0)
	{
		if (iXJguBaVZpKkvPxECrdatIMTkzaqA == null || !EBzxNLCoCEiAmYrTrdrEDqxzbtqdb(ref P_0))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)(iXJguBaVZpKkvPxECrdatIMTkzaqA + P_0.bSoADjGEUczbEBvtSoaggSZapQtkb);
	}

	public unsafe bool mPfFKvCmKWBfggKIbSJgASmzfFxPB(uVwiNWYgxpmOBCthZhzLerBhVuWd P_0, out IntPtr P_1)
	{
		if (iXJguBaVZpKkvPxECrdatIMTkzaqA == null || !EBzxNLCoCEiAmYrTrdrEDqxzbtqdb(ref P_0))
		{
			P_1 = IntPtr.Zero;
			return false;
		}
		P_1 = (IntPtr)(iXJguBaVZpKkvPxECrdatIMTkzaqA + P_0.bSoADjGEUczbEBvtSoaggSZapQtkb);
		return true;
	}

	private bool EBzxNLCoCEiAmYrTrdrEDqxzbtqdb(ref uVwiNWYgxpmOBCthZhzLerBhVuWd P_0)
	{
		int num = P_0.eYvwbItYEYvdkySSgDxYVVHDlrwk;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = P_0.LufflKDrOCgtJcngUfvPOIcdjZOBA;
		if (num2 > 254)
		{
			return false;
		}
		if (num2 != uEeEhLGPnPlSlombqFSWmtMKwBjR)
		{
			if (!UJEPgBqMfqtoMwHeGChzhNmodXrI)
			{
				if (num2 + 1 != uEeEhLGPnPlSlombqFSWmtMKwBjR)
				{
					return false;
				}
			}
			else if (num2 > uEeEhLGPnPlSlombqFSWmtMKwBjR)
			{
				if (uEeEhLGPnPlSlombqFSWmtMKwBjR != 0 || num2 != 254)
				{
					return false;
				}
			}
			else if (num2 + 1 != uEeEhLGPnPlSlombqFSWmtMKwBjR)
			{
				return false;
			}
			if (P_0.bSoADjGEUczbEBvtSoaggSZapQtkb < ThEfLdbAROqiQSpdLlcodfgTIYay)
			{
				return false;
			}
		}
		else if (P_0.bSoADjGEUczbEBvtSoaggSZapQtkb + num > ThEfLdbAROqiQSpdLlcodfgTIYay)
		{
			return false;
		}
		if (P_0.bSoADjGEUczbEBvtSoaggSZapQtkb + num > mIEJgSIMuWRZJkJkIMsZrJbYPtth)
		{
			return false;
		}
		return true;
	}

	public void Dispose()
	{
		BqUODhyLactFSGVOvjZdLgdsNsJn(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void flxhliVBuoqXkbDTPlKNUbhHZACN()
	{
		try
		{
			BqUODhyLactFSGVOvjZdLgdsNsJn(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected unsafe virtual void BqUODhyLactFSGVOvjZdLgdsNsJn(bool P_0)
	{
		if (!UmLFvaamUgexJQYDOaoccqIqiQhsA)
		{
			if (iXJguBaVZpKkvPxECrdatIMTkzaqA != null)
			{
				Marshal.FreeHGlobal((IntPtr)iXJguBaVZpKkvPxECrdatIMTkzaqA);
			}
			UmLFvaamUgexJQYDOaoccqIqiQhsA = true;
		}
	}
}

using System;
using System.Runtime.InteropServices;

internal class TQaIBLAKCHenrEZftHNBClvoRpUX : IDisposable
{
	private int UpyFOwAuBefdszuZIQnwBLnjqduhb;

	private uint TnbqoUvYgoTtgZoGauUtjgKQTcti;

	private IntPtr qYwiBoMPHShQjayEoojybBKfstNcA;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public TQaIBLAKCHenrEZftHNBClvoRpUX(uint P_0)
	{
		if (P_0 == 0)
		{
			throw new Exception("size must be > 0!");
		}
		TnbqoUvYgoTtgZoGauUtjgKQTcti = P_0;
		UpyFOwAuBefdszuZIQnwBLnjqduhb = 0;
		try
		{
			qYwiBoMPHShQjayEoojybBKfstNcA = Marshal.AllocHGlobal((int)P_0);
			if (qYwiBoMPHShQjayEoojybBKfstNcA == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr LucPkylTTXgrBjaDzRQoCLFlGsmA(uint P_0, void* P_1)
	{
		if (JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > TnbqoUvYgoTtgZoGauUtjgKQTcti)
		{
			return IntPtr.Zero;
		}
		if (UpyFOwAuBefdszuZIQnwBLnjqduhb + P_0 >= TnbqoUvYgoTtgZoGauUtjgKQTcti)
		{
			UpyFOwAuBefdszuZIQnwBLnjqduhb = 0;
		}
		IntPtr intPtr = new IntPtr(qYwiBoMPHShQjayEoojybBKfstNcA.ToInt64() + UpyFOwAuBefdszuZIQnwBLnjqduhb);
		egeTdzIGHudlgfKlEvWOdRMMLrIl.XzyKQtjTUtOkyLWLbIpJnkSlLGhP(intPtr, (IntPtr)P_1, (int)P_0);
		UpyFOwAuBefdszuZIQnwBLnjqduhb += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
			if (qYwiBoMPHShQjayEoojybBKfstNcA != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(qYwiBoMPHShQjayEoojybBKfstNcA);
			}
		}
	}
}

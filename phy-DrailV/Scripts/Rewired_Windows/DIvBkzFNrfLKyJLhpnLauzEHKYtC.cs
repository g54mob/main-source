using System;
using System.Runtime.InteropServices;

internal class DIvBkzFNrfLKyJLhpnLauzEHKYtC : IDisposable
{
	internal enum rHOdbWdSnMINYiyYLRlQKsPMUXfdA
	{
		Current = 0,
		All = 1
	}

	private delegate IntPtr kcsomLHUfkKgELahWnZlAIkNWfmF(int nCode, IntPtr wParam, IntPtr lParam);

	private const int sDkgenNRlpmMOBdZXpgBMkQiQGJr = 4;

	private IntPtr eFHRRoxCmKOrIEdRKtHJZgFOoQzu = IntPtr.Zero;

	private kcsomLHUfkKgELahWnZlAIkNWfmF xUJODCQXMXpoTxgBFpeQEQxiaOleA;

	private Action<IntPtr, IntPtr, uint, uint> VVJIxyxUwlgAKCHBRxuhvxUZgZQf;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public void AzYzBJlcmiCHLPNQUcdxfYwoglxM(Action<IntPtr, IntPtr, uint, uint> P_0, rHOdbWdSnMINYiyYLRlQKsPMUXfdA P_1)
	{
		VVJIxyxUwlgAKCHBRxuhvxUZgZQf = P_0;
		xUJODCQXMXpoTxgBFpeQEQxiaOleA = VygkVDrPeXOfxkaTorDHyUOJLnEx;
		uint num = 0u;
		if (P_1 == rHOdbWdSnMINYiyYLRlQKsPMUXfdA.Current)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		eFHRRoxCmKOrIEdRKtHJZgFOoQzu = haVLICrGIWCYPgMueQdcoFZEhPGfb(4, xUJODCQXMXpoTxgBFpeQEQxiaOleA, IntPtr.Zero, num);
		_ = eFHRRoxCmKOrIEdRKtHJZgFOoQzu == IntPtr.Zero;
	}

	public void BoVMfxbMzcbKtbQWqjFzAFoettqXA()
	{
		if (!(eFHRRoxCmKOrIEdRKtHJZgFOoQzu == IntPtr.Zero) && udilltRUxxmQsZPRdoDvDcApOzRI(eFHRRoxCmKOrIEdRKtHJZgFOoQzu))
		{
			eFHRRoxCmKOrIEdRKtHJZgFOoQzu = IntPtr.Zero;
		}
	}

	private IntPtr VygkVDrPeXOfxkaTorDHyUOJLnEx(int P_0, IntPtr P_1, IntPtr P_2)
	{
		if (P_0 >= 0)
		{
			int num = 0;
			IntPtr arg = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			IntPtr arg2 = Marshal.ReadIntPtr(P_2, num);
			num += IntPtr.Size;
			uint arg3 = (uint)Marshal.ReadInt32(P_2, num);
			num += 4;
			if (IntPtr.Size == 8)
			{
				num += 4;
			}
			uint arg4 = (uint)Marshal.ReadInt32(P_2, num);
			VVJIxyxUwlgAKCHBRxuhvxUZgZQf(arg, arg2, arg3, arg4);
		}
		return NdHlPBRpBqPiUGGTiKFBtTaCOkgl(eFHRRoxCmKOrIEdRKtHJZgFOoQzu, P_0, P_1, P_2);
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
			BoVMfxbMzcbKtbQWqjFzAFoettqXA();
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr haVLICrGIWCYPgMueQdcoFZEhPGfb(int P_0, kcsomLHUfkKgELahWnZlAIkNWfmF P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool udilltRUxxmQsZPRdoDvDcApOzRI(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr NdHlPBRpBqPiUGGTiKFBtTaCOkgl(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}

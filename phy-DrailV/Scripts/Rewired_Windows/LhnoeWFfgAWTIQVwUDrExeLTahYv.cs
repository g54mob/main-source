using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class LhnoeWFfgAWTIQVwUDrExeLTahYv : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr aplBdpdxGQilXlbPmCeRwGeZutQs(int nCode, IntPtr wParam, IntPtr lParam);

	private struct PUXpqzrhSDrhJyWoBfjogVyoJuK
	{
		public IntPtr mNsdvaHDFKDFahVDlWwmilyWYCai;

		public IntPtr nhvNvffWmDuQXVIedqBDqonyqtfv;

		public uint bkfFviCNWSZPjaePxTIQmEfUevifA;

		public IntPtr XtBzFXxIBbKUbpfkmUoHGQQCWPvu;
	}

	private const int sDkgenNRlpmMOBdZXpgBMkQiQGJr = 4;

	private static LhnoeWFfgAWTIQVwUDrExeLTahYv EToGUeeDPOyHneDVvjOghKGIXvYPB;

	private IntPtr eFHRRoxCmKOrIEdRKtHJZgFOoQzu = IntPtr.Zero;

	private aplBdpdxGQilXlbPmCeRwGeZutQs xUJODCQXMXpoTxgBFpeQEQxiaOleA;

	private Action<TnBAbECWdaPgVNXogndIoAkaXfwP, YvVkQPzMBUosNIBjDcPfESKuCCRN, uint, IntPtr> VVJIxyxUwlgAKCHBRxuhvxUZgZQf;

	private byte[] OLVAdsKjaIEbJhqfnvsKaoGtxAKD;

	private readonly bool hWQcuKIWAfUxKlnIaMbrWrthBhKC;

	private PUXpqzrhSDrhJyWoBfjogVyoJuK IMTvgCHjwfuOMUIPNrELpoJoNOyO;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public LhnoeWFfgAWTIQVwUDrExeLTahYv()
	{
		if (EToGUeeDPOyHneDVvjOghKGIXvYPB != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		EToGUeeDPOyHneDVvjOghKGIXvYPB = this;
		hWQcuKIWAfUxKlnIaMbrWrthBhKC = IntPtr.Size == 8;
		OLVAdsKjaIEbJhqfnvsKaoGtxAKD = new byte[IntPtr.Size * 3 + 4];
	}

	public void AzYzBJlcmiCHLPNQUcdxfYwoglxM(Action<TnBAbECWdaPgVNXogndIoAkaXfwP, YvVkQPzMBUosNIBjDcPfESKuCCRN, uint, IntPtr> P_0, bool P_1)
	{
		VVJIxyxUwlgAKCHBRxuhvxUZgZQf = P_0;
		xUJODCQXMXpoTxgBFpeQEQxiaOleA = VygkVDrPeXOfxkaTorDHyUOJLnEx;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		eFHRRoxCmKOrIEdRKtHJZgFOoQzu = haVLICrGIWCYPgMueQdcoFZEhPGfb(4, xUJODCQXMXpoTxgBFpeQEQxiaOleA, IntPtr.Zero, num);
		if (eFHRRoxCmKOrIEdRKtHJZgFOoQzu == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void BoVMfxbMzcbKtbQWqjFzAFoettqXA()
	{
		if (!(eFHRRoxCmKOrIEdRKtHJZgFOoQzu == IntPtr.Zero))
		{
			if (!udilltRUxxmQsZPRdoDvDcApOzRI(eFHRRoxCmKOrIEdRKtHJZgFOoQzu))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				eFHRRoxCmKOrIEdRKtHJZgFOoQzu = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(aplBdpdxGQilXlbPmCeRwGeZutQs))]
	private static IntPtr VygkVDrPeXOfxkaTorDHyUOJLnEx(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, EToGUeeDPOyHneDVvjOghKGIXvYPB.OLVAdsKjaIEbJhqfnvsKaoGtxAKD, 0, EToGUeeDPOyHneDVvjOghKGIXvYPB.OLVAdsKjaIEbJhqfnvsKaoGtxAKD.Length);
		int num = 0;
		EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.mNsdvaHDFKDFahVDlWwmilyWYCai = TnBAbECWdaPgVNXogndIoAkaXfwP.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(TnBAbECWdaPgVNXogndIoAkaXfwP.roxDXNunuWegdGGVJoHuwBGRcdSk(EToGUeeDPOyHneDVvjOghKGIXvYPB.OLVAdsKjaIEbJhqfnvsKaoGtxAKD, num));
		num += TnBAbECWdaPgVNXogndIoAkaXfwP.TnbqoUvYgoTtgZoGauUtjgKQTcti;
		EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.nhvNvffWmDuQXVIedqBDqonyqtfv = YvVkQPzMBUosNIBjDcPfESKuCCRN.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(YvVkQPzMBUosNIBjDcPfESKuCCRN.roxDXNunuWegdGGVJoHuwBGRcdSk(EToGUeeDPOyHneDVvjOghKGIXvYPB.OLVAdsKjaIEbJhqfnvsKaoGtxAKD, num));
		num += YvVkQPzMBUosNIBjDcPfESKuCCRN.TnbqoUvYgoTtgZoGauUtjgKQTcti;
		EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.bkfFviCNWSZPjaePxTIQmEfUevifA = BitConverter.ToUInt32(EToGUeeDPOyHneDVvjOghKGIXvYPB.OLVAdsKjaIEbJhqfnvsKaoGtxAKD, num);
		num += 4;
		if (EToGUeeDPOyHneDVvjOghKGIXvYPB.hWQcuKIWAfUxKlnIaMbrWrthBhKC)
		{
			EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.XtBzFXxIBbKUbpfkmUoHGQQCWPvu = new IntPtr(BitConverter.ToInt32(EToGUeeDPOyHneDVvjOghKGIXvYPB.OLVAdsKjaIEbJhqfnvsKaoGtxAKD, num + 4));
		}
		else
		{
			EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.XtBzFXxIBbKUbpfkmUoHGQQCWPvu = new IntPtr(BitConverter.ToInt32(EToGUeeDPOyHneDVvjOghKGIXvYPB.OLVAdsKjaIEbJhqfnvsKaoGtxAKD, num));
		}
		if (P_0 >= 0)
		{
			EToGUeeDPOyHneDVvjOghKGIXvYPB.VVJIxyxUwlgAKCHBRxuhvxUZgZQf(TnBAbECWdaPgVNXogndIoAkaXfwP.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.mNsdvaHDFKDFahVDlWwmilyWYCai), YvVkQPzMBUosNIBjDcPfESKuCCRN.bPhBTDiXwPSGeHgqUdzKHurTqKRxA(EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.nhvNvffWmDuQXVIedqBDqonyqtfv), EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.bkfFviCNWSZPjaePxTIQmEfUevifA, EToGUeeDPOyHneDVvjOghKGIXvYPB.IMTvgCHjwfuOMUIPNrELpoJoNOyO.XtBzFXxIBbKUbpfkmUoHGQQCWPvu);
		}
		return NdHlPBRpBqPiUGGTiKFBtTaCOkgl(EToGUeeDPOyHneDVvjOghKGIXvYPB.eFHRRoxCmKOrIEdRKtHJZgFOoQzu, P_0, P_1, P_2);
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
			if (EToGUeeDPOyHneDVvjOghKGIXvYPB == this)
			{
				EToGUeeDPOyHneDVvjOghKGIXvYPB = null;
			}
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr haVLICrGIWCYPgMueQdcoFZEhPGfb(int P_0, aplBdpdxGQilXlbPmCeRwGeZutQs P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool udilltRUxxmQsZPRdoDvDcApOzRI(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr NdHlPBRpBqPiUGGTiKFBtTaCOkgl(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}

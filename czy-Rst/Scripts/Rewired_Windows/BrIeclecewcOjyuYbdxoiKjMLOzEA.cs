using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class BrIeclecewcOjyuYbdxoiKjMLOzEA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr kfFMTxebLiFeikyMbvgVmmpeETUbb(int nCode, IntPtr wParam, IntPtr lParam);

	private struct nnubkVBRYmFzlnfySsIpiiFlHqitA
	{
		public IntPtr aCeXgfuiimXEHhMCxfECVWPIhRkaA;

		public IntPtr OxndDcHZhpqBSTgXHeLoEmwJsfO;

		public uint ojirtVHcslAhcBjeBXXosyBiaesHA;

		public IntPtr SqNOjJbqTeNVnLJzIwgJmtWSBLTe;
	}

	private const int livvDzjLbZAMlrlrGRqKNokTaFRm = 4;

	private static BrIeclecewcOjyuYbdxoiKjMLOzEA VCuEkLvdXMyqXkWlBUYZQSjpIiTC;

	private IntPtr BMjQtjsxGTOyAvpDqYYDwBJlwkcG = IntPtr.Zero;

	private kfFMTxebLiFeikyMbvgVmmpeETUbb yxqThEXWTKNkcdCgzdkjlhYwdlGF;

	private Action<LEuvDhxKvWdNgdGKNNakDiKtAuJK, OyupQaMYRgpbewATwEdBKrofApgMA, uint, IntPtr> HGVcbiianosltYrWbQFjIiGqpgsm;

	private byte[] VMSeqiHplAAgVEvLdJxLyjYBwHQlA;

	private readonly bool TUudqfCtgEzRsSPAaMqJDwrOeEoPA;

	private nnubkVBRYmFzlnfySsIpiiFlHqitA GrfYkNYHlnjABbojKkbWYHCShFfab;

	private bool ZFODvaZRHkxoydSrDeDrEClIoOlA;

	public BrIeclecewcOjyuYbdxoiKjMLOzEA()
	{
		if (VCuEkLvdXMyqXkWlBUYZQSjpIiTC != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		VCuEkLvdXMyqXkWlBUYZQSjpIiTC = this;
		TUudqfCtgEzRsSPAaMqJDwrOeEoPA = IntPtr.Size == 8;
		VMSeqiHplAAgVEvLdJxLyjYBwHQlA = new byte[IntPtr.Size * 3 + 4];
	}

	public void AlnfUMestYPkBhNwHqnljpYcdWiwB(Action<LEuvDhxKvWdNgdGKNNakDiKtAuJK, OyupQaMYRgpbewATwEdBKrofApgMA, uint, IntPtr> P_0, bool P_1)
	{
		HGVcbiianosltYrWbQFjIiGqpgsm = P_0;
		yxqThEXWTKNkcdCgzdkjlhYwdlGF = hvpBEYaUCTqYRYWDzgOXYVIagRZAA;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		BMjQtjsxGTOyAvpDqYYDwBJlwkcG = bYqaKggsPJucNVsyQDXddBFaFfkH(4, yxqThEXWTKNkcdCgzdkjlhYwdlGF, IntPtr.Zero, num);
		if (BMjQtjsxGTOyAvpDqYYDwBJlwkcG == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void iyiGIeFVXDDjWBZgdHRxqUkBWpeYA()
	{
		if (!(BMjQtjsxGTOyAvpDqYYDwBJlwkcG == IntPtr.Zero))
		{
			if (!uQTtwAtFfzdmSkrFzvVgoHLwLsPx(BMjQtjsxGTOyAvpDqYYDwBJlwkcG))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				BMjQtjsxGTOyAvpDqYYDwBJlwkcG = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(kfFMTxebLiFeikyMbvgVmmpeETUbb))]
	private static IntPtr hvpBEYaUCTqYRYWDzgOXYVIagRZAA(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, VCuEkLvdXMyqXkWlBUYZQSjpIiTC.VMSeqiHplAAgVEvLdJxLyjYBwHQlA, 0, VCuEkLvdXMyqXkWlBUYZQSjpIiTC.VMSeqiHplAAgVEvLdJxLyjYBwHQlA.Length);
		int num = 0;
		VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.aCeXgfuiimXEHhMCxfECVWPIhRkaA = LEuvDhxKvWdNgdGKNNakDiKtAuJK.rhYgDeOYoIoVxokcikUMkMqJbQWdA(LEuvDhxKvWdNgdGKNNakDiKtAuJK.yqUNbqQzYQvRWeGApbcQbcevGbdU(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.VMSeqiHplAAgVEvLdJxLyjYBwHQlA, num));
		num += LEuvDhxKvWdNgdGKNNakDiKtAuJK.RPJdODlvWmemfFrsNAabNYyROBedA;
		VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.OxndDcHZhpqBSTgXHeLoEmwJsfO = OyupQaMYRgpbewATwEdBKrofApgMA.keuVtMlUSeULteexuLaYlQNpVhPS(OyupQaMYRgpbewATwEdBKrofApgMA.BKdFFeNNrUDfbtBIanUHRHljbpXDA(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.VMSeqiHplAAgVEvLdJxLyjYBwHQlA, num));
		num += OyupQaMYRgpbewATwEdBKrofApgMA.gwNfiHhwpjqGhQTcSgExWwtZloXG;
		VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.ojirtVHcslAhcBjeBXXosyBiaesHA = BitConverter.ToUInt32(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.VMSeqiHplAAgVEvLdJxLyjYBwHQlA, num);
		num += 4;
		if (VCuEkLvdXMyqXkWlBUYZQSjpIiTC.TUudqfCtgEzRsSPAaMqJDwrOeEoPA)
		{
			VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.SqNOjJbqTeNVnLJzIwgJmtWSBLTe = new IntPtr(BitConverter.ToInt32(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.VMSeqiHplAAgVEvLdJxLyjYBwHQlA, num + 4));
		}
		else
		{
			VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.SqNOjJbqTeNVnLJzIwgJmtWSBLTe = new IntPtr(BitConverter.ToInt32(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.VMSeqiHplAAgVEvLdJxLyjYBwHQlA, num));
		}
		if (P_0 >= 0)
		{
			VCuEkLvdXMyqXkWlBUYZQSjpIiTC.HGVcbiianosltYrWbQFjIiGqpgsm(LEuvDhxKvWdNgdGKNNakDiKtAuJK.textmLTcqVwANsHtDDZcjbwEGxLO(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.aCeXgfuiimXEHhMCxfECVWPIhRkaA), OyupQaMYRgpbewATwEdBKrofApgMA.TtPyHegXoNSjezueuvsQIWYTljSQ(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.OxndDcHZhpqBSTgXHeLoEmwJsfO), VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.ojirtVHcslAhcBjeBXXosyBiaesHA, VCuEkLvdXMyqXkWlBUYZQSjpIiTC.GrfYkNYHlnjABbojKkbWYHCShFfab.SqNOjJbqTeNVnLJzIwgJmtWSBLTe);
		}
		return DOWNWNpRUESOliMjxekBbPJOYMauA(VCuEkLvdXMyqXkWlBUYZQSjpIiTC.BMjQtjsxGTOyAvpDqYYDwBJlwkcG, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		BGcDjOeQEYCCIfRwglFZFRopoaYic(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void sObyYAxLlJWuBcsdmnNzZwcUMKQd()
	{
		try
		{
			BGcDjOeQEYCCIfRwglFZFRopoaYic(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void BGcDjOeQEYCCIfRwglFZFRopoaYic(bool P_0)
	{
		if (!ZFODvaZRHkxoydSrDeDrEClIoOlA)
		{
			iyiGIeFVXDDjWBZgdHRxqUkBWpeYA();
			if (VCuEkLvdXMyqXkWlBUYZQSjpIiTC == this)
			{
				VCuEkLvdXMyqXkWlBUYZQSjpIiTC = null;
			}
			ZFODvaZRHkxoydSrDeDrEClIoOlA = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr bYqaKggsPJucNVsyQDXddBFaFfkH(int P_0, kfFMTxebLiFeikyMbvgVmmpeETUbb P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool uQTtwAtFfzdmSkrFzvVgoHLwLsPx(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr DOWNWNpRUESOliMjxekBbPJOYMauA(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}

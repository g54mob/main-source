using System;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Attributes;

internal class iSBmuPTVuXorzAdPnEFtEYVlNIoeA : IDisposable
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr CArvdpbNrpOilDPgsEDpEfprHhFeA(int nCode, IntPtr wParam, IntPtr lParam);

	private struct aHovfhSMrrJRWflfegWtjyBYbOFK
	{
		public IntPtr AeUFTfFfnXmDYBqFGNubURPeNNZnB;

		public IntPtr aorrKDjHNZsslERXseubSwNfsWKn;

		public uint WStNtkQXfHEQQmfIhktbpvCCOqyu;

		public IntPtr upgvjqkQfOJkkKiDWHuXIUZBKeJh;
	}

	private const int DHteXHYXtsBWDYMVCVNHPcwsyzdJ = 4;

	private static iSBmuPTVuXorzAdPnEFtEYVlNIoeA heROkWREmBJbplBdYBrsAWSyixjW;

	private IntPtr TIJeWBqbOrtzQdqnbXeWmJyNdbfE = IntPtr.Zero;

	private CArvdpbNrpOilDPgsEDpEfprHhFeA URBcYlZGTrsCPxOYrIVlLnAxLsdh;

	private Action<hcPVReJyQiArmIHbOVqOGewAPSMF, SfqsPVLmRZgSrVufaicZklrTKZnE, uint, IntPtr> BtjGXNkFEuDfwdUKqFxKDFRoyVvbA;

	private byte[] RirLhxxQWdgBXdKmIOfrjGztmufG;

	private readonly bool KkHLCAwkBzTIUMVCKngZNcNoHLKN;

	private aHovfhSMrrJRWflfegWtjyBYbOFK nscclYHSRVevLHWrIOFTkDirbuWDA;

	private bool OlsgWpSLGORhPWMUNUdimwJYnjXy;

	public iSBmuPTVuXorzAdPnEFtEYVlNIoeA()
	{
		if (heROkWREmBJbplBdYBrsAWSyixjW != null)
		{
			throw new Exception("Singleton instance already exists!");
		}
		heROkWREmBJbplBdYBrsAWSyixjW = this;
		KkHLCAwkBzTIUMVCKngZNcNoHLKN = IntPtr.Size == 8;
		RirLhxxQWdgBXdKmIOfrjGztmufG = new byte[IntPtr.Size * 3 + 4];
	}

	public void LoAluUeLtlvdhgnFWegVTDIwLOWC(Action<hcPVReJyQiArmIHbOVqOGewAPSMF, SfqsPVLmRZgSrVufaicZklrTKZnE, uint, IntPtr> P_0, bool P_1)
	{
		BtjGXNkFEuDfwdUKqFxKDFRoyVvbA = P_0;
		URBcYlZGTrsCPxOYrIVlLnAxLsdh = pXHfJqUiQiIFraDckiZLfxlOUNoV;
		uint num = 0u;
		if (P_1)
		{
			num = (uint)AppDomain.GetCurrentThreadId();
		}
		TIJeWBqbOrtzQdqnbXeWmJyNdbfE = grJPbzfLmOHHQDQHsiroZCHyDwTL(4, URBcYlZGTrsCPxOYrIVlLnAxLsdh, IntPtr.Zero, num);
		if (TIJeWBqbOrtzQdqnbXeWmJyNdbfE == IntPtr.Zero)
		{
			Logger.LogError("SetWindowsHookEx Failed");
		}
	}

	public void GXbGWMejSYaTFGxntebkYCBXpiUaA()
	{
		if (!(TIJeWBqbOrtzQdqnbXeWmJyNdbfE == IntPtr.Zero))
		{
			if (!EWQSALfzdINwYhMqtHTfmQoaVQZi(TIJeWBqbOrtzQdqnbXeWmJyNdbfE))
			{
				Logger.LogError("UnhookWindowsHookEx Failed");
			}
			else
			{
				TIJeWBqbOrtzQdqnbXeWmJyNdbfE = IntPtr.Zero;
			}
		}
	}

	[MonoPInvokeCallback(typeof(CArvdpbNrpOilDPgsEDpEfprHhFeA))]
	private static IntPtr pXHfJqUiQiIFraDckiZLfxlOUNoV(int P_0, IntPtr P_1, IntPtr P_2)
	{
		Marshal.Copy(P_2, heROkWREmBJbplBdYBrsAWSyixjW.RirLhxxQWdgBXdKmIOfrjGztmufG, 0, heROkWREmBJbplBdYBrsAWSyixjW.RirLhxxQWdgBXdKmIOfrjGztmufG.Length);
		int num = 0;
		heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.AeUFTfFfnXmDYBqFGNubURPeNNZnB = hcPVReJyQiArmIHbOVqOGewAPSMF.eaeNsXREAABrOFAtpPSWJrzJcLFe(hcPVReJyQiArmIHbOVqOGewAPSMF.FKAjBPJoaIKMTxDdJfTzVdirMwAV(heROkWREmBJbplBdYBrsAWSyixjW.RirLhxxQWdgBXdKmIOfrjGztmufG, num));
		num += hcPVReJyQiArmIHbOVqOGewAPSMF.ymhBAEaPjmNhyGVrYXEalKTogmXeA;
		heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.aorrKDjHNZsslERXseubSwNfsWKn = SfqsPVLmRZgSrVufaicZklrTKZnE.DmZETaZVlmwbDRShBfAZkMGinPLN(SfqsPVLmRZgSrVufaicZklrTKZnE.DISWPwjNJfzWNrSbBaIVrRhoAaAX(heROkWREmBJbplBdYBrsAWSyixjW.RirLhxxQWdgBXdKmIOfrjGztmufG, num));
		num += SfqsPVLmRZgSrVufaicZklrTKZnE.SvvBNFKYHNMAheJrAuhnpuarRpsQA;
		heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.WStNtkQXfHEQQmfIhktbpvCCOqyu = BitConverter.ToUInt32(heROkWREmBJbplBdYBrsAWSyixjW.RirLhxxQWdgBXdKmIOfrjGztmufG, num);
		num += 4;
		if (heROkWREmBJbplBdYBrsAWSyixjW.KkHLCAwkBzTIUMVCKngZNcNoHLKN)
		{
			heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.upgvjqkQfOJkkKiDWHuXIUZBKeJh = new IntPtr(BitConverter.ToInt32(heROkWREmBJbplBdYBrsAWSyixjW.RirLhxxQWdgBXdKmIOfrjGztmufG, num + 4));
		}
		else
		{
			heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.upgvjqkQfOJkkKiDWHuXIUZBKeJh = new IntPtr(BitConverter.ToInt32(heROkWREmBJbplBdYBrsAWSyixjW.RirLhxxQWdgBXdKmIOfrjGztmufG, num));
		}
		if (P_0 >= 0)
		{
			heROkWREmBJbplBdYBrsAWSyixjW.BtjGXNkFEuDfwdUKqFxKDFRoyVvbA(hcPVReJyQiArmIHbOVqOGewAPSMF.DNLblbiRZbcAUdOYIybyelqXmcnXB(heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.AeUFTfFfnXmDYBqFGNubURPeNNZnB), SfqsPVLmRZgSrVufaicZklrTKZnE.oOPSXpTSDzhMIfZBiGDTaFGuKlhK(heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.aorrKDjHNZsslERXseubSwNfsWKn), heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.WStNtkQXfHEQQmfIhktbpvCCOqyu, heROkWREmBJbplBdYBrsAWSyixjW.nscclYHSRVevLHWrIOFTkDirbuWDA.upgvjqkQfOJkkKiDWHuXIUZBKeJh);
		}
		return XThDMLcgMhETWIIAzsKNRdRkoRyY(heROkWREmBJbplBdYBrsAWSyixjW.TIJeWBqbOrtzQdqnbXeWmJyNdbfE, P_0, P_1, P_2);
	}

	public void Dispose()
	{
		xcVldSazKhRAfqfxTlgivmslveIR(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void PUnnxGcsgkKLwwSEFSNeKalkBPRG()
	{
		try
		{
			xcVldSazKhRAfqfxTlgivmslveIR(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected virtual void xcVldSazKhRAfqfxTlgivmslveIR(bool P_0)
	{
		if (!OlsgWpSLGORhPWMUNUdimwJYnjXy)
		{
			GXbGWMejSYaTFGxntebkYCBXpiUaA();
			if (heROkWREmBJbplBdYBrsAWSyixjW == this)
			{
				heROkWREmBJbplBdYBrsAWSyixjW = null;
			}
			OlsgWpSLGORhPWMUNUdimwJYnjXy = true;
		}
	}

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "SetWindowsHookEx")]
	private static extern IntPtr grJPbzfLmOHHQDQHsiroZCHyDwTL(int P_0, CArvdpbNrpOilDPgsEDpEfprHhFeA P_1, IntPtr P_2, uint P_3);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "UnhookWindowsHookEx")]
	private static extern bool EWQSALfzdINwYhMqtHTfmQoaVQZi(IntPtr P_0);

	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "CallNextHookEx")]
	private static extern IntPtr XThDMLcgMhETWIIAzsKNRdRkoRyY(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class FgQekEkraYueHKTplGUiEKBfBvOs : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct fLJrHlSvRgDcjJGVFybHGuAjGxKI : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private FgQekEkraYueHKTplGUiEKBfBvOs ieygMOXNGdkMEteRELfzDrdKEUzV;

		private int TPsRSdxnrKoAkDLCsCbkOGsAAweI;

		byte IEnumerator<byte>.Current => ieygMOXNGdkMEteRELfzDrdKEUzV.uqYqDcthJgjuEiLPlHdIjctfnfBg(TPsRSdxnrKoAkDLCsCbkOGsAAweI);

		object IEnumerator.Current => ieygMOXNGdkMEteRELfzDrdKEUzV.uqYqDcthJgjuEiLPlHdIjctfnfBg(TPsRSdxnrKoAkDLCsCbkOGsAAweI);

		public fLJrHlSvRgDcjJGVFybHGuAjGxKI(FgQekEkraYueHKTplGUiEKBfBvOs P_0)
		{
			ieygMOXNGdkMEteRELfzDrdKEUzV = P_0;
			TPsRSdxnrKoAkDLCsCbkOGsAAweI = -1;
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			if (TPsRSdxnrKoAkDLCsCbkOGsAAweI >= ieygMOXNGdkMEteRELfzDrdKEUzV.UALFxyqiGwJateZGaOMlmCXkahgX - 1)
			{
				return false;
			}
			TPsRSdxnrKoAkDLCsCbkOGsAAweI++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			TPsRSdxnrKoAkDLCsCbkOGsAAweI = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int UALFxyqiGwJateZGaOMlmCXkahgX;

	private unsafe byte* mBmayCQbbTcsOqVxCAeTCbgkICxfA;

	public int pOJjeOhZngQfSdHOOtbWpQLjutTT => UALFxyqiGwJateZGaOMlmCXkahgX;

	public unsafe bool JAZhQbcBsWMYFjIraHngHPNmgJRdA
	{
		get
		{
			if (UALFxyqiGwJateZGaOMlmCXkahgX <= 0)
			{
				return true;
			}
			return mBmayCQbbTcsOqVxCAeTCbgkICxfA != null;
		}
	}

	public unsafe byte pZZsjuVxTvmLalxBKSyLDbXbiFaY
	{
		get
		{
			if (P_0 < 0 || P_0 >= UALFxyqiGwJateZGaOMlmCXkahgX)
			{
				throw new IndexOutOfRangeException();
			}
			return mBmayCQbbTcsOqVxCAeTCbgkICxfA[P_0];
		}
		set
		{
			if (num < 0 || num >= UALFxyqiGwJateZGaOMlmCXkahgX)
			{
				throw new IndexOutOfRangeException();
			}
			mBmayCQbbTcsOqVxCAeTCbgkICxfA[num] = b;
		}
	}

	public FgQekEkraYueHKTplGUiEKBfBvOs(int P_0)
	{
		HObVkhugPjZywvpyHuHVOLJentGW(P_0);
	}

	public unsafe FgQekEkraYueHKTplGUiEKBfBvOs(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0.Length);
	}

	public FgQekEkraYueHKTplGUiEKBfBvOs(FgQekEkraYueHKTplGUiEKBfBvOs P_0)
		: this(P_0.UALFxyqiGwJateZGaOMlmCXkahgX)
	{
		P_0.kZOMlFURSmiXJvcDzoVlHeReJQPg(this, 0, P_0.UALFxyqiGwJateZGaOMlmCXkahgX);
	}

	public unsafe FgQekEkraYueHKTplGUiEKBfBvOs(byte* P_0, int P_1)
		: this(P_1)
	{
		YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(P_0, mBmayCQbbTcsOqVxCAeTCbgkICxfA, 0, 0, P_1);
	}

	public unsafe bool AWLCZFrxwgZtIEvYldAVYUeEQBWM(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= UALFxyqiGwJateZGaOMlmCXkahgX || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > UALFxyqiGwJateZGaOMlmCXkahgX || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= UALFxyqiGwJateZGaOMlmCXkahgX || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool kZOMlFURSmiXJvcDzoVlHeReJQPg(FgQekEkraYueHKTplGUiEKBfBvOs P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return AWLCZFrxwgZtIEvYldAVYUeEQBWM(P_0.mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0.UALFxyqiGwJateZGaOMlmCXkahgX, P_1, P_2, P_3);
	}

	public unsafe bool nptIxfMwvhUczsEgrUcATmWVBweh(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= UALFxyqiGwJateZGaOMlmCXkahgX || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > UALFxyqiGwJateZGaOMlmCXkahgX || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= UALFxyqiGwJateZGaOMlmCXkahgX || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool AfGLcgBlPsArKeBPwJyFPPGGLAYd(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 < 0 || P_3 >= P_1)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_4 <= 0 || P_4 > UALFxyqiGwJateZGaOMlmCXkahgX || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_4 + P_3 >= P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool mcPdZZZYiUVxKYoutVHyGQdIjzch(FgQekEkraYueHKTplGUiEKBfBvOs P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return AfGLcgBlPsArKeBPwJyFPPGGLAYd(P_0.mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0.UALFxyqiGwJateZGaOMlmCXkahgX, P_1, P_2, P_3, P_4);
	}

	public unsafe bool LrLStNaUgegcMbRojwXBJZyAHREx(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > UALFxyqiGwJateZGaOMlmCXkahgX || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool aetMfWvhNgNoGwihnfFEeIInkGNX(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= UALFxyqiGwJateZGaOMlmCXkahgX || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			P_3 = UALFxyqiGwJateZGaOMlmCXkahgX - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool yQbjCllelyOvaeadfAqlCfQNbFumA(FgQekEkraYueHKTplGUiEKBfBvOs P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return aetMfWvhNgNoGwihnfFEeIInkGNX(P_0.mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0.UALFxyqiGwJateZGaOMlmCXkahgX, P_1, P_2);
	}

	public unsafe bool VtieIXtsEvlHOvIcuBnmaPbwnODr(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= UALFxyqiGwJateZGaOMlmCXkahgX || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			P_2 = UALFxyqiGwJateZGaOMlmCXkahgX - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool CzaFKADXiEhrtXwlOmqhGBFSCPVCA(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			return false;
		}
		if (P_3 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			P_4 = UALFxyqiGwJateZGaOMlmCXkahgX - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return YeypUSYzjFxvMCDxNtGmgYXVPZRT.CcBZvVACfBcSKwyrnAlMhQJagBzm(mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool xTLYItKSDonOOVJGiVAtJHyBGEFv(FgQekEkraYueHKTplGUiEKBfBvOs P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return CzaFKADXiEhrtXwlOmqhGBFSCPVCA(P_0.mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0.UALFxyqiGwJateZGaOMlmCXkahgX, P_1, P_2, P_3);
	}

	public unsafe bool qHECJEwUIHVKSVGROCDPXbuxktgO(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			return false;
		}
		if (P_2 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 >= UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			P_3 = UALFxyqiGwJateZGaOMlmCXkahgX - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)mBmayCQbbTcsOqVxCAeTCbgkICxfA, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void OyMbFWVMsEaSQDOacDlkrWwVkfis(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (UALFxyqiGwJateZGaOMlmCXkahgX != P_0)
		{
			HObVkhugPjZywvpyHuHVOLJentGW(P_0);
		}
	}

	public unsafe void IfZgZLHLKJaxReyVZAshBlQMJtLu()
	{
		if (UALFxyqiGwJateZGaOMlmCXkahgX != 0 && mBmayCQbbTcsOqVxCAeTCbgkICxfA != null)
		{
			YeypUSYzjFxvMCDxNtGmgYXVPZRT.xbOwmZQwGJcjNgOZBaSqHPiiakDW(mBmayCQbbTcsOqVxCAeTCbgkICxfA, UALFxyqiGwJateZGaOMlmCXkahgX);
		}
	}

	private unsafe void HObVkhugPjZywvpyHuHVOLJentGW(int P_0)
	{
		if (P_0 == UALFxyqiGwJateZGaOMlmCXkahgX)
		{
			IfZgZLHLKJaxReyVZAshBlQMJtLu();
			return;
		}
		if (UALFxyqiGwJateZGaOMlmCXkahgX > 0)
		{
			HzNijSVUpHaQbDhTVfWkPtUMJOgw();
		}
		mBmayCQbbTcsOqVxCAeTCbgkICxfA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (mBmayCQbbTcsOqVxCAeTCbgkICxfA == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		UALFxyqiGwJateZGaOMlmCXkahgX = P_0;
		IfZgZLHLKJaxReyVZAshBlQMJtLu();
	}

	private unsafe void HzNijSVUpHaQbDhTVfWkPtUMJOgw()
	{
		if (mBmayCQbbTcsOqVxCAeTCbgkICxfA != null)
		{
			Marshal.FreeHGlobal((IntPtr)mBmayCQbbTcsOqVxCAeTCbgkICxfA);
		}
		mBmayCQbbTcsOqVxCAeTCbgkICxfA = null;
		UALFxyqiGwJateZGaOMlmCXkahgX = 0;
	}

	public void Dispose()
	{
		RZZDJiPyRGrHNfcSkvHyArWIIvBC(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void GFetNeuPYshbPhgKRrCTgPggmuuG()
	{
		try
		{
			RZZDJiPyRGrHNfcSkvHyArWIIvBC(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void RZZDJiPyRGrHNfcSkvHyArWIIvBC(bool P_0)
	{
		HzNijSVUpHaQbDhTVfWkPtUMJOgw();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new fLJrHlSvRgDcjJGVFybHGuAjGxKI(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new fLJrHlSvRgDcjJGVFybHGuAjGxKI(this);
	}
}

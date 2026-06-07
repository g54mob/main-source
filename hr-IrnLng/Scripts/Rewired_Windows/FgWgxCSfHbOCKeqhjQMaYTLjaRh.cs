using System;
using System.Runtime.CompilerServices;

internal class FgWgxCSfHbOCKeqhjQMaYTLjaRh : xSHRGmoevrIxtWOdFoYGCWpzcJB
{
	protected internal unsafe void* fRSdJIinkkjfuOwZLyQSrdGfQnO;

	[CompilerGenerated]
	private object zmNmkFRObyjKatcIVUVoGZZMJOh;

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return zmNmkFRObyjKatcIVUVoGZZMJOh;
		}
		[CompilerGenerated]
		set
		{
			zmNmkFRObyjKatcIVUVoGZZMJOh = value;
		}
	}

	public unsafe IntPtr NativePointer
	{
		get
		{
			return (IntPtr)fRSdJIinkkjfuOwZLyQSrdGfQnO;
		}
		set
		{
			void* ptr = (void*)value;
			if (fRSdJIinkkjfuOwZLyQSrdGfQnO != ptr)
			{
				hajdtxuRNKFMJtRoePiOlVhbcEI();
				void* ptr2 = fRSdJIinkkjfuOwZLyQSrdGfQnO;
				fRSdJIinkkjfuOwZLyQSrdGfQnO = ptr;
				YjQaFefqGrnqqqeiNUAuRzgYbMt((IntPtr)ptr2);
			}
		}
	}

	public FgWgxCSfHbOCKeqhjQMaYTLjaRh(IntPtr pointer)
	{
		NativePointer = pointer;
	}

	protected FgWgxCSfHbOCKeqhjQMaYTLjaRh()
	{
	}

	public static explicit operator IntPtr(FgWgxCSfHbOCKeqhjQMaYTLjaRh cppObject)
	{
		return cppObject?.NativePointer ?? IntPtr.Zero;
	}

	protected void XNbRORWiJfkdJRTBZLTKNmqvlrp(FgWgxCSfHbOCKeqhjQMaYTLjaRh P_0)
	{
		NativePointer = P_0.NativePointer;
		P_0.NativePointer = IntPtr.Zero;
	}

	protected void XNbRORWiJfkdJRTBZLTKNmqvlrp(IntPtr P_0)
	{
		NativePointer = P_0;
	}

	protected virtual void hajdtxuRNKFMJtRoePiOlVhbcEI()
	{
	}

	protected virtual void YjQaFefqGrnqqqeiNUAuRzgYbMt(IntPtr P_0)
	{
	}

	protected override void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
	}

	public static T WxliJmcswjjTPTiIBOtybNDHdQxj<T>(IntPtr P_0) where T : FgWgxCSfHbOCKeqhjQMaYTLjaRh
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return null;
	}

	internal static T tJhGdlzLWNGqXPfwgQxBwgHbCTo<T>(IntPtr P_0)
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return (T)(object)null;
	}

	public static IntPtr TxlefAHlXeJQpHOXLtdLlcbBdes<TCallback>(UjWdPKrIisWRvtOtTtqXWszemnj P_0) where TCallback : UjWdPKrIisWRvtOtTtqXWszemnj
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		if (P_0 is FgWgxCSfHbOCKeqhjQMaYTLjaRh)
		{
			return ((FgWgxCSfHbOCKeqhjQMaYTLjaRh)P_0).NativePointer;
		}
		zhfPNWSRlKRFPvTawRzkutbfsyG zhfPNWSRlKRFPvTawRzkutbfsyG2 = P_0.Shadow as zhfPNWSRlKRFPvTawRzkutbfsyG;
		if (zhfPNWSRlKRFPvTawRzkutbfsyG2 == null)
		{
			zhfPNWSRlKRFPvTawRzkutbfsyG2 = new zhfPNWSRlKRFPvTawRzkutbfsyG();
			zhfPNWSRlKRFPvTawRzkutbfsyG2.BVmTKMsAVVqdkfwNjSwlgNFzTsh(P_0);
		}
		return zhfPNWSRlKRFPvTawRzkutbfsyG2.PYgQmrazoUqWjrASzZcCXOaxeza(typeof(TCallback));
	}
}

using System;
using System.Runtime.CompilerServices;

internal class CndQdhRoXYCqAIOwkhIvRMCMVjY : cmmTIRbfTUTdtkqdISXVDgTWEci
{
	protected internal unsafe void* oQrDIzabSXnJeReNAUCNWaVKrkpV;

	[CompilerGenerated]
	private object cusyraYkNHEZcBcSOdYpJJQzVMK;

	public object Tag
	{
		[CompilerGenerated]
		get
		{
			return cusyraYkNHEZcBcSOdYpJJQzVMK;
		}
		[CompilerGenerated]
		set
		{
			cusyraYkNHEZcBcSOdYpJJQzVMK = value;
		}
	}

	public unsafe IntPtr NativePointer
	{
		get
		{
			return (IntPtr)oQrDIzabSXnJeReNAUCNWaVKrkpV;
		}
		set
		{
			void* ptr = (void*)value;
			if (oQrDIzabSXnJeReNAUCNWaVKrkpV != ptr)
			{
				NativePointerUpdating();
				void* ptr2 = oQrDIzabSXnJeReNAUCNWaVKrkpV;
				oQrDIzabSXnJeReNAUCNWaVKrkpV = ptr;
				NativePointerUpdated((IntPtr)ptr2);
			}
		}
	}

	public CndQdhRoXYCqAIOwkhIvRMCMVjY(IntPtr pointer)
	{
		NativePointer = pointer;
	}

	protected CndQdhRoXYCqAIOwkhIvRMCMVjY()
	{
	}

	public static explicit operator IntPtr(CndQdhRoXYCqAIOwkhIvRMCMVjY cppObject)
	{
		if (cppObject != null)
		{
			return cppObject.NativePointer;
		}
		return IntPtr.Zero;
	}

	protected void EMYNCgPLdQyYFxBZATDRQLfGByW(CndQdhRoXYCqAIOwkhIvRMCMVjY P_0)
	{
		NativePointer = P_0.NativePointer;
		P_0.NativePointer = IntPtr.Zero;
	}

	protected void EMYNCgPLdQyYFxBZATDRQLfGByW(IntPtr P_0)
	{
		NativePointer = P_0;
	}

	protected virtual void NativePointerUpdating()
	{
	}

	protected virtual void NativePointerUpdated(IntPtr P_0)
	{
	}

	protected override void Dispose(bool P_0)
	{
	}

	public static T ZScGNopAWKvTUpCYGztYcWeFDEh<T>(IntPtr P_0) where T : CndQdhRoXYCqAIOwkhIvRMCMVjY
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return null;
	}

	internal static T ckWaMRwiVoiNozoedQSIbSIESVJ<T>(IntPtr P_0)
	{
		if (!(P_0 == IntPtr.Zero))
		{
			return (T)Activator.CreateInstance(typeof(T), P_0);
		}
		return (T)(object)null;
	}

	public static IntPtr QxCYddYaxFOdxdhOGstSgUmktsD<TCallback>(VJvDCfEiULZhxmTbSdcYPJiPZwU P_0) where TCallback : VJvDCfEiULZhxmTbSdcYPJiPZwU
	{
		if (P_0 == null)
		{
			return IntPtr.Zero;
		}
		if (P_0 is CndQdhRoXYCqAIOwkhIvRMCMVjY)
		{
			return ((CndQdhRoXYCqAIOwkhIvRMCMVjY)P_0).NativePointer;
		}
		uIUGPlDgBlthVDXefxRhzAiUrij uIUGPlDgBlthVDXefxRhzAiUrij2 = P_0.Shadow as uIUGPlDgBlthVDXefxRhzAiUrij;
		if (uIUGPlDgBlthVDXefxRhzAiUrij2 == null)
		{
			uIUGPlDgBlthVDXefxRhzAiUrij2 = new uIUGPlDgBlthVDXefxRhzAiUrij();
			uIUGPlDgBlthVDXefxRhzAiUrij2.GVPNrpnUrcRcuBVNsoUmnQYWdWW(P_0);
		}
		return uIUGPlDgBlthVDXefxRhzAiUrij2.QYDfLSnALpsGfPExecRVCpKKeSN(typeof(TCallback));
	}
}

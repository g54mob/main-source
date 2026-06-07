using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class mXwMxWdFMluqLBsXXlIeDjVvdfc
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int vUsHTlDDYFxYKqKriBjvunbdwAr(void* deviceInstance, IntPtr data);

	private readonly IntPtr oQrDIzabSXnJeReNAUCNWaVKrkpV;

	private readonly vUsHTlDDYFxYKqKriBjvunbdwAr gcSCuQrNDUgbabBuaIMfeSRwgnvd;

	[CompilerGenerated]
	private List<zrEGTrpSWmDsDgePoqRmKRnUzSU> DczLlkfeGxiENjCpMtVQpQGyXVUH;

	public IntPtr NativePointer
	{
		get
		{
			return oQrDIzabSXnJeReNAUCNWaVKrkpV;
		}
	}

	public List<zrEGTrpSWmDsDgePoqRmKRnUzSU> Effects
	{
		[CompilerGenerated]
		get
		{
			return DczLlkfeGxiENjCpMtVQpQGyXVUH;
		}
		[CompilerGenerated]
		private set
		{
			DczLlkfeGxiENjCpMtVQpQGyXVUH = value;
		}
	}

	public unsafe mXwMxWdFMluqLBsXXlIeDjVvdfc()
	{
		gcSCuQrNDUgbabBuaIMfeSRwgnvd = aKNliUIPfYalsPJMzhZGNzedMMA;
		oQrDIzabSXnJeReNAUCNWaVKrkpV = Marshal.GetFunctionPointerForDelegate((Delegate)gcSCuQrNDUgbabBuaIMfeSRwgnvd);
		Effects = new List<zrEGTrpSWmDsDgePoqRmKRnUzSU>();
	}

	[MonoPInvokeCallback(typeof(vUsHTlDDYFxYKqKriBjvunbdwAr))]
	private unsafe static int aKNliUIPfYalsPJMzhZGNzedMMA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		mXwMxWdFMluqLBsXXlIeDjVvdfc instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<mXwMxWdFMluqLBsXXlIeDjVvdfc>(instanceId, out instance))
		{
			return 1;
		}
		zrEGTrpSWmDsDgePoqRmKRnUzSU item = new zrEGTrpSWmDsDgePoqRmKRnUzSU((IntPtr)P_0);
		instance.Effects.Add(item);
		return 1;
	}
}

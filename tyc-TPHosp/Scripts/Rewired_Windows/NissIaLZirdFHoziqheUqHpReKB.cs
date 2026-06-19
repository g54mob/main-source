using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class NissIaLZirdFHoziqheUqHpReKB
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int gVUMJyDrAhoSezVQbJCsDAhoHKy(void* deviceInstance, IntPtr data);

	private readonly IntPtr gBbLrXrPAfTbPiLRobgphErqzjOU;

	private readonly gVUMJyDrAhoSezVQbJCsDAhoHKy iWJLmGxRkATRajaGxiTgAzQvcIb;

	[CompilerGenerated]
	private List<rxIioKPHJsrewHFOHBkKEKQgeMHd> sFuwqEBjvuFGXTXuivaRzXirOFT;

	public IntPtr NativePointer => gBbLrXrPAfTbPiLRobgphErqzjOU;

	public List<rxIioKPHJsrewHFOHBkKEKQgeMHd> EffectInfos
	{
		[CompilerGenerated]
		get
		{
			return sFuwqEBjvuFGXTXuivaRzXirOFT;
		}
		[CompilerGenerated]
		private set
		{
			sFuwqEBjvuFGXTXuivaRzXirOFT = value;
		}
	}

	public unsafe NissIaLZirdFHoziqheUqHpReKB()
	{
		iWJLmGxRkATRajaGxiTgAzQvcIb = jscUCyzwRGjCWznCekEoTJIJeZk;
		gBbLrXrPAfTbPiLRobgphErqzjOU = Marshal.GetFunctionPointerForDelegate((Delegate)iWJLmGxRkATRajaGxiTgAzQvcIb);
		EffectInfos = new List<rxIioKPHJsrewHFOHBkKEKQgeMHd>();
	}

	[MonoPInvokeCallback(typeof(gVUMJyDrAhoSezVQbJCsDAhoHKy))]
	private unsafe static int jscUCyzwRGjCWznCekEoTJIJeZk(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<NissIaLZirdFHoziqheUqHpReKB>(instanceId, out var instance))
		{
			return 1;
		}
		rxIioKPHJsrewHFOHBkKEKQgeMHd rxIioKPHJsrewHFOHBkKEKQgeMHd2 = new rxIioKPHJsrewHFOHBkKEKQgeMHd();
		rxIioKPHJsrewHFOHBkKEKQgeMHd2.SZrGrLlmHSqjecDGhpZXEmGQmZZ(ref *(rxIioKPHJsrewHFOHBkKEKQgeMHd.NPTZXGeQqZbGSlzBIgFefPiuIPr*)P_0);
		instance.EffectInfos.Add(rxIioKPHJsrewHFOHBkKEKQgeMHd2);
		return 1;
	}
}

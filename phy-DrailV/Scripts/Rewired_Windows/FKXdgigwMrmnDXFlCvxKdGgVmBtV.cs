using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class FKXdgigwMrmnDXFlCvxKdGgVmBtV
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int EsViDDIMcjMmVmXHJmFzvozesJdw(void* deviceInstance, IntPtr data);

	private readonly IntPtr EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	private readonly EsViDDIMcjMmVmXHJmFzvozesJdw SmCbULdHvFnyCWdLLpSYHEPsMuCV;

	[CompilerGenerated]
	private List<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> KdwPkyMPQhTkNZHaiXndQGVKXTMy;

	public IntPtr GMaPHoiZAJyngdXeSoVFwLOeWHKm => EetGmuBhqQLYShPkdlGmBVJKSvCAb;

	public List<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> lJEElwWCSJibTpKRfAjsxJzExiUx
	{
		[CompilerGenerated]
		get
		{
			return KdwPkyMPQhTkNZHaiXndQGVKXTMy;
		}
		[CompilerGenerated]
		private set
		{
			KdwPkyMPQhTkNZHaiXndQGVKXTMy = kdwPkyMPQhTkNZHaiXndQGVKXTMy;
		}
	}

	public unsafe FKXdgigwMrmnDXFlCvxKdGgVmBtV()
	{
		SmCbULdHvFnyCWdLLpSYHEPsMuCV = VZOTPbDwRYryMlBqLFLwwGYXtzDR;
		EetGmuBhqQLYShPkdlGmBVJKSvCAb = Marshal.GetFunctionPointerForDelegate((Delegate)SmCbULdHvFnyCWdLLpSYHEPsMuCV);
		lJEElwWCSJibTpKRfAjsxJzExiUx = new List<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA>();
	}

	[MonoPInvokeCallback(typeof(EsViDDIMcjMmVmXHJmFzvozesJdw))]
	private unsafe static int VZOTPbDwRYryMlBqLFLwwGYXtzDR(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<FKXdgigwMrmnDXFlCvxKdGgVmBtV>(instanceId, out var instance))
		{
			return 1;
		}
		VrUjHkyKwlgfxGiNlmxxLiWLUcYKA vrUjHkyKwlgfxGiNlmxxLiWLUcYKA = new VrUjHkyKwlgfxGiNlmxxLiWLUcYKA();
		vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.ubvFUqtErpTMhZPdcRbSTBcoJcFu(ref *(VrUjHkyKwlgfxGiNlmxxLiWLUcYKA.IacdTewioIKxUnYMxBjxVjuABGpk*)P_0);
		instance.lJEElwWCSJibTpKRfAjsxJzExiUx.Add(vrUjHkyKwlgfxGiNlmxxLiWLUcYKA);
		return 1;
	}
}

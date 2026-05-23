using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class aWYauuILSpfXYKFzcfMqIXHZhSe
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int iIeodEaJEWAaYWjmeCffQxqEIRt(void* deviceInstance, IntPtr data);

	private readonly IntPtr gCHLRLMMTROdfhHdjSeFpmVcoRj;

	private readonly iIeodEaJEWAaYWjmeCffQxqEIRt uQapxaGEDQOujgaUJWGffIJYTlv;

	[CompilerGenerated]
	private List<xBiEjBKnCsnOWnQvBLTcHMpujVI> PpZmAAQMYrVxITVAbRPGFKRUDiE;

	public IntPtr NativePointer
	{
		get
		{
			return gCHLRLMMTROdfhHdjSeFpmVcoRj;
		}
	}

	public List<xBiEjBKnCsnOWnQvBLTcHMpujVI> Effects
	{
		[CompilerGenerated]
		get
		{
			return PpZmAAQMYrVxITVAbRPGFKRUDiE;
		}
		[CompilerGenerated]
		private set
		{
			PpZmAAQMYrVxITVAbRPGFKRUDiE = value;
		}
	}

	public unsafe aWYauuILSpfXYKFzcfMqIXHZhSe()
	{
		uQapxaGEDQOujgaUJWGffIJYTlv = skdBtwfztIJkzCEgYfTWfWwLPCYE;
		gCHLRLMMTROdfhHdjSeFpmVcoRj = Marshal.GetFunctionPointerForDelegate(uQapxaGEDQOujgaUJWGffIJYTlv);
		Effects = new List<xBiEjBKnCsnOWnQvBLTcHMpujVI>();
	}

	[MonoPInvokeCallback(typeof(iIeodEaJEWAaYWjmeCffQxqEIRt))]
	private unsafe static int skdBtwfztIJkzCEgYfTWfWwLPCYE(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		aWYauuILSpfXYKFzcfMqIXHZhSe instance;
		if (!ObjectInstanceTracker.Default.TryGetInstance<aWYauuILSpfXYKFzcfMqIXHZhSe>(instanceId, out instance))
		{
			return 1;
		}
		xBiEjBKnCsnOWnQvBLTcHMpujVI item = new xBiEjBKnCsnOWnQvBLTcHMpujVI((IntPtr)P_0);
		instance.Effects.Add(item);
		return 1;
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class uxawxWVlzdBVtnkhqAxlfwHWDeHM
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int gBGdyDNSDWcNMHbMUaZGzTRGtNcI(void* deviceInstance, IntPtr data);

	private readonly IntPtr gBbLrXrPAfTbPiLRobgphErqzjOU;

	private readonly gBGdyDNSDWcNMHbMUaZGzTRGtNcI iWJLmGxRkATRajaGxiTgAzQvcIb;

	[CompilerGenerated]
	private List<QFSOxzhPpyaLqYMwQgtmifgAXZG> jxiNxzNwJESbRliQjcnetLttpyV;

	public IntPtr NativePointer => gBbLrXrPAfTbPiLRobgphErqzjOU;

	public List<QFSOxzhPpyaLqYMwQgtmifgAXZG> Objects
	{
		[CompilerGenerated]
		get
		{
			return jxiNxzNwJESbRliQjcnetLttpyV;
		}
		[CompilerGenerated]
		private set
		{
			jxiNxzNwJESbRliQjcnetLttpyV = value;
		}
	}

	public unsafe uxawxWVlzdBVtnkhqAxlfwHWDeHM()
	{
		iWJLmGxRkATRajaGxiTgAzQvcIb = ywLvzbkdvFnZkuZyESXlguazoKl;
		gBbLrXrPAfTbPiLRobgphErqzjOU = Marshal.GetFunctionPointerForDelegate((Delegate)iWJLmGxRkATRajaGxiTgAzQvcIb);
		Objects = new List<QFSOxzhPpyaLqYMwQgtmifgAXZG>();
	}

	[MonoPInvokeCallback(typeof(gBGdyDNSDWcNMHbMUaZGzTRGtNcI))]
	private unsafe static int ywLvzbkdvFnZkuZyESXlguazoKl(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<uxawxWVlzdBVtnkhqAxlfwHWDeHM>(instanceId, out var instance))
		{
			return 1;
		}
		QFSOxzhPpyaLqYMwQgtmifgAXZG qFSOxzhPpyaLqYMwQgtmifgAXZG = new QFSOxzhPpyaLqYMwQgtmifgAXZG();
		qFSOxzhPpyaLqYMwQgtmifgAXZG.SZrGrLlmHSqjecDGhpZXEmGQmZZ(ref *(QFSOxzhPpyaLqYMwQgtmifgAXZG.QEsufglotPefkYnVXiZFASJHIbf*)P_0);
		instance.Objects.Add(qFSOxzhPpyaLqYMwQgtmifgAXZG);
		return 1;
	}
}

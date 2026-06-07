using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class pSLwPncgyQSJNlwHKnjrUwAYqIB
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int hvXFxawhuVmzsSEgxJloQhtTZlU(void* deviceInstance, IntPtr data);

	private readonly IntPtr fRSdJIinkkjfuOwZLyQSrdGfQnO;

	private readonly hvXFxawhuVmzsSEgxJloQhtTZlU tIfcxbGihlHDauFsvXKgPfSPacGb;

	[CompilerGenerated]
	private List<yzVAAkmkVGSRhMXfCTpeXmbVejh> UbUaTnkqaEsDLazoHJPqXVXDOpE;

	public IntPtr NativePointer => fRSdJIinkkjfuOwZLyQSrdGfQnO;

	public List<yzVAAkmkVGSRhMXfCTpeXmbVejh> Effects
	{
		[CompilerGenerated]
		get
		{
			return UbUaTnkqaEsDLazoHJPqXVXDOpE;
		}
		[CompilerGenerated]
		private set
		{
			UbUaTnkqaEsDLazoHJPqXVXDOpE = value;
		}
	}

	public unsafe pSLwPncgyQSJNlwHKnjrUwAYqIB()
	{
		tIfcxbGihlHDauFsvXKgPfSPacGb = xEmnorPJLrLxadbSeFgXAWpOByb;
		fRSdJIinkkjfuOwZLyQSrdGfQnO = Marshal.GetFunctionPointerForDelegate((Delegate)tIfcxbGihlHDauFsvXKgPfSPacGb);
		Effects = new List<yzVAAkmkVGSRhMXfCTpeXmbVejh>();
	}

	[MonoPInvokeCallback(typeof(hvXFxawhuVmzsSEgxJloQhtTZlU))]
	private unsafe static int xEmnorPJLrLxadbSeFgXAWpOByb(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<pSLwPncgyQSJNlwHKnjrUwAYqIB>(instanceId, out var instance))
		{
			return 1;
		}
		yzVAAkmkVGSRhMXfCTpeXmbVejh item = new yzVAAkmkVGSRhMXfCTpeXmbVejh((IntPtr)P_0);
		instance.Effects.Add(item);
		return 1;
	}
}

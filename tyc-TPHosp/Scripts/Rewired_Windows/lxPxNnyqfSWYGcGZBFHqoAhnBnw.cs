using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class lxPxNnyqfSWYGcGZBFHqoAhnBnw
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int wkziHWGTOCSAIuXRPeDFKSjYhTx(void* deviceInstance, IntPtr data);

	private readonly IntPtr gBbLrXrPAfTbPiLRobgphErqzjOU;

	private readonly wkziHWGTOCSAIuXRPeDFKSjYhTx iWJLmGxRkATRajaGxiTgAzQvcIb;

	[CompilerGenerated]
	private List<rwUDYNAmSWwCoTDiwmZsStufkqWe> qDqBpXBKgIoJSkcZlgBemZxqiDEr;

	public IntPtr NativePointer => gBbLrXrPAfTbPiLRobgphErqzjOU;

	public List<rwUDYNAmSWwCoTDiwmZsStufkqWe> DeviceInstances
	{
		[CompilerGenerated]
		get
		{
			return qDqBpXBKgIoJSkcZlgBemZxqiDEr;
		}
		[CompilerGenerated]
		private set
		{
			qDqBpXBKgIoJSkcZlgBemZxqiDEr = value;
		}
	}

	public unsafe lxPxNnyqfSWYGcGZBFHqoAhnBnw()
	{
		iWJLmGxRkATRajaGxiTgAzQvcIb = fLILWIVczrkZXOeVWFvxfwcrGnZ;
		gBbLrXrPAfTbPiLRobgphErqzjOU = Marshal.GetFunctionPointerForDelegate((Delegate)iWJLmGxRkATRajaGxiTgAzQvcIb);
		DeviceInstances = new List<rwUDYNAmSWwCoTDiwmZsStufkqWe>();
	}

	[MonoPInvokeCallback(typeof(wkziHWGTOCSAIuXRPeDFKSjYhTx))]
	private unsafe static int fLILWIVczrkZXOeVWFvxfwcrGnZ(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<lxPxNnyqfSWYGcGZBFHqoAhnBnw>(instanceId, out var instance))
		{
			return 1;
		}
		rwUDYNAmSWwCoTDiwmZsStufkqWe rwUDYNAmSWwCoTDiwmZsStufkqWe2 = new rwUDYNAmSWwCoTDiwmZsStufkqWe();
		rwUDYNAmSWwCoTDiwmZsStufkqWe2.SZrGrLlmHSqjecDGhpZXEmGQmZZ(ref *(rwUDYNAmSWwCoTDiwmZsStufkqWe.MxdddwkBmuWNQRajlQiwtQYhNMj*)P_0);
		instance.DeviceInstances.Add(rwUDYNAmSWwCoTDiwmZsStufkqWe2);
		return 1;
	}
}

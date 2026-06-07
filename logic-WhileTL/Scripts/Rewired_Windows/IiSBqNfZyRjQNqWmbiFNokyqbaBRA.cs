using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class IiSBqNfZyRjQNqWmbiFNokyqbaBRA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int ueSNajOxQavSpBzZdhkwzMbBZtWy(void* deviceInstance, IntPtr data);

	private readonly IntPtr ISXmNcLLklYzihMykauyFAuVLvSm;

	private readonly ueSNajOxQavSpBzZdhkwzMbBZtWy MsgdQZHArmPPyiCZWkdIRBkxqnWg;

	[CompilerGenerated]
	private List<DpsxEuVKaSYMZbImADbJhzCTgmnxA> tHHyebDcqTNmFZDYoIlrrljphEnaA;

	public IntPtr EEEaoiMKSwLCOBgsTjMBeDlbgYMaA => ISXmNcLLklYzihMykauyFAuVLvSm;

	public List<DpsxEuVKaSYMZbImADbJhzCTgmnxA> yqMXeHrgLkhifQsPqGPBAWffyeOi
	{
		[CompilerGenerated]
		get
		{
			return tHHyebDcqTNmFZDYoIlrrljphEnaA;
		}
		[CompilerGenerated]
		private set
		{
			tHHyebDcqTNmFZDYoIlrrljphEnaA = list;
		}
	}

	public unsafe IiSBqNfZyRjQNqWmbiFNokyqbaBRA()
	{
		MsgdQZHArmPPyiCZWkdIRBkxqnWg = KHrcfRKgRiPDciOzNmfrDkJbqZzBB;
		ISXmNcLLklYzihMykauyFAuVLvSm = Marshal.GetFunctionPointerForDelegate((Delegate)MsgdQZHArmPPyiCZWkdIRBkxqnWg);
		yqMXeHrgLkhifQsPqGPBAWffyeOi = new List<DpsxEuVKaSYMZbImADbJhzCTgmnxA>();
	}

	[MonoPInvokeCallback(typeof(ueSNajOxQavSpBzZdhkwzMbBZtWy))]
	private unsafe static int KHrcfRKgRiPDciOzNmfrDkJbqZzBB(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<IiSBqNfZyRjQNqWmbiFNokyqbaBRA>(instanceId, out var instance))
		{
			return 1;
		}
		DpsxEuVKaSYMZbImADbJhzCTgmnxA item = new DpsxEuVKaSYMZbImADbJhzCTgmnxA((IntPtr)P_0);
		instance.yqMXeHrgLkhifQsPqGPBAWffyeOi.Add(item);
		return 1;
	}
}

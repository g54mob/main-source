using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class KESzypUoRrBjhqIzEtJFHMUOflLS
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int YpHRwjKOjLjOUQBKngwbWnJvbEAI(void* deviceInstance, IntPtr data);

	private readonly IntPtr CYlKFBedShUlDjWIsryYajxAijwJ;

	private readonly YpHRwjKOjLjOUQBKngwbWnJvbEAI FIibrImujrFEoBHCOWJioqlSLxlwA;

	[CompilerGenerated]
	private List<XUQFpkbAIUWBAvsBSetKkBpsieSh> IBqdUdJJWPdSQIFOLGraXrBRLlaBb;

	public IntPtr zAsTMRpQoVQGocmNgOnTreWXlohA => CYlKFBedShUlDjWIsryYajxAijwJ;

	public List<XUQFpkbAIUWBAvsBSetKkBpsieSh> CnSeCKRKqFwQboPirXAoFUsjqorq
	{
		[CompilerGenerated]
		get
		{
			return IBqdUdJJWPdSQIFOLGraXrBRLlaBb;
		}
		[CompilerGenerated]
		private set
		{
			IBqdUdJJWPdSQIFOLGraXrBRLlaBb = iBqdUdJJWPdSQIFOLGraXrBRLlaBb;
		}
	}

	public unsafe KESzypUoRrBjhqIzEtJFHMUOflLS()
	{
		FIibrImujrFEoBHCOWJioqlSLxlwA = dzIGUdRcqrkQjwibYTvIYQufmkWC;
		CYlKFBedShUlDjWIsryYajxAijwJ = Marshal.GetFunctionPointerForDelegate(FIibrImujrFEoBHCOWJioqlSLxlwA);
		CnSeCKRKqFwQboPirXAoFUsjqorq = new List<XUQFpkbAIUWBAvsBSetKkBpsieSh>();
	}

	[MonoPInvokeCallback(typeof(YpHRwjKOjLjOUQBKngwbWnJvbEAI))]
	private unsafe static int dzIGUdRcqrkQjwibYTvIYQufmkWC(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<KESzypUoRrBjhqIzEtJFHMUOflLS>(instanceId, out var instance))
		{
			return 1;
		}
		XUQFpkbAIUWBAvsBSetKkBpsieSh xUQFpkbAIUWBAvsBSetKkBpsieSh = new XUQFpkbAIUWBAvsBSetKkBpsieSh();
		xUQFpkbAIUWBAvsBSetKkBpsieSh.vDosgOAclKksQIalBlFLxAKMHoljA(ref *(XUQFpkbAIUWBAvsBSetKkBpsieSh.pqvBneOaUOKkcohpuZSBYMutdWP*)P_0);
		instance.CnSeCKRKqFwQboPirXAoFUsjqorq.Add(xUQFpkbAIUWBAvsBSetKkBpsieSh);
		return 1;
	}
}

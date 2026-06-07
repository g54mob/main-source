using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class VHqBZiDAaibKNtNsVhBQhEiLhvPFb
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int ZMduTuWXUCSgoxxZygwuBfjqpIOl(void* deviceInstance, IntPtr data);

	private readonly IntPtr TcHPaUgObiYEpWmNjPmJtqDHugwV;

	private readonly ZMduTuWXUCSgoxxZygwuBfjqpIOl MfKYOZmwQgNnMciPBwHznkZFwtvP;

	[CompilerGenerated]
	private List<ESmgxahnkXhoMInINiiXbtozwAJc> TDAlGuLnhUpgwiOZAhAngFnCafkn;

	public IntPtr isqkhFlhzbdTwTIfSUHeeBOJengx => TcHPaUgObiYEpWmNjPmJtqDHugwV;

	public List<ESmgxahnkXhoMInINiiXbtozwAJc> DRkojPTgJAZzHPQtkjGbOUWuayzk
	{
		[CompilerGenerated]
		get
		{
			return TDAlGuLnhUpgwiOZAhAngFnCafkn;
		}
		[CompilerGenerated]
		private set
		{
			TDAlGuLnhUpgwiOZAhAngFnCafkn = tDAlGuLnhUpgwiOZAhAngFnCafkn;
		}
	}

	public unsafe VHqBZiDAaibKNtNsVhBQhEiLhvPFb()
	{
		MfKYOZmwQgNnMciPBwHznkZFwtvP = kVkzGkDPLmXJTXhpDBDRTEwskzUj;
		TcHPaUgObiYEpWmNjPmJtqDHugwV = Marshal.GetFunctionPointerForDelegate(MfKYOZmwQgNnMciPBwHznkZFwtvP);
		DRkojPTgJAZzHPQtkjGbOUWuayzk = new List<ESmgxahnkXhoMInINiiXbtozwAJc>();
	}

	[MonoPInvokeCallback(typeof(ZMduTuWXUCSgoxxZygwuBfjqpIOl))]
	private unsafe static int kVkzGkDPLmXJTXhpDBDRTEwskzUj(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<VHqBZiDAaibKNtNsVhBQhEiLhvPFb>(instanceId, out var instance))
		{
			return 1;
		}
		ESmgxahnkXhoMInINiiXbtozwAJc eSmgxahnkXhoMInINiiXbtozwAJc = new ESmgxahnkXhoMInINiiXbtozwAJc();
		eSmgxahnkXhoMInINiiXbtozwAJc.eaQHSZWIWRXsofauQZjAoaoLdatv(ref *(ESmgxahnkXhoMInINiiXbtozwAJc.whSwLosjZHhSUVSyeJeXUqazdQSI*)P_0);
		instance.DRkojPTgJAZzHPQtkjGbOUWuayzk.Add(eSmgxahnkXhoMInINiiXbtozwAJc);
		return 1;
	}
}

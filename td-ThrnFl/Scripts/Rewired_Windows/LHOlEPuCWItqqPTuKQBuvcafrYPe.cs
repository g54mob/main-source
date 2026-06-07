using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class LHOlEPuCWItqqPTuKQBuvcafrYPe
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int mhpfCIhUCBqPQqplAbJRsNncCgVIA(void* deviceInstance, IntPtr data);

	private readonly IntPtr eFaQxBXMvOJcWvoxxVVBNeDFcgvfA;

	private readonly mhpfCIhUCBqPQqplAbJRsNncCgVIA otcYjlGgGOJGzCzwsSXNJcAxndas;

	[CompilerGenerated]
	private List<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> PaHCNcEwIewFjgkrnzfrfCwPjAgCA;

	public IntPtr ZCbAZpPlPRrfLoAkHSdboLTHpIck => eFaQxBXMvOJcWvoxxVVBNeDFcgvfA;

	public List<TtTEWPAmgCXtCiwlxHCRLqWtUGyz> fqcxHWEtOCcJhbsYwhhFKnHuSvHD
	{
		[CompilerGenerated]
		get
		{
			return PaHCNcEwIewFjgkrnzfrfCwPjAgCA;
		}
		[CompilerGenerated]
		private set
		{
			PaHCNcEwIewFjgkrnzfrfCwPjAgCA = paHCNcEwIewFjgkrnzfrfCwPjAgCA;
		}
	}

	public unsafe LHOlEPuCWItqqPTuKQBuvcafrYPe()
	{
		otcYjlGgGOJGzCzwsSXNJcAxndas = AhhZVXLLRnVmrguWIEmPshPVJzfU;
		eFaQxBXMvOJcWvoxxVVBNeDFcgvfA = Marshal.GetFunctionPointerForDelegate(otcYjlGgGOJGzCzwsSXNJcAxndas);
		fqcxHWEtOCcJhbsYwhhFKnHuSvHD = new List<TtTEWPAmgCXtCiwlxHCRLqWtUGyz>();
	}

	[MonoPInvokeCallback(typeof(mhpfCIhUCBqPQqplAbJRsNncCgVIA))]
	private unsafe static int AhhZVXLLRnVmrguWIEmPshPVJzfU(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<LHOlEPuCWItqqPTuKQBuvcafrYPe>(instanceId, out var instance))
		{
			return 1;
		}
		TtTEWPAmgCXtCiwlxHCRLqWtUGyz ttTEWPAmgCXtCiwlxHCRLqWtUGyz = new TtTEWPAmgCXtCiwlxHCRLqWtUGyz();
		ttTEWPAmgCXtCiwlxHCRLqWtUGyz.TtyhEackCfmdJlKMmkiqQXPnEbsk(ref *(TtTEWPAmgCXtCiwlxHCRLqWtUGyz.AbMcDiwidhIvQjaqbuZmNyEcvHQB*)P_0);
		instance.fqcxHWEtOCcJhbsYwhhFKnHuSvHD.Add(ttTEWPAmgCXtCiwlxHCRLqWtUGyz);
		return 1;
	}
}

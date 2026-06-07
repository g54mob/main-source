using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class YoNdWTOHnsblckKbBeXvtDyABaTU
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int kJrDQPGIYMCtzmiLudWAqyQHPQS(void* deviceInstance, IntPtr data);

	private readonly IntPtr fRSdJIinkkjfuOwZLyQSrdGfQnO;

	private readonly kJrDQPGIYMCtzmiLudWAqyQHPQS tIfcxbGihlHDauFsvXKgPfSPacGb;

	[CompilerGenerated]
	private List<iQdYOFGqjdttFdWEmsYrjXbvWlZ> puDtOVMzHvJTeznDPBLkCQaukALd;

	public IntPtr NativePointer => fRSdJIinkkjfuOwZLyQSrdGfQnO;

	public List<iQdYOFGqjdttFdWEmsYrjXbvWlZ> EffectInfos
	{
		[CompilerGenerated]
		get
		{
			return puDtOVMzHvJTeznDPBLkCQaukALd;
		}
		[CompilerGenerated]
		private set
		{
			puDtOVMzHvJTeznDPBLkCQaukALd = value;
		}
	}

	public unsafe YoNdWTOHnsblckKbBeXvtDyABaTU()
	{
		tIfcxbGihlHDauFsvXKgPfSPacGb = kfXmLxkbSLEAnHCKVePBynLMPWs;
		fRSdJIinkkjfuOwZLyQSrdGfQnO = Marshal.GetFunctionPointerForDelegate((Delegate)tIfcxbGihlHDauFsvXKgPfSPacGb);
		EffectInfos = new List<iQdYOFGqjdttFdWEmsYrjXbvWlZ>();
	}

	[MonoPInvokeCallback(typeof(kJrDQPGIYMCtzmiLudWAqyQHPQS))]
	private unsafe static int kfXmLxkbSLEAnHCKVePBynLMPWs(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<YoNdWTOHnsblckKbBeXvtDyABaTU>(instanceId, out var instance))
		{
			return 1;
		}
		iQdYOFGqjdttFdWEmsYrjXbvWlZ iQdYOFGqjdttFdWEmsYrjXbvWlZ2 = new iQdYOFGqjdttFdWEmsYrjXbvWlZ();
		iQdYOFGqjdttFdWEmsYrjXbvWlZ2.RRYnwCwWhPouHIqMSeRibznJNqB(ref *(iQdYOFGqjdttFdWEmsYrjXbvWlZ.zgrrBZuTNFbjZfulvWYJVnCHbyX*)P_0);
		instance.EffectInfos.Add(iQdYOFGqjdttFdWEmsYrjXbvWlZ2);
		return 1;
	}
}

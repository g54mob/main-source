using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class QiTfRjPTtbCpCewVmnCmcDMtcdCL
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int oaCgQyciDpPHnCtIboIkBAsNhWvF(void* deviceInstance, IntPtr data);

	private readonly IntPtr tkIGqgtIwxjuCkXnyDpVvseOkZD;

	private readonly oaCgQyciDpPHnCtIboIkBAsNhWvF fqbGqHjzpkWVQgbYWnLpGdohkzDz;

	[CompilerGenerated]
	private List<mJduBvJZdmRdzZAgBfTeevZWKVWE> lbPAHfDFHgwVEDTdyzOtTQMHKFYE;

	public IntPtr NativePointer => tkIGqgtIwxjuCkXnyDpVvseOkZD;

	public List<mJduBvJZdmRdzZAgBfTeevZWKVWE> EffectInfos
	{
		[CompilerGenerated]
		get
		{
			return lbPAHfDFHgwVEDTdyzOtTQMHKFYE;
		}
		[CompilerGenerated]
		private set
		{
			lbPAHfDFHgwVEDTdyzOtTQMHKFYE = value;
		}
	}

	public unsafe QiTfRjPTtbCpCewVmnCmcDMtcdCL()
	{
		fqbGqHjzpkWVQgbYWnLpGdohkzDz = wmTpiDpdxKWcFnLccreSgOTdGwb;
		tkIGqgtIwxjuCkXnyDpVvseOkZD = Marshal.GetFunctionPointerForDelegate((Delegate)fqbGqHjzpkWVQgbYWnLpGdohkzDz);
		EffectInfos = new List<mJduBvJZdmRdzZAgBfTeevZWKVWE>();
	}

	[MonoPInvokeCallback(typeof(oaCgQyciDpPHnCtIboIkBAsNhWvF))]
	private unsafe static int wmTpiDpdxKWcFnLccreSgOTdGwb(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<QiTfRjPTtbCpCewVmnCmcDMtcdCL>(instanceId, out var instance))
		{
			return 1;
		}
		mJduBvJZdmRdzZAgBfTeevZWKVWE mJduBvJZdmRdzZAgBfTeevZWKVWE2 = new mJduBvJZdmRdzZAgBfTeevZWKVWE();
		mJduBvJZdmRdzZAgBfTeevZWKVWE2.ZXWljcfhlKeirbwwnVKxodNeLfEH(ref *(mJduBvJZdmRdzZAgBfTeevZWKVWE.XvQwIGwuHHRNrVVYCbbcmKlgiml*)P_0);
		instance.EffectInfos.Add(mJduBvJZdmRdzZAgBfTeevZWKVWE2);
		return 1;
	}
}

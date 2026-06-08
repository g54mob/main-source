using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class dLDbuXdsvHQuxBbHdyWqOgmnniK
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int BAmtFTUeLbRxqYLoDDalzXHZCtq(void* deviceInstance, IntPtr data);

	private readonly IntPtr tkIGqgtIwxjuCkXnyDpVvseOkZD;

	private readonly BAmtFTUeLbRxqYLoDDalzXHZCtq fqbGqHjzpkWVQgbYWnLpGdohkzDz;

	[CompilerGenerated]
	private List<krdBDutqeQQbjaAvQCOyBGYYnTc> MvGnxobicVshGWZYwYELBhcaXcG;

	public IntPtr NativePointer => tkIGqgtIwxjuCkXnyDpVvseOkZD;

	public List<krdBDutqeQQbjaAvQCOyBGYYnTc> Effects
	{
		[CompilerGenerated]
		get
		{
			return MvGnxobicVshGWZYwYELBhcaXcG;
		}
		[CompilerGenerated]
		private set
		{
			MvGnxobicVshGWZYwYELBhcaXcG = value;
		}
	}

	public unsafe dLDbuXdsvHQuxBbHdyWqOgmnniK()
	{
		fqbGqHjzpkWVQgbYWnLpGdohkzDz = flmcBNIfRwTpSFryNIXYEDgvSfc;
		tkIGqgtIwxjuCkXnyDpVvseOkZD = Marshal.GetFunctionPointerForDelegate((Delegate)fqbGqHjzpkWVQgbYWnLpGdohkzDz);
		Effects = new List<krdBDutqeQQbjaAvQCOyBGYYnTc>();
	}

	[MonoPInvokeCallback(typeof(BAmtFTUeLbRxqYLoDDalzXHZCtq))]
	private unsafe static int flmcBNIfRwTpSFryNIXYEDgvSfc(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<dLDbuXdsvHQuxBbHdyWqOgmnniK>(instanceId, out var instance))
		{
			return 1;
		}
		krdBDutqeQQbjaAvQCOyBGYYnTc item = new krdBDutqeQQbjaAvQCOyBGYYnTc((IntPtr)P_0);
		instance.Effects.Add(item);
		return 1;
	}
}

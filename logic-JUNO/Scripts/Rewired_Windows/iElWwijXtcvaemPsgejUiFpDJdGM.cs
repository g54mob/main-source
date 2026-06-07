using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class iElWwijXtcvaemPsgejUiFpDJdGM : uiIFGbFnfmeNgclXAVjyNHmstSYCB
{
	[CompilerGenerated]
	private GbSuGdEnVkELLsLPYRvsqEtXKOtS[] uNvDqOzWwuEeCAVfPOPiHXeAaSxiA;

	public GbSuGdEnVkELLsLPYRvsqEtXKOtS[] tpcAqcxhckqRZSbiZkjnCAqEOVWc
	{
		[CompilerGenerated]
		get
		{
			return uNvDqOzWwuEeCAVfPOPiHXeAaSxiA;
		}
		[CompilerGenerated]
		set
		{
			uNvDqOzWwuEeCAVfPOPiHXeAaSxiA = array;
		}
	}

	unsafe int uiIFGbFnfmeNgclXAVjyNHmstSYCB.YvNwnaANRlPKFYvzJdKlkyBxuraS
	{
		get
		{
			if (tpcAqcxhckqRZSbiZkjnCAqEOVWc == null)
			{
				return 0;
			}
			return tpcAqcxhckqRZSbiZkjnCAqEOVWc.Length * sizeof(GbSuGdEnVkELLsLPYRvsqEtXKOtS);
		}
	}

	protected unsafe virtual uiIFGbFnfmeNgclXAVjyNHmstSYCB XnzAuheMYcFhKfTNfOYeWhERTdxq(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(GbSuGdEnVkELLsLPYRvsqEtXKOtS) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(GbSuGdEnVkELLsLPYRvsqEtXKOtS);
		tpcAqcxhckqRZSbiZkjnCAqEOVWc = new GbSuGdEnVkELLsLPYRvsqEtXKOtS[num];
		fixed (GbSuGdEnVkELLsLPYRvsqEtXKOtS* ptr = tpcAqcxhckqRZSbiZkjnCAqEOVWc)
		{
			UzSdPpQstdjpcZsalnZeqrJQhDdn.gLWtQFUcdwcEsyTafnFfcDcnxkwx((IntPtr)ptr, P_1, UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<GbSuGdEnVkELLsLPYRvsqEtXKOtS>() * tpcAqcxhckqRZSbiZkjnCAqEOVWc.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr EIqPYnPMYPtyNDLXbjGQyVmCuqSl()
	{
		if (YvNwnaANRlPKFYvzJdKlkyBxuraS == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(YvNwnaANRlPKFYvzJdKlkyBxuraS);
		fixed (GbSuGdEnVkELLsLPYRvsqEtXKOtS* ptr = tpcAqcxhckqRZSbiZkjnCAqEOVWc)
		{
			UzSdPpQstdjpcZsalnZeqrJQhDdn.gLWtQFUcdwcEsyTafnFfcDcnxkwx(intPtr, (IntPtr)ptr, UzSdPpQstdjpcZsalnZeqrJQhDdn.ZacpjjccPJhFrXzenZKetagLntJC<GbSuGdEnVkELLsLPYRvsqEtXKOtS>() * tpcAqcxhckqRZSbiZkjnCAqEOVWc.Length);
		}
		return intPtr;
	}
}

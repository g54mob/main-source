using System;
using System.Runtime.InteropServices;

internal class VMGAKXIBdMsPTuSmeIglvnLsfUom
{
	private int lByQDcCcGiyaNPCgUBWhfJNUyTLtA;

	private byte[] kcmNiIZUDkYdjOHLshTUSHlaTTLt;

	public virtual int zZHfXGvkFZGpmLEYkBXqWnicdKKv => lByQDcCcGiyaNPCgUBWhfJNUyTLtA;

	protected VMGAKXIBdMsPTuSmeIglvnLsfUom()
	{
	}

	internal VMGAKXIBdMsPTuSmeIglvnLsfUom(int P_0, IntPtr P_1)
	{
		mXYfCRamUIsumHUhhAvrFBTaOGSkb(P_0, P_1);
	}

	private unsafe void mXYfCRamUIsumHUhhAvrFBTaOGSkb(int P_0, IntPtr P_1)
	{
		lByQDcCcGiyaNPCgUBWhfJNUyTLtA = P_0;
		if (lByQDcCcGiyaNPCgUBWhfJNUyTLtA > 0 && P_1 != IntPtr.Zero)
		{
			kcmNiIZUDkYdjOHLshTUSHlaTTLt = new byte[P_0];
			fixed (byte* ptr = kcmNiIZUDkYdjOHLshTUSHlaTTLt)
			{
				luYaFPaftNInTWGPWfCvgYuDUqDyA.JJGgrpAvfYRUJflNOROgzAByeTGgb((IntPtr)ptr, P_1, lByQDcCcGiyaNPCgUBWhfJNUyTLtA);
			}
		}
	}

	protected virtual VMGAKXIBdMsPTuSmeIglvnLsfUom orPEsOjKgFEgqySeDcqXgQkZcJiTA(int P_0, IntPtr P_1)
	{
		mXYfCRamUIsumHUhhAvrFBTaOGSkb(P_0, P_1);
		return this;
	}

	internal virtual void NsxrOfWKyCbmbkmGAlnFutnUytYi(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr codPfEAsGlBEcYEYbEwxiIJHeCbbb()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (lByQDcCcGiyaNPCgUBWhfJNUyTLtA > 0 && kcmNiIZUDkYdjOHLshTUSHlaTTLt != null)
		{
			intPtr = Marshal.AllocHGlobal(lByQDcCcGiyaNPCgUBWhfJNUyTLtA);
			fixed (byte* ptr = kcmNiIZUDkYdjOHLshTUSHlaTTLt)
			{
				luYaFPaftNInTWGPWfCvgYuDUqDyA.JJGgrpAvfYRUJflNOROgzAByeTGgb(intPtr, (IntPtr)ptr, lByQDcCcGiyaNPCgUBWhfJNUyTLtA);
			}
		}
		return intPtr;
	}

	public unsafe _0001 kByhSCnUwgVYUGZyYZHNcRAaRsfB<_0001>() where _0001 : VMGAKXIBdMsPTuSmeIglvnLsfUom, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(VMGAKXIBdMsPTuSmeIglvnLsfUom))
		{
			fixed (byte* ptr = kcmNiIZUDkYdjOHLshTUSHlaTTLt)
			{
				void* ptr2 = ptr;
				return (_0001)new _0001().orPEsOjKgFEgqySeDcqXgQkZcJiTA(lByQDcCcGiyaNPCgUBWhfJNUyTLtA, (IntPtr)ptr2);
			}
		}
		return null;
	}
}

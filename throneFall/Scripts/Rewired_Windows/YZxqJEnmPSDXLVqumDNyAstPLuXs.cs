using System;
using System.Runtime.InteropServices;

internal class YZxqJEnmPSDXLVqumDNyAstPLuXs
{
	private int unHGoxbykwunNgdyCbzakTdxcSqV;

	private byte[] ppDKMXiulibMxhaTcgyVjuNJdUoeA;

	public virtual int cnukmVIFnHXEymKWqjwhliQZpPzT => unHGoxbykwunNgdyCbzakTdxcSqV;

	protected YZxqJEnmPSDXLVqumDNyAstPLuXs()
	{
	}

	internal YZxqJEnmPSDXLVqumDNyAstPLuXs(int P_0, IntPtr P_1)
	{
		hffXfIXBuIgomxkvhUMwkYxnDIxj(P_0, P_1);
	}

	private unsafe void hffXfIXBuIgomxkvhUMwkYxnDIxj(int P_0, IntPtr P_1)
	{
		unHGoxbykwunNgdyCbzakTdxcSqV = P_0;
		if (unHGoxbykwunNgdyCbzakTdxcSqV > 0 && P_1 != IntPtr.Zero)
		{
			ppDKMXiulibMxhaTcgyVjuNJdUoeA = new byte[P_0];
			fixed (byte* ptr = ppDKMXiulibMxhaTcgyVjuNJdUoeA)
			{
				qEhGRKCBLVdeTteVGclkbvGuEbqQ.QPzyomEBrMYCJYJGQjOnlpkXCKnC((IntPtr)ptr, P_1, unHGoxbykwunNgdyCbzakTdxcSqV);
			}
		}
	}

	protected virtual YZxqJEnmPSDXLVqumDNyAstPLuXs pbmzyLSRCFkiiLPqFXuYbdMoEbZJ(int P_0, IntPtr P_1)
	{
		hffXfIXBuIgomxkvhUMwkYxnDIxj(P_0, P_1);
		return this;
	}

	internal virtual void AhWemurOSCbjneLUKhYIsHFlLnzeb(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr pzKboXtwmzhMubaKvGFsfpzqtDIbA()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (unHGoxbykwunNgdyCbzakTdxcSqV > 0 && ppDKMXiulibMxhaTcgyVjuNJdUoeA != null)
		{
			intPtr = Marshal.AllocHGlobal(unHGoxbykwunNgdyCbzakTdxcSqV);
			fixed (byte* ptr = ppDKMXiulibMxhaTcgyVjuNJdUoeA)
			{
				qEhGRKCBLVdeTteVGclkbvGuEbqQ.QPzyomEBrMYCJYJGQjOnlpkXCKnC(intPtr, (IntPtr)ptr, unHGoxbykwunNgdyCbzakTdxcSqV);
			}
		}
		return intPtr;
	}

	public unsafe _0001 ruJCeVfEkaRBGOlDQTwMiZjZPAJVA<_0001>() where _0001 : YZxqJEnmPSDXLVqumDNyAstPLuXs, new()
	{
		if (GetType() == typeof(_0001))
		{
			return (_0001)this;
		}
		if (GetType() == typeof(YZxqJEnmPSDXLVqumDNyAstPLuXs))
		{
			fixed (byte* ptr = ppDKMXiulibMxhaTcgyVjuNJdUoeA)
			{
				void* ptr2 = ptr;
				return (_0001)new _0001().pbmzyLSRCFkiiLPqFXuYbdMoEbZJ(unHGoxbykwunNgdyCbzakTdxcSqV, (IntPtr)ptr2);
			}
		}
		return null;
	}
}

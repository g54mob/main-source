using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class AkKXlPdFZKfRRGXKHGiUbeSbVqNe : YZxqJEnmPSDXLVqumDNyAstPLuXs
{
	[CompilerGenerated]
	private cJvFFCFYlUdHihMydtBoZpabbeurb[] MtGnfznDOMRirzpIqwdmUkluDsgx;

	public cJvFFCFYlUdHihMydtBoZpabbeurb[] XJBNuVpcROGaaugQydSzBZTuZiYO
	{
		[CompilerGenerated]
		get
		{
			return MtGnfznDOMRirzpIqwdmUkluDsgx;
		}
		[CompilerGenerated]
		set
		{
			MtGnfznDOMRirzpIqwdmUkluDsgx = mtGnfznDOMRirzpIqwdmUkluDsgx;
		}
	}

	unsafe int YZxqJEnmPSDXLVqumDNyAstPLuXs.cnukmVIFnHXEymKWqjwhliQZpPzT
	{
		get
		{
			if (XJBNuVpcROGaaugQydSzBZTuZiYO == null)
			{
				return 0;
			}
			return XJBNuVpcROGaaugQydSzBZTuZiYO.Length * sizeof(cJvFFCFYlUdHihMydtBoZpabbeurb);
		}
	}

	protected unsafe virtual YZxqJEnmPSDXLVqumDNyAstPLuXs pSYbQUkgBWhWbRelQwviLHVtZPyC(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(cJvFFCFYlUdHihMydtBoZpabbeurb) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(cJvFFCFYlUdHihMydtBoZpabbeurb);
		XJBNuVpcROGaaugQydSzBZTuZiYO = new cJvFFCFYlUdHihMydtBoZpabbeurb[num];
		fixed (cJvFFCFYlUdHihMydtBoZpabbeurb* ptr = XJBNuVpcROGaaugQydSzBZTuZiYO)
		{
			qEhGRKCBLVdeTteVGclkbvGuEbqQ.QPzyomEBrMYCJYJGQjOnlpkXCKnC((IntPtr)ptr, P_1, qEhGRKCBLVdeTteVGclkbvGuEbqQ.hvDyZKiqAhdaUxlKMfmseYlxZmKl<cJvFFCFYlUdHihMydtBoZpabbeurb>() * XJBNuVpcROGaaugQydSzBZTuZiYO.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr eaNCMMHuyblUiluAUFoOhjEkKGZE()
	{
		if (cnukmVIFnHXEymKWqjwhliQZpPzT == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(cnukmVIFnHXEymKWqjwhliQZpPzT);
		fixed (cJvFFCFYlUdHihMydtBoZpabbeurb* ptr = XJBNuVpcROGaaugQydSzBZTuZiYO)
		{
			qEhGRKCBLVdeTteVGclkbvGuEbqQ.QPzyomEBrMYCJYJGQjOnlpkXCKnC(intPtr, (IntPtr)ptr, qEhGRKCBLVdeTteVGclkbvGuEbqQ.hvDyZKiqAhdaUxlKMfmseYlxZmKl<cJvFFCFYlUdHihMydtBoZpabbeurb>() * XJBNuVpcROGaaugQydSzBZTuZiYO.Length);
		}
		return intPtr;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class CPuBWCMhNamBMnQeDlTojpzpZLV : TypeSpecificParameters
{
	[CompilerGenerated]
	private int xdYLGNLFdtNtSICxLmLbPsJDgnoh;

	[CompilerGenerated]
	private int xBLQbuuOApCHxIIaCjLpyQSDJuIc;

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return xdYLGNLFdtNtSICxLmLbPsJDgnoh;
		}
		[CompilerGenerated]
		set
		{
			xdYLGNLFdtNtSICxLmLbPsJDgnoh = value;
		}
	}

	public int End
	{
		[CompilerGenerated]
		get
		{
			return xBLQbuuOApCHxIIaCjLpyQSDJuIc;
		}
		[CompilerGenerated]
		set
		{
			xBLQbuuOApCHxIIaCjLpyQSDJuIc = value;
		}
	}

	public override int Size
	{
		get
		{
			return QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<xjszHClrUkEdeadSVasvIuEVntOx>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(xjszHClrUkEdeadSVasvIuEVntOx))
		{
			return null;
		}
		Start = ((xjszHClrUkEdeadSVasvIuEVntOx*)(void*)P_1)->JLNyGUJfqBkWKpBQUvTKmlQdbACH;
		End = ((xjszHClrUkEdeadSVasvIuEVntOx*)(void*)P_1)->HZIkoFxQqFBcgRfXTcHgtVlfRcw;
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((xjszHClrUkEdeadSVasvIuEVntOx*)(void*)intPtr)->JLNyGUJfqBkWKpBQUvTKmlQdbACH = Start;
		((xjszHClrUkEdeadSVasvIuEVntOx*)(void*)intPtr)->HZIkoFxQqFBcgRfXTcHgtVlfRcw = End;
		return intPtr;
	}
}

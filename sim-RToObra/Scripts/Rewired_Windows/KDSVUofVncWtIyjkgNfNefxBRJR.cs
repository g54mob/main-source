using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class KDSVUofVncWtIyjkgNfNefxBRJR : TypeSpecificParameters
{
	[CompilerGenerated]
	private int vNyPYduIfdcbJBGBmBJjUIRfTdk;

	[CompilerGenerated]
	private int fmreUSJyUjKsoHnOnNljLgCpqlK;

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return vNyPYduIfdcbJBGBmBJjUIRfTdk;
		}
		[CompilerGenerated]
		set
		{
			vNyPYduIfdcbJBGBmBJjUIRfTdk = value;
		}
	}

	public int End
	{
		[CompilerGenerated]
		get
		{
			return fmreUSJyUjKsoHnOnNljLgCpqlK;
		}
		[CompilerGenerated]
		set
		{
			fmreUSJyUjKsoHnOnNljLgCpqlK = value;
		}
	}

	public override int Size
	{
		get
		{
			return WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<vHWCwXSCmsadzduQomzMjEnbhKV>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(vHWCwXSCmsadzduQomzMjEnbhKV))
		{
			return null;
		}
		Start = ((vHWCwXSCmsadzduQomzMjEnbhKV*)(void*)P_1)->JNpqtseTgVDsLidqlJBYdNCXmOC;
		End = ((vHWCwXSCmsadzduQomzMjEnbhKV*)(void*)P_1)->TMohdrIBqFmGlUmvsaZyAcjFTcsl;
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((vHWCwXSCmsadzduQomzMjEnbhKV*)(void*)intPtr)->JNpqtseTgVDsLidqlJBYdNCXmOC = Start;
		((vHWCwXSCmsadzduQomzMjEnbhKV*)(void*)intPtr)->TMohdrIBqFmGlUmvsaZyAcjFTcsl = End;
		return intPtr;
	}
}

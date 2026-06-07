using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class rcwISfyXIWrlRTDqBZQjEkVTkfN : TypeSpecificParameters
{
	[CompilerGenerated]
	private int iKSkxthOQZRfKohDEpxNtMfHclQ;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return iKSkxthOQZRfKohDEpxNtMfHclQ;
		}
		[CompilerGenerated]
		set
		{
			iKSkxthOQZRfKohDEpxNtMfHclQ = value;
		}
	}

	public override int Size
	{
		get
		{
			return QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<HAOYVwbwXSSDuKjJRIeWfMVmLVf>();
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(HAOYVwbwXSSDuKjJRIeWfMVmLVf))
		{
			return null;
		}
		Magnitude = ((HAOYVwbwXSSDuKjJRIeWfMVmLVf*)(void*)P_1)->IAYfOfnCdHbByEvdeKnGBmGFweo;
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((HAOYVwbwXSSDuKjJRIeWfMVmLVf*)(void*)intPtr)->IAYfOfnCdHbByEvdeKnGBmGFweo = Magnitude;
		return intPtr;
	}
}

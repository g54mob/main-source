using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class wjZiTzdqfcsLAntMwbWLSGmZimW : TypeSpecificParameters
{
	[CompilerGenerated]
	private MJoHgeSODqFAnJjtIlynHSsZkLrL[] zPMpyhiGdSeHhYKkuKQpBwnGlMH;

	public MJoHgeSODqFAnJjtIlynHSsZkLrL[] Conditions
	{
		[CompilerGenerated]
		get
		{
			return zPMpyhiGdSeHhYKkuKQpBwnGlMH;
		}
		[CompilerGenerated]
		set
		{
			zPMpyhiGdSeHhYKkuKQpBwnGlMH = value;
		}
	}

	public unsafe override int Size
	{
		get
		{
			if (Conditions == null)
			{
				return 0;
			}
			return Conditions.Length * sizeof(MJoHgeSODqFAnJjtIlynHSsZkLrL);
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(MJoHgeSODqFAnJjtIlynHSsZkLrL) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(MJoHgeSODqFAnJjtIlynHSsZkLrL);
		Conditions = new MJoHgeSODqFAnJjtIlynHSsZkLrL[num];
		fixed (MJoHgeSODqFAnJjtIlynHSsZkLrL* conditions = Conditions)
		{
			QiyhMeApbloIAQYCjGAvUEQIhAz.jZaoqafpmcVnUamkQHboGxYtgDI((IntPtr)conditions, P_1, QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<MJoHgeSODqFAnJjtIlynHSsZkLrL>() * Conditions.Length);
		}
		return this;
	}

	internal unsafe override IntPtr MarshalTo()
	{
		if (Size == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		fixed (MJoHgeSODqFAnJjtIlynHSsZkLrL* conditions = Conditions)
		{
			QiyhMeApbloIAQYCjGAvUEQIhAz.jZaoqafpmcVnUamkQHboGxYtgDI(intPtr, (IntPtr)conditions, QiyhMeApbloIAQYCjGAvUEQIhAz.THBpTsDJKmVwufYBxLzZkiSYLgH<MJoHgeSODqFAnJjtIlynHSsZkLrL>() * Conditions.Length);
		}
		return intPtr;
	}
}

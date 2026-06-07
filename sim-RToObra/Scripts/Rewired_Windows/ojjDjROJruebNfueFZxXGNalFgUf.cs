using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class ojjDjROJruebNfueFZxXGNalFgUf : TypeSpecificParameters
{
	[CompilerGenerated]
	private EHQbbClyTgHDucqDpwYzJcyzZrb[] bBmlkNXXvCRzqHhKTDMzMfrydbHe;

	public EHQbbClyTgHDucqDpwYzJcyzZrb[] Conditions
	{
		[CompilerGenerated]
		get
		{
			return bBmlkNXXvCRzqHhKTDMzMfrydbHe;
		}
		[CompilerGenerated]
		set
		{
			bBmlkNXXvCRzqHhKTDMzMfrydbHe = value;
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
			return Conditions.Length * sizeof(EHQbbClyTgHDucqDpwYzJcyzZrb);
		}
	}

	protected unsafe override TypeSpecificParameters MarshalFrom(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(EHQbbClyTgHDucqDpwYzJcyzZrb) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(EHQbbClyTgHDucqDpwYzJcyzZrb);
		Conditions = new EHQbbClyTgHDucqDpwYzJcyzZrb[num];
		fixed (EHQbbClyTgHDucqDpwYzJcyzZrb* conditions = Conditions)
		{
			WISJwItoxlmpVJIyUeIxBJGahMp.paUzUKGciuAmJnjIrFfoiXQPbNEU((IntPtr)conditions, P_1, WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<EHQbbClyTgHDucqDpwYzJcyzZrb>() * Conditions.Length);
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
		fixed (EHQbbClyTgHDucqDpwYzJcyzZrb* conditions = Conditions)
		{
			WISJwItoxlmpVJIyUeIxBJGahMp.paUzUKGciuAmJnjIrFfoiXQPbNEU(intPtr, (IntPtr)conditions, WISJwItoxlmpVJIyUeIxBJGahMp.XMvgwMGgZmqMvpsoWuNJPriqSDB<EHQbbClyTgHDucqDpwYzJcyzZrb>() * Conditions.Length);
		}
		return intPtr;
	}
}

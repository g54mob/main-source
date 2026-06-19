using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class iVNVqLlnLMOWzpYVGJIpiSLvxgn : efmrLSrolSjovsfxfjCVLLJRnGz
{
	[CompilerGenerated]
	private QZafDQFAZUCkAQfnuyKZFoQrEYWl[] rCSYpTceduAOYEteOihDpfFaFem;

	public QZafDQFAZUCkAQfnuyKZFoQrEYWl[] Conditions
	{
		[CompilerGenerated]
		get
		{
			return rCSYpTceduAOYEteOihDpfFaFem;
		}
		[CompilerGenerated]
		set
		{
			rCSYpTceduAOYEteOihDpfFaFem = value;
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
			return Conditions.Length * sizeof(QZafDQFAZUCkAQfnuyKZFoQrEYWl);
		}
	}

	protected unsafe override efmrLSrolSjovsfxfjCVLLJRnGz jgUKJdlhVlbmjmcGcqukHIxicKDF(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(QZafDQFAZUCkAQfnuyKZFoQrEYWl) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(QZafDQFAZUCkAQfnuyKZFoQrEYWl);
		Conditions = new QZafDQFAZUCkAQfnuyKZFoQrEYWl[num];
		fixed (QZafDQFAZUCkAQfnuyKZFoQrEYWl* conditions = Conditions)
		{
			QvyMHYIdbHWMtWGQBjyLybggaNAi.jMquLSbqoOKLzeBecvZYwYcJcSl((IntPtr)conditions, P_1, QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<QZafDQFAZUCkAQfnuyKZFoQrEYWl>() * Conditions.Length);
		}
		return this;
	}

	internal unsafe override IntPtr ytPODbihcgKkYwOfQIFAEFNEgkj()
	{
		if (Size == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		fixed (QZafDQFAZUCkAQfnuyKZFoQrEYWl* conditions = Conditions)
		{
			QvyMHYIdbHWMtWGQBjyLybggaNAi.jMquLSbqoOKLzeBecvZYwYcJcSl(intPtr, (IntPtr)conditions, QvyMHYIdbHWMtWGQBjyLybggaNAi.PVPOiGJSBGvoBbaMPpcfSPOcCOq<QZafDQFAZUCkAQfnuyKZFoQrEYWl>() * Conditions.Length);
		}
		return intPtr;
	}
}

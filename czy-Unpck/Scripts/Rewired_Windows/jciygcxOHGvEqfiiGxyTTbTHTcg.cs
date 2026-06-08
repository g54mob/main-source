using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class jciygcxOHGvEqfiiGxyTTbTHTcg : TypeSpecificParameters
{
	[CompilerGenerated]
	private XLwrhYJvWaHPzRWehZfDVeNVjB[] ucbVtqsPLiJWFWsASBPzWfYMrnh;

	public XLwrhYJvWaHPzRWehZfDVeNVjB[] Conditions
	{
		[CompilerGenerated]
		get
		{
			return ucbVtqsPLiJWFWsASBPzWfYMrnh;
		}
		[CompilerGenerated]
		set
		{
			ucbVtqsPLiJWFWsASBPzWfYMrnh = value;
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
			return Conditions.Length * sizeof(XLwrhYJvWaHPzRWehZfDVeNVjB);
		}
	}

	protected unsafe virtual TypeSpecificParameters wybJdAhTpvWqyyOomZLOcLcMQJK(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(XLwrhYJvWaHPzRWehZfDVeNVjB) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(XLwrhYJvWaHPzRWehZfDVeNVjB);
		Conditions = new XLwrhYJvWaHPzRWehZfDVeNVjB[num];
		fixed (XLwrhYJvWaHPzRWehZfDVeNVjB* conditions = Conditions)
		{
			XhNUbpKnHPBQaARiBNUpPFpGECJ.qzVukddgYEFywyhAwohqPAzjNic((IntPtr)conditions, P_1, XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<XLwrhYJvWaHPzRWehZfDVeNVjB>() * Conditions.Length);
		}
		return this;
	}

	internal unsafe virtual IntPtr lowChckoFmJAJyiuKPzqepQclpma()
	{
		if (Size == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		fixed (XLwrhYJvWaHPzRWehZfDVeNVjB* conditions = Conditions)
		{
			XhNUbpKnHPBQaARiBNUpPFpGECJ.qzVukddgYEFywyhAwohqPAzjNic(intPtr, (IntPtr)conditions, XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<XLwrhYJvWaHPzRWehZfDVeNVjB>() * Conditions.Length);
		}
		return intPtr;
	}
}

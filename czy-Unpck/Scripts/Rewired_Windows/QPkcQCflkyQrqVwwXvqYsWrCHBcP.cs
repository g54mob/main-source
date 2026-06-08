using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class QPkcQCflkyQrqVwwXvqYsWrCHBcP : TypeSpecificParameters
{
	[CompilerGenerated]
	private int vrvvqoxvolfpwoshkncTklEZbkq;

	[CompilerGenerated]
	private int DitDhDJCcKKijbbWdIpFTtWEFCR;

	[CompilerGenerated]
	private int brAKiIttahgPijzqdsTyXItmENG;

	[CompilerGenerated]
	private int EvIZNuglsDHSToQcsxMMZlPkihW;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return vrvvqoxvolfpwoshkncTklEZbkq;
		}
		[CompilerGenerated]
		set
		{
			vrvvqoxvolfpwoshkncTklEZbkq = value;
		}
	}

	public int Offset
	{
		[CompilerGenerated]
		get
		{
			return DitDhDJCcKKijbbWdIpFTtWEFCR;
		}
		[CompilerGenerated]
		set
		{
			DitDhDJCcKKijbbWdIpFTtWEFCR = value;
		}
	}

	public int Phase
	{
		[CompilerGenerated]
		get
		{
			return brAKiIttahgPijzqdsTyXItmENG;
		}
		[CompilerGenerated]
		set
		{
			brAKiIttahgPijzqdsTyXItmENG = value;
		}
	}

	public int Period
	{
		[CompilerGenerated]
		get
		{
			return EvIZNuglsDHSToQcsxMMZlPkihW;
		}
		[CompilerGenerated]
		set
		{
			EvIZNuglsDHSToQcsxMMZlPkihW = value;
		}
	}

	public override int Size => XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<NOaMlSIxMcGXIrGjYbGbVKWqCft>();

	protected unsafe virtual TypeSpecificParameters wybJdAhTpvWqyyOomZLOcLcMQJK(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(NOaMlSIxMcGXIrGjYbGbVKWqCft))
		{
			return null;
		}
		Magnitude = ((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)P_1)->FXxFdTtisNzPdwaJDmVbALJIsoI;
		Offset = ((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)P_1)->udsPlCkQjZnJYoduwmqSePFhHcD;
		Phase = ((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)P_1)->IiChEISlTJXYEudmybeahaLEHoQf;
		Period = ((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)P_1)->qJBGwrnyEBjsDegBVBsJKqruTYR;
		return this;
	}

	internal unsafe virtual IntPtr lowChckoFmJAJyiuKPzqepQclpma()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)intPtr)->FXxFdTtisNzPdwaJDmVbALJIsoI = Magnitude;
		((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)intPtr)->udsPlCkQjZnJYoduwmqSePFhHcD = Offset;
		((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)intPtr)->IiChEISlTJXYEudmybeahaLEHoQf = Phase;
		((NOaMlSIxMcGXIrGjYbGbVKWqCft*)(void*)intPtr)->qJBGwrnyEBjsDegBVBsJKqruTYR = Period;
		return intPtr;
	}
}

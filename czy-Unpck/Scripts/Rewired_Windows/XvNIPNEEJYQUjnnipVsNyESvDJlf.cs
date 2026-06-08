using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class XvNIPNEEJYQUjnnipVsNyESvDJlf : TypeSpecificParameters
{
	[CompilerGenerated]
	private int qwhYUOZFiFVqAOJOzKjtSsiZpMm;

	[CompilerGenerated]
	private int oiidJryhiHxGNSdUweCvVnxBiuo;

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return qwhYUOZFiFVqAOJOzKjtSsiZpMm;
		}
		[CompilerGenerated]
		set
		{
			qwhYUOZFiFVqAOJOzKjtSsiZpMm = value;
		}
	}

	public int End
	{
		[CompilerGenerated]
		get
		{
			return oiidJryhiHxGNSdUweCvVnxBiuo;
		}
		[CompilerGenerated]
		set
		{
			oiidJryhiHxGNSdUweCvVnxBiuo = value;
		}
	}

	public override int Size => XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<wQNPbRfeyMFfQsByvizjxVbDWjc>();

	protected unsafe virtual TypeSpecificParameters wybJdAhTpvWqyyOomZLOcLcMQJK(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(wQNPbRfeyMFfQsByvizjxVbDWjc))
		{
			return null;
		}
		Start = ((wQNPbRfeyMFfQsByvizjxVbDWjc*)(void*)P_1)->EsoCoViNGnlmiCnejoKMpfdflIEq;
		End = ((wQNPbRfeyMFfQsByvizjxVbDWjc*)(void*)P_1)->GmzzaYdwOhpjURgvhfIaeqAzPwUF;
		return this;
	}

	internal unsafe virtual IntPtr lowChckoFmJAJyiuKPzqepQclpma()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((wQNPbRfeyMFfQsByvizjxVbDWjc*)(void*)intPtr)->EsoCoViNGnlmiCnejoKMpfdflIEq = Start;
		((wQNPbRfeyMFfQsByvizjxVbDWjc*)(void*)intPtr)->GmzzaYdwOhpjURgvhfIaeqAzPwUF = End;
		return intPtr;
	}
}

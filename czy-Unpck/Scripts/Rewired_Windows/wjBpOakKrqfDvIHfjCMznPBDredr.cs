using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX.DirectInput;

internal class wjBpOakKrqfDvIHfjCMznPBDredr : TypeSpecificParameters
{
	[CompilerGenerated]
	private int vrvvqoxvolfpwoshkncTklEZbkq;

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

	public override int Size => XhNUbpKnHPBQaARiBNUpPFpGECJ.MNwplfZetGrtOlzgThGDriPKjRnh<KcpXoprAhoBvOSmjhbpAceuqXRNv>();

	protected unsafe virtual TypeSpecificParameters wybJdAhTpvWqyyOomZLOcLcMQJK(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(KcpXoprAhoBvOSmjhbpAceuqXRNv))
		{
			return null;
		}
		Magnitude = ((KcpXoprAhoBvOSmjhbpAceuqXRNv*)(void*)P_1)->FXxFdTtisNzPdwaJDmVbALJIsoI;
		return this;
	}

	internal unsafe virtual IntPtr lowChckoFmJAJyiuKPzqepQclpma()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((KcpXoprAhoBvOSmjhbpAceuqXRNv*)(void*)intPtr)->FXxFdTtisNzPdwaJDmVbALJIsoI = Magnitude;
		return intPtr;
	}
}

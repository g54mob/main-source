using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class IJifLoiaqpsvOsIAgbnXZWDdIMzr : jTTnjFcmJNutQYLpCwPogAkUWGz
{
	[CompilerGenerated]
	private int nlxydQyMgmNfYIkZLfxAegmoYhtr;

	[CompilerGenerated]
	private int ZOlcYxOhkDwVTNVqOeDCDhifGTM;

	[CompilerGenerated]
	private int fKYXmmvfqMoANTZCrzvJrkPCDT;

	[CompilerGenerated]
	private int CBSKoCvNmWHYbUSsXgdTJjvTrGR;

	public int Magnitude
	{
		[CompilerGenerated]
		get
		{
			return nlxydQyMgmNfYIkZLfxAegmoYhtr;
		}
		[CompilerGenerated]
		set
		{
			nlxydQyMgmNfYIkZLfxAegmoYhtr = value;
		}
	}

	public int Offset
	{
		[CompilerGenerated]
		get
		{
			return ZOlcYxOhkDwVTNVqOeDCDhifGTM;
		}
		[CompilerGenerated]
		set
		{
			ZOlcYxOhkDwVTNVqOeDCDhifGTM = value;
		}
	}

	public int Phase
	{
		[CompilerGenerated]
		get
		{
			return fKYXmmvfqMoANTZCrzvJrkPCDT;
		}
		[CompilerGenerated]
		set
		{
			fKYXmmvfqMoANTZCrzvJrkPCDT = value;
		}
	}

	public int Period
	{
		[CompilerGenerated]
		get
		{
			return CBSKoCvNmWHYbUSsXgdTJjvTrGR;
		}
		[CompilerGenerated]
		set
		{
			CBSKoCvNmWHYbUSsXgdTJjvTrGR = value;
		}
	}

	public override int Size => JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<ZVqrwaXZElKMgXVLnsNaBJoRnLw>();

	protected unsafe override jTTnjFcmJNutQYLpCwPogAkUWGz aRreqoecxmLuIAlYVRIPwMKrCMT(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(ZVqrwaXZElKMgXVLnsNaBJoRnLw))
		{
			return null;
		}
		Magnitude = ((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)P_1)->HrvHolcikWHXZaApwdSgVSxbbzRN;
		Offset = ((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)P_1)->cJyNeilCnUdRmKWIRHhHHebKNpEt;
		Phase = ((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)P_1)->AcMjRuNGLIISmbUCFoxzylvtfbLP;
		Period = ((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)P_1)->sdBcJXmkKQvxjWztwpjKOfFLjNU;
		return this;
	}

	internal unsafe override IntPtr diiFuCizNlbWbcWAcnolWnmjPwtB()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)intPtr)->HrvHolcikWHXZaApwdSgVSxbbzRN = Magnitude;
		((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)intPtr)->cJyNeilCnUdRmKWIRHhHHebKNpEt = Offset;
		((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)intPtr)->AcMjRuNGLIISmbUCFoxzylvtfbLP = Phase;
		((ZVqrwaXZElKMgXVLnsNaBJoRnLw*)(void*)intPtr)->sdBcJXmkKQvxjWztwpjKOfFLjNU = Period;
		return intPtr;
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class LoTDIdLrDRPQLTfMAzbMsggKtKy : jTTnjFcmJNutQYLpCwPogAkUWGz
{
	[CompilerGenerated]
	private int oCvFspOLIUHOditXIXwIOMGcefH;

	[CompilerGenerated]
	private int sbgqlLzmZIvtzsiVRNmoPHqqbrC;

	public int Start
	{
		[CompilerGenerated]
		get
		{
			return oCvFspOLIUHOditXIXwIOMGcefH;
		}
		[CompilerGenerated]
		set
		{
			oCvFspOLIUHOditXIXwIOMGcefH = value;
		}
	}

	public int End
	{
		[CompilerGenerated]
		get
		{
			return sbgqlLzmZIvtzsiVRNmoPHqqbrC;
		}
		[CompilerGenerated]
		set
		{
			sbgqlLzmZIvtzsiVRNmoPHqqbrC = value;
		}
	}

	public override int Size => JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<akPCdhaxsXVxmOwGKkkyfaRwihp>();

	protected unsafe override jTTnjFcmJNutQYLpCwPogAkUWGz aRreqoecxmLuIAlYVRIPwMKrCMT(int P_0, IntPtr P_1)
	{
		if (P_0 != sizeof(akPCdhaxsXVxmOwGKkkyfaRwihp))
		{
			return null;
		}
		Start = ((akPCdhaxsXVxmOwGKkkyfaRwihp*)(void*)P_1)->GLqFjpJWOmaiIIPQEPXLKjDgABxr;
		End = ((akPCdhaxsXVxmOwGKkkyfaRwihp*)(void*)P_1)->KftupcwjUwqncnODGnJtuLiOjjP;
		return this;
	}

	internal unsafe override IntPtr diiFuCizNlbWbcWAcnolWnmjPwtB()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		((akPCdhaxsXVxmOwGKkkyfaRwihp*)(void*)intPtr)->GLqFjpJWOmaiIIPQEPXLKjDgABxr = Start;
		((akPCdhaxsXVxmOwGKkkyfaRwihp*)(void*)intPtr)->KftupcwjUwqncnODGnJtuLiOjjP = End;
		return intPtr;
	}
}

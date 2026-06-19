using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class xGDPuMIfChSheuxfJoXSbFOXgbp : global::slgsKTDRGmBruGFKLTFOPLqJxXF<VwADaAlBseatulGZReavdrMTTYM, CxtCtjaqPTiIJAtrfQzRXLFwdcUL>
{
	[CompilerGenerated]
	private int RkHmUkFagIcuVyeFrIvOvYHyjcT;

	[CompilerGenerated]
	private int KiZDpPGxcmgcOiMjesMGjldBynGY;

	[CompilerGenerated]
	private int ekYwYCWDRoEpZPSKmCrdEdToFuQX;

	[CompilerGenerated]
	private bool[] UUSNBXrcqSCPYFEDTgVyvhoBLuR;

	public int X
	{
		[CompilerGenerated]
		get
		{
			return RkHmUkFagIcuVyeFrIvOvYHyjcT;
		}
		[CompilerGenerated]
		set
		{
			RkHmUkFagIcuVyeFrIvOvYHyjcT = value;
		}
	}

	public int Y
	{
		[CompilerGenerated]
		get
		{
			return KiZDpPGxcmgcOiMjesMGjldBynGY;
		}
		[CompilerGenerated]
		set
		{
			KiZDpPGxcmgcOiMjesMGjldBynGY = value;
		}
	}

	public int Z
	{
		[CompilerGenerated]
		get
		{
			return ekYwYCWDRoEpZPSKmCrdEdToFuQX;
		}
		[CompilerGenerated]
		set
		{
			ekYwYCWDRoEpZPSKmCrdEdToFuQX = value;
		}
	}

	public bool[] Buttons
	{
		[CompilerGenerated]
		get
		{
			return UUSNBXrcqSCPYFEDTgVyvhoBLuR;
		}
		[CompilerGenerated]
		private set
		{
			UUSNBXrcqSCPYFEDTgVyvhoBLuR = value;
		}
	}

	public xGDPuMIfChSheuxfJoXSbFOXgbp()
	{
		Buttons = new bool[8];
	}

	public void CWncwVbJhTWISMonvIVEimpDcKXc(CxtCtjaqPTiIJAtrfQzRXLFwdcUL P_0)
	{
		int value = P_0.Value;
		switch (P_0.Offset)
		{
		case EEpRoHwRHSLOZaxUatsMwXPeiuf.lSOdwKYaTJSJyAWJnADwkSPKwkp:
			X = value;
			return;
		case EEpRoHwRHSLOZaxUatsMwXPeiuf.ZqYMkLdonrbLPbHprxydzkIAizSD:
			Y = value;
			return;
		case EEpRoHwRHSLOZaxUatsMwXPeiuf.ZCWmLKzOWxAhKMWTYgDsRddDcsH:
			Z = value;
			return;
		}
		int num = (int)(P_0.Offset - 12);
		if (num >= 0 && num < 8)
		{
			Buttons[num] = (value & 0x80) != 0;
		}
	}

	void global::slgsKTDRGmBruGFKLTFOPLqJxXF<VwADaAlBseatulGZReavdrMTTYM, CxtCtjaqPTiIJAtrfQzRXLFwdcUL>.CWncwVbJhTWISMonvIVEimpDcKXc(CxtCtjaqPTiIJAtrfQzRXLFwdcUL P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CWncwVbJhTWISMonvIVEimpDcKXc
		this.CWncwVbJhTWISMonvIVEimpDcKXc(P_0);
	}

	public unsafe void jgUKJdlhVlbmjmcGcqukHIxicKDF(IntPtr P_0)
	{
		VwADaAlBseatulGZReavdrMTTYM* ptr = (VwADaAlBseatulGZReavdrMTTYM*)(void*)P_0;
		X = ptr->lSOdwKYaTJSJyAWJnADwkSPKwkp;
		Y = ptr->ZqYMkLdonrbLPbHprxydzkIAizSD;
		Z = ptr->ZCWmLKzOWxAhKMWTYgDsRddDcsH;
		void* ptr2 = &ptr->roFOWNsXzVtFzUVhAShEvmVQYJl;
		fixed (bool* buttons = Buttons)
		{
			for (int i = 0; i < 8; i++)
			{
				buttons[i] = (((byte*)ptr2)[i] & 0x80) != 0;
			}
		}
	}

	void global::slgsKTDRGmBruGFKLTFOPLqJxXF<VwADaAlBseatulGZReavdrMTTYM, CxtCtjaqPTiIJAtrfQzRXLFwdcUL>.jgUKJdlhVlbmjmcGcqukHIxicKDF(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in jgUKJdlhVlbmjmcGcqukHIxicKDF
		this.jgUKJdlhVlbmjmcGcqukHIxicKDF(P_0);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", X, Y, Z, QvyMHYIdbHWMtWGQBjyLybggaNAi.TrOgnwDXldYAiczZEbzuYfkxxbo(";", Buttons));
	}
}

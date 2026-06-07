using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class yNkMiHDtoqzkTOExoaYlEExEabj : global::vnUBANiQfJIVAasLhjdkZgyRflNB<WjjYlXmXAfHcHTWLwEMCGqvGlYK, BcULecnbJOYisVDznNGumjicoPO>
{
	[CompilerGenerated]
	private int MAkiSbGwERoayEvPAUPnIJcdncZ;

	[CompilerGenerated]
	private int RnaTYneAptcbJojqRwlUMSkfhIJ;

	[CompilerGenerated]
	private int nVripNFryfdPaxUiPNiWOkXpoXW;

	[CompilerGenerated]
	private bool[] XQrgtOAsOVYOxnRMaeGTHEOMORZH;

	public int X
	{
		[CompilerGenerated]
		get
		{
			return MAkiSbGwERoayEvPAUPnIJcdncZ;
		}
		[CompilerGenerated]
		set
		{
			MAkiSbGwERoayEvPAUPnIJcdncZ = value;
		}
	}

	public int Y
	{
		[CompilerGenerated]
		get
		{
			return RnaTYneAptcbJojqRwlUMSkfhIJ;
		}
		[CompilerGenerated]
		set
		{
			RnaTYneAptcbJojqRwlUMSkfhIJ = value;
		}
	}

	public int Z
	{
		[CompilerGenerated]
		get
		{
			return nVripNFryfdPaxUiPNiWOkXpoXW;
		}
		[CompilerGenerated]
		set
		{
			nVripNFryfdPaxUiPNiWOkXpoXW = value;
		}
	}

	public bool[] Buttons
	{
		[CompilerGenerated]
		get
		{
			return XQrgtOAsOVYOxnRMaeGTHEOMORZH;
		}
		[CompilerGenerated]
		private set
		{
			XQrgtOAsOVYOxnRMaeGTHEOMORZH = value;
		}
	}

	public yNkMiHDtoqzkTOExoaYlEExEabj()
	{
		Buttons = new bool[8];
	}

	public void RMEkOMsGFSFWbHqrAFftMTIKNIHO(BcULecnbJOYisVDznNGumjicoPO P_0)
	{
		int value = P_0.Value;
		switch (P_0.Offset)
		{
		case LRYSHKbThRAxcQfQZYKvTAwphcx.aKhnJLPlzQqMJcsXANqZDKcXdkvk:
			X = value;
			return;
		case LRYSHKbThRAxcQfQZYKvTAwphcx.CfrGUAcJZiBIgrKhIOoWYteVjgS:
			Y = value;
			return;
		case LRYSHKbThRAxcQfQZYKvTAwphcx.WXjeIOAoewOQIscExpKoNuKQHmwy:
			Z = value;
			return;
		}
		int num = (int)(P_0.Offset - 12);
		if (num >= 0 && num < 8)
		{
			Buttons[num] = (value & 0x80) != 0;
		}
	}

	void global::vnUBANiQfJIVAasLhjdkZgyRflNB<WjjYlXmXAfHcHTWLwEMCGqvGlYK, BcULecnbJOYisVDznNGumjicoPO>.RMEkOMsGFSFWbHqrAFftMTIKNIHO(BcULecnbJOYisVDznNGumjicoPO P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in RMEkOMsGFSFWbHqrAFftMTIKNIHO
		this.RMEkOMsGFSFWbHqrAFftMTIKNIHO(P_0);
	}

	public unsafe void aRreqoecxmLuIAlYVRIPwMKrCMT(IntPtr P_0)
	{
		WjjYlXmXAfHcHTWLwEMCGqvGlYK* ptr = (WjjYlXmXAfHcHTWLwEMCGqvGlYK*)(void*)P_0;
		X = ptr->aKhnJLPlzQqMJcsXANqZDKcXdkvk;
		Y = ptr->CfrGUAcJZiBIgrKhIOoWYteVjgS;
		Z = ptr->WXjeIOAoewOQIscExpKoNuKQHmwy;
		void* ptr2 = &ptr->iBuknEloRUrWSskvjaWhGBuFECf;
		fixed (bool* buttons = Buttons)
		{
			for (int i = 0; i < 8; i++)
			{
				buttons[i] = (((byte*)ptr2)[i] & 0x80) != 0;
			}
		}
	}

	void global::vnUBANiQfJIVAasLhjdkZgyRflNB<WjjYlXmXAfHcHTWLwEMCGqvGlYK, BcULecnbJOYisVDznNGumjicoPO>.aRreqoecxmLuIAlYVRIPwMKrCMT(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in aRreqoecxmLuIAlYVRIPwMKrCMT
		this.aRreqoecxmLuIAlYVRIPwMKrCMT(P_0);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", X, Y, Z, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OIlEUrSiFgjSFdEJhLLHCtYsqjmh(";", Buttons));
	}
}

using System;
using System.Runtime.InteropServices;

internal struct MwEMUNdEdQpngdbXMtjwIdOvEFgfA
{
	public IntPtr GEoKoDLgzuOgaHNmtaKAjGyTRPHPA;

	public int YJxgmrhGdMGPkniGcIrcdScWCULe;

	public int gYvbRztLqcPpQaEsDreUlHXMLoES;

	public MejVVrrMOBdCIGddmesHFxhfxqsN NadNaDdOvUUOWifUshEFULBlVOiN;

	public bool lIWThXiHWWHNJNDnbDmfYLAeadEBA
	{
		get
		{
			if (GEoKoDLgzuOgaHNmtaKAjGyTRPHPA != IntPtr.Zero && YJxgmrhGdMGPkniGcIrcdScWCULe > 0)
			{
				return gYvbRztLqcPpQaEsDreUlHXMLoES > 0;
			}
			return false;
		}
	}

	public MwEMUNdEdQpngdbXMtjwIdOvEFgfA(IntPtr P_0, int P_1, int P_2)
	{
		GEoKoDLgzuOgaHNmtaKAjGyTRPHPA = P_0;
		YJxgmrhGdMGPkniGcIrcdScWCULe = P_1;
		gYvbRztLqcPpQaEsDreUlHXMLoES = P_2;
		NadNaDdOvUUOWifUshEFULBlVOiN = MejVVrrMOBdCIGddmesHFxhfxqsN.None;
	}

	public void mRPBPXXgQHTFojuFHBLMWgttkOWb()
	{
		GEoKoDLgzuOgaHNmtaKAjGyTRPHPA = IntPtr.Zero;
		YJxgmrhGdMGPkniGcIrcdScWCULe = 0;
		gYvbRztLqcPpQaEsDreUlHXMLoES = 0;
		NadNaDdOvUUOWifUshEFULBlVOiN = MejVVrrMOBdCIGddmesHFxhfxqsN.None;
	}

	public string UfXBcLnOnKbFQCpPjPQGmLcffWFT()
	{
		string text = "OutputReport:\n";
		text = text + "buffer = " + ((GEoKoDLgzuOgaHNmtaKAjGyTRPHPA == IntPtr.Zero) ? "NULL" : ("Is Valid (" + GEoKoDLgzuOgaHNmtaKAjGyTRPHPA + ")")) + "\n";
		text = text + "bufferLength = " + YJxgmrhGdMGPkniGcIrcdScWCULe + "\n";
		text = text + "reportLength = " + gYvbRztLqcPpQaEsDreUlHXMLoES + "\n";
		string text2 = text;
		int nadNaDdOvUUOWifUshEFULBlVOiN = (int)NadNaDdOvUUOWifUshEFULBlVOiN;
		text = text2 + "options = " + nadNaDdOvUUOWifUshEFULBlVOiN + "\n";
		if (GEoKoDLgzuOgaHNmtaKAjGyTRPHPA != IntPtr.Zero)
		{
			text += "Buffer data:\n";
			for (int i = 0; i < gYvbRztLqcPpQaEsDreUlHXMLoES; i++)
			{
				text += Marshal.ReadByte(GEoKoDLgzuOgaHNmtaKAjGyTRPHPA, i).ToString("X2");
				if (i < gYvbRztLqcPpQaEsDreUlHXMLoES - 1)
				{
					text += ", ";
				}
			}
		}
		return text;
	}
}

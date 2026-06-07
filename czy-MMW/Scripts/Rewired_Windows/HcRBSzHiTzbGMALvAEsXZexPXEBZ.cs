using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout((LayoutKind)2, Pack = 1)]
internal struct HcRBSzHiTzbGMALvAEsXZexPXEBZ
{
	[FieldOffset(0)]
	private int sgetyMheahHbpgqmSOFaTdoPdjQO;

	[FieldOffset(0)]
	private long qYeBHVAgvDvMIhhIHFTKgyozoXAm;

	[FieldOffset(0)]
	private IntPtr FoomgkxmCriLlgObcPiTyKvazJPPA;

	private static readonly bool GLYhKTbcQOINnKehSDYLcgKdTLPQ;

	public static readonly int IabIDFFXuzTzMKLlKXhbFJMnNlAAb;

	static HcRBSzHiTzbGMALvAEsXZexPXEBZ()
	{
		IabIDFFXuzTzMKLlKXhbFJMnNlAAb = IntPtr.Size;
		GLYhKTbcQOINnKehSDYLcgKdTLPQ = IabIDFFXuzTzMKLlKXhbFJMnNlAAb == 8;
	}

	public static HcRBSzHiTzbGMALvAEsXZexPXEBZ fUQicADzxXIQrkxzHoyafEzebDHj(byte[] P_0, int P_1)
	{
		HcRBSzHiTzbGMALvAEsXZexPXEBZ result = default(HcRBSzHiTzbGMALvAEsXZexPXEBZ);
		if (GLYhKTbcQOINnKehSDYLcgKdTLPQ)
		{
			result.qYeBHVAgvDvMIhhIHFTKgyozoXAm = BitConverter.ToInt64(P_0, P_1);
			result.FoomgkxmCriLlgObcPiTyKvazJPPA = new IntPtr(result.qYeBHVAgvDvMIhhIHFTKgyozoXAm);
		}
		else
		{
			result.sgetyMheahHbpgqmSOFaTdoPdjQO = BitConverter.ToInt32(P_0, P_1);
			result.FoomgkxmCriLlgObcPiTyKvazJPPA = new IntPtr(result.sgetyMheahHbpgqmSOFaTdoPdjQO);
		}
		return result;
	}

	[SpecialName]
	public static HcRBSzHiTzbGMALvAEsXZexPXEBZ hWZgqaHVSypUmdJEsvIjORzlXnweA(IntPtr P_0)
	{
		HcRBSzHiTzbGMALvAEsXZexPXEBZ result = new HcRBSzHiTzbGMALvAEsXZexPXEBZ
		{
			FoomgkxmCriLlgObcPiTyKvazJPPA = P_0
		};
		if (GLYhKTbcQOINnKehSDYLcgKdTLPQ)
		{
			result.qYeBHVAgvDvMIhhIHFTKgyozoXAm = P_0.ToInt64();
		}
		else
		{
			result.sgetyMheahHbpgqmSOFaTdoPdjQO = P_0.ToInt32();
		}
		return result;
	}

	[SpecialName]
	public static IntPtr WkKmSDBqDFoXCMFhycRbkxUzcAe(HcRBSzHiTzbGMALvAEsXZexPXEBZ P_0)
	{
		return P_0.FoomgkxmCriLlgObcPiTyKvazJPPA;
	}

	public string VQjgGZIbOeVNUuOuofHZmotDedHXA()
	{
		if (GLYhKTbcQOINnKehSDYLcgKdTLPQ)
		{
			return qYeBHVAgvDvMIhhIHFTKgyozoXAm.ToString();
		}
		return sgetyMheahHbpgqmSOFaTdoPdjQO.ToString();
	}
}

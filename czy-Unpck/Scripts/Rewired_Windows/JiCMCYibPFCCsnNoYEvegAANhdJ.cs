using System.Globalization;
using System.Runtime.CompilerServices;

internal struct JiCMCYibPFCCsnNoYEvegAANhdJ : sICszkYwpNiWijkjbVFpRqgCSlS
{
	[CompilerGenerated]
	private int fMmMWTgxeZVJITOSdeqegfMziDqj;

	[CompilerGenerated]
	private int cJthCaWMkXDBMUrxOobqkYUcpYI;

	[CompilerGenerated]
	private int mOACUFOhzabpECRulHNiUmKnmPuc;

	[CompilerGenerated]
	private int xQNMKHoNyfvenNDzoyAxiMIhBVw;

	public int RawOffset
	{
		[CompilerGenerated]
		get
		{
			return fMmMWTgxeZVJITOSdeqegfMziDqj;
		}
		[CompilerGenerated]
		set
		{
			fMmMWTgxeZVJITOSdeqegfMziDqj = value;
		}
	}

	public int Value
	{
		[CompilerGenerated]
		get
		{
			return cJthCaWMkXDBMUrxOobqkYUcpYI;
		}
		[CompilerGenerated]
		set
		{
			cJthCaWMkXDBMUrxOobqkYUcpYI = value;
		}
	}

	public int Timestamp
	{
		[CompilerGenerated]
		get
		{
			return mOACUFOhzabpECRulHNiUmKnmPuc;
		}
		[CompilerGenerated]
		set
		{
			mOACUFOhzabpECRulHNiUmKnmPuc = value;
		}
	}

	public int Sequence
	{
		[CompilerGenerated]
		get
		{
			return xQNMKHoNyfvenNDzoyAxiMIhBVw;
		}
		[CompilerGenerated]
		set
		{
			xQNMKHoNyfvenNDzoyAxiMIhBVw = value;
		}
	}

	public JyGPXuuGnWQnEiWwiRmuNcSKdlm Offset => (JyGPXuuGnWQnEiWwiRmuNcSKdlm)RawOffset;

	public bool IsButton
	{
		get
		{
			if (Offset >= JyGPXuuGnWQnEiWwiRmuNcSKdlm.kvgxnwcmXJfPwIpDErgyOXIkVzq)
			{
				return Offset <= JyGPXuuGnWQnEiWwiRmuNcSKdlm.RDAiiKyySIejaPDZiGAMyiIbYux;
			}
			return false;
		}
	}

	public override string ToString()
	{
		object obj = ((Offset < JyGPXuuGnWQnEiWwiRmuNcSKdlm.kvgxnwcmXJfPwIpDErgyOXIkVzq) ? ((object)Value) : ((object)((Value & 0x80) != 0)));
		return string.Format(CultureInfo.InvariantCulture, "Offset: {0}, Value: {1} Timestamp: {2} Sequence: {3}", Offset, obj, Timestamp, Sequence);
	}
}

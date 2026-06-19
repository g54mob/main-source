using System.Globalization;
using System.Runtime.CompilerServices;

internal struct CxtCtjaqPTiIJAtrfQzRXLFwdcUL : nDrEgNGnTRWwjtbFlemJsFzwuXR
{
	[CompilerGenerated]
	private int sBXhiwubELfJZDeydaNIHRBNIAbX;

	[CompilerGenerated]
	private int fSCbEFKOiXUVLBIHUzBIJZZUgwNP;

	[CompilerGenerated]
	private int xSlEpcSVHgVvFNrIxImCHLZPzOzB;

	[CompilerGenerated]
	private int klyfwocrSdgsgVsBufyLHnTLOml;

	public int RawOffset
	{
		[CompilerGenerated]
		get
		{
			return sBXhiwubELfJZDeydaNIHRBNIAbX;
		}
		[CompilerGenerated]
		set
		{
			sBXhiwubELfJZDeydaNIHRBNIAbX = value;
		}
	}

	public int Value
	{
		[CompilerGenerated]
		get
		{
			return fSCbEFKOiXUVLBIHUzBIJZZUgwNP;
		}
		[CompilerGenerated]
		set
		{
			fSCbEFKOiXUVLBIHUzBIJZZUgwNP = value;
		}
	}

	public int Timestamp
	{
		[CompilerGenerated]
		get
		{
			return xSlEpcSVHgVvFNrIxImCHLZPzOzB;
		}
		[CompilerGenerated]
		set
		{
			xSlEpcSVHgVvFNrIxImCHLZPzOzB = value;
		}
	}

	public int Sequence
	{
		[CompilerGenerated]
		get
		{
			return klyfwocrSdgsgVsBufyLHnTLOml;
		}
		[CompilerGenerated]
		set
		{
			klyfwocrSdgsgVsBufyLHnTLOml = value;
		}
	}

	public EEpRoHwRHSLOZaxUatsMwXPeiuf Offset => (EEpRoHwRHSLOZaxUatsMwXPeiuf)RawOffset;

	public bool IsButton
	{
		get
		{
			if (Offset >= EEpRoHwRHSLOZaxUatsMwXPeiuf.roFOWNsXzVtFzUVhAShEvmVQYJl)
			{
				return Offset <= EEpRoHwRHSLOZaxUatsMwXPeiuf.SVvkZhqUsEPobRWxwlUsTZVNhOo;
			}
			return false;
		}
	}

	public override string ToString()
	{
		object obj = ((Offset < EEpRoHwRHSLOZaxUatsMwXPeiuf.roFOWNsXzVtFzUVhAShEvmVQYJl) ? ((object)Value) : ((object)((Value & 0x80) != 0)));
		return string.Format(CultureInfo.InvariantCulture, "Offset: {0}, Value: {1} Timestamp: {2} Sequence: {3}", Offset, obj, Timestamp, Sequence);
	}
}

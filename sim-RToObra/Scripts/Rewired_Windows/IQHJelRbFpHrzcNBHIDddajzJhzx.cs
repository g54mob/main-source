using System.Globalization;
using System.Runtime.CompilerServices;

internal struct IQHJelRbFpHrzcNBHIDddajzJhzx : ljBboFKnVnZvPrifuYUjgBZmjtqF
{
	[CompilerGenerated]
	private int yfhGLucNEvnanXIGgvdwqyfJdDCZ;

	[CompilerGenerated]
	private int dosogNhmkhqSvRDzBbXmwfoYpVk;

	[CompilerGenerated]
	private int hFNBicxkBYWkpQmsuQdugdxJHyI;

	[CompilerGenerated]
	private int aCGGDcEPANQFChSjzFLbuqpNxBEu;

	public int RawOffset
	{
		[CompilerGenerated]
		get
		{
			return yfhGLucNEvnanXIGgvdwqyfJdDCZ;
		}
		[CompilerGenerated]
		set
		{
			yfhGLucNEvnanXIGgvdwqyfJdDCZ = value;
		}
	}

	public int Value
	{
		[CompilerGenerated]
		get
		{
			return dosogNhmkhqSvRDzBbXmwfoYpVk;
		}
		[CompilerGenerated]
		set
		{
			dosogNhmkhqSvRDzBbXmwfoYpVk = value;
		}
	}

	public int Timestamp
	{
		[CompilerGenerated]
		get
		{
			return hFNBicxkBYWkpQmsuQdugdxJHyI;
		}
		[CompilerGenerated]
		set
		{
			hFNBicxkBYWkpQmsuQdugdxJHyI = value;
		}
	}

	public int Sequence
	{
		[CompilerGenerated]
		get
		{
			return aCGGDcEPANQFChSjzFLbuqpNxBEu;
		}
		[CompilerGenerated]
		set
		{
			aCGGDcEPANQFChSjzFLbuqpNxBEu = value;
		}
	}

	public MZHUBDTHdehqtjgZrEaaHlgyrAO Offset
	{
		get
		{
			return (MZHUBDTHdehqtjgZrEaaHlgyrAO)RawOffset;
		}
	}

	public bool IsButton
	{
		get
		{
			if (Offset >= MZHUBDTHdehqtjgZrEaaHlgyrAO.njZmHLdfhhWLZoHDYycECbArNY)
			{
				return Offset <= MZHUBDTHdehqtjgZrEaaHlgyrAO.YdBhmzJhogTuNOSBnLjOovnRyOF;
			}
			return false;
		}
	}

	public override string ToString()
	{
		object obj = ((Offset < MZHUBDTHdehqtjgZrEaaHlgyrAO.njZmHLdfhhWLZoHDYycECbArNY) ? ((object)Value) : ((object)((Value & 0x80) != 0)));
		return string.Format(CultureInfo.InvariantCulture, "Offset: {0}, Value: {1} Timestamp: {2} Sequence: {3}", Offset, obj, Timestamp, Sequence);
	}
}

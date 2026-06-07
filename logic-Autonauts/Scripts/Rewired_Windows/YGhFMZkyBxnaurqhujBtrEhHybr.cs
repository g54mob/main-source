using System.Globalization;
using System.Runtime.CompilerServices;

internal struct YGhFMZkyBxnaurqhujBtrEhHybr : hqppqxEFMrkdOneNLCGrQSVQngm
{
	[CompilerGenerated]
	private int eoLSEMwCGttHqHMsFnQgxIjjBZA;

	[CompilerGenerated]
	private int vDMIfhOSmpUzcMOZizpsfyranju;

	[CompilerGenerated]
	private int vitGQGOSFYjFeGJYVpKkKpzbqDUN;

	[CompilerGenerated]
	private int oxmUSKqUtJOoFHDnAJvzfvVvRaC;

	public int RawOffset
	{
		[CompilerGenerated]
		get
		{
			return eoLSEMwCGttHqHMsFnQgxIjjBZA;
		}
		[CompilerGenerated]
		set
		{
			eoLSEMwCGttHqHMsFnQgxIjjBZA = value;
		}
	}

	public int Value
	{
		[CompilerGenerated]
		get
		{
			return vDMIfhOSmpUzcMOZizpsfyranju;
		}
		[CompilerGenerated]
		set
		{
			vDMIfhOSmpUzcMOZizpsfyranju = value;
		}
	}

	public int Timestamp
	{
		[CompilerGenerated]
		get
		{
			return vitGQGOSFYjFeGJYVpKkKpzbqDUN;
		}
		[CompilerGenerated]
		set
		{
			vitGQGOSFYjFeGJYVpKkKpzbqDUN = value;
		}
	}

	public int Sequence
	{
		[CompilerGenerated]
		get
		{
			return oxmUSKqUtJOoFHDnAJvzfvVvRaC;
		}
		[CompilerGenerated]
		set
		{
			oxmUSKqUtJOoFHDnAJvzfvVvRaC = value;
		}
	}

	public ERjtNzmsJyamqiHKUeCoQVdEFzIc Offset
	{
		get
		{
			return (ERjtNzmsJyamqiHKUeCoQVdEFzIc)RawOffset;
		}
	}

	public bool IsButton
	{
		get
		{
			if (Offset >= ERjtNzmsJyamqiHKUeCoQVdEFzIc.tCZBnjIanpTLMWOdmkssjTpuuZEF)
			{
				return Offset <= ERjtNzmsJyamqiHKUeCoQVdEFzIc.IlbdeJbomyYYMHOtCcROIbjfKoJY;
			}
			return false;
		}
	}

	public override string ToString()
	{
		object obj = ((Offset < ERjtNzmsJyamqiHKUeCoQVdEFzIc.tCZBnjIanpTLMWOdmkssjTpuuZEF) ? ((object)Value) : ((object)((Value & 0x80) != 0)));
		return string.Format(CultureInfo.InvariantCulture, "Offset: {0}, Value: {1} Timestamp: {2} Sequence: {3}", Offset, obj, Timestamp, Sequence);
	}
}

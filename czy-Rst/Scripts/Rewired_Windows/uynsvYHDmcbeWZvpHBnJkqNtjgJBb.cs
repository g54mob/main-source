using System;
using System.Runtime.CompilerServices;

internal struct uynsvYHDmcbeWZvpHBnJkqNtjgJBb : IEquatable<uynsvYHDmcbeWZvpHBnJkqNtjgJBb>
{
	public static readonly uynsvYHDmcbeWZvpHBnJkqNtjgJBb GGJQGIRxDCxQewnhtXflNiMfjwnM = new uynsvYHDmcbeWZvpHBnJkqNtjgJBb(0, 0);

	public static readonly uynsvYHDmcbeWZvpHBnJkqNtjgJBb wwKRfUBsLWovPsjJYCYFqQzVRwLR = GGJQGIRxDCxQewnhtXflNiMfjwnM;

	public int WOHhnqzWtiihneiQjkxBTrLAHHPw;

	public int rzbJvitpsgLXcHqDOMTivLPoCrVE;

	public uynsvYHDmcbeWZvpHBnJkqNtjgJBb(int P_0, int P_1)
	{
		WOHhnqzWtiihneiQjkxBTrLAHHPw = P_0;
		rzbJvitpsgLXcHqDOMTivLPoCrVE = P_1;
	}

	public bool Equals(uynsvYHDmcbeWZvpHBnJkqNtjgJBb other)
	{
		if (other.WOHhnqzWtiihneiQjkxBTrLAHHPw == WOHhnqzWtiihneiQjkxBTrLAHHPw)
		{
			return other.rzbJvitpsgLXcHqDOMTivLPoCrVE == rzbJvitpsgLXcHqDOMTivLPoCrVE;
		}
		return false;
	}

	bool IEquatable<uynsvYHDmcbeWZvpHBnJkqNtjgJBb>.Equals(uynsvYHDmcbeWZvpHBnJkqNtjgJBb other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool uKGyECTmINAGKdfSMEbRXejbslufA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(uynsvYHDmcbeWZvpHBnJkqNtjgJBb))
		{
			return false;
		}
		return Equals((uynsvYHDmcbeWZvpHBnJkqNtjgJBb)P_0);
	}

	public int AEsNqZztOluBNQdYkRasQeOWmaIk()
	{
		return (WOHhnqzWtiihneiQjkxBTrLAHHPw * 397) ^ rzbJvitpsgLXcHqDOMTivLPoCrVE;
	}

	[SpecialName]
	public static bool HINQPeNowikDMqPnLROBcxwJuGAr(uynsvYHDmcbeWZvpHBnJkqNtjgJBb P_0, uynsvYHDmcbeWZvpHBnJkqNtjgJBb P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool AvswslUrIBJcrulxnAvbpkfvZuRG(uynsvYHDmcbeWZvpHBnJkqNtjgJBb P_0, uynsvYHDmcbeWZvpHBnJkqNtjgJBb P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string AgpKjSVyhxGNFfLLmxLQCsmFCvgS()
	{
		return $"({WOHhnqzWtiihneiQjkxBTrLAHHPw},{rzbJvitpsgLXcHqDOMTivLPoCrVE})";
	}
}

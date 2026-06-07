using System;
using System.Runtime.CompilerServices;

internal struct sWMtxJuQbVsqyEOVlrZifGQzSJMN : IEquatable<sWMtxJuQbVsqyEOVlrZifGQzSJMN>
{
	public static readonly sWMtxJuQbVsqyEOVlrZifGQzSJMN QagaoHOZMTBPVQnvZJmDirYxGdGB = new sWMtxJuQbVsqyEOVlrZifGQzSJMN(0, 0);

	public int akBBQvHGNmOoexbuVhBsGGBjXjqRA;

	public int xDcojUNhgkrNNUMJMYHuxsBcZDRH;

	public sWMtxJuQbVsqyEOVlrZifGQzSJMN(int P_0, int P_1)
	{
		akBBQvHGNmOoexbuVhBsGGBjXjqRA = P_0;
		xDcojUNhgkrNNUMJMYHuxsBcZDRH = P_1;
	}

	public bool Equals(sWMtxJuQbVsqyEOVlrZifGQzSJMN other)
	{
		if (other.akBBQvHGNmOoexbuVhBsGGBjXjqRA == akBBQvHGNmOoexbuVhBsGGBjXjqRA)
		{
			return other.xDcojUNhgkrNNUMJMYHuxsBcZDRH == xDcojUNhgkrNNUMJMYHuxsBcZDRH;
		}
		return false;
	}

	bool IEquatable<sWMtxJuQbVsqyEOVlrZifGQzSJMN>.Equals(sWMtxJuQbVsqyEOVlrZifGQzSJMN other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool EcKPahtTXyrXHDaQMzCHwGwOqNVy(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(sWMtxJuQbVsqyEOVlrZifGQzSJMN))
		{
			return false;
		}
		return Equals((sWMtxJuQbVsqyEOVlrZifGQzSJMN)P_0);
	}

	public int tcBHMUkyDFDRiVIqnxrJijlogafv()
	{
		return (akBBQvHGNmOoexbuVhBsGGBjXjqRA * 397) ^ xDcojUNhgkrNNUMJMYHuxsBcZDRH;
	}

	[SpecialName]
	public static bool xpyzJNhghuXhhZXiegPFpeJazPOu(sWMtxJuQbVsqyEOVlrZifGQzSJMN P_0, sWMtxJuQbVsqyEOVlrZifGQzSJMN P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool PWyqOrYzEXqQOJPGreGvqWGEvVRM(sWMtxJuQbVsqyEOVlrZifGQzSJMN P_0, sWMtxJuQbVsqyEOVlrZifGQzSJMN P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string iWuUnLJNEsNZqmeDpoObjGsCUXMJ()
	{
		return $"({akBBQvHGNmOoexbuVhBsGGBjXjqRA},{xDcojUNhgkrNNUMJMYHuxsBcZDRH})";
	}
}

using System;
using System.Runtime.CompilerServices;

internal struct gImTUzOGmlLUVHhZfDblcFQvlRczA : IEquatable<gImTUzOGmlLUVHhZfDblcFQvlRczA>
{
	public static readonly gImTUzOGmlLUVHhZfDblcFQvlRczA DNUQeQhbcXahkIqZaBMMfAOQscLb = new gImTUzOGmlLUVHhZfDblcFQvlRczA(0, 0);

	public static readonly gImTUzOGmlLUVHhZfDblcFQvlRczA uMVHqbcnPiGcMKRopEupOZnOYltfA = DNUQeQhbcXahkIqZaBMMfAOQscLb;

	public int sMhjKmedaJXvuWuJjxGXzPNNYASh;

	public int QEnfVkaMwVYHdztLXaIgjMjEhryEA;

	public gImTUzOGmlLUVHhZfDblcFQvlRczA(int P_0, int P_1)
	{
		sMhjKmedaJXvuWuJjxGXzPNNYASh = P_0;
		QEnfVkaMwVYHdztLXaIgjMjEhryEA = P_1;
	}

	public bool Equals(gImTUzOGmlLUVHhZfDblcFQvlRczA other)
	{
		if (other.sMhjKmedaJXvuWuJjxGXzPNNYASh == sMhjKmedaJXvuWuJjxGXzPNNYASh)
		{
			return other.QEnfVkaMwVYHdztLXaIgjMjEhryEA == QEnfVkaMwVYHdztLXaIgjMjEhryEA;
		}
		return false;
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(gImTUzOGmlLUVHhZfDblcFQvlRczA))
		{
			return false;
		}
		return Equals((gImTUzOGmlLUVHhZfDblcFQvlRczA)P_0);
	}

	public int bmOcwbrzltTGalVFCIlUiIeugfGh()
	{
		return (sMhjKmedaJXvuWuJjxGXzPNNYASh * 397) ^ QEnfVkaMwVYHdztLXaIgjMjEhryEA;
	}

	[SpecialName]
	public static bool UxzrDeMrBdIYZHmpHMJBdoPkTemL(gImTUzOGmlLUVHhZfDblcFQvlRczA P_0, gImTUzOGmlLUVHhZfDblcFQvlRczA P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool ymVlplVHAhddfhnAkCmAWabpGMPgb(gImTUzOGmlLUVHhZfDblcFQvlRczA P_0, gImTUzOGmlLUVHhZfDblcFQvlRczA P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return $"({sMhjKmedaJXvuWuJjxGXzPNNYASh},{QEnfVkaMwVYHdztLXaIgjMjEhryEA})";
	}
}

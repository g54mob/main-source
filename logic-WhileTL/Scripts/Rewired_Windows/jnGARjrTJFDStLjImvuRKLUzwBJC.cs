using System;
using System.Runtime.CompilerServices;

internal struct jnGARjrTJFDStLjImvuRKLUzwBJC : IEquatable<jnGARjrTJFDStLjImvuRKLUzwBJC>
{
	public static readonly jnGARjrTJFDStLjImvuRKLUzwBJC DNUQeQhbcXahkIqZaBMMfAOQscLb = new jnGARjrTJFDStLjImvuRKLUzwBJC(0, 0);

	public int RCyEFnmMbZQABDUevMWhbVQzTujo;

	public int fUeJOoPRVduJmSWUtOameNDdhtWbA;

	public jnGARjrTJFDStLjImvuRKLUzwBJC(int P_0, int P_1)
	{
		RCyEFnmMbZQABDUevMWhbVQzTujo = P_0;
		fUeJOoPRVduJmSWUtOameNDdhtWbA = P_1;
	}

	public bool Equals(jnGARjrTJFDStLjImvuRKLUzwBJC other)
	{
		if (other.RCyEFnmMbZQABDUevMWhbVQzTujo == RCyEFnmMbZQABDUevMWhbVQzTujo)
		{
			return other.fUeJOoPRVduJmSWUtOameNDdhtWbA == fUeJOoPRVduJmSWUtOameNDdhtWbA;
		}
		return false;
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(jnGARjrTJFDStLjImvuRKLUzwBJC))
		{
			return false;
		}
		return Equals((jnGARjrTJFDStLjImvuRKLUzwBJC)P_0);
	}

	public int bmOcwbrzltTGalVFCIlUiIeugfGh()
	{
		return (RCyEFnmMbZQABDUevMWhbVQzTujo * 397) ^ fUeJOoPRVduJmSWUtOameNDdhtWbA;
	}

	[SpecialName]
	public static bool UxzrDeMrBdIYZHmpHMJBdoPkTemL(jnGARjrTJFDStLjImvuRKLUzwBJC P_0, jnGARjrTJFDStLjImvuRKLUzwBJC P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool ymVlplVHAhddfhnAkCmAWabpGMPgb(jnGARjrTJFDStLjImvuRKLUzwBJC P_0, jnGARjrTJFDStLjImvuRKLUzwBJC P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return $"({RCyEFnmMbZQABDUevMWhbVQzTujo},{fUeJOoPRVduJmSWUtOameNDdhtWbA})";
	}
}

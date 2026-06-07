using System;
using System.Runtime.CompilerServices;

internal struct bkavrHDWcffiWUczwZFCihBlwezH : IEquatable<bkavrHDWcffiWUczwZFCihBlwezH>
{
	public static readonly bkavrHDWcffiWUczwZFCihBlwezH TESIYBcDvPHguVfzIKzmKRWzMgTzA = new bkavrHDWcffiWUczwZFCihBlwezH(0, 0);

	public static readonly bkavrHDWcffiWUczwZFCihBlwezH vFHtoXRvGTxmRlRZxyuCmfGByYre = TESIYBcDvPHguVfzIKzmKRWzMgTzA;

	public int TOCvbddrThQnjzdSUrLURcLGVXhw;

	public int sHwLZdtXTztIoEvqhdkhpkLaAKlbA;

	public bkavrHDWcffiWUczwZFCihBlwezH(int P_0, int P_1)
	{
		TOCvbddrThQnjzdSUrLURcLGVXhw = P_0;
		sHwLZdtXTztIoEvqhdkhpkLaAKlbA = P_1;
	}

	public bool Equals(bkavrHDWcffiWUczwZFCihBlwezH other)
	{
		if (other.TOCvbddrThQnjzdSUrLURcLGVXhw == TOCvbddrThQnjzdSUrLURcLGVXhw)
		{
			return other.sHwLZdtXTztIoEvqhdkhpkLaAKlbA == sHwLZdtXTztIoEvqhdkhpkLaAKlbA;
		}
		return false;
	}

	bool IEquatable<bkavrHDWcffiWUczwZFCihBlwezH>.Equals(bkavrHDWcffiWUczwZFCihBlwezH other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool vXPYEVVSyUDHEgkErLjMimpzlOSH(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(bkavrHDWcffiWUczwZFCihBlwezH))
		{
			return false;
		}
		return Equals((bkavrHDWcffiWUczwZFCihBlwezH)P_0);
	}

	public int RXtlZSpVPaLzNFmQFodhUCMSVemt()
	{
		return (TOCvbddrThQnjzdSUrLURcLGVXhw * 397) ^ sHwLZdtXTztIoEvqhdkhpkLaAKlbA;
	}

	[SpecialName]
	public static bool CYUZuxLYSxUsMlbLsygIqcyPKGgH(bkavrHDWcffiWUczwZFCihBlwezH P_0, bkavrHDWcffiWUczwZFCihBlwezH P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool LNrTgkQfoGnKrxEhYBysHxvbjRfBA(bkavrHDWcffiWUczwZFCihBlwezH P_0, bkavrHDWcffiWUczwZFCihBlwezH P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string XcdjLXDNePQNQmVRitRpSwJfhCFb()
	{
		return $"({TOCvbddrThQnjzdSUrLURcLGVXhw},{sHwLZdtXTztIoEvqhdkhpkLaAKlbA})";
	}
}

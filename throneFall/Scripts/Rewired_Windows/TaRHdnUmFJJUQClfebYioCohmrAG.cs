using System;
using System.Runtime.CompilerServices;

internal struct TaRHdnUmFJJUQClfebYioCohmrAG : IEquatable<TaRHdnUmFJJUQClfebYioCohmrAG>
{
	public static readonly TaRHdnUmFJJUQClfebYioCohmrAG vHymMmrPHbAmHcDNYbqugRGpeCBtA = new TaRHdnUmFJJUQClfebYioCohmrAG(0f, 0f);

	public static readonly TaRHdnUmFJJUQClfebYioCohmrAG EtpzZkIDEMHVcHiEdPnRhTNyYjxe = vHymMmrPHbAmHcDNYbqugRGpeCBtA;

	public float eVrZakroJDUDfwYENQbNUdXtjNYg;

	public float CzarnBwJVoOAaLRFtKcIxVpOhzjs;

	public TaRHdnUmFJJUQClfebYioCohmrAG(float P_0, float P_1)
	{
		eVrZakroJDUDfwYENQbNUdXtjNYg = P_0;
		CzarnBwJVoOAaLRFtKcIxVpOhzjs = P_1;
	}

	public bool Equals(TaRHdnUmFJJUQClfebYioCohmrAG other)
	{
		if (other.eVrZakroJDUDfwYENQbNUdXtjNYg == eVrZakroJDUDfwYENQbNUdXtjNYg)
		{
			return other.CzarnBwJVoOAaLRFtKcIxVpOhzjs == CzarnBwJVoOAaLRFtKcIxVpOhzjs;
		}
		return false;
	}

	bool IEquatable<TaRHdnUmFJJUQClfebYioCohmrAG>.Equals(TaRHdnUmFJJUQClfebYioCohmrAG other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool iaYQLIcJpeCNnUImvtQFGeuRrQLy(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(TaRHdnUmFJJUQClfebYioCohmrAG))
		{
			return false;
		}
		return Equals((TaRHdnUmFJJUQClfebYioCohmrAG)P_0);
	}

	public int hzRIPvJUpNTwgkHZQtXbwSzvHnDx()
	{
		return (eVrZakroJDUDfwYENQbNUdXtjNYg.GetHashCode() * 397) ^ CzarnBwJVoOAaLRFtKcIxVpOhzjs.GetHashCode();
	}

	[SpecialName]
	public static bool StCoCnIFguHgLjTqPewnXGpqIKtY(TaRHdnUmFJJUQClfebYioCohmrAG P_0, TaRHdnUmFJJUQClfebYioCohmrAG P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool EgmzmUzRhlhaPUlxkShQUTAMwpo(TaRHdnUmFJJUQClfebYioCohmrAG P_0, TaRHdnUmFJJUQClfebYioCohmrAG P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string uoizeXSvbcADnCVxNtcddjXhwKKx()
	{
		return $"({eVrZakroJDUDfwYENQbNUdXtjNYg},{CzarnBwJVoOAaLRFtKcIxVpOhzjs})";
	}
}

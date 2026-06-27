using System;
using System.Runtime.CompilerServices;

internal struct fnZjeIaETChryBLPEIhpAzWjyXuLA : IEquatable<fnZjeIaETChryBLPEIhpAzWjyXuLA>
{
	public static readonly fnZjeIaETChryBLPEIhpAzWjyXuLA VavkklSNhSTQBFEjmpjraDhhIAFkA = new fnZjeIaETChryBLPEIhpAzWjyXuLA(0, 0);

	public int zbAeGyWWrlWlkiQusNdpEhHdYfOu;

	public int yetQqFZpGtnyDTlLpasptFBmEVvQ;

	public fnZjeIaETChryBLPEIhpAzWjyXuLA(int P_0, int P_1)
	{
		zbAeGyWWrlWlkiQusNdpEhHdYfOu = P_0;
		yetQqFZpGtnyDTlLpasptFBmEVvQ = P_1;
	}

	public bool Equals(fnZjeIaETChryBLPEIhpAzWjyXuLA other)
	{
		if (other.zbAeGyWWrlWlkiQusNdpEhHdYfOu == zbAeGyWWrlWlkiQusNdpEhHdYfOu)
		{
			return other.yetQqFZpGtnyDTlLpasptFBmEVvQ == yetQqFZpGtnyDTlLpasptFBmEVvQ;
		}
		return false;
	}

	bool IEquatable<fnZjeIaETChryBLPEIhpAzWjyXuLA>.Equals(fnZjeIaETChryBLPEIhpAzWjyXuLA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool RgBaOkpHrjEDZICKxCeCqFgAxRxT(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(fnZjeIaETChryBLPEIhpAzWjyXuLA))
		{
			return false;
		}
		return Equals((fnZjeIaETChryBLPEIhpAzWjyXuLA)P_0);
	}

	public int cdEhBPqVhEgIeAWuMUPInofoHmPQA()
	{
		return (zbAeGyWWrlWlkiQusNdpEhHdYfOu * 397) ^ yetQqFZpGtnyDTlLpasptFBmEVvQ;
	}

	[SpecialName]
	public static bool stnJZGzCJdmIhEMaVjgYlFXocTkt(fnZjeIaETChryBLPEIhpAzWjyXuLA P_0, fnZjeIaETChryBLPEIhpAzWjyXuLA P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool KGtSukMaJKFAAGgMWcLkmcAUTBnL(fnZjeIaETChryBLPEIhpAzWjyXuLA P_0, fnZjeIaETChryBLPEIhpAzWjyXuLA P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string hmfvIYTumrUSajfXUcSejfmSrIqO()
	{
		return $"({zbAeGyWWrlWlkiQusNdpEhHdYfOu},{yetQqFZpGtnyDTlLpasptFBmEVvQ})";
	}
}

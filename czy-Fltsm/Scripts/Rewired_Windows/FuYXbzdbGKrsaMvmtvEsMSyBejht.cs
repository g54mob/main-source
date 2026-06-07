using System;
using System.Runtime.CompilerServices;

internal struct FuYXbzdbGKrsaMvmtvEsMSyBejht : IEquatable<FuYXbzdbGKrsaMvmtvEsMSyBejht>
{
	public static readonly FuYXbzdbGKrsaMvmtvEsMSyBejht dObqauCICwRzroiKJPqcxfCNdPcW = new FuYXbzdbGKrsaMvmtvEsMSyBejht(0f, 0f);

	public static readonly FuYXbzdbGKrsaMvmtvEsMSyBejht CjeYZozcUTCmAeZdqjiZUZNQQVEMA = dObqauCICwRzroiKJPqcxfCNdPcW;

	public float apaGdyMxrIzrJoOJEHhZHuTTNixIb;

	public float SLhFaJNCCbBbYRLIebPQaBxgJoAgA;

	public FuYXbzdbGKrsaMvmtvEsMSyBejht(float P_0, float P_1)
	{
		apaGdyMxrIzrJoOJEHhZHuTTNixIb = P_0;
		SLhFaJNCCbBbYRLIebPQaBxgJoAgA = P_1;
	}

	public bool Equals(FuYXbzdbGKrsaMvmtvEsMSyBejht other)
	{
		if (other.apaGdyMxrIzrJoOJEHhZHuTTNixIb == apaGdyMxrIzrJoOJEHhZHuTTNixIb)
		{
			return other.SLhFaJNCCbBbYRLIebPQaBxgJoAgA == SLhFaJNCCbBbYRLIebPQaBxgJoAgA;
		}
		return false;
	}

	bool IEquatable<FuYXbzdbGKrsaMvmtvEsMSyBejht>.Equals(FuYXbzdbGKrsaMvmtvEsMSyBejht other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool uGJxbCVFatDoRAwdoDfHgWkrNseL(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(FuYXbzdbGKrsaMvmtvEsMSyBejht))
		{
			return false;
		}
		return Equals((FuYXbzdbGKrsaMvmtvEsMSyBejht)P_0);
	}

	public int lQAddtwQiIvLEiFULZslILnPBiou()
	{
		return (apaGdyMxrIzrJoOJEHhZHuTTNixIb.GetHashCode() * 397) ^ SLhFaJNCCbBbYRLIebPQaBxgJoAgA.GetHashCode();
	}

	[SpecialName]
	public static bool MzTonvxPtxNDrjyvCJrbpgjOPICI(FuYXbzdbGKrsaMvmtvEsMSyBejht P_0, FuYXbzdbGKrsaMvmtvEsMSyBejht P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool AzfbLgtuUuwQWRDkobdlksBqrzMCA(FuYXbzdbGKrsaMvmtvEsMSyBejht P_0, FuYXbzdbGKrsaMvmtvEsMSyBejht P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string aWjUKLneoxgnXCauWHWjTJdTBWfC()
	{
		return $"({apaGdyMxrIzrJoOJEHhZHuTTNixIb},{SLhFaJNCCbBbYRLIebPQaBxgJoAgA})";
	}
}

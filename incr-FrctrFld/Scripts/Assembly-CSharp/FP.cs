using System;

[Serializable]
public struct FP : IComparable<FP>
{
	public long RawValue;

	public const int SHIFT_AMOUNT = 12;

	private const long _one = 4096L;

	public static FP One;

	public static FP Zero;

	public static FP OneThousand;

	public static FP MaxValue;

	public static FP MinValue;

	public int IntValue => 0;

	public float FloatValue => 0f;

	public FP Inverse => default(FP);

	public static FP Create(long StartingRawValue, bool NeedsShifting)
	{
		return default(FP);
	}

	public static FP Create(double DoubleValue)
	{
		return default(FP);
	}

	public int ToInt()
	{
		return 0;
	}

	public double ToDouble()
	{
		return 0.0;
	}

	public static FP Abs(FP F1)
	{
		return default(FP);
	}

	public static FP FromParts(int PreDecimal, int PostDecimal)
	{
		return default(FP);
	}

	public static FP FromRational(int numerator, int denominator)
	{
		return default(FP);
	}

	public static FP operator *(FP one, FP other)
	{
		return default(FP);
	}

	public static FP operator *(FP one, int multi)
	{
		return default(FP);
	}

	public static FP operator *(int multi, FP one)
	{
		return default(FP);
	}

	public static FP operator /(FP one, FP other)
	{
		return default(FP);
	}

	public static FP operator /(FP one, int divisor)
	{
		return default(FP);
	}

	public static FP operator /(int divisor, FP one)
	{
		return default(FP);
	}

	public static FP operator %(FP one, FP other)
	{
		return default(FP);
	}

	public static FP operator %(FP one, int divisor)
	{
		return default(FP);
	}

	public static FP operator %(int divisor, FP one)
	{
		return default(FP);
	}

	public static FP operator +(FP one, FP other)
	{
		return default(FP);
	}

	public static FP operator +(FP one, int other)
	{
		return default(FP);
	}

	public static FP operator +(int other, FP one)
	{
		return default(FP);
	}

	public static FP operator -(FP one, FP other)
	{
		return default(FP);
	}

	public static FP operator -(FP one, int other)
	{
		return default(FP);
	}

	public static FP operator -(int other, FP one)
	{
		return default(FP);
	}

	public static bool operator ==(FP one, FP other)
	{
		return false;
	}

	public static bool operator ==(FP one, int other)
	{
		return false;
	}

	public static bool operator ==(int other, FP one)
	{
		return false;
	}

	public static bool operator !=(FP one, FP other)
	{
		return false;
	}

	public static bool operator !=(FP one, int other)
	{
		return false;
	}

	public static bool operator !=(int other, FP one)
	{
		return false;
	}

	public static bool operator >=(FP one, FP other)
	{
		return false;
	}

	public static bool operator >=(FP one, int other)
	{
		return false;
	}

	public static bool operator >=(int other, FP one)
	{
		return false;
	}

	public static bool operator <=(FP one, FP other)
	{
		return false;
	}

	public static bool operator <=(FP one, int other)
	{
		return false;
	}

	public static bool operator <=(int other, FP one)
	{
		return false;
	}

	public static bool operator >(FP one, FP other)
	{
		return false;
	}

	public static bool operator >(FP one, int other)
	{
		return false;
	}

	public static bool operator >(int other, FP one)
	{
		return false;
	}

	public static bool operator <(FP one, FP other)
	{
		return false;
	}

	public static bool operator <(FP one, int other)
	{
		return false;
	}

	public static bool operator <(int other, FP one)
	{
		return false;
	}

	public static explicit operator int(FP src)
	{
		return 0;
	}

	public static explicit operator FP(int src)
	{
		return default(FP);
	}

	public static explicit operator FP(long src)
	{
		return default(FP);
	}

	public static explicit operator FP(ulong src)
	{
		return default(FP);
	}

	public static FP operator <<(FP one, int Amount)
	{
		return default(FP);
	}

	public static FP operator >>(FP one, int Amount)
	{
		return default(FP);
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public int CompareTo(FP other)
	{
		return 0;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override string ToString()
	{
		return null;
	}

	public static FP Add(FP left, FP right)
	{
		return default(FP);
	}

	public static FP Add(FP left, float right)
	{
		return default(FP);
	}

	public static FP Add(FP left, int right)
	{
		return default(FP);
	}

	public static FP Add(float left, float right)
	{
		return default(FP);
	}

	public static FP Add(float left, FP right)
	{
		return default(FP);
	}

	public static FP Add(float left, int right)
	{
		return default(FP);
	}

	public static FP Add(int left, int right)
	{
		return default(FP);
	}

	public static FP Add(int left, FP right)
	{
		return default(FP);
	}

	public static FP Add(int left, float right)
	{
		return default(FP);
	}

	public static FP Subtract(FP left, FP right)
	{
		return default(FP);
	}

	public static FP Subtract(FP left, float right)
	{
		return default(FP);
	}

	public static FP Subtract(FP left, int right)
	{
		return default(FP);
	}

	public static FP Subtract(float left, float right)
	{
		return default(FP);
	}

	public static FP Subtract(float left, FP right)
	{
		return default(FP);
	}

	public static FP Subtract(float left, int right)
	{
		return default(FP);
	}

	public static FP Subtract(int left, int right)
	{
		return default(FP);
	}

	public static FP Subtract(int left, FP right)
	{
		return default(FP);
	}

	public static FP Subtract(int left, float right)
	{
		return default(FP);
	}

	public static FP Multiply(FP left, FP right)
	{
		return default(FP);
	}

	public static FP Multiply(FP left, float right)
	{
		return default(FP);
	}

	public static FP Multiply(FP left, int right)
	{
		return default(FP);
	}

	public static FP Multiply(float left, float right)
	{
		return default(FP);
	}

	public static FP Multiply(float left, FP right)
	{
		return default(FP);
	}

	public static FP Multiply(float left, int right)
	{
		return default(FP);
	}

	public static FP Multiply(int left, int right)
	{
		return default(FP);
	}

	public static FP Multiply(int left, FP right)
	{
		return default(FP);
	}

	public static FP Multiply(int left, float right)
	{
		return default(FP);
	}

	public static FP Divide(FP numerator, FP denominator)
	{
		return default(FP);
	}

	public static FP Divide(FP numerator, float denominator)
	{
		return default(FP);
	}

	public static FP Divide(FP numerator, int denominator)
	{
		return default(FP);
	}

	public static FP Divide(float numerator, float denominator)
	{
		return default(FP);
	}

	public static FP Divide(float numerator, FP denominator)
	{
		return default(FP);
	}

	public static FP Divide(float numerator, int denominator)
	{
		return default(FP);
	}

	public static FP Divide(int numerator, int denominator)
	{
		return default(FP);
	}

	public static FP Divide(int numerator, FP denominator)
	{
		return default(FP);
	}

	public static FP Divide(int numerator, float denominator)
	{
		return default(FP);
	}

	public static FP Max(FP first, FP second)
	{
		return default(FP);
	}

	public static FP Min(FP first, FP second)
	{
		return default(FP);
	}

	public static FP NextDouble(Random rng)
	{
		return default(FP);
	}
}

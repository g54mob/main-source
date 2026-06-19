using System;
using System.Runtime.CompilerServices;

internal struct mebkLrrYQunuBtianxwaMEUAxkkB : IEquatable<mebkLrrYQunuBtianxwaMEUAxkkB>
{
	public static readonly mebkLrrYQunuBtianxwaMEUAxkkB UwCgvYCpGeJOjLFIXgcoHtwUIRdGA = new mebkLrrYQunuBtianxwaMEUAxkkB(0f, 0f);

	public static readonly mebkLrrYQunuBtianxwaMEUAxkkB xFOcYrAELehIcVdmDXBRkvXRZJL = UwCgvYCpGeJOjLFIXgcoHtwUIRdGA;

	public float HJLyeMUpXMiFHLJUKEBRmhvYeNsL;

	public float hMGiKdDUSjqkWuzWeurGPFDxwvBk;

	public mebkLrrYQunuBtianxwaMEUAxkkB(float P_0, float P_1)
	{
		HJLyeMUpXMiFHLJUKEBRmhvYeNsL = P_0;
		hMGiKdDUSjqkWuzWeurGPFDxwvBk = P_1;
	}

	public bool Equals(mebkLrrYQunuBtianxwaMEUAxkkB other)
	{
		if (other.HJLyeMUpXMiFHLJUKEBRmhvYeNsL == HJLyeMUpXMiFHLJUKEBRmhvYeNsL)
		{
			return other.hMGiKdDUSjqkWuzWeurGPFDxwvBk == hMGiKdDUSjqkWuzWeurGPFDxwvBk;
		}
		return false;
	}

	bool IEquatable<mebkLrrYQunuBtianxwaMEUAxkkB>.Equals(mebkLrrYQunuBtianxwaMEUAxkkB other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool HecFseNlcxgxHtfjsyYNyJKoBZrS(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(mebkLrrYQunuBtianxwaMEUAxkkB))
		{
			return false;
		}
		return Equals((mebkLrrYQunuBtianxwaMEUAxkkB)P_0);
	}

	public int WLhOqRkmuOlUUTLYJXwjOYLAqKtf()
	{
		return (HJLyeMUpXMiFHLJUKEBRmhvYeNsL.GetHashCode() * 397) ^ hMGiKdDUSjqkWuzWeurGPFDxwvBk.GetHashCode();
	}

	[SpecialName]
	public static bool hKkFlHthhxzShYFdWRavboTVLFNs(mebkLrrYQunuBtianxwaMEUAxkkB P_0, mebkLrrYQunuBtianxwaMEUAxkkB P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool nqWOGUnfEmDMOwYemCSnqGvpfkJL(mebkLrrYQunuBtianxwaMEUAxkkB P_0, mebkLrrYQunuBtianxwaMEUAxkkB P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string DgKdBxDjgjtjFxnoQWipHZhWqHgqA()
	{
		return $"({HJLyeMUpXMiFHLJUKEBRmhvYeNsL},{hMGiKdDUSjqkWuzWeurGPFDxwvBk})";
	}
}

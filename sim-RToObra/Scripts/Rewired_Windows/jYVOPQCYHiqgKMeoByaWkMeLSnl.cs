using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX;

internal struct jYVOPQCYHiqgKMeoByaWkMeLSnl : IEquatable<jYVOPQCYHiqgKMeoByaWkMeLSnl>
{
	private int nEslPeCqYKwOxTPurTsfYhhCzhq;

	public static readonly jYVOPQCYHiqgKMeoByaWkMeLSnl YvXJmEatEqGvAjZvpFZGKdhOIJfG = new jYVOPQCYHiqgKMeoByaWkMeLSnl(0);

	public static readonly jYVOPQCYHiqgKMeoByaWkMeLSnl MUwrWuTBWJwJJxksyLaWtiHPtLL = new jYVOPQCYHiqgKMeoByaWkMeLSnl(1);

	public static readonly ResultDescriptor bjrddvJQNqpuWTiUiLMmkausaPn = new ResultDescriptor(-2147467260, "General", "E_ABORT", "Operation aborted");

	public static readonly ResultDescriptor mSOeNIIIvbWlpvawKhTrovfxyvS = new ResultDescriptor(-2147024891, "General", "E_ACCESSDENIED", "General access denied error");

	public static readonly ResultDescriptor ectEHhOaZjPumSaECnijEeuBhis = new ResultDescriptor(-2147467259, "General", "E_FAIL", "Unspecified error");

	public static readonly ResultDescriptor AjhCMjVsVcEblCfQrhtHerUiIlxO = new ResultDescriptor(-2147024890, "General", "E_HANDLE", "Invalid handle");

	public static readonly ResultDescriptor wLfnyNulmMugpEmCIzvNtqeLAdV = new ResultDescriptor(-2147024809, "General", "E_INVALIDARG", "Invalid Arguments");

	public static readonly ResultDescriptor ymSCQKXrphiDRDDeSCEbyPwyJtcG = new ResultDescriptor(-2147467262, "General", "E_NOINTERFACE", "No such interface supported");

	public static readonly ResultDescriptor pRAblnvhaPpMHCxFTLjIknDBzCQ = new ResultDescriptor(-2147467263, "General", "E_NOTIMPL", "Not implemented");

	public static readonly ResultDescriptor jFtbcbhAGsGoCXYTAxsTdurmtKqj = new ResultDescriptor(-2147024882, "General", "E_OUTOFMEMORY", "Out of memory");

	public static readonly ResultDescriptor tnCXccAEpBsWncTpQRRHEOcNBrQf = new ResultDescriptor(-2147467261, "General", "E_POINTER", "Invalid pointer");

	public static readonly ResultDescriptor qIVyNzYNrRqJYBRVWCuiieulSwa = new ResultDescriptor(-2147418113, "General", "E_UNEXPECTED", "Catastrophic failure");

	public static readonly ResultDescriptor YKVXEhqJfPSDpGnTDtlQSInyBlT = new ResultDescriptor(128, "General", "WAIT_ABANDONED", "WaitAbandoned");

	public static readonly ResultDescriptor TTldlSPHyixTKLlaeBLfpSYRXxc = new ResultDescriptor(258, "General", "WAIT_TIMEOUT", "WaitTimeout");

	public int Code
	{
		get
		{
			return nEslPeCqYKwOxTPurTsfYhhCzhq;
		}
	}

	public bool Success
	{
		get
		{
			return Code >= 0;
		}
	}

	public bool Failure
	{
		get
		{
			return Code < 0;
		}
	}

	public jYVOPQCYHiqgKMeoByaWkMeLSnl(int code)
	{
		nEslPeCqYKwOxTPurTsfYhhCzhq = code;
	}

	public jYVOPQCYHiqgKMeoByaWkMeLSnl(uint code)
	{
		nEslPeCqYKwOxTPurTsfYhhCzhq = (int)code;
	}

	public static explicit operator int(jYVOPQCYHiqgKMeoByaWkMeLSnl result)
	{
		return result.Code;
	}

	public static explicit operator uint(jYVOPQCYHiqgKMeoByaWkMeLSnl result)
	{
		return (uint)result.Code;
	}

	public static implicit operator jYVOPQCYHiqgKMeoByaWkMeLSnl(int result)
	{
		return new jYVOPQCYHiqgKMeoByaWkMeLSnl(result);
	}

	public static implicit operator jYVOPQCYHiqgKMeoByaWkMeLSnl(uint result)
	{
		return new jYVOPQCYHiqgKMeoByaWkMeLSnl(result);
	}

	public bool Equals(jYVOPQCYHiqgKMeoByaWkMeLSnl other)
	{
		return Code == other.Code;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is jYVOPQCYHiqgKMeoByaWkMeLSnl))
		{
			return false;
		}
		return Equals((jYVOPQCYHiqgKMeoByaWkMeLSnl)obj);
	}

	public override int GetHashCode()
	{
		return Code;
	}

	public static bool operator ==(jYVOPQCYHiqgKMeoByaWkMeLSnl left, jYVOPQCYHiqgKMeoByaWkMeLSnl right)
	{
		return left.Code == right.Code;
	}

	public static bool operator !=(jYVOPQCYHiqgKMeoByaWkMeLSnl left, jYVOPQCYHiqgKMeoByaWkMeLSnl right)
	{
		return left.Code != right.Code;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "HRESULT = 0x{0:X}", nEslPeCqYKwOxTPurTsfYhhCzhq);
	}

	public void ekcBiXGMbYMGcLEdCGmXypFMzRo()
	{
		if (nEslPeCqYKwOxTPurTsfYhhCzhq < 0)
		{
			throw new PQfDifZXOUFRqvqrEtvLLzUnIdC(this);
		}
	}

	public static jYVOPQCYHiqgKMeoByaWkMeLSnl jrPzTMNdlahxUQAhDtGilmPxYYE(Exception P_0)
	{
		return new jYVOPQCYHiqgKMeoByaWkMeLSnl(Marshal.GetHRForException(P_0));
	}

	public static jYVOPQCYHiqgKMeoByaWkMeLSnl CKMEeDKWkHYSudBLKohftqjmzWe(int P_0)
	{
		return (int)((P_0 <= 0) ? P_0 : ((P_0 & 0xFFFF) | 0x70000 | 0x80000000u));
	}
}

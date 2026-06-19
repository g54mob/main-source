using System;
using System.Globalization;
using System.Runtime.InteropServices;

internal struct llpFqWliQEfHkPmCCWtyJDAPdFG : IEquatable<llpFqWliQEfHkPmCCWtyJDAPdFG>
{
	private int liEAVohjSeZTNcOUaajZNpPAbiZE;

	public static readonly llpFqWliQEfHkPmCCWtyJDAPdFG SDdUlCTcEYKXsgFRafZmbpFIEvW = new llpFqWliQEfHkPmCCWtyJDAPdFG(0);

	public static readonly llpFqWliQEfHkPmCCWtyJDAPdFG UPQyshqOdrsvRiQtfWcQUxVtCkF = new llpFqWliQEfHkPmCCWtyJDAPdFG(1);

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE tDZcVfgVJSEScIAorBbEGFGAoWUH = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147467260, "General", "E_ABORT", "Operation aborted");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE iGiKGUvgdFLhDaDKHqxJNpLxUvn = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147024891, "General", "E_ACCESSDENIED", "General access denied error");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE kHFmoPnpsJxcKVqEXHVFvqCJicD = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147467259, "General", "E_FAIL", "Unspecified error");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE GSZkdryWLYMEZkOmiTMrMdkEwnC = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147024890, "General", "E_HANDLE", "Invalid handle");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE kBNGNLdBmuKHFxVmJuFpgGSZqLcj = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147024809, "General", "E_INVALIDARG", "Invalid Arguments");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE eukeFKsUhVcorQiYRqHNssAkuYX = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147467262, "General", "E_NOINTERFACE", "No such interface supported");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE xQuyTjYHcvulfPRjEbPwTIpVKFn = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147467263, "General", "E_NOTIMPL", "Not implemented");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE tcJOjpjrESJFmJHvRbCvBxTiMLV = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147024882, "General", "E_OUTOFMEMORY", "Out of memory");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE xviaGotIdfEzLdrFRPrhydWTPste = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147467261, "General", "E_POINTER", "Invalid pointer");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE iTzdrbryfzDkmYvvVNaWTuUrSNV = new idVfiiFRzAukcbNWHToMNNCddpvE(-2147418113, "General", "E_UNEXPECTED", "Catastrophic failure");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE INtevxRgbfGfPKJpEyDsQfPuNSw = new idVfiiFRzAukcbNWHToMNNCddpvE(128, "General", "WAIT_ABANDONED", "WaitAbandoned");

	public static readonly idVfiiFRzAukcbNWHToMNNCddpvE ZfFkFMcyaKFYiUgUzlxDSicVVGR = new idVfiiFRzAukcbNWHToMNNCddpvE(258, "General", "WAIT_TIMEOUT", "WaitTimeout");

	public int Code => liEAVohjSeZTNcOUaajZNpPAbiZE;

	public bool Success => Code >= 0;

	public bool Failure => Code < 0;

	public llpFqWliQEfHkPmCCWtyJDAPdFG(int code)
	{
		liEAVohjSeZTNcOUaajZNpPAbiZE = code;
	}

	public llpFqWliQEfHkPmCCWtyJDAPdFG(uint code)
	{
		liEAVohjSeZTNcOUaajZNpPAbiZE = (int)code;
	}

	public static explicit operator int(llpFqWliQEfHkPmCCWtyJDAPdFG result)
	{
		return result.Code;
	}

	public static explicit operator uint(llpFqWliQEfHkPmCCWtyJDAPdFG result)
	{
		return (uint)result.Code;
	}

	public static implicit operator llpFqWliQEfHkPmCCWtyJDAPdFG(int result)
	{
		return new llpFqWliQEfHkPmCCWtyJDAPdFG(result);
	}

	public static implicit operator llpFqWliQEfHkPmCCWtyJDAPdFG(uint result)
	{
		return new llpFqWliQEfHkPmCCWtyJDAPdFG(result);
	}

	public bool Equals(llpFqWliQEfHkPmCCWtyJDAPdFG other)
	{
		return Code == other.Code;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is llpFqWliQEfHkPmCCWtyJDAPdFG))
		{
			return false;
		}
		return Equals((llpFqWliQEfHkPmCCWtyJDAPdFG)obj);
	}

	public override int GetHashCode()
	{
		return Code;
	}

	public static bool operator ==(llpFqWliQEfHkPmCCWtyJDAPdFG left, llpFqWliQEfHkPmCCWtyJDAPdFG right)
	{
		return left.Code == right.Code;
	}

	public static bool operator !=(llpFqWliQEfHkPmCCWtyJDAPdFG left, llpFqWliQEfHkPmCCWtyJDAPdFG right)
	{
		return left.Code != right.Code;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "HRESULT = 0x{0:X}", new object[1] { liEAVohjSeZTNcOUaajZNpPAbiZE });
	}

	public void oCKdtZanlshnKAQVdRIdxFviUCRp()
	{
		if (liEAVohjSeZTNcOUaajZNpPAbiZE < 0)
		{
			throw new LMHEDbkJUaggUeITLPipkWgboJt(this);
		}
	}

	public static llpFqWliQEfHkPmCCWtyJDAPdFG zkvdFGkonWzMinJZStLITAxzZBbN(Exception P_0)
	{
		return new llpFqWliQEfHkPmCCWtyJDAPdFG(Marshal.GetHRForException(P_0));
	}

	public static llpFqWliQEfHkPmCCWtyJDAPdFG QcuCkPDvedTbIRwzVUSTdGFumwD(int P_0)
	{
		return (int)((P_0 <= 0) ? P_0 : ((P_0 & 0xFFFF) | 0x70000 | 0x80000000u));
	}
}

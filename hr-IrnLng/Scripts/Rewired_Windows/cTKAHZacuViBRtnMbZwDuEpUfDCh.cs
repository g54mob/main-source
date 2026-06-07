using System;
using System.Globalization;
using System.Runtime.InteropServices;

internal struct cTKAHZacuViBRtnMbZwDuEpUfDCh : IEquatable<cTKAHZacuViBRtnMbZwDuEpUfDCh>
{
	private int qtnbxiwgfWZiriWTHHcFKuTtiBf;

	public static readonly cTKAHZacuViBRtnMbZwDuEpUfDCh TxKWeNYuiFlAPAnHJjVLUemLHGGi = new cTKAHZacuViBRtnMbZwDuEpUfDCh(0);

	public static readonly cTKAHZacuViBRtnMbZwDuEpUfDCh PFzGEbEdwmNeOxCCYNcTctOAOEaT = new cTKAHZacuViBRtnMbZwDuEpUfDCh(1);

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE qHobaJlreDGBTqcFWVXtwxndIoG = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147467260, "General", "E_ABORT", "Operation aborted");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE lWHmtTiBJSblwQJCwuDiiqwckvl = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147024891, "General", "E_ACCESSDENIED", "General access denied error");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE zPuMcYksSQmCrdOOqfHyQttEuaN = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147467259, "General", "E_FAIL", "Unspecified error");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE FKsLUabodNMQaQbwVmjKhSJZWuM = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147024890, "General", "E_HANDLE", "Invalid handle");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE vGclIUEEHfBBytmeqleEzfBSJPw = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147024809, "General", "E_INVALIDARG", "Invalid Arguments");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE hnJlYDxoHONgQikKwHYqDqnldwP = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147467262, "General", "E_NOINTERFACE", "No such interface supported");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE iXXzOiDEOutlCxBxxCvZkUUIjFt = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147467263, "General", "E_NOTIMPL", "Not implemented");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE wNqPmcaTiPeJTnUdidkEyxqbgLX = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147024882, "General", "E_OUTOFMEMORY", "Out of memory");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE yfDJopcjLaMfgHvJqVDIWFnCasve = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147467261, "General", "E_POINTER", "Invalid pointer");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE flSIXqqKPmgWPkGjwdIxiWpsRwF = new bOkYhrAZvLuDrbKeuEpFihavppE(-2147418113, "General", "E_UNEXPECTED", "Catastrophic failure");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE RcWJKqAANuJrqfhntCtNQJoxQUe = new bOkYhrAZvLuDrbKeuEpFihavppE(128, "General", "WAIT_ABANDONED", "WaitAbandoned");

	public static readonly bOkYhrAZvLuDrbKeuEpFihavppE WvoxVDhASVaGPuuCQnDwtmFOMGL = new bOkYhrAZvLuDrbKeuEpFihavppE(258, "General", "WAIT_TIMEOUT", "WaitTimeout");

	public int Code => qtnbxiwgfWZiriWTHHcFKuTtiBf;

	public bool Success => Code >= 0;

	public bool Failure => Code < 0;

	public cTKAHZacuViBRtnMbZwDuEpUfDCh(int code)
	{
		qtnbxiwgfWZiriWTHHcFKuTtiBf = code;
	}

	public cTKAHZacuViBRtnMbZwDuEpUfDCh(uint code)
	{
		qtnbxiwgfWZiriWTHHcFKuTtiBf = (int)code;
	}

	public static explicit operator int(cTKAHZacuViBRtnMbZwDuEpUfDCh result)
	{
		return result.Code;
	}

	public static explicit operator uint(cTKAHZacuViBRtnMbZwDuEpUfDCh result)
	{
		return (uint)result.Code;
	}

	public static implicit operator cTKAHZacuViBRtnMbZwDuEpUfDCh(int result)
	{
		return new cTKAHZacuViBRtnMbZwDuEpUfDCh(result);
	}

	public static implicit operator cTKAHZacuViBRtnMbZwDuEpUfDCh(uint result)
	{
		return new cTKAHZacuViBRtnMbZwDuEpUfDCh(result);
	}

	public bool Equals(cTKAHZacuViBRtnMbZwDuEpUfDCh other)
	{
		return Code == other.Code;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is cTKAHZacuViBRtnMbZwDuEpUfDCh))
		{
			return false;
		}
		return Equals((cTKAHZacuViBRtnMbZwDuEpUfDCh)obj);
	}

	public override int GetHashCode()
	{
		return Code;
	}

	public static bool operator ==(cTKAHZacuViBRtnMbZwDuEpUfDCh left, cTKAHZacuViBRtnMbZwDuEpUfDCh right)
	{
		return left.Code == right.Code;
	}

	public static bool operator !=(cTKAHZacuViBRtnMbZwDuEpUfDCh left, cTKAHZacuViBRtnMbZwDuEpUfDCh right)
	{
		return left.Code != right.Code;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "HRESULT = 0x{0:X}", new object[1] { qtnbxiwgfWZiriWTHHcFKuTtiBf });
	}

	public void zHpTMwuToxnnciRWweSPaClPGJQ()
	{
		if (qtnbxiwgfWZiriWTHHcFKuTtiBf < 0)
		{
			throw new CgeVuknLwxYkzYPFwGhCkZZiVyf(this);
		}
	}

	public static cTKAHZacuViBRtnMbZwDuEpUfDCh yGCjLezDbTWZdvBjlfravEjoTji(Exception P_0)
	{
		return new cTKAHZacuViBRtnMbZwDuEpUfDCh(Marshal.GetHRForException(P_0));
	}

	public static cTKAHZacuViBRtnMbZwDuEpUfDCh PgZAWScCMstxmUffqucivyAticP(int P_0)
	{
		return (int)((P_0 <= 0) ? P_0 : ((P_0 & 0xFFFF) | 0x70000 | 0x80000000u));
	}
}

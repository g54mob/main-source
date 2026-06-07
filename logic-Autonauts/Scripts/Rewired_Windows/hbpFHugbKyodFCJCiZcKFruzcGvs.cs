using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired.Libraries.SharpDX;

internal struct hbpFHugbKyodFCJCiZcKFruzcGvs : IEquatable<hbpFHugbKyodFCJCiZcKFruzcGvs>
{
	private int dtYHqQrbYMNxeWQQOHQzTAvcbbw;

	public static readonly hbpFHugbKyodFCJCiZcKFruzcGvs ArffBsNPEaehLmOZGRICZLxoNOj = new hbpFHugbKyodFCJCiZcKFruzcGvs(0);

	public static readonly hbpFHugbKyodFCJCiZcKFruzcGvs KfUZMUiXIFGiSaZYZsQQuFRrFYH = new hbpFHugbKyodFCJCiZcKFruzcGvs(1);

	public static readonly ResultDescriptor lOJkcRgVLeugHKemZHTmJbqSiFzZ = new ResultDescriptor(-2147467260, "General", "E_ABORT", "Operation aborted");

	public static readonly ResultDescriptor yVqAlyIbxfVHomwUxgThirpJMeIk = new ResultDescriptor(-2147024891, "General", "E_ACCESSDENIED", "General access denied error");

	public static readonly ResultDescriptor mwBxXjlFurjQdRZMzjjlJPyjMtq = new ResultDescriptor(-2147467259, "General", "E_FAIL", "Unspecified error");

	public static readonly ResultDescriptor AfHDKBuJLwqXggieIpFFolQobhh = new ResultDescriptor(-2147024890, "General", "E_HANDLE", "Invalid handle");

	public static readonly ResultDescriptor oLPeqfFEsABlygHovprFVaidiIVH = new ResultDescriptor(-2147024809, "General", "E_INVALIDARG", "Invalid Arguments");

	public static readonly ResultDescriptor wGiXMyihhrKsYMCNzADnUfyUdLm = new ResultDescriptor(-2147467262, "General", "E_NOINTERFACE", "No such interface supported");

	public static readonly ResultDescriptor dCgPuRSdaPFHMcFzgIbKejJnmUIp = new ResultDescriptor(-2147467263, "General", "E_NOTIMPL", "Not implemented");

	public static readonly ResultDescriptor nOHftJviEurNVNybdeFVvMdSKey = new ResultDescriptor(-2147024882, "General", "E_OUTOFMEMORY", "Out of memory");

	public static readonly ResultDescriptor haefKnmfNQDcvxTjDVZTvazCpQ = new ResultDescriptor(-2147467261, "General", "E_POINTER", "Invalid pointer");

	public static readonly ResultDescriptor eDzMNezdORWXRYxlvCoSteLVAkY = new ResultDescriptor(-2147418113, "General", "E_UNEXPECTED", "Catastrophic failure");

	public static readonly ResultDescriptor EDbGWHBBtXaDefHvIcdEhPxGQBeH = new ResultDescriptor(128, "General", "WAIT_ABANDONED", "WaitAbandoned");

	public static readonly ResultDescriptor HUNaykguqmlwZlMQZnTbhyQnxBon = new ResultDescriptor(258, "General", "WAIT_TIMEOUT", "WaitTimeout");

	public int Code
	{
		get
		{
			return dtYHqQrbYMNxeWQQOHQzTAvcbbw;
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

	public hbpFHugbKyodFCJCiZcKFruzcGvs(int code)
	{
		dtYHqQrbYMNxeWQQOHQzTAvcbbw = code;
	}

	public hbpFHugbKyodFCJCiZcKFruzcGvs(uint code)
	{
		dtYHqQrbYMNxeWQQOHQzTAvcbbw = (int)code;
	}

	public static explicit operator int(hbpFHugbKyodFCJCiZcKFruzcGvs result)
	{
		return result.Code;
	}

	public static explicit operator uint(hbpFHugbKyodFCJCiZcKFruzcGvs result)
	{
		return (uint)result.Code;
	}

	public static implicit operator hbpFHugbKyodFCJCiZcKFruzcGvs(int result)
	{
		return new hbpFHugbKyodFCJCiZcKFruzcGvs(result);
	}

	public static implicit operator hbpFHugbKyodFCJCiZcKFruzcGvs(uint result)
	{
		return new hbpFHugbKyodFCJCiZcKFruzcGvs(result);
	}

	public bool Equals(hbpFHugbKyodFCJCiZcKFruzcGvs other)
	{
		return Code == other.Code;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is hbpFHugbKyodFCJCiZcKFruzcGvs))
		{
			return false;
		}
		return Equals((hbpFHugbKyodFCJCiZcKFruzcGvs)obj);
	}

	public override int GetHashCode()
	{
		return Code;
	}

	public static bool operator ==(hbpFHugbKyodFCJCiZcKFruzcGvs left, hbpFHugbKyodFCJCiZcKFruzcGvs right)
	{
		return left.Code == right.Code;
	}

	public static bool operator !=(hbpFHugbKyodFCJCiZcKFruzcGvs left, hbpFHugbKyodFCJCiZcKFruzcGvs right)
	{
		return left.Code != right.Code;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "HRESULT = 0x{0:X}", new object[1] { dtYHqQrbYMNxeWQQOHQzTAvcbbw });
	}

	public void moUKMvtdvMYFxCOFvigNjjXmpVy()
	{
		if (dtYHqQrbYMNxeWQQOHQzTAvcbbw < 0)
		{
			throw new ZaTrePujSOBIfuqTlTtZUAAZPrQ(this);
		}
	}

	public static hbpFHugbKyodFCJCiZcKFruzcGvs rvhIeccpxwreHTkBqNncgpJNySM(Exception P_0)
	{
		return new hbpFHugbKyodFCJCiZcKFruzcGvs(Marshal.GetHRForException(P_0));
	}

	public static hbpFHugbKyodFCJCiZcKFruzcGvs ONeKHvnLoZiRbwOhjBwvaQrKhnk(int P_0)
	{
		return (int)((P_0 <= 0) ? P_0 : ((P_0 & 0xFFFF) | 0x70000 | 0x80000000u));
	}
}

using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct hffboTtMgbbEhgBbkOhyJBfJupGf : IEquatable<hffboTtMgbbEhgBbkOhyJBfJupGf>
{
	private int GDuwXAWrHXaQpuDbdQUCjoGAbwOi;

	public hffboTtMgbbEhgBbkOhyJBfJupGf(bool boolValue)
	{
		GDuwXAWrHXaQpuDbdQUCjoGAbwOi = (boolValue ? 1 : 0);
	}

	public bool Equals(hffboTtMgbbEhgBbkOhyJBfJupGf other)
	{
		return GDuwXAWrHXaQpuDbdQUCjoGAbwOi == other.GDuwXAWrHXaQpuDbdQUCjoGAbwOi;
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if (obj is hffboTtMgbbEhgBbkOhyJBfJupGf)
		{
			return Equals((hffboTtMgbbEhgBbkOhyJBfJupGf)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return GDuwXAWrHXaQpuDbdQUCjoGAbwOi;
	}

	public static bool operator ==(hffboTtMgbbEhgBbkOhyJBfJupGf left, hffboTtMgbbEhgBbkOhyJBfJupGf right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(hffboTtMgbbEhgBbkOhyJBfJupGf left, hffboTtMgbbEhgBbkOhyJBfJupGf right)
	{
		return !left.Equals(right);
	}

	public static implicit operator bool(hffboTtMgbbEhgBbkOhyJBfJupGf booleanValue)
	{
		return booleanValue.GDuwXAWrHXaQpuDbdQUCjoGAbwOi != 0;
	}

	public static implicit operator hffboTtMgbbEhgBbkOhyJBfJupGf(bool boolValue)
	{
		return new hffboTtMgbbEhgBbkOhyJBfJupGf(boolValue);
	}

	public override string ToString()
	{
		return string.Format("{0}", GDuwXAWrHXaQpuDbdQUCjoGAbwOi != 0);
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct IyNzWgENqThPgJqwJUbyZoBSDLqz : IEquatable<IyNzWgENqThPgJqwJUbyZoBSDLqz>
{
	private int eLQFIuOQewkCNrPxzXYVYtQgMNhv;

	public IyNzWgENqThPgJqwJUbyZoBSDLqz(bool P_0)
	{
		eLQFIuOQewkCNrPxzXYVYtQgMNhv = (P_0 ? 1 : 0);
	}

	public bool Equals(IyNzWgENqThPgJqwJUbyZoBSDLqz other)
	{
		return eLQFIuOQewkCNrPxzXYVYtQgMNhv == other.eLQFIuOQewkCNrPxzXYVYtQgMNhv;
	}

	bool IEquatable<IyNzWgENqThPgJqwJUbyZoBSDLqz>.Equals(IyNzWgENqThPgJqwJUbyZoBSDLqz other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool sXCvFoqOatMpyVEcqIvmYFyZZpEp(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is IyNzWgENqThPgJqwJUbyZoBSDLqz)
		{
			return Equals((IyNzWgENqThPgJqwJUbyZoBSDLqz)P_0);
		}
		return false;
	}

	public int XuvgVQbSARtllkdoRcnTaNvituFkB()
	{
		return eLQFIuOQewkCNrPxzXYVYtQgMNhv;
	}

	[SpecialName]
	public static bool aTFEEBFxqBHOYMwzVhONslLEkUsg(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0, IyNzWgENqThPgJqwJUbyZoBSDLqz P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool CRvMVcECkvjslxlrHwDJGWVYlyZN(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0, IyNzWgENqThPgJqwJUbyZoBSDLqz P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool jJSETxscYMZtZlfXLHmsaXFsRvOk(IyNzWgENqThPgJqwJUbyZoBSDLqz P_0)
	{
		return P_0.eLQFIuOQewkCNrPxzXYVYtQgMNhv != 0;
	}

	[SpecialName]
	public static IyNzWgENqThPgJqwJUbyZoBSDLqz cJopUoIQbnWjFkuxHmEliogcRMOs(bool P_0)
	{
		return new IyNzWgENqThPgJqwJUbyZoBSDLqz(P_0);
	}

	public string jPAyRwDhYwTBtsYslETEWUoXJEFc()
	{
		return $"{eLQFIuOQewkCNrPxzXYVYtQgMNhv != 0}";
	}
}

using System;
using System.Runtime.CompilerServices;

internal class SJqfYgHdWEqERVLNrJIhUARlTAxF : IEquatable<SJqfYgHdWEqERVLNrJIhUARlTAxF>
{
	private IntPtr QIcmgVoinWYuiDYrKUnlAyfyVyX;

	public IntPtr luwkDSgKmtkkJGTIhfGeRJflBENf => QIcmgVoinWYuiDYrKUnlAyfyVyX;

	public bool nLhMBBNUJOGIUePAsQRBDPmHBCQk => QIcmgVoinWYuiDYrKUnlAyfyVyX != IntPtr.Zero;

	public SJqfYgHdWEqERVLNrJIhUARlTAxF(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		QIcmgVoinWYuiDYrKUnlAyfyVyX = P_0;
	}

	public virtual bool jZDzSXZxdCWdMwHZUyoPQCpJqwtO(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is SJqfYgHdWEqERVLNrJIhUARlTAxF))
		{
			return false;
		}
		return ((SJqfYgHdWEqERVLNrJIhUARlTAxF)P_0).QIcmgVoinWYuiDYrKUnlAyfyVyX == QIcmgVoinWYuiDYrKUnlAyfyVyX;
	}

	public virtual int OKmHwlPUpGWOCHAigwiZemxGbtTc()
	{
		return base.GetHashCode();
	}

	public bool Equals(SJqfYgHdWEqERVLNrJIhUARlTAxF other)
	{
		if (other == null)
		{
			return false;
		}
		return QIcmgVoinWYuiDYrKUnlAyfyVyX == other.QIcmgVoinWYuiDYrKUnlAyfyVyX;
	}

	bool IEquatable<SJqfYgHdWEqERVLNrJIhUARlTAxF>.Equals(SJqfYgHdWEqERVLNrJIhUARlTAxF other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool kdGZeSoUvyDzCFLjBWEQVACsHaIg(SJqfYgHdWEqERVLNrJIhUARlTAxF P_0, SJqfYgHdWEqERVLNrJIhUARlTAxF P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool PPqCjTGGCObxuiKlqeheYazGPcKp(SJqfYgHdWEqERVLNrJIhUARlTAxF P_0, SJqfYgHdWEqERVLNrJIhUARlTAxF P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return false;
		}
		if (P_0 == null || P_1 == null)
		{
			return true;
		}
		return !P_0.Equals(P_1);
	}
}

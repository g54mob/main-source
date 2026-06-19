using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class YFMyTlGpqWfdvBPQCYKgauQgeieHA<_0001> : IDisposable where _0001 : struct
{
	private static readonly int TYpiRCHqbWfUFPoXMBeYDDnOOBwn = Marshal.SizeOf(typeof(_0001));

	private fFicYORCqoZwZowJIRdCWZeAXNjG nohemrZtyvXplsalfjnYdTGhThej;

	private bool UpplxCHRhkbUszYRPmwcYulbfKSo;

	public fFicYORCqoZwZowJIRdCWZeAXNjG CfpozvRHgvwEKCcHNhGHLGvhabUC => nohemrZtyvXplsalfjnYdTGhThej;

	public bool csXVeToTqpGtPkWPMZnrrcpvigcJ
	{
		get
		{
			if (nohemrZtyvXplsalfjnYdTGhThej != null)
			{
				return nohemrZtyvXplsalfjnYdTGhThej.htleiMGbKkdgXiYbwwHlpQSekWiiA != IntPtr.Zero;
			}
			return false;
		}
	}

	public unsafe _0001 gnHnXpTsWWkENqJXmGbbCVbmgYnq
	{
		get
		{
			RkYRRxxcruJFckWrrSYyIiLgvghl();
			return Unsafe.Read<_0001>((void*)nohemrZtyvXplsalfjnYdTGhThej.htleiMGbKkdgXiYbwwHlpQSekWiiA);
		}
		set
		{
			RkYRRxxcruJFckWrrSYyIiLgvghl();
			_0001* ptr = &val;
			nohemrZtyvXplsalfjnYdTGhThej.WyWjmYldVzOPnclSpipOCyNnETvv((IntPtr)ptr, TYpiRCHqbWfUFPoXMBeYDDnOOBwn, TYpiRCHqbWfUFPoXMBeYDDnOOBwn);
		}
	}

	public YFMyTlGpqWfdvBPQCYKgauQgeieHA()
	{
		nohemrZtyvXplsalfjnYdTGhThej = new fFicYORCqoZwZowJIRdCWZeAXNjG(TYpiRCHqbWfUFPoXMBeYDDnOOBwn);
	}

	private void VZPnjcLQZcjWOhUNDAfvxDEdaULbA()
	{
		if (nohemrZtyvXplsalfjnYdTGhThej == null)
		{
			nohemrZtyvXplsalfjnYdTGhThej.Dispose();
			nohemrZtyvXplsalfjnYdTGhThej = null;
		}
	}

	private void RkYRRxxcruJFckWrrSYyIiLgvghl()
	{
		if (!csXVeToTqpGtPkWPMZnrrcpvigcJ)
		{
			throw new Exception("Memory not allocated.");
		}
	}

	private void xKmrOomwrWxQZZCfXHIvchxMZIPG(bool P_0)
	{
		if (!UpplxCHRhkbUszYRPmwcYulbfKSo)
		{
			if (P_0)
			{
				VZPnjcLQZcjWOhUNDAfvxDEdaULbA();
			}
			UpplxCHRhkbUszYRPmwcYulbfKSo = true;
		}
	}

	public void Dispose()
	{
		xKmrOomwrWxQZZCfXHIvchxMZIPG(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}

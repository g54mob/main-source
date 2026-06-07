using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class DeyfmwNUpNcdcgevEUIZIIFKEdvu : kMwtSZJjzkIhHlufXnXiyaOycSDO
{
	[CompilerGenerated]
	private bkoJnPgJsdhsouQyfcFPIuslpRXdb GdyPTXjyNumMGHKJfEpZNPXotIXK;

	public bkoJnPgJsdhsouQyfcFPIuslpRXdb PsZqHFxtixmJrqmLCpvcipOhjwdd
	{
		[CompilerGenerated]
		get
		{
			return GdyPTXjyNumMGHKJfEpZNPXotIXK;
		}
		[CompilerGenerated]
		private set
		{
			GdyPTXjyNumMGHKJfEpZNPXotIXK = gdyPTXjyNumMGHKJfEpZNPXotIXK;
		}
	}

	protected abstract sfDZCwoiybFOIJFSGzKIJjZOWRQkA EOGASVyTxtCupFKBpHnLEYXWCann { get; }

	public unsafe virtual void xkbqdGnPZaLmXtYYpoxCohwDgwtr(bkoJnPgJsdhsouQyfcFPIuslpRXdb P_0)
	{
		PsZqHFxtixmJrqmLCpvcipOhjwdd = P_0;
		base.odpdeHVpSKtJOjaxhiXZmqovsVjq = Marshal.AllocHGlobal(IntPtr.Size * 2);
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(base.odpdeHVpSKtJOjaxhiXZmqovsVjq, EOGASVyTxtCupFKBpHnLEYXWCann.xBcoZGNgjFHBlnBwrrDhjDjpecwDA);
		((IntPtr*)(void*)base.odpdeHVpSKtJOjaxhiXZmqovsVjq)[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void IKTosnAThJejUhpEVDvbNXvLRrEt(bool P_0)
	{
		if (base.odpdeHVpSKtJOjaxhiXZmqovsVjq != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)base.odpdeHVpSKtJOjaxhiXZmqovsVjq)[1]).Free();
			Marshal.FreeHGlobal(base.odpdeHVpSKtJOjaxhiXZmqovsVjq);
			base.odpdeHVpSKtJOjaxhiXZmqovsVjq = IntPtr.Zero;
		}
		PsZqHFxtixmJrqmLCpvcipOhjwdd = null;
		iMwajwOGQSEQfomVDYbytdzJQpuM(P_0);
	}

	internal unsafe static _0001 qwHdVPIkBZIfEIoQsxifMLHPvYIUA<_0001>(IntPtr P_0) where _0001 : DeyfmwNUpNcdcgevEUIZIIFKEdvu
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}

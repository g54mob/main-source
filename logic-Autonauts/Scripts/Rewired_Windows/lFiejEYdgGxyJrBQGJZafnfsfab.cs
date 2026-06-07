using System;
using System.Runtime.InteropServices;

internal class lFiejEYdgGxyJrBQGJZafnfsfab : IDisposable
{
	private int oLgBwdcknvycEPFgvSfVvkpdwcBq;

	private uint jCrESXpCSpMEOgJbFAsGAKUQCWML;

	private IntPtr MYqfxxMkzXpHLHoxPjvHgHItxus;

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	public lFiejEYdgGxyJrBQGJZafnfsfab(uint size)
	{
		if (size == 0)
		{
			throw new Exception("size must be > 0!");
		}
		jCrESXpCSpMEOgJbFAsGAKUQCWML = size;
		oLgBwdcknvycEPFgvSfVvkpdwcBq = 0;
		try
		{
			MYqfxxMkzXpHLHoxPjvHgHItxus = Marshal.AllocHGlobal((int)size);
			if (MYqfxxMkzXpHLHoxPjvHgHItxus == IntPtr.Zero)
			{
				throw new Exception("Could not allocate native memory.");
			}
		}
		catch
		{
			throw;
		}
	}

	public unsafe IntPtr xVijxMtzmKdJKIZiwPverJmHDTc(uint P_0, void* P_1)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return IntPtr.Zero;
		}
		if (P_0 == 0)
		{
			return IntPtr.Zero;
		}
		if (P_0 > jCrESXpCSpMEOgJbFAsGAKUQCWML)
		{
			return IntPtr.Zero;
		}
		if (oLgBwdcknvycEPFgvSfVvkpdwcBq + P_0 >= jCrESXpCSpMEOgJbFAsGAKUQCWML)
		{
			oLgBwdcknvycEPFgvSfVvkpdwcBq = 0;
		}
		IntPtr intPtr = new IntPtr(MYqfxxMkzXpHLHoxPjvHgHItxus.ToInt64() + oLgBwdcknvycEPFgvSfVvkpdwcBq);
		QiyhMeApbloIAQYCjGAvUEQIhAz.jZaoqafpmcVnUamkQHboGxYtgDI(intPtr, (IntPtr)P_1, (int)P_0);
		oLgBwdcknvycEPFgvSfVvkpdwcBq += (int)P_0;
		return intPtr;
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~lFiejEYdgGxyJrBQGJZafnfsfab()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
			if (MYqfxxMkzXpHLHoxPjvHgHItxus != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(MYqfxxMkzXpHLHoxPjvHgHItxus);
			}
		}
	}
}

using System;
using System.Runtime.InteropServices;

internal class efmrLSrolSjovsfxfjCVLLJRnGz
{
	private int KHUMyXsEITLkNGKfkxwaDTOLUYX;

	private byte[] DBZCtHAzIvFuQOarCKsttoMaNgUG;

	public virtual int Size => KHUMyXsEITLkNGKfkxwaDTOLUYX;

	protected efmrLSrolSjovsfxfjCVLLJRnGz()
	{
	}

	internal efmrLSrolSjovsfxfjCVLLJRnGz(int bufferSize, IntPtr bufferPointer)
	{
		wCHMeVtmpfgnaDbZjXJYwQMfteN(bufferSize, bufferPointer);
	}

	private unsafe void wCHMeVtmpfgnaDbZjXJYwQMfteN(int P_0, IntPtr P_1)
	{
		KHUMyXsEITLkNGKfkxwaDTOLUYX = P_0;
		if (KHUMyXsEITLkNGKfkxwaDTOLUYX > 0 && P_1 != IntPtr.Zero)
		{
			DBZCtHAzIvFuQOarCKsttoMaNgUG = new byte[P_0];
			fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
			{
				QvyMHYIdbHWMtWGQBjyLybggaNAi.jMquLSbqoOKLzeBecvZYwYcJcSl((IntPtr)dBZCtHAzIvFuQOarCKsttoMaNgUG, P_1, KHUMyXsEITLkNGKfkxwaDTOLUYX);
			}
		}
	}

	protected virtual efmrLSrolSjovsfxfjCVLLJRnGz jgUKJdlhVlbmjmcGcqukHIxicKDF(int P_0, IntPtr P_1)
	{
		wCHMeVtmpfgnaDbZjXJYwQMfteN(P_0, P_1);
		return this;
	}

	internal virtual void HRXVOMCLwtFtpdpxuwJyOuZOqNYw(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr ytPODbihcgKkYwOfQIFAEFNEgkj()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (KHUMyXsEITLkNGKfkxwaDTOLUYX > 0 && DBZCtHAzIvFuQOarCKsttoMaNgUG != null)
		{
			intPtr = Marshal.AllocHGlobal(KHUMyXsEITLkNGKfkxwaDTOLUYX);
			fixed (byte* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
			{
				QvyMHYIdbHWMtWGQBjyLybggaNAi.jMquLSbqoOKLzeBecvZYwYcJcSl(intPtr, (IntPtr)dBZCtHAzIvFuQOarCKsttoMaNgUG, KHUMyXsEITLkNGKfkxwaDTOLUYX);
			}
		}
		return intPtr;
	}

	public unsafe T SQwyoJkOzYtpJrQnYpvFdfsPKNz<T>() where T : efmrLSrolSjovsfxfjCVLLJRnGz, new()
	{
		if ((object)GetType() == typeof(T))
		{
			return (T)this;
		}
		if ((object)GetType() == typeof(efmrLSrolSjovsfxfjCVLLJRnGz))
		{
			fixed (IntPtr* dBZCtHAzIvFuQOarCKsttoMaNgUG = DBZCtHAzIvFuQOarCKsttoMaNgUG)
			{
				T val = new T();
				return (T)val.jgUKJdlhVlbmjmcGcqukHIxicKDF(KHUMyXsEITLkNGKfkxwaDTOLUYX, (IntPtr)dBZCtHAzIvFuQOarCKsttoMaNgUG);
			}
		}
		return null;
	}
}

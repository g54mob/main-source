using System;
using System.Runtime.InteropServices;

internal class jTTnjFcmJNutQYLpCwPogAkUWGz
{
	private int LbbxyCxAoEHDoioGNvHFmBkKTGD;

	private byte[] MGmVOJiswkwnBAbvbGQwLtBdeEt;

	public virtual int Size => LbbxyCxAoEHDoioGNvHFmBkKTGD;

	protected jTTnjFcmJNutQYLpCwPogAkUWGz()
	{
	}

	internal jTTnjFcmJNutQYLpCwPogAkUWGz(int bufferSize, IntPtr bufferPointer)
	{
		dtacWSwUXqejVvKTIPvzDNvgneL(bufferSize, bufferPointer);
	}

	private unsafe void dtacWSwUXqejVvKTIPvzDNvgneL(int P_0, IntPtr P_1)
	{
		LbbxyCxAoEHDoioGNvHFmBkKTGD = P_0;
		if (LbbxyCxAoEHDoioGNvHFmBkKTGD > 0 && P_1 != IntPtr.Zero)
		{
			MGmVOJiswkwnBAbvbGQwLtBdeEt = new byte[P_0];
			fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
			{
				JOFzuBXkNUfGEywCsKAgVeZrrPQ.esVdJDaUiZZdCOdqRfdjVzLEMDz((IntPtr)mGmVOJiswkwnBAbvbGQwLtBdeEt, P_1, LbbxyCxAoEHDoioGNvHFmBkKTGD);
			}
		}
	}

	protected virtual jTTnjFcmJNutQYLpCwPogAkUWGz aRreqoecxmLuIAlYVRIPwMKrCMT(int P_0, IntPtr P_1)
	{
		dtacWSwUXqejVvKTIPvzDNvgneL(P_0, P_1);
		return this;
	}

	internal virtual void OdygDBNQWwlgGNhRXdWTJchNXjM(IntPtr P_0)
	{
		if (P_0 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(P_0);
		}
	}

	internal unsafe virtual IntPtr diiFuCizNlbWbcWAcnolWnmjPwtB()
	{
		IntPtr intPtr = IntPtr.Zero;
		if (LbbxyCxAoEHDoioGNvHFmBkKTGD > 0 && MGmVOJiswkwnBAbvbGQwLtBdeEt != null)
		{
			intPtr = Marshal.AllocHGlobal(LbbxyCxAoEHDoioGNvHFmBkKTGD);
			fixed (byte* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
			{
				JOFzuBXkNUfGEywCsKAgVeZrrPQ.esVdJDaUiZZdCOdqRfdjVzLEMDz(intPtr, (IntPtr)mGmVOJiswkwnBAbvbGQwLtBdeEt, LbbxyCxAoEHDoioGNvHFmBkKTGD);
			}
		}
		return intPtr;
	}

	public unsafe T XfFjEfjbaPbhAdXIFtDUgYESCQXo<T>() where T : jTTnjFcmJNutQYLpCwPogAkUWGz, new()
	{
		if ((object)GetType() == typeof(T))
		{
			return (T)this;
		}
		if ((object)GetType() == typeof(jTTnjFcmJNutQYLpCwPogAkUWGz))
		{
			fixed (IntPtr* mGmVOJiswkwnBAbvbGQwLtBdeEt = MGmVOJiswkwnBAbvbGQwLtBdeEt)
			{
				T val = new T();
				return (T)val.aRreqoecxmLuIAlYVRIPwMKrCMT(LbbxyCxAoEHDoioGNvHFmBkKTGD, (IntPtr)mGmVOJiswkwnBAbvbGQwLtBdeEt);
			}
		}
		return null;
	}
}

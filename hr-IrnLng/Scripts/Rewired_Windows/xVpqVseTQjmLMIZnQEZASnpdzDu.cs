using System;
using System.Runtime.CompilerServices;

internal struct xVpqVseTQjmLMIZnQEZASnpdzDu
{
	public IntPtr IwQsZkJYbdNBBYrWJIGRHvvDEft;

	private IntPtr mWhFrSJsfxNOutaOqTMHrfrrvsg;

	private int vAkszvGkuHLRWcyqAHqcEthfHLL;

	public int RhAZtGylZIlqFAlkWgbLvitHuRP;

	public int eWxhbyRJEJBxoPGkeUikLAJgMYg;

	internal bool IsValid
	{
		get
		{
			if (vAkszvGkuHLRWcyqAHqcEthfHLL > 0)
			{
				return mWhFrSJsfxNOutaOqTMHrfrrvsg != IntPtr.Zero;
			}
			return false;
		}
	}

	public IntPtr RawDataPtr => mWhFrSJsfxNOutaOqTMHrfrrvsg;

	public int RawDataBytes => vAkszvGkuHLRWcyqAHqcEthfHLL;

	internal unsafe xVpqVseTQjmLMIZnQEZASnpdzDu(ref oJqDOpLSpzXpieFwwDGOPDuUBLb rawInput, qAXutNHQIdCaXRExJZxwcyxTtYa memQueue)
	{
		IwQsZkJYbdNBBYrWJIGRHvvDEft = rawInput.byDGMqNQwQgcEKGrKIjIwBvRyWv.IwQsZkJYbdNBBYrWJIGRHvvDEft;
		RhAZtGylZIlqFAlkWgbLvitHuRP = rawInput.nvzezGVBdfISGGHTlahzHbKLnPuh.PSsdzRYAbZaVcorZHnsXJAJvmBj.RhAZtGylZIlqFAlkWgbLvitHuRP;
		eWxhbyRJEJBxoPGkeUikLAJgMYg = rawInput.nvzezGVBdfISGGHTlahzHbKLnPuh.PSsdzRYAbZaVcorZHnsXJAJvmBj.DzKDRCYoUwrLJdCKmaTuuiOJrEa;
		vAkszvGkuHLRWcyqAHqcEthfHLL = RhAZtGylZIlqFAlkWgbLvitHuRP * eWxhbyRJEJBxoPGkeUikLAJgMYg;
		if (vAkszvGkuHLRWcyqAHqcEthfHLL > 0)
		{
			fixed (IntPtr* cPSoRXsYzsffziDaPlzGKqcPDoP = &System.Runtime.CompilerServices.Unsafe.As<int, IntPtr>(ref rawInput.nvzezGVBdfISGGHTlahzHbKLnPuh.PSsdzRYAbZaVcorZHnsXJAJvmBj.cPSoRXsYzsffziDaPlzGKqcPDoP))
			{
				mWhFrSJsfxNOutaOqTMHrfrrvsg = memQueue.eUHeyUyORxWRVoiDvPZqazEckWe((uint)vAkszvGkuHLRWcyqAHqcEthfHLL, cPSoRXsYzsffziDaPlzGKqcPDoP);
			}
		}
		else
		{
			mWhFrSJsfxNOutaOqTMHrfrrvsg = IntPtr.Zero;
		}
	}
}

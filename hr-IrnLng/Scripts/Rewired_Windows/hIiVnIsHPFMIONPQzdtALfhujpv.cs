using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class hIiVnIsHPFMIONPQzdtALfhujpv : jTTnjFcmJNutQYLpCwPogAkUWGz
{
	[CompilerGenerated]
	private TJRnIVDrRJeQlBxEPiFyVFpyIHY[] mwtVyGpITzAMjayqlJQyCekrdciF;

	public TJRnIVDrRJeQlBxEPiFyVFpyIHY[] Conditions
	{
		[CompilerGenerated]
		get
		{
			return mwtVyGpITzAMjayqlJQyCekrdciF;
		}
		[CompilerGenerated]
		set
		{
			mwtVyGpITzAMjayqlJQyCekrdciF = value;
		}
	}

	public unsafe override int Size
	{
		get
		{
			if (Conditions == null)
			{
				return 0;
			}
			return Conditions.Length * sizeof(TJRnIVDrRJeQlBxEPiFyVFpyIHY);
		}
	}

	protected unsafe override jTTnjFcmJNutQYLpCwPogAkUWGz aRreqoecxmLuIAlYVRIPwMKrCMT(int P_0, IntPtr P_1)
	{
		if (P_0 <= 0 || P_0 % sizeof(TJRnIVDrRJeQlBxEPiFyVFpyIHY) != 0)
		{
			return null;
		}
		int num = P_0 / sizeof(TJRnIVDrRJeQlBxEPiFyVFpyIHY);
		Conditions = new TJRnIVDrRJeQlBxEPiFyVFpyIHY[num];
		fixed (TJRnIVDrRJeQlBxEPiFyVFpyIHY* conditions = Conditions)
		{
			JOFzuBXkNUfGEywCsKAgVeZrrPQ.esVdJDaUiZZdCOdqRfdjVzLEMDz((IntPtr)conditions, P_1, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<TJRnIVDrRJeQlBxEPiFyVFpyIHY>() * Conditions.Length);
		}
		return this;
	}

	internal unsafe override IntPtr diiFuCizNlbWbcWAcnolWnmjPwtB()
	{
		if (Size == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(Size);
		fixed (TJRnIVDrRJeQlBxEPiFyVFpyIHY* conditions = Conditions)
		{
			JOFzuBXkNUfGEywCsKAgVeZrrPQ.esVdJDaUiZZdCOdqRfdjVzLEMDz(intPtr, (IntPtr)conditions, JOFzuBXkNUfGEywCsKAgVeZrrPQ.OheswNOEnBNdiBgAmQFClJxrSCm<TJRnIVDrRJeQlBxEPiFyVFpyIHY>() * Conditions.Length);
		}
		return intPtr;
	}
}

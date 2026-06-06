using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct OHRjBiOQHgDSIYOkYVxJaSngpGAe
{
	[FieldOffset(0)]
	private uint FmDemQHiZOzGGDtItcfidyQDKOtkB;

	[FieldOffset(0)]
	private ulong GWoewYCpSlEilYeQcBokERuCnFblb;

	[FieldOffset(0)]
	private IntPtr zpZAxZmPikPnFKeZYYFMjhSlApNR;

	private static readonly bool JuyDiRAWACrnFKBsISURUMwBldFT;

	public static readonly int gNyFYBjOezjUTHkjcyIlWPJKctbeb;

	static OHRjBiOQHgDSIYOkYVxJaSngpGAe()
	{
		gNyFYBjOezjUTHkjcyIlWPJKctbeb = IntPtr.Size;
		JuyDiRAWACrnFKBsISURUMwBldFT = gNyFYBjOezjUTHkjcyIlWPJKctbeb == 8;
	}

	public static OHRjBiOQHgDSIYOkYVxJaSngpGAe RyOkPgTggMRnRBPKGefNIJPelevk(byte[] P_0, int P_1)
	{
		OHRjBiOQHgDSIYOkYVxJaSngpGAe result = default(OHRjBiOQHgDSIYOkYVxJaSngpGAe);
		if (JuyDiRAWACrnFKBsISURUMwBldFT)
		{
			result.GWoewYCpSlEilYeQcBokERuCnFblb = BitConverter.ToUInt64(P_0, P_1);
			result.zpZAxZmPikPnFKeZYYFMjhSlApNR = new IntPtr((long)result.GWoewYCpSlEilYeQcBokERuCnFblb);
		}
		else
		{
			result.FmDemQHiZOzGGDtItcfidyQDKOtkB = BitConverter.ToUInt32(P_0, P_1);
			result.zpZAxZmPikPnFKeZYYFMjhSlApNR = new IntPtr((int)result.FmDemQHiZOzGGDtItcfidyQDKOtkB);
		}
		return result;
	}

	[SpecialName]
	public static IntPtr gEDIrApYDatuDUtmOMhOwLhqdJhG(OHRjBiOQHgDSIYOkYVxJaSngpGAe P_0)
	{
		return P_0.zpZAxZmPikPnFKeZYYFMjhSlApNR;
	}

	[SpecialName]
	public static OHRjBiOQHgDSIYOkYVxJaSngpGAe ZtoAmugAdPqDKVmpUbCCRQaCJxmo(IntPtr P_0)
	{
		OHRjBiOQHgDSIYOkYVxJaSngpGAe result = new OHRjBiOQHgDSIYOkYVxJaSngpGAe
		{
			zpZAxZmPikPnFKeZYYFMjhSlApNR = P_0
		};
		if (JuyDiRAWACrnFKBsISURUMwBldFT)
		{
			result.GWoewYCpSlEilYeQcBokERuCnFblb = (ulong)P_0.ToInt64();
		}
		else
		{
			result.FmDemQHiZOzGGDtItcfidyQDKOtkB = (uint)P_0.ToInt32();
		}
		return result;
	}

	public string ZeKnhwrCYvKvsDtnWLKnPhyUyVLc()
	{
		if (JuyDiRAWACrnFKBsISURUMwBldFT)
		{
			return GWoewYCpSlEilYeQcBokERuCnFblb.ToString();
		}
		return FmDemQHiZOzGGDtItcfidyQDKOtkB.ToString();
	}

	public int RGFuXedNAsGnqzpsTGtfHfWvsxRcA()
	{
		if (JuyDiRAWACrnFKBsISURUMwBldFT)
		{
			return (int)GWoewYCpSlEilYeQcBokERuCnFblb;
		}
		return (int)FmDemQHiZOzGGDtItcfidyQDKOtkB;
	}
}

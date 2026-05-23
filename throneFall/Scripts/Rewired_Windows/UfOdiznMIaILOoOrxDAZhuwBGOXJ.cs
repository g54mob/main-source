using System;
using System.Runtime.CompilerServices;

internal struct UfOdiznMIaILOoOrxDAZhuwBGOXJ
{
	private int tXafBWiVGzkROFQyjLNVnATphDFlb;

	private long cAVsnZNTjmzfviDmTKseSDJnvDoP;

	private static readonly bool FMIlKUVTuiyNJeizFSYekeMYsCji;

	public static readonly int JxnjXWRqnncgJLRynSvJbwXaSSmp;

	static UfOdiznMIaILOoOrxDAZhuwBGOXJ()
	{
		FMIlKUVTuiyNJeizFSYekeMYsCji = IntPtr.Size == 8;
		JxnjXWRqnncgJLRynSvJbwXaSSmp = (FMIlKUVTuiyNJeizFSYekeMYsCji ? 8 : 4);
	}

	public static UfOdiznMIaILOoOrxDAZhuwBGOXJ bnEuXYVyxUcGrktcTThcftMyKavo(byte[] P_0, int P_1)
	{
		UfOdiznMIaILOoOrxDAZhuwBGOXJ result = default(UfOdiznMIaILOoOrxDAZhuwBGOXJ);
		if (FMIlKUVTuiyNJeizFSYekeMYsCji)
		{
			result.cAVsnZNTjmzfviDmTKseSDJnvDoP = BitConverter.ToInt64(P_0, P_1);
		}
		else
		{
			result.tXafBWiVGzkROFQyjLNVnATphDFlb = BitConverter.ToInt32(P_0, P_1);
		}
		return result;
	}

	[SpecialName]
	public static int eSxZszSjQGNXftOoVoUBvDgQZxko(UfOdiznMIaILOoOrxDAZhuwBGOXJ P_0)
	{
		if (FMIlKUVTuiyNJeizFSYekeMYsCji)
		{
			return (int)P_0.cAVsnZNTjmzfviDmTKseSDJnvDoP;
		}
		return P_0.tXafBWiVGzkROFQyjLNVnATphDFlb;
	}

	[SpecialName]
	public static long eSxZszSjQGNXftOoVoUBvDgQZxko(UfOdiznMIaILOoOrxDAZhuwBGOXJ P_0)
	{
		if (FMIlKUVTuiyNJeizFSYekeMYsCji)
		{
			return P_0.cAVsnZNTjmzfviDmTKseSDJnvDoP;
		}
		return P_0.tXafBWiVGzkROFQyjLNVnATphDFlb;
	}

	public string uPklsIowmEUKEqVqcWkJQRDrhwkp()
	{
		if (FMIlKUVTuiyNJeizFSYekeMYsCji)
		{
			return cAVsnZNTjmzfviDmTKseSDJnvDoP.ToString();
		}
		return tXafBWiVGzkROFQyjLNVnATphDFlb.ToString();
	}
}

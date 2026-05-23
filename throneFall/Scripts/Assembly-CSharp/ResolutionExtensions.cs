using UnityEngine;

public static class ResolutionExtensions
{
	public static bool CompareResolutions(this Resolution resA, Resolution resB)
	{
		if (resA.width == resB.width)
		{
			return resA.height == resB.height;
		}
		return false;
	}
}

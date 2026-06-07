using System.Collections.Generic;

public class WishSpeedCompare : IComparer<float>
{
	int IComparer<float>.Compare(float a, float b)
	{
		if (a > b)
		{
			return 1;
		}
		if (a < b)
		{
			return -1;
		}
		return 0;
	}
}

using UnityEngine;

public class DogFeatAtePoop
{
	public int poopCount;

	public void ReportFeatProgress(int poopsEaten)
	{
		poopCount += poopsEaten;
	}

	public string GetFeatString()
	{
		return "Ate some poop";
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		DogFeatAtePoop dogFeatAtePoop = (DogFeatAtePoop)obj;
		if (dogFeatAtePoop == null)
		{
			return false;
		}
		return this == dogFeatAtePoop;
	}

	public static bool operator ==(DogFeatAtePoop a, DogFeatAtePoop b)
	{
		return a.poopCount == b.poopCount;
	}

	public static bool operator !=(DogFeatAtePoop a, DogFeatAtePoop b)
	{
		return a.poopCount != b.poopCount;
	}

	public static bool operator >(DogFeatAtePoop a, DogFeatAtePoop b)
	{
		return a.poopCount > b.poopCount;
	}

	public static bool operator <(DogFeatAtePoop a, DogFeatAtePoop b)
	{
		return a.poopCount < b.poopCount;
	}

	public static bool operator >=(DogFeatAtePoop a, DogFeatAtePoop b)
	{
		if (a > b || a == b)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(DogFeatAtePoop a, DogFeatAtePoop b)
	{
		if (a < b || a == b)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int.TryParse("poopCount", out var result);
		return Mathf.RoundToInt((float)poopCount * 1000f) ^ result;
	}
}

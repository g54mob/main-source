using UnityEngine;

public class DogFeatGotAnxious
{
	public int timesAnxious;

	public void ReportFeatProgress(int timesUpdate)
	{
		timesAnxious += timesUpdate;
	}

	public string GetFeatString()
	{
		return "Got anxious";
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		DogFeatGotAnxious dogFeatGotAnxious = (DogFeatGotAnxious)obj;
		if (dogFeatGotAnxious == null)
		{
			return false;
		}
		return this == dogFeatGotAnxious;
	}

	public static bool operator ==(DogFeatGotAnxious a, DogFeatGotAnxious b)
	{
		return a.timesAnxious == b.timesAnxious;
	}

	public static bool operator !=(DogFeatGotAnxious a, DogFeatGotAnxious b)
	{
		return a.timesAnxious != b.timesAnxious;
	}

	public static bool operator >(DogFeatGotAnxious a, DogFeatGotAnxious b)
	{
		return a.timesAnxious > b.timesAnxious;
	}

	public static bool operator <(DogFeatGotAnxious a, DogFeatGotAnxious b)
	{
		return a.timesAnxious < b.timesAnxious;
	}

	public static bool operator >=(DogFeatGotAnxious a, DogFeatGotAnxious b)
	{
		if (a > b || a == b)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(DogFeatGotAnxious a, DogFeatGotAnxious b)
	{
		if (a < b || a == b)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int.TryParse("timesAnxious", out var result);
		return Mathf.RoundToInt((float)timesAnxious * 1000f) ^ result;
	}
}

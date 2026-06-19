using UnityEngine;

public class DogFeatHoursSlept
{
	public int minutesSlept;

	public void ReportFeatProgress(int numMinutesReported)
	{
		minutesSlept += numMinutesReported;
	}

	public string GetFeatString()
	{
		int roundedHours = GetRoundedHours();
		string text = "Slept " + roundedHours + " hour";
		if (roundedHours > 1)
		{
			text += "s";
		}
		return text;
	}

	private int GetRoundedHours()
	{
		return Mathf.RoundToInt((float)minutesSlept / 60f);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		DogFeatHoursSlept dogFeatHoursSlept = (DogFeatHoursSlept)obj;
		if (dogFeatHoursSlept == null)
		{
			return false;
		}
		return this == dogFeatHoursSlept;
	}

	public static bool operator ==(DogFeatHoursSlept a, DogFeatHoursSlept b)
	{
		return a.minutesSlept == b.minutesSlept;
	}

	public static bool operator !=(DogFeatHoursSlept a, DogFeatHoursSlept b)
	{
		return a.minutesSlept != b.minutesSlept;
	}

	public static bool operator >(DogFeatHoursSlept a, DogFeatHoursSlept b)
	{
		return a.minutesSlept > b.minutesSlept;
	}

	public static bool operator <(DogFeatHoursSlept a, DogFeatHoursSlept b)
	{
		return a.minutesSlept < b.minutesSlept;
	}

	public static bool operator >=(DogFeatHoursSlept a, DogFeatHoursSlept b)
	{
		if (a > b || a == b)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(DogFeatHoursSlept a, DogFeatHoursSlept b)
	{
		if (a < b || a == b)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int.TryParse("minutesSlept", out var result);
		return Mathf.RoundToInt((float)minutesSlept * 1000f) ^ result;
	}
}

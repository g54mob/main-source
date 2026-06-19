using UnityEngine;

public class DogFeatEggsLaid
{
	public int eggCount;

	public void ReportFeatProgress(int numEggsReported)
	{
		eggCount += numEggsReported;
	}

	public string GetFeatString()
	{
		string text = "Laid " + eggCount + " egg";
		if (eggCount > 1)
		{
			text += "s";
		}
		return text;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		DogFeatEggsLaid dogFeatEggsLaid = (DogFeatEggsLaid)obj;
		if (dogFeatEggsLaid == null)
		{
			return false;
		}
		return this == dogFeatEggsLaid;
	}

	public static bool operator ==(DogFeatEggsLaid a, DogFeatEggsLaid b)
	{
		return a.eggCount == b.eggCount;
	}

	public static bool operator !=(DogFeatEggsLaid a, DogFeatEggsLaid b)
	{
		return a.eggCount != b.eggCount;
	}

	public static bool operator >(DogFeatEggsLaid a, DogFeatEggsLaid b)
	{
		return a.eggCount > b.eggCount;
	}

	public static bool operator <(DogFeatEggsLaid a, DogFeatEggsLaid b)
	{
		return a.eggCount < b.eggCount;
	}

	public static bool operator >=(DogFeatEggsLaid a, DogFeatEggsLaid b)
	{
		if (a > b || a == b)
		{
			return true;
		}
		return false;
	}

	public static bool operator <=(DogFeatEggsLaid a, DogFeatEggsLaid b)
	{
		if (a < b || a == b)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int.TryParse("eggCount", out var result);
		return Mathf.RoundToInt((float)eggCount * 1000f) ^ result;
	}
}

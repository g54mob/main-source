using System;

[Serializable]
public class AppStoreBaseRate
{
	public float[] countRate;

	public float averageRating;

	public string OpinionAutor;

	public string OpinionDes;

	public string OpinionDate;

	public int OpinionRate;

	public float OpinionLike;

	public float OpinionDislike;

	public void MathAverageRating()
	{
	}

	public int GetRateCount()
	{
		return 0;
	}
}

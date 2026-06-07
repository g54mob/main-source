using System.Collections.Generic;
using Rewired.Utils;

internal class iLxYqULhLHYVzWUNInwsvFMgTLJw : nzvKGmaBQSUTfqFTedvTBlZfGVTbA
{
	private List<wFYGqCHOsYruybQVsWezkNKyKrXL> mppofRDDqHgjShtjrUThTWkiQJMaA;

	private wFYGqCHOsYruybQVsWezkNKyKrXL[] CvRivMMcZJsZoCdxFIQjiNNJEhKT;

	private bool amqVTeYuivRHkAwHFePJyGpYeVyZ;

	public iLxYqULhLHYVzWUNInwsvFMgTLJw()
	{
		mppofRDDqHgjShtjrUThTWkiQJMaA = new List<wFYGqCHOsYruybQVsWezkNKyKrXL>();
	}

	public virtual void dVWvrNkukEIxEdmTszWilerRuVgg(wFYGqCHOsYruybQVsWezkNKyKrXL P_0)
	{
		mppofRDDqHgjShtjrUThTWkiQJMaA.Add(P_0);
	}

	public float AvmFaVwVxdsffZPseEpEUlAxasjL(int P_0)
	{
		if (P_0 < 0 || P_0 >= CvRivMMcZJsZoCdxFIQjiNNJEhKT.Length)
		{
			return 0f;
		}
		return UITHXfZdHjeZpmrhbpBNoTxSfjwv(CvRivMMcZJsZoCdxFIQjiNNJEhKT[P_0].UlKNPPlLaZhClEawslKAiUmeimOHc);
	}

	public int xplWLXEautdRpIIdCautWiKzBlMG(int P_0)
	{
		if (P_0 < 0 || P_0 >= CvRivMMcZJsZoCdxFIQjiNNJEhKT.Length)
		{
			return 0;
		}
		return (int)CvRivMMcZJsZoCdxFIQjiNNJEhKT[P_0].jHHNfybuROFfOXYZpaERSBoYajCX;
	}

	public virtual void PteyASSfcygeUXrHKxljHraljwjD()
	{
		if (!amqVTeYuivRHkAwHFePJyGpYeVyZ)
		{
			amqVTeYuivRHkAwHFePJyGpYeVyZ = true;
			CvRivMMcZJsZoCdxFIQjiNNJEhKT = mppofRDDqHgjShtjrUThTWkiQJMaA.ToArray();
			mppofRDDqHgjShtjrUThTWkiQJMaA = null;
		}
	}

	private float UITHXfZdHjeZpmrhbpBNoTxSfjwv(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}

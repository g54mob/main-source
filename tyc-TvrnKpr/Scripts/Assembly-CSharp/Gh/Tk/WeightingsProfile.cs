using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[Serializable]
	public class WeightingsProfile
	{
		[SerializeField]
		public List<Weighting> weightings;

		public static Weighting GetBiggestWeighting(WeightingsProfile baseProfile, WeightingsProfile comparisonProfile)
		{
			return null;
		}

		public int GetProfileRating(WeightingsProfile profile)
		{
			return 0;
		}
	}
}

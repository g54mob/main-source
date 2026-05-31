using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Customer Review")]
	public class CustomerReviewData : ScriptableObject
	{
		[SerializeField]
		public List<int> _scoreSteps = new List<int>();

		public static event Action<int> StarsReview;

		public int GetScoreFromSatisfaction(float unitIntervalSatisfaction, bool Vampire = false)
		{
			int num = GetSatisfactionStarCount(unitIntervalSatisfaction).CurrentValue - 1;
			if (Vampire)
			{
				CustomerReviewData.StarsReview?.Invoke(num + 1);
			}
			return _scoreSteps[num];
		}

		public RangeValue<int> GetSatisfactionStarCount(float unitIntervalSatisfaction)
		{
			RangeValue<int> result = new RangeValue<int>
			{
				MinimumValue = 1,
				MaximumValue = _scoreSteps.Count
			};
			float num = 1f / (float)_scoreSteps.Count;
			int value = (int)Math.Ceiling(unitIntervalSatisfaction / num) - 1;
			value = Math.Clamp(value, 0, _scoreSteps.Count - 1);
			result.CurrentValue = value + 1;
			return result;
		}
	}
}

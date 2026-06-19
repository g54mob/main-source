using System;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class StatAsAchievement
	{
		public AchievementId _id;

		public Stat _stat;

		public int _targetValue;

		[NonSerialized]
		public int _currentValue;

		[NonSerialized]
		public bool _unlocked;

		public bool IsComplete => _currentValue >= _targetValue;

		public int GetCompletePercent()
		{
			if (IsComplete)
			{
				return 100;
			}
			return Mathf.FloorToInt((float)_currentValue / (float)_targetValue * 100f);
		}
	}
}

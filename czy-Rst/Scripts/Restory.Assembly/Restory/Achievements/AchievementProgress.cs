using System;
using UnityEngine;

namespace Restory.Achievements
{
	[Serializable]
	public class AchievementProgress
	{
		[SerializeField]
		private float progress;

		[SerializeField]
		private bool isUnlocked;

		public float Progress
		{
			get
			{
				return progress;
			}
			set
			{
				progress = value;
			}
		}

		public bool IsUnlocked
		{
			get
			{
				return isUnlocked;
			}
			set
			{
				isUnlocked = value;
			}
		}
	}
}

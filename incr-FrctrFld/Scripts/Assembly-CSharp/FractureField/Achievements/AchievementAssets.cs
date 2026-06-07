using System;
using System.Collections.Generic;
using UnityEngine;

namespace FractureField.Achievements
{
	[Serializable]
	public class AchievementAssets
	{
		private Dictionary<string, Sprite> AchievementSprites { get; }

		public void Init()
		{
		}

		public Sprite GetSprite(string achievementId)
		{
			return null;
		}
	}
}

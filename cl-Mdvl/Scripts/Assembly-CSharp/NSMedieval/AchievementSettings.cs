using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval
{
	[Serializable]
	public class AchievementSettings : NSEipix.Base.Model
	{
		[Serializable]
		public struct StatSettings
		{
			[SerializeField]
			private string id;

			[SerializeField]
			private int refreshInterval;

			public string ID => id;

			public int RefreshInterval => refreshInterval;
		}

		[SerializeField]
		private StatSettings[] stats;

		public StatSettings[] Stats => stats;

		public override string GetID()
		{
			return "AchievementSettings";
		}
	}
}

using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using TH20.Video;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ChallengeScheduleDefinition
	{
		public struct Item
		{
			public SharedInstance<ChallengeConfig> Config;

			public int Weight;
		}

		public bool Deprecated;

		public string Name;

		public bool IsEnabledOnStart = true;

		public bool StartWithCooldown = true;

		public int MinCooldownInDays = 150;

		public int MaxCooldownInDays = 250;

		public List<IChallengePrerequisite> Prerequisites;

		public List<Item> Challenges;

		public SharedInstance<SubtitlesDefinition> Subtitles;

		public bool CheckConditions(Level level)
		{
			if (Prerequisites == null)
			{
				return true;
			}
			foreach (IChallengePrerequisite prerequisite in Prerequisites)
			{
				if (!prerequisite.CheckConditions(level))
				{
					return false;
				}
			}
			return true;
		}
	}
}

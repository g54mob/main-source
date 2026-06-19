using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CollaborativeProjectDefinition
	{
		[Serializable]
		public struct NPCChat
		{
			public LocalisedString Name;

			public LocalisedString Message;

			public Sprite Icon;
		}

		public LocalisedString Name;

		public LocalisedString Description;

		public LocalisedString VictoryLetterText;

		public LocalisedString VictoryLetterHeader;

		public LocalisedString VictoryLetterFooter;

		public List<NPCChat> StickyChatList;

		public int MaxCollaborators;

		public Sprite RootNodeSprite;

		public SharedInstance<ResearchNetworkGenerator> NetworkGenerator;

		public Dictionary<int, SharedInstance<ResearchNetworkGenerator>> VersionNetworkGenerator;

		public IRewardMetagame[] CompletionRewards;

		public List<SharedInstance<CollaborativeProjectDefinition>> ProjectPrerequisites;

		public bool IsDebugProject;

		public bool HasAchievementToReward;

		public AchievementId AchievementToReward;
	}
}

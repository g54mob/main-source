using System;
using NSEipix.Base;
using NSMedieval.Model;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.PlayerTriggeredEventSystem
{
	[Serializable]
	public class EventOutcomeSetting : NSEipix.Base.Model
	{
		[Serializable]
		public class GlobalStatWithNpcCount
		{
			[SerializeField]
			private string globalStat;

			[SerializeField]
			private float value;

			[SerializeField]
			private int minNpcCount = -1;

			public string GlobalStat => globalStat;

			public float Value => value;

			public int MinNpcCount => minNpcCount;
		}

		[SerializeField]
		private string id;

		[SerializeField]
		private string unlockAchievementOnEnd;

		[SerializeField]
		private string imagePath;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private float outcomeValue;

		[SerializeField]
		private float factionFriendliness;

		[SerializeField]
		private string[] participantEffectors;

		[SerializeField]
		private string[] skillEffectors;

		[SerializeField]
		private string[] nonParticipantEffectors;

		[SerializeField]
		private string[] nonFactionPrisonerEffectors;

		[SerializeField]
		private string[] factionPrisonerEffectors;

		[SerializeField]
		private SecondMapType discoverMapMarkerFromForeigners;

		[SerializeField]
		private float discoverMapMarkerFromForeignersChance;

		[SerializeField]
		private GlobalStatWithNpcCount[] addToGlobalStats;

		public string UnlockAchievementOnEnd => unlockAchievementOnEnd;

		public LocKeys[] LocKeys => locKeys;

		public float OutcomeValue => outcomeValue;

		public string ImagePath => imagePath;

		public string[] ParticipantEffectors => participantEffectors ?? (participantEffectors = Array.Empty<string>());

		public string[] NonParticipantEffectors => nonParticipantEffectors ?? (nonParticipantEffectors = Array.Empty<string>());

		public string[] NonFactionPrisonerEffectors => nonFactionPrisonerEffectors ?? (nonFactionPrisonerEffectors = Array.Empty<string>());

		public string[] FactionPrisonerEffectors => factionPrisonerEffectors ?? (factionPrisonerEffectors = Array.Empty<string>());

		public float Friendliness => factionFriendliness;

		public SecondMapType DiscoverMapMarkerFromForeigners => discoverMapMarkerFromForeigners;

		public float DiscoverMapMarkerFromForeignersChance => discoverMapMarkerFromForeignersChance;

		public string[] SkillEffectors => skillEffectors;

		public GlobalStatWithNpcCount[] AddToGlobalStats => addToGlobalStats;

		public override string GetID()
		{
			return id;
		}
	}
}

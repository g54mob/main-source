using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Model;
using UnityEngine;

namespace Social
{
	[Serializable]
	public class SocialCompatibilitySettings : Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private float speechCraftWeight;

		[SerializeField]
		private float ageWeight;

		[SerializeField]
		private float beliefWeight;

		[SerializeField]
		private float affectionWeight;

		[SerializeField]
		private float randomWeight;

		[SerializeField]
		private float speechCraftMax;

		[SerializeField]
		private float ageMaxDiff;

		[SerializeField]
		private float beliefMaxDiff;

		[SerializeField]
		private float affectionMaxDiff;

		[SerializeField]
		private float affectionRivalThreshold;

		[SerializeField]
		private float affectionFriendThreshold;

		[SerializeField]
		private int conversationSpeechcraftXp;

		[SerializeField]
		private List<EventInteractionTypeFloatPair> eventInteractionGlobalChances;

		[NonSerialized]
		private readonly System.Random random = new System.Random();

		public float AffectionRivalThreshold => affectionRivalThreshold;

		public float AffectionFriendThreshold => affectionFriendThreshold;

		public int ConversationSpeechcraftXp => conversationSpeechcraftXp;

		public List<EventInteractionTypeFloatPair> EventInteractionGlobalChances => eventInteractionGlobalChances;

		public override string GetID()
		{
			return id;
		}

		public float GetSpeechCraftValue(float speechCraftLevel)
		{
			return speechCraftLevel / speechCraftMax * speechCraftWeight * 2f - speechCraftWeight;
		}

		public float GetAgeValue(float valueA, float valueB)
		{
			return (ageMaxDiff - Mathf.Min(Mathf.Abs(valueA - valueB), ageMaxDiff)) / ageMaxDiff * ageWeight * 2f - ageWeight;
		}

		public float GetBeliefValue(float valueA, float valueB)
		{
			return (beliefMaxDiff - Mathf.Min(Mathf.Abs(valueA - valueB), beliefMaxDiff)) / beliefMaxDiff * beliefWeight * 2f - beliefWeight;
		}

		public float GetAffectionValue(float affection)
		{
			return Mathf.Abs(affection + affectionMaxDiff / 2f) / affectionMaxDiff * affectionWeight * 2f - affectionWeight;
		}

		public float GetRandom()
		{
			return (float)random.Next(101) / 100f * randomWeight * 2f - randomWeight;
		}

		public AffectionLevel GetAffectionLevel(float value)
		{
			if (value <= AffectionRivalThreshold)
			{
				return AffectionLevel.Rival;
			}
			if (value > AffectionFriendThreshold)
			{
				return AffectionLevel.Friend;
			}
			return AffectionLevel.Neutral;
		}
	}
}

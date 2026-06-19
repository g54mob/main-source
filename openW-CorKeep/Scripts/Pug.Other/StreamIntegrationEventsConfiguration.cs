using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "StreamIntegrationEventsConfiguration", menuName = "Pug/StreamIntegration/StreamIntegrationEventsConfiguration", order = 0)]
public class StreamIntegrationEventsConfiguration : ScriptableObject
{
	[Serializable]
	public class EnemyGroupsProbability
	{
		public StreamIntegrationEventRarity rarity;

		public float probability;
	}

	[Serializable]
	public class EnemyGroupsConfigurations
	{
		public ObjectID[] commonEnemies;

		public ObjectID[] rareEnemies;

		public ObjectID[] specialEnemies;
	}

	[Serializable]
	public class MaxEnemiesOnScreenPerRarity
	{
		public int maximumCommonEnemies;

		public int maximumRareEnemies;

		public int maximumSpecialEnemies;
	}

	[Serializable]
	public class DebuffBuffPotionGroupsProbability
	{
		public StreamIntegrationEventRarity rarity;

		public float probability;
	}

	[Serializable]
	public class DebuffBuffPotionGroupsConfigurations
	{
		[Serializable]
		public struct DebuffBuffPotionDataWithProbability
		{
			public ObjectID objectId;

			public ConditionData condition;

			public float durationForTextMessages;

			public float durationForSentGifts;

			public float probabilityToBeApplied;
		}

		public DebuffBuffPotionDataWithProbability[] commonDebuffBuffPotions;

		public DebuffBuffPotionDataWithProbability[] rareDebuffBuffsPotions;

		public DebuffBuffPotionDataWithProbability[] specialDebuffBuffsPotions;
	}

	[Serializable]
	public class AmountOfHPMPToRestoreWhenLiked
	{
		public float amountOfHP;

		public float amountOfMP;

		public bool convertToPercentage;
	}

	[Serializable]
	public class BombPosCleanupConfigurations
	{
		public float cleanUpInterval;

		public float posExpirationTime;
	}

	[Serializable]
	public class BombGroupsConfigurations
	{
		[Serializable]
		public struct BombDataWithProbability
		{
			public ObjectID objectId;

			public float probability;
		}

		public BombDataWithProbability[] bombs;

		public int2 bombSpawnArea;
	}

	public int safeZoneRadius;

	public float safeZoneFadeTime;

	public float textMessagesSummonAggregationTime;

	public float textMessagesBuffAggregationTime;

	public float textMessagesDebuffAggregationTime;

	public float textMessagesBombsAggregationTime;

	public List<EnemyGroupsProbability> enemyGroupsTextMessageProbability;

	public List<EnemyGroupsProbability> enemyGroupsPaidGiftProbability;

	public EnemyGroupsConfigurations enemyPoolConfigurations;

	public MaxEnemiesOnScreenPerRarity maxEnemiesOnScreenPerRarity;

	public List<DebuffBuffPotionGroupsProbability> debuffBuffPotionTextMessageProbability;

	public List<DebuffBuffPotionGroupsProbability> debuffBuffPotionPaidGiftProbability;

	public DebuffBuffPotionGroupsConfigurations buffPotionGroupsConfigurations;

	public DebuffBuffPotionGroupsConfigurations debuffConfigurations;

	public BombPosCleanupConfigurations bombPositionCleanUpConfigurations;

	public BombGroupsConfigurations bombsPoolTextMessageConfigurations;

	public BombGroupsConfigurations bombsPoolPaidGiftConfigurations;

	public AmountOfHPMPToRestoreWhenLiked amountOfHpMpToRestoreWhenLiked;
}

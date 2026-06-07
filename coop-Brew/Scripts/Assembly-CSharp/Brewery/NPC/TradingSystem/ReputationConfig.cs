using System;
using UnityEngine;

namespace Brewery.NPC.TradingSystem
{
	[Obsolete("Reputation system has been removed. NPC progression is now quest-based.")]
	[CreateAssetMenu(fileName = "ReputationConfig", menuName = "Trading/Reputation Config")]
	public class ReputationConfig : ScriptableObject
	{
		[Header("Reputation Limits")]
		[Tooltip("Maximum reputation level (default 10)")]
		public float maxReputation;

		[Header("Trade Multiplier")]
		[Tooltip("Formula: effectiveMax = baseMax * (1 + reputation * this). At 0.9, rep 10 = 10x trades")]
		public float tradeMultiplierPerLevel;

		[Header("Reputation Gains - Trading")]
		[Tooltip("Base reputation gained per trade, scaled by trade value ($100 = 1x multiplier)")]
		public float baseReputationPerTrade;

		[Tooltip("Trade value that equals 1x reputation multiplier")]
		public float baseTradeValue;

		[Tooltip("Maximum value multiplier for reputation gains (caps very expensive trades)")]
		public float maxValueMultiplier;

		[Tooltip("Minimum value multiplier for reputation gains (cheap trades still give some rep)")]
		public float minValueMultiplier;

		[Header("Reputation Gains - Quests")]
		[Tooltip("Reputation gained per quest step completed with an NPC")]
		public float reputationPerQuestStep;

		[Tooltip("Bonus reputation when completing a full quest chain from an NPC")]
		public float reputationPerQuestChain;

		public float GetTradeMultiplier(float reputation)
		{
			return 0f;
		}

		public int GetEffectiveMaxTrades(int baseMax, float reputation)
		{
			return 0;
		}

		public float CalculateTradeReputation(int totalTradeValue)
		{
			return 0f;
		}

		public float ClampReputation(float reputation)
		{
			return 0f;
		}
	}
}

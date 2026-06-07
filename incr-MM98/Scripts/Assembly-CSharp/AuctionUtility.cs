using System;
using R3;
using UnityEngine;

public static class AuctionUtility
{
	private const float Epsilon = 0.0001f;

	private const float MinDropchance = 0.05f;

	private const float MaxDropchance = 0.85f;

	private const float HiddenRange = 0.8f;

	private const float HypeAlignedBonus = 0.22f;

	private const float HypeMisalignedPenalty = 0.55f;

	private const float ParticipationAlignedBonus = 0.35f;

	private const float ParticipationMisalignedPenalty = 0.65f;

	private const float PositiveSentimentThreshold = 0.4f;

	private const float NegativeSentimentThreshold = -0.4f;

	private const float NeutralValueDrift = 0.06f;

	private const float ValuePositivePeakBonus = 0.65f;

	private const float ValueNegativePeakPenalty = 0.7f;

	private const float HypeObfuscationNoise = 0.045f;

	private const float SentimentDeadzone = 0.18f;

	private const float SentimentJitter = 0.08f;

	private const float SentimentMoveSpeed = 0.07f;

	public static void RerollHiddenDistribution(DatabaseState.AuctionState state)
	{
		float[] array = new float[4]
		{
			BiteRandom.NextFloat() + 0.0001f,
			BiteRandom.NextFloat() + 0.0001f,
			BiteRandom.NextFloat() + 0.0001f,
			BiteRandom.NextFloat() + 0.0001f
		};
		float num = array[0] + array[1] + array[2] + array[3];
		if (num <= 0.0001f)
		{
			num = 1f;
		}
		state.HiddenCommonDropchance.Value = 0.05f + 0.8f * (array[0] / num);
		state.HiddenUncommonDropchance.Value = 0.05f + 0.8f * (array[1] / num);
		state.HiddenRareDropchance.Value = 0.05f + 0.8f * (array[2] / num);
		state.HiddenLegendaryDropchance.Value = 0.05f + 0.8f * (array[3] / num);
		state.HiddenSentiment.Value = 0f;
		state.HiddenSentimentTarget.Value = 0f;
		state.HiddenSentimentTimer.StartTimer(BiteRandom.NextFloat(8f, 15f));
	}

	public static void TickHiddenSentiment(DatabaseState.AuctionState state, float deltaTime)
	{
		if (state.HiddenSentimentTimer.AdvanceTimer(deltaTime))
		{
			float dropAlignmentScore = GetDropAlignmentScore(state);
			float num = ((Mathf.Abs(dropAlignmentScore) < 0.18f) ? 0f : dropAlignmentScore);
			num = Mathf.Clamp(num + BiteRandom.NextFloat(-0.08f, 0.08f), -1f, 1f);
			state.HiddenSentimentTarget.Value = num;
			state.HiddenSentimentTimer.StartTimer(BiteRandom.NextFloat(8f, 15f));
		}
		state.HiddenSentiment.Value = Mathf.MoveTowards(state.HiddenSentiment.Value, state.HiddenSentimentTarget.Value, 0.07f * deltaTime);
	}

	public static float GetHiddenSentimentScore(DatabaseState.AuctionState state)
	{
		return Mathf.Clamp(state.HiddenSentiment.Value, -1f, 1f);
	}

	public static AuctionSentimentState GetSentimentState(DatabaseState.AuctionState state)
	{
		return GetSentimentState(GetHiddenSentimentScore(state));
	}

	public static AuctionSentimentState GetSentimentState(float score)
	{
		if (score >= 0.4f)
		{
			return AuctionSentimentState.Positive;
		}
		if (score <= -0.4f)
		{
			return AuctionSentimentState.Negative;
		}
		return AuctionSentimentState.Neutral;
	}

	public static float GetSentimentIntensity(float score)
	{
		return GetSentimentState(score) switch
		{
			AuctionSentimentState.Positive => Mathf.InverseLerp(0.4f, 1f, score), 
			AuctionSentimentState.Negative => Mathf.InverseLerp(-0.4f, -1f, score), 
			_ => Mathf.Clamp01(Mathf.Abs(score) / Mathf.Abs(0.4f)), 
		};
	}

	public static float GetDropAlignmentScore(DatabaseState.AuctionState state)
	{
		float num = Mathf.Clamp01((Mathf.Abs(state.CommonDropchance.Value - state.HiddenCommonDropchance.Value) + Mathf.Abs(state.UncommonDropchance.Value - state.HiddenUncommonDropchance.Value) + Mathf.Abs(state.RareDropchance.Value - state.HiddenRareDropchance.Value) + Mathf.Abs(state.LegendaryDropchance.Value - state.HiddenLegendaryDropchance.Value)) * 0.5f);
		return Mathf.Clamp(1f - num * 2f, -1f, 1f);
	}

	public static float GetHypeOffsetFromAlignment(DatabaseState.AuctionState state)
	{
		float num = Mathf.Clamp(GetHiddenSentimentScore(state) + BuildHypeObfuscation(state), -1f, 1f);
		if (!(num >= 0f))
		{
			return num * 0.55f;
		}
		return num * 0.22f;
	}

	public static float GetParticipationMultiplierFromAlignment(DatabaseState.AuctionState state)
	{
		float hiddenSentimentScore = GetHiddenSentimentScore(state);
		return Mathf.Clamp((hiddenSentimentScore >= 0f) ? (1f + hiddenSentimentScore * 0.35f) : (1f + hiddenSentimentScore * 0.65f), 0.2f, 1.5f);
	}

	public static double GetValueMultiplierFromAlignment(DatabaseState.AuctionState state)
	{
		float hiddenSentimentScore = GetHiddenSentimentScore(state);
		AuctionSentimentState sentimentState = GetSentimentState(hiddenSentimentScore);
		float sentimentIntensity = GetSentimentIntensity(hiddenSentimentScore);
		return Mathf.Clamp(sentimentState switch
		{
			AuctionSentimentState.Positive => 1f + sentimentIntensity * 0.65f, 
			AuctionSentimentState.Negative => 1f - sentimentIntensity * 0.7f, 
			_ => 1f + hiddenSentimentScore * 0.06f, 
		}, 0.3f, 1.7f);
	}

	public static LootItemQuality RandomLootQuality()
	{
		float num = BiteRandom.NextFloat();
		float value = Database.State.Auction.CommonDropchance.Value;
		if (num < value)
		{
			return LootItemQuality.Common;
		}
		value += Database.State.Auction.UncommonDropchance.Value;
		if (num < value)
		{
			return LootItemQuality.Uncommon;
		}
		value += Database.State.Auction.RareDropchance.Value;
		if (!(num < value))
		{
			return LootItemQuality.Legendary;
		}
		return LootItemQuality.Rare;
	}

	public static double RandomLootValue(LootItemQuality quality)
	{
		double num = BiteRandom.NextDouble(ModifierType.AuctionValueMinimum.Double(), ModifierType.AuctionValueMaximum.Double());
		double num2 = ModifierType.AuctionValueModifier.Double();
		double valueMultiplierFromAlignment = GetValueMultiplierFromAlignment(Database.State.Auction);
		return Math.Round(num * num2 * valueMultiplierFromAlignment * quality switch
		{
			LootItemQuality.Common => ModifierType.AuctionValueCommonModifier.Double(), 
			LootItemQuality.Uncommon => ModifierType.AuctionValueUncommonModifier.Double(), 
			LootItemQuality.Rare => ModifierType.AuctionValueRareModifier.Double(), 
			LootItemQuality.Legendary => ModifierType.AuctionValueLegendaryModifier.Double(), 
			_ => throw new ArgumentOutOfRangeException("quality", quality, null), 
		}, MidpointRounding.AwayFromZero);
	}

	private static float BuildHypeObfuscation(DatabaseState.AuctionState state)
	{
		float num = state.HiddenSentimentTarget.Value * 19.19f + state.HiddenCommonDropchance.Value * 7.77f + state.HiddenLegendaryDropchance.Value * 31.13f;
		return Mathf.Clamp((Mathf.Sin(num * 12.9898f) + Mathf.Sin(num * 78.233f) * 0.5f) * 0.045f, -0.045f, 0.045f);
	}

	public static void MapFromProperties(ref float[] chances, ReactiveProperty<float>[] properties)
	{
		if (chances.Length != properties.Length)
		{
			throw new IndexOutOfRangeException("Mismatch in amount of chances and properties");
		}
		chances[0] = properties[0].Value;
		chances[1] = properties[1].Value;
		chances[2] = properties[2].Value;
		chances[3] = properties[3].Value;
	}

	public static void MapToProperties(ref float[] chances, ReactiveProperty<float>[] properties)
	{
		if (chances.Length != properties.Length)
		{
			throw new IndexOutOfRangeException("Mismatch in amount of chances and properties");
		}
		properties[0].Value = chances[0];
		properties[1].Value = chances[1];
		properties[2].Value = chances[2];
		properties[3].Value = chances[3];
	}

	public static void RedistributeProportionally(int pinnedIndex, float target, ref float[] chances)
	{
		float num = Mathf.Clamp(target, 0.05f, 0.85f);
		chances[pinnedIndex] = num;
		bool[] array = new bool[chances.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i != pinnedIndex;
		}
		for (int j = 0; j < 32; j++)
		{
			float num2 = 0f;
			float num3 = 0f;
			int num4 = 0;
			for (int k = 0; k < chances.Length; k++)
			{
				if (k != pinnedIndex)
				{
					if (array[k])
					{
						num2 += chances[k];
						num4++;
					}
					else
					{
						num3 += chances[k];
					}
				}
			}
			float num5 = 1f - num - num3;
			if (num4 == 0)
			{
				break;
			}
			if (num2 <= 0.0001f)
			{
				float num6 = num5 / (float)num4;
				for (int l = 0; l < chances.Length; l++)
				{
					if (array[l])
					{
						chances[l] = num6;
					}
				}
			}
			else
			{
				float num7 = num5 / num2;
				for (int m = 0; m < chances.Length; m++)
				{
					if (array[m])
					{
						chances[m] *= num7;
					}
				}
			}
			bool flag = false;
			for (int n = 0; n < chances.Length; n++)
			{
				if (!array[n])
				{
					continue;
				}
				float num8 = chances[n];
				if (!(num8 < 0.05f))
				{
					if (num8 > 0.85f)
					{
						chances[n] = 0.85f;
						array[n] = false;
						flag = true;
					}
				}
				else
				{
					chances[n] = 0.05f;
					array[n] = false;
					flag = true;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		float num9 = 0f;
		float[] array2 = chances;
		foreach (float num11 in array2)
		{
			num9 += num11;
		}
		float num12 = 1f - num9;
		if (Mathf.Abs(num12) >= 0.0005f)
		{
			int num13 = -1;
			float num14 = float.MinValue;
			for (int num15 = 0; num15 < chances.Length; num15++)
			{
				if (num15 != pinnedIndex && !(chances[num15] <= num14))
				{
					num14 = chances[num15];
					num13 = num15;
				}
			}
			if (num13 >= 0)
			{
				float value = chances[num13] + num12;
				chances[num13] = Mathf.Clamp(value, 0.05f, 0.85f);
			}
		}
		for (int num16 = 0; num16 < chances.Length; num16++)
		{
			chances[num16] = Mathf.Clamp(chances[num16], 0.05f, 0.85f);
		}
	}
}

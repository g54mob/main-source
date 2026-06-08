using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class SpecialTileSpawner : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<GroupTypeConfiguration, bool> _003C_003E9__13_0;

		public static Func<GroupTypeConfiguration, bool> _003C_003E9__13_1;

		internal bool _003CSetup_003Eb__13_0(GroupTypeConfiguration x)
		{
			return x.groupType.id == GroupTypeId.Water;
		}

		internal bool _003CSetup_003Eb__13_1(GroupTypeConfiguration x)
		{
			return x.groupType.id == GroupTypeId.TrainTracks;
		}
	}

	[SerializeField]
	private Tile specialTile;

	[SerializeField]
	private int scoreTreshold;

	[SerializeField]
	private bool increaseTreshold = true;

	[SerializeField]
	[FormerlySerializedAs("increaseTresholdAmount")]
	private int increaseAmount;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private TileGenerator tileGenerator;

	private int lastRewardedStep;

	private int lastRewardedScore;

	public int LastRewardedStep => lastRewardedStep;

	public int LastRewardedScore => lastRewardedScore;

	public void Setup(int lastRewardedStep = -1, int lastRewardedScore = -1)
	{
		if ((lastRewardedStep == -1 && lastRewardedScore == -1) || lastRewardedScore < rewardSystem.Score / 2)
		{
			DetermineLastRewardedScore(rewardSystem.Score, out this.lastRewardedScore, out this.lastRewardedStep);
		}
		else
		{
			this.lastRewardedStep = lastRewardedStep;
			this.lastRewardedScore = lastRewardedScore;
		}
		if (Enumerable.First(tileGenerator.Configuration.globalGroupTypeProbabilities, (GroupTypeConfiguration x) => x.groupType.id == GroupTypeId.Water).Probability != 0f || Enumerable.First(tileGenerator.Configuration.globalGroupTypeProbabilities, (GroupTypeConfiguration x) => x.groupType.id == GroupTypeId.TrainTracks).Probability != 0f)
		{
			tileStack.OnAdvanced += CheckScoreCondition;
		}
	}

	private void CheckScoreCondition()
	{
		if (rewardSystem.Score > lastRewardedScore + scoreTreshold + lastRewardedStep * increaseAmount && tileStack.Height >= 3)
		{
			lastRewardedScore += scoreTreshold + lastRewardedStep * increaseAmount;
			lastRewardedStep++;
			tileStack.ReplaceStackedTile(Mathf.Clamp(3, 0, tileStack.Height - 1), specialTile);
		}
	}

	private void TestScoresTo2M()
	{
		for (int i = 0; i < 2000000; i += 10000)
		{
			TestScore(i);
		}
	}

	private void TestScore(int score)
	{
		Debug.Log($"Score {score} -> Previously: {Mathf.FloorToInt((float)score / 2500f)}; New: {GetStepFromScore(score)}");
	}

	public int GetStepFromScore(int score)
	{
		if (!increaseTreshold)
		{
			return Mathf.FloorToInt((float)rewardSystem.Score / (float)scoreTreshold);
		}
		int num = 0;
		int num2 = 0;
		while (num2 < score)
		{
			num2 += 2500 + num * increaseAmount;
			if (num2 > score)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private void DetermineLastRewardedScore(int score, out int lastRewardedScore, out int increasedCounter)
	{
		int num = 0;
		increasedCounter = 0;
		lastRewardedScore = 0;
		while (num < score)
		{
			num += scoreTreshold + increasedCounter * increaseAmount;
			if (num <= score)
			{
				lastRewardedScore = num;
				increasedCounter++;
				continue;
			}
			break;
		}
	}

	private void OnDestroy()
	{
		tileStack.OnAdvanced -= CheckScoreCondition;
	}
}

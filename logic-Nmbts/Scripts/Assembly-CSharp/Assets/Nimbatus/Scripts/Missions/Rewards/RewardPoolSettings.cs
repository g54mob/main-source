using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.Receivables.ReceivableSettings;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.Rewards
{
	public class RewardPoolSettings
	{
		public class RewardPoolParameters
		{
			public int MinAmount = 1;

			public int MaxAmount = 1;

			public bool UseProbabilityByComplexity;

			[HideIf("UseProbabilityByComplexity", true)]
			[Indent(1)]
			public float Probability = 1f;

			[ShowIf("UseProbabilityByComplexity", true)]
			[Indent(1)]
			public AnimationCurve ProbabilityByComplexity = new AnimationCurve(new Keyframe(1f, 0.1f), new Keyframe(5f, 0.9f));
		}

		[HideIf("AdjustedForDifficulty", true)]
		public RewardPoolParameters Default = new RewardPoolParameters();

		[HorizontalGroup("Split", 0f, 0, 0, 0)]
		[ShowIf("AdjustedForDifficulty", true)]
		[VerticalGroup("Split/Low", 0)]
		[LabelWidth(100f)]
		public RewardPoolParameters Low;

		[ShowIf("AdjustedForDifficulty", true)]
		[VerticalGroup("Split/Medium", 0)]
		[LabelWidth(100f)]
		public RewardPoolParameters Medium;

		[ShowIf("AdjustedForDifficulty", true)]
		[VerticalGroup("Split/Hard", 0)]
		[LabelWidth(100f)]
		public RewardPoolParameters High;

		[HideInInspector]
		public bool AdjustedForDifficulty;

		public BaseReceivableSettings Reward;

		[Button("Simple/Advanced")]
		private void Toggle()
		{
			if (!AdjustedForDifficulty)
			{
				if (Low == null)
				{
					Low = new RewardPoolParameters();
				}
				if (Medium == null)
				{
					Medium = new RewardPoolParameters();
				}
				if (High == null)
				{
					High = new RewardPoolParameters();
				}
			}
			else if (Default == null)
			{
				Default = new RewardPoolParameters();
			}
			AdjustedForDifficulty = !AdjustedForDifficulty;
		}

		public RewardPoolParameters GetGroup(EMissionDifficulty difficulty)
		{
			if (!AdjustedForDifficulty)
			{
				return Default;
			}
			switch (difficulty)
			{
			case EMissionDifficulty.Low:
				if (AdjustedForDifficulty)
				{
					return Low;
				}
				return Default;
			case EMissionDifficulty.Medium:
				if (AdjustedForDifficulty)
				{
					return Medium;
				}
				return Default;
			case EMissionDifficulty.Hard:
				if (AdjustedForDifficulty)
				{
					return High;
				}
				return Default;
			default:
				return Default;
			}
		}

		public BaseReceivable CreateReward(int seed, int amount)
		{
			return Reward.CreateReceivable(seed, amount);
		}
	}
}

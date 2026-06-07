using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions.Rewards
{
	public class RewardPool : SerializedScriptableObject
	{
		public class PossibleReward
		{
			public BaseReceivable Receivable;

			public float Probability;
		}

		public bool IsDefaultPool;

		[Indent(1)]
		public bool UseProbabilityByComplexity;

		[HideIf("UseProbabilityByComplexity", true)]
		[Indent(1)]
		public float Probability = 1f;

		[ShowIf("UseProbabilityByComplexity", true)]
		[Indent(1)]
		public AnimationCurve ProbabilityByComplexity = new AnimationCurve(new Keyframe(1f, 0.1f), new Keyframe(5f, 0.9f));

		public bool IsClimateZoneSpecific;

		[ShowIf("IsClimateZoneSpecific", true)]
		public List<EClimateZoneType> AllowedClimateZones;

		public bool OnlyWithPartUnlocking;

		public bool OnlyWithTechTree;

		public bool OnlyInSandbox;

		public List<RewardPoolSettings> Pool = new List<RewardPoolSettings>();

		public bool IsCompatible()
		{
			if (OnlyWithPartUnlocking && !RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				return false;
			}
			if (OnlyWithTechTree && !RuntimeGlobals.HasWeaponWorkshop)
			{
				return false;
			}
			if (OnlyWithTechTree && SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<WeaponAttributeUpgrade>().All((WeaponAttributeUpgrade i) => i.Unlocked))
			{
				return false;
			}
			if (OnlyInSandbox && RuntimeGlobals.GameMode != EGameMode.Creative)
			{
				return false;
			}
			return true;
		}

		public float GetEffectiveProbability(EMissionComplexity complexity)
		{
			if (complexity != EMissionComplexity.None && UseProbabilityByComplexity)
			{
				return ProbabilityByComplexity.Evaluate((float)complexity);
			}
			return Probability;
		}

		public BaseReceivable CreateRandomReward(int seed, EMissionDifficulty difficulty, EMissionComplexity complexity = EMissionComplexity.None)
		{
			RewardPoolSettings rewardPoolSettings = ((complexity == EMissionComplexity.None) ? Pool.RandomItemProbability((RewardPoolSettings p) => p.GetGroup(difficulty).Probability, seed) : Pool.RandomItemProbability((RewardPoolSettings p) => (!p.GetGroup(difficulty).UseProbabilityByComplexity) ? p.GetGroup(difficulty).Probability : p.GetGroup(difficulty).ProbabilityByComplexity.Evaluate((float)complexity), seed));
			int amount = Random.Range(rewardPoolSettings.GetGroup(difficulty).MinAmount, rewardPoolSettings.GetGroup(difficulty).MaxAmount + 1);
			return rewardPoolSettings.CreateReward(seed, amount);
		}

		public List<PossibleReward> GetPossibleRewards(EMissionDifficulty difficulty, EMissionComplexity complexity, int seed)
		{
			List<PossibleReward> list = new List<PossibleReward>();
			foreach (RewardPoolSettings item in Pool)
			{
				int amount = Random.Range(item.GetGroup(difficulty).MinAmount, item.GetGroup(difficulty).MaxAmount + 1);
				BaseReceivable receivable = item.CreateReward(seed, amount);
				float probability = ((complexity == EMissionComplexity.None) ? item.GetGroup(difficulty).Probability : (item.GetGroup(difficulty).UseProbabilityByComplexity ? item.GetGroup(difficulty).ProbabilityByComplexity.Evaluate((float)complexity) : item.GetGroup(difficulty).Probability));
				list.Add(new PossibleReward
				{
					Receivable = receivable,
					Probability = probability
				});
			}
			return list;
		}
	}
}

using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.TechTree;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Rewards")]
	public class StaticRewards : ScriptableObject
	{
		public void RewardMoney(int amount)
		{
			MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(MonoSingleton<MoneyHandler>.Instance.CurrentMoney + amount);
		}

		public void RewardPrestige(int amount)
		{
			Prestige.AddRewardScore(amount);
		}

		public void RewardHiringAlteration(int amount)
		{
			MonoSingleton<InterimAgency>.Instance.SetHiringCostMultiplier(amount);
		}

		public void RewardMaeveDiscount(float multiplier)
		{
			Debug.Log(MonoSingleton<MaeveExtermination>.Instance);
			if (!(MonoSingleton<MaeveExtermination>.Instance == null))
			{
				MonoSingleton<MaeveExtermination>.Instance.SetDiscount(multiplier);
			}
		}

		public void RewardFreeSalary()
		{
			MonoSingleton<InterimAgency>.Instance.SetWorkerSalaryFree(isFree: true);
		}

		public void RewardInterestRate(float rate)
		{
			MonoSingleton<FinancialLoaningManager>.Instance.ChangeLoanInterest(rate);
		}

		public void RewardResearchPoints(int points)
		{
			points = Math.Clamp(points, 0, 250);
			CTSSingleton<TechTreePoints>.Instance.TryToAddPoints(points);
		}

		public void RewardPackage(UnlockKeyCondition unlockKey)
		{
			UnlockingManager.AddUnlockKey(unlockKey.Key);
		}

		public void RewardPackage(EUnlockKey key)
		{
			UnlockingManager.AddUnlockKey(key);
		}

		public void RewardSpawnNonSpecificVampires(int count)
		{
			CTSSingleton<CustomerSpawner>.Instance.SpawnVampiresFromRules(count);
		}

		public void RewardVigilanceSet(int amount)
		{
			MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceTo(amount);
		}

		public void StartGlobalCooldown(CooldownReference cooldownReference)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists())
			{
				CTSSingleton<LevelParameters>.Instance.GlobalCooldowns.StartCooldown(cooldownReference);
			}
		}

		public void AllVampiresLeave()
		{
			foreach (Customer vampire in CustomerManager.VampireList)
			{
				if (!vampire.ActionPlayer.HasAnyActionOfType<AgentActionLeave>())
				{
					vampire.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
				}
			}
		}

		public void UnlockLevel(MapInfoSO map)
		{
			if (CTSSingleton<ProfileManager>.Instance.CurrentProfile is CareerProfile careerProfile)
			{
				careerProfile.Unlock(map);
			}
		}
	}
}

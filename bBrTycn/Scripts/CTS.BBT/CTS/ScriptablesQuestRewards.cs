using System;
using CTS.BBT;
using CTS.Core;
using CTS.TechTree;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "Quests/Scriptable Quest Rewards", fileName = "New List")]
	public class ScriptablesQuestRewards : Reward
	{
		public enum ERewardType
		{
			None = 0,
			Money = 1,
			HiringAlteration = 2,
			SetVigilance = 3,
			Furniture = 4,
			DrinkSo = 5,
			Prestige = 6,
			DiscountFurniture = 7,
			InterestRate = 8,
			ResearchPoint = 9,
			SpawnVampire = 10,
			UnlockPackage = 11,
			NotImplemented = 12
		}

		[SerializeField]
		[BoxGroup("Base Settings")]
		[Space(10f)]
		public ERewardType RewardType;

		[SerializeField]
		[BoxGroup("Money Settings")]
		[ShowIf("RewardType", ERewardType.Money)]
		[Space(10f)]
		private int _moneyAmountPositive;

		[SerializeField]
		[BoxGroup("Money Settings")]
		[ShowIf("RewardType", ERewardType.Money)]
		private int _moneyAmountNeutral;

		[SerializeField]
		[BoxGroup("Money Settings")]
		[ShowIf("RewardType", ERewardType.Money)]
		private int _moneyAmountNegative;

		[SerializeField]
		[BoxGroup("Prestige Settings")]
		[ShowIf("RewardType", ERewardType.Prestige)]
		[Space(10f)]
		private int _prestrigeAmountPositive;

		[SerializeField]
		[BoxGroup("Prestige Settings")]
		[ShowIf("RewardType", ERewardType.Prestige)]
		private int _prestrigeAmountNeutral;

		[SerializeField]
		[BoxGroup("Prestige Settings")]
		[ShowIf("RewardType", ERewardType.Prestige)]
		private int _prestrigeAmountNegative;

		[SerializeField]
		[BoxGroup("Hiring Alteration Settings")]
		[ShowIf("RewardType", ERewardType.HiringAlteration)]
		[Label("Positive Hiring Alteration (%)")]
		[Space(10f)]
		private int _hiringAlterationPositive;

		[SerializeField]
		[BoxGroup("Hiring Alteration Settings")]
		[ShowIf("RewardType", ERewardType.HiringAlteration)]
		[Label("Neutral Hiring Alteration (%)")]
		private int _hiringAlterationNeutral;

		[SerializeField]
		[BoxGroup("Hiring Alteration Settings")]
		[ShowIf("RewardType", ERewardType.HiringAlteration)]
		[Label("Negative Hiring Alteration (%)")]
		private int _hiringAlterationNegative;

		[SerializeField]
		[BoxGroup("Vigilance Settings")]
		[ShowIf("RewardType", ERewardType.SetVigilance)]
		[Space(10f)]
		private int _vigilanceAmountPositive;

		[SerializeField]
		[BoxGroup("Vigilance Settings")]
		[ShowIf("RewardType", ERewardType.SetVigilance)]
		private int _vigilanceAmountNeutral;

		[SerializeField]
		[BoxGroup("Vigilance Settings")]
		[ShowIf("RewardType", ERewardType.SetVigilance)]
		private int _vigilanceAmountNegative;

		[SerializeField]
		[BoxGroup("Furniture Settings")]
		[ShowIf("RewardType", ERewardType.Furniture)]
		[Space(10f)]
		private Furniture _furniturePositive;

		[SerializeField]
		[BoxGroup("Furniture Settings")]
		[ShowIf("RewardType", ERewardType.Furniture)]
		private Furniture _furnitureNeutral;

		[SerializeField]
		[BoxGroup("Furniture Settings")]
		[ShowIf("RewardType", ERewardType.Furniture)]
		private Furniture _furnitureNegative;

		[SerializeField]
		[BoxGroup("DrinkSo Settings")]
		[ShowIf("RewardType", ERewardType.DrinkSo)]
		[Space(10f)]
		private DrinkSO _drinkSOPositive;

		[SerializeField]
		[BoxGroup("DrinkSo Settings")]
		[ShowIf("RewardType", ERewardType.DrinkSo)]
		private DrinkSO _drinkSONeutral;

		[SerializeField]
		[BoxGroup("DrinkSo Settings")]
		[ShowIf("RewardType", ERewardType.DrinkSo)]
		private DrinkSO _drinkSONegative;

		[SerializeField]
		[BoxGroup("Discount Furniture Settings")]
		[ShowIf("RewardType", ERewardType.DiscountFurniture)]
		[Space(10f)]
		private int _discountFurnitureAmountPositive;

		[SerializeField]
		[BoxGroup("Discount Furniture Settings")]
		[ShowIf("RewardType", ERewardType.DiscountFurniture)]
		private int _discountFurnitureAmountNeutral;

		[SerializeField]
		[BoxGroup("Discount Furniture Settings")]
		[ShowIf("RewardType", ERewardType.DiscountFurniture)]
		private int _discountFurnitureAmountNegative;

		[SerializeField]
		[BoxGroup("Interest Rate Settings")]
		[ShowIf("RewardType", ERewardType.InterestRate)]
		[Space(10f)]
		private float _interestRatePositive;

		[SerializeField]
		[BoxGroup("Interest Rate Settings")]
		[ShowIf("RewardType", ERewardType.InterestRate)]
		private float _interestRateNeutral;

		[SerializeField]
		[BoxGroup("Interest Rate Settings")]
		[ShowIf("RewardType", ERewardType.InterestRate)]
		private float _interestRateNegative;

		[SerializeField]
		[BoxGroup("Research Points Settings")]
		[ShowIf("RewardType", ERewardType.ResearchPoint)]
		[Space(10f)]
		private byte _researchPointsPositive;

		[SerializeField]
		[BoxGroup("Research Points Settings")]
		[ShowIf("RewardType", ERewardType.ResearchPoint)]
		private byte _researchPointsNeutral;

		[SerializeField]
		[BoxGroup("Research Points Settings")]
		[ShowIf("RewardType", ERewardType.ResearchPoint)]
		private byte _researchPointsNegative;

		[SerializeField]
		[BoxGroup("Spawn Vampire Settings")]
		[ShowIf("RewardType", ERewardType.SpawnVampire)]
		[Space(10f)]
		private byte _spawnAmountPositive;

		[SerializeField]
		[BoxGroup("Spawn Vampire Settings")]
		[ShowIf("RewardType", ERewardType.SpawnVampire)]
		private byte _spawnAmountNeutral;

		[SerializeField]
		[BoxGroup("Spawn Vampire Settings")]
		[ShowIf("RewardType", ERewardType.SpawnVampire)]
		private byte _spawnAmountNegative;

		[SerializeField]
		[BoxGroup("Spawn Vampire Settings")]
		[ShowIf("RewardType", ERewardType.SpawnVampire)]
		private CustomerParameters _vampireToSpawn;

		[SerializeField]
		[BoxGroup("Unlock Package Settings")]
		[ShowIf("RewardType", ERewardType.UnlockPackage)]
		[Space(10f)]
		private EUnlockKey _packageToUnlock;

		public override void ApplyReward(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			switch (RewardType)
			{
			case ERewardType.None:
				Debug.LogWarning("No reward type selected");
				break;
			case ERewardType.Money:
				RewardMoney(dialogueScore);
				break;
			case ERewardType.HiringAlteration:
				RewardHiringAlteration(dialogueScore);
				break;
			case ERewardType.SetVigilance:
				RewardSetVigilance(dialogueScore);
				break;
			case ERewardType.Furniture:
				Debug.Log("It doesn't work because the system doesn't exist");
				break;
			case ERewardType.DrinkSo:
				Debug.Log("It doesn't work because the system doesn't exist");
				break;
			case ERewardType.DiscountFurniture:
				Debug.Log("It doesn't work because the system doesn't exist");
				break;
			case ERewardType.Prestige:
				RewardPrestige(dialogueScore);
				break;
			case ERewardType.InterestRate:
				RewardInterestRate(dialogueScore);
				break;
			case ERewardType.ResearchPoint:
				RewardResearchPoint(dialogueScore);
				break;
			case ERewardType.SpawnVampire:
				SpawnVampires(dialogueScore);
				break;
			case ERewardType.UnlockPackage:
				UnlockPackage();
				break;
			case ERewardType.NotImplemented:
				Debug.Log("Reward not yet implemented");
				break;
			}
		}

		private void RewardSetVigilance(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			int vigilanceTo = MonoSingleton<VigilanceHandlers>.Instance.CurrentVigilance;
			switch (dialogueScore)
			{
			case LastDialogueHelper.EDialogueScore.Positive:
				vigilanceTo = _vigilanceAmountPositive;
				break;
			case LastDialogueHelper.EDialogueScore.Neutral:
				vigilanceTo = _vigilanceAmountNeutral;
				break;
			case LastDialogueHelper.EDialogueScore.Negative:
				vigilanceTo = _vigilanceAmountNegative;
				break;
			}
			MonoSingleton<VigilanceHandlers>.Instance.SetVigilanceTo(vigilanceTo);
		}

		private void UnlockPackage()
		{
			UnlockingManager.AddUnlockKey(_packageToUnlock);
		}

		private void SpawnVampires(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			if ((bool)CTSSingleton<CustomerSpawner>.Instance && (bool)_vampireToSpawn && _vampireToSpawn.IsVampire)
			{
				int count = 0;
				switch (dialogueScore)
				{
				case LastDialogueHelper.EDialogueScore.Positive:
					count = _spawnAmountPositive;
					break;
				case LastDialogueHelper.EDialogueScore.Neutral:
					count = _spawnAmountNeutral;
					break;
				case LastDialogueHelper.EDialogueScore.Negative:
					count = _spawnAmountNegative;
					break;
				}
				CTSSingleton<CustomerSpawner>.Instance.SpawnSpecific(count, _vampireToSpawn);
			}
		}

		private void RewardResearchPoint(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			byte pointsToAdd = 0;
			switch (dialogueScore)
			{
			case LastDialogueHelper.EDialogueScore.Positive:
				pointsToAdd = _researchPointsPositive;
				break;
			case LastDialogueHelper.EDialogueScore.Neutral:
				pointsToAdd = _researchPointsNeutral;
				break;
			case LastDialogueHelper.EDialogueScore.Negative:
				pointsToAdd = _researchPointsNegative;
				break;
			}
			CTSSingleton<TechTreePoints>.Instance.TryToAddPoints(pointsToAdd);
		}

		private void RewardMoney(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			int currentMoney = MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
			switch (dialogueScore)
			{
			case LastDialogueHelper.EDialogueScore.Positive:
				MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(currentMoney + _moneyAmountPositive);
				break;
			case LastDialogueHelper.EDialogueScore.Neutral:
				MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(currentMoney + _moneyAmountNeutral);
				break;
			case LastDialogueHelper.EDialogueScore.Negative:
				MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(currentMoney + _moneyAmountNegative);
				break;
			}
		}

		private void RewardPrestige(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			switch (dialogueScore)
			{
			case LastDialogueHelper.EDialogueScore.Positive:
				Prestige.AddRewardScore(_prestrigeAmountPositive);
				break;
			case LastDialogueHelper.EDialogueScore.Neutral:
				Prestige.AddRewardScore(_prestrigeAmountNeutral);
				break;
			case LastDialogueHelper.EDialogueScore.Negative:
				Prestige.AddRewardScore(_prestrigeAmountNegative);
				break;
			}
		}

		private void RewardHiringAlteration(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			int hiringCostMultiplier = dialogueScore switch
			{
				LastDialogueHelper.EDialogueScore.Neutral => _hiringAlterationNeutral, 
				LastDialogueHelper.EDialogueScore.Positive => _hiringAlterationPositive, 
				LastDialogueHelper.EDialogueScore.Negative => _hiringAlterationNegative, 
				_ => throw new ArgumentOutOfRangeException("dialogueScore", dialogueScore, null), 
			};
			MonoSingleton<InterimAgency>.Instance.SetHiringCostMultiplier(hiringCostMultiplier);
		}

		private void RewardInterestRate(LastDialogueHelper.EDialogueScore dialogueScore)
		{
			float newInterest = dialogueScore switch
			{
				LastDialogueHelper.EDialogueScore.Neutral => _interestRateNeutral, 
				LastDialogueHelper.EDialogueScore.Positive => _interestRatePositive, 
				LastDialogueHelper.EDialogueScore.Negative => _interestRateNegative, 
				_ => throw new ArgumentOutOfRangeException("dialogueScore", dialogueScore, null), 
			};
			MonoSingleton<FinancialLoaningManager>.Instance.ChangeLoanInterest(newInterest);
		}
	}
}

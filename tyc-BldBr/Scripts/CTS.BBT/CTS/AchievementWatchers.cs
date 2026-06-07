using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.TechTree;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class AchievementWatchers : MonoSingleton<AchievementWatchers>
	{
		[Serializable]
		private struct MachineStructAchievemnt
		{
			public FurnitureSO machine;

			public string succesKey;
		}

		public struct ProgressSaveSucess
		{
			public bool toiledAdd;

			public bool loanTake;

			public int numberOfCustomerInToilet;

			public ESubSpecies observedSpecies;
		}

		[SerializeField]
		private string _firstPanicFinish;

		[SerializeField]
		private string _loanSucces;

		[SerializeField]
		private string _oneYearPassed;

		[SerializeField]
		[Foldout("GameOver")]
		private string _playerSurviveTimer;

		[SerializeField]
		[Foldout("techTree")]
		private string _techTreeFullUnlock;

		[SerializeField]
		[Foldout("Power")]
		private string _killAnotherNPCWithAbyssal;

		[SerializeField]
		[Foldout("Machine")]
		private List<MachineStructAchievemnt> _listMachines;

		[SerializeField]
		[Foldout("Machine")]
		private string _machineKilled;

		[SerializeField]
		[Foldout("Worker")]
		private string _servedDrinkVampireSucces;

		[SerializeField]
		[Foldout("Worker")]
		private List<JunkObjectParameters> _washUrine = new List<JunkObjectParameters>();

		[SerializeField]
		[Foldout("Worker")]
		private string _maxLevelWorker;

		[SerializeField]
		[Foldout("Worker")]
		private string _firedWorker;

		[SerializeField]
		[Foldout("Customer")]
		private string _keyPirateThrowUp;

		[SerializeField]
		[Foldout("Customer")]
		private ESubSpecies _pirateSpecies;

		[SerializeField]
		[Foldout("Level")]
		private List<MapInfoSO> _mapInfoSOs;

		[SerializeField]
		[Foldout("Level")]
		private string _allThreeStarsUnlocked;

		[SerializeField]
		[Foldout("Stats")]
		private string _abyssalKill;

		[SerializeField]
		[Foldout("Stats")]
		private string _secondaryMission;

		[SerializeField]
		[Foldout("Stats")]
		private string _searchPoint;

		[SerializeField]
		[Foldout("Stats")]
		private string _humanMachine;

		[SerializeField]
		[Foldout("Stats")]
		private string _workerHire;

		[SerializeField]
		[Foldout("Stats")]
		private string _fiveStars;

		[SerializeField]
		[Foldout("Stats")]
		private string _wipePee;

		private static bool _toiletAddToTheLevel;

		private static ESubSpecies _observedsSpecies;

		private static bool _loanTake;

		private static int _numberOfCustomerInToilett;

		[SerializeField]
		[Foldout("Toilet in the level")]
		private string _toiletKey;

		[SerializeField]
		[Foldout("Toilet in the level")]
		private MapInfoSO _excludeLevelToilet;

		[SerializeField]
		[Foldout("Loan in the level")]
		private string _loanTakeKey;

		[SerializeField]
		[Foldout("Number of customer toilet")]
		private string _customerInToiletKey;

		[SerializeField]
		[Foldout("Species In The Bar")]
		private ESubSpecies[] _subSpeciesToCheck;

		[SerializeField]
		[Foldout("Species In The Bar")]
		private string _subSpeciesKey;

		private static ESubSpecies ObservedSpecies => _observedsSpecies;

		protected override void SingletonAwake()
		{
			WorkerChoreDrinkDelivery.DrinkDelivered += WorkerChoreDrinkDelivery_DrinkDelivered;
			PanicCounter.PanicActive += PanicCounter_PanicActive;
			PowerInfernalAbyss.KillAnotherNPC += PowerInfernalAbyss_KillAnotherNPC;
			Furniture.FurniturePlaced += Furniture_FurnitureBought;
			MachineBase.VictimHarvested += MachineBase_VictimHarvested;
			WorkerHirePanel.Hiring += WorkerHirePanel_Hiring;
			TechTreePoints.ResearchPointsGained += TechTreePoints_ResearchPointsGained;
			CustomerReviewData.StarsReview += PrestigeCustomerReviews_CustomerReviewed;
			JunkObject.OnJunkDiscarded += JunkObject_OnObjectDiscarded;
			WorkerLevel.MaxLevelReach += WorkerLevel_MaxLevelReach;
			Worker.Fired += Worker_Fired;
			PowerInfernalAbyss.KillSomeone += PowerInfernalAbyss_KillSomeone;
			MachineBase.HumanKill += MachineBase_HumanKill;
			FinancialLoaningManager.OnTakeOutALoan += FinancialLoaningManager_OnTakeOutALoan;
			AutonomousActionVomit.AgentThrowUp += AutonomousActionVomit_AgentThrowUp;
			MapInfoSO.MapWinThreeStars += MapInfoSO_MapWinThreeStars;
			CalendarHandlers.NewYear += CalendarHandlers_NewYear;
			TechTreeVisualManager.UnlockEvent += TechTreeVisualManager_UnlockEvent;
			GameOver.OnPlayerEscape += GameOver_OnPlayerEscape;
			SecondaryQuest.SecondaryQuestSuccess += SecondaryQuest_SecondaryQuestSuccess;
			Agent.EnteringBar += Customer_EnteringBar;
			AgentActionToilet.CustomerIn += AgentActionToilet_CustomerIn;
			AgentActionToilet.CustomerOut += AgentActionToilet_CustomerOut;
			VictoryScreenManager.LevelFinish += VictoryScreenManager_LevelFinish;
		}

		protected override void OnSingletonDestroy()
		{
			CustomerReviewData.StarsReview -= PrestigeCustomerReviews_CustomerReviewed;
			WorkerHirePanel.Hiring -= WorkerHirePanel_Hiring;
			PanicCounter.PanicActive -= PanicCounter_PanicActive;
			WorkerChoreDrinkDelivery.DrinkDelivered -= WorkerChoreDrinkDelivery_DrinkDelivered;
			PowerInfernalAbyss.KillAnotherNPC -= PowerInfernalAbyss_KillAnotherNPC;
			Furniture.FurniturePlaced -= Furniture_FurnitureBought;
			MachineBase.VictimHarvested -= MachineBase_VictimHarvested;
			TechTreePoints.ResearchPointsGained -= TechTreePoints_ResearchPointsGained;
			JunkObject.OnJunkDiscarded -= JunkObject_OnObjectDiscarded;
			WorkerLevel.MaxLevelReach -= WorkerLevel_MaxLevelReach;
			Worker.Fired -= Worker_Fired;
			PowerInfernalAbyss.KillSomeone -= PowerInfernalAbyss_KillSomeone;
			MachineBase.HumanKill -= MachineBase_HumanKill;
			FinancialLoaningManager.OnTakeOutALoan -= FinancialLoaningManager_OnTakeOutALoan;
			AutonomousActionVomit.AgentThrowUp -= AutonomousActionVomit_AgentThrowUp;
			MapInfoSO.MapWinThreeStars -= MapInfoSO_MapWinThreeStars;
			CalendarHandlers.NewYear -= CalendarHandlers_NewYear;
			TechTreeVisualManager.UnlockEvent -= TechTreeVisualManager_UnlockEvent;
			SecondaryQuest.SecondaryQuestSuccess -= SecondaryQuest_SecondaryQuestSuccess;
			Agent.EnteringBar -= Customer_EnteringBar;
			AgentActionToilet.CustomerIn -= AgentActionToilet_CustomerIn;
			AgentActionToilet.CustomerOut -= AgentActionToilet_CustomerOut;
			VictoryScreenManager.LevelFinish -= VictoryScreenManager_LevelFinish;
			_toiletAddToTheLevel = false;
			_observedsSpecies = (ESubSpecies)0;
			_loanTake = false;
			_numberOfCustomerInToilett = 0;
		}

		private void PowerInfernalAbyss_KillSomeone()
		{
			AchievementManager.AddToStats(_abyssalKill, 1);
		}

		private void SecondaryQuest_SecondaryQuestSuccess(SecondaryQuest obj)
		{
			AchievementManager.AddToStats(_secondaryMission, 1);
		}

		private void TechTreePoints_ResearchPointsGained(int obj)
		{
			AchievementManager.AddToStats(_searchPoint, obj);
		}

		private void MachineBase_VictimHarvested(MachineBase arg1, Agent arg2)
		{
			AchievementManager.AddToStats(_humanMachine, 1);
		}

		private void WorkerHirePanel_Hiring(Agent obj)
		{
			AchievementManager.AddToStats(_workerHire, 1);
		}

		private void PrestigeCustomerReviews_CustomerReviewed(int arg2)
		{
			if (arg2 == 5)
			{
				AchievementManager.AddToStats(_fiveStars, 1);
			}
		}

		private void JunkObject_OnObjectDiscarded(JunkObject obj)
		{
			if (_washUrine == null)
			{
				return;
			}
			foreach (JunkObjectParameters item in _washUrine)
			{
				if (item != null && item == obj.Parameters)
				{
					AchievementManager.AddToStats(_wipePee, 1);
					break;
				}
			}
		}

		private void GameOver_OnPlayerEscape()
		{
			UnlockAchivement(_playerSurviveTimer);
		}

		private void PowerInfernalAbyss_KillAnotherNPC()
		{
			UnlockAchivement(_killAnotherNPCWithAbyssal);
		}

		private void WorkerLevel_MaxLevelReach()
		{
			UnlockAchivement(_maxLevelWorker);
		}

		private void MachineBase_HumanKill()
		{
			UnlockAchivement(_machineKilled);
		}

		private void Worker_Fired(Worker obj)
		{
			UnlockAchivement(_firedWorker);
		}

		private void TechTreeVisualManager_UnlockEvent()
		{
			UnlockAchivement(_techTreeFullUnlock);
		}

		private void CalendarHandlers_NewYear()
		{
			UnlockAchivement(_oneYearPassed);
		}

		private void WorkerChoreDrinkDelivery_DrinkDelivered(CustomerOrder obj)
		{
			if (obj.CustomerRef.IsVampire)
			{
				UnlockAchivement(_servedDrinkVampireSucces);
			}
		}

		private void Furniture_FurnitureBought(Furniture obj)
		{
			foreach (MachineStructAchievemnt listMachine in _listMachines)
			{
				if (obj.Parameters == listMachine.machine)
				{
					UnlockAchivement(listMachine.succesKey);
				}
			}
			if (obj.Interactor is Toilet && !_toiletAddToTheLevel)
			{
				_toiletAddToTheLevel = true;
			}
		}

		private void PanicCounter_PanicActive(bool obj)
		{
			if (!obj)
			{
				UnlockAchivement(_firstPanicFinish);
			}
		}

		private void FinancialLoaningManager_OnTakeOutALoan(int obj)
		{
			if (MonoSingleton<FinancialLoaningManager>.Instance.ActiveContracts.Count == MonoSingleton<FinancialLoaningManager>.Instance.FinancialLoanSO.Count)
			{
				UnlockAchivement(_loanSucces);
			}
			if (!_loanTake)
			{
				_loanTake = true;
			}
		}

		private void AutonomousActionVomit_AgentThrowUp(Agent obj)
		{
			if (obj is Customer && ((Customer)obj).SpawnParameters.CharacterData.SubSpecies == _pirateSpecies)
			{
				UnlockAchivement(_keyPirateThrowUp);
			}
		}

		private void MapInfoSO_MapWinThreeStars()
		{
			bool flag = true;
			foreach (MapInfoSO mapInfoSO in _mapInfoSOs)
			{
				if (mapInfoSO.GetScoreInProfile() < 6)
				{
					flag = false;
				}
			}
			if (flag)
			{
				UnlockAchivement(_allThreeStarsUnlocked);
			}
		}

		public static void LoadSavePogress(ProgressSaveSucess progressSaveSucess)
		{
			_toiletAddToTheLevel = progressSaveSucess.toiledAdd;
			_loanTake = progressSaveSucess.loanTake;
			_numberOfCustomerInToilett = progressSaveSucess.numberOfCustomerInToilet;
			_observedsSpecies = progressSaveSucess.observedSpecies;
		}

		public static ProgressSaveSucess SavingSaveProgres()
		{
			return new ProgressSaveSucess
			{
				toiledAdd = _toiletAddToTheLevel,
				loanTake = _loanTake,
				numberOfCustomerInToilet = _numberOfCustomerInToilett,
				observedSpecies = _observedsSpecies
			};
		}

		private void Customer_EnteringBar(Agent obj)
		{
			if (obj is Customer { IsHuman: false } customer)
			{
				ESubSpecies subSpecies = customer.SpawnParameters.CharacterData.SubSpecies;
				_observedsSpecies |= subSpecies;
				if (AreAllSpeciesObserved())
				{
					UnlockAchivement(_subSpeciesKey);
				}
			}
		}

		[Button("Afficher Especes Observees et Manquantes", EButtonEnableMode.Always)]
		private void ShowObservedAndMissingSpecies()
		{
			ESubSpecies eSubSpecies = (ESubSpecies)0;
			ESubSpecies eSubSpecies2 = (ESubSpecies)0;
			ESubSpecies[] subSpeciesToCheck = _subSpeciesToCheck;
			foreach (ESubSpecies eSubSpecies3 in subSpeciesToCheck)
			{
				eSubSpecies |= eSubSpecies3;
			}
			eSubSpecies2 = eSubSpecies & ~_observedsSpecies;
			Debug.Log($" Especes Observees : {_observedsSpecies}");
			Debug.Log($" Esp\ufffdces manquantes: {eSubSpecies2}");
		}

		private bool AreAllSpeciesObserved()
		{
			ESubSpecies eSubSpecies = (ESubSpecies)0;
			ESubSpecies[] subSpeciesToCheck = _subSpeciesToCheck;
			foreach (ESubSpecies eSubSpecies2 in subSpeciesToCheck)
			{
				eSubSpecies |= eSubSpecies2;
			}
			return (_observedsSpecies & eSubSpecies) == eSubSpecies;
		}

		private void AgentActionToilet_CustomerIn()
		{
			_numberOfCustomerInToilett++;
			if (_numberOfCustomerInToilett >= 10)
			{
				UnlockAchivement(_customerInToiletKey);
			}
		}

		private void AgentActionToilet_CustomerOut()
		{
			_numberOfCustomerInToilett--;
			if (_numberOfCustomerInToilett < 0)
			{
				_numberOfCustomerInToilett = 0;
			}
		}

		private void VictoryScreenManager_LevelFinish()
		{
			Debug.Log(_toiletAddToTheLevel + " + " + _loanTake);
			if (!_toiletAddToTheLevel)
			{
				UnlockAchivement(_toiletKey);
			}
			if (!_loanTake && CTSSingleton<GameMode>.Instance.LevelInfo != _excludeLevelToilet)
			{
				UnlockAchivement(_loanTakeKey);
			}
		}

		private void UnlockAchivement(string Key)
		{
			if (Key != string.Empty)
			{
				AchievementManager.UnlockAchievement(Key);
			}
		}
	}
}

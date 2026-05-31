using CTS.BBT;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.TechTree;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest18 : Level02Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _researchPointsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentResearchPointsVariable;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetResearchPointsVariable;

		[SerializeField]
		private int _targetResearchPointsVariableValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private TechTreeTechnologySO _iceCrusherResearch;

		private HaveSpecificFurnitureInteractorGoal<BloodyIceCrusher> _iceCrusherGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _iceCrusherEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _currentIceCrusherVariable;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetIceCrusherVariable;

		[SerializeField]
		private int _targetIceCrusherVariableValue;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		[QuestEntryPopup]
		private int _deliveryTabEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		[QuestEntryPopup]
		private int _granitasDeliveryEntry;

		[SerializeField]
		private StringKey _stockMissionTab;

		[SerializeField]
		private StockItemSO _granitas;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		private StockMissionData _deliveryData;

		[SerializeField]
		[VariablePopup(false)]
		private string _targetGranitasVariable;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_currentResearchPointsVariable, _currentIceCrusherVariable);
		}

		protected override void QuestSetup()
		{
			UnlockingManager.AddUnlockKey(EUnlockKey.KawaiBarPackage);
		}

		protected override void StopObservingObjectives()
		{
			TechTreePoints.OnGainResearchPoints -= OnGainResearchPoints;
			_iceCrusherGoal?.CleanStopObserving();
			MissionBasket.MissionEnded -= OnMissionEnded;
			UI_StockPopulator.PanelOpened -= OnStockUIShown;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetResearchPointsVariable, _targetResearchPointsVariableValue);
			if (base.QuestChain.MissionBasket.CurrentMission != _deliveryData)
			{
				base.QuestChain.MissionBasket.SetMission(_deliveryData);
			}
			DialogueLua.SetVariable(_targetGranitasVariable, base.QuestChain.MissionBasket.CurrentMissionStatus[_granitas].RequiredCount);
			TechTreePoints.OnGainResearchPoints += OnGainResearchPoints;
			OnGainResearchPoints();
			if (TechTreeManager.GetTechnologyResearchLevel(_iceCrusherResearch) != ETechTreeTechnologyLevel.Level0)
			{
				TechTreePoints.OnGainResearchPoints -= OnGainResearchPoints;
				QuestEntrySuccess(_researchPointsEntry);
			}
			else
			{
				HighlightButton.Highlight(BBTUI.Instance.ButtonID_TechTree);
			}
			DialogueLua.SetVariable(_targetIceCrusherVariable, _targetIceCrusherVariableValue);
			_iceCrusherGoal = new HaveSpecificFurnitureInteractorGoal<BloodyIceCrusher>(this, _iceCrusherEntry, _currentIceCrusherVariable, _targetIceCrusherVariable);
			_iceCrusherGoal?.StartObserving();
			MissionBasket.MissionEnded += OnMissionEnded;
			UI_StockPopulator.PanelOpened += OnStockUIShown;
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists() && QuestLog.GetQuestEntryState(_questName, _iceCrusherEntry) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<BloodyIceCrusher>())
			{
				QuestEntryCancelSuccess(_iceCrusherEntry);
			}
		}

		private void OnStockUIShown(StringKey key)
		{
			if (key.IsValid() && key == _stockMissionTab)
			{
				UI_StockPopulator.PanelOpened -= OnStockUIShown;
				QuestEntrySuccess(_deliveryTabEntry);
			}
		}

		private void OnMissionEnded(MissionBasket basket, MissionBasket.MissionResult result)
		{
			if (!(basket != base.QuestChain.MissionBasket) && result.Result == MissionBasket.EMissionResult.Full)
			{
				MissionBasket.MissionEnded -= OnMissionEnded;
				QuestEntrySuccess(_granitasDeliveryEntry);
			}
		}

		private void OnGainResearchPoints()
		{
			if (SetQuestEntryVariable(_researchPointsEntry, _currentResearchPointsVariable, TechTreeManager.GetCurrentPoints, _targetResearchPointsVariable))
			{
				TechTreePoints.OnGainResearchPoints -= OnGainResearchPoints;
				QuestEntrySuccess(_researchPointsEntry);
			}
		}
	}
}

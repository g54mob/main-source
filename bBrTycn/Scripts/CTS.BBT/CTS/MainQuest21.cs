using CTS.BBT;
using CTS.BBT.AI;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.TechTree;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest21 : Level02Quest
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
		[QuestEntryPopup]
		private int _arcadeTrapResearchEntry;

		[SerializeField]
		private TechTreeTechnologySO _arcadeTrapResearch;

		[SerializeField]
		[QuestEntryPopup]
		private int _arcadeTrapBuyEntry;

		[SerializeField]
		[QuestEntryPopup]
		private int _prisonerTrappedEntry;

		[SerializeField]
		private LocalizedString _bark01;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_currentResearchPointsVariable);
		}

		protected override void StopObservingObjectives()
		{
			TechTreePoints.OnGainResearchPoints -= OnGainResearchPoints;
			TechTreeManager.OnTechnologyResearched -= OnTechnologyResearched;
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
			BloodyArcade.HumanCaptured -= OnCapturedHuman;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_targetResearchPointsVariable, _targetResearchPointsVariableValue);
			TechTreePoints.OnGainResearchPoints += OnGainResearchPoints;
			OnGainResearchPoints();
			TechTreeManager.OnTechnologyResearched += OnTechnologyResearched;
			if (TechTreeManager.GetTechnologyResearchLevel(_arcadeTrapResearch) != ETechTreeTechnologyLevel.Level0)
			{
				OnTechnologyResearched(_arcadeTrapResearch);
			}
			else
			{
				HighlightButton.Highlight(BBTUI.Instance.ButtonID_TechTree);
			}
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<BloodyArcade>())
			{
				QuestEntrySuccess(_arcadeTrapBuyEntry);
			}
			BloodyArcade.HumanCaptured += OnCapturedHuman;
		}

		private void OnCapturedHuman(Agent human)
		{
			BloodyArcade.HumanCaptured -= OnCapturedHuman;
			QuestEntrySuccess(_prisonerTrappedEntry);
			Barks.BarkAgent(human, _bark01);
		}

		private void OnTechnologyResearched(TechTreeTechnologySO tech)
		{
			if (tech == _arcadeTrapResearch)
			{
				TechTreeManager.OnTechnologyResearched -= OnTechnologyResearched;
				TechTreePoints.OnGainResearchPoints -= OnGainResearchPoints;
				QuestEntrySuccess(_researchPointsEntry);
				QuestEntrySuccess(_arcadeTrapResearchEntry);
			}
		}

		private void OnGainResearchPoints()
		{
			if (SetQuestEntryVariable(_researchPointsEntry, _currentResearchPointsVariable, TechTreeManager.GetCurrentPoints, _targetResearchPointsVariable))
			{
				TechTreePoints.OnGainResearchPoints -= OnGainResearchPoints;
				QuestEntrySuccess(_researchPointsEntry);
				DialogueHelper.StartConversation(_feedback01);
				if (IsEntryStateActive(_arcadeTrapResearchEntry))
				{
					HighlightButton.Highlight(BBTUI.Instance.ButtonID_TechTree);
				}
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists() && QuestLog.GetQuestEntryState(_questName, _arcadeTrapBuyEntry) == QuestState.Success && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<BloodyArcade>())
			{
				QuestEntryCancelSuccess(_arcadeTrapBuyEntry);
			}
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (QuestLog.GetQuestEntryState(_questName, _arcadeTrapBuyEntry) == QuestState.Active && furniture.Interactor is BloodyArcade)
			{
				QuestEntrySuccess(_arcadeTrapBuyEntry);
			}
		}
	}
}

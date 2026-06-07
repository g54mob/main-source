using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest35 : Quest
	{
		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		[QuestEntryPopup]
		private int _smokedEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _smokedTargetVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _smokedVariableName;

		[SerializeField]
		private StockItemSO _smokedSO;

		private SubStockMissionGoal _smockedGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		private LocalizedString _bark01;

		private SubStockMissionGoal _bloodGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodTargetVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodVariableName;

		[SerializeField]
		private StockItemSO _bloodSO;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		[QuestEntryPopup]
		private int _granitaEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _granitaTargetVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _granitaVariableName;

		[SerializeField]
		private StockItemSO _granitaSO;

		private SubStockMissionGoal _granitaGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		private LocalizedString _bark03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_smokedVariableName, _bloodVariableName, _granitaVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.SetMission(_stockMissionData);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_smockedGoal?.CleanStopObserving();
			_bloodGoal?.CleanStopObserving();
			_granitaGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_smokedTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.CurrentMissionStatus[_smokedSO].RequiredCount);
			DialogueLua.SetVariable(_bloodTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.CurrentMissionStatus[_bloodSO].RequiredCount);
			DialogueLua.SetVariable(_granitaTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.CurrentMissionStatus[_granitaSO].RequiredCount);
			MissionBasket mainMissionBasket = CTSSingleton<StoreBaskets>.Instance.MainMissionBasket;
			_smockedGoal = new SubStockMissionGoal(this, _smokedEntry, _smokedVariableName, _smokedTargetVariableName, mainMissionBasket, _smokedSO);
			_smockedGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback01);
			});
			_bloodGoal = new SubStockMissionGoal(this, _bloodEntry, _bloodVariableName, _bloodTargetVariableName, mainMissionBasket, _bloodSO);
			_bloodGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback02);
			});
			_granitaGoal = new SubStockMissionGoal(this, _granitaEntry, _granitaVariableName, _granitaTargetVariableName, mainMissionBasket, _granitaSO);
			_granitaGoal?.StartObserving(delegate
			{
				DialogueHelper.StartFeedback(_feedback03);
			});
		}
	}
}

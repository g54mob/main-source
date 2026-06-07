using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest28 : Quest
	{
		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		[QuestEntryPopup]
		private int _bloodEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _bloodTargetVariableName;

		[SerializeField]
		private StockItemSO _bloodSO;

		private SubStockMissionGoal _bloodGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[QuestEntryPopup]
		private int _granitaEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _granitaVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _granitaTargetVariableName;

		[SerializeField]
		private StockItemSO _granitaSO;

		private SubStockMissionGoal _granitaGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		[QuestEntryPopup]
		private int _smokedEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _smokedVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _smokedTargetVariableName;

		[SerializeField]
		private StockItemSO _smokedSO;

		private SubStockMissionGoal _smockedGoal;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_bloodVariableName);
			ResetVariableTo0(_granitaVariableName);
			ResetVariableTo0(_smokedVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.SetMission(_stockMissionData);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			_bloodGoal?.CleanStopObserving();
			_granitaGoal?.CleanStopObserving();
			_smockedGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_bloodTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.CurrentMissionStatus[_bloodSO].RequiredCount);
			DialogueLua.SetVariable(_granitaTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.CurrentMissionStatus[_granitaSO].RequiredCount);
			DialogueLua.SetVariable(_smokedTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.CurrentMissionStatus[_smokedSO].RequiredCount);
			MissionBasket mainMissionBasket = CTSSingleton<StoreBaskets>.Instance.MainMissionBasket;
			_bloodGoal = new SubStockMissionGoal(this, _bloodEntry, _bloodVariableName, _bloodTargetVariableName, mainMissionBasket, _bloodSO);
			_granitaGoal = new SubStockMissionGoal(this, _granitaEntry, _granitaVariableName, _granitaTargetVariableName, mainMissionBasket, _granitaSO);
			_smockedGoal = new SubStockMissionGoal(this, _smokedEntry, _smokedVariableName, _smokedTargetVariableName, mainMissionBasket, _smokedSO);
			_bloodGoal?.StartObserving(OnBloodGoalAchieved);
			_granitaGoal?.StartObserving(OnGranitaGoalAchieved);
			_smockedGoal?.StartObserving(OnSmockedGoalAchieved);
		}

		private void OnBloodGoalAchieved()
		{
			_bloodGoal.Achieved -= OnBloodGoalAchieved;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnGranitaGoalAchieved()
		{
			_granitaGoal.Achieved -= OnGranitaGoalAchieved;
			DialogueHelper.StartConversation(_feedback02);
		}

		private void OnSmockedGoalAchieved()
		{
			_smockedGoal.Achieved -= OnSmockedGoalAchieved;
			DialogueHelper.StartConversation(_feedback03);
		}
	}
}

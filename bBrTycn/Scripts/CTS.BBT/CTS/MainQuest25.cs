using System.Collections;
using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest25 : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue01;

		[SerializeField]
		private RewardData _reward01;

		[SerializeField]
		[QuestEntryPopup]
		private int _missionStockEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[VariablePopup(false)]
		private string _granitaVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _granitaTargetVariableName;

		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		private StockItemSO _granitaSO;

		private SubStockMissionGoal _missionStockGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _humanKillEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _humanTargetVariableName;

		private KillHumanGoal _killHumanGoal;

		private DipCorpsesGoal _dipCorpsesGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _corpseDissolveEntry;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback03;

		[SerializeField]
		[VariablePopup(false)]
		private string _corpseVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _corpseTargetVariableName;

		[SerializeField]
		private StringKey _missionBasketKey;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_granitaVariableName);
			ResetVariableTo0(_humanVariableName);
			ResetVariableTo0(_corpseVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.SetMission(_stockMissionData);
			DialogueLua.SetVariable(_granitaTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket.CurrentMissionStatus[_granitaSO].RequiredCount);
			return DialogueHelper.DialogueCoroutine(_dialogue01, _reward01);
		}

		protected override void StopObservingObjectives()
		{
			_missionStockGoal?.CleanStopObserving();
			_killHumanGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_missionStockGoal = new SubStockMissionGoal(this, _missionStockEntry, _granitaVariableName, _granitaTargetVariableName, CTSSingleton<StoreBaskets>.Instance.MainMissionBasket, _granitaSO);
			_killHumanGoal = new KillHumanGoal(this, _humanKillEntry, _humanVariableName, _humanTargetVariableName);
			_dipCorpsesGoal = new DipCorpsesGoal(this, _corpseDissolveEntry, _corpseVariableName, _corpseTargetVariableName);
			_missionStockGoal?.StartObserving(OnMissionStockAchieved);
			_killHumanGoal?.StartObserving(OnHumanKillAchieved);
			_dipCorpsesGoal?.StartObserving(OnCorpseDissolveAchieved);
		}

		private void OnMissionStockAchieved()
		{
			_missionStockGoal.Achieved -= OnMissionStockAchieved;
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnHumanKillAchieved()
		{
			_killHumanGoal.Achieved -= OnHumanKillAchieved;
			DialogueHelper.StartConversation(_feedback02);
		}

		private void OnCorpseDissolveAchieved()
		{
			DialogueHelper.StartConversation(_feedback03);
		}
	}
}

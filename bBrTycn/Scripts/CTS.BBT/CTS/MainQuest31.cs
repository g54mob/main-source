using System.Collections;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest31 : Quest
	{
		[SerializeField]
		[ConversationPopup(false, false)]
		private string _dialogue01;

		[SerializeField]
		private RewardData _reward01;

		[SerializeField]
		[QuestEntryPopup]
		private int _investigatorsEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _investigatorsVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _investigatorsTargetVariableName;

		[SerializeField]
		private int _investigatorsTargetVariableNameValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		private NoInvestigatorsGoal _investigatorsGoal;

		[SerializeField]
		[QuestEntryPopup]
		private int _moneyEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _moneyVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _moneyTargetVariableName;

		[SerializeField]
		private int _moneyTargetVariableNameValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		private SellDrinksGoal _sellDrinksGoal;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_investigatorsVariableName);
			ResetVariableTo0(_moneyVariableName);
		}

		protected override IEnumerator QuestIntroduction()
		{
			yield return DialogueHelper.DialogueCoroutine(_dialogue01, _reward01);
		}

		protected override void StopObservingObjectives()
		{
			_investigatorsGoal?.CleanStopObserving();
			_sellDrinksGoal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_investigatorsTargetVariableName, _investigatorsTargetVariableNameValue);
			DialogueLua.SetVariable(_moneyTargetVariableName, _moneyTargetVariableNameValue);
			_investigatorsGoal = new NoInvestigatorsGoal(this, _investigatorsEntry, _investigatorsVariableName, _investigatorsTargetVariableName);
			_sellDrinksGoal = new SellDrinksGoal(this, _moneyEntry, _moneyVariableName, _moneyTargetVariableName);
			_investigatorsGoal?.StartObserving(OnInvestigatorsGoalAchieved);
			_sellDrinksGoal?.StartObserving(OnSellDrinksGoalAchieved);
		}

		private void OnInvestigatorsGoalAchieved()
		{
			DialogueHelper.StartConversation(_feedback01);
		}

		private void OnSellDrinksGoalAchieved()
		{
			DialogueHelper.StartConversation(_feedback02);
		}
	}
}

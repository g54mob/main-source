using CTS.BBT;
using CTS.BBT.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class MainQuest12 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _moneyEntry;

		[SerializeField]
		[VariablePopup(false)]
		private string _moneyVariableName;

		[SerializeField]
		[VariablePopup(false)]
		private string _moneyMaxVariableName;

		[SerializeField]
		private int _moneyMaxVariableNameValue;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_moneyVariableName);
		}

		protected override void StopObservingObjectives()
		{
			CustomerOrder.DrinkPayed -= OnCustomerPayedDrink;
		}

		protected override void StartObservingObjectives()
		{
			DialogueLua.SetVariable(_moneyMaxVariableName, _moneyMaxVariableNameValue);
			CustomerOrder.DrinkPayed += OnCustomerPayedDrink;
		}

		private void OnCustomerPayedDrink(DrinkSO arg1, int drinkPrice)
		{
			if (IncrementQuestEntryVariable(_moneyEntry, _moneyVariableName, drinkPrice, _moneyMaxVariableName))
			{
				CustomerOrder.DrinkPayed -= OnCustomerPayedDrink;
				QuestEntrySuccess(_moneyEntry);
			}
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			UnlockingManager.AddUnlockKey(EUnlockKey.BasicBarPackage);
			base.QuestChain.MachinesUILocker.Unlock();
		}

		public override void SuccessConfirmation()
		{
			base.SuccessConfirmation();
			base.QuestChain.MachinesUILocker.Unlock();
		}
	}
}

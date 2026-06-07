using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class MainQuest06 : Level01Quest
	{
		[SerializeField]
		[QuestEntryPopup]
		private int _orderID;

		[SerializeField]
		[QuestEntryPopup]
		private int _makeDrinkID;

		[SerializeField]
		[QuestEntryPopup]
		private int _serviceID;

		[SerializeField]
		private LocalizedString _bark01;

		[SerializeField]
		private LocalizedString _bark02;

		[SerializeField]
		private LocalizedString _bark03;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback01;

		[SerializeField]
		[ConversationPopup(false, false)]
		private string _feedback02;

		protected override IEnumerator QuestIntroduction()
		{
			DialogueHelper.StartConversation(_feedback01);
			yield break;
		}

		protected override void StopObservingObjectives()
		{
			AgentActionTakeOrder.TakingOrder -= OnTakingOrder;
			AgentActionTakeOrder.OrderTaken -= OnOrderTaken;
			WorkerChoreDrinkPreparation.PreparingDrink -= PreparingDrink;
			WorkerChoreDrinkPreparation.DrinkPrepared -= OnDrinkPrepared;
			WorkerChoreDrinkDelivery.DeliveringDrink -= OnDeliveringDrink;
			WorkerChoreDrinkDelivery.DrinkDelivered -= OnDrinkDelivered;
		}

		protected override void StartObservingObjectives()
		{
			AgentActionTakeOrder.TakingOrder += OnTakingOrder;
			AgentActionTakeOrder.OrderTaken += OnOrderTaken;
			WorkerChoreDrinkPreparation.PreparingDrink += PreparingDrink;
			WorkerChoreDrinkPreparation.DrinkPrepared += OnDrinkPrepared;
			WorkerChoreDrinkDelivery.DeliveringDrink += OnDeliveringDrink;
			WorkerChoreDrinkDelivery.DrinkDelivered += OnDrinkDelivered;
		}

		private void OnDrinkDelivered(CustomerOrder order)
		{
			WorkerChoreDrinkDelivery.DrinkDelivered -= OnDrinkDelivered;
			QuestEntrySuccess(_serviceID);
		}

		private void OnDeliveringDrink(CustomerOrder order)
		{
			WorkerChoreDrinkDelivery.DeliveringDrink -= OnDeliveringDrink;
			base.QuestChain.BarkFirstWorker(_bark03.GetLocalizedString(), 2f);
		}

		private void OnDrinkPrepared()
		{
			WorkerChoreDrinkPreparation.DrinkPrepared -= OnDrinkPrepared;
			QuestEntrySuccess(_makeDrinkID);
		}

		private void PreparingDrink()
		{
			WorkerChoreDrinkPreparation.PreparingDrink -= PreparingDrink;
			base.QuestChain.BarkPreviousInhabitant(_bark02.GetLocalizedString(), 2f);
		}

		private void OnOrderTaken(Agent agent)
		{
			AgentActionTakeOrder.OrderTaken -= OnOrderTaken;
			QuestEntrySuccess(_orderID);
		}

		private void OnTakingOrder(Agent agent)
		{
			AgentActionTakeOrder.TakingOrder -= OnTakingOrder;
			base.QuestChain.BarkPreviousInhabitant(_bark01.GetLocalizedString(), 2f);
		}

		protected override void OnQuestSuccess()
		{
			base.OnQuestSuccess();
			DialogueHelper.StartConversation(_feedback02);
		}
	}
}

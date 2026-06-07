using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class DeliverOneTypeSecondaryQuest : SecondaryQuest
	{
		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		private StringKey<MainCharacterData> _deliveryRecipient;

		[SerializeField]
		private StockItemSO _stockItemSO;

		private SubStockMissionGoal _subDelivery1Goal;

		[SerializeField]
		[QuestEntryPopup]
		private int _subDelivery1Entry;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery1Target;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery1;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_subDelivery1);
		}

		public override void OfferQuest()
		{
			CTSSingleton<CharacterDeliveries>.Instance.StartDelivery(CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _deliveryRecipient, _stockMissionData);
			DialogueLua.SetVariable(_subDelivery1Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.CurrentMissionStatus[_stockItemSO].RequiredCount);
			base.OfferQuest();
		}

		public override void QuestRefused()
		{
			CancelMissionBasket();
			base.QuestRefused();
		}

		protected override void StopObservingObjectives()
		{
			_subDelivery1Goal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_subDelivery1Goal = new SubStockMissionGoal(this, _subDelivery1Entry, _subDelivery1, _subDelivery1Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _stockItemSO);
			_subDelivery1Goal?.StartObserving();
		}
	}
}

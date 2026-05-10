using CTS.BBT;
using CTS.Core;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace CTS
{
	public class DeliverFourTypeSecondaryQuest : SecondaryQuest
	{
		[SerializeField]
		private StockMissionData _stockMissionData;

		[SerializeField]
		private StringKey<MainCharacterData> _deliveryRecipient;

		[SerializeField]
		private StockItemSO _stockItem1SO;

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

		[SerializeField]
		private StockItemSO _stockItem2SO;

		private SubStockMissionGoal _subDelivery2Goal;

		[SerializeField]
		[QuestEntryPopup]
		private int _subDelivery2Entry;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery2Target;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery2;

		[SerializeField]
		private StockItemSO _stockItem3SO;

		private SubStockMissionGoal _subDelivery3Goal;

		[SerializeField]
		[QuestEntryPopup]
		private int _subDelivery3Entry;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery3Target;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery3;

		[SerializeField]
		private StockItemSO _stockItem4SO;

		private SubStockMissionGoal _subDelivery4Goal;

		[SerializeField]
		[QuestEntryPopup]
		private int _subDelivery4Entry;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery4Target;

		[SerializeField]
		[VariablePopup(false)]
		private string _subDelivery4;

		protected override void OnResetQuest()
		{
			ResetVariableTo0(_subDelivery1, _subDelivery2, _subDelivery3, _subDelivery4);
		}

		public override void OfferQuest()
		{
			CTSSingleton<CharacterDeliveries>.Instance.StartDelivery(CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _deliveryRecipient, _stockMissionData);
			DialogueLua.SetVariable(_subDelivery1Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.CurrentMissionStatus[_stockItem1SO].RequiredCount);
			DialogueLua.SetVariable(_subDelivery2Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.CurrentMissionStatus[_stockItem2SO].RequiredCount);
			DialogueLua.SetVariable(_subDelivery3Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.CurrentMissionStatus[_stockItem3SO].RequiredCount);
			DialogueLua.SetVariable(_subDelivery4Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket.CurrentMissionStatus[_stockItem4SO].RequiredCount);
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
			_subDelivery2Goal?.CleanStopObserving();
			_subDelivery3Goal?.CleanStopObserving();
			_subDelivery4Goal?.CleanStopObserving();
		}

		protected override void StartObservingObjectives()
		{
			_subDelivery1Goal = new SubStockMissionGoal(this, _subDelivery1Entry, _subDelivery1, _subDelivery1Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _stockItem1SO);
			_subDelivery2Goal = new SubStockMissionGoal(this, _subDelivery2Entry, _subDelivery2, _subDelivery2Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _stockItem2SO);
			_subDelivery3Goal = new SubStockMissionGoal(this, _subDelivery3Entry, _subDelivery3, _subDelivery3Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _stockItem3SO);
			_subDelivery4Goal = new SubStockMissionGoal(this, _subDelivery4Entry, _subDelivery4, _subDelivery4Target, CTSSingleton<StoreBaskets>.Instance.SecondaryMissionBasket, _stockItem4SO);
			_subDelivery1Goal?.StartObserving();
			_subDelivery2Goal?.StartObserving();
			_subDelivery3Goal?.StartObserving();
			_subDelivery4Goal?.StartObserving();
		}
	}
}

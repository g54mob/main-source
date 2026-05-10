using System;
using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	internal sealed class EventsManager : MonoBehaviour
	{
		public static Func<Currencies, int, int> ChangeMoney { get; set; }

		public static event Func<Currencies, int> GetCurrentMoney;

		public static event Action<ContextualActions> OnSelectActor;

		public static event Action<IContextActor> OnRightClickContextActor;

		private void OnEnable()
		{
			Furniture.BuyingFurniture += TriggerChangeMoney;
			Customer.OnSpendMoney += TriggerChangeMoney;
			ContextualActionsInput.OnRightClickContextActor += TriggerRightClickContextActor;
			UI_ConstructionFacture.BuyingConstruction += TriggerChangeMoneyDollars;
		}

		private void OnDisable()
		{
			Furniture.BuyingFurniture -= TriggerChangeMoney;
			Customer.OnSpendMoney -= TriggerChangeMoney;
			ContextualActionsInput.OnRightClickContextActor -= TriggerRightClickContextActor;
			UI_ConstructionFacture.BuyingConstruction -= TriggerChangeMoneyDollars;
		}

		public int TriggerChangeMoneyDollars(int p_valueChange)
		{
			return ChangeMoney(Currencies.Dollars, p_valueChange);
		}

		public int TriggerChangeMoney(Currencies p_currency, int p_valueChange)
		{
			return ChangeMoney(p_currency, p_valueChange);
		}

		public static int TriggerGetCurrentMoney(Currencies p_currency)
		{
			return EventsManager.GetCurrentMoney(p_currency);
		}

		public void TriggerRightClickContextActor(IContextActor p_contextActor)
		{
			EventsManager.OnRightClickContextActor?.Invoke(p_contextActor);
		}
	}
}

using CTS.BBT;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class ActionCreateDrinkInHand : InstantAction
	{
		[SerializeField]
		private DrinkSO _drinkToCreate;

		protected override bool PlayAction(ActionSequence sequence)
		{
			Agent playerAgent = sequence.PlayerAgent;
			if (playerAgent.ObjectHolding.IsHolding<Drink>() || playerAgent.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (playerAgent is Customer customer)
			{
				if (customer.CurrentOrder != null)
				{
					customer.ClearOrder();
				}
				Drink drink = Drink.Create(_drinkToCreate, null);
				drink.gameObject.SetActive(value: true);
				drink.SetFull();
				customer.ObjectHolding.TryGrabObject(drink);
				return true;
			}
			_ = playerAgent is Worker;
			return false;
		}
	}
}

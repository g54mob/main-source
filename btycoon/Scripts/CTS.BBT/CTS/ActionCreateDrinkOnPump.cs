using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionCreateDrinkOnPump : InstantAction, IGive<Drink>
	{
		[SerializeField]
		private StationDrink _pump;

		[SerializeField]
		private DrinkSO _drinkToCreate;

		private Drink _createdDrink;

		protected override bool PlayAction(ActionSequence sequence)
		{
			List<ItemSlot> list = new List<ItemSlot>();
			if (!_pump.TryGetSlots(1, list))
			{
				return false;
			}
			ItemSlot itemSlot = list[0];
			_createdDrink = Drink.Create(_drinkToCreate, null);
			_createdDrink.gameObject.SetActive(value: true);
			_createdDrink.SetFull();
			itemSlot.SetUnused();
			_createdDrink.Place(itemSlot);
			return true;
		}

		public Drink Get()
		{
			return _createdDrink;
		}
	}
}

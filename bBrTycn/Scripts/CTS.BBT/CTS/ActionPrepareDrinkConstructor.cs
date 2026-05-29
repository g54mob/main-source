using CTS.BBT;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class ActionPrepareDrinkConstructor : ActionConstructor<AgentActionDrinkPreparation>, IGive<Drink>
	{
		[SerializeField]
		private StationDrink _station;

		[SerializeField]
		private DrinkSO _drinkData;

		[SerializeField]
		private bool _requireStock;

		protected override AgentActionDrinkPreparation ConstructAction()
		{
			return new AgentActionDrinkPreparation(_station, _drinkData, _requireStock);
		}

		public Drink Get()
		{
			return GetAction().Cast<IGive<Drink>>().Get();
		}
	}
}

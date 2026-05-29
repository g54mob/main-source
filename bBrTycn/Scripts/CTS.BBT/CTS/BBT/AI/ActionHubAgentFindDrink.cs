using System;
using System.Collections.Generic;
using CTS.Core;

namespace CTS.BBT.AI
{
	internal class ActionHubAgentFindDrink : AgentHubAction
	{
		private WorkerActionGetDrinkFromStorage _actionGetDrinkFromStorage;

		private WorkerActionGetDrinkFromPump _actionGetDrinkFromPump;

		private bool _anyCompleted;

		private DrinkSO _bloodData;

		private float _fridgeDistance;

		private float _pumpDistance;

		private readonly List<DrinkSO> _allowedDrinks;

		private StationStock _nearestFridge => _actionGetDrinkFromStorage.Fridge;

		private StationDrink _nearestPump => _actionGetDrinkFromPump.Pump;

		public ActionHubAgentFindDrink(List<DrinkSO> drinkData)
		{
			_allowedDrinks = drinkData;
			_actionGetDrinkFromStorage = new WorkerActionGetDrinkFromStorage(null);
			_actionGetDrinkFromPump = new WorkerActionGetDrinkFromPump(null);
			_actionGetDrinkFromStorage.OnActionComplete += OnAnyCompleted;
			_actionGetDrinkFromPump.OnActionComplete += OnAnyCompleted;
			AddScoredAction(_actionGetDrinkFromStorage, CalculateScoreStorage);
			AddScoredAction(_actionGetDrinkFromPump, CalculateScorePump);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			return _anyCompleted;
		}

		private void SetBloodData()
		{
			_bloodData = null;
			foreach (DrinkSO allowedDrink in _allowedDrinks)
			{
				if (allowedDrink.CanBePrepared())
				{
					_bloodData = allowedDrink;
					break;
				}
			}
			_actionGetDrinkFromPump.DrinkData = _bloodData;
			_actionGetDrinkFromStorage.DrinkData = _bloodData;
		}

		protected override void PreCheck(Agent agent)
		{
			if (agent is Worker worker && worker.RoomAssignations.AssignedRooms.Count > 0 && !worker.AssignationBypassNeeds)
			{
				CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(agent.RoomObject, out var outFurniture, out _fridgeDistance, StationStock.IsFridgeAndInAssignation, worker);
				_actionGetDrinkFromStorage.SetFridge(outFurniture);
				CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(agent.RoomObject, out StationDrink outFurniture2, out _pumpDistance, (Func<StationDrink, Worker, bool>)BBTObjectExtensions.IsInAssignation, worker);
				_actionGetDrinkFromPump.SetPump(outFurniture2);
			}
			else
			{
				CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(agent.RoomObject, out var outFurniture3, out _fridgeDistance, StationStock.IsFridge);
				_actionGetDrinkFromStorage.SetFridge(outFurniture3);
				CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor<StationDrink>(agent.RoomObject, out var outFurniture4, out _pumpDistance);
				_actionGetDrinkFromPump.SetPump(outFurniture4);
			}
			SetBloodData();
		}

		private int CalculateScoreStorage(Agent agent)
		{
			if (agent is Customer)
			{
				return -1;
			}
			if (!_nearestFridge)
			{
				return -1;
			}
			return (int)(100000f - _fridgeDistance);
		}

		private int CalculateScorePump(Agent agent)
		{
			if (agent is Customer)
			{
				return -1;
			}
			if (!_nearestPump)
			{
				return -1;
			}
			return (int)(100000f - _pumpDistance);
		}

		private void OnAnyCompleted(AgentAction action)
		{
			_anyCompleted = true;
			_actionGetDrinkFromPump.OnActionComplete -= OnAnyCompleted;
			_actionGetDrinkFromStorage.OnActionComplete -= OnAnyCompleted;
		}
	}
}

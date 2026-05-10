using System.Collections;
using System.Collections.Generic;
using CTS.Core;

namespace CTS.BBT.AI
{
	internal class WorkerActionGetDrinkFromPump : WorkerAction
	{
		private List<StockStack> _ingredientsList = new List<StockStack>();

		private int _drinkPrice;

		private Drink _drinkItem;

		private StationDrink _pump;

		public DrinkSO DrinkData { get; set; }

		public StationDrink Pump => _pump;

		public WorkerActionGetDrinkFromPump(DrinkSO drinkData, StationDrink pump = null)
		{
			DrinkData = drinkData;
			_pump = pump;
		}

		public void SetPump(StationDrink pump)
		{
			_pump = pump;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!CTSSingleton<LevelParameters>.Instance)
			{
				return false;
			}
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if ((bool)_pump)
			{
				if (!_pump.CanBeUsed(agentRef))
				{
					return false;
				}
			}
			else if (!CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<StationDrink>())
			{
				return false;
			}
			if (base.IsPlaying)
			{
				return true;
			}
			return DrinkData.CanBePrepared();
		}

		public override void OnStart()
		{
			if (!_pump && !CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetInteractor<StationDrink>(out _pump))
			{
				CancelAction("couldn't find a pump, this shouldn't happen", playBlockedAction: true);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			SyncWithFurniture(_pump);
			base.ActionAgent.FurnitureAssignment.StartUsing(_pump);
			yield return MoveToActor(_pump, EInteractionKey.RegularUsage);
			if (_ingredientsList.Count > 0)
			{
				foreach (StockStack ingredients in _ingredientsList)
				{
					Stocks.BarStock.ForceAdd(ingredients.ItemData.StockType, ingredients);
				}
				_ingredientsList.Clear();
			}
			_drinkPrice = DrinkData.GetCurrentPrice();
			if (!DrinkData.TryGetIngredients(_ingredientsList))
			{
				CancelAction("couldn't get ingredients for " + DrinkData.Name, playBlockedAction: true);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			_drinkItem = Drink.Create(DrinkData, null);
			base.ActionAgent.Animator.Events.OnGrab += OnGrab;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GrabObjectLeft);
			StopFurnitureSyncing();
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Drink, 0f);
			_ingredientsList.Clear();
			base.ActionAgent.PayForDrink(_drinkPrice);
			base.ActionAgent.Statistics.AddToStatisticUnitInterval(EAgentStatistics.Hunger, _drinkItem.DrinkData.ThirstPercent);
			_drinkItem.SetEmpty();
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.DropObjectLeft, 0f);
		}

		private void OnGrab()
		{
			base.ActionAgent.Animator.Events.OnGrab -= OnGrab;
			base.ActionAgent.ProceduralAnimator.WeightMultiplier = 1f;
			_drinkItem.gameObject.SetActive(value: true);
			_drinkItem.SetFull();
			base.ActionAgent.ObjectHolding.TryGrabObject(_drinkItem);
		}

		protected override void OnStopped()
		{
			base.ActionAgent.FurnitureAssignment.StopUsing();
			base.ActionAgent.Animator.Events.OnGrab -= OnGrab;
			if ((bool)_drinkItem)
			{
				_drinkItem.Clear();
			}
		}

		public override void OnCancel()
		{
			base.ActionAgent.ProceduralAnimator.WeightMultiplier = 1f;
			foreach (StockStack ingredients in _ingredientsList)
			{
				Stocks.BarStock.ForceAdd(ingredients.ItemData.StockType, ingredients);
			}
		}
	}
}

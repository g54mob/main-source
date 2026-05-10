using System.Collections;
using System.Collections.Generic;
using CTS.Core;

namespace CTS.BBT.AI
{
	internal class WorkerActionGetDrinkFromStorage : WorkerAction
	{
		private List<StockStack> _ingredientsList = new List<StockStack>();

		private int _drinkPrice;

		private Drink _drinkItem;

		private StationStock _fridge;

		public DrinkSO DrinkData { get; set; }

		public StationStock Fridge => _fridge;

		public WorkerActionGetDrinkFromStorage(DrinkSO drinkData, StationStock fridge = null)
		{
			DrinkData = drinkData;
			_fridge = fridge;
		}

		public void SetFridge(StationStock fridge)
		{
			if (!fridge)
			{
				_fridge = null;
			}
			else if (!(fridge.Type != Stocks.VampireStockType))
			{
				_fridge = fridge;
			}
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
			if ((bool)_fridge)
			{
				if (!_fridge.CanBeUsed(agentRef))
				{
					return false;
				}
			}
			else if (!CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable(StationStock.IsFridge))
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
			if (!_fridge && !CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetInteractor(out _fridge, StationStock.IsFridge))
			{
				CancelAction("couldn't find a fridge, this shouldn't happen", playBlockedAction: true);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			SyncWithFurniture(_fridge);
			base.ActionAgent.FurnitureAssignment.StartUsing(_fridge);
			yield return MoveToActor(_fridge, EInteractionKey.RegularUsage);
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
				CancelAction("couldn't find ingredients for " + DrinkData.Name, playBlockedAction: true);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			_drinkItem = Drink.Create(DrinkData, null);
			_ingredientsList.Clear();
			base.ActionAgent.Animator.Events.OnGrab += OnGrab;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GrabObjectLeft);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Drink, 0f);
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
			foreach (StockStack ingredients in _ingredientsList)
			{
				Stocks.BarStock.ForceAdd(ingredients.ItemData.StockType, ingredients);
			}
		}
	}
}

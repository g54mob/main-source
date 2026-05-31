using System.Collections;
using System.Collections.Generic;
using Animancer;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class AgentActionDrinkPreparation : WorkerAction, IGive<Drink>
	{
		private DrinkSO _drinkData;

		private StationDrink _station;

		private readonly bool _requireIngredients;

		private List<AnimKey> _possibleAnimations = new List<AnimKey>();

		private List<StockStack> _ingredientList = new List<StockStack>();

		private List<ItemSlot> _itemSlots = new List<ItemSlot>();

		private Drink _createdDrink;

		public AgentActionDrinkPreparation(StationDrink station, DrinkSO drinkData, bool requireIngredients = true)
		{
			_requireIngredients = requireIngredients;
			_drinkData = drinkData;
			_station = station;
			_possibleAnimations.Add(AgentAnim.MakeDrink);
			_possibleAnimations.Add(AgentAnim.MakeDrink02);
			_possibleAnimations.Add(AgentAnim.MakeDrink03);
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (_drinkData == null)
			{
				return false;
			}
			if (_station == null)
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (!(agentRef is Worker agent))
			{
				return false;
			}
			if (!_station.CanBeUsed(agent))
			{
				return false;
			}
			if (base.IsPlaying)
			{
				return true;
			}
			if (_requireIngredients)
			{
				return _drinkData.CanBePrepared();
			}
			return true;
		}

		public override void OnStart()
		{
			if (!_station.TryGetSlots(1, _itemSlots))
			{
				CancelAction("couldn't get item slot", playBlockedAction: true);
			}
			else
			{
				base.ActionAgent.FurnitureAssignment.StartUsing(_station);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(_station, EInteractionKey.RegularUsage);
			if (!_requireIngredients)
			{
				yield break;
			}
			if (_ingredientList.Count > 0)
			{
				foreach (StockStack ingredient in _ingredientList)
				{
					Stocks.BarStock.ForceAdd(ingredient.ItemData.StockType, ingredient);
				}
				_ingredientList.Clear();
			}
			if (!_drinkData.TryGetIngredients(_ingredientList))
			{
				CancelAction("couldn't get ingredients for " + _drinkData.Name, playBlockedAction: true);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			_station.GetComponent<ObjectGrabData>().GrabWith(base.ActionAgent);
			base.ActionAgent.Tools.OnUseTool(5);
			_createdDrink = Drink.Create(_drinkData, null);
			_createdDrink.gameObject.SetActive(value: true);
			_createdDrink.transform.SetPositionAndRotation(_station.PumpSlot.position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
			_createdDrink.transform.localScale = Vector3.zero;
			_createdDrink.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBack);
			_createdDrink.RoomObject.SetParent(_station.Furniture.RoomObject);
			yield return base.ActionAgent.Animator.PlayPunctual(_possibleAnimations.GetRandom(), FadeMode.FromStart);
			base.ActionAgent.ProceduralAnimator.DisableGrab();
			base.ActionAgent.Tools.DisableTools();
			_createdDrink.SetFull();
			ItemSlot itemSlot = _itemSlots[0];
			if (!itemSlot.InSlot)
			{
				_createdDrink.transform.SetParent(_station.transform);
				_createdDrink.transform.DOMove(itemSlot.transform.position, 0.15f).SetEase(Ease.InOutSine);
				itemSlot.SetUnused();
				_createdDrink.Place(itemSlot, move: false);
				_ingredientList.Clear();
			}
		}

		protected override void OnStopped()
		{
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}

		public override void OnCancel()
		{
			if (!_requireIngredients)
			{
				return;
			}
			foreach (StockStack ingredient in _ingredientList)
			{
				Stocks.BarStock.ForceAdd(ingredient.ItemData.StockType, ingredient);
			}
		}

		public Drink Get()
		{
			return _createdDrink;
		}
	}
}

using System;
using System.Collections;
using Animancer;
using CTS.Core.Pooling;
using DG.Tweening;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class WorkerChoreDrinkPreparation : WorkerChore
	{
		private readonly WorkerChoreGroupOrderPreparation _groupChore;

		public CustomerOrder Order { get; }

		private GroupOrder GroupOrder => _groupChore.GroupOrder;

		private StationDrink Station => GroupOrder.Station;

		public bool ClearSlotsOnEnd { get; set; }

		public static event Action PreparingDrink;

		public static event Action DrinkPrepared;

		public override string GetDisplayName()
		{
			return "Prepare " + Order.DrinkData.Name;
		}

		public WorkerChoreDrinkPreparation(ChoreCategory p_category, Customer p_customer, WorkerChoreGroupOrderPreparation p_groupChore)
			: base(p_category)
		{
			Order = p_customer.CurrentOrder;
			_groupChore = p_groupChore;
			base.VisibleInContextualMenu = false;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!Station || !Station.CanBeUsed(p_agentRef))
			{
				return false;
			}
			if (!base.IsPlaying)
			{
				return Order.DrinkData.CanBePrepared();
			}
			return true;
		}

		public override void OnStart()
		{
			SyncWithFurniture(GroupOrder.Station);
			base.ActionAgent.FurnitureAssignment.StartUsing(GroupOrder.Station);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(Station, EInteractionKey.RegularUsage);
		}

		public override IEnumerator ActionRoutine()
		{
			WorkerChoreDrinkPreparation.PreparingDrink?.Invoke();
			Station.GetComponent<ObjectGrabData>().GrabWith(base.ActionAgent);
			float speedMultiplier = base.ActionAgent.GetSpeedMultiplier();
			base.ActionAgent.Animator.Speed = speedMultiplier;
			base.ActionAgent.Tools.OnUseTool(5);
			Drink newDrink = Drink.Create(Order.DrinkData, Order);
			newDrink.gameObject.SetActive(value: true);
			newDrink.transform.SetPositionAndRotation(Station.PumpSlot.position, Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 360f), 0f));
			newDrink.transform.localScale = Vector3.zero;
			newDrink.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBack);
			newDrink.RoomObject.SetParent(Station.Furniture.RoomObject);
			Order.PreparedDrink = new PooledRef<Drink>(newDrink);
			float num = 0f;
			int num2 = 0;
			foreach (StockStack ingredient in Order.IngredientList)
			{
				num2 += ingredient.StackCount;
				num += ingredient.Quality * (float)ingredient.StackCount;
			}
			num = ((num2 != 0) ? (num / (float)num2) : 5f);
			newDrink.Quality = Mathf.RoundToInt(num);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.MakeDrink, FadeMode.FromStart);
			if (newDrink.Order.CustomerRef.CurrentOrder == newDrink.Order)
			{
				newDrink.SetFull();
				MoveToSlot();
				WorkerChoreDrinkPreparation.DrinkPrepared?.Invoke();
				Order.SetPrepared();
			}
			else
			{
				MoveToSlot();
				newDrink.CreateClearingChore();
			}
			_groupChore.RemoveOrder(this);
			if (ClearSlotsOnEnd)
			{
				_groupChore.ClearUnusedSlots();
			}
			base.ActionAgent.ProceduralAnimator.DisableGrab();
			base.ActionAgent.Tools.DisableTools();
			void MoveToSlot()
			{
				ItemSlot itemSlot = null;
				foreach (ItemSlot stationSlot in _groupChore.StationSlots)
				{
					if (!stationSlot.InSlot)
					{
						itemSlot = stationSlot;
						break;
					}
				}
				_ = (bool)itemSlot;
				newDrink.transform.SetParent(Station.transform);
				newDrink.transform.DOMove(itemSlot.transform.position, 0.15f).SetEase(Ease.InOutSine);
				itemSlot.SetUnused();
				newDrink.Place(itemSlot, move: false);
			}
		}

		protected override void OnDestroy()
		{
			GroupOrder.RemoveOrder(Order);
			_groupChore.RemoveOrder(this);
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Animator.Speed = 1f;
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}

		public override void OnCancel()
		{
			if (Order.PreparedDrink.TryGetValue(out var outValue))
			{
				outValue.Clear();
			}
			base.ActionAgent.ProceduralAnimator.DisableGrab();
			base.ActionAgent.Tools.DisableTools();
			if (!base.Destroyed)
			{
				_groupChore.CancelAction("Cancelled from drink cancelled");
			}
		}
	}
}

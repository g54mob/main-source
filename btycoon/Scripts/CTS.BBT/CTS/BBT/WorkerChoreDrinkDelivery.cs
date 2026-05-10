using System;
using System.Collections;
using Animancer;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;

namespace CTS.BBT
{
	public sealed class WorkerChoreDrinkDelivery : WorkerChore
	{
		private readonly CustomerOrder _order;

		private readonly WorkerChorePlateDelivery _groupChore;

		private static readonly StringKey _satisfactionPointCorrect = "DeliverOrderCorrect";

		private static readonly StringKey _satisfactionPointWrong = "DeliverOrderWrong";

		private Addressable<PrestigeUIStatsSO> _humanDrinkDeliveredStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/HumansServed.asset");

		private Addressable<PrestigeUIStatsSO> _vampireDrinkDeliveredStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/VampiresServed.asset");

		public Drink Drink => _order.PreparedDrink;

		public ItemSlot ItemSlot { get; }

		public static event Action<CustomerOrder> DeliveringDrink;

		public static event Action<CustomerOrder> DrinkDelivered;

		public static event Action<SatisfactionEvent> SatisfactionTriggered;

		public WorkerChoreDrinkDelivery(ChoreCategory p_category, CustomerOrder p_customerOrder, WorkerChorePlateDelivery p_groupChore)
			: base(p_category)
		{
			_groupChore = p_groupChore;
			_order = p_customerOrder;
			ItemSlot = _order.CustomerRef.AssignedSeat.ItemSlot;
			base.VisibleInContextualMenu = false;
		}

		public override string GetDisplayName()
		{
			return "Deliver " + _order.PreparedDrink.Value.DrinkData.Name;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!p_agentRef.ObjectHolding.IsHolding(_groupChore.Plate))
			{
				return false;
			}
			Table assignedTable = _order.CustomerRef.GroupData.AssignedTable;
			if (!assignedTable || !assignedTable.Furniture.Controller.IsPlaced)
			{
				return false;
			}
			return p_agentRef.ObjectHolding.GetHeldObject<OrderPlate>().Contains(Drink);
		}

		public override void OnStart()
		{
			SyncWithFurniture(_order.CustomerRef.GroupData.AssignedTable);
		}

		public override IEnumerator WaitForRoutine()
		{
			WorkerChoreDrinkDelivery.DeliveringDrink?.Invoke(_order);
			PathingTracker tracker;
			yield return MoveToTransform(ItemSlot.transform, out tracker, AgentPath.EDestinationType.LookAtDistance);
		}

		public override IEnumerator ActionRoutine()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.DropObjectRight, FadeMode.FromStart);
			WorkerChoreDrinkDelivery.DrinkDelivered?.Invoke(_order);
			if (_order.CustomerRef.IsHuman)
			{
				_humanDrinkDeliveredStat.Value?.AddToCurrentValue(1);
			}
			else
			{
				_vampireDrinkDeliveredStat.Value?.AddToCurrentValue(1);
			}
		}

		public override void OnComplete()
		{
			base.OnComplete();
			_groupChore.RemoveChore(this);
			_order.Status = CustomerOrder.EStatus.Delivered;
			if (!_order.IsDestroyed && _order.PreparedDrink.TryGetValue(out var outValue))
			{
				_groupChore.Plate.RemoveDrink(outValue);
				if ((bool)ItemSlot.InSlot)
				{
					ItemSlot.InSlot.Clear();
				}
				ItemSlot.SetUnused();
				outValue.Place(ItemSlot);
				if (_order.Satisfaction == EOrderResult.Good)
				{
					_order.CustomerRef.Satisfaction.AddFlatValue(_satisfactionPointCorrect);
					WorkerChoreDrinkDelivery.SatisfactionTriggered?.Invoke(new SatisfactionEvent(_order.CustomerRef, isGood: true));
				}
				else if (_order.Satisfaction == EOrderResult.Bad)
				{
					_order.CustomerRef.Satisfaction.AddFlatValue(_satisfactionPointWrong);
					WorkerChoreDrinkDelivery.SatisfactionTriggered?.Invoke(new SatisfactionEvent(_order.CustomerRef, isGood: false));
				}
				_order.Pay();
			}
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}

		protected override void OnDestroy()
		{
			_groupChore.RemoveChore(this);
		}
	}
}

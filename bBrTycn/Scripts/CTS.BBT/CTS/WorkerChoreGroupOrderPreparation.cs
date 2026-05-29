using System.Collections;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public sealed class WorkerChoreGroupOrderPreparation : WorkerChore
	{
		public readonly GroupOrder GroupOrder;

		private readonly List<WorkerChoreDrinkPreparation> _orderChores = new List<WorkerChoreDrinkPreparation>();

		private WorkerChoreDrinkPreparation _lastChore;

		public List<ItemSlot> StationSlots => GroupOrder.StationSlots;

		public WorkerChoreGroupOrderPreparation(ChoreCategory category, GroupOrder groupOrder)
			: base(category, groupOrder.AssignedTable.Furniture.RoomObject)
		{
			GroupOrder = groupOrder;
		}

		public override string GetDisplayName()
		{
			return ContextualActionDisplayNames.GetAction(EActionName.DrinkPreparation);
		}

		public void AddChore(WorkerChoreDrinkPreparation p_chore)
		{
			_orderChores.Add(p_chore);
		}

		public void RemoveOrder(WorkerChoreDrinkPreparation p_preparation)
		{
			_orderChores.Remove(p_preparation);
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!CanAnyDrinkBePrepared())
			{
				return false;
			}
			if (!p_agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (p_agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (base.IsPlaying)
			{
				return true;
			}
			if ((bool)GroupOrder.Station)
			{
				return GroupOrder.Station.CanBeUsed(p_agentRef);
			}
			Table assignedTable = GroupOrder.Orders[0].CustomerRef.GroupData.AssignedTable;
			return CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable(StationDrink.HasEnoughSlots, assignedTable.Furniture.RoomObject.CurrentRoom, _orderChores.Count);
		}

		public override void OnStart()
		{
			if (!TryGetStation())
			{
				CancelAction("couldn't find pump", playBlockedAction: true);
			}
			else
			{
				if (_orderChores.Count == 0)
				{
					return;
				}
				foreach (WorkerChoreDrinkPreparation orderChore in _orderChores)
				{
					if (orderChore.Status == EStatus.Idle && orderChore.Order.DrinkData.CanBePrepared())
					{
						_lastChore = orderChore;
						PlayActionAndResumeThis(orderChore);
						return;
					}
				}
				CancelAction("couldn't find a valid order");
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		public override void OnComplete()
		{
			base.OnComplete();
			GroupOrder.CreateDeliveryChores();
			ClearUnusedSlots();
			StationSlots.Clear();
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
			base.OnCancel();
			foreach (CustomerOrder order in GroupOrder.Orders)
			{
				if (order.Chore is WorkerChoreDrinkPreparation)
				{
					order.Chore.CancelAction("Cancelled from main chore");
				}
			}
		}

		protected override void OnDestroy()
		{
			EStatus? eStatus = _lastChore?.Status;
			if (eStatus.HasValue && eStatus == EStatus.InProgress)
			{
				_lastChore.ClearSlotsOnEnd = true;
			}
			else
			{
				ClearUnusedSlots();
			}
		}

		private bool CanAnyDrinkBePrepared()
		{
			if (_orderChores.Count <= 0)
			{
				return true;
			}
			for (int i = 0; i < _orderChores.Count; i++)
			{
				if (_orderChores[i].Order.Status > CustomerOrder.EStatus.Ordered)
				{
					_orderChores.RemoveAt(i);
					i--;
					continue;
				}
				_ = _orderChores[i];
				_ = _orderChores[i].Order;
				_ = _orderChores[i].Order.DrinkData;
				if (_orderChores[i].Order.DrinkData.CanBePrepared())
				{
					return true;
				}
			}
			return false;
		}

		private bool TryGetStation()
		{
			if ((bool)GroupOrder.Station)
			{
				return GroupOrder.Station.CanBeUsed(base.ActionAgent);
			}
			Table assignedTable = GroupOrder.Orders[0].CustomerRef.GroupData.AssignedTable;
			if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(assignedTable.Furniture.RoomObject, out var outFurniture, out var _, StationDrink.HasEnoughSlots, assignedTable.Furniture.RoomObject.CurrentRoom, _orderChores.Count))
			{
				if (!outFurniture.TryGetSlots(_orderChores.Count, GroupOrder.StationSlots))
				{
					return false;
				}
				GroupOrder.Station = outFurniture;
				return true;
			}
			return false;
		}

		public void ClearUnusedSlots()
		{
			for (int num = StationSlots.Count - 1; num >= 0; num--)
			{
				if (!StationSlots[num].InSlot)
				{
					StationSlots[num].SetUnused();
					StationSlots.RemoveAt(num);
				}
			}
		}
	}
}

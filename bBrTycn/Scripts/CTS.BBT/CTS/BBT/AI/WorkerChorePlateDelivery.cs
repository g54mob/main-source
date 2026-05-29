using System.Collections;
using System.Collections.Generic;

namespace CTS.BBT.AI
{
	public sealed class WorkerChorePlateDelivery : WorkerChore
	{
		public readonly GroupOrder GroupOrder;

		private readonly List<WorkerChoreDrinkDelivery> _orderChores = new List<WorkerChoreDrinkDelivery>();

		public OrderPlate Plate => GroupOrder.Plate;

		public WorkerChorePlateDelivery(ChoreCategory category, GroupOrder groupOrder)
			: base(category, groupOrder.AssignedTable.Furniture.RoomObject)
		{
			GroupOrder = groupOrder;
			Plate.Order = groupOrder;
		}

		public override string GetDisplayName()
		{
			return ContextualActionDisplayNames.GetAction(EActionName.DrinkServed);
		}

		public void AddChore(WorkerChoreDrinkDelivery p_chore)
		{
			_orderChores.Add(p_chore);
		}

		public void RemoveChore(WorkerChoreDrinkDelivery p_chore)
		{
			_orderChores.Remove(p_chore);
			if (_orderChores.Count <= 0)
			{
				DestroyChore();
			}
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (Plate.IsHeld)
			{
				return p_agentRef.ObjectHolding.IsHolding(Plate);
			}
			if (p_agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			return p_agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override void OnStart()
		{
			if (GroupOrder.Destroyed || _orderChores.Count == 0)
			{
				return;
			}
			if ((bool)Plate && !Plate.IsHeld && Plate.isActiveAndEnabled)
			{
				PlayActionAndResumeThis(new AgentActionPickUpItem(Plate));
				return;
			}
			foreach (WorkerChoreDrinkDelivery orderChore in _orderChores)
			{
				if (!Plate.Contains(orderChore.Drink))
				{
					PlayActionAndResumeThis(new WorkerActionPutDrinkOnPlate(orderChore.Drink, Plate));
					return;
				}
			}
			foreach (WorkerChoreDrinkDelivery orderChore2 in _orderChores)
			{
				if (orderChore2.Status == EStatus.Idle)
				{
					PlayActionAndResumeThis(orderChore2);
					return;
				}
			}
			CancelAction("Didn't find an order to do");
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnStopped()
		{
		}
	}
}

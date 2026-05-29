using System.Collections;
using CTS.Core;

namespace CTS.BBT.AI
{
	public class AgentActionClearDrink : AgentAction<Agent>
	{
		private Table _table;

		public override bool CanBePerformed(Agent agentRef)
		{
			return agentRef.ObjectHolding.IsHolding<Drink>();
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			if (!(base.ActionAgent is Worker) && base.ActionAgent is Customer customer)
			{
				float outDistance;
				if ((bool)customer.AssignedSeat)
				{
					_table = customer.GroupData.AssignedTable;
				}
				else if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor<Table>(base.ActionAgent.RoomObject, out _table, out outDistance))
				{
					yield return MoveToLookAt(_table.transform, 0.2f, 1.5f);
				}
			}
		}

		public override IEnumerator ActionRoutine()
		{
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.DropObjectLeft, 0f);
			Drink heldObject = base.ActionAgent.ObjectHolding.GetHeldObject<Drink>();
			if (!(heldObject == null))
			{
				base.ActionAgent.ObjectHolding.DropObject();
				heldObject.Clear();
				base.ActionAgent.ProceduralAnimator.DisableGrab();
				if ((bool)_table)
				{
					_table.Cleanable.AddFilth();
				}
			}
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}

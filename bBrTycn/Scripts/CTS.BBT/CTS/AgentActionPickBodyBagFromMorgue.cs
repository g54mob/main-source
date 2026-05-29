using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS
{
	public class AgentActionPickBodyBagFromMorgue : AgentAction<Agent>
	{
		public DeadBodyData BodyData { get; set; }

		public StationMorgue Morgue { get; set; }

		public event Action<BodyBag> BodyBagCreated;

		public AgentActionPickBodyBagFromMorgue(DeadBodyData bodyData, StationMorgue morgue)
		{
			BodyData = bodyData;
			Morgue = morgue;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (BodyData.Identifier == default(Guid))
			{
				return false;
			}
			if (Morgue == null)
			{
				return false;
			}
			if (!Morgue.CanBeUsed(agentRef))
			{
				return false;
			}
			if (!BodyData.IsInMorgue(Morgue))
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			return agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override void OnStart()
		{
			SyncWithFurniture(Morgue);
			base.ActionAgent.FurnitureAssignment.StartUsing(Morgue);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(Morgue, EInteractionKey.RegularUsage);
		}

		public override IEnumerator ActionRoutine()
		{
			if (Morgue.RemoveBodyBag(BodyData, out var bag))
			{
				this.BodyBagCreated?.Invoke(bag);
				base.ActionAgent.ObjectHolding.TryGrabObject(bag);
			}
			yield break;
		}

		protected override void OnStopped()
		{
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}

		public override void OnCancel()
		{
		}
	}
}

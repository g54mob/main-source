using System;
using System.Collections;
using CTS.Core.Pooling;

namespace CTS.BBT.AI
{
	internal sealed class WorkerActionMorgueBodyDrop : WorkerAction
	{
		private MorgueAnims _morgueAnimator;

		private BodyBag _bodyBag;

		public StationMorgue Morgue { get; set; }

		public static event Action<Worker> BodyDroppedInMorgue;

		internal WorkerActionMorgueBodyDrop(StationMorgue Morgue)
		{
			this.Morgue = Morgue;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!(p_agentRef is Worker worker))
			{
				return false;
			}
			if (!worker.IsEngaged)
			{
				return false;
			}
			if (Morgue.IsFull)
			{
				return false;
			}
			if (!Morgue)
			{
				return false;
			}
			return worker.ObjectHolding.IsHolding<BodyBag>();
		}

		public override void OnStart()
		{
		}

		public override IEnumerator WaitForRoutine()
		{
			SyncWithFurniture(Morgue);
			base.ActionAgent.FurnitureAssignment.StartUsing(Morgue);
			yield return MoveToActor(Morgue, EInteractionKey.RegularUsage, BodyBag.GetAgentQueryFilter());
		}

		public override IEnumerator ActionRoutine()
		{
			_morgueAnimator = Morgue.GetComponent<MorgueAnims>();
			_morgueAnimator.OpenOrCloseMorgue(value: true);
			_bodyBag = base.ActionAgent.ObjectHolding.GetHeldObject<BodyBag>();
			base.ActionAgent.ObjectHolding.DropObject();
			_bodyBag.transform.position = base.ActionAgent.transform.position;
			_bodyBag.AnimDrop(BodyBag.EBodyBagAnim.DropMorgue);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.DropBodyMorgue);
			Morgue.AddBodyBag(_bodyBag.BodyData);
			_morgueAnimator.OpenOrCloseMorgue(value: false);
			Pooler.Push(_bodyBag);
			WorkerActionMorgueBodyDrop.BodyDroppedInMorgue?.Invoke(base.ActionAgent);
		}

		protected override void OnStopped()
		{
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}

		public override void OnCancel()
		{
			Pooler.Push(_bodyBag);
			_morgueAnimator.OpenOrCloseMorgue(value: false);
		}
	}
}

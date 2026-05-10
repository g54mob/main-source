using System.Collections;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core.Pooling;

namespace CTS
{
	internal class AgentActionPickUpItem : AgentAction<Agent>
	{
		private MoveTarget _moveTarget;

		public PooledRef<Item> Item { get; set; }

		public AgentActionPickUpItem(Item p_item)
		{
			if ((bool)p_item)
			{
				Item = new PooledRef<Item>(p_item);
			}
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!Item.TryGetValue(out var outValue))
			{
				return false;
			}
			if (!outValue.gameObject.activeInHierarchy)
			{
				return false;
			}
			if (outValue.IsHeld)
			{
				return false;
			}
			if ((object)outValue.GrabbingAgent != null && outValue.GrabbingAgent != p_agentRef)
			{
				return false;
			}
			return !p_agentRef.ObjectHolding.IsCurrentlyHolding;
		}

		public override void OnStart()
		{
			if (!Item.TryGetValue(out var outValue))
			{
				CancelAction("Item was destroyed", playBlockedAction: true);
				return;
			}
			SyncWithItem(outValue);
			if (!outValue.ContextActorData.TryGetInteractionTarget(EInteractionKey.PickUp, base.ActionAgent.transform.position, out _moveTarget))
			{
				CancelAction("");
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			if (!base.ActionAgent.Movement.CheckDestination(_moveTarget))
			{
				yield return MoveToTarget(_moveTarget);
			}
		}

		public override IEnumerator ActionRoutine()
		{
			Item.Value.GrabbingAgent = base.ActionAgent;
			base.ActionAgent.Animator.Events.OnGrab += OnGrab;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.GrabObjectLeft);
		}

		private void OnGrab()
		{
			if ((bool)base.ActionAgent && Item.TryGetValue(out var outValue))
			{
				base.ActionAgent.Animator.Events.OnGrab -= OnGrab;
				if (!outValue.IsHeld || !(outValue.CurrentHolder != base.ActionAgent))
				{
					base.ActionAgent.ProceduralAnimator.WeightMultiplier = 1f;
					base.ActionAgent.ObjectHolding.TryGrabObject(outValue);
				}
			}
		}

		protected override void OnStopped()
		{
			if (Item.TryGetValue(out var outValue) && outValue.GrabbingAgent == base.ActionAgent)
			{
				outValue.GrabbingAgent = null;
			}
			base.ActionAgent.Animator.Events.OnGrab -= OnGrab;
		}

		public override void OnCancel()
		{
		}
	}
}

using System;
using System.Collections;
using CTS.AI;
using CTS.Core;

namespace CTS.BBT.AI
{
	internal sealed class WorkerActionWipeMemory : WorkerAction
	{
		private readonly Customer _human;

		private MoveTarget _moveTarget;

		private CustomerActionGetMemoryWiped _customerAction;

		private LockToggle _customerBusyToggle = new LockToggle();

		public static event Action<Worker, Customer> WipingMemory;

		public WorkerActionWipeMemory(Customer p_customer)
		{
			_human = p_customer;
		}

		public override bool CanBePerformed(Agent p_agentRef)
		{
			if (!_human.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (_human.Tags.HasTag(EAgentTag.Hunter))
			{
				return false;
			}
			if (!(p_agentRef is Worker worker))
			{
				return false;
			}
			if (_human.IsVampire)
			{
				return false;
			}
			if (!worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.ClearingMemory))
			{
				return false;
			}
			if (worker.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (!worker.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			return !_human.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious, ContextualStateDead>();
		}

		public override void OnStart()
		{
			if (!_human.ContextActorData.TryGetInteractionTarget(EInteractionKey.PickUp, base.ActionAgent.transform.position, out _moveTarget))
			{
				CancelAction("couldn't get pickup point on human", playBlockedAction: true);
				return;
			}
			_customerBusyToggle.Lock();
			_customerBusyToggle.Clear();
			_customerBusyToggle.Add(_human.Business);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToLookAt(_moveTarget.transform, 0.2f, 4f);
			SyncAction(_human, new CustomerActionGetMemoryWiped(base.ActionAgent), Priority);
			base.SyncedAction?.SetWaitForCompletion(value: false);
			if (base.SyncedAction == null)
			{
				CancelAction("synced action is null");
			}
		}

		public override IEnumerator ActionRoutine()
		{
			WorkerActionWipeMemory.WipingMemory?.Invoke(base.ActionAgent, _human);
			base.ActionAgent.Animator.Events.TriggerVFX(VFXList.MemoryWipeEyes);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.MemoryWipe);
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			_customerBusyToggle.Remove(_human.Business);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}

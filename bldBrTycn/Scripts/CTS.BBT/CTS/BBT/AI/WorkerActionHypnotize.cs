using System;
using System.Collections;
using Animancer;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class WorkerActionHypnotize : WorkerAction
	{
		private SoftReference<Customer> _human;

		private CustomerActionGetHypnotized _customerAction;

		private LockToggle _customerBusyToggle = new LockToggle();

		public Customer Human
		{
			get
			{
				return _human.Get();
			}
			set
			{
				Customer value2 = _human.Value;
				if ((object)value2 != value)
				{
					if ((bool)value2)
					{
						_customerBusyToggle.Remove(value2.Business);
					}
					_human = SoftReference.Create(value);
				}
			}
		}

		public static event Action<Agent> Hypnotizing;

		public WorkerActionHypnotize(SoftReference<Customer> customer)
		{
			_human = customer;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			Customer human = Human;
			if (!human)
			{
				return false;
			}
			if (!human.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if ((bool)human.ControllingVampire)
			{
				return false;
			}
			if (!(agentRef is Worker worker))
			{
				return false;
			}
			if (!worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Hypnosis))
			{
				return false;
			}
			if (human.IsVampire)
			{
				return false;
			}
			if (human == worker.ControlledHuman)
			{
				return false;
			}
			if (!worker.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (worker.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (human.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>())
			{
				return !human.Tags.HasTag(EAgentTag.Restrained);
			}
			return false;
		}

		public override void OnStart()
		{
			if (!Human.ContextActorData.TryGetInteractionTarget(EInteractionKey.RegularUsage, base.ActionAgent.transform.position, out var _))
			{
				CancelAction("couldn't find regular usagepoint on human", playBlockedAction: true);
			}
			_customerBusyToggle.Lock();
			_customerBusyToggle.Clear();
			_customerBusyToggle.Add(Human.Business);
			if (_customerAction == null)
			{
				_customerAction = new CustomerActionGetHypnotized(base.ActionAgent);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToLookAt(Human.transform, 0.2f, 3f);
			SyncAction(Human, _customerAction, Priority);
			base.SyncedAction.SetWaitForCompletion(value: false);
			yield return MoveToAgent(Human, 0.2f, 2f, _customerAction);
		}

		private void OnCustomerActionCancelled(AgentAction action)
		{
			_customerAction.OnActionCancelled -= OnCustomerActionCancelled;
			CancelAction("customer action got cancelled");
		}

		public override IEnumerator ActionRoutine()
		{
			Customer human = Human;
			base.ActionAgent.SetControlledHuman(null);
			human.ContextualFSM.SetStateNormal();
			base.ActionAgent.ActionPlayer.StartCoroutine(SetControlledHuman());
			base.ActionAgent.Animator.Events.TriggerVFX(VFXList.HypnosisEyes);
			base.ActionAgent.SkeletonData.TryGetBone(EBone.Eyes, out var boneTransform);
			human.SkeletonData.TryGetBone(EBone.Eyes, out var boneTransform2);
			if ((bool)boneTransform && (bool)boneTransform2)
			{
				base.ActionAgent.VFXManager.SetTrailTarget(VFXList.HypnosisTether, boneTransform2);
				base.ActionAgent.VFXManager.Play(VFXList.HypnosisTether, boneTransform);
			}
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Hypnosis, FadeMode.FromStart);
		}

		private IEnumerator SetControlledHuman()
		{
			yield return new WaitForSeconds(1.1f);
			base.ActionAgent.SetControlledHuman(Human);
			WorkerActionHypnotize.Hypnotizing?.Invoke(base.ActionAgent);
		}

		protected override void OnStopped()
		{
			if (_customerAction != null)
			{
				_customerAction.OnActionCancelled -= OnCustomerActionCancelled;
			}
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			if ((bool)Human)
			{
				_customerBusyToggle.Remove(Human.Business);
			}
		}

		public override void OnCancel()
		{
			if ((bool)Human && CustomerManager.HumansList.Contains(Human))
			{
				CustomerManager.PutHumanAtEndOfList(Human);
			}
			base.ActionAgent.VFXManager.Kill(VFXList.HypnosisTether);
		}
	}
}

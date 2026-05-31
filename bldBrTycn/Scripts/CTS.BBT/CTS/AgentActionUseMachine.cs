using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;

namespace CTS
{
	public class AgentActionUseMachine : AgentAction<Agent>
	{
		private SoftReference<MachineBase> _machine;

		private Tween _processTween;

		public MachineBase Machine
		{
			get
			{
				return _machine.Get();
			}
			private set
			{
				_machine = SoftReference.Create(value);
			}
		}

		public AgentActionUseMachine(SoftReference<MachineBase> machine)
		{
			_machine = machine;
		}

		public void SetMachine(MachineBase machine)
		{
			Machine = machine;
		}

		public override void OnStart()
		{
			_processTween = null;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!Machine)
			{
				return false;
			}
			if (!agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			if (!Machine.CanBeUsed(agentRef))
			{
				return false;
			}
			return Machine.UsageCondition(agentRef);
		}

		public override IEnumerator WaitForRoutine()
		{
			SyncWithFurniture(Machine);
			base.ActionAgent.FurnitureAssignment.StartUsing(Machine);
			yield return MoveToActor(Machine, EInteractionKey.RegularUsage);
		}

		public override IEnumerator ActionRoutine()
		{
			if (_machine.Value.Usable && (int)_machine.Value.UseAnimation != (int)AgentAnim.None)
			{
				base.ActionAgent.Animator.StartLoop(_machine.Value.UseAnimation);
			}
			_processTween = Machine.UseMachine(base.ActionAgent);
			yield return _processTween.WaitForCompletion();
			base.ActionAgent.Animator.ReturnToIdle();
		}

		public override void OnCancel()
		{
			if (!base.ActionAgent.Selection.Selectable)
			{
				base.ActionAgent.Selection.Selectable = true;
			}
			_processTween?.Kill();
		}

		protected override void OnStopped()
		{
			_processTween = null;
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}
	}
}

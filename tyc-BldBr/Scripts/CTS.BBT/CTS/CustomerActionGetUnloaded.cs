using System.Collections;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	internal class CustomerActionGetUnloaded : CustomerAction
	{
		private readonly MachineBase _machine;

		private readonly bool _shouldPanic;

		public bool ShouldLeaveAfter;

		public CustomerActionGetUnloaded(MachineBase machine, bool shouldPanic = false)
		{
			_machine = machine;
			_shouldPanic = shouldPanic;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			return _machine.Victim == agentRef;
		}

		public override void OnStart()
		{
			if (base.ActionAgent.ContextualFSM.CurrentStateEquals<ContextualStateUnconscious>())
			{
				base.ActionAgent.ContextualFSM.SetStateNormal();
				PlayActionAndResumeThis(new AgentActionGetUp());
			}
			base.ActionAgent.FurnitureAssignment.StartUsing(_machine);
			SyncWithFurniture(_machine);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			Agent victim = _machine.Victim;
			if (!(_machine is ICustomerCell))
			{
				victim.Tags.AddTag(EAgentTag.WentInMachine);
			}
			Tween tween = _machine.PrepareVictimForUnload();
			if (tween == null)
			{
				Debug.LogError("PrepareVictimForUnload returned null.");
				yield break;
			}
			yield return tween.WaitForCompletion();
			if (victim.IsAlive)
			{
				if (_shouldPanic)
				{
					victim.ContextualFSM.SetStatePanicking();
				}
				else
				{
					victim.ContextualFSM.SetStateNormal();
				}
				if (_machine.MovingToUnload && !_machine.machineWillBeDestroyed)
				{
					yield return MoveToTarget(_machine.UnloadPosition, (int?)(-1));
				}
				if (!_shouldPanic && ShouldLeaveAfter)
				{
					base.ActionAgent.AddTag(BBTAgentTags.NoReview);
					victim.Tags.AddTag(EAgentTag.Angry);
					victim.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Autonomous);
				}
				_machine.FinalizeUnload();
			}
		}

		public override void OnCancel()
		{
			if (_machine.Victim == base.ActionAgent)
			{
				_machine.FinalizeUnload();
			}
		}

		protected override void OnStopped()
		{
			base.ActionAgent.FurnitureAssignment.StopUsing();
			_machine.OnFurnitureUsageEndUnload();
		}
	}
}

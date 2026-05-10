using System;
using System.Collections;
using CTS.AI;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class AgentActionInvestigate : AgentAction<Agent>
	{
		private static readonly float _speedChange = 0.6f;

		private static readonly StringKey _speedKey = "InvestigationSpeed";

		private static StringKey _actionKey = "AI_Action_Alert";

		public IVisible Target { get; set; }

		public static event Action<Agent> Investigating;

		public override bool CanBePerformed(Agent agentRef)
		{
			if (Target == null)
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
			SeatCheck();
			base.ActionAgent.AddTag(BBTAgentTags.Investigating);
			base.ActionAgent.Cooldowns.StopCooldown(BBTAgentTags.Investigate);
			base.ActionAgent.Movement.AddSpeedModifier(_speedKey, _speedChange);
			AgentActionInvestigate.Investigating?.Invoke(base.ActionAgent);
		}

		public override IEnumerator WaitForRoutine()
		{
			base.ActionAgent.Animator.EnableOverride("Investigate");
			PathingTracker path = MoveToLookAt(Target.Transform, 0.25f, 2f, 0.5f, AgentsMover.AllAreas);
			while (!path.IsCompleted)
			{
				yield return null;
				if (Target == null)
				{
					CancelAction("Failed", playBlockedAction: true);
					yield break;
				}
			}
			CustomerActionAlert customerActionAlert = (CustomerActionAlert)base.ActionAgent.ActionList.InstantiateAction(_actionKey);
			customerActionAlert.Target = Target;
			customerActionAlert.BaseDuration = 4f;
			base.ActionAgent.ActionPlayer.ForceAction(customerActionAlert, Priority);
		}

		public override IEnumerator ActionRoutine()
		{
			yield break;
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Animator.DisableOverride("Investigate");
			base.ActionAgent.Movement.RemoveSpeedModifier(_speedKey);
			base.ActionAgent?.RemoveTag(BBTAgentTags.Investigating);
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			base.ActionAgent?.RemoveTag(BBTAgentTags.Investigating);
		}

		public override void OnCancel()
		{
		}
	}
}

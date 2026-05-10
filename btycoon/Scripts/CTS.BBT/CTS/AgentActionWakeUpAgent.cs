using System.Collections;
using CTS.AI;
using CTS.BBT.AI;

namespace CTS
{
	internal class AgentActionWakeUpAgent : AgentAction<Agent>
	{
		private MoveTarget _moveTarget;

		public Agent Target { get; set; }

		public AgentActionWakeUpAgent(Agent agent)
		{
			Target = agent;
		}

		public override void OnStart()
		{
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!Target)
			{
				return false;
			}
			if (!(agentRef is Worker worker))
			{
				return false;
			}
			if (!worker.IsEngaged)
			{
				return false;
			}
			if (!worker.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			return Target.Tags.HasTag(EAgentTag.IsUnconscious);
		}

		public override IEnumerator WaitForRoutine()
		{
			_moveTarget = MoveTarget.CreateNew(Target.transform, AgentPath.EDestinationType.LookAtDistance);
			yield return MoveToTarget(_moveTarget);
		}

		public override IEnumerator ActionRoutine()
		{
			Target.ContextualFSM.SetStateNormal();
			base.ActionAgent.AgentEyesBlinkControler.CurrentEyesState = AgentEyesBlinkControler.e_eyesState.Normal;
			Target.ActionPlayer.ForceAction(new AgentActionGetUp(), EActionPriority.Player);
			yield break;
		}

		public override void OnCancel()
		{
		}

		protected override void OnStopped()
		{
			MoveTarget.Clear(ref _moveTarget);
		}
	}
}

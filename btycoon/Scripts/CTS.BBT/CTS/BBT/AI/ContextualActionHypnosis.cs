using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal sealed class ContextualActionHypnosis : ContextualAction<Customer>
	{
		private WorkerActionHypnotize _action;

		public override void Setup()
		{
			_action = new WorkerActionHypnotize(contextActor);
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			return _action.CanBePerformed(p_worker);
		}

		protected override void Execution(Worker p_worker)
		{
			contextActor.AgentEyesBlinkControler.CurrentEyesState = AgentEyesBlinkControler.e_eyesState.StayOpen;
			p_worker.ActionPlayer.ForceAction(_action, EActionPriority.Player);
			Setup();
		}
	}
}

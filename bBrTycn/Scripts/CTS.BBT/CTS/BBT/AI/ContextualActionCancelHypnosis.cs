using System;

namespace CTS.BBT.AI
{
	[Serializable]
	internal sealed class ContextualActionCancelHypnosis : ContextualAction<Customer>
	{
		public override void Setup()
		{
		}

		public override bool CanBePerformed(Worker p_worker)
		{
			return contextActor.ControllingVampire;
		}

		protected override void Execution(Worker p_worker)
		{
			contextActor.AgentEyesBlinkControler.CurrentEyesState = AgentEyesBlinkControler.e_eyesState.Normal;
			p_worker.SetControlledHuman(null);
		}
	}
}

namespace CTS.BBT.AI
{
	public class ActionHubWitnessDealing : AgentHubAction
	{
		private readonly Customer _witness;

		private readonly WorkerActionWipeMemory _actionWipeMemory;

		internal ActionHubWitnessDealing(Customer witness)
		{
			_witness = witness;
			_actionWipeMemory = new WorkerActionWipeMemory(_witness);
			AddScoredAction(_actionWipeMemory, CalculateMemoryWipe);
		}

		protected override bool ShouldBeConsideredCompleted(Agent agent)
		{
			return !_witness.ContextualFSM.CurrentStateEquals<ContextualStatePanicking>();
		}

		private int CalculateMemoryWipe(Agent agent)
		{
			if (!(agent is Worker worker))
			{
				return -1;
			}
			if (worker.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.ClearingMemory))
			{
				return 100;
			}
			return -1;
		}
	}
}

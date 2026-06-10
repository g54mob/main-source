namespace NSMedieval.GameEventSystem
{
	public static class PhaseBuilder
	{
		public static GameEventLinearPhaseBase LinkPhases(params GameEventLinearPhaseBase[] phases)
		{
			for (int i = 0; i < phases.Length - 1; i++)
			{
				phases[i].LinkNextPhase(phases[i + 1]);
			}
			return phases[0];
		}
	}
}

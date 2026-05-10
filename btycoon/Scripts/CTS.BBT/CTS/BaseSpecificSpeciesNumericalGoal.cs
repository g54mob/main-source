namespace CTS
{
	public abstract class BaseSpecificSpeciesNumericalGoal : QuestNumericGoal
	{
		protected ESpecies TargetSpecies { get; private set; }

		public BaseSpecificSpeciesNumericalGoal(Quest quest, int entryID, string variableName, string targetVariableName, ESpecies targetSpecies)
			: base(quest, entryID, variableName, targetVariableName)
		{
			TargetSpecies = targetSpecies;
		}
	}
}

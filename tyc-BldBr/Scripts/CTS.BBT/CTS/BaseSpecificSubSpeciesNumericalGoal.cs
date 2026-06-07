namespace CTS
{
	public abstract class BaseSpecificSubSpeciesNumericalGoal : QuestNumericGoal
	{
		protected ESubSpecies TargetSubSpecies { get; private set; }

		public BaseSpecificSubSpeciesNumericalGoal(Quest quest, int entryID, string variableName, string targetVariableName, ESubSpecies targetSubSpecies)
			: base(quest, entryID, variableName, targetVariableName)
		{
			TargetSubSpecies = targetSubSpecies;
		}
	}
}

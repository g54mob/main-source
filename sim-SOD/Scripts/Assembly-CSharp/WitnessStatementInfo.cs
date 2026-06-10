public class WitnessStatementInfo
{
	public enum StatementType
	{
		Alibi = 0,
		knowVictim = 1
	}

	public Citizen citizen;

	public StatementType statementType;

	public WitnessStatementInfo(Citizen newCit, StatementType newStatementType)
	{
	}
}

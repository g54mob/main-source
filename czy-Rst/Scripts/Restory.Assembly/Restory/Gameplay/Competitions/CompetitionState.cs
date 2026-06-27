namespace Restory.Gameplay.Competitions
{
	public enum CompetitionState
	{
		None = 0,
		InProgress = 1,
		Failure = 2,
		Success_WorseThanPreviousTime = 3,
		Success_NewBestTime = 4
	}
}

namespace FluentAssertions.CallerIdentification
{
	internal enum ParsingState
	{
		InProgress = 0,
		GoToNextSymbol = 1,
		CandidateFound = 2,
		Completed = 3
	}
}

namespace FluentAssertions.Execution
{
	public class ContinuationOfGiven<TSubject>
	{
		public GivenSelector<TSubject> Then { get; }

		public bool Succeeded => Then.Succeeded;

		internal ContinuationOfGiven(GivenSelector<TSubject> parent)
		{
			Then = parent;
		}
	}
}

namespace FluentAssertions.Equivalency
{
	public interface IAssertionContext<TSubject>
	{
		INode SelectedNode { get; }

		TSubject Subject { get; }

		TSubject Expectation { get; }

		string Because { get; set; }

		object[] BecauseArgs { get; set; }
	}
}

namespace FluentAssertions.Execution
{
	public class Continuation
	{
		public AssertionChain Then { get; }

		internal Continuation(AssertionChain parent)
		{
			Then = parent;
		}
	}
}

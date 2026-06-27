namespace FluentAssertions.Configuration
{
	public class GlobalConfiguration
	{
		private TestFramework? testFramework;

		public GlobalFormattingOptions Formatting { get; set; } = new GlobalFormattingOptions();

		public GlobalEquivalencyOptions Equivalency { get; set; } = new GlobalEquivalencyOptions();

		public TestFramework? TestFramework
		{
			get
			{
				return testFramework;
			}
			set
			{
				testFramework = value;
				AssertionEngine.TestFramework = null;
			}
		}
	}
}

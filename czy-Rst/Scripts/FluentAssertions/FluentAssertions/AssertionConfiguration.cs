using FluentAssertions.Configuration;

namespace FluentAssertions
{
	public static class AssertionConfiguration
	{
		public static GlobalConfiguration Current => AssertionEngine.Configuration;
	}
}

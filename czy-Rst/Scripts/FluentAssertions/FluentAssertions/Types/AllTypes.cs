using System.Reflection;

namespace FluentAssertions.Types
{
	public static class AllTypes
	{
		public static TypeSelector From(Assembly assembly)
		{
			return assembly.Types();
		}
	}
}

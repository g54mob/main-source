using Utf8Json.Internal.Emit;

namespace Utf8Json.Resolvers
{
	public abstract class DynamicCompositeResolver : IJsonFormatterResolver
	{
		private const string ModuleName = "Utf8Json.Resolvers.DynamicCompositeResolver";

		private static readonly DynamicAssembly assembly;

		public readonly IJsonFormatter[] formatters;

		public readonly IJsonFormatterResolver[] resolvers;

		static DynamicCompositeResolver()
		{
		}

		public static IJsonFormatterResolver Create(IJsonFormatter[] formatters, IJsonFormatterResolver[] resolvers)
		{
			return null;
		}

		public DynamicCompositeResolver(IJsonFormatter[] formatters, IJsonFormatterResolver[] resolvers)
		{
		}

		public IJsonFormatter<T> GetFormatterLoop<T>()
		{
			return null;
		}

		public abstract IJsonFormatter<T> GetFormatter<T>();
	}
}

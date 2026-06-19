using MessagePack.Resolvers;
using MessagePack.Unity;

namespace MessagePack.Internal
{
	internal static class StandardResolverHelper
	{
		public static readonly IFormatterResolver[] DefaultResolvers = new IFormatterResolver[6]
		{
			BuiltinResolver.Instance,
			AttributeFormatterResolver.Instance,
			UnityResolver.Instance,
			DynamicEnumResolver.Instance,
			DynamicGenericResolver.Instance,
			DynamicUnionResolver.Instance
		};
	}
}

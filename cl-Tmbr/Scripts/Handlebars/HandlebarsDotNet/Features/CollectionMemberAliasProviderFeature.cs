using HandlebarsDotNet.MemberAliasProvider;

namespace HandlebarsDotNet.Features
{
	internal class CollectionMemberAliasProviderFeature : IFeature
	{
		private static readonly CollectionMemberAliasProvider AliasProvider = new CollectionMemberAliasProvider();

		public void OnCompiling(ICompiledHandlebarsConfiguration configuration)
		{
			configuration.AliasProviders.Add(AliasProvider);
		}

		public void CompilationCompleted()
		{
		}
	}
}

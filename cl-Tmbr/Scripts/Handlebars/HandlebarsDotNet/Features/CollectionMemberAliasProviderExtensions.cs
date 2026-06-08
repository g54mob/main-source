namespace HandlebarsDotNet.Features
{
	public static class CollectionMemberAliasProviderExtensions
	{
		public static HandlebarsConfiguration UseCollectionMemberAliasProvider(this HandlebarsConfiguration configuration)
		{
			configuration.CompileTimeConfiguration.Features.Add(new CollectionMemberAliasProviderFeatureFactory());
			return configuration;
		}
	}
}

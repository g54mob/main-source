namespace HandlebarsDotNet.Features
{
	internal class CollectionMemberAliasProviderFeatureFactory : IFeatureFactory
	{
		public IFeature CreateFeature()
		{
			return new CollectionMemberAliasProviderFeature();
		}
	}
}

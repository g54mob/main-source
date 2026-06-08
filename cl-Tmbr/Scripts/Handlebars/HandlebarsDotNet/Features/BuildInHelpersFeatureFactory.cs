namespace HandlebarsDotNet.Features
{
	internal class BuildInHelpersFeatureFactory : IFeatureFactory
	{
		public IFeature CreateFeature()
		{
			return new BuildInHelpersFeature();
		}
	}
}

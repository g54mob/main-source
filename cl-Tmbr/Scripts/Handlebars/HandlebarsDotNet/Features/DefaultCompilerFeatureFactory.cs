namespace HandlebarsDotNet.Features
{
	internal class DefaultCompilerFeatureFactory : IFeatureFactory
	{
		public IFeature CreateFeature()
		{
			return new DefaultCompilerFeature();
		}
	}
}

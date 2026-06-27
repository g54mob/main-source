namespace Castle.Core.Resource
{
	public class UncResourceFactory : IResourceFactory
	{
		public bool Accept(CustomUri uri)
		{
			return uri.IsUnc;
		}

		public IResource Create(CustomUri uri)
		{
			return new UncResource(uri);
		}

		public IResource Create(CustomUri uri, string basePath)
		{
			return new UncResource(uri, basePath);
		}
	}
}

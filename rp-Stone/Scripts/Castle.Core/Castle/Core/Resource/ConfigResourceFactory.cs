namespace Castle.Core.Resource
{
	public class ConfigResourceFactory : IResourceFactory
	{
		public bool Accept(CustomUri uri)
		{
			return "config".Equals(uri.Scheme);
		}

		public IResource Create(CustomUri uri)
		{
			return new ConfigResource(uri);
		}

		public IResource Create(CustomUri uri, string basePath)
		{
			return Create(uri);
		}
	}
}

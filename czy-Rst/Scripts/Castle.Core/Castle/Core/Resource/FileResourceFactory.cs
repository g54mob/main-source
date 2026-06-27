namespace Castle.Core.Resource
{
	public class FileResourceFactory : IResourceFactory
	{
		public bool Accept(CustomUri uri)
		{
			return "file".Equals(uri.Scheme);
		}

		public IResource Create(CustomUri uri)
		{
			return Create(uri, null);
		}

		public IResource Create(CustomUri uri, string basePath)
		{
			if (basePath != null)
			{
				return new FileResource(uri, basePath);
			}
			return new FileResource(uri);
		}
	}
}

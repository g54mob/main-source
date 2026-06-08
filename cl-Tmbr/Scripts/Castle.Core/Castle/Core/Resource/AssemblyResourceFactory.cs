namespace Castle.Core.Resource
{
	public class AssemblyResourceFactory : IResourceFactory
	{
		public bool Accept(CustomUri uri)
		{
			return "assembly".Equals(uri.Scheme);
		}

		public IResource Create(CustomUri uri)
		{
			return Create(uri, null);
		}

		public IResource Create(CustomUri uri, string basePath)
		{
			if (basePath == null)
			{
				return new AssemblyResource(uri);
			}
			return new AssemblyResource(uri, basePath);
		}
	}
}

namespace Castle.Core.Resource
{
	public interface IResourceFactory
	{
		bool Accept(CustomUri uri);

		IResource Create(CustomUri uri);

		IResource Create(CustomUri uri, string basePath);
	}
}

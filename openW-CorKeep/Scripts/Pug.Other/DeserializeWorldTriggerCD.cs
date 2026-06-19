using Pug.Platform;
using Unity.Entities;

public struct DeserializeWorldTriggerCD : IComponentData, IQueryTypeParameter
{
	public FilesystemManager.File file;
}

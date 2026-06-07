namespace Jundroo.SocialPlatforms.Steam.RemoteStorage
{
	public class RemoteStorageLocalFileChange
	{
		public RemoteStorageLocalFileChangeType ChangeType { get; }

		public string Path { get; }

		public RemoteStorageFilePathType PathType { get; }

		public RemoteStorageLocalFileChange(string path, RemoteStorageFilePathType pathType, RemoteStorageLocalFileChangeType changeType)
		{
			Path = path;
			PathType = pathType;
			ChangeType = changeType;
		}
	}
}

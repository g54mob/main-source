namespace Jundroo.SocialPlatforms.Steam
{
	public class SubscribedWorkshopItemInfo
	{
		public string FolderPath { get; private set; }

		public ulong Id { get; private set; }

		public bool Installed { get; private set; }

		public uint Timestamp { get; private set; }

		public SubscribedWorkshopItemInfo(ulong id, bool installed, string folderPath, uint timestamp)
		{
			Id = id;
			Installed = installed;
			FolderPath = folderPath;
			Timestamp = timestamp;
		}
	}
}

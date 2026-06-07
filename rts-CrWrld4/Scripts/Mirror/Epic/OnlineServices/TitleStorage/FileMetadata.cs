namespace Epic.OnlineServices.TitleStorage
{
	public class FileMetadata : ISettable
	{
		public uint FileSizeBytes { get; set; }

		public string MD5Hash { get; set; }

		public string Filename { get; set; }

		public uint UnencryptedDataSizeBytes { get; set; }

		internal void Set(FileMetadataInternal? other)
		{
		}

		public void Set(object other)
		{
		}
	}
}

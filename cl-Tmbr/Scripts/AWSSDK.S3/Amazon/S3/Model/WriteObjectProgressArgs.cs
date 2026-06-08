namespace Amazon.S3.Model
{
	public class WriteObjectProgressArgs : TransferProgressArgs
	{
		public string BucketName { get; private set; }

		public string Key { get; private set; }

		public string VersionId { get; private set; }

		public string FilePath { get; private set; }

		public bool IsCompleted { get; private set; }

		internal WriteObjectProgressArgs(string bucketName, string key, string versionId, long incrementTransferred, long transferred, long total, bool completed)
			: base(incrementTransferred, transferred, total)
		{
			BucketName = bucketName;
			Key = key;
			VersionId = versionId;
			IsCompleted = completed;
		}

		internal WriteObjectProgressArgs(string bucketName, string key, string filePath, string versionId, long incrementTransferred, long transferred, long total, bool completed)
			: base(incrementTransferred, transferred, total)
		{
			BucketName = bucketName;
			Key = key;
			VersionId = versionId;
			FilePath = filePath;
			IsCompleted = completed;
		}
	}
}

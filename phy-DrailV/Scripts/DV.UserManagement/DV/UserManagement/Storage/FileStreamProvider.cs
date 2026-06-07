using System.IO;

namespace DV.UserManagement.Storage
{
	public class FileStreamProvider : IStreamProvider
	{
		private Stream fileStream;

		private string filePath = string.Empty;

		private long seekPosition;

		public FileStreamProvider(string filePath, long seekPosition = 0L)
		{
			this.filePath = filePath;
			this.seekPosition = seekPosition;
		}

		public Stream GrabStream()
		{
			fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			fileStream.Seek(seekPosition, SeekOrigin.Begin);
			return fileStream;
		}

		public void ReleaseStream()
		{
			fileStream.Close();
			fileStream = null;
		}
	}
}

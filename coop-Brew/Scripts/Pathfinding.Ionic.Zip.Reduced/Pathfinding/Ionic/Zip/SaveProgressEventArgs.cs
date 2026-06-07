namespace Pathfinding.Ionic.Zip
{
	public class SaveProgressEventArgs : ZipProgressEventArgs
	{
		private int _entriesSaved;

		public int EntriesSaved => 0;

		internal SaveProgressEventArgs(string archiveName, bool before, int entriesTotal, int entriesSaved, ZipEntry entry)
		{
		}

		internal SaveProgressEventArgs()
		{
		}

		internal SaveProgressEventArgs(string archiveName, ZipProgressEventType flavor)
		{
		}

		internal static SaveProgressEventArgs ByteUpdate(string archiveName, ZipEntry entry, long bytesXferred, long totalBytes)
		{
			return null;
		}

		internal static SaveProgressEventArgs Started(string archiveName)
		{
			return null;
		}

		internal static SaveProgressEventArgs Completed(string archiveName)
		{
			return null;
		}
	}
}

namespace Pathfinding.Ionic.Zip
{
	public class ReadProgressEventArgs : ZipProgressEventArgs
	{
		internal ReadProgressEventArgs()
		{
		}

		private ReadProgressEventArgs(string archiveName, ZipProgressEventType flavor)
		{
		}

		internal static ReadProgressEventArgs Before(string archiveName, int entriesTotal)
		{
			return null;
		}

		internal static ReadProgressEventArgs After(string archiveName, ZipEntry entry, int entriesTotal)
		{
			return null;
		}

		internal static ReadProgressEventArgs Started(string archiveName)
		{
			return null;
		}

		internal static ReadProgressEventArgs ByteUpdate(string archiveName, ZipEntry entry, long bytesXferred, long totalBytes)
		{
			return null;
		}

		internal static ReadProgressEventArgs Completed(string archiveName)
		{
			return null;
		}
	}
}

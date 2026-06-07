namespace Pathfinding.Ionic.Zip
{
	public class ExtractProgressEventArgs : ZipProgressEventArgs
	{
		private int _entriesExtracted;

		private string _target;

		public int EntriesExtracted => 0;

		public string ExtractLocation => null;

		internal ExtractProgressEventArgs(string archiveName, bool before, int entriesTotal, int entriesExtracted, ZipEntry entry, string extractLocation)
		{
		}

		internal ExtractProgressEventArgs(string archiveName, ZipProgressEventType flavor)
		{
		}

		internal ExtractProgressEventArgs()
		{
		}

		internal static ExtractProgressEventArgs BeforeExtractEntry(string archiveName, ZipEntry entry, string extractLocation)
		{
			return null;
		}

		internal static ExtractProgressEventArgs ExtractExisting(string archiveName, ZipEntry entry, string extractLocation)
		{
			return null;
		}

		internal static ExtractProgressEventArgs AfterExtractEntry(string archiveName, ZipEntry entry, string extractLocation)
		{
			return null;
		}

		internal static ExtractProgressEventArgs ExtractAllStarted(string archiveName, string extractLocation)
		{
			return null;
		}

		internal static ExtractProgressEventArgs ExtractAllCompleted(string archiveName, string extractLocation)
		{
			return null;
		}

		internal static ExtractProgressEventArgs ByteUpdate(string archiveName, ZipEntry entry, long bytesWritten, long totalBytes)
		{
			return null;
		}
	}
}

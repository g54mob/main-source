namespace Pathfinding.Ionic.Zip
{
	public class AddProgressEventArgs : ZipProgressEventArgs
	{
		internal AddProgressEventArgs()
		{
		}

		private AddProgressEventArgs(string archiveName, ZipProgressEventType flavor)
		{
		}

		internal static AddProgressEventArgs AfterEntry(string archiveName, ZipEntry entry, int entriesTotal)
		{
			return null;
		}

		internal static AddProgressEventArgs Started(string archiveName)
		{
			return null;
		}

		internal static AddProgressEventArgs Completed(string archiveName)
		{
			return null;
		}
	}
}

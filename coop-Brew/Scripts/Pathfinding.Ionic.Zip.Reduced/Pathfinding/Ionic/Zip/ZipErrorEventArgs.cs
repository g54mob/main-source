using System;

namespace Pathfinding.Ionic.Zip
{
	public class ZipErrorEventArgs : ZipProgressEventArgs
	{
		private Exception _exc;

		public Exception Exception => null;

		public string FileName => null;

		private ZipErrorEventArgs()
		{
		}

		internal static ZipErrorEventArgs Saving(string archiveName, ZipEntry entry, Exception exception)
		{
			return null;
		}
	}
}

using System;

namespace Pathfinding.Ionic.Zip
{
	public class ZipProgressEventArgs : EventArgs
	{
		private int _entriesTotal;

		private bool _cancel;

		private ZipEntry _latestEntry;

		private ZipProgressEventType _flavor;

		private string _archiveName;

		private long _bytesTransferred;

		private long _totalBytesToTransfer;

		public int EntriesTotal
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ZipEntry CurrentEntry
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool Cancel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ZipProgressEventType EventType
		{
			get
			{
				return default(ZipProgressEventType);
			}
			set
			{
			}
		}

		public string ArchiveName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public long BytesTransferred
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public long TotalBytesToTransfer
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		internal ZipProgressEventArgs()
		{
		}

		internal ZipProgressEventArgs(string archiveName, ZipProgressEventType flavor)
		{
		}
	}
}

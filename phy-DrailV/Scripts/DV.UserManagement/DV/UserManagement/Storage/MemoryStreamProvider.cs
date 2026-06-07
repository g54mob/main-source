using System.IO;

namespace DV.UserManagement.Storage
{
	public class MemoryStreamProvider : IStreamProvider
	{
		private MemoryStream baseStream;

		private long seekOffset;

		private bool grabbed;

		public MemoryStreamProvider(MemoryStream baseStream, long seekOffset = 0L)
		{
			this.baseStream = baseStream;
			this.seekOffset = seekOffset;
		}

		public MemoryStreamProvider(byte[] buffer, long seekOffset = 0L)
		{
			baseStream = new MemoryStream(buffer, writable: false);
			this.seekOffset = seekOffset;
		}

		public Stream GrabStream()
		{
			grabbed = true;
			baseStream.Seek(seekOffset, SeekOrigin.Begin);
			return baseStream;
		}

		public void ReleaseStream()
		{
			grabbed = false;
		}
	}
}

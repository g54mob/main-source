using System;
using System.IO;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Cms
{
	public class CmsProcessableFile : CmsProcessable, CmsReadable
	{
		private const int DefaultBufSize = 32768;

		private readonly FileInfo _file;

		private readonly int _bufSize;

		public CmsProcessableFile(FileInfo file)
		{
		}

		public CmsProcessableFile(FileInfo file, int bufSize)
		{
		}

		public virtual Stream GetInputStream()
		{
			return null;
		}

		public virtual void Write(Stream zOut)
		{
		}

		[Obsolete]
		public virtual object GetContent()
		{
			return null;
		}
	}
}

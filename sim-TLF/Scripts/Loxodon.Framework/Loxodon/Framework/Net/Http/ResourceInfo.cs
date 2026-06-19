using System;
using System.IO;

namespace Loxodon.Framework.Net.Http
{
	public class ResourceInfo
	{
		public Uri Path { get; private set; }

		public FileInfo FileInfo { get; private set; }

		public long FileSize { get; set; }

		public ResourceInfo(Uri path, FileInfo fileInfo)
			: this(path, fileInfo, -1L)
		{
		}

		public ResourceInfo(Uri path, FileInfo fileInfo, long fileSize)
		{
			Path = path;
			FileInfo = fileInfo;
			FileSize = fileSize;
		}
	}
}

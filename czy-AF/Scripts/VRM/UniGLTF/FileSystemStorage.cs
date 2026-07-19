using System;
using System.IO;

namespace UniGLTF
{
	public class FileSystemStorage : IStorage
	{
		private string m_root;

		public FileSystemStorage(string root)
		{
			m_root = Path.GetFullPath(root);
		}

		public ArraySegment<byte> Get(string url)
		{
			return new ArraySegment<byte>(url.StartsWith("data:") ? UriByteBuffer.ReadEmbedded(url) : File.ReadAllBytes(Path.Combine(m_root, url)));
		}

		public string GetPath(string url)
		{
			if (url.StartsWith("data:"))
			{
				return null;
			}
			return Path.Combine(m_root, url).Replace("\\", "/");
		}
	}
}

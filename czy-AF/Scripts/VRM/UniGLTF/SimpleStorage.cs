using System;

namespace UniGLTF
{
	public class SimpleStorage : IStorage
	{
		private ArraySegment<byte> m_bytes;

		public SimpleStorage()
			: this(default(ArraySegment<byte>))
		{
		}

		public SimpleStorage(ArraySegment<byte> bytes)
		{
			m_bytes = bytes;
		}

		public ArraySegment<byte> Get(string url)
		{
			return m_bytes;
		}

		public string GetPath(string url)
		{
			return null;
		}
	}
}

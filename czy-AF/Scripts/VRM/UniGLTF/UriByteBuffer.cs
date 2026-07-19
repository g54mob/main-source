using System;
using System.IO;

namespace UniGLTF
{
	public class UriByteBuffer : IBytesBuffer
	{
		private byte[] m_bytes;

		private const string DataPrefix = "data:application/octet-stream;base64,";

		private const string DataPrefix2 = "data:application/gltf-buffer;base64,";

		private const string DataPrefix3 = "data:image/jpeg;base64,";

		public string Uri { get; private set; }

		public ArraySegment<byte> GetBytes()
		{
			return new ArraySegment<byte>(m_bytes);
		}

		public UriByteBuffer(string baseDir, string uri)
		{
			Uri = uri;
			m_bytes = ReadFromUri(baseDir, uri);
		}

		[Obsolete("Use ReadEmbedded(uri)")]
		public static byte[] ReadEmbeded(string uri)
		{
			return ReadEmbedded(uri);
		}

		public static byte[] ReadEmbedded(string uri)
		{
			int num = uri.IndexOf(";base64,");
			if (num < 0)
			{
				throw new NotImplementedException();
			}
			return Convert.FromBase64String(uri.Substring(num + 8));
		}

		private byte[] ReadFromUri(string baseDir, string uri)
		{
			byte[] array = ReadEmbedded(uri);
			if (array != null)
			{
				return array;
			}
			return File.ReadAllBytes(Path.Combine(baseDir, uri));
		}

		public glTFBufferView Extend<T>(ArraySegment<T> array, glBufferTarget target) where T : struct
		{
			throw new NotImplementedException();
		}
	}
}

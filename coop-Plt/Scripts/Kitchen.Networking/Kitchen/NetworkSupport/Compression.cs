using System.IO;
using System.IO.Compression;
using System.Text;

namespace Kitchen.NetworkSupport
{
	public static class Compression
	{
		public static MemoryStream Zip(string str, bool log = false)
		{
			using MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(str));
			using MemoryStream memoryStream2 = new MemoryStream();
			using (GZipStream destination = new GZipStream(memoryStream2, CompressionMode.Compress))
			{
				memoryStream.CopyTo(destination);
			}
			return memoryStream2;
		}

		public static MemoryStream Zip(MemoryStream uncompressedStream, bool log = false)
		{
			using MemoryStream memoryStream = new MemoryStream();
			_ = uncompressedStream.Length;
			using (GZipStream destination = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				uncompressedStream.CopyTo(destination);
			}
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			_ = memoryStream2.Length;
			uncompressedStream.Dispose();
			return memoryStream2;
		}

		public static string UnzipToString(MemoryStream compressedStream, bool log = false)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
			{
				gZipStream.CopyTo(memoryStream);
			}
			compressedStream.Dispose();
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}

		public static MemoryStream UnzipToStream(MemoryStream compressedStream, bool log = false)
		{
			using MemoryStream memoryStream = new MemoryStream();
			_ = compressedStream.Length;
			using (GZipStream gZipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
			{
				gZipStream.CopyTo(memoryStream);
			}
			MemoryStream memoryStream2 = new MemoryStream(memoryStream.ToArray());
			_ = memoryStream2.Length;
			return memoryStream2;
		}
	}
}

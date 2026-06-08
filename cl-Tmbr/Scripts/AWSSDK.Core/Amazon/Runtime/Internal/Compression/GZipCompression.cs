using System.IO;
using System.IO.Compression;

namespace Amazon.Runtime.Internal.Compression
{
	public class GZipCompression : ICompressionAlgorithm
	{
		public CompressionEncodingAlgorithm AlgorithmId => CompressionEncodingAlgorithm.gzip;

		public byte[] Compress(byte[] content)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				gZipStream.Write(content, 0, content.Length);
				gZipStream.Close();
			}
			return memoryStream.ToArray();
		}

		public Stream GetCompressionStream(Stream inputStream)
		{
			return new GZipStream(inputStream, CompressionMode.Compress, leaveOpen: true);
		}
	}
}

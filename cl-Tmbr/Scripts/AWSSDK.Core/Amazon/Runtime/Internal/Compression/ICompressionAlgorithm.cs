using System.IO;

namespace Amazon.Runtime.Internal.Compression
{
	public interface ICompressionAlgorithm
	{
		CompressionEncodingAlgorithm AlgorithmId { get; }

		byte[] Compress(byte[] content);

		Stream GetCompressionStream(Stream inputStream);
	}
}

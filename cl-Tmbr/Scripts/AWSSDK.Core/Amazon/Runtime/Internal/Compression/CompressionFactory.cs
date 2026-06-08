using System;

namespace Amazon.Runtime.Internal.Compression
{
	public static class CompressionFactory
	{
		public static ICompressionAlgorithm GetCompressionAlgorithm(CompressionEncodingAlgorithm type)
		{
			if (type == CompressionEncodingAlgorithm.gzip)
			{
				return new GZipCompression();
			}
			throw new ArgumentException($"Invalid compression type: {type}");
		}
	}
}

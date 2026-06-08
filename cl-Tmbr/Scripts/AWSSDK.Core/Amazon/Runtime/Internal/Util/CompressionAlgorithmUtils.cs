using System;

namespace Amazon.Runtime.Internal.Util
{
	public static class CompressionAlgorithmUtils
	{
		public static void SetCompressionAlgorithm(IRequest request, CompressionEncodingAlgorithm compressionAlgorithm)
		{
			request.CompressionAlgorithm = compressionAlgorithm;
		}

		public static void SetRequestHeader(IRequest request, CompressionEncodingAlgorithm compressionEncodingAlgorithm)
		{
			string text = compressionEncodingAlgorithm.ToString();
			if (compressionEncodingAlgorithm == CompressionEncodingAlgorithm.NONE)
			{
				throw new ArgumentException("CompressionEncodingAlgorithm enum cannot have value NONE");
			}
			if (request.Headers.ContainsKey("Content-Encoding"))
			{
				request.Headers["Content-Encoding"] = request.Headers["Content-Encoding"] + "," + text;
			}
			else
			{
				request.Headers["Content-Encoding"] = text;
			}
		}
	}
}

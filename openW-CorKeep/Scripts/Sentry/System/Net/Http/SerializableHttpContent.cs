using System.IO;
using System.Threading;

namespace System.Net.Http
{
	internal abstract class SerializableHttpContent : HttpContent
	{
		protected virtual void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
		{
		}

		internal Stream ReadAsStream(CancellationToken cancellationToken)
		{
			MemoryStream memoryStream = new MemoryStream();
			SerializeToStream(memoryStream, null, cancellationToken);
			memoryStream.Seek(0L, SeekOrigin.Begin);
			return memoryStream;
		}
	}
}

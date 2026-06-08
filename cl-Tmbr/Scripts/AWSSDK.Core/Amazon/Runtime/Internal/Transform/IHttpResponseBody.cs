using System;
using System.IO;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal.Transform
{
	public interface IHttpResponseBody : IDisposable
	{
		Stream OpenResponse();

		Task<Stream> OpenResponseAsync();
	}
}

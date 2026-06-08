using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.Runtime
{
	public interface IHttpRequest<TRequestContent> : IDisposable
	{
		string Method { get; set; }

		Uri RequestUri { get; }

		Version HttpProtocolVersion { get; set; }

		void ConfigureRequest(IRequestContext requestContext);

		void SetRequestHeaders(IDictionary<string, string> headers);

		TRequestContent GetRequestContent();

		IWebResponseData GetResponse();

		void WriteToRequestBody(TRequestContent requestContent, Stream contentStream, IDictionary<string, string> contentHeaders, IRequestContext requestContext);

		void WriteToRequestBody(TRequestContent requestContent, byte[] content, IDictionary<string, string> contentHeaders);

		IHttpRequestStreamHandle SetupHttpRequestStreamPublisher(IDictionary<string, string> contentHeaders, IHttpRequestStreamPublisher publisher);

		Stream SetupProgressListeners(Stream originalStream, long progressUpdateInterval, object sender, EventHandler<StreamTransferProgressArgs> callback);

		void Abort();

		Task<TRequestContent> GetRequestContentAsync();

		Task<IWebResponseData> GetResponseAsync(CancellationToken cancellationToken);
	}
}

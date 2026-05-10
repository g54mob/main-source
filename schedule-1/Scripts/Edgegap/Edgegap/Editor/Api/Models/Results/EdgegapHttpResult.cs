using System.Net;
using System.Net.Http;

namespace Edgegap.Editor.Api.Models.Results
{
	public class EdgegapHttpResult
	{
		public HttpMethod HttpMethod;

		public HttpStatusCode StatusCode { get; }

		public string Json { get; }

		public string ReasonPhrase { get; }

		public bool HasErr => false;

		public EdgegapErrorResult Error { get; set; }

		public bool IsResultCode200 => false;

		public bool IsResultCode204 => false;

		public bool IsResultCode403 => false;

		public bool IsResultCode409 => false;

		public bool IsResultCode400 => false;

		public bool IsResultCode410 => false;

		public EdgegapHttpResult(HttpResponseMessage httpResponse)
		{
		}
	}
	public class EdgegapHttpResult<TResult> : EdgegapHttpResult
	{
		public TResult Data { get; set; }

		public EdgegapHttpResult(HttpResponseMessage httpResponse, bool isLogLevelDebug = false)
			: base(null)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Sentry.Extensibility
{
	public class FormRequestPayloadExtractor : BaseRequestPayloadExtractor
	{
		private const string SupportedContentType = "application/x-www-form-urlencoded";

		protected override bool IsSupported(IHttpRequest request)
		{
			return "application/x-www-form-urlencoded".Equals(request.ContentType, StringComparison.InvariantCulture);
		}

		protected override object? DoExtractPayLoad(IHttpRequest request)
		{
			return request.Form?.ToDictionary<KeyValuePair<string, IEnumerable<string>>, string, IEnumerable<string>>((KeyValuePair<string, IEnumerable<string>> k) => k.Key, (KeyValuePair<string, IEnumerable<string>> v) => v.Value);
		}
	}
}

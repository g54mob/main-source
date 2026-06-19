using System.Collections.Generic;
using System.IO;

namespace Sentry.Extensibility
{
	public interface IHttpRequest
	{
		long? ContentLength { get; }

		string? ContentType { get; }

		Stream? Body { get; }

		IEnumerable<KeyValuePair<string, IEnumerable<string>>>? Form { get; }
	}
}

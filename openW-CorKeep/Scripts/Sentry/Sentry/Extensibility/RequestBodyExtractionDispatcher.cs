using System;
using System.Collections.Generic;
using Sentry.Internal.Extensions;

namespace Sentry.Extensibility
{
	public class RequestBodyExtractionDispatcher : IRequestPayloadExtractor
	{
		private readonly SentryOptions _options;

		private readonly Func<RequestSize> _sizeSwitch;

		internal IEnumerable<IRequestPayloadExtractor> Extractors { get; }

		public RequestBodyExtractionDispatcher(IEnumerable<IRequestPayloadExtractor> extractors, SentryOptions options, Func<RequestSize> sizeSwitch)
		{
			Extractors = extractors ?? throw new ArgumentNullException("extractors");
			_options = options ?? throw new ArgumentNullException("options");
			_sizeSwitch = sizeSwitch ?? throw new ArgumentNullException("sizeSwitch");
		}

		public object? ExtractPayload(IHttpRequest request)
		{
			if (request.IsNull())
			{
				return null;
			}
			RequestSize requestSize = _sizeSwitch();
			switch (requestSize)
			{
			case RequestSize.Small:
				if (!(request.ContentLength < 1000))
				{
					break;
				}
				goto case RequestSize.Always;
			case RequestSize.Medium:
				if (!(request.ContentLength < 10000))
				{
					break;
				}
				goto case RequestSize.Always;
			case RequestSize.Always:
				_options.LogDebug("Attempting to read request body of size: {0}, configured max: {1}.", request.ContentLength, requestSize);
				foreach (IRequestPayloadExtractor extractor in Extractors)
				{
					object obj = extractor.ExtractPayload(request);
					if (obj != null && (!(obj is string value) || !string.IsNullOrEmpty(value)))
					{
						return obj;
					}
				}
				break;
			case RequestSize.None:
				_options.LogDebug("Skipping request body extraction.");
				return null;
			}
			if (request.ContentLength.HasValue)
			{
				_options.LogWarning("Ignoring request with Size {0} and configuration RequestSize {1}", request.ContentLength, requestSize);
			}
			return null;
		}
	}
}

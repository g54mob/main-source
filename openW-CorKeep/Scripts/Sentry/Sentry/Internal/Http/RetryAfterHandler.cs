using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Sentry.Infrastructure;

namespace Sentry.Internal.Http
{
	internal class RetryAfterHandler : DelegatingHandler
	{
		private readonly ISystemClock _clock;

		private const HttpStatusCode TooManyRequests = HttpStatusCode.TooManyRequests;

		internal static readonly TimeSpan DefaultRetryAfterDelay = TimeSpan.FromSeconds(60.0);

		private long _retryAfterUtcTicks;

		internal long RetryAfterUtcTicks => _retryAfterUtcTicks;

		public RetryAfterHandler(HttpMessageHandler innerHandler)
			: this(innerHandler, SystemClock.Clock)
		{
		}

		internal RetryAfterHandler(HttpMessageHandler innerHandler, ISystemClock clock)
			: base(innerHandler)
		{
			_clock = clock ?? throw new ArgumentNullException("clock");
		}

		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			long num = Interlocked.CompareExchange(ref _retryAfterUtcTicks, 0L, 0L);
			if (num != 0L)
			{
				if (num > _clock.GetUtcNow().Ticks)
				{
					return new HttpResponseMessage(HttpStatusCode.TooManyRequests);
				}
				Interlocked.Exchange(ref _retryAfterUtcTicks, 0L);
			}
			HttpResponseMessage httpResponseMessage = await base.SendAsync(request, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (httpResponseMessage.StatusCode == HttpStatusCode.TooManyRequests)
			{
				DateTimeOffset retryAfterTimestamp = GetRetryAfterTimestamp(httpResponseMessage);
				Interlocked.Exchange(ref _retryAfterUtcTicks, retryAfterTimestamp.UtcTicks);
			}
			return httpResponseMessage;
		}

		private DateTimeOffset GetRetryAfterTimestamp(HttpResponseMessage response)
		{
			if (response.Headers.RetryAfter != null)
			{
				TimeSpan? delta = response.Headers.RetryAfter.Delta;
				if (delta.HasValue)
				{
					TimeSpan valueOrDefault = delta.GetValueOrDefault();
					return _clock.GetUtcNow() + valueOrDefault;
				}
				DateTimeOffset? date = response.Headers.RetryAfter.Date;
				if (date.HasValue)
				{
					return date.GetValueOrDefault();
				}
			}
			if (response.Headers.TryGetValues("Retry-After", out var values) && double.TryParse(values.FirstOrDefault(), NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out var result))
			{
				return _clock.GetUtcNow().AddTicks((long)(result * 10000000.0));
			}
			return _clock.GetUtcNow() + DefaultRetryAfterDelay;
		}
	}
}

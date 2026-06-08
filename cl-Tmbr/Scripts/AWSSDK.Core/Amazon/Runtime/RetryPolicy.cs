using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
using System.Threading.Tasks;
using AWSSDK.Runtime.Internal.Util;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime
{
	public abstract class RetryPolicy
	{
		private const string sslErrorZeroReturn = "SSL_ERROR_ZERO_RETURN";

		private static HashSet<string> definiteClockSkewErrorCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "RequestTimeTooSkewed", "RequestExpired", "RequestInTheFuture" };

		private static HashSet<string> possibleClockSkewErrorCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "InvalidSignatureException", "AuthFailure", "SignatureDoesNotMatch" };

		private const string clockSkewMessageFormat = "Identified clock skew: local time = {0}, local time with correction = {1}, current clock skew correction = {2}, server time = {3}, service endpoint = {4}.";

		private const string clockSkewUpdatedFormat = "Setting clock skew correction: new clock skew correction = {0}, service endpoint = {1}.";

		private const string clockSkewMessageParen = "(";

		private const string clockSkewMessagePlusSeparator = " + ";

		private const string clockSkewMessageMinusSeparator = " - ";

		private static TimeSpan clockSkewMaxThreshold = TimeSpan.FromMinutes(5.0);

		public int MaxRetries { get; protected set; }

		public ILogger Logger { get; set; }

		public virtual ICollection<string> ThrottlingErrorCodes { get; protected set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"Throttling", "ThrottlingException", "ThrottledException", "RequestThrottledException", "TooManyRequestsException", "ProvisionedThroughputExceededException", "TransactionInProgressException", "RequestLimitExceeded", "BandwidthLimitExceeded", "LimitExceededException",
			"RequestThrottled", "SlowDown", "PriorRequestNotComplete"
		};

		public ICollection<string> TimeoutErrorCodesToRetryOn { get; protected set; } = new HashSet<string> { "RequestTimeout", "RequestTimeoutException" };

		public ICollection<string> ErrorCodesToRetryOn { get; protected set; } = new HashSet<string>();

		public ICollection<HttpStatusCode> HttpStatusCodesToRetryOn { get; protected set; } = new HashSet<HttpStatusCode>
		{
			HttpStatusCode.InternalServerError,
			HttpStatusCode.ServiceUnavailable,
			HttpStatusCode.BadGateway,
			HttpStatusCode.GatewayTimeout
		};

		public ICollection<WebExceptionStatus> WebExceptionStatusesToRetryOn { get; protected set; } = new HashSet<WebExceptionStatus>
		{
			WebExceptionStatus.ConnectFailure,
			WebExceptionStatus.ConnectionClosed,
			WebExceptionStatus.KeepAliveFailure,
			WebExceptionStatus.NameResolutionFailure,
			WebExceptionStatus.ReceiveFailure,
			WebExceptionStatus.SendFailure,
			WebExceptionStatus.Timeout
		};

		protected RetryCapacity RetryCapacity { get; set; }

		public bool Retry(IExecutionContext executionContext, Exception exception)
		{
			bool flag = !RetryLimitReached(executionContext) && CanRetry(executionContext);
			if (flag || executionContext.RequestContext.CSMEnabled)
			{
				bool flag2 = IsClockskew(executionContext, exception);
				if (flag2 || RetryForException(executionContext, exception))
				{
					executionContext.RequestContext.IsLastExceptionRetryable = true;
					if (!flag)
					{
						return false;
					}
					executionContext.RequestContext.LastCapacityType = ((!IsServiceTimeoutError(exception)) ? CapacityManager.CapacityType.Retry : CapacityManager.CapacityType.Timeout);
					return OnRetry(executionContext, flag2, IsThrottlingError(exception));
				}
			}
			return false;
		}

		public abstract bool CanRetry(IExecutionContext executionContext);

		public abstract bool RetryForException(IExecutionContext executionContext, Exception exception);

		public abstract bool RetryLimitReached(IExecutionContext executionContext);

		public abstract void WaitBeforeRetry(IExecutionContext executionContext);

		public virtual void NotifySuccess(IExecutionContext executionContext)
		{
		}

		public virtual bool OnRetry(IExecutionContext executionContext)
		{
			return true;
		}

		public virtual bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity)
		{
			return true;
		}

		public virtual bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity, bool isThrottlingError)
		{
			return OnRetry(executionContext, bypassAcquireCapacity);
		}

		public virtual void ObtainSendToken(IExecutionContext executionContext, Exception exception)
		{
		}

		public virtual bool IsThrottlingError(Exception exception)
		{
			AmazonServiceException ex = exception as AmazonServiceException;
			if (ex == null || ex.Retryable?.Throttling != true)
			{
				return ThrottlingErrorCodes.Contains(ex?.ErrorCode);
			}
			return true;
		}

		public virtual bool IsTransientError(IExecutionContext executionContext, Exception exception)
		{
			if (exception is IOException && !(exception is FileNotFoundException))
			{
				return true;
			}
			if (ExceptionUtils.IsInnerException<IOException>(exception))
			{
				return true;
			}
			AmazonServiceException ex = exception as AmazonServiceException;
			if (ex != null)
			{
				if (ex.Retryable != null)
				{
					return true;
				}
				if (HttpStatusCodesToRetryOn.Contains(ex.StatusCode) && !IsThrottlingError(exception))
				{
					return true;
				}
				if (ex.StatusCode == HttpStatusCode.OK && ex is AmazonUnmarshallingException)
				{
					return true;
				}
			}
			if (ExceptionUtils.IsInnerException<WebException>(exception, out var inner) && WebExceptionStatusesToRetryOn.Contains(inner.Status))
			{
				return true;
			}
			if (IsTransientSslError(exception))
			{
				return true;
			}
			if (ExceptionUtils.IsInnerException<ObjectDisposedException>(exception))
			{
				return true;
			}
			if (ex == null && exception is HttpRequestException)
			{
				return true;
			}
			if (exception is OperationCanceledException && !executionContext.RequestContext.CancellationToken.IsCancellationRequested)
			{
				return true;
			}
			if (exception is TimeoutException)
			{
				return true;
			}
			return false;
		}

		public static bool IsTransientSslError(Exception exception)
		{
			bool flag = false;
			while (exception != null)
			{
				if (exception is AuthenticationException)
				{
					flag = true;
				}
				if (flag && exception.Message.Contains("SSL_ERROR_ZERO_RETURN"))
				{
					return true;
				}
				exception = exception.InnerException;
			}
			return false;
		}

		public virtual bool IsServiceTimeoutError(Exception exception)
		{
			return TimeoutErrorCodesToRetryOn.Contains((exception as AmazonServiceException)?.ErrorCode);
		}

		private bool IsClockskew(IExecutionContext executionContext, Exception exception)
		{
			_ = executionContext.RequestContext.ClientConfig;
			AmazonServiceException ex = exception as AmazonServiceException;
			bool flag = executionContext.RequestContext.Request != null && string.Equals(executionContext.RequestContext.Request.HttpMethod, "HEAD", StringComparison.Ordinal);
			bool flag2 = ex != null && (ex.ErrorCode == null || possibleClockSkewErrorCodes.Contains(ex.ErrorCode));
			bool num = ex != null && definiteClockSkewErrorCodes.Contains(ex.ErrorCode);
			DateTime dateTime = AWSConfigs.utcNowSource();
			string text = executionContext.RequestContext.Request.Endpoint.ToString();
			DateTime correctedUtcNowForEndpoint = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(text);
			DateTime serverTime;
			bool flag3 = TryParseDateHeader(ex, out serverTime);
			if (!flag3)
			{
				flag3 = TryParseExceptionMessage(ex, out serverTime);
			}
			serverTime = serverTime.ToUniversalTime();
			bool flag4 = AWSConfigs.CorrectForClockSkew && !AWSConfigs.ManualClockCorrection.HasValue;
			if (num && flag3)
			{
				Logger.InfoFormat("Identified clock skew: local time = {0}, local time with correction = {1}, current clock skew correction = {2}, server time = {3}, service endpoint = {4}.", dateTime, correctedUtcNowForEndpoint, CorrectClockSkew.GetCorrectedUtcNowForEndpoint(text), serverTime, text);
				TimeSpan timeSpan = serverTime - dateTime;
				CorrectClockSkew.SetClockCorrectionForEndpoint(text, timeSpan);
				if (flag4)
				{
					Logger.InfoFormat("Setting clock skew correction: new clock skew correction = {0}, service endpoint = {1}.", timeSpan, text);
					executionContext.RequestContext.IsSigned = false;
					return true;
				}
			}
			if ((flag2 || flag) && flag3)
			{
				TimeSpan timeSpan2 = (executionContext.RequestContext.Request.SignedAt ?? correctedUtcNowForEndpoint) - serverTime;
				if (((timeSpan2.Ticks < 0) ? (-timeSpan2) : timeSpan2) > clockSkewMaxThreshold)
				{
					Logger.InfoFormat("Identified clock skew: local time = {0}, local time with correction = {1}, current clock skew correction = {2}, server time = {3}, service endpoint = {4}.", dateTime, correctedUtcNowForEndpoint, CorrectClockSkew.GetClockCorrectionForEndpoint(text), serverTime, text);
					TimeSpan timeSpan3 = serverTime - dateTime;
					CorrectClockSkew.SetClockCorrectionForEndpoint(text, timeSpan3);
					if (flag4)
					{
						Logger.InfoFormat("Setting clock skew correction: new clock skew correction = {0}, service endpoint = {1}.", timeSpan3, text);
						executionContext.RequestContext.IsSigned = false;
						return true;
					}
				}
			}
			return false;
		}

		private static bool TryParseDateHeader(AmazonServiceException ase, out DateTime serverTime)
		{
			IWebResponseData webData = GetWebData(ase);
			if (webData != null)
			{
				string headerValue = webData.GetHeaderValue("Date");
				if (!string.IsNullOrEmpty(headerValue) && DateTime.TryParseExact(headerValue, "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out serverTime))
				{
					return true;
				}
			}
			serverTime = DateTime.MinValue;
			return false;
		}

		private static bool TryParseExceptionMessage(AmazonServiceException ase, out DateTime serverTime)
		{
			if (ase != null && !string.IsNullOrEmpty(ase.Message))
			{
				string message = ase.Message;
				int num = message.IndexOf("(", StringComparison.Ordinal);
				if (num >= 0)
				{
					num++;
					int num2 = message.IndexOf(" + ", num, StringComparison.Ordinal);
					if (num2 < 0)
					{
						num2 = message.IndexOf(" - ", num, StringComparison.Ordinal);
					}
					if (num2 > num && DateTime.TryParseExact(message.Substring(num, num2 - num), "yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out serverTime))
					{
						return true;
					}
				}
			}
			serverTime = DateTime.MinValue;
			return false;
		}

		private static IWebResponseData GetWebData(AmazonServiceException ase)
		{
			if (ase != null)
			{
				Exception ex = ase;
				do
				{
					if (ex is HttpErrorResponseException ex2)
					{
						return ex2.Response;
					}
					ex = ex.InnerException;
				}
				while (ex != null);
			}
			return null;
		}

		protected static bool ContainErrorMessage(Exception exception, HashSet<string> errorMessages)
		{
			if (exception == null)
			{
				return false;
			}
			if (errorMessages.Contains(exception.Message))
			{
				return true;
			}
			return ContainErrorMessage(exception.InnerException, errorMessages);
		}

		protected static string GetRetryCapacityKey(IClientConfig config)
		{
			if (config.ServiceURL == null)
			{
				return $"http:{config.UseHttp}//region:{config.RegionEndpoint?.SystemName}.service:{config.RegionEndpointServiceName}.fips:{config.UseFIPSEndpoint}.ipv6:{config.UseDualstackEndpoint}";
			}
			return config.ServiceURL;
		}

		public async Task<bool> RetryAsync(IExecutionContext executionContext, Exception exception)
		{
			bool canRetry = !RetryLimitReached(executionContext) && CanRetry(executionContext);
			if (canRetry || executionContext.RequestContext.CSMEnabled)
			{
				bool isClockSkewError = IsClockskew(executionContext, exception);
				bool flag = isClockSkewError;
				if (!flag)
				{
					flag = await RetryForExceptionAsync(executionContext, exception).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (flag)
				{
					executionContext.RequestContext.IsLastExceptionRetryable = true;
					if (!canRetry)
					{
						return false;
					}
					return OnRetry(executionContext, isClockSkewError, IsThrottlingError(exception));
				}
			}
			return false;
		}

		public virtual Task ObtainSendTokenAsync(IExecutionContext executionContext, Exception exception)
		{
			return Task.CompletedTask;
		}

		public abstract Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception);

		public abstract Task WaitBeforeRetryAsync(IExecutionContext executionContext);
	}
}

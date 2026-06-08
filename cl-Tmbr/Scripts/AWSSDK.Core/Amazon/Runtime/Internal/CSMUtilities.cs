using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal
{
	public static class CSMUtilities
	{
		private const string requestKey = "Request";

		public static Task SerializetoJsonAndPostOverUDPAsync(MonitoringAPICall monitoringAPICall)
		{
			string response2;
			if (monitoringAPICall is MonitoringAPICallAttempt monitoringAPICallAttempt)
			{
				if (CreateUDPMessage(monitoringAPICallAttempt, out var response))
				{
					return MonitoringListener.Instance.PostMessagesOverUDPAsync(response);
				}
			}
			else if (CreateUDPMessage((MonitoringAPICallEvent)monitoringAPICall, out response2))
			{
				return MonitoringListener.Instance.PostMessagesOverUDPAsync(response2);
			}
			return Task.FromResult(0);
		}

		public static void SerializetoJsonAndPostOverUDP(MonitoringAPICall monitoringAPICall)
		{
			string response = string.Empty;
			if (monitoringAPICall is MonitoringAPICallAttempt monitoringAPICallAttempt)
			{
				if (CreateUDPMessage(monitoringAPICallAttempt, out response))
				{
					MonitoringListener.Instance.PostMessagesOverUDP(response);
				}
			}
			else if (CreateUDPMessage((MonitoringAPICallEvent)monitoringAPICall, out response))
			{
				MonitoringListener.Instance.PostMessagesOverUDP(response);
			}
		}

		public static string GetApiNameFromRequest(string requestName, IDictionary<string, string> serviceApiNameMapping, string serviceName)
		{
			Logger logger = Logger.GetLogger(typeof(CSMUtilities));
			if (requestName.EndsWith("Request", StringComparison.Ordinal))
			{
				string text = requestName.Substring(0, requestName.Length - "Request".Length);
				if (serviceApiNameMapping.Count > 0 && serviceApiNameMapping.TryGetValue(text, out var value))
				{
					text = value;
				}
				return text;
			}
			logger.InfoFormat(string.Format(CultureInfo.InvariantCulture, "Invalid request name: Request {0} does not end with the keyword '{1}'. Investigate possible generator bug for service:{2} and operation name:{3}", requestName, "Request", serviceName, requestName));
			return string.Empty;
		}

		private static bool CreateUDPMessage(MonitoringAPICallAttempt monitoringAPICallAttempt, out string response)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream);
			utf8JsonWriter.WriteStartObject();
			CreateUDPMessage(monitoringAPICallAttempt, utf8JsonWriter);
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.AccessKey))
			{
				utf8JsonWriter.WritePropertyName("AccessKey");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.AccessKey);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.AWSException))
			{
				utf8JsonWriter.WritePropertyName("AWSException");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.AWSException);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.Fqdn))
			{
				utf8JsonWriter.WritePropertyName("Fqdn");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.Fqdn);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.SdkException))
			{
				utf8JsonWriter.WritePropertyName("SdkException");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.SdkException);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.AWSExceptionMessage))
			{
				utf8JsonWriter.WritePropertyName("AWSExceptionMessage");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.AWSExceptionMessage);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.SdkExceptionMessage))
			{
				utf8JsonWriter.WritePropertyName("SdkExceptionMessage");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.SdkExceptionMessage);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.SessionToken))
			{
				utf8JsonWriter.WritePropertyName("SessionToken");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.SessionToken);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.XAmzId2))
			{
				utf8JsonWriter.WritePropertyName("XAmzId2");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.XAmzId2);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.XAmznRequestId))
			{
				utf8JsonWriter.WritePropertyName("XAmznRequestId");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.XAmznRequestId);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallAttempt.XAmzRequestId))
			{
				utf8JsonWriter.WritePropertyName("XAmzRequestId");
				utf8JsonWriter.WriteStringValue(monitoringAPICallAttempt.XAmzRequestId);
			}
			if (monitoringAPICallAttempt.HttpStatusCode.HasValue)
			{
				utf8JsonWriter.WritePropertyName("HttpStatusCode");
				utf8JsonWriter.WriteNumberValue(monitoringAPICallAttempt.HttpStatusCode.Value);
			}
			utf8JsonWriter.WritePropertyName("AttemptLatency");
			utf8JsonWriter.WriteNumberValue(monitoringAPICallAttempt.AttemptLatency);
			utf8JsonWriter.WriteEndObject();
			utf8JsonWriter.Flush();
			response = Encoding.UTF8.GetString(memoryStream.ToArray());
			return Encoding.Unicode.GetByteCount(response) <= 8192;
		}

		private static bool CreateUDPMessage(MonitoringAPICallEvent monitoringAPICallEvent, out string response)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream);
			utf8JsonWriter.WriteStartObject();
			CreateUDPMessage(monitoringAPICallEvent, utf8JsonWriter);
			utf8JsonWriter.WritePropertyName("Latency");
			utf8JsonWriter.WriteNumberValue(monitoringAPICallEvent.Latency);
			utf8JsonWriter.WritePropertyName("AttemptCount");
			utf8JsonWriter.WriteNumberValue(monitoringAPICallEvent.AttemptCount);
			utf8JsonWriter.WritePropertyName("MaxRetriesExceeded");
			int value = 0;
			if (monitoringAPICallEvent.IsLastExceptionRetryable)
			{
				value = 1;
			}
			utf8JsonWriter.WriteNumberValue(value);
			if (monitoringAPICallEvent.FinalHttpStatusCode.HasValue)
			{
				utf8JsonWriter.WritePropertyName("FinalHttpStatusCode");
				utf8JsonWriter.WriteNumberValue(monitoringAPICallEvent.FinalHttpStatusCode.Value);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallEvent.FinalAWSException))
			{
				utf8JsonWriter.WritePropertyName("FinalAWSException");
				utf8JsonWriter.WriteStringValue(monitoringAPICallEvent.FinalAWSException);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallEvent.FinalSdkException))
			{
				utf8JsonWriter.WritePropertyName("FinalSdkException");
				utf8JsonWriter.WriteStringValue(monitoringAPICallEvent.FinalSdkException);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallEvent.FinalAWSExceptionMessage))
			{
				utf8JsonWriter.WritePropertyName("FinalAWSExceptionMessage");
				utf8JsonWriter.WriteStringValue(monitoringAPICallEvent.FinalAWSExceptionMessage);
			}
			if (!string.IsNullOrEmpty(monitoringAPICallEvent.FinalSdkExceptionMessage))
			{
				utf8JsonWriter.WritePropertyName("FinalSdkExceptionMessage");
				utf8JsonWriter.WriteStringValue(monitoringAPICallEvent.FinalSdkExceptionMessage);
			}
			utf8JsonWriter.WriteEndObject();
			utf8JsonWriter.Flush();
			response = Encoding.UTF8.GetString(memoryStream.ToArray());
			return Encoding.Unicode.GetByteCount(response) <= 8192;
		}

		private static void CreateUDPMessage(MonitoringAPICall monitoringAPICall, Utf8JsonWriter jw)
		{
			_ = string.Empty;
			if (!string.IsNullOrEmpty(monitoringAPICall.Api))
			{
				jw.WritePropertyName("Api");
				jw.WriteStringValue(monitoringAPICall.Api);
			}
			if (!string.IsNullOrEmpty(monitoringAPICall.Service))
			{
				jw.WritePropertyName("Service");
				jw.WriteStringValue(monitoringAPICall.Service);
			}
			if (!string.IsNullOrEmpty(monitoringAPICall.ClientId))
			{
				jw.WritePropertyName("ClientId");
				jw.WriteStringValue(monitoringAPICall.ClientId);
			}
			jw.WritePropertyName("Version");
			jw.WriteNumberValue(monitoringAPICall.Version);
			if (!string.IsNullOrEmpty(monitoringAPICall.Type))
			{
				jw.WritePropertyName("Type");
				jw.WriteStringValue(monitoringAPICall.Type);
			}
			jw.WritePropertyName("Timestamp");
			jw.WriteNumberValue(monitoringAPICall.Timestamp);
			if (!string.IsNullOrEmpty(monitoringAPICall.Region))
			{
				jw.WritePropertyName("Region");
				jw.WriteStringValue(monitoringAPICall.Region);
			}
			if (!string.IsNullOrEmpty(monitoringAPICall.UserAgent))
			{
				jw.WritePropertyName("UserAgent");
				jw.WriteStringValue(monitoringAPICall.UserAgent);
			}
		}
	}
}

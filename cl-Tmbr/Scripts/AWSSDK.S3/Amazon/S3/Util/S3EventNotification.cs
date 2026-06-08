using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Amazon.Runtime;

namespace Amazon.S3.Util
{
	public class S3EventNotification
	{
		public class UserIdentityEntity
		{
			public string PrincipalId { get; set; }
		}

		public class S3BucketEntity
		{
			public string Name { get; set; }

			public UserIdentityEntity OwnerIdentity { get; set; }

			public string Arn { get; set; }
		}

		public class S3ObjectEntity
		{
			public string Key { get; set; }

			public long Size { get; set; }

			public string ETag { get; set; }

			public string VersionId { get; set; }

			public string Sequencer { get; set; }
		}

		public class S3Entity
		{
			public string ConfigurationId { get; set; }

			public S3BucketEntity Bucket { get; set; }

			public S3ObjectEntity Object { get; set; }

			public string S3SchemaVersion { get; set; }
		}

		public class RequestParametersEntity
		{
			public string SourceIPAddress { get; set; }
		}

		public class ResponseElementsEntity
		{
			public string XAmzId2 { get; set; }

			public string XAmzRequestId { get; set; }
		}

		public class S3GlacierEventDataEntity
		{
			public S3RestoreEventDataEntity RestoreEventData { get; set; }
		}

		public class S3RestoreEventDataEntity
		{
			public DateTime LifecycleRestorationExpiryTime { get; set; }

			public string LifecycleRestoreStorageClass { get; set; }
		}

		public class S3EventNotificationRecord
		{
			public string AwsRegion { get; set; }

			public EventType EventName { get; set; }

			public string EventSource { get; set; }

			public DateTime EventTime { get; set; }

			public string EventVersion { get; set; }

			public RequestParametersEntity RequestParameters { get; set; }

			public ResponseElementsEntity ResponseElements { get; set; }

			public S3Entity S3 { get; set; }

			public UserIdentityEntity UserIdentity { get; set; }

			public S3GlacierEventDataEntity GlacierEventData { get; set; }
		}

		public List<S3EventNotificationRecord> Records { get; set; }

		public static S3EventNotification ParseJson(string json)
		{
			try
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(json);
				S3EventNotification s3EventNotification = new S3EventNotification
				{
					Records = new List<S3EventNotificationRecord>()
				};
				if (jsonDocument.RootElement.TryGetProperty("Records", out var value) && value.ValueKind == JsonValueKind.Array)
				{
					foreach (JsonElement item in value.EnumerateArray())
					{
						S3EventNotificationRecord s3EventNotificationRecord = new S3EventNotificationRecord();
						s3EventNotificationRecord.EventVersion = GetValueAsString(item, "eventVersion");
						s3EventNotificationRecord.EventSource = GetValueAsString(item, "eventSource");
						s3EventNotificationRecord.AwsRegion = GetValueAsString(item, "awsRegion");
						if (item.TryGetProperty("eventTime", out var value2) && value2.ValueKind == JsonValueKind.String)
						{
							s3EventNotificationRecord.EventTime = DateTime.Parse(value2.GetString(), CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
						}
						if (item.TryGetProperty("eventName", out var value3) && value3.ValueKind == JsonValueKind.String)
						{
							string text = value3.GetString();
							if (!text.StartsWith("s3:", StringComparison.OrdinalIgnoreCase))
							{
								text = "s3:" + text;
							}
							s3EventNotificationRecord.EventName = EventType.FindValue(text);
						}
						if (item.TryGetProperty("userIdentity", out var value4))
						{
							s3EventNotificationRecord.UserIdentity = new UserIdentityEntity();
							s3EventNotificationRecord.UserIdentity.PrincipalId = GetValueAsString(value4, "principalId");
						}
						if (item.TryGetProperty("requestParameters", out var value5))
						{
							s3EventNotificationRecord.RequestParameters = new RequestParametersEntity();
							s3EventNotificationRecord.RequestParameters.SourceIPAddress = GetValueAsString(value5, "sourceIPAddress");
						}
						if (item.TryGetProperty("responseElements", out var value6))
						{
							s3EventNotificationRecord.ResponseElements = new ResponseElementsEntity();
							s3EventNotificationRecord.ResponseElements.XAmzRequestId = GetValueAsString(value6, "x-amz-request-id");
							s3EventNotificationRecord.ResponseElements.XAmzId2 = GetValueAsString(value6, "x-amz-id-2");
						}
						if (item.TryGetProperty("s3", out var value7))
						{
							s3EventNotificationRecord.S3 = new S3Entity();
							s3EventNotificationRecord.S3.S3SchemaVersion = GetValueAsString(value7, "s3SchemaVersion");
							s3EventNotificationRecord.S3.ConfigurationId = GetValueAsString(value7, "configurationId");
							if (value7.TryGetProperty("bucket", out var value8))
							{
								s3EventNotificationRecord.S3.Bucket = new S3BucketEntity();
								s3EventNotificationRecord.S3.Bucket.Name = GetValueAsString(value8, "name");
								s3EventNotificationRecord.S3.Bucket.Arn = GetValueAsString(value8, "arn");
								if (value8.TryGetProperty("ownerIdentity", out var value9))
								{
									s3EventNotificationRecord.S3.Bucket.OwnerIdentity = new UserIdentityEntity();
									s3EventNotificationRecord.S3.Bucket.OwnerIdentity.PrincipalId = GetValueAsString(value9, "principalId");
								}
							}
							if (value7.TryGetProperty("object", out var value10))
							{
								s3EventNotificationRecord.S3.Object = new S3ObjectEntity();
								s3EventNotificationRecord.S3.Object.Key = GetValueAsString(value10, "key");
								s3EventNotificationRecord.S3.Object.Size = GetValueAsLong(value10, "size");
								s3EventNotificationRecord.S3.Object.ETag = GetValueAsString(value10, "eTag");
								s3EventNotificationRecord.S3.Object.VersionId = GetValueAsString(value10, "versionId");
								s3EventNotificationRecord.S3.Object.Sequencer = GetValueAsString(value10, "sequencer");
							}
						}
						if (item.TryGetProperty("glacierEventData", out var value11))
						{
							s3EventNotificationRecord.GlacierEventData = new S3GlacierEventDataEntity();
							if (value11.TryGetProperty("restoreEventData", out var value12))
							{
								s3EventNotificationRecord.GlacierEventData.RestoreEventData = new S3RestoreEventDataEntity();
								s3EventNotificationRecord.GlacierEventData.RestoreEventData.LifecycleRestorationExpiryTime = GetValueAsDateTime(value12, "lifecycleRestorationExpiryTime").GetValueOrDefault();
								s3EventNotificationRecord.GlacierEventData.RestoreEventData.LifecycleRestoreStorageClass = GetValueAsString(value12, "lifecycleRestoreStorageClass");
							}
						}
						s3EventNotification.Records.Add(s3EventNotificationRecord);
					}
				}
				return s3EventNotification;
			}
			catch (Exception ex)
			{
				throw new AmazonClientException("Failed to parse json string: " + ex.Message, ex);
			}
		}

		private static string GetValueAsString(JsonElement data, string key)
		{
			if (data.TryGetProperty(key, out var value) && value.ValueKind == JsonValueKind.String)
			{
				return value.GetString();
			}
			return null;
		}

		private static DateTime? GetValueAsDateTime(JsonElement data, string key)
		{
			string valueAsString = GetValueAsString(data, key);
			if (string.IsNullOrEmpty(valueAsString))
			{
				return null;
			}
			return DateTime.Parse(valueAsString, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal);
		}

		private static long GetValueAsLong(JsonElement data, string key)
		{
			if (data.TryGetProperty(key, out var value) && value.ValueKind == JsonValueKind.Number && value.TryGetInt64(out var value2))
			{
				return value2;
			}
			return 0L;
		}
	}
}

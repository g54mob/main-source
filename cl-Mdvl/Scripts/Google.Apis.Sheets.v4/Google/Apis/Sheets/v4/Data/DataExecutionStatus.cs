using System;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Google.Apis.Sheets.v4.Data
{
	public class DataExecutionStatus : IDirectResponseSchema
	{
		private string _lastRefreshTimeRaw;

		private object _lastRefreshTime;

		[JsonProperty("errorCode")]
		public virtual string ErrorCode { get; set; }

		[JsonProperty("errorMessage")]
		public virtual string ErrorMessage { get; set; }

		[JsonProperty("lastRefreshTime")]
		public virtual string LastRefreshTimeRaw
		{
			get
			{
				return _lastRefreshTimeRaw;
			}
			set
			{
				_lastRefreshTime = Utilities.DeserializeForGoogleFormat(value);
				_lastRefreshTimeRaw = value;
			}
		}

		[JsonIgnore]
		[Obsolete("This property is obsolete and may behave unexpectedly; please use LastRefreshTimeDateTimeOffset instead.")]
		public virtual object LastRefreshTime
		{
			get
			{
				return _lastRefreshTime;
			}
			set
			{
				_lastRefreshTimeRaw = Utilities.SerializeForGoogleFormat(value);
				_lastRefreshTime = value;
			}
		}

		[JsonIgnore]
		public virtual DateTimeOffset? LastRefreshTimeDateTimeOffset
		{
			get
			{
				return DiscoveryFormat.ParseGoogleDateTimeToDateTimeOffset(LastRefreshTimeRaw);
			}
			set
			{
				LastRefreshTimeRaw = DiscoveryFormat.FormatDateTimeOffsetToGoogleDateTime(value);
			}
		}

		[JsonProperty("state")]
		public virtual string State { get; set; }

		public virtual string ETag { get; set; }
	}
}

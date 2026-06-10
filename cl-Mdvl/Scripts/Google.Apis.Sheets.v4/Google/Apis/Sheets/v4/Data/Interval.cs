using System;
using Google.Apis.Requests;
using Google.Apis.Util;
using Newtonsoft.Json;

namespace Google.Apis.Sheets.v4.Data
{
	public class Interval : IDirectResponseSchema
	{
		private string _endTimeRaw;

		private object _endTime;

		private string _startTimeRaw;

		private object _startTime;

		[JsonProperty("endTime")]
		public virtual string EndTimeRaw
		{
			get
			{
				return _endTimeRaw;
			}
			set
			{
				_endTime = Utilities.DeserializeForGoogleFormat(value);
				_endTimeRaw = value;
			}
		}

		[JsonIgnore]
		[Obsolete("This property is obsolete and may behave unexpectedly; please use EndTimeDateTimeOffset instead.")]
		public virtual object EndTime
		{
			get
			{
				return _endTime;
			}
			set
			{
				_endTimeRaw = Utilities.SerializeForGoogleFormat(value);
				_endTime = value;
			}
		}

		[JsonIgnore]
		public virtual DateTimeOffset? EndTimeDateTimeOffset
		{
			get
			{
				return DiscoveryFormat.ParseGoogleDateTimeToDateTimeOffset(EndTimeRaw);
			}
			set
			{
				EndTimeRaw = DiscoveryFormat.FormatDateTimeOffsetToGoogleDateTime(value);
			}
		}

		[JsonProperty("startTime")]
		public virtual string StartTimeRaw
		{
			get
			{
				return _startTimeRaw;
			}
			set
			{
				_startTime = Utilities.DeserializeForGoogleFormat(value);
				_startTimeRaw = value;
			}
		}

		[JsonIgnore]
		[Obsolete("This property is obsolete and may behave unexpectedly; please use StartTimeDateTimeOffset instead.")]
		public virtual object StartTime
		{
			get
			{
				return _startTime;
			}
			set
			{
				_startTimeRaw = Utilities.SerializeForGoogleFormat(value);
				_startTime = value;
			}
		}

		[JsonIgnore]
		public virtual DateTimeOffset? StartTimeDateTimeOffset
		{
			get
			{
				return DiscoveryFormat.ParseGoogleDateTimeToDateTimeOffset(StartTimeRaw);
			}
			set
			{
				StartTimeRaw = DiscoveryFormat.FormatDateTimeOffsetToGoogleDateTime(value);
			}
		}

		public virtual string ETag { get; set; }
	}
}

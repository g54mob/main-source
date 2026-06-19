using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public class SentryMonitorOptions : ISentryJsonSerializable
	{
		private SentryMonitorScheduleType _type;

		private string? _crontab;

		private int? _interval;

		private SentryMonitorInterval? _unit;

		private static Regex? CrontabValidationInstance;

		private int? _failureIssueThreshold;

		private int? _recoveryThreshold;

		public TimeSpan? CheckInMargin { get; set; }

		public TimeSpan? MaxRuntime { get; set; }

		public int? FailureIssueThreshold
		{
			get
			{
				return _failureIssueThreshold;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("FailureIssueThreshold has to be set to a number greater than 0.");
				}
				_failureIssueThreshold = value;
			}
		}

		public int? RecoveryThreshold
		{
			get
			{
				return _recoveryThreshold;
			}
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("RecoveryThreshold has to be set to a number greater than 0.");
				}
				_recoveryThreshold = value;
			}
		}

		public string? TimeZone { get; set; }

		public string? Owner { get; set; }

		private static Regex CrontabValidation()
		{
			return CrontabValidationInstance ?? (CrontabValidationInstance = new Regex("^(\\*|([0-5]?\\d))(\\s+)(\\*|([01]?\\d|2[0-3]))(\\s+)(\\*|([1-9]|[12]\\d|3[01]))(\\s+)(\\*|([1-9]|1[0-2]))(\\s+)(\\*|([0-7]))$", RegexOptions.Compiled | RegexOptions.CultureInvariant));
		}

		public void Interval(string crontab)
		{
			if (_type != SentryMonitorScheduleType.None)
			{
				throw new ArgumentException("You tried to set the interval twice. The Check-Ins interval is supposed to be set only once.");
			}
			if (!CrontabValidation().IsMatch(crontab))
			{
				throw new ArgumentException("The provided crontab does not match the expected format of '* * * * *' translating to 'minute', 'hour', 'day of the month', 'month', and 'day of the week'.");
			}
			_type = SentryMonitorScheduleType.Crontab;
			_crontab = crontab;
		}

		public void Interval(int interval, SentryMonitorInterval unit)
		{
			if (_type != SentryMonitorScheduleType.None)
			{
				throw new ArgumentException("You tried to set the interval twice. The Check-Ins interval is supposed to be set only once.");
			}
			_type = SentryMonitorScheduleType.Interval;
			_interval = interval;
			_unit = unit;
		}

		internal SentryMonitorOptions()
		{
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject("monitor_config");
			writer.WriteStartObject("schedule");
			writer.WriteString("type", TypeToString(_type));
			switch (_type)
			{
			case SentryMonitorScheduleType.Crontab:
				writer.WriteStringIfNotWhiteSpace("value", _crontab);
				break;
			case SentryMonitorScheduleType.Interval:
				writer.WriteNumberIfNotNull("value", _interval);
				writer.WriteStringIfNotWhiteSpace("unit", _unit.ToString().ToLower());
				break;
			default:
				logger?.LogError("Invalid MonitorScheduleType: '{0}'", _type.ToString());
				break;
			}
			writer.WriteEndObject();
			writer.WriteNumberIfNotNull("checkin_margin", CheckInMargin?.TotalMinutes);
			writer.WriteNumberIfNotNull("max_runtime", MaxRuntime?.TotalMinutes);
			writer.WriteNumberIfNotNull("failure_issue_threshold", FailureIssueThreshold);
			writer.WriteNumberIfNotNull("recovery_threshold", RecoveryThreshold);
			writer.WriteStringIfNotWhiteSpace("timezone", TimeZone);
			writer.WriteStringIfNotWhiteSpace("owner", Owner);
			writer.WriteEndObject();
		}

		private static string TypeToString(SentryMonitorScheduleType type)
		{
			return type switch
			{
				SentryMonitorScheduleType.Crontab => "crontab", 
				SentryMonitorScheduleType.Interval => "interval", 
				_ => throw new ArgumentException($"Unsupported Monitor Schedule Type: '{type}'."), 
			};
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry
{
	[DebuggerDisplay("Message: {Message}, Type: {Type}")]
	public sealed class Breadcrumb : ISentryJsonSerializable
	{
		private readonly IReadOnlyDictionary<string, string>? _data;

		private readonly string? _message;

		private bool _sendDefaultPii = true;

		public DateTimeOffset Timestamp { get; }

		public string? Message
		{
			get
			{
				if (!_sendDefaultPii)
				{
					return _message?.RedactUrl();
				}
				return _message;
			}
			private init
			{
				_message = value;
			}
		}

		public string? Type { get; }

		public IReadOnlyDictionary<string, string>? Data
		{
			get
			{
				if (!_sendDefaultPii)
				{
					return _data?.ToDictionary((KeyValuePair<string, string> x) => x.Key, (KeyValuePair<string, string> x) => x.Value.RedactUrl());
				}
				return _data;
			}
			private init
			{
				_data = value;
			}
		}

		public string? Category { get; }

		public BreadcrumbLevel Level { get; }

		internal void Redact()
		{
			_sendDefaultPii = false;
		}

		public Breadcrumb(string message, string type, IReadOnlyDictionary<string, string>? data = null, string? category = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
			: this(null, message, type, data, category, level)
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Breadcrumb(DateTimeOffset? timestamp = null, string? message = null, string? type = null, IReadOnlyDictionary<string, string>? data = null, string? category = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			Timestamp = timestamp ?? DateTimeOffset.UtcNow;
			Message = message;
			Type = type;
			Data = data;
			Category = category;
			Level = level;
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("timestamp", Timestamp.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ", DateTimeFormatInfo.InvariantInfo));
			writer.WriteStringIfNotWhiteSpace("message", Message);
			writer.WriteStringIfNotWhiteSpace("type", Type);
			writer.WriteStringDictionaryIfNotEmpty("data", Data);
			writer.WriteStringIfNotWhiteSpace("category", Category);
			writer.WriteStringIfNotWhiteSpace("level", Level.NullIfDefault()?.ToString().ToLowerInvariant());
			writer.WriteEndObject();
		}

		public static Breadcrumb FromJson(JsonElement json)
		{
			DateTimeOffset? timestamp = json.GetPropertyOrNull("timestamp")?.GetDateTimeOffset();
			string message = json.GetPropertyOrNull("message")?.GetString();
			string type = json.GetPropertyOrNull("type")?.GetString();
			Dictionary<string, string> data = json.GetPropertyOrNull("data")?.GetStringDictionaryOrNull();
			string category = json.GetPropertyOrNull("category")?.GetString();
			BreadcrumbLevel valueOrDefault = (json.GetPropertyOrNull("level")?.GetString()?.ParseEnum<BreadcrumbLevel>()).GetValueOrDefault();
			return new Breadcrumb(timestamp, message, type, data, category, valueOrDefault);
		}
	}
}

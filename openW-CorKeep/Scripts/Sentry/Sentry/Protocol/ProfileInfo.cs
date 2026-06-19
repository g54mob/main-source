using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	internal sealed class ProfileInfo : ISentryJsonSerializable
	{
		private readonly SentryContexts _contexts = new SentryContexts();

		public SentryId EventId { get; private set; } = SentryId.Create();

		public DebugMeta DebugMeta { get; set; } = new DebugMeta
		{
			Images = new List<DebugImage>()
		};

		public SentryContexts Contexts
		{
			get
			{
				return _contexts;
			}
			set
			{
				_contexts.ReplaceWith(value);
			}
		}

		public SampleProfile Profile { get; set; } = new SampleProfile();

		public DateTimeOffset StartTimestamp { get; set; } = DateTimeOffset.UtcNow;

		public string? Environment { get; set; }

		public string? Platform { get; set; } = "csharp";

		public string? Release { get; set; }

		public SentryTransaction? Transaction { get; set; }

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("version", "1");
			writer.WriteSerializable("event_id", EventId, logger);
			writer.WriteString("timestamp", StartTimestamp);
			writer.WriteStringIfNotWhiteSpace("platform", Platform);
			writer.WriteStringIfNotWhiteSpace("release", Release);
			writer.WriteStringIfNotWhiteSpace("environment", Environment);
			List<DebugImage>? images = DebugMeta.Images;
			if (images != null && images.Count > 0)
			{
				writer.WriteSerializable("debug_meta", DebugMeta, logger);
			}
			writer.WriteStartObject("device");
			writer.WriteString("architecture", _contexts.Device.Architecture ?? "");
			writer.WriteStringIfNotWhiteSpace("manufacturer", _contexts.Device.Manufacturer);
			writer.WriteStringIfNotWhiteSpace("model", _contexts.Device.Model);
			writer.WriteEndObject();
			string? rawDescription = _contexts.OperatingSystem.RawDescription;
			object obj;
			if (rawDescription == null)
			{
				obj = null;
			}
			else
			{
				string text = rawDescription.Replace("Microsoft Windows", "Windows");
				obj = ((text != null) ? PolyfillExtensions.Split(text, ' ', 2) : null);
			}
			string[] array = (string[])obj;
			writer.WriteStartObject("os");
			writer.WriteString("name", _contexts.OperatingSystem.Name ?? array?.First() ?? "");
			writer.WriteString("version", _contexts.OperatingSystem.Version ?? array?.Last() ?? "");
			writer.WriteEndObject();
			writer.WriteSerializable("runtime", _contexts.Runtime, logger);
			if (Transaction != null)
			{
				writer.WriteStartObject("transaction");
				writer.WriteString("active_thread_id", "0");
				writer.WriteSerializable("id", Transaction.EventId, logger);
				writer.WriteString("name", Transaction.Name);
				writer.WriteSerializable("trace_id", Transaction.TraceId, logger);
				writer.WriteEndObject();
			}
			writer.WriteSerializable("profile", Profile, logger);
			writer.WriteEndObject();
		}
	}
}

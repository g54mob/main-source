using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Protocol;

namespace Sentry
{
	[DebuggerDisplay("{GetType().Name,nq}: {EventId,nq}")]
	public sealed class SentryEvent : IEventLike, IHasTags, IHasExtra, ISentryJsonSerializable
	{
		private IDictionary<string, string>? _modules;

		private DebugMeta? _debugMeta;

		private SentryRequest? _request;

		private readonly SentryContexts _contexts = new SentryContexts();

		private SentryUser? _user;

		private IReadOnlyList<string>? _fingerprint;

		private List<Breadcrumb>? _breadcrumbs;

		private Dictionary<string, object?>? _extra;

		private Dictionary<string, string>? _tags;

		public Exception? Exception { get; }

		public SentryId EventId { get; }

		public DateTimeOffset Timestamp { get; }

		public SentryMessage? Message { get; set; }

		public string? Logger { get; set; }

		public string? Platform { get; set; }

		public string? ServerName { get; set; }

		public string? Release { get; set; }

		public string? Distribution { get; set; }

		internal SentryValues<SentryException>? SentryExceptionValues { get; set; }

		public IEnumerable<SentryException>? SentryExceptions
		{
			get
			{
				return SentryExceptionValues?.Values ?? Enumerable.Empty<SentryException>();
			}
			set
			{
				SentryExceptionValues = ((value != null) ? new SentryValues<SentryException>(value) : null);
			}
		}

		private SentryValues<SentryThread>? SentryThreadValues { get; set; }

		public IEnumerable<SentryThread>? SentryThreads
		{
			get
			{
				return SentryThreadValues?.Values ?? Enumerable.Empty<SentryThread>();
			}
			set
			{
				SentryThreadValues = ((value != null) ? new SentryValues<SentryThread>(value) : null);
			}
		}

		public List<DebugImage>? DebugImages
		{
			get
			{
				return _debugMeta?.Images;
			}
			set
			{
				if (_debugMeta == null)
				{
					_debugMeta = new DebugMeta();
				}
				_debugMeta.Images = value;
			}
		}

		public IDictionary<string, string> Modules => _modules ?? (_modules = new Dictionary<string, string>());

		public SentryLevel? Level { get; set; }

		public string? TransactionName { get; set; }

		public SentryRequest Request
		{
			get
			{
				return _request ?? (_request = new SentryRequest());
			}
			set
			{
				_request = value;
			}
		}

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

		public SentryUser User
		{
			get
			{
				return _user ?? (_user = new SentryUser());
			}
			set
			{
				_user = value;
			}
		}

		public string? Environment { get; set; }

		public SdkVersion Sdk { get; internal set; } = new SdkVersion();

		public IReadOnlyList<string> Fingerprint
		{
			get
			{
				return _fingerprint ?? Array.Empty<string>();
			}
			set
			{
				_fingerprint = value;
			}
		}

		public IReadOnlyCollection<Breadcrumb> Breadcrumbs => _breadcrumbs ?? (_breadcrumbs = new List<Breadcrumb>());

		public IReadOnlyDictionary<string, object?> Extra => _extra ?? (_extra = new Dictionary<string, object>());

		public IReadOnlyDictionary<string, string> Tags => _tags ?? (_tags = new Dictionary<string, string>());

		internal DynamicSamplingContext? DynamicSamplingContext { get; set; }

		internal bool HasException()
		{
			if (Exception == null)
			{
				return SentryExceptions?.Any() ?? false;
			}
			return true;
		}

		internal bool HasTerminalException()
		{
			object obj = Exception?.Data[Mechanism.HandledKey];
			if (obj is bool && !(bool)obj)
			{
				return Exception.Data[Mechanism.MechanismKey] as string != "UnobservedTaskException";
			}
			return SentryExceptions?.Any(delegate(SentryException e)
			{
				Mechanism mechanism = e.Mechanism;
				return mechanism != null && ((!mechanism.Handled) ?? false) && mechanism.Type != "UnobservedTaskException";
			}) ?? false;
		}

		public SentryEvent()
			: this(null)
		{
		}

		public SentryEvent(Exception? exception)
			: this(exception, null, default(SentryId))
		{
		}

		internal SentryEvent(Exception? exception = null, DateTimeOffset? timestamp = null, SentryId eventId = default(SentryId))
		{
			Exception = exception;
			Timestamp = timestamp ?? DateTimeOffset.UtcNow;
			EventId = ((eventId != default(SentryId)) ? eventId : SentryId.Create());
			Platform = "csharp";
		}

		public void AddBreadcrumb(Breadcrumb breadcrumb)
		{
			(_breadcrumbs ?? (_breadcrumbs = new List<Breadcrumb>())).Add(breadcrumb);
		}

		public void SetExtra(string key, object? value)
		{
			(_extra ?? (_extra = new Dictionary<string, object>()))[key] = value;
		}

		public void SetTag(string key, string value)
		{
			(_tags ?? (_tags = new Dictionary<string, string>()))[key] = value;
		}

		public void UnsetTag(string key)
		{
			(_tags ?? (_tags = new Dictionary<string, string>())).Remove(key);
		}

		internal void Redact()
		{
			foreach (Breadcrumb breadcrumb in Breadcrumbs)
			{
				breadcrumb.Redact();
			}
		}

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteStringDictionaryIfNotEmpty("modules", _modules);
			writer.WriteSerializable("event_id", EventId, logger);
			writer.WriteString("timestamp", Timestamp);
			writer.WriteSerializableIfNotNull("logentry", Message, logger);
			writer.WriteStringIfNotWhiteSpace("logger", Logger);
			writer.WriteStringIfNotWhiteSpace("platform", Platform);
			writer.WriteStringIfNotWhiteSpace("server_name", ServerName);
			writer.WriteStringIfNotWhiteSpace("release", Release);
			writer.WriteStringIfNotWhiteSpace("dist", Distribution);
			writer.WriteSerializableIfNotNull("exception", SentryExceptionValues, logger);
			writer.WriteSerializableIfNotNull("threads", SentryThreadValues, logger);
			writer.WriteStringIfNotWhiteSpace("level", Level?.ToString().ToLowerInvariant());
			writer.WriteStringIfNotWhiteSpace("transaction", TransactionName);
			writer.WriteSerializableIfNotNull("request", _request, logger);
			writer.WriteSerializableIfNotNull("contexts", _contexts.NullIfEmpty(), logger);
			writer.WriteSerializableIfNotNull("user", _user, logger);
			writer.WriteStringIfNotWhiteSpace("environment", Environment);
			writer.WriteSerializable("sdk", Sdk, logger);
			writer.WriteStringArrayIfNotEmpty("fingerprint", _fingerprint);
			writer.WriteArrayIfNotEmpty("breadcrumbs", _breadcrumbs, logger);
			writer.WriteDictionaryIfNotEmpty("extra", _extra, logger);
			writer.WriteStringDictionaryIfNotEmpty("tags", _tags);
			writer.WriteSerializableIfNotNull("debug_meta", _debugMeta, logger);
			writer.WriteEndObject();
		}

		public static SentryEvent FromJson(JsonElement json)
		{
			return FromJson(json, null);
		}

		internal static SentryEvent FromJson(JsonElement json, Exception? exception)
		{
			Dictionary<string, string> dictionary = json.GetPropertyOrNull("modules")?.GetStringDictionaryOrNull();
			SentryId eventId = json.GetPropertyOrNull("event_id")?.Pipe(SentryId.FromJson) ?? SentryId.Empty;
			DateTimeOffset? timestamp = json.GetPropertyOrNull("timestamp")?.GetDateTimeOffset();
			SentryMessage message = json.GetPropertyOrNull("logentry")?.Pipe(SentryMessage.FromJson);
			string logger = json.GetPropertyOrNull("logger")?.GetString();
			string platform = json.GetPropertyOrNull("platform")?.GetString();
			string serverName = json.GetPropertyOrNull("server_name")?.GetString();
			string release = json.GetPropertyOrNull("release")?.GetString();
			string distribution = json.GetPropertyOrNull("dist")?.GetString();
			JsonElement? propertyOrNull = json.GetPropertyOrNull("exception");
			object obj;
			if (!propertyOrNull.HasValue)
			{
				obj = null;
			}
			else
			{
				JsonElement? propertyOrNull2 = propertyOrNull.GetValueOrDefault().GetPropertyOrNull("values");
				obj = (propertyOrNull2.HasValue ? propertyOrNull2.GetValueOrDefault().EnumerateArray().Select(SentryException.FromJson)
					.ToList()
					.Pipe((List<SentryException> v) => new SentryValues<SentryException>(v)) : null);
			}
			SentryValues<SentryException> sentryExceptionValues = (SentryValues<SentryException>)obj;
			propertyOrNull = json.GetPropertyOrNull("threads");
			object obj2;
			if (!propertyOrNull.HasValue)
			{
				obj2 = null;
			}
			else
			{
				JsonElement? propertyOrNull2 = propertyOrNull.GetValueOrDefault().GetPropertyOrNull("values");
				obj2 = (propertyOrNull2.HasValue ? propertyOrNull2.GetValueOrDefault().EnumerateArray().Select(SentryThread.FromJson)
					.ToList()
					.Pipe((List<SentryThread> v) => new SentryValues<SentryThread>(v)) : null);
			}
			SentryValues<SentryThread> sentryThreadValues = (SentryValues<SentryThread>)obj2;
			SentryLevel? level = json.GetPropertyOrNull("level")?.GetString()?.ParseEnum<SentryLevel>();
			string transactionName = json.GetPropertyOrNull("transaction")?.GetString();
			SentryRequest request = json.GetPropertyOrNull("request")?.Pipe(SentryRequest.FromJson);
			SentryContexts sentryContexts = json.GetPropertyOrNull("contexts")?.Pipe(SentryContexts.FromJson);
			SentryUser user = json.GetPropertyOrNull("user")?.Pipe(SentryUser.FromJson);
			string environment = json.GetPropertyOrNull("environment")?.GetString();
			SdkVersion sdk = json.GetPropertyOrNull("sdk")?.Pipe(SdkVersion.FromJson) ?? new SdkVersion();
			propertyOrNull = json.GetPropertyOrNull("fingerprint");
			string[] fingerprint = (propertyOrNull.HasValue ? (from j in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select j.GetString()).ToArray() : null);
			propertyOrNull = json.GetPropertyOrNull("breadcrumbs");
			List<Breadcrumb> breadcrumbs = (propertyOrNull.HasValue ? propertyOrNull.GetValueOrDefault().EnumerateArray().Select(Breadcrumb.FromJson)
				.ToList() : null);
			Dictionary<string, object> dictionary2 = json.GetPropertyOrNull("extra")?.GetDictionaryOrNull();
			Dictionary<string, string> dictionary3 = json.GetPropertyOrNull("tags")?.GetStringDictionaryOrNull();
			DebugMeta debugMeta = json.GetPropertyOrNull("debug_meta")?.Pipe(DebugMeta.FromJson);
			return new SentryEvent(exception, timestamp, eventId)
			{
				_modules = dictionary?.WhereNotNullValue().ToDict(),
				Message = message,
				Logger = logger,
				Platform = platform,
				ServerName = serverName,
				Release = release,
				Distribution = distribution,
				SentryExceptionValues = sentryExceptionValues,
				SentryThreadValues = sentryThreadValues,
				_debugMeta = debugMeta,
				Level = level,
				TransactionName = transactionName,
				_request = request,
				Contexts = (sentryContexts ?? new SentryContexts()),
				_user = user,
				Environment = environment,
				Sdk = sdk,
				_fingerprint = fingerprint,
				_breadcrumbs = breadcrumbs,
				_extra = dictionary2?.ToDict(),
				_tags = dictionary3?.WhereNotNullValue().ToDict()
			};
		}
	}
}

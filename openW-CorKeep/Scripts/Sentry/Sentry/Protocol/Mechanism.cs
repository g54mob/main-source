using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry.Protocol
{
	public sealed class Mechanism : ISentryJsonSerializable
	{
		public static readonly string HandledKey = "Sentry:Handled";

		public static readonly string MechanismKey = "Sentry:Mechanism";

		public static readonly string DescriptionKey = "Sentry:Description";

		private const string DefaultType = "generic";

		private string _type = "generic";

		internal Dictionary<string, object>? InternalData { get; private set; }

		internal Dictionary<string, object>? InternalMeta { get; private set; }

		public string Type
		{
			get
			{
				return _type;
			}
			[param: AllowNull]
			set
			{
				_type = (string.IsNullOrWhiteSpace(value) ? "generic" : value);
			}
		}

		public string? Description { get; set; }

		public string? Source { get; set; }

		public string? HelpLink { get; set; }

		public bool? Handled { get; set; }

		public bool Synthetic { get; set; }

		public bool IsExceptionGroup { get; set; }

		public int? ExceptionId { get; set; }

		public int? ParentId { get; set; }

		public IDictionary<string, object> Meta => InternalMeta ?? (InternalMeta = new Dictionary<string, object>());

		public IDictionary<string, object> Data => InternalData ?? (InternalData = new Dictionary<string, object>());

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteString("type", Type);
			writer.WriteStringIfNotWhiteSpace("description", Description);
			writer.WriteStringIfNotWhiteSpace("source", Source);
			writer.WriteStringIfNotWhiteSpace("help_link", HelpLink);
			writer.WriteBooleanIfNotNull("handled", Handled);
			writer.WriteBooleanIfTrue("synthetic", Synthetic);
			writer.WriteBooleanIfTrue("is_exception_group", IsExceptionGroup);
			writer.WriteNumberIfNotNull("exception_id", ExceptionId);
			writer.WriteNumberIfNotNull("parent_id", ParentId);
			writer.WriteDictionaryIfNotEmpty("data", InternalData, logger);
			writer.WriteDictionaryIfNotEmpty("meta", InternalMeta, logger);
			writer.WriteEndObject();
		}

		public static Mechanism FromJson(JsonElement json)
		{
			string type = json.GetPropertyOrNull("type")?.GetString();
			string description = json.GetPropertyOrNull("description")?.GetString();
			string source = json.GetPropertyOrNull("source")?.GetString();
			string helpLink = json.GetPropertyOrNull("help_link")?.GetString();
			bool? handled = json.GetPropertyOrNull("handled")?.GetBoolean();
			bool synthetic = json.GetPropertyOrNull("synthetic")?.GetBoolean() ?? false;
			bool isExceptionGroup = json.GetPropertyOrNull("is_exception_group")?.GetBoolean() ?? false;
			int? exceptionId = json.GetPropertyOrNull("exception_id")?.GetInt32();
			int? parentId = json.GetPropertyOrNull("parent_id")?.GetInt32();
			Dictionary<string, object> dictionary = json.GetPropertyOrNull("data")?.GetDictionaryOrNull();
			Dictionary<string, object> dictionary2 = json.GetPropertyOrNull("meta")?.GetDictionaryOrNull();
			return new Mechanism
			{
				Type = type,
				Description = description,
				Source = source,
				HelpLink = helpLink,
				Handled = handled,
				Synthetic = synthetic,
				IsExceptionGroup = isExceptionGroup,
				ExceptionId = exceptionId,
				ParentId = parentId,
				InternalData = dictionary?.WhereNotNullValue().ToDict(),
				InternalMeta = dictionary2?.WhereNotNullValue().ToDict()
			};
		}

		internal bool IsDefaultOrEmpty()
		{
			if (!Handled.HasValue && !Synthetic && !IsExceptionGroup && !ExceptionId.HasValue && !ParentId.HasValue && Type == "generic" && string.IsNullOrWhiteSpace(Description) && string.IsNullOrWhiteSpace(HelpLink) && string.IsNullOrWhiteSpace(Source))
			{
				Dictionary<string, object>? internalData = InternalData;
				if (internalData == null || internalData.Count <= 0)
				{
					Dictionary<string, object>? internalMeta = InternalMeta;
					return internalMeta == null || internalMeta.Count <= 0;
				}
			}
			return false;
		}
	}
}

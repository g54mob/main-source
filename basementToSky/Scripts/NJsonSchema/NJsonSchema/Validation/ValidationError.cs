using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation
{
	public class ValidationError
	{
		public ValidationErrorKind Kind { get; private set; }

		public string Property { get; private set; }

		public string Path { get; private set; }

		public bool HasLineInfo { get; private set; }

		public int LineNumber { get; private set; }

		public int LinePosition { get; private set; }

		public JsonSchema Schema { get; private set; }

		public ValidationError(ValidationErrorKind errorKind, string propertyName, string propertyPath, JToken token, JsonSchema schema)
		{
			Kind = errorKind;
			Property = propertyName;
			Path = ((propertyPath != null) ? ("#/" + propertyPath) : "#");
			HasLineInfo = ((IJsonLineInfo)token)?.HasLineInfo() ?? false;
			if (HasLineInfo)
			{
				LineNumber = ((IJsonLineInfo)token).LineNumber;
				LinePosition = ((IJsonLineInfo)token).LinePosition;
			}
			else
			{
				LineNumber = 0;
				LinePosition = 0;
			}
			Schema = schema;
		}

		public override string ToString()
		{
			return $"{Kind}: {Path}";
		}
	}
}

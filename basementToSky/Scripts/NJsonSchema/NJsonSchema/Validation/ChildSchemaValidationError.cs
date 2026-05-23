using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation
{
	public class ChildSchemaValidationError : ValidationError
	{
		public IReadOnlyDictionary<JsonSchema, ICollection<ValidationError>> Errors { get; private set; }

		public ChildSchemaValidationError(ValidationErrorKind kind, string property, string path, IReadOnlyDictionary<JsonSchema, ICollection<ValidationError>> errors, JToken token, JsonSchema schema)
			: base(kind, property, path, token, schema)
		{
			Errors = errors;
		}

		public override string ToString()
		{
			string text = $"{base.Kind}: {base.Path}\n";
			foreach (KeyValuePair<JsonSchema, ICollection<ValidationError>> error in Errors)
			{
				text += "{\n";
				foreach (ValidationError item in error.Value)
				{
					text += string.Format("  {0}\n", item.ToString().Replace("\n", "\n  "));
				}
				text += "}\n";
			}
			return text;
		}
	}
}

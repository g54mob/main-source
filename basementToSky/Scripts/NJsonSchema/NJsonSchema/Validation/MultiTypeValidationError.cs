using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation
{
	public class MultiTypeValidationError : ValidationError
	{
		public IReadOnlyDictionary<JsonObjectType, ICollection<ValidationError>> Errors { get; private set; }

		public MultiTypeValidationError(ValidationErrorKind kind, string property, string path, IReadOnlyDictionary<JsonObjectType, ICollection<ValidationError>> errors, JToken token, JsonSchema schema)
			: base(kind, property, path, token, schema)
		{
			Errors = errors;
		}

		public override string ToString()
		{
			string text = $"{base.Kind}: {base.Path}\n";
			foreach (KeyValuePair<JsonObjectType, ICollection<ValidationError>> error in Errors)
			{
				text = text + "{" + error.Key.ToString() + ":\n";
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

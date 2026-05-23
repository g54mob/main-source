using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public interface IFormatValidator
	{
		ValidationErrorKind ValidationErrorKind { get; }

		string Format { get; }

		bool IsValid(string value, JTokenType tokenType);
	}
}

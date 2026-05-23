using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class Base64FormatValidator : IFormatValidator
	{
		private readonly ByteFormatValidator _byteFormatValidator = new ByteFormatValidator();

		public string Format { get; } = "base64";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.Base64Expected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			return _byteFormatValidator.IsValid(value, tokenType);
		}
	}
}

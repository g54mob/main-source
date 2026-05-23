using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class ByteFormatValidator : IFormatValidator
	{
		private const string Base64Expression = "^[a-zA-Z0-9\\+/]*={0,3}$";

		public string Format { get; } = "byte";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.Base64Expected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			if (value.Length % 4 == 0)
			{
				return Regex.IsMatch(value, "^[a-zA-Z0-9\\+/]*={0,3}$", RegexOptions.None);
			}
			return false;
		}
	}
}

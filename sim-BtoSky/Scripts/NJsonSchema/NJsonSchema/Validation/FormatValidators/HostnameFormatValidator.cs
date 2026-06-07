using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class HostnameFormatValidator : IFormatValidator
	{
		private const string HostnameExpression = "^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\\-]*[a-zA-Z0-9])\\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\\-]*[A-Za-z0-9])$";

		public string Format { get; } = "hostname";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.HostnameExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			return Regex.IsMatch(value, "^(([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\\-]*[a-zA-Z0-9])\\.)*([A-Za-z0-9]|[A-Za-z0-9][A-Za-z0-9\\-]*[A-Za-z0-9])$", RegexOptions.IgnoreCase);
		}
	}
}

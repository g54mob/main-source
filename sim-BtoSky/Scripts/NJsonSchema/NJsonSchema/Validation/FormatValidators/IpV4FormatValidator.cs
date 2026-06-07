using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class IpV4FormatValidator : IFormatValidator
	{
		private const string IpV4RegexExpression = "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

		public string Format { get; } = "ipv4";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.IpV4Expected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			return Regex.IsMatch(value, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?).){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$", RegexOptions.IgnoreCase);
		}
	}
}

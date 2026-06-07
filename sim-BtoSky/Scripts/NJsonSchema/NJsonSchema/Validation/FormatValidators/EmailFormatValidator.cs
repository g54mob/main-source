using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class EmailFormatValidator : IFormatValidator
	{
		private const string EmailRegexExpression = "^\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z$";

		public string Format { get; } = "email";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.EmailExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			return Regex.IsMatch(value, "^\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z$", RegexOptions.IgnoreCase);
		}
	}
}

using System;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class UuidFormatValidator : IFormatValidator
	{
		public string Format { get; } = "uuid";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.UuidExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			Guid result;
			return Guid.TryParse(value, out result);
		}
	}
}

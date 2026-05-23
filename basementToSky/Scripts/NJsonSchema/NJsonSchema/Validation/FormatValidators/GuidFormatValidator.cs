using System;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class GuidFormatValidator : IFormatValidator
	{
		public string Format { get; } = "guid";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.GuidExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			Guid result;
			return Guid.TryParse(value, out result);
		}
	}
}

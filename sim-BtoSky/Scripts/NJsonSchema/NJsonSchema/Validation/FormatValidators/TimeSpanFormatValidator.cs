using System;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class TimeSpanFormatValidator : IFormatValidator
	{
		public string Format { get; } = "time-span";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.TimeSpanExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			TimeSpan result;
			if (tokenType != JTokenType.TimeSpan)
			{
				return TimeSpan.TryParse(value, out result);
			}
			return true;
		}
	}
}

using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class TimeFormatValidator : IFormatValidator
	{
		public string Format { get; } = "time";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.TimeExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			DateTime result;
			if (tokenType != JTokenType.Date)
			{
				return DateTime.TryParseExact(value, "HH:mm:ss.FFFFFFFK", null, DateTimeStyles.None, out result);
			}
			return true;
		}
	}
}

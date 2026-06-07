using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class DateFormatValidator : IFormatValidator
	{
		public string Format { get; } = "date";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.DateExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			if (tokenType != JTokenType.Date)
			{
				if (DateTime.TryParseExact(value, "yyyy-MM-dd", null, DateTimeStyles.None, out var result))
				{
					return result.Date == result;
				}
				return false;
			}
			return true;
		}
	}
}

using System;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class DateTimeFormatValidator : IFormatValidator
	{
		private readonly string[] _acceptableFormats = new string[15]
		{
			"yyyy-MM-dd'T'HH:mm:ss.FFFFFFFK", "yyyy-MM-dd' 'HH:mm:ss.FFFFFFFK", "yyyy-MM-dd'T'HH:mm:ssK", "yyyy-MM-dd' 'HH:mm:ssK", "yyyy-MM-dd'T'HH:mm:ss", "yyyy-MM-dd' 'HH:mm:ss", "yyyy-MM-dd'T'HH:mm", "yyyy-MM-dd' 'HH:mm", "yyyy-MM-dd'T'HH", "yyyy-MM-dd' 'HH",
			"yyyy-MM-dd", "yyyy-MM-dd", "yyyyMMdd", "yyyy-MM", "yyyy"
		};

		public string Format { get; } = "date-time";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.DateTimeExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			DateTimeOffset result;
			if (tokenType != JTokenType.Date)
			{
				return DateTimeOffset.TryParseExact(value, _acceptableFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
			}
			return true;
		}
	}
}

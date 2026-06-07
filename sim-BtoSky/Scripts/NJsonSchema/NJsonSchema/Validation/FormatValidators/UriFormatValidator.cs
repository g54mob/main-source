using System;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class UriFormatValidator : IFormatValidator
	{
		public string Format { get; } = "uri";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.UriExpected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			Uri result;
			if (tokenType != JTokenType.Uri)
			{
				return Uri.TryCreate(value, UriKind.Absolute, out result);
			}
			return true;
		}
	}
}

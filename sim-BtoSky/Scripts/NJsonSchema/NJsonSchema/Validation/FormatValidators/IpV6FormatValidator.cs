using System;
using Newtonsoft.Json.Linq;

namespace NJsonSchema.Validation.FormatValidators
{
	public class IpV6FormatValidator : IFormatValidator
	{
		public string Format { get; } = "ipv6";

		public ValidationErrorKind ValidationErrorKind { get; } = ValidationErrorKind.IpV6Expected;

		public bool IsValid(string value, JTokenType tokenType)
		{
			return Uri.CheckHostName(value) == UriHostNameType.IPv6;
		}
	}
}

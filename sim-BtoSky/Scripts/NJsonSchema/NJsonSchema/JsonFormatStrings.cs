using System;

namespace NJsonSchema
{
	public static class JsonFormatStrings
	{
		public const string DateTime = "date-time";

		public const string TimeSpan = "time-span";

		public const string Duration = "duration";

		public const string Email = "email";

		public const string Uri = "uri";

		public const string Guid = "guid";

		[Obsolete("Now made redundant. Use \"guid\" instead.")]
		public const string Uuid = "uuid";

		public const string Integer = "int32";

		public const string Long = "int64";

		public const string Double = "double";

		public const string Float = "float";

		public const string Decimal = "decimal";

		public const string IpV4 = "ipv4";

		public const string IpV6 = "ipv6";

		[Obsolete("Now made redundant. Use \"byte\" instead.")]
		public const string Base64 = "base64";

		public const string Byte = "byte";

		public const string Binary = "binary";

		public const string Hostname = "hostname";

		public const string Phone = "phone";

		public const string Date = "date";

		public const string Time = "time";
	}
}

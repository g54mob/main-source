namespace Utf8Json.Resolvers
{
	public static class StandardResolver
	{
		public static readonly IJsonFormatterResolver Default;

		public static readonly IJsonFormatterResolver CamelCase;

		public static readonly IJsonFormatterResolver SnakeCase;

		public static readonly IJsonFormatterResolver ExcludeNull;

		public static readonly IJsonFormatterResolver ExcludeNullCamelCase;

		public static readonly IJsonFormatterResolver ExcludeNullSnakeCase;

		public static readonly IJsonFormatterResolver AllowPrivate;

		public static readonly IJsonFormatterResolver AllowPrivateCamelCase;

		public static readonly IJsonFormatterResolver AllowPrivateSnakeCase;

		public static readonly IJsonFormatterResolver AllowPrivateExcludeNull;

		public static readonly IJsonFormatterResolver AllowPrivateExcludeNullCamelCase;

		public static readonly IJsonFormatterResolver AllowPrivateExcludeNullSnakeCase;
	}
}

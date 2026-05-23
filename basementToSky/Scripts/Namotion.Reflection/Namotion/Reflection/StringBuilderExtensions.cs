using System.Text;

namespace Namotion.Reflection
{
	internal static class StringBuilderExtensions
	{
		public static StringBuilder Append(this StringBuilder stringBuilder, params string?[] values)
		{
			foreach (string value in values)
			{
				if (!string.IsNullOrEmpty(value))
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder;
		}

		public static StringBuilder Append(this StringBuilder stringBuilder, string? value1, string? value2, string? value3 = null, string? value4 = null, string? value5 = null, string? value6 = null)
		{
			AppendStringToStringBuilder(stringBuilder, value1);
			AppendStringToStringBuilder(stringBuilder, value2);
			AppendStringToStringBuilder(stringBuilder, value3);
			AppendStringToStringBuilder(stringBuilder, value4);
			AppendStringToStringBuilder(stringBuilder, value5);
			AppendStringToStringBuilder(stringBuilder, value6);
			return stringBuilder;
		}

		private static void AppendStringToStringBuilder(StringBuilder stringBuilder, string? value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				stringBuilder.Append(value);
			}
		}
	}
}

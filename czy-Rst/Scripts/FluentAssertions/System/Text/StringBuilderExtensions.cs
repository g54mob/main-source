using System.Collections.Generic;

namespace System.Text
{
	internal static class StringBuilderExtensions
	{
		public static StringBuilder AppendLine(this StringBuilder stringBuilder, IFormatProvider _, string value)
		{
			return stringBuilder.AppendLine(value);
		}

		public static StringBuilder AppendJoin<T>(this StringBuilder stringBuilder, string separator, IEnumerable<T> values)
		{
			return stringBuilder.Append(string.Join(separator, values));
		}
	}
}

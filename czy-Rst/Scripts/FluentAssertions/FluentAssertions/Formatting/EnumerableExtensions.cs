using System.Collections.Generic;
using System.Text;

namespace FluentAssertions.Formatting
{
	internal static class EnumerableExtensions
	{
		internal static string JoinUsingWritingStyle<T>(this IEnumerable<T> items)
		{
			StringBuilder stringBuilder = new StringBuilder();
			T val = default(T);
			bool flag = true;
			foreach (T item in items)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(val);
				}
				val = item;
			}
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(" and ");
			}
			stringBuilder.Append(val);
			return stringBuilder.ToString();
		}
	}
}

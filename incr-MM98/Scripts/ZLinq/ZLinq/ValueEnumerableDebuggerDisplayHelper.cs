using System;
using System.Text;

namespace ZLinq
{
	internal static class ValueEnumerableDebuggerDisplayHelper
	{
		public static string BuildDisplayText(Type type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			BuildCore(stringBuilder, type);
			Type type2 = type.GetInterface("IValueEnumerator`1");
			Type type3 = (((object)type2 != null) ? type2.GetGenericArguments()[0] : null);
			if (type3 != null)
			{
				stringBuilder.Append(" => ");
				stringBuilder.Append(type3.Name);
			}
			return stringBuilder.ToString();
		}

		private static void BuildCore(StringBuilder sb, Type type)
		{
			if (type.IsGenericType)
			{
				Type type2 = type.GenericTypeArguments[0];
				bool flag = type2.IsGenericType;
				if (!flag)
				{
					bool flag2;
					switch (type2.Name)
					{
					case "FromRange":
					case "FromRange2":
					case "FromRangeDateTime":
					case "FromRangeDateTimeTo":
						flag2 = true;
						break;
					default:
						flag2 = false;
						break;
					}
					flag = flag2;
				}
				if (flag)
				{
					BuildCore(sb, type2);
					sb.Append(".");
				}
				int num = type.Name.IndexOf('`');
				if (num != -1)
				{
					string value = type.Name.Substring(0, num);
					sb.Append(value);
				}
				else
				{
					sb.Append(type.Name);
				}
				flag = !type2.IsGenericType;
				if (flag)
				{
					bool flag2;
					switch (type2.Name)
					{
					case "FromRange":
					case "FromRange2":
					case "FromRangeDateTime":
					case "FromRangeDateTimeTo":
						flag2 = true;
						break;
					default:
						flag2 = false;
						break;
					}
					flag = !flag2;
				}
				if (flag)
				{
					sb.Append("<");
					sb.Append(type2.Name);
					sb.Append(">");
				}
			}
			else
			{
				bool flag;
				switch (type.Name)
				{
				case "FromRange":
				case "FromRange2":
				case "FromRangeDateTime":
				case "FromRangeDateTimeTo":
					flag = true;
					break;
				default:
					flag = false;
					break;
				}
				if (flag)
				{
					sb.Append(type.Name);
					return;
				}
				sb.Append("<");
				sb.Append(type.Name);
				sb.Append(">");
			}
		}
	}
}

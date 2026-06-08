using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bindito.Core.Internal
{
	public static class TypeFormatting
	{
		public static string Format(Type type)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string name = type.Name;
			int num = name.IndexOf('`');
			stringBuilder.Append((num >= 0) ? name.Remove(num) : name);
			if (type.IsGenericType)
			{
				stringBuilder.Append("<");
				stringBuilder.Append(string.Join(",", type.GenericTypeArguments.Select(Format)));
				stringBuilder.Append(">");
			}
			return stringBuilder.ToString();
		}

		public static string FormatChain(IEnumerable<Type> dependencyChain)
		{
			StringBuilder stringBuilder = new StringBuilder();
			List<Type> list = dependencyChain.ToList();
			if (list.Count > 0)
			{
				stringBuilder.Append(Format(list.First()));
				for (int i = 1; i < list.Count; i++)
				{
					stringBuilder.Append(" => " + Format(list[i]));
				}
			}
			return stringBuilder.ToString();
		}
	}
}

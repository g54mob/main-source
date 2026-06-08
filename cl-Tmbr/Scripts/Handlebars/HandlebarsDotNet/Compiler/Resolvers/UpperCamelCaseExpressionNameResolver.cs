using System;

namespace HandlebarsDotNet.Compiler.Resolvers
{
	public class UpperCamelCaseExpressionNameResolver : IExpressionNameResolver
	{
		public string ResolveExpressionName(object instance, string expressionName)
		{
			if (string.IsNullOrEmpty(expressionName))
			{
				return expressionName;
			}
			bool flag = expressionName.IndexOf("_", StringComparison.OrdinalIgnoreCase) >= 0;
			bool flag2 = expressionName.IndexOf(".", StringComparison.OrdinalIgnoreCase) >= 0;
			if (char.IsUpper(expressionName[0]) && !flag && !flag2)
			{
				return expressionName;
			}
			char[] array = expressionName.ToCharArray();
			char[] array2 = new char[array.Length];
			if (flag)
			{
				int num = 0;
				array[0] = char.ToUpperInvariant(array[0]);
				for (int i = 0; i < array.Length; i++)
				{
					bool num2 = i + 1 < array.Length;
					bool flag3 = array[i] == '_';
					if (num2 && flag3)
					{
						array[i + 1] = char.ToUpperInvariant(array[i + 1]);
					}
					else
					{
						array2[num++] = array[i];
					}
				}
				array = array2;
			}
			array[0] = char.ToUpperInvariant(array[0]);
			for (int j = 0; j < array.Length; j++)
			{
				bool flag4 = j + 1 < array.Length;
				if (array[j] == '.' && flag4)
				{
					array[j + 1] = char.ToUpperInvariant(array[j + 1]);
				}
			}
			return new string(array).TrimEnd('\0');
		}
	}
}

using System;
using System.Reflection;
using System.Text;

namespace Castle.DynamicProxy.Generators
{
	internal static class MetaTypeElementUtil
	{
		public static string CreateNameForExplicitImplementation(Type sourceType, string name)
		{
			string text = sourceType.Namespace;
			if (sourceType.GetTypeInfo().IsGenericType)
			{
				StringBuilder stringBuilder = new StringBuilder();
				if (text != null)
				{
					stringBuilder.Append(text);
					stringBuilder.Append('.');
				}
				stringBuilder.AppendNameOf(sourceType);
				stringBuilder.Append('.');
				stringBuilder.Append(name);
				return stringBuilder.ToString();
			}
			if (text != null)
			{
				return text + "." + sourceType.Name + "." + name;
			}
			return sourceType.Name + "." + name;
		}

		private static void AppendNameOf(this StringBuilder nameBuilder, Type type)
		{
			nameBuilder.Append(type.Name);
			if (!type.GetTypeInfo().IsGenericType)
			{
				return;
			}
			nameBuilder.Append('[');
			Type[] genericArguments = type.GetGenericArguments();
			int i = 0;
			for (int num = genericArguments.Length; i < num; i++)
			{
				if (i > 0)
				{
					nameBuilder.Append(',');
				}
				nameBuilder.AppendNameOf(genericArguments[i]);
			}
			nameBuilder.Append(']');
		}
	}
}

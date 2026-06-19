using System;
using System.Text;

namespace Aggro.Core
{
	public static class TypeUtil
	{
		public static string GetFriendlyName<T>()
		{
			return GetFriendlyName(typeof(T));
		}

		public static string GetFriendlyName(Type type)
		{
			if (type == null || type.FullName == null)
			{
				return "<NULL>";
			}
			string text = type.FullName.Replace('+', '.');
			if (!string.IsNullOrEmpty(type.Namespace))
			{
				text = text.Replace(type.Namespace + ".", "");
			}
			if (type.IsGenericType)
			{
				int num = type.Name.IndexOf('`');
				StringBuilder stringBuilder = new StringBuilder(text);
				stringBuilder.Remove(num, type.Name.Length - num);
				stringBuilder.Append('<');
				Type[] genericArguments = type.GetGenericArguments();
				for (int i = 0; i < genericArguments.Length; i++)
				{
					if (i != 0)
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append(GetFriendlyName(genericArguments[i]));
				}
				stringBuilder.Append('>');
				return stringBuilder.ToString();
			}
			return text;
		}
	}
}

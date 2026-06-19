using System;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	public class ColorTypeConverter : ITypeConverter
	{
		public bool Support(string typeName)
		{
			if (typeName == "color")
			{
				return true;
			}
			return false;
		}

		public Type GetType(string typeName)
		{
			if (typeName == "color")
			{
				return typeof(Color);
			}
			throw new NotSupportedException();
		}

		public object Convert(Type type, object value)
		{
			if (type == null)
			{
				throw new NotSupportedException();
			}
			if (ColorUtility.TryParseHtmlString((string)value, out var color))
			{
				return color;
			}
			throw new FormatException($"The '{value}' is illegal Color.");
		}
	}
}

using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	public class RectTypeConverter : ITypeConverter
	{
		public bool Support(string typeName)
		{
			if (typeName == "rect")
			{
				return true;
			}
			return false;
		}

		public Type GetType(string typeName)
		{
			if (typeName == "rect")
			{
				return typeof(Rect);
			}
			throw new NotSupportedException();
		}

		public object Convert(Type type, object value)
		{
			if (type == null)
			{
				throw new NotSupportedException();
			}
			try
			{
				string[] array = Regex.Replace(((string)value).Trim(), "(^\\()|(\\)$)", "").Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				if (array.Length == 4)
				{
					return new Rect(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]), float.Parse(array[3]));
				}
			}
			catch (Exception)
			{
			}
			throw new FormatException($"The '{value}' is illegal Rect.");
		}
	}
}

using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class StringFormatAttribute : DictionaryBehaviorAttribute, IDictionaryPropertyGetter, IDictionaryBehavior
	{
		private static readonly char[] PropertyDelimeters = new char[2] { ',', ' ' };

		public string Format { get; private set; }

		public string Properties { get; private set; }

		public StringFormatAttribute(string format, string properties)
		{
			if (format == null)
			{
				throw new ArgumentNullException("format");
			}
			Format = format;
			Properties = properties;
		}

		object IDictionaryPropertyGetter.GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
		{
			return string.Format(Format, GetFormatArguments(dictionaryAdapter, property.Property.Name)).Trim();
		}

		private object[] GetFormatArguments(IDictionaryAdapter dictionaryAdapter, string formattedPropertyName)
		{
			string[] array = Properties.Split(PropertyDelimeters, StringSplitOptions.RemoveEmptyEntries);
			object[] array2 = new object[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (text != formattedPropertyName)
				{
					array2[i] = dictionaryAdapter.GetProperty(text, ifExists: false);
				}
				else
				{
					array2[i] = "(recursive)";
				}
			}
			return array2;
		}
	}
}

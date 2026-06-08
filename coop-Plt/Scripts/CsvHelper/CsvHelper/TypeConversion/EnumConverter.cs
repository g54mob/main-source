using System;
using System.Collections.Generic;
using System.Reflection;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace CsvHelper.TypeConversion
{
	public class EnumConverter : DefaultTypeConverter
	{
		private readonly Type type;

		private readonly Dictionary<string, string> enumNamesByAttributeNames = new Dictionary<string, string>();

		private readonly Dictionary<string, string> enumNamesByAttributeNamesIgnoreCase = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		private readonly Dictionary<object, string> attributeNamesByEnumValues = new Dictionary<object, string>();

		public EnumConverter(Type type)
		{
			if (!typeof(Enum).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo()))
			{
				throw new ArgumentException("'" + type.FullName + "' is not an Enum.");
			}
			this.type = type;
			foreach (object value in Enum.GetValues(type))
			{
				string name = Enum.GetName(type, value);
				NameAttribute customAttribute = type.GetField(name).GetCustomAttribute<NameAttribute>();
				if (customAttribute == null || customAttribute.Names.Length == 0)
				{
					continue;
				}
				string[] names = customAttribute.Names;
				foreach (string text in names)
				{
					if (!enumNamesByAttributeNames.ContainsKey(text))
					{
						enumNamesByAttributeNames.Add(text, name);
					}
					if (!enumNamesByAttributeNamesIgnoreCase.ContainsKey(text))
					{
						enumNamesByAttributeNamesIgnoreCase.Add(text, name);
					}
					if (!attributeNamesByEnumValues.ContainsKey(value))
					{
						attributeNamesByEnumValues.Add(value, text);
					}
				}
			}
		}

		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			bool valueOrDefault = memberMapData.TypeConverterOptions.EnumIgnoreCase == true;
			if (text != null)
			{
				Dictionary<string, string> dictionary = (valueOrDefault ? enumNamesByAttributeNamesIgnoreCase : enumNamesByAttributeNames);
				if (dictionary.ContainsKey(text))
				{
					return Enum.Parse(type, dictionary[text]);
				}
			}
			try
			{
				return Enum.Parse(type, text, valueOrDefault);
			}
			catch
			{
				return base.ConvertFromString(text, row, memberMapData);
			}
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (value != null && attributeNamesByEnumValues.ContainsKey(value))
			{
				return attributeNamesByEnumValues[value];
			}
			return base.ConvertToString(value, row, memberMapData);
		}
	}
}

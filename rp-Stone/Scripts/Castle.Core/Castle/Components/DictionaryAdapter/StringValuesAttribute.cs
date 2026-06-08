using System;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
	public class StringValuesAttribute : DictionaryBehaviorAttribute, IDictionaryPropertySetter, IDictionaryBehavior
	{
		public string Format { get; set; }

		bool IDictionaryPropertySetter.SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor property)
		{
			if (value != null)
			{
				value = GetPropertyAsString(property, value);
			}
			return true;
		}

		private string GetPropertyAsString(PropertyDescriptor property, object value)
		{
			if (!string.IsNullOrEmpty(Format))
			{
				return string.Format(Format, value);
			}
			TypeConverter typeConverter = property.TypeConverter;
			if (typeConverter != null && typeConverter.CanConvertTo(typeof(string)))
			{
				return (string)typeConverter.ConvertTo(value, typeof(string));
			}
			return value.ToString();
		}
	}
}

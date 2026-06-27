using System;
using System.ComponentModel;

namespace Castle.Components.DictionaryAdapter
{
	public class DefaultPropertyGetter : IDictionaryPropertyGetter, IDictionaryBehavior
	{
		private readonly TypeConverter converter;

		public int ExecutionOrder => int.MaxValue;

		public DefaultPropertyGetter(TypeConverter converter)
		{
			this.converter = converter;
		}

		public object GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
		{
			Type propertyType = property.PropertyType;
			if (storedValue != null && !propertyType.IsInstanceOfType(storedValue) && converter != null && converter.CanConvertFrom(storedValue.GetType()))
			{
				return converter.ConvertFrom(storedValue);
			}
			return storedValue;
		}

		public IDictionaryBehavior Copy()
		{
			return this;
		}
	}
}

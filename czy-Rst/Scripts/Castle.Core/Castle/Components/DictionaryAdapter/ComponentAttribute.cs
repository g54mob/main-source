using System;

namespace Castle.Components.DictionaryAdapter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class ComponentAttribute : DictionaryBehaviorAttribute, IDictionaryKeyBuilder, IDictionaryBehavior, IDictionaryPropertyGetter, IDictionaryPropertySetter
	{
		public bool NoPrefix
		{
			get
			{
				return Prefix == "";
			}
			set
			{
				if (value)
				{
					Prefix = "";
				}
			}
		}

		public string Prefix { get; set; }

		string IDictionaryKeyBuilder.GetKey(IDictionaryAdapter dictionaryAdapter, string key, PropertyDescriptor property)
		{
			return Prefix ?? (key + "_");
		}

		object IDictionaryPropertyGetter.GetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, object storedValue, PropertyDescriptor property, bool ifExists)
		{
			if (storedValue == null)
			{
				object obj = dictionaryAdapter.This.ExtendedProperties[property.PropertyName];
				if (obj == null)
				{
					PropertyDescriptor propertyDescriptor = new PropertyDescriptor(property.Property, null);
					propertyDescriptor.AddBehavior(new KeyPrefixAttribute(key));
					obj = dictionaryAdapter.This.Factory.GetAdapter(property.Property.PropertyType, dictionaryAdapter.This.Dictionary, propertyDescriptor);
					dictionaryAdapter.This.ExtendedProperties[property.PropertyName] = obj;
				}
				return obj;
			}
			return storedValue;
		}

		public bool SetPropertyValue(IDictionaryAdapter dictionaryAdapter, string key, ref object value, PropertyDescriptor property)
		{
			dictionaryAdapter.This.ExtendedProperties.Remove(property.PropertyName);
			return false;
		}
	}
}

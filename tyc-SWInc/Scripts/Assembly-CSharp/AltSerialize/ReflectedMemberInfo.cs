using System;
using System.Reflection;

namespace AltSerialize
{
	internal class ReflectedMemberInfo
	{
		private FieldInfo _fieldInfo;

		private PropertyInfo _propertyInfo;

		private bool _isFieldInfo;

		public bool IgnoreNetwork;

		public string Name
		{
			get
			{
				if (_isFieldInfo)
				{
					return _fieldInfo.Name;
				}
				return _propertyInfo.Name;
			}
		}

		public Type FieldType
		{
			get
			{
				return GetFieldOrPropertyType();
			}
		}

		public bool NonSerialized
		{
			get
			{
				if (_isFieldInfo)
				{
					return _fieldInfo.IsNotSerialized;
				}
				return false;
			}
		}

		public FieldInfo Field
		{
			get
			{
				return _fieldInfo;
			}
		}

		public PropertyInfo Property
		{
			get
			{
				return _propertyInfo;
			}
		}

		public ReflectedMemberInfo(FieldInfo field)
		{
			if (field == null)
			{
				throw new AltSerializeException("Could not create meta data information for serialization.");
			}
			if (field.FieldType == null)
			{
				throw new AltSerializeException("The field '" + field.Name + "' has no Type information.");
			}
			_isFieldInfo = true;
			_fieldInfo = field;
			IgnoreNetwork = field.GetCustomAttribute<IgnoreNetwork>() != null;
		}

		public ReflectedMemberInfo(PropertyInfo propinfo)
		{
			if (propinfo == null)
			{
				throw new AltSerializeException("Could not create meta data information for serialization.");
			}
			if (propinfo.PropertyType == null)
			{
				throw new AltSerializeException("The property '" + propinfo.Name + "' has no Type information.");
			}
			_propertyInfo = propinfo;
		}

		public object GetValue(object obj)
		{
			if (_isFieldInfo)
			{
				return _fieldInfo.GetValue(obj);
			}
			return _propertyInfo.GetValue(obj, null);
		}

		public void SetValue(object obj, object newValue)
		{
			if (_isFieldInfo)
			{
				_fieldInfo.SetValue(obj, newValue);
			}
			else
			{
				_propertyInfo.SetValue(obj, newValue, null);
			}
		}

		public Type GetFieldOrPropertyType()
		{
			try
			{
				if (_isFieldInfo)
				{
					return _fieldInfo.FieldType;
				}
				return _propertyInfo.PropertyType;
			}
			catch (Exception ex)
			{
				if (_isFieldInfo)
				{
					if (_fieldInfo == null)
					{
						throw new AltSerializeException("The field information for a reflected member was null.");
					}
					throw new AltSerializeException("Failed to retrieve the field type for the field named '" + _fieldInfo.Name + "': " + ex.Message);
				}
				if (_propertyInfo == null)
				{
					throw new AltSerializeException("The property information for a reflected member was null!");
				}
				throw new AltSerializeException("Failed to retrieve the property type for the property named '" + _propertyInfo.Name + "': " + ex.Message);
			}
		}
	}
}

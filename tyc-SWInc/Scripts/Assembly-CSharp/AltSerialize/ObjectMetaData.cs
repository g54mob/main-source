using System;
using System.Reflection;

namespace AltSerialize
{
	internal class ObjectMetaData
	{
		private AltSerializer _owner;

		private Type _type;

		private bool _implementsIList;

		private bool _implementsIDictionary;

		private bool _isGenericList;

		private bool _isGenericHashSet;

		private bool _isISerializable;

		private bool _useInterface;

		private ReflectedMemberInfo[] _fields;

		public int NetworkedFields;

		private ReflectedMemberInfo[] _properties;

		private DynamicSerializer _dynamicSerializer;

		private Type _genericTypeDefinition;

		private Type[] _genericParameters;

		private MethodInfo _deserializeMethod;

		private MethodInfo _serializeMethod;

		private object _extra;

		private FieldInfo _size;

		public AltSerializer Owner
		{
			get
			{
				return _owner;
			}
			set
			{
				_owner = value;
			}
		}

		public Type ObjectType
		{
			get
			{
				return _type;
			}
			set
			{
				_type = value;
			}
		}

		public bool ImplementsIList
		{
			get
			{
				return _implementsIList;
			}
			set
			{
				_implementsIList = value;
			}
		}

		public bool ImplementsIDictionary
		{
			get
			{
				return _implementsIDictionary;
			}
			set
			{
				_implementsIDictionary = value;
			}
		}

		public bool IsGenericList
		{
			get
			{
				return _isGenericList;
			}
			set
			{
				_isGenericList = value;
			}
		}

		public bool IsGenericHashSet
		{
			get
			{
				return _isGenericHashSet;
			}
			set
			{
				_isGenericHashSet = value;
			}
		}

		public bool IsISerializable
		{
			get
			{
				return _isISerializable;
			}
			set
			{
				_isISerializable = value;
			}
		}

		public bool IsIAltSerializable
		{
			get
			{
				return _useInterface;
			}
			set
			{
				_useInterface = value;
			}
		}

		public ReflectedMemberInfo[] Fields
		{
			get
			{
				return _fields;
			}
			set
			{
				_fields = value;
			}
		}

		public ReflectedMemberInfo[] Properties
		{
			get
			{
				return _properties;
			}
			set
			{
				_properties = value;
			}
		}

		public ReflectedMemberInfo[] Values
		{
			get
			{
				if (Owner.SerializeProperties)
				{
					return Properties;
				}
				return Fields;
			}
		}

		public DynamicSerializer DynamicSerializer
		{
			get
			{
				return _dynamicSerializer;
			}
			set
			{
				_dynamicSerializer = value;
			}
		}

		public Type GenericTypeDefinition
		{
			get
			{
				return _genericTypeDefinition;
			}
			set
			{
				_genericTypeDefinition = value;
			}
		}

		public Type[] GenericParameters
		{
			get
			{
				return _genericParameters;
			}
			set
			{
				_genericParameters = value;
			}
		}

		public MethodInfo DeserializeMethod
		{
			get
			{
				return _deserializeMethod;
			}
			set
			{
				_deserializeMethod = value;
			}
		}

		public MethodInfo SerializeMethod
		{
			get
			{
				return _serializeMethod;
			}
			set
			{
				_serializeMethod = value;
			}
		}

		public object Extra
		{
			get
			{
				return _extra;
			}
			set
			{
				_extra = value;
			}
		}

		public FieldInfo SizeField
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public ObjectMetaData(AltSerializer owner)
		{
			Owner = owner;
		}

		public ReflectedMemberInfo FindMemberInfoByName(string propertyName)
		{
			for (int i = 0; i < Values.Length; i++)
			{
				if (Values[i].Name == propertyName)
				{
					return Values[i];
				}
			}
			return null;
		}
	}
}

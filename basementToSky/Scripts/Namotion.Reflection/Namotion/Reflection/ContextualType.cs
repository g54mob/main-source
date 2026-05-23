using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Namotion.Reflection
{
	public class ContextualType : CachedType
	{
		private static readonly byte[] _emptyNullableFlags = new byte[1];

		private readonly int _nullableFlagsIndex;

		private byte[]? _nullableFlags;

		private Nullability? nullability;

		private ContextualMethodInfo[]? _methods;

		private ContextualPropertyInfo[]? _properties;

		private ContextualFieldInfo[]? _fields;

		private bool? _isValueType;

		private ContextualType? _enumerableItemType;

		public ContextualType? Parent { get; }

		public Attribute[] ContextAttributes { get; private set; }

		public Nullability OriginalNullability { get; private set; }

		public override IEnumerable<Attribute> Attributes => ContextAttributes.Concat<Attribute>(base.Attributes);

		public new ContextualType[] GenericArguments
		{
			get
			{
				UpdateOriginalGenericArguments();
				if (_genericArguments == null)
				{
					throw new InvalidOperationException("_genericArguments is not initialized");
				}
				if (_genericArguments is ContextualType[])
				{
					return (ContextualType[])_genericArguments;
				}
				_genericArguments = ((IEnumerable)_genericArguments).Cast<ContextualType>().ToArray();
				return (ContextualType[])_genericArguments;
			}
		}

		public new ContextualType[] OriginalGenericArguments
		{
			get
			{
				UpdateOriginalGenericArguments();
				if (_originalGenericArguments == null)
				{
					throw new InvalidOperationException("_originalGenericArguments is not initialized");
				}
				if (_originalGenericArguments is ContextualType[])
				{
					return (ContextualType[])_originalGenericArguments;
				}
				_originalGenericArguments = ((IEnumerable)_originalGenericArguments).Cast<ContextualType>().ToArray();
				return (ContextualType[])_originalGenericArguments;
			}
		}

		public new ContextualType? ElementType
		{
			get
			{
				UpdateOriginalGenericArguments();
				return _elementType as ContextualType;
			}
		}

		public ContextualType? EnumerableItemType
		{
			get
			{
				ContextualType elementType = ElementType;
				if (elementType != null)
				{
					return elementType;
				}
				ContextualMethodInfo contextualMethodInfo = Methods.SingleOrDefault((ContextualMethodInfo m) => m.Name == "GetEnumerator");
				if (contextualMethodInfo != null)
				{
					ContextualType[] genericArguments = GenericArguments;
					if (genericArguments != null && genericArguments.Length == 1)
					{
						return GenericArguments[0];
					}
					if (_enumerableItemType != null)
					{
						return _enumerableItemType;
					}
					ContextualParameterInfo returnParameter = contextualMethodInfo.ReturnParameter;
					if (returnParameter != null && returnParameter.GenericArguments.Length == 1)
					{
						_enumerableItemType = returnParameter.GenericArguments[0];
						return _enumerableItemType;
					}
				}
				return null;
			}
		}

		public ContextualType? BaseType => base.Type.GetTypeInfo().BaseType?.ToContextualType(base.Type.GetTypeInfo().GetCustomAttributes());

		public Nullability Nullability
		{
			get
			{
				if (nullability.HasValue)
				{
					return nullability.Value;
				}
				UpdateOriginalGenericArguments();
				lock (this)
				{
					if (!nullability.HasValue)
					{
						nullability = (base.IsNullableType ? Nullability.Nullable : OriginalNullability);
					}
					return nullability.Value;
				}
			}
		}

		public bool IsValueType
		{
			get
			{
				bool? isValueType = _isValueType;
				if (!isValueType.HasValue)
				{
					bool? flag = (_isValueType = base.TypeInfo.IsValueType);
					return flag.Value;
				}
				return isValueType == true;
			}
		}

		public ContextualPropertyInfo[] Properties
		{
			get
			{
				if (_properties == null)
				{
					lock (this)
					{
						if (_properties == null)
						{
							_properties = base.Type.GetRuntimeProperties().Select(delegate(PropertyInfo property)
							{
								if (base.TypeInfo.IsGenericType && !base.TypeInfo.ContainsGenericParameters)
								{
									Type genericType = base.TypeInfo.GetGenericTypeDefinition();
									PropertyInfo propertyInfo = genericType.GetRuntimeProperties().SingleOrDefault((PropertyInfo p) => p.Name == property.Name && p.DeclaringType == genericType);
									if (propertyInfo != null && propertyInfo.PropertyType.IsGenericParameter)
									{
										ContextualType contextualType = GenericArguments[propertyInfo.PropertyType.GenericParameterPosition];
										int nullableFlagsIndex = contextualType._nullableFlagsIndex;
										return new ContextualPropertyInfo(property, ref nullableFlagsIndex, contextualType._nullableFlags);
									}
								}
								int nullableFlagsIndex2 = 0;
								return new ContextualPropertyInfo(property, ref nullableFlagsIndex2, null);
							}).ToArray();
						}
					}
				}
				return _properties;
			}
		}

		public ContextualMethodInfo[] Methods
		{
			get
			{
				if (_methods == null)
				{
					lock (this)
					{
						if (_methods == null)
						{
							_methods = base.Type.GetRuntimeMethods().Select(delegate(MethodInfo method)
							{
								int nullableFlagsIndex = 0;
								return new ContextualMethodInfo(method, new ContextualParameterInfo(method.ReturnParameter, ref nullableFlagsIndex, null), method.GetParameters().Select(delegate(ParameterInfo p)
								{
									int nullableFlagsIndex2 = 0;
									return new ContextualParameterInfo(p, ref nullableFlagsIndex2, null);
								}));
							}).ToArray();
						}
					}
				}
				return _methods;
			}
		}

		public ContextualFieldInfo[] Fields
		{
			get
			{
				if (_fields == null)
				{
					lock (this)
					{
						if (_fields == null)
						{
							_fields = base.Type.GetRuntimeFields().Select(delegate(FieldInfo field)
							{
								if (base.TypeInfo.IsGenericType && !base.TypeInfo.ContainsGenericParameters)
								{
									FieldInfo runtimeField = field.DeclaringType.GetGenericTypeDefinition().GetRuntimeField(field.Name);
									if (runtimeField != null)
									{
										ContextualType contextualType = GenericArguments[runtimeField.FieldType.GenericParameterPosition];
										int nullableFlagsIndex = contextualType._nullableFlagsIndex;
										return new ContextualFieldInfo(field, ref nullableFlagsIndex, contextualType._nullableFlags);
									}
								}
								int nullableFlagsIndex2 = 0;
								return new ContextualFieldInfo(field, ref nullableFlagsIndex2, null);
							}).ToArray();
						}
					}
				}
				return _fields;
			}
		}

		internal static ContextualType ForType(Type type, IEnumerable<Attribute> contextAttributes)
		{
			int nullableFlagsIndex = 0;
			return new ContextualType(type, contextAttributes, null, ref nullableFlagsIndex, null, null);
		}

		internal ContextualType(Type type, IEnumerable<Attribute> contextAttributes, ContextualType? parent, ref int nullableFlagsIndex, byte[]? nullableFlags, NullableFlagsSource[] customAttributeProviders)
			: base(type)
		{
			Parent = parent;
			ContextAttributes = ((contextAttributes is Attribute[] array) ? array : (contextAttributes?.ToArray() ?? ArrayExt.Empty<Attribute>()));
			_nullableFlags = nullableFlags;
			_nullableFlagsIndex = nullableFlagsIndex;
			InitializeNullableFlagsAndOriginalNullability(ref nullableFlagsIndex, customAttributeProviders);
			if (_nullableFlags != null)
			{
				UpdateOriginalGenericArguments(ref nullableFlagsIndex);
			}
		}

		public T? GetContextAttribute<T>() where T : Attribute
		{
			return ContextAttributes.GetSingleOrDefault<T>();
		}

		public IEnumerable<T> GetContextAttributes<T>()
		{
			return ContextAttributes.OfType<T>();
		}

		public T? GetAttribute<T>()
		{
			T singleOrDefault = ContextAttributes.GetSingleOrDefault<T>();
			if (singleOrDefault == null)
			{
				return base.InheritedAttributes.GetSingleOrDefault<T>();
			}
			return singleOrDefault;
		}

		public IEnumerable<T> GetAttributes<T>()
		{
			return ContextAttributes.OfType<T>().Concat(base.InheritedAttributes.OfType<T>());
		}

		public ContextualPropertyInfo? GetProperty(string propertyName)
		{
			return Properties.FirstOrDefault((ContextualPropertyInfo p) => p.Name == propertyName);
		}

		public ContextualFieldInfo? GetField(string fieldName)
		{
			return Fields.FirstOrDefault((ContextualFieldInfo p) => p.Name == fieldName);
		}

		public override string ToString()
		{
			return (base.Type.Name.FirstToken('`') + ": " + Nullability.ToString() + "\n  " + string.Join("\n", GenericArguments.Select((ContextualType a) => a.ToString())).Replace("\n", "\n  ")).Trim();
		}

		protected override CachedType GetCachedType(Type type, ref int nullableFlagsIndex)
		{
			return new ContextualType(type, ContextAttributes, this, ref nullableFlagsIndex, _nullableFlags, null);
		}

		private void InitializeNullableFlagsAndOriginalNullability(ref int nullableFlagsIndex, NullableFlagsSource[] customAttributeProviders)
		{
			TypeInfo typeInfo = base.OriginalType.GetTypeInfo();
			try
			{
				if (_nullableFlags == null)
				{
					Attribute attribute = ContextAttributes.FirstOrDefault((Attribute a) => a.GetType().FullName == "System.Runtime.CompilerServices.NullableAttribute");
					if (attribute != null)
					{
						_nullableFlags = GetFlagsFromNullableAttribute(attribute);
					}
					else if (typeInfo.IsGenericParameter)
					{
						if (typeInfo.GenericParameterAttributes.HasFlag(GenericParameterAttributes.NotNullableValueTypeConstraint) || typeInfo.GenericParameterAttributes.HasFlag(GenericParameterAttributes.ReferenceTypeConstraint))
						{
							attribute = typeInfo.GetCustomAttributes().FirstOrDefault((Attribute a) => a.GetType().FullName == "System.Runtime.CompilerServices.NullableAttribute");
							if (attribute != null)
							{
								_nullableFlags = GetFlagsFromNullableAttribute(attribute);
							}
							else
							{
								NullableFlagsSource[] customAttributeProviders2 = ((!typeInfo.DeclaringType.IsNested) ? new NullableFlagsSource[1] { NullableFlagsSource.Create(typeInfo.DeclaringType) } : new NullableFlagsSource[2]
								{
									NullableFlagsSource.Create(typeInfo.DeclaringType),
									NullableFlagsSource.Create(typeInfo.DeclaringType.DeclaringType)
								});
								_nullableFlags = GetFlagsFromCustomAttributeProviders(customAttributeProviders2);
							}
						}
						else if (customAttributeProviders != null)
						{
							_nullableFlags = GetFlagsFromCustomAttributeProviders(customAttributeProviders);
						}
						else
						{
							_nullableFlags = _emptyNullableFlags;
						}
					}
					else if (customAttributeProviders != null)
					{
						_nullableFlags = GetFlagsFromCustomAttributeProviders(customAttributeProviders);
					}
					else
					{
						_nullableFlags = _emptyNullableFlags;
					}
				}
			}
			catch
			{
				_nullableFlags = _emptyNullableFlags;
			}
			if (typeInfo.IsValueType)
			{
				if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() != typeof(Nullable<>))
				{
					nullableFlagsIndex++;
				}
				OriginalNullability = Nullability.NotNullable;
			}
			else
			{
				byte b = ((_nullableFlags.Length > nullableFlagsIndex) ? _nullableFlags[nullableFlagsIndex] : _nullableFlags.Last());
				nullableFlagsIndex++;
				OriginalNullability = b switch
				{
					2 => Nullability.Nullable, 
					1 => Nullability.NotNullable, 
					0 => Nullability.Unknown, 
					_ => Nullability.Unknown, 
				};
			}
		}

		private byte[] GetFlagsFromNullableAttribute(Attribute nullableAttribute)
		{
			return ((byte[])nullableAttribute?.GetType().GetRuntimeField("NullableFlags")?.GetValue(nullableAttribute)) ?? _emptyNullableFlags;
		}

		private static byte[]? GetFlagsFromCustomAttributeProviders(NullableFlagsSource[] customAttributeProviders)
		{
			for (int i = 0; i < customAttributeProviders.Length; i++)
			{
				byte[] nullableFlags = customAttributeProviders[i].NullableFlags;
				if (nullableFlags != null)
				{
					return nullableFlags;
				}
			}
			return _emptyNullableFlags;
		}
	}
}

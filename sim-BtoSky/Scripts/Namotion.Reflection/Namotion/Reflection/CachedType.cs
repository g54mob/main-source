using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Namotion.Reflection
{
	public class CachedType
	{
		private Type? _type;

		private bool _isNullableType;

		private string? _typeName;

		private Attribute[]? _inheritedAttributes;

		internal object? _genericArguments;

		internal object? _originalGenericArguments;

		internal object? _elementType;

		private TypeInfo? _typeInfo;

		public Type OriginalType { get; }

		public virtual IEnumerable<Attribute> Attributes => InheritedAttributes;

		public string TypeName => _typeName ?? (_typeName = Type.Name);

		public TypeInfo TypeInfo => _typeInfo ?? (_typeInfo = Type.GetTypeInfo());

		public Attribute[] InheritedAttributes
		{
			get
			{
				if (_inheritedAttributes != null)
				{
					return _inheritedAttributes;
				}
				UpdateOriginalGenericArguments();
				lock (this)
				{
					if (_inheritedAttributes == null)
					{
						_inheritedAttributes = _type.GetTypeInfo().GetCustomAttributes(inherit: true).OfType<Attribute>()
							.ToArray();
					}
					return _inheritedAttributes;
				}
			}
		}

		public Type Type
		{
			get
			{
				UpdateOriginalGenericArguments();
				return _type ?? throw new InvalidOperationException("_type is not initialized");
			}
		}

		public bool IsNullableType
		{
			get
			{
				UpdateOriginalGenericArguments();
				return _isNullableType;
			}
		}

		public CachedType[] GenericArguments
		{
			get
			{
				UpdateOriginalGenericArguments();
				return ((CachedType[])_genericArguments) ?? throw new InvalidOperationException("_genericArguments is not initialized");
			}
		}

		public CachedType[] OriginalGenericArguments
		{
			get
			{
				UpdateOriginalGenericArguments();
				return ((CachedType[])_originalGenericArguments) ?? throw new InvalidOperationException("_genericArguments is not initialized");
			}
		}

		public CachedType? ElementType
		{
			get
			{
				UpdateOriginalGenericArguments();
				return _elementType as CachedType;
			}
		}

		public static void ClearCache()
		{
			ContextualTypeExtensions.ClearCache();
		}

		public static implicit operator Type(CachedType type)
		{
			return type.OriginalType;
		}

		internal CachedType(Type type)
		{
			OriginalType = type;
		}

		public T? GetInheritedAttribute<T>() where T : Attribute
		{
			return InheritedAttributes.GetSingleOrDefault<T>();
		}

		public IEnumerable<T> GetInheritedAttributes<T>()
		{
			return InheritedAttributes.OfType<T>();
		}

		public override string ToString()
		{
			return (Type.Name.FirstToken('`') + "\n  " + string.Join("\n", GenericArguments.Select((CachedType a) => a.ToString())).Replace("\n", "\n  ")).Trim();
		}

		protected virtual CachedType GetCachedType(Type type, ref int nullableFlagsIndex)
		{
			return type.ToCachedType();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void UpdateOriginalGenericArguments()
		{
			int nullableFlagsIndex = 0;
			UpdateOriginalGenericArguments(ref nullableFlagsIndex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected void UpdateOriginalGenericArguments(ref int nullableFlagsIndex)
		{
			if (_originalGenericArguments != null)
			{
				return;
			}
			lock (this)
			{
				if (_originalGenericArguments != null)
				{
					return;
				}
				List<CachedType> list = new List<CachedType>();
				Type[] genericTypeArguments = OriginalType.GenericTypeArguments;
				foreach (Type type in genericTypeArguments)
				{
					list.Add(GetCachedType(type, ref nullableFlagsIndex));
				}
				if (list.Count == 0)
				{
					Type elementType = OriginalType.GetElementType();
					if (elementType != null)
					{
						_elementType = GetCachedType(elementType, ref nullableFlagsIndex);
					}
				}
				_originalGenericArguments = list.ToArray();
				_isNullableType = OriginalType.Name == "Nullable`1";
				_genericArguments = (_isNullableType ? list[0]._originalGenericArguments : _originalGenericArguments);
				_type = (_isNullableType ? ((IEnumerable)_originalGenericArguments).Cast<CachedType>().First().OriginalType : OriginalType);
			}
		}
	}
}

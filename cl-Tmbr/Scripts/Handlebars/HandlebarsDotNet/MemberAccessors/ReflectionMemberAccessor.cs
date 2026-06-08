using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.MemberAccessors
{
	public sealed class ReflectionMemberAccessor : IMemberAccessor
	{
		private sealed class RawObjectTypeDescriptor
		{
			private delegate TValue ValueTypeGetterDelegate<T, TValue>(ref T instance);

			private static readonly MethodInfo CreateGetDelegateMethodInfo = typeof(RawObjectTypeDescriptor).GetMethod("CreateGetDelegate", BindingFlags.Static | BindingFlags.NonPublic);

			private static readonly Func<KeyValuePair<ChainSegment, Type>, Func<object, object>> ValueGetterFactory = (KeyValuePair<ChainSegment, Type> o) => GetValueGetter(o.Key, o.Value);

			private static readonly Func<ChainSegment, Type, DeferredValue<KeyValuePair<ChainSegment, Type>, Func<object, object>>> ValueFactory = (ChainSegment key, Type state) => new DeferredValue<KeyValuePair<ChainSegment, Type>, Func<object, object>>(new KeyValuePair<ChainSegment, Type>(key, state), ValueGetterFactory);

			private readonly LookupSlim<ChainSegment, DeferredValue<KeyValuePair<ChainSegment, Type>, Func<object, object>>, ChainSegment.ChainSegmentEqualityComparer> _accessors = new LookupSlim<ChainSegment, DeferredValue<KeyValuePair<ChainSegment, Type>, Func<object, object>>, ChainSegment.ChainSegmentEqualityComparer>(default(ChainSegment.ChainSegmentEqualityComparer));

			private Type Type { get; }

			public RawObjectTypeDescriptor(Type type)
			{
				Type = type;
			}

			public Func<object, object> GetOrCreateAccessor(ChainSegment name)
			{
				if (!_accessors.TryGetValue(in name, out var value))
				{
					return _accessors.GetOrAdd(name, ValueFactory, Type).Value;
				}
				return value.Value;
			}

			private static Func<object, object> GetValueGetter(ChainSegment name, Type type)
			{
				PropertyInfo propertyInfo = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((PropertyInfo o) => o.GetIndexParameters().Length == 0 && string.Equals(o.Name, name.LowerInvariant, StringComparison.OrdinalIgnoreCase));
				if (propertyInfo != null)
				{
					return (Func<object, object>)CreateGetDelegateMethodInfo.MakeGenericMethod(type, propertyInfo.PropertyType).Invoke(null, new object[1] { propertyInfo });
				}
				FieldInfo field = type.GetFields(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault((FieldInfo o) => string.Equals(o.Name, name.LowerInvariant, StringComparison.OrdinalIgnoreCase));
				if (field != null)
				{
					return (object o) => field.GetValue(o);
				}
				return null;
			}

			private static Func<object, object> CreateGetDelegate<T, TValue>(PropertyInfo property)
			{
				if (property.DeclaringType.GetTypeInfo().IsValueType)
				{
					ValueTypeGetterDelegate<T, TValue> @delegate = (ValueTypeGetterDelegate<T, TValue>)property.GetMethod.CreateDelegate(typeof(ValueTypeGetterDelegate<T, TValue>));
					return delegate(object o)
					{
						T instance = (T)o;
						return @delegate(ref instance);
					};
				}
				Func<T, TValue> delegate2 = (Func<T, TValue>)property.GetMethod.CreateDelegate(typeof(Func<T, TValue>));
				return (object o) => delegate2((T)o);
			}
		}

		private static readonly Func<Type, DeferredValue<Type, RawObjectTypeDescriptor>> DescriptorsValueFactory = (Type key) => new DeferredValue<Type, RawObjectTypeDescriptor>(key, (Type type) => new RawObjectTypeDescriptor(type));

		private readonly LookupSlim<Type, DeferredValue<Type, RawObjectTypeDescriptor>, ReferenceEqualityComparer<Type>> _descriptors = new LookupSlim<Type, DeferredValue<Type, RawObjectTypeDescriptor>, ReferenceEqualityComparer<Type>>(default(ReferenceEqualityComparer<Type>));

		private readonly IReadOnlyList<IMemberAliasProvider> _aliasProviders;

		public ReflectionMemberAccessor(IReadOnlyList<IMemberAliasProvider> aliasProviders)
		{
			_aliasProviders = aliasProviders;
		}

		public bool TryGetValue(object instance, ChainSegment memberName, out object value)
		{
			Type type = instance.GetType();
			if (TryGetValueImpl(instance, type, memberName, out value))
			{
				return true;
			}
			for (int i = 0; i < _aliasProviders.Count; i++)
			{
				if (_aliasProviders[i].TryGetMemberByAlias(instance, type, memberName, out value))
				{
					return true;
				}
			}
			value = null;
			return false;
		}

		private bool TryGetValueImpl(object instance, Type instanceType, ChainSegment memberName, out object value)
		{
			if (!_descriptors.TryGetValue(in instanceType, out var value2))
			{
				value2 = _descriptors.GetOrAdd(instanceType, DescriptorsValueFactory);
			}
			Func<object, object> orCreateAccessor = value2.Value.GetOrCreateAccessor(memberName);
			value = orCreateAccessor?.Invoke(instance);
			return orCreateAccessor != null;
		}
	}
}

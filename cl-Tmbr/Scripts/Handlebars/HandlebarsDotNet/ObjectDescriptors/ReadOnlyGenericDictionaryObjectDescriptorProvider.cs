using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Iterators;
using HandlebarsDotNet.MemberAccessors.DictionaryAccessors;
using HandlebarsDotNet.Polyfills;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.ObjectDescriptors
{
	public sealed class ReadOnlyGenericDictionaryObjectDescriptorProvider : IObjectDescriptorProvider
	{
		private static readonly MethodInfo CreateDescriptorMethodInfo = typeof(ReadOnlyGenericDictionaryObjectDescriptorProvider).GetMethod("CreateDescriptor", BindingFlags.Static | BindingFlags.NonPublic);

		private readonly LookupSlim<Type, DeferredValue<Type, Type>, ReferenceEqualityComparer<Type>> _typeCache = new LookupSlim<Type, DeferredValue<Type, Type>, ReferenceEqualityComparer<Type>>(default(ReferenceEqualityComparer<Type>));

		private static readonly Func<Type, DeferredValue<Type, Type>> InterfaceTypeValueFactory = (Type key) => new DeferredValue<Type, Type>(key, (Type type) => (from i in type.GetInterfaces()
			where i.GetTypeInfo().IsGenericType
			where i.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<, >)
			select i).FirstOrDefault((Type i) => TypeDescriptor.GetConverter(i.GetGenericArguments()[0]).CanConvertFrom(typeof(string))));

		public bool TryGetDescriptor(Type type, out ObjectDescriptor value)
		{
			Type value2 = _typeCache.GetOrAdd(type, InterfaceTypeValueFactory).Value;
			if (value2 == null)
			{
				value = ObjectDescriptor.Empty;
				return false;
			}
			Type[] genericArguments = value2.GetGenericArguments();
			MethodInfo methodInfo = CreateDescriptorMethodInfo.MakeGenericMethod(type, genericArguments[0], genericArguments[1]);
			value = (ObjectDescriptor)methodInfo.Invoke(null, ArrayEx.Empty<object>());
			return true;
		}

		private static ObjectDescriptor CreateDescriptor<T, TK, TV>() where T : class, IReadOnlyDictionary<TK, TV>
		{
			return new ObjectDescriptor(typeof(T), new ReadOnlyGenericDictionaryAccessor<T, TK, TV>(), (ObjectDescriptor descriptor, object o) => ((T)o).Keys, (ObjectDescriptor self) => new ReadOnlyDictionaryIterator<T, TK, TV>());
		}
	}
}

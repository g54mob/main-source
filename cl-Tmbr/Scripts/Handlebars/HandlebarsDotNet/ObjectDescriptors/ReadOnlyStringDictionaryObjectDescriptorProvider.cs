using System;
using System.Collections.Generic;
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
	public sealed class ReadOnlyStringDictionaryObjectDescriptorProvider : IObjectDescriptorProvider
	{
		private static readonly object[] EmptyArray = ArrayEx.Empty<object>();

		private static readonly MethodInfo CreateClassDescriptorMethodInfo = typeof(ReadOnlyStringDictionaryObjectDescriptorProvider).GetMethod("CreateDescriptor", BindingFlags.Static | BindingFlags.NonPublic);

		private readonly LookupSlim<Type, DeferredValue<Type, Type>, ReferenceEqualityComparer<Type>> _typeCache = new LookupSlim<Type, DeferredValue<Type, Type>, ReferenceEqualityComparer<Type>>(default(ReferenceEqualityComparer<Type>));

		private static readonly Func<Type, DeferredValue<Type, Type>> InterfaceTypeValueFactory = (Type key) => new DeferredValue<Type, Type>(key, (Type type) => type.GetInterfaces().FirstOrDefault((Type i) => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IReadOnlyDictionary<, >) && i.GetGenericArguments()[0] == typeof(string)));

		public bool TryGetDescriptor(Type type, out ObjectDescriptor value)
		{
			Type value2 = _typeCache.GetOrAdd(type, InterfaceTypeValueFactory).Value;
			if (value2 == null)
			{
				value = ObjectDescriptor.Empty;
				return false;
			}
			Type type2 = value2.GetGenericArguments()[1];
			MethodInfo methodInfo = CreateClassDescriptorMethodInfo.MakeGenericMethod(type, type2);
			value = (ObjectDescriptor)methodInfo.Invoke(null, EmptyArray);
			return true;
		}

		private static ObjectDescriptor CreateDescriptor<T, TV>() where T : class, IReadOnlyDictionary<string, TV>
		{
			return new ObjectDescriptor(typeof(IDictionary<string, TV>), new ReadOnlyStringDictionaryAccessor<T, TV>(), (ObjectDescriptor descriptor, object o) => ((T)o).Keys, (ObjectDescriptor self) => new ReadOnlyDictionaryIterator<T, string, TV>());
		}
	}
}

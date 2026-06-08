using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.EqualityComparers;
using HandlebarsDotNet.Iterators;
using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.PathStructure;
using HandlebarsDotNet.Runtime;

namespace HandlebarsDotNet.ObjectDescriptors
{
	public sealed class ObjectDescriptorProvider : IObjectDescriptorProvider
	{
		private readonly LookupSlim<Type, DeferredValue<Type, ChainSegment[]>, ReferenceEqualityComparer<Type>> _membersCache = new LookupSlim<Type, DeferredValue<Type, ChainSegment[]>, ReferenceEqualityComparer<Type>>(default(ReferenceEqualityComparer<Type>));

		private readonly ReflectionMemberAccessor _reflectionMemberAccessor;

		private static readonly Func<ObjectDescriptor, object, IEnumerable<object>> GetProperties = (ObjectDescriptor descriptor, object o) => ((LookupSlim<Type, DeferredValue<Type, ChainSegment[]>, ReferenceEqualityComparer<Type>>)descriptor.Dependencies[0]).GetOrAdd(descriptor.DescribedType, DescriptorValueFactory).Value;

		private static readonly Func<Type, DeferredValue<Type, ChainSegment[]>> DescriptorValueFactory = (Type key) => new DeferredValue<Type, ChainSegment[]>(key, delegate(Type type)
		{
			IEnumerable<PropertyInfo> source = from o in type.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where o.CanRead && o.GetIndexParameters().Length == 0
				select o;
			return (from o in Enumerable.Concat(second: type.GetFields(BindingFlags.Instance | BindingFlags.Public), first: source.Cast<MemberInfo>())
				select o.Name into o
				select ChainSegment.Create(o)).ToArray();
		});

		public ObjectDescriptorProvider(IReadOnlyList<IMemberAliasProvider> aliasProviders)
		{
			_reflectionMemberAccessor = new ReflectionMemberAccessor(aliasProviders);
		}

		public bool TryGetDescriptor(Type type, out ObjectDescriptor value)
		{
			value = new ObjectDescriptor(type, _reflectionMemberAccessor, GetProperties, (ObjectDescriptor self) => new ObjectIterator(self), _membersCache);
			return true;
		}
	}
}

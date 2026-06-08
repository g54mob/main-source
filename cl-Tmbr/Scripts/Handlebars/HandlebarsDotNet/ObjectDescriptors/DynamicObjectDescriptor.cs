using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using HandlebarsDotNet.Iterators;
using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.ObjectDescriptors
{
	public sealed class DynamicObjectDescriptor : IObjectDescriptorProvider
	{
		private readonly ObjectDescriptorProvider _objectDescriptorProvider;

		private static readonly DynamicMemberAccessor DynamicMemberAccessor = new DynamicMemberAccessor();

		private static readonly Func<ObjectDescriptor, object, IEnumerable<object>> GetProperties = delegate(ObjectDescriptor descriptor, object o)
		{
			ObjectDescriptor objectDescriptor = (ObjectDescriptor)descriptor.Dependencies[0];
			IEnumerable<ChainSegment> second = objectDescriptor.GetProperties(objectDescriptor, o).Cast<ChainSegment>();
			return ((IDynamicMetaObjectProvider)o).GetMetaObject(Expression.Constant(o)).GetDynamicMemberNames().Select(ChainSegment.Create)
				.Concat(second);
		};

		private static readonly Type Type = typeof(IDynamicMetaObjectProvider);

		public DynamicObjectDescriptor(ObjectDescriptorProvider objectDescriptorProvider)
		{
			_objectDescriptorProvider = objectDescriptorProvider;
		}

		public bool TryGetDescriptor(Type type, out ObjectDescriptor value)
		{
			if (!Type.IsAssignableFrom(type))
			{
				value = ObjectDescriptor.Empty;
				return false;
			}
			if (!_objectDescriptorProvider.TryGetDescriptor(type, out var value2))
			{
				value = ObjectDescriptor.Empty;
				return false;
			}
			MergedMemberAccessor memberAccessor = new MergedMemberAccessor(value2.MemberAccessor, DynamicMemberAccessor);
			value = new ObjectDescriptor(type, memberAccessor, GetProperties, (ObjectDescriptor self) => new DynamicObjectIterator(self), value2);
			return true;
		}
	}
}

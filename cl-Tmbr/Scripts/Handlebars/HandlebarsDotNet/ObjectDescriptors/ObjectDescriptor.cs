using System;
using System.Collections;
using System.Runtime.CompilerServices;
using HandlebarsDotNet.Iterators;
using HandlebarsDotNet.MemberAccessors;

namespace HandlebarsDotNet.ObjectDescriptors
{
	public sealed class ObjectDescriptor
	{
		public static readonly ObjectDescriptor Empty = new ObjectDescriptor();

		public readonly IIterator Iterator;

		public readonly object[] Dependencies;

		public readonly Type DescribedType;

		public readonly Func<ObjectDescriptor, object, IEnumerable> GetProperties;

		public readonly IMemberAccessor MemberAccessor;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ObjectDescriptor Create(object from)
		{
			return Create(from?.GetType());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ObjectDescriptor Create(Type from)
		{
			if (from == null)
			{
				return Empty;
			}
			if (!ObjectDescriptorFactory.Current.TryGetDescriptor(from, out var value))
			{
				return Empty;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryCreate(object from, out ObjectDescriptor descriptor)
		{
			return TryCreate(from?.GetType(), out descriptor);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryCreate(Type from, out ObjectDescriptor descriptor)
		{
			if (from == null)
			{
				descriptor = Empty;
				return false;
			}
			return ObjectDescriptorFactory.Current.TryGetDescriptor(from, out descriptor);
		}

		public ObjectDescriptor(Type describedType, IMemberAccessor memberAccessor, Func<ObjectDescriptor, object, IEnumerable> getProperties, Func<ObjectDescriptor, IIterator> iterator, params object[] dependencies)
			: this()
		{
			DescribedType = describedType;
			GetProperties = getProperties;
			MemberAccessor = memberAccessor;
			Dependencies = dependencies;
			Iterator = iterator(this);
		}

		private ObjectDescriptor()
		{
		}
	}
}

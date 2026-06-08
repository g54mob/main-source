using System;
using System.Collections;
using System.Collections.Generic;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.MemberAccessors.EnumerableAccessors
{
	public sealed class EnumerableMemberAccessor<T, TV> : EnumerableMemberAccessor where T : class, IEnumerable<TV>
	{
		protected override bool TryGetValueInternal(object instance, int index, out object value)
		{
			using IEnumerator<TV> enumerator = ((T)instance).GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (index-- == 0)
				{
					value = enumerator.Current;
					return true;
				}
			}
			value = null;
			return false;
		}
	}
	public class EnumerableMemberAccessor : IMemberAccessor
	{
		public static EnumerableMemberAccessor Create(Type type)
		{
			if (type.IsAssignableToGenericType(typeof(IList<>), out var resolvedType))
			{
				Type type2 = resolvedType.GenericTypeArguments[0];
				return (EnumerableMemberAccessor)Activator.CreateInstance(typeof(ListMemberAccessor<, >).MakeGenericType(resolvedType, type2));
			}
			if (type.IsAssignableToGenericType(typeof(IReadOnlyList<>), out resolvedType))
			{
				Type type3 = resolvedType.GenericTypeArguments[0];
				return (EnumerableMemberAccessor)Activator.CreateInstance(typeof(ReadOnlyListMemberAccessor<, >).MakeGenericType(resolvedType, type3));
			}
			if (type.IsAssignableToGenericType(typeof(IEnumerable<>), out resolvedType))
			{
				Type type4 = resolvedType.GenericTypeArguments[0];
				return (EnumerableMemberAccessor)Activator.CreateInstance(typeof(EnumerableMemberAccessor<, >).MakeGenericType(resolvedType, type4));
			}
			return new EnumerableMemberAccessor();
		}

		protected EnumerableMemberAccessor()
		{
		}

		public virtual bool TryGetValue(object instance, ChainSegment memberName, out object value)
		{
			if (int.TryParse(memberName.LowerInvariant, out var result) && result >= 0)
			{
				return TryGetValueInternal(instance, result, out value);
			}
			value = null;
			return false;
		}

		protected virtual bool TryGetValueInternal(object instance, int index, out object value)
		{
			IEnumerable enumerable;
			if (!(instance is IList list))
			{
				enumerable = instance as IEnumerable;
				if (enumerable == null)
				{
					value = null;
					return false;
				}
			}
			else
			{
				if (list.Count > index)
				{
					value = list[index];
					return true;
				}
				enumerable = (IEnumerable)instance;
			}
			IEnumerator enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (index-- == 0)
				{
					value = enumerator.Current;
					return true;
				}
			}
			value = null;
			return false;
		}
	}
}

using System;
using System.Collections;
using System.Linq;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.MemberAliasProvider
{
	internal sealed class CollectionMemberAliasProvider : IMemberAliasProvider, IMemberAliasProvider<object>
	{
		private static readonly ChainSegment Count = ChainSegment.Create("Count");

		private static readonly ChainSegment Length = ChainSegment.Create("Length");

		public bool TryGetMemberByAlias(object instance, Type targetType, ChainSegment memberAlias, out object value)
		{
			ICollection collection;
			IEnumerable enumerable;
			if (!(instance is Array array))
			{
				collection = instance as ICollection;
				if (collection == null)
				{
					enumerable = instance as IEnumerable;
					if (enumerable != null)
					{
						goto IL_0087;
					}
					goto IL_0108;
				}
			}
			else
			{
				Array array2 = array;
				if (memberAlias.Equals(Count))
				{
					value = array2.Length;
					return true;
				}
				collection = (ICollection)instance;
			}
			ICollection collection2 = collection;
			if (!memberAlias.Equals(Length))
			{
				enumerable = (IEnumerable)instance;
				goto IL_0087;
			}
			value = collection2.Count;
			return true;
			IL_0087:
			IEnumerable enumerable2 = enumerable;
			if (ObjectDescriptorFactory.Current.TryGetDescriptor(targetType, out var value2) && value2.GetProperties != null)
			{
				ChainSegment chainSegment = value2.GetProperties(value2, enumerable2).OfType<ChainSegment>().FirstOrDefault(delegate(ChainSegment o)
				{
					string text = o.ToString().ToLowerInvariant();
					return text.Equals("length") || text.Equals("count");
				});
				if (chainSegment != null && value2.MemberAccessor.TryGetValue(enumerable2, chainSegment.ToString(), out value))
				{
					return true;
				}
				value = null;
				return false;
			}
			goto IL_0108;
			IL_0108:
			value = null;
			return false;
		}
	}
}

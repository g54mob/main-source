using System.Collections.Generic;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.MemberAccessors.DictionaryAccessors
{
	public sealed class ReadOnlyStringDictionaryAccessor<T, TV> : IMemberAccessor where T : IReadOnlyDictionary<string, TV>
	{
		public bool TryGetValue(object instance, ChainSegment memberName, out object value)
		{
			if (((T)instance/*cast due to .constrained prefix*/).TryGetValue(memberName.TrimmedValue, out var value2))
			{
				value = value2;
				return true;
			}
			value = null;
			return false;
		}
	}
}

using System.Collections;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.MemberAccessors
{
	public sealed class DictionaryMemberAccessor : IMemberAccessor
	{
		public bool TryGetValue(object instance, ChainSegment memberName, out object value)
		{
			value = null;
			IDictionary dictionary = (IDictionary)instance;
			value = dictionary[memberName.LowerInvariant];
			return true;
		}
	}
}

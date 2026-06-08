using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.MemberAccessors
{
	public interface IMemberAccessor
	{
		bool TryGetValue(object instance, ChainSegment memberName, out object value);
	}
}

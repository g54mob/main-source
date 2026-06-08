using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.MemberAccessors
{
	public sealed class MergedMemberAccessor : IMemberAccessor
	{
		private readonly IMemberAccessor[] _accessors;

		public MergedMemberAccessor(params IMemberAccessor[] accessors)
		{
			_accessors = accessors;
		}

		public bool TryGetValue(object instance, ChainSegment memberName, out object value)
		{
			for (int i = 0; i < _accessors.Length; i++)
			{
				if (_accessors[i].TryGetValue(instance, memberName, out value))
				{
					return true;
				}
			}
			value = null;
			return false;
		}
	}
}

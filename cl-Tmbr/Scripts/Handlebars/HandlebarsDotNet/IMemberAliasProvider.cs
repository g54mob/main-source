using System;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet
{
	public interface IMemberAliasProvider<in T>
	{
		bool TryGetMemberByAlias(T instance, Type targetType, ChainSegment memberAlias, out object value);
	}
	public interface IMemberAliasProvider : IMemberAliasProvider<object>
	{
	}
}

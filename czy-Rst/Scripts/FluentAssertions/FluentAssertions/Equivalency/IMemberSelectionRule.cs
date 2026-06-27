using System.Collections.Generic;

namespace FluentAssertions.Equivalency
{
	public interface IMemberSelectionRule
	{
		bool IncludesMembers { get; }

		IEnumerable<IMember> SelectMembers(INode currentNode, IEnumerable<IMember> selectedMembers, MemberSelectionContext context);
	}
}

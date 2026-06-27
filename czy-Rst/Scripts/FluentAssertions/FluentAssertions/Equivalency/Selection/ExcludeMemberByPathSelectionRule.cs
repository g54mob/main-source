using System.Collections.Generic;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency.Selection
{
	internal class ExcludeMemberByPathSelectionRule : SelectMemberByPathSelectionRule
	{
		private MemberPath memberToExclude;

		public MemberPath CurrentPath => memberToExclude;

		public ExcludeMemberByPathSelectionRule(MemberPath pathToExclude)
		{
			memberToExclude = pathToExclude;
		}

		protected override void AddOrRemoveMembersFrom(List<IMember> selectedMembers, INode parent, string parentPath, MemberSelectionContext context)
		{
			selectedMembers.RemoveAll((IMember member) => memberToExclude.IsSameAs(new MemberPath(member, parentPath)));
		}

		public void AppendPath(MemberPath nextPath)
		{
			memberToExclude = memberToExclude.AsParentCollectionOf(nextPath);
		}

		public override string ToString()
		{
			return "Exclude member " + memberToExclude;
		}
	}
}

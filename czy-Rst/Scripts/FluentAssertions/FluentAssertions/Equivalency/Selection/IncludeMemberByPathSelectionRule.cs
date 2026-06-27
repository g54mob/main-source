using System.Collections.Generic;
using System.Reflection;
using FluentAssertions.Common;
using Reflectify;

namespace FluentAssertions.Equivalency.Selection
{
	internal class IncludeMemberByPathSelectionRule : SelectMemberByPathSelectionRule
	{
		private readonly MemberPath memberToInclude;

		public override bool IncludesMembers => true;

		public IncludeMemberByPathSelectionRule(MemberPath pathToInclude)
		{
			memberToInclude = pathToInclude;
		}

		protected override void AddOrRemoveMembersFrom(List<IMember> selectedMembers, INode parent, string parentPath, MemberSelectionContext context)
		{
			MemberInfo[] members = context.Type.GetMembers(MemberKind.Public | MemberKind.Internal);
			foreach (MemberInfo memberInfo in members)
			{
				MemberPath candidate = new MemberPath(context.Type, memberInfo.DeclaringType, parentPath.Combine(memberInfo.Name));
				if (memberToInclude.IsSameAs(candidate) || memberToInclude.IsParentOrChildOf(candidate))
				{
					selectedMembers.Add(MemberFactory.Create(memberInfo, parent));
				}
			}
		}

		public override string ToString()
		{
			return "Include member root." + memberToInclude;
		}
	}
}

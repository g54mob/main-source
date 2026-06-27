using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentAssertions.Equivalency.Selection
{
	internal class ExcludeMemberByPredicateSelectionRule : IMemberSelectionRule
	{
		private readonly Func<IMemberInfo, bool> predicate;

		private readonly string description;

		public bool IncludesMembers => false;

		public ExcludeMemberByPredicateSelectionRule(Expression<Func<IMemberInfo, bool>> predicate)
		{
			description = predicate.Body.ToString();
			this.predicate = predicate.Compile();
		}

		public IEnumerable<IMember> SelectMembers(INode currentNode, IEnumerable<IMember> selectedMembers, MemberSelectionContext context)
		{
			return selectedMembers.Where((IMember p) => !predicate(new MemberToMemberInfoAdapter(p))).ToArray();
		}

		public override string ToString()
		{
			return "Exclude member when " + description;
		}
	}
}

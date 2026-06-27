using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions.Common;
using Reflectify;

namespace FluentAssertions.Equivalency.Selection
{
	internal class IncludeMemberByPredicateSelectionRule : IMemberSelectionRule
	{
		private readonly Func<IMemberInfo, bool> predicate;

		private readonly string description;

		public bool IncludesMembers => true;

		public IncludeMemberByPredicateSelectionRule(Expression<Func<IMemberInfo, bool>> predicate)
		{
			description = predicate.Body.ToString();
			this.predicate = predicate.Compile();
		}

		public IEnumerable<IMember> SelectMembers(INode currentNode, IEnumerable<IMember> selectedMembers, MemberSelectionContext context)
		{
			List<IMember> list = new List<IMember>(selectedMembers);
			MemberInfo[] members = currentNode.Type.GetMembers(MemberKind.Public | MemberKind.Internal);
			foreach (MemberInfo memberInfo in members)
			{
				IMember member = MemberFactory.Create(memberInfo, currentNode);
				if (predicate(new MemberToMemberInfoAdapter(member)) && !list.Exists((IMember p) => p.IsEquivalentTo(member)))
				{
					list.Add(member);
				}
			}
			return list;
		}

		public override string ToString()
		{
			return "Include member when " + description;
		}
	}
}

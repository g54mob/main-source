using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Reflectify;

namespace FluentAssertions.Equivalency.Selection
{
	internal class AllFieldsSelectionRule : IMemberSelectionRule
	{
		public bool IncludesMembers => false;

		public IEnumerable<IMember> SelectMembers(INode currentNode, IEnumerable<IMember> selectedMembers, MemberSelectionContext context)
		{
			IEnumerable<IMember> second = from info in context.Type.GetFields(context.IncludedFields.ToMemberKind())
				select new Field(info, currentNode);
			return selectedMembers.Union(second).ToList();
		}

		public override string ToString()
		{
			return "Include all non-private fields";
		}
	}
}

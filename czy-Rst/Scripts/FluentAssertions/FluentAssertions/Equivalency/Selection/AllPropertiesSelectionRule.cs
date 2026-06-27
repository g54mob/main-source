using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Reflectify;

namespace FluentAssertions.Equivalency.Selection
{
	internal class AllPropertiesSelectionRule : IMemberSelectionRule
	{
		public bool IncludesMembers => false;

		public IEnumerable<IMember> SelectMembers(INode currentNode, IEnumerable<IMember> selectedMembers, MemberSelectionContext context)
		{
			MemberVisibility includedProperties = context.IncludedProperties;
			IEnumerable<IMember> second = from info in context.Type.GetProperties(includedProperties.ToMemberKind()).Where(delegate(PropertyInfo property)
				{
					MethodInfo getMethod = property.GetMethod;
					return (object)getMethod != null && !getMethod.IsPrivate;
				})
				select new Property(context.Type, info, currentNode);
			return selectedMembers.Union(second).ToList();
		}

		public override string ToString()
		{
			return "Include all non-private properties";
		}
	}
}

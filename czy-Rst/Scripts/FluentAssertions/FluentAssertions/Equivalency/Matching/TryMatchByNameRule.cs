using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Matching
{
	internal class TryMatchByNameRule : IMemberMatchingRule
	{
		public IMember Match(IMember expectedMember, object subject, INode parent, IEquivalencyOptions options, AssertionChain assertionChain)
		{
			if (options.IncludedProperties != MemberVisibility.None)
			{
				PropertyInfo propertyInfo = subject.GetType().FindProperty(expectedMember.Expectation.Name, options.IncludedProperties | MemberVisibility.ExplicitlyImplemented);
				if ((object)propertyInfo != null && !propertyInfo.IsIndexer())
				{
					return new Property(propertyInfo, parent);
				}
			}
			FieldInfo fieldInfo = subject.GetType().FindField(expectedMember.Expectation.Name, options.IncludedFields);
			if ((object)fieldInfo == null)
			{
				return null;
			}
			return new Field(fieldInfo, parent);
		}

		public override string ToString()
		{
			return "Try to match member by name";
		}
	}
}

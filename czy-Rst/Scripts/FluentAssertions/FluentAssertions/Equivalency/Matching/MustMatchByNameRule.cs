using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Matching
{
	internal class MustMatchByNameRule : IMemberMatchingRule
	{
		public IMember Match(IMember expectedMember, object subject, INode parent, IEquivalencyOptions options, AssertionChain assertionChain)
		{
			IMember member = null;
			if (options.IncludedProperties != MemberVisibility.None)
			{
				PropertyInfo propertyInfo = subject.GetType().FindProperty(expectedMember.Subject.Name, options.IncludedProperties | MemberVisibility.ExplicitlyImplemented | MemberVisibility.DefaultInterfaceProperties);
				member = (((object)propertyInfo != null && !propertyInfo.IsIndexer()) ? new Property(propertyInfo, parent) : null);
			}
			if (member == null && options.IncludedFields != MemberVisibility.None)
			{
				FieldInfo fieldInfo = subject.GetType().FindField(expectedMember.Subject.Name, options.IncludedFields);
				member = (((object)fieldInfo != null) ? new Field(fieldInfo, parent) : null);
			}
			if (member == null)
			{
				assertionChain.FailWith("Expectation has {0} that the other object does not have.", expectedMember.Expectation.AsNonFormattable());
			}
			else if (options.IgnoreNonBrowsableOnSubject && !member.IsBrowsable)
			{
				assertionChain.FailWith("Expectation has {0} that is non-browsable in the other object, and non-browsable members on the subject are ignored with the current configuration", expectedMember.Expectation.AsNonFormattable());
			}
			return member;
		}

		public override string ToString()
		{
			return "Match member by name (or throw)";
		}
	}
}

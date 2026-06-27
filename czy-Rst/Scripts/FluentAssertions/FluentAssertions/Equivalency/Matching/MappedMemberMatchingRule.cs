using System;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Matching
{
	internal class MappedMemberMatchingRule<TExpectation, TSubject> : IMemberMatchingRule
	{
		private readonly string expectationMemberName;

		private readonly string subjectMemberName;

		public MappedMemberMatchingRule(string expectationMemberName, string subjectMemberName)
		{
			if (IsNestedPath(expectationMemberName))
			{
				throw new ArgumentException("The expectation's member name cannot be a nested path", "expectationMemberName");
			}
			if (IsNestedPath(subjectMemberName))
			{
				throw new ArgumentException("The subject's member name cannot be a nested path", "subjectMemberName");
			}
			this.expectationMemberName = expectationMemberName;
			this.subjectMemberName = subjectMemberName;
		}

		private static bool IsNestedPath(string path)
		{
			if (!SystemExtensions.Contains(path, '.', StringComparison.Ordinal) && !SystemExtensions.Contains(path, '[', StringComparison.Ordinal))
			{
				return SystemExtensions.Contains(path, ']', StringComparison.Ordinal);
			}
			return true;
		}

		public IMember Match(IMember expectedMember, object subject, INode parent, IEquivalencyOptions options, AssertionChain assertionChain)
		{
			if (parent.Type.IsSameOrInherits(typeof(TExpectation)) && subject is TSubject && expectedMember.Subject.Name == expectationMemberName)
			{
				IMember member = MemberFactory.Find(subject, subjectMemberName, parent);
				return member ?? throw new MissingMemberException($"Subject of type {typeof(TSubject)} does not have member {subjectMemberName}");
			}
			return null;
		}
	}
}

using System;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Matching
{
	internal class MappedPathMatchingRule : IMemberMatchingRule
	{
		private readonly MemberPath expectationPath;

		private readonly MemberPath subjectPath;

		public MappedPathMatchingRule(string expectationMemberPath, string subjectMemberPath)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(expectationMemberPath, "expectationMemberPath", "A member path cannot be null");
			Guard.ThrowIfArgumentIsNullOrEmpty(subjectMemberPath, "subjectMemberPath", "A member path cannot be null");
			expectationPath = new MemberPath(expectationMemberPath);
			subjectPath = new MemberPath(subjectMemberPath);
			if (expectationPath.GetContainsSpecificCollectionIndex() || subjectPath.GetContainsSpecificCollectionIndex())
			{
				throw new ArgumentException("Mapping properties containing a collection index must use the [] format without specific index.");
			}
			if (!expectationPath.HasSameParentAs(subjectPath))
			{
				throw new ArgumentException("The member paths must have the same parent.");
			}
		}

		public IMember Match(IMember expectedMember, object subject, INode parent, IEquivalencyOptions options, AssertionChain assertionChain)
		{
			MemberPath memberPath = expectationPath;
			if (expectedMember.RootIsCollection)
			{
				memberPath = memberPath.WithCollectionAsRoot();
			}
			if (memberPath.IsEquivalentTo(expectedMember.Expectation.PathAndName))
			{
				return MemberFactory.Find(subject, subjectPath.MemberName, parent) ?? throw new MissingMemberException("Subject of type " + subject?.GetType().Name + " does not have member " + subjectPath.MemberName);
			}
			return null;
		}
	}
}

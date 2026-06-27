using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Equivalency.Selection;

namespace FluentAssertions.Equivalency
{
	public class NestedExclusionOptionBuilder<TExpectation, TCurrent>
	{
		private readonly ExcludeMemberByPathSelectionRule currentPathSelectionRule;

		private readonly EquivalencyOptions<TExpectation> capturedOptions;

		internal NestedExclusionOptionBuilder(EquivalencyOptions<TExpectation> capturedOptions, ExcludeMemberByPathSelectionRule currentPathSelectionRule)
		{
			this.capturedOptions = capturedOptions;
			this.currentPathSelectionRule = currentPathSelectionRule;
		}

		public EquivalencyOptions<TExpectation> Exclude(Expression<Func<TCurrent, object>> expression)
		{
			MemberPath currentPath = currentPathSelectionRule.CurrentPath;
			foreach (MemberPath memberPath in expression.GetMemberPaths())
			{
				MemberPath pathToExclude = currentPath.AsParentCollectionOf(memberPath);
				capturedOptions.AddSelectionRule(new ExcludeMemberByPathSelectionRule(pathToExclude));
			}
			return capturedOptions;
		}

		public NestedExclusionOptionBuilder<TExpectation, TNext> For<TNext>(Expression<Func<TCurrent, IEnumerable<TNext>>> expression)
		{
			MemberPath memberPath = expression.GetMemberPath();
			currentPathSelectionRule.AppendPath(memberPath);
			return new NestedExclusionOptionBuilder<TExpectation, TNext>(capturedOptions, currentPathSelectionRule);
		}
	}
}

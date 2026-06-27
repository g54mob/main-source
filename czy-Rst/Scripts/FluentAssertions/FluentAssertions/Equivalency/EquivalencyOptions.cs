using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Equivalency.Execution;
using FluentAssertions.Equivalency.Matching;
using FluentAssertions.Equivalency.Ordering;
using FluentAssertions.Equivalency.Selection;

namespace FluentAssertions.Equivalency
{
	public class EquivalencyOptions<TExpectation> : SelfReferenceEquivalencyOptions<EquivalencyOptions<TExpectation>>
	{
		public EquivalencyOptions()
		{
		}

		public EquivalencyOptions(IEquivalencyOptions defaults)
			: base(defaults)
		{
		}

		public EquivalencyOptions<TExpectation> Excluding(Expression<Func<TExpectation, object>> expression)
		{
			foreach (MemberPath memberPath in expression.GetMemberPaths())
			{
				AddSelectionRule(new ExcludeMemberByPathSelectionRule(memberPath));
			}
			return this;
		}

		public NestedExclusionOptionBuilder<TExpectation, TNext> For<TNext>(Expression<Func<TExpectation, IEnumerable<TNext>>> expression)
		{
			return new NestedExclusionOptionBuilder<TExpectation, TNext>(this, new ExcludeMemberByPathSelectionRule(expression.GetMemberPath()));
		}

		public EquivalencyOptions<TExpectation> Including(Expression<Func<TExpectation, object>> expression)
		{
			foreach (MemberPath memberPath in expression.GetMemberPaths())
			{
				AddSelectionRule(new IncludeMemberByPathSelectionRule(memberPath));
			}
			return this;
		}

		public EquivalencyOptions<TExpectation> WithStrictOrderingFor(Expression<Func<TExpectation, object>> expression)
		{
			string path = expression.GetMemberPath().ToString();
			base.OrderingRules.Add(new PathBasedOrderingRule(path));
			return this;
		}

		public EquivalencyOptions<TExpectation> WithoutStrictOrderingFor(Expression<Func<TExpectation, object>> expression)
		{
			string path = expression.GetMemberPath().ToString();
			base.OrderingRules.Add(new PathBasedOrderingRule(path)
			{
				Invert = true
			});
			return this;
		}

		public EquivalencyOptions<IEnumerable<TExpectation>> AsCollection()
		{
			return new EquivalencyOptions<IEnumerable<TExpectation>>(new CollectionMemberOptionsDecorator(this));
		}

		public EquivalencyOptions<TExpectation> WithMapping<TSubject>(Expression<Func<TExpectation, object>> expectationMemberPath, Expression<Func<TSubject, object>> subjectMemberPath)
		{
			return WithMapping(expectationMemberPath.GetMemberPath().ToString().WithoutSpecificCollectionIndices(), subjectMemberPath.GetMemberPath().ToString().WithoutSpecificCollectionIndices());
		}

		public EquivalencyOptions<TExpectation> WithMapping(string expectationMemberPath, string subjectMemberPath)
		{
			AddMatchingRule(new MappedPathMatchingRule(expectationMemberPath, subjectMemberPath));
			return this;
		}

		public EquivalencyOptions<TExpectation> WithMapping<TNestedExpectation, TNestedSubject>(Expression<Func<TNestedExpectation, object>> expectationMember, Expression<Func<TNestedSubject, object>> subjectMember)
		{
			return WithMapping<TNestedExpectation, TNestedSubject>(expectationMember.GetMemberPath().ToString(), subjectMember.GetMemberPath().ToString());
		}

		public EquivalencyOptions<TExpectation> WithMapping<TNestedExpectation, TNestedSubject>(string expectationMemberName, string subjectMemberName)
		{
			AddMatchingRule(new MappedMemberMatchingRule<TNestedExpectation, TNestedSubject>(expectationMemberName, subjectMemberName));
			return this;
		}
	}
	public class EquivalencyOptions : SelfReferenceEquivalencyOptions<EquivalencyOptions>
	{
		public EquivalencyOptions()
		{
			IncludingNestedObjects();
			IncludingFields();
			IncludingProperties();
			PreferringDeclaredMemberTypes();
		}
	}
}

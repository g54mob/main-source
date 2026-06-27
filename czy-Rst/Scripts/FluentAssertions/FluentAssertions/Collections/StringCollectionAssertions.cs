using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;

namespace FluentAssertions.Collections
{
	public class StringCollectionAssertions : StringCollectionAssertions<IEnumerable<string>>
	{
		public StringCollectionAssertions(IEnumerable<string> actualValue, AssertionChain assertionChain)
			: base(actualValue, assertionChain)
		{
		}
	}
	public class StringCollectionAssertions<TCollection> : StringCollectionAssertions<TCollection, StringCollectionAssertions<TCollection>> where TCollection : IEnumerable<string>
	{
		public StringCollectionAssertions(TCollection actualValue, AssertionChain assertionChain)
			: base(actualValue, assertionChain)
		{
		}
	}
	public class StringCollectionAssertions<TCollection, TAssertions> : GenericCollectionAssertions<TCollection, string, TAssertions> where TCollection : IEnumerable<string> where TAssertions : StringCollectionAssertions<TCollection, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		public StringCollectionAssertions(TCollection actualValue, AssertionChain assertionChain)
			: base(actualValue, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public new AndConstraint<TAssertions> Equal(params string[] expected)
		{
			return Equal(expected.AsEnumerable(), "");
		}

		public AndConstraint<TAssertions> Equal(IEnumerable<string> expected)
		{
			return Equal(expected, "");
		}

		public AndConstraint<TAssertions> BeEquivalentTo(params string[] expectation)
		{
			return BeEquivalentTo(expectation, (EquivalencyOptions<string> config) => config, "");
		}

		public AndConstraint<TAssertions> BeEquivalentTo(IEnumerable<string> expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeEquivalentTo(expectation, (EquivalencyOptions<string> config) => config, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeEquivalentTo(IEnumerable<string> expectation, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<IEnumerable<string>> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>()).AsCollection();
			EquivalencyValidationContext context = new EquivalencyValidationContext(Node.From<IEnumerable<string>>(() => base.CurrentAssertionChain.CallerIdentifier), equivalencyOptions)
			{
				Reason = new Reason(because, becauseArgs),
				TraceWriter = equivalencyOptions.TraceWriter
			};
			Comparands comparands = new Comparands
			{
				Subject = base.Subject,
				Expectation = expectation,
				CompileTimeType = typeof(IEnumerable<string>)
			};
			new EquivalencyValidator().AssertEquality(comparands, context);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> AllBe(string expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return AllBe(expectation, (EquivalencyOptions<string> options) => options, because, becauseArgs);
		}

		public AndConstraint<TAssertions> AllBe(string expectation, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			string[] expectation2 = GenericCollectionAssertions<TCollection, string, TAssertions>.RepeatAsManyAs(expectation, base.Subject).ToArray();
			Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config2 = (EquivalencyOptions<string> x) => config(x).WithStrictOrderingFor((IObjectInfo s) => string.IsNullOrEmpty(s.Path));
			return BeEquivalentTo(expectation2, config2, because, becauseArgs);
		}

		public AndWhichConstraint<TAssertions, string> ContainMatch(string wildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match strings in collection against <null>. Provide a wildcard pattern or use the Contain method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match strings in collection against an empty string. Provide a wildcard pattern or use the Contain method.");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain a match of {0}{reason}, but found <null>.", wildcardPattern);
			string[] array = Array.Empty<string>();
			int? num = null;
			if (assertionChain.Succeeded)
			{
				(array, num) = AllThatMatch(wildcardPattern);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(array.Length != 0).FailWith("Expected {context:collection} {0} to contain a match of {1}{reason}.", base.Subject, wildcardPattern);
			}
			TAssertions parent = (TAssertions)this;
			string[] subjects = array;
			AssertionChain obj = assertionChain;
			int? num2 = num;
			return new AndWhichConstraint<TAssertions, string>(parent, subjects, obj, "[" + num2 + "]");
		}

		private (string[] MatchingItems, int? FirstMatchingIndex) AllThatMatch(string wildcardPattern)
		{
			int? firstMatchingIndex = null;
			return (MatchingItems: base.Subject.Where(delegate(string item, int index)
			{
				using AssertionScope assertionScope = new AssertionScope();
				item.Should().Match(wildcardPattern, "");
				if (assertionScope.Discard().Length == 0)
				{
					int valueOrDefault = firstMatchingIndex.GetValueOrDefault();
					if (!firstMatchingIndex.HasValue)
					{
						valueOrDefault = index;
						firstMatchingIndex = valueOrDefault;
					}
					return true;
				}
				return false;
			}).ToArray(), FirstMatchingIndex: firstMatchingIndex);
		}

		public AndConstraint<TAssertions> NotContainMatch(string wildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match strings in collection against <null>. Provide a wildcard pattern or use the NotContain method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match strings in collection against an empty string. Provide a wildcard pattern or use the NotContain method.");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Did not expect {context:collection} to contain a match of {0}{reason}, but found <null>.", wildcardPattern);
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(NotContainsMatch(wildcardPattern)).FailWith("Did not expect {context:collection} {0} to contain a match of {1}{reason}.", base.Subject, wildcardPattern);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		private bool NotContainsMatch(string wildcardPattern)
		{
			AssertionScope scope = new AssertionScope();
			try
			{
				return base.Subject.All(delegate(string item)
				{
					item.Should().NotMatch(wildcardPattern, "");
					return scope.Discard().Length == 0;
				});
			}
			finally
			{
				if (scope != null)
				{
					((IDisposable)scope).Dispose();
				}
			}
		}
	}
}

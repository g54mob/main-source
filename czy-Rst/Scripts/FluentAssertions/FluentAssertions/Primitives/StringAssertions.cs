using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public class StringAssertions : StringAssertions<StringAssertions>
	{
		public StringAssertions(string value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class StringAssertions<TAssertions> : ReferenceTypeAssertions<string, TAssertions> where TAssertions : StringAssertions<TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "string";

		public StringAssertions(string value, AssertionChain assertionChain)
			: base(value, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> Be(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			new StringValidator(assertionChain, new StringEqualityStrategy(StringComparer.Ordinal, "be"), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeOneOf(params string[] validValues)
		{
			return BeOneOf(validValues, string.Empty);
		}

		public AndConstraint<TAssertions> BeOneOf(IEnumerable<string> validValues, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(validValues.Contains(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} to be one of {0}{reason}, but found {1}.", validValues, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeEquivalentTo(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			new StringValidator(assertionChain, new StringEqualityStrategy(StringComparer.OrdinalIgnoreCase, "be equivalent to"), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeEquivalentTo(string expected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<string> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>());
			StringValidator stringValidator = new StringValidator(assertionChain, new StringEqualityStrategy(equivalencyOptions.GetStringComparerOrDefault(), "be equivalent to"), because, becauseArgs);
			string subject = ApplyStringSettings(base.Subject, equivalencyOptions);
			expected = ApplyStringSettings(expected, equivalencyOptions);
			stringValidator.Validate(subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeEquivalentTo(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			bool condition;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				BeEquivalentTo(unexpected, "");
				condition = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to be equivalent to {0}{reason}, but they are.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeEquivalentTo(string unexpected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			bool condition;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().BeEquivalentTo(unexpected, config, "");
				condition = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to be equivalent to {0}{reason}, but they are.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBe(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != unexpected).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to be {0}{reason}.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Match(string wildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match string against <null>. Provide a wildcard pattern or use the BeNull method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match string against an empty string. Provide a wildcard pattern or use the BeEmpty method.");
			new StringValidator(assertionChain, new StringWildcardMatchingStrategy(), because, becauseArgs).Validate(base.Subject, wildcardPattern);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotMatch(string wildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match string against <null>. Provide a wildcard pattern or use the NotBeNull method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match string against an empty string. Provide a wildcard pattern or use the NotBeEmpty method.");
			new StringValidator(assertionChain, new StringWildcardMatchingStrategy
			{
				Negate = true
			}, because, becauseArgs).Validate(base.Subject, wildcardPattern);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> MatchEquivalentOf(string wildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match string against <null>. Provide a wildcard pattern or use the BeNull method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match string against an empty string. Provide a wildcard pattern or use the BeEmpty method.");
			new StringValidator(assertionChain, new StringWildcardMatchingStrategy
			{
				IgnoreCase = true,
				IgnoreAllNewlines = true
			}, because, becauseArgs).Validate(base.Subject, wildcardPattern);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> MatchEquivalentOf(string wildcardPattern, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match string against <null>. Provide a wildcard pattern or use the BeNull method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match string against an empty string. Provide a wildcard pattern or use the BeEmpty method.");
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<string> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>());
			StringValidator stringValidator = new StringValidator(assertionChain, new StringWildcardMatchingStrategy
			{
				IgnoreCase = equivalencyOptions.IgnoreCase,
				IgnoreNewlineStyle = equivalencyOptions.IgnoreNewlineStyle
			}, because, becauseArgs);
			string subject = ApplyStringSettings(base.Subject, equivalencyOptions);
			wildcardPattern = ApplyStringSettings(wildcardPattern, equivalencyOptions);
			stringValidator.Validate(subject, wildcardPattern);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotMatchEquivalentOf(string wildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match string against <null>. Provide a wildcard pattern or use the NotBeNull method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match string against an empty string. Provide a wildcard pattern or use the NotBeEmpty method.");
			new StringValidator(assertionChain, new StringWildcardMatchingStrategy
			{
				IgnoreCase = true,
				IgnoreAllNewlines = true,
				Negate = true
			}, because, becauseArgs).Validate(base.Subject, wildcardPattern);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotMatchEquivalentOf(string wildcardPattern, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(wildcardPattern, "wildcardPattern", "Cannot match string against <null>. Provide a wildcard pattern or use the NotBeNull method.");
			Guard.ThrowIfArgumentIsEmpty(wildcardPattern, "wildcardPattern", "Cannot match string against an empty string. Provide a wildcard pattern or use the NotBeEmpty method.");
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<string> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>());
			StringValidator stringValidator = new StringValidator(assertionChain, new StringWildcardMatchingStrategy
			{
				IgnoreCase = equivalencyOptions.IgnoreCase,
				IgnoreNewlineStyle = equivalencyOptions.IgnoreNewlineStyle,
				Negate = true
			}, because, becauseArgs);
			string subject = ApplyStringSettings(base.Subject, equivalencyOptions);
			wildcardPattern = ApplyStringSettings(wildcardPattern, equivalencyOptions);
			stringValidator.Validate(subject, wildcardPattern);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> MatchRegex([StringSyntax("Regex")] string regularExpression, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(regularExpression, "regularExpression", "Cannot match string against <null>. Provide a regex pattern or use the BeNull method.");
			Regex regularExpression2;
			try
			{
				regularExpression2 = new Regex(regularExpression);
			}
			catch (ArgumentException)
			{
				assertionChain.FailWith("Cannot match {context:string} against {0} because it is not a valid regular expression.", regularExpression);
				return new AndConstraint<TAssertions>((TAssertions)this);
			}
			return MatchRegex(regularExpression2, occurrenceConstraint, because, becauseArgs);
		}

		public AndConstraint<TAssertions> MatchRegex([StringSyntax("Regex")] string regularExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(regularExpression, "regularExpression", "Cannot match string against <null>. Provide a regex pattern or use the BeNull method.");
			Regex regularExpression2;
			try
			{
				regularExpression2 = new Regex(regularExpression);
			}
			catch (ArgumentException)
			{
				assertionChain.FailWith("Cannot match {context:string} against {0} because it is not a valid regular expression.", regularExpression);
				return new AndConstraint<TAssertions>((TAssertions)this);
			}
			return MatchRegex(regularExpression2, because, becauseArgs);
		}

		public AndConstraint<TAssertions> MatchRegex(Regex regularExpression, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(regularExpression, "regularExpression", "Cannot match string against <null>. Provide a regex pattern or use the BeNull method.");
			string text = regularExpression.ToString();
			Guard.ThrowIfArgumentIsEmpty(text, "regularExpression", "Cannot match string against an empty string. Provide a regex pattern or use the BeEmpty method.");
			assertionChain.ForCondition(base.Subject != null).UsingLineBreaks.BecauseOf(because, becauseArgs).FailWith("Expected {context:string} to match regex {0}{reason}, but it was <null>.", text);
			if (assertionChain.Succeeded)
			{
				int count = regularExpression.Matches(base.Subject).Count;
				assertionChain.ForConstraint(occurrenceConstraint, count).UsingLineBreaks.BecauseOf(because, becauseArgs).FailWith("Expected {context:string} {0} to match regex {1} {expectedOccurrence}{reason}, but found it " + count.Times() + ".", base.Subject, text);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> MatchRegex(Regex regularExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(regularExpression, "regularExpression", "Cannot match string against <null>. Provide a regex pattern or use the BeNull method.");
			string text = regularExpression.ToString();
			Guard.ThrowIfArgumentIsEmpty(text, "regularExpression", "Cannot match string against an empty string. Provide a regex pattern or use the BeEmpty method.");
			assertionChain.ForCondition(base.Subject != null).UsingLineBreaks.BecauseOf(because, becauseArgs).FailWith("Expected {context:string} to match regex {0}{reason}, but it was <null>.", text);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(regularExpression.IsMatch(base.Subject)).BecauseOf(because, becauseArgs).UsingLineBreaks.FailWith("Expected {context:string} to match regex {0}{reason}, but {1} does not match.", text, base.Subject);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotMatchRegex([StringSyntax("Regex")] string regularExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(regularExpression, "regularExpression", "Cannot match string against <null>. Provide a regex pattern or use the NotBeNull method.");
			Regex regularExpression2;
			try
			{
				regularExpression2 = new Regex(regularExpression);
			}
			catch (ArgumentException)
			{
				assertionChain.FailWith("Cannot match {context:string} against {0} because it is not a valid regular expression.", regularExpression);
				return new AndConstraint<TAssertions>((TAssertions)this);
			}
			return NotMatchRegex(regularExpression2, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotMatchRegex(Regex regularExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(regularExpression, "regularExpression", "Cannot match string against <null>. Provide a regex pattern or use the NotBeNull method.");
			string text = regularExpression.ToString();
			Guard.ThrowIfArgumentIsEmpty(text, "regularExpression", "Cannot match string against an empty regex pattern. Provide a regex pattern or use the NotBeEmpty method.");
			assertionChain.ForCondition(base.Subject != null).UsingLineBreaks.BecauseOf(because, becauseArgs).FailWith("Expected {context:string} to not match regex {0}{reason}, but it was <null>.", text);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(!regularExpression.IsMatch(base.Subject)).BecauseOf(because, becauseArgs).UsingLineBreaks.FailWith("Did not expect {context:string} to match regex {0}{reason}, but {1} matches.", text, base.Subject);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> StartWith(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare start of string with <null>.");
			new StringValidator(assertionChain, new StringStartStrategy(StringComparer.Ordinal, "start with"), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotStartWith(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare start of string with <null>.");
			bool flag;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().StartWith(unexpected, "");
				flag = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(base.Subject != null && flag).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to start with {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> StartWithEquivalentOf(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare string start equivalence with <null>.");
			new StringValidator(assertionChain, new StringStartStrategy(StringComparer.OrdinalIgnoreCase, "start with equivalent of"), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> StartWithEquivalentOf(string expected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare string start equivalence with <null>.");
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<string> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>());
			StringValidator stringValidator = new StringValidator(assertionChain, new StringStartStrategy(equivalencyOptions.GetStringComparerOrDefault(), "start with equivalent of"), because, becauseArgs);
			string subject = ApplyStringSettings(base.Subject, equivalencyOptions);
			expected = ApplyStringSettings(expected, equivalencyOptions);
			stringValidator.Validate(subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotStartWithEquivalentOf(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare start of string with <null>.");
			bool flag;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().StartWithEquivalentOf(unexpected, "");
				flag = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(base.Subject != null && flag).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to start with equivalent of {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotStartWithEquivalentOf(string unexpected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare start of string with <null>.");
			Guard.ThrowIfArgumentIsNull(config, "config");
			bool flag;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().StartWithEquivalentOf(unexpected, config, "");
				flag = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(base.Subject != null && flag).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to start with equivalent of {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> EndWith(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare string end with <null>.");
			new StringValidator(assertionChain, new StringEndStrategy(StringComparer.Ordinal, "end with"), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotEndWith(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare end of string with <null>.");
			bool flag;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().EndWith(unexpected, "");
				flag = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(base.Subject != null && flag).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to end with {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> EndWithEquivalentOf(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare string end equivalence with <null>.");
			new StringValidator(assertionChain, new StringEndStrategy(StringComparer.OrdinalIgnoreCase, "end with equivalent of"), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> EndWithEquivalentOf(string expected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare string end equivalence with <null>.");
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<string> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>());
			StringValidator stringValidator = new StringValidator(assertionChain, new StringEndStrategy(equivalencyOptions.GetStringComparerOrDefault(), "end with equivalent of"), because, becauseArgs);
			string subject = ApplyStringSettings(base.Subject, equivalencyOptions);
			expected = ApplyStringSettings(expected, equivalencyOptions);
			stringValidator.Validate(subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotEndWithEquivalentOf(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare end of string with <null>.");
			bool flag;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().EndWithEquivalentOf(unexpected, "");
				flag = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(base.Subject != null && flag).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to end with equivalent of {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotEndWithEquivalentOf(string unexpected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare end of string with <null>.");
			Guard.ThrowIfArgumentIsNull(config, "config");
			bool flag;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().EndWithEquivalentOf(unexpected, config, "");
				flag = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(base.Subject != null && flag).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to end with equivalent of {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Contain(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert string containment against <null>.");
			Guard.ThrowIfArgumentIsEmpty(expected, "expected", "Cannot assert string containment against an empty string.");
			assertionChain.ForCondition(Contains(base.Subject, expected, StringComparison.Ordinal)).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} {0} to contain {1}{reason}.", base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Contain(string expected, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert string containment against <null>.");
			Guard.ThrowIfArgumentIsEmpty(expected, "expected", "Cannot assert string containment against an empty string.");
			int num = base.Subject.CountSubstring(expected, StringComparer.Ordinal);
			assertionChain.ForConstraint(occurrenceConstraint, num).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} {0} to contain {1} {expectedOccurrence}{reason}, but found it " + num.Times() + ".", base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainEquivalentOf(string expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert string containment against <null>.");
			Guard.ThrowIfArgumentIsEmpty(expected, "expected", "Cannot assert string containment against an empty string.");
			new StringValidatorSupportingNull(assertionChain, new StringContainsStrategy(StringComparer.OrdinalIgnoreCase, AtLeast.Once()), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainEquivalentOf(string expected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return ContainEquivalentOf(expected, AtLeast.Once(), config, because, becauseArgs);
		}

		public AndConstraint<TAssertions> ContainEquivalentOf(string expected, OccurrenceConstraint occurrenceConstraint, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert string containment against <null>.");
			Guard.ThrowIfArgumentIsEmpty(expected, "expected", "Cannot assert string containment against an empty string.");
			Guard.ThrowIfArgumentIsNull(occurrenceConstraint, "occurrenceConstraint");
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<string> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>());
			StringValidatorSupportingNull stringValidatorSupportingNull = new StringValidatorSupportingNull(assertionChain, new StringContainsStrategy(equivalencyOptions.GetStringComparerOrDefault(), occurrenceConstraint), because, becauseArgs);
			string subject = ApplyStringSettings(base.Subject, equivalencyOptions);
			expected = ApplyStringSettings(expected, equivalencyOptions);
			stringValidatorSupportingNull.Validate(subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainEquivalentOf(string expected, OccurrenceConstraint occurrenceConstraint, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot assert string containment against <null>.");
			Guard.ThrowIfArgumentIsEmpty(expected, "expected", "Cannot assert string containment against an empty string.");
			Guard.ThrowIfArgumentIsNull(occurrenceConstraint, "occurrenceConstraint");
			new StringValidatorSupportingNull(assertionChain, new StringContainsStrategy(StringComparer.OrdinalIgnoreCase, occurrenceConstraint), because, becauseArgs).Validate(base.Subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainAll(IEnumerable<string> values, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ThrowIfValuesNullOrEmpty(values);
			IEnumerable<string> enumerable = values.Where((string v) => !Contains(base.Subject, v, StringComparison.Ordinal));
			assertionChain.ForCondition(values.All((string v) => Contains(base.Subject, v, StringComparison.Ordinal))).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} {0} to contain the strings: {1}{reason}.", base.Subject, enumerable);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainAll(params string[] values)
		{
			return ContainAll(values, string.Empty);
		}

		public AndConstraint<TAssertions> ContainAny(IEnumerable<string> values, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ThrowIfValuesNullOrEmpty(values);
			assertionChain.ForCondition(values.Any((string v) => Contains(base.Subject, v, StringComparison.Ordinal))).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} {0} to contain at least one of the strings: {1}{reason}.", base.Subject, values);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainAny(params string[] values)
		{
			return ContainAny(values, string.Empty);
		}

		public AndConstraint<TAssertions> NotContain(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot assert string containment against <null>.");
			Guard.ThrowIfArgumentIsEmpty(unexpected, "unexpected", "Cannot assert string containment against an empty string.");
			assertionChain.ForCondition(!Contains(base.Subject, unexpected, StringComparison.Ordinal)).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} {0} to contain {1}{reason}.", base.Subject, unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainAll(IEnumerable<string> values, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ThrowIfValuesNullOrEmpty(values);
			int num = values.Count((string v) => Contains(base.Subject, v, StringComparison.Ordinal));
			assertionChain.ForCondition(num != values.Count()).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} {0} to contain all of the strings: {1}{reason}.", base.Subject, values);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainAll(params string[] values)
		{
			return NotContainAll(values, string.Empty);
		}

		public AndConstraint<TAssertions> NotContainAny(IEnumerable<string> values, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			ThrowIfValuesNullOrEmpty(values);
			IEnumerable<string> enumerable = values.Where((string v) => Contains(base.Subject, v, StringComparison.Ordinal));
			assertionChain.ForCondition(!enumerable.Any()).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} {0} to contain any of the strings: {1}{reason}.", base.Subject, enumerable);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainAny(params string[] values)
		{
			return NotContainAny(values, string.Empty);
		}

		public AndConstraint<TAssertions> NotContainEquivalentOf(string unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!string.IsNullOrEmpty(unexpected) && base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} to contain the equivalent of {0}{reason}, but found {1}.", unexpected, base.Subject);
			bool condition;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().ContainEquivalentOf(unexpected, "");
				condition = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} to contain the equivalent of {0}{reason} but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainEquivalentOf(string unexpected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			assertionChain.ForCondition(!string.IsNullOrEmpty(unexpected) && base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} to contain the equivalent of {0}{reason}, but found {1}.", unexpected, base.Subject);
			bool condition;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				base.Subject.Should().ContainEquivalentOf(unexpected, config, "");
				condition = assertionScope.Discard().Length != 0;
			}
			assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} to contain the equivalent of {0}{reason}, but found {1}.", unexpected, base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertionChain obj = assertionChain;
			string subject = base.Subject;
			obj.ForCondition(subject != null && subject.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} to be empty{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject == null || base.Subject.Length > 0).BecauseOf(because, becauseArgs).FailWith("Did not expect {context:string} to be empty{reason}.");
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveLength(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:string} with length {0}{reason}, but found <null>.", expected);
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.Length == expected).FailWith("Expected {context:string} with length {0}{reason}, but found string {1} with length {2}.", expected, base.Subject, base.Subject.Length);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeNullOrEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!string.IsNullOrEmpty(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to be <null> or empty{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNullOrEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(string.IsNullOrEmpty(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} to be <null> or empty{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeNullOrWhiteSpace([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(!string.IsNullOrWhiteSpace(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} not to be <null> or whitespace{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeNullOrWhiteSpace([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(string.IsNullOrWhiteSpace(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected {context:string} to be <null> or whitespace{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeUpperCased([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null && !base.Subject.Any(char.IsLower)).BecauseOf(because, becauseArgs).FailWith("Expected all alphabetic characters in {context:string} to be upper-case{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeUpperCased([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject == null || HasMixedOrNoCase(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected some characters in {context:string} to be lower-case{reason}.");
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeLowerCased([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null && !base.Subject.Any(char.IsUpper)).BecauseOf(because, becauseArgs).FailWith("Expected all alphabetic characters in {context:string} to be lower cased{reason}, but found {0}.", base.Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeLowerCased([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject == null || HasMixedOrNoCase(base.Subject)).BecauseOf(because, becauseArgs).FailWith("Expected some characters in {context:string} to be upper-case{reason}.");
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		private static bool HasMixedOrNoCase(string value)
		{
			bool flag = false;
			bool flag2 = false;
			foreach (char c in value)
			{
				flag |= char.IsUpper(c);
				flag2 |= char.IsLower(c);
				if (flag && flag2)
				{
					return true;
				}
			}
			if (!flag)
			{
				return !flag2;
			}
			return false;
		}

		internal AndConstraint<TAssertions> Be(string expected, Func<EquivalencyOptions<string>, EquivalencyOptions<string>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<string> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<string>());
			StringValidator stringValidator = new StringValidator(assertionChain, new StringEqualityStrategy(equivalencyOptions.GetStringComparerOrDefault(), "be"), because, becauseArgs);
			string subject = ApplyStringSettings(base.Subject, equivalencyOptions);
			expected = ApplyStringSettings(expected, equivalencyOptions);
			stringValidator.Validate(subject, expected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		private static bool Contains(string actual, string expected, StringComparison comparison)
		{
			return SystemExtensions.Contains(actual ?? string.Empty, expected ?? string.Empty, comparison);
		}

		private static void ThrowIfValuesNullOrEmpty(IEnumerable<string> values)
		{
			Guard.ThrowIfArgumentIsNull(values, "values", "Cannot assert string containment of values in null collection");
			if (!values.Any())
			{
				throw new ArgumentException("Cannot assert string containment of values in empty collection", "values");
			}
		}

		private static string ApplyStringSettings(string value, IEquivalencyOptions options)
		{
			if (options.IgnoreLeadingWhitespace)
			{
				value = value.TrimStart(Array.Empty<char>());
			}
			if (options.IgnoreTrailingWhitespace)
			{
				value = value.TrimEnd(Array.Empty<char>());
			}
			if (options.IgnoreNewlineStyle)
			{
				value = value.RemoveNewlineStyle();
			}
			return value;
		}
	}
}

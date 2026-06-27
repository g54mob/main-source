using System;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class StringEqualityEquivalencyStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			Type expectedType = comparands.GetExpectedType(context.Options);
			if ((object)expectedType == null || expectedType != typeof(string))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			if (!ValidateAgainstNulls(assertionChain, comparands, context.CurrentNode))
			{
				return EquivalencyResult.EquivalencyProven;
			}
			if (ValidateSubjectIsString(assertionChain, comparands, context.CurrentNode))
			{
				string actualValue = (string)comparands.Subject;
				string expected = (string)comparands.Expectation;
				assertionChain.ReuseOnce();
				actualValue.Should().Be(expected, CreateOptions(context.Options), context.Reason.FormattedMessage, context.Reason.Arguments);
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static Func<EquivalencyOptions<string>, EquivalencyOptions<string>> CreateOptions(IEquivalencyOptions existingOptions)
		{
			return delegate(EquivalencyOptions<string> o)
			{
				if (existingOptions is EquivalencyOptions<string> result)
				{
					return result;
				}
				if (existingOptions.IgnoreLeadingWhitespace)
				{
					o.IgnoringLeadingWhitespace();
				}
				if (existingOptions.IgnoreTrailingWhitespace)
				{
					o.IgnoringTrailingWhitespace();
				}
				if (existingOptions.IgnoreCase)
				{
					o.IgnoringCase();
				}
				if (existingOptions.IgnoreNewlineStyle)
				{
					o.IgnoringNewlineStyle();
				}
				return o;
			};
		}

		private static bool ValidateAgainstNulls(AssertionChain assertionChain, Comparands comparands, INode currentNode)
		{
			object expectation = comparands.Expectation;
			object subject = comparands.Subject;
			if (expectation == null != (subject == null))
			{
				assertionChain.FailWith("Expected {0} to be {1}{reason}, but found {2}.", currentNode.Subject.Description.AsNonFormattable(), expectation, subject);
				return false;
			}
			return true;
		}

		private static bool ValidateSubjectIsString(AssertionChain assertionChain, Comparands comparands, INode currentNode)
		{
			if (comparands.Subject is string)
			{
				return true;
			}
			assertionChain.FailWith("Expected {0} to be {1}, but found {2}.", currentNode.AsNonFormattable(), comparands.RuntimeType, comparands.Subject.GetType());
			return assertionChain.Succeeded;
		}
	}
}

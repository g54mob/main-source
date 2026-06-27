using System;
using System.Collections;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class DictionaryEquivalencyStep : EquivalencyStep<IDictionary>
	{
		protected override EquivalencyResult OnHandle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency nestedValidator)
		{
			IDictionary dictionary = comparands.Subject as IDictionary;
			IDictionary dictionary2 = comparands.Expectation as IDictionary;
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			if (PreconditionsAreMet(dictionary2, dictionary, assertionChain) && dictionary2 != null)
			{
				foreach (object key in dictionary2.Keys)
				{
					if (context.Options.IsRecursive)
					{
						context.Tracer.WriteLine((INode member) => FormattableString.Invariant($"Recursing into dictionary item {key} at {member.Expectation}"));
						nestedValidator.AssertEquivalencyOf(new Comparands(dictionary[key], dictionary2[key], typeof(object)), context.AsDictionaryItem<object, IDictionary>(key));
						continue;
					}
					context.Tracer.WriteLine((INode member) => FormattableString.Invariant($"Comparing dictionary item {key} at {member.Expectation} between subject and expectation"));
					assertionChain.WithCallerPostfix("[" + key.ToFormattedString() + "]").ReuseOnce();
					dictionary[key].Should().Be(dictionary2[key], context.Reason.FormattedMessage, context.Reason.Arguments);
				}
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static bool PreconditionsAreMet(IDictionary expectation, IDictionary subject, AssertionChain assertionChain)
		{
			if (AssertIsDictionary(subject, assertionChain) && AssertEitherIsNotNull(expectation, subject, assertionChain))
			{
				return AssertSameLength(expectation, subject, assertionChain);
			}
			return false;
		}

		private static bool AssertEitherIsNotNull(IDictionary expectation, IDictionary subject, AssertionChain assertionChain)
		{
			assertionChain.ForCondition((expectation == null && subject == null) || expectation != null).FailWith("Expected {context:subject} to be {0}{reason}, but found {1}.", null, subject);
			return assertionChain.Succeeded;
		}

		private static bool AssertIsDictionary(IDictionary subject, AssertionChain assertionChain)
		{
			assertionChain.ForCondition(subject != null).FailWith("Expected {context:subject} to be a dictionary, but it is not.");
			return assertionChain.Succeeded;
		}

		private static bool AssertSameLength(IDictionary expectation, IDictionary subject, AssertionChain assertionChain)
		{
			assertionChain.ForCondition(expectation == null || subject.Keys.Count == expectation.Keys.Count).FailWith("Expected {context:subject} to be a dictionary with {0} item(s), but it only contains {1} item(s).", expectation?.Keys.Count, subject?.Keys.Count);
			return assertionChain.Succeeded;
		}
	}
}

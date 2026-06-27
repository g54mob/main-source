using System;
using System.Collections;
using System.Linq;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class EnumerableEquivalencyStep : IEquivalencyStep
	{
		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (!IsCollection(comparands.GetExpectedType(context.Options)))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			if (AssertSubjectIsCollection(assertionChain, comparands.Subject))
			{
				new EnumerableEquivalencyValidator(assertionChain, valueChildNodes, context)
				{
					Recursive = (context.CurrentNode.IsRoot || context.Options.IsRecursive),
					OrderingRules = context.Options.OrderingRules
				}.Execute(ToArray(comparands.Subject), ToArray(comparands.Expectation));
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static bool AssertSubjectIsCollection(AssertionChain assertionChain, object subject)
		{
			assertionChain.ForCondition(subject != null).FailWith("Expected a collection, but {context:Subject} is <null>.");
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(IsCollection(subject.GetType())).FailWith("Expected a collection, but {context:Subject} is of a non-collection type.");
			}
			return assertionChain.Succeeded;
		}

		private static bool IsCollection(Type type)
		{
			if (!typeof(string).IsAssignableFrom(type))
			{
				return typeof(IEnumerable).IsAssignableFrom(type);
			}
			return false;
		}

		internal static object[] ToArray(object value)
		{
			if (value == null)
			{
				return null;
			}
			try
			{
				return ((IEnumerable)value).Cast<object>().ToArray();
			}
			catch (InvalidOperationException) when (IsIgnorableArrayLikeType(value))
			{
				return Array.Empty<object>();
			}
		}

		private static bool IsIgnorableArrayLikeType(object value)
		{
			Type type = value.GetType();
			if (!type.Name.Equals("ImmutableArray`1", StringComparison.Ordinal))
			{
				if (type.IsGenericType)
				{
					return type.GetGenericTypeDefinition() == typeof(ArraySegment<>);
				}
				return false;
			}
			return true;
		}
	}
}

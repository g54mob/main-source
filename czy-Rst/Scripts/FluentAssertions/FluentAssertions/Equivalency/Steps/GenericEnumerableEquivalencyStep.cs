using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class GenericEnumerableEquivalencyStep : IEquivalencyStep
	{
		private static readonly MethodInfo HandleMethod = new Action<EnumerableEquivalencyValidator, object[], IEnumerable<object>>(HandleImpl).GetMethodInfo().GetGenericMethodDefinition();

		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			Type expectedType = comparands.GetExpectedType(context.Options);
			if (comparands.Expectation == null || !IsGenericCollection(expectedType))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			Type[] interfaceTypes = GetIEnumerableInterfaces(expectedType);
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			assertionChain.ForCondition(interfaceTypes.Length == 1).FailWith(() => new FailReason("{context:Expectation} implements {0}, so cannot determine which one to use for asserting the equivalency of the collection. ", interfaceTypes.Select((Type type) => "IEnumerable<" + type.GetGenericArguments().Single()?.ToString() + ">")));
			if (AssertSubjectIsCollection(assertionChain, comparands.Subject))
			{
				EnumerableEquivalencyValidator enumerableEquivalencyValidator = new EnumerableEquivalencyValidator(assertionChain, valueChildNodes, context)
				{
					Recursive = (context.CurrentNode.IsRoot || context.Options.IsRecursive),
					OrderingRules = context.Options.OrderingRules
				};
				Type typeOfEnumeration = GetTypeOfEnumeration(expectedType);
				object[] array = EnumerableEquivalencyStep.ToArray(comparands.Subject);
				try
				{
					HandleMethod.MakeGenericMethod(typeOfEnumeration).Invoke(null, new object[3] { enumerableEquivalencyValidator, array, comparands.Expectation });
				}
				catch (TargetInvocationException exception)
				{
					exception.Unwrap().Throw();
				}
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static void HandleImpl<T>(EnumerableEquivalencyValidator validator, object[] subject, IEnumerable<T> expectation)
		{
			validator.Execute(subject, ToArray(expectation));
		}

		private static bool AssertSubjectIsCollection(AssertionChain assertionChain, object subject)
		{
			assertionChain.ForCondition(subject != null).FailWith("Expected {context:subject} not to be {0}.", new object[1]);
			if (assertionChain.Succeeded)
			{
				assertionChain.ForCondition(IsCollection(subject.GetType())).FailWith("Expected {context:subject} to be a collection, but it was a {0}", subject.GetType());
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

		private static bool IsGenericCollection(Type type)
		{
			Type[] iEnumerableInterfaces = GetIEnumerableInterfaces(type);
			if (!typeof(string).IsAssignableFrom(type))
			{
				return iEnumerableInterfaces.Length != 0;
			}
			return false;
		}

		private static Type[] GetIEnumerableInterfaces(Type type)
		{
			if (Type.GetTypeCode(type) != TypeCode.Object)
			{
				return Array.Empty<Type>();
			}
			Type typeFromHandle = typeof(IEnumerable<>);
			return type.GetClosedGenericInterfaces(typeFromHandle);
		}

		private static Type GetTypeOfEnumeration(Type enumerableType)
		{
			return GetIEnumerableInterfaces(enumerableType).Single().GetGenericArguments().Single();
		}

		private static T[] ToArray<T>(IEnumerable<T> value)
		{
			try
			{
				return value?.ToArray();
			}
			catch (InvalidOperationException) when (value.GetType().Name.Equals("ImmutableArray`1", StringComparison.Ordinal))
			{
				return Array.Empty<T>();
			}
		}
	}
}

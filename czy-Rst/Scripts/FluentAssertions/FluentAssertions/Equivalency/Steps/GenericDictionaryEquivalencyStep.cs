using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions.Execution;

namespace FluentAssertions.Equivalency.Steps
{
	public class GenericDictionaryEquivalencyStep : IEquivalencyStep
	{
		private sealed class KeyDifference<TSubjectKey, TExpectedKey>
		{
			public List<TExpectedKey> MissingKeys { get; }

			public List<TSubjectKey> AdditionalKeys { get; }

			public KeyDifference(List<TExpectedKey> missingKeys, List<TSubjectKey> additionalKeys)
			{
				MissingKeys = missingKeys;
				AdditionalKeys = additionalKeys;
			}
		}

		private static readonly MethodInfo AssertDictionaryEquivalenceMethod = new Action<AssertionChain, EquivalencyValidationContext, IValidateChildNodeEquivalency, IEquivalencyOptions, IDictionary<object, object>, IDictionary<object, object>>(AssertDictionaryEquivalence).GetMethodInfo().GetGenericMethodDefinition();

		public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IValidateChildNodeEquivalency valueChildNodes)
		{
			if (comparands.Expectation == null)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			DictionaryInterfaceInfo dictionaryInterfaceInfo = DictionaryInterfaceInfo.FindFrom(comparands.GetExpectedType(context.Options), "expectation");
			if (dictionaryInterfaceInfo == null)
			{
				return EquivalencyResult.ContinueWithNext;
			}
			if (IsNonGenericDictionary(comparands.Subject))
			{
				return EquivalencyResult.ContinueWithNext;
			}
			AssertionChain assertionChain = AssertionChain.GetOrCreate().For(context);
			if (IsNotNull(assertionChain, comparands.Subject))
			{
				DictionaryInterfaceInfo dictionaryInterfaceInfo2 = EnsureSubjectIsOfTheExpectedDictionaryType(assertionChain, comparands, dictionaryInterfaceInfo);
				if (dictionaryInterfaceInfo2 != null)
				{
					AssertDictionaryEquivalence(comparands, assertionChain, context, valueChildNodes, dictionaryInterfaceInfo2, dictionaryInterfaceInfo);
				}
			}
			return EquivalencyResult.EquivalencyProven;
		}

		private static bool IsNonGenericDictionary(object subject)
		{
			if (!(subject is IDictionary))
			{
				return false;
			}
			return !subject.GetType().GetInterfaces().Any((Type @interface) => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == typeof(IDictionary<, >));
		}

		private static bool IsNotNull(AssertionChain assertionChain, object subject)
		{
			assertionChain.ForCondition(subject != null).FailWith("Expected {context:Subject} not to be {0}{reason}.", new object[1]);
			return assertionChain.Succeeded;
		}

		private static DictionaryInterfaceInfo EnsureSubjectIsOfTheExpectedDictionaryType(AssertionChain assertionChain, Comparands comparands, DictionaryInterfaceInfo expectedDictionary)
		{
			DictionaryInterfaceInfo dictionaryInterfaceInfo = DictionaryInterfaceInfo.FindFromWithKey(comparands.Subject.GetType(), "subject", expectedDictionary.Key);
			if (dictionaryInterfaceInfo == null)
			{
				object obj = expectedDictionary.ConvertFrom(comparands.Subject);
				if (obj != null)
				{
					comparands.Subject = obj;
					dictionaryInterfaceInfo = DictionaryInterfaceInfo.FindFrom(comparands.Subject.GetType(), "subject");
				}
			}
			if (dictionaryInterfaceInfo == null)
			{
				assertionChain.FailWith("Expected {context:subject} to be a dictionary or collection of key-value pairs that is keyed to " + $"type {expectedDictionary.Key}.");
			}
			return dictionaryInterfaceInfo;
		}

		private static void FailWithLengthDifference<TSubjectKey, TSubjectValue, TExpectedKey, TExpectedValue>(IDictionary<TSubjectKey, TSubjectValue> subject, IDictionary<TExpectedKey, TExpectedValue> expectation, AssertionChain assertionChain) where TExpectedKey : TSubjectKey
		{
			KeyDifference<TSubjectKey, TExpectedKey> keyDifference = CalculateKeyDifference(subject, expectation);
			bool hasMissingKeys = keyDifference.MissingKeys.Count > 0;
			bool hasAdditionalKeys = keyDifference.AdditionalKeys.Count > 0;
			assertionChain.WithExpectation("Expected {context:subject} to be a dictionary with {0} item(s){reason}, ", expectation.Count, delegate(AssertionChain chain)
			{
				chain.ForCondition(!hasMissingKeys || hasAdditionalKeys).FailWith("but it misses key(s) {0}", keyDifference.MissingKeys).Then.ForCondition(hasMissingKeys || !hasAdditionalKeys).FailWith("but has additional key(s) {0}", keyDifference.AdditionalKeys).Then.ForCondition(!hasMissingKeys || !hasAdditionalKeys).FailWith("but it misses key(s) {0} and has additional key(s) {1}", keyDifference.MissingKeys, keyDifference.AdditionalKeys);
			});
		}

		private static KeyDifference<TSubjectKey, TExpectedKey> CalculateKeyDifference<TSubjectKey, TSubjectValue, TExpectedKey, TExpectedValue>(IDictionary<TSubjectKey, TSubjectValue> subject, IDictionary<TExpectedKey, TExpectedValue> expectation) where TExpectedKey : TSubjectKey
		{
			List<TExpectedKey> list = new List<TExpectedKey>();
			HashSet<TSubjectKey> hashSet = new HashSet<TSubjectKey>();
			foreach (TExpectedKey key in expectation.Keys)
			{
				if (subject.ContainsKey((TSubjectKey)(object)key))
				{
					hashSet.Add((TSubjectKey)(object)key);
				}
				else
				{
					list.Add(key);
				}
			}
			List<TSubjectKey> list2 = new List<TSubjectKey>();
			foreach (TSubjectKey key2 in subject.Keys)
			{
				if (!hashSet.Contains(key2))
				{
					list2.Add(key2);
				}
			}
			return new KeyDifference<TSubjectKey, TExpectedKey>(list, list2);
		}

		private static void AssertDictionaryEquivalence(Comparands comparands, AssertionChain assertionChain, IEquivalencyValidationContext context, IValidateChildNodeEquivalency parent, DictionaryInterfaceInfo actualDictionary, DictionaryInterfaceInfo expectedDictionary)
		{
			AssertDictionaryEquivalenceMethod.MakeGenericMethod(actualDictionary.Key, actualDictionary.Value, expectedDictionary.Key, expectedDictionary.Value).Invoke(null, new object[6] { assertionChain, context, parent, context.Options, comparands.Subject, comparands.Expectation });
		}

		private static void AssertDictionaryEquivalence<TSubjectKey, TSubjectValue, TExpectedKey, TExpectedValue>(AssertionChain assertionChain, EquivalencyValidationContext context, IValidateChildNodeEquivalency parent, IEquivalencyOptions options, IDictionary<TSubjectKey, TSubjectValue> subject, IDictionary<TExpectedKey, TExpectedValue> expectation) where TExpectedKey : TSubjectKey
		{
			if (subject.Count != expectation.Count)
			{
				FailWithLengthDifference(subject, expectation, assertionChain);
				return;
			}
			foreach (TExpectedKey key in expectation.Keys)
			{
				if (subject.TryGetValue((TSubjectKey)(object)key, out var value))
				{
					if (options.IsRecursive)
					{
						using (new AssertionScope())
						{
							Comparands comparands = new Comparands(subject[(TSubjectKey)(object)key], expectation[key], typeof(TExpectedValue));
							parent.AssertEquivalencyOf(comparands, context.AsDictionaryItem<TExpectedKey, TExpectedValue>(key));
						}
					}
					else
					{
						assertionChain.ReuseOnce();
						AssertionExtensions.Should(value).Be(expectation[key], context.Reason.FormattedMessage, context.Reason.Arguments);
					}
				}
				else
				{
					assertionChain.BecauseOf(context.Reason).FailWith("Expected {context:subject} to contain key {0}{reason}.", key);
				}
			}
		}
	}
}

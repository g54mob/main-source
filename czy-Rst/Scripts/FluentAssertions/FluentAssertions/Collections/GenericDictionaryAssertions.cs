using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;

namespace FluentAssertions.Collections
{
	[DebuggerNonUserCode]
	public class GenericDictionaryAssertions<TCollection, TKey, TValue> : GenericDictionaryAssertions<TCollection, TKey, TValue, GenericDictionaryAssertions<TCollection, TKey, TValue>> where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
	{
		public GenericDictionaryAssertions(TCollection keyValuePairs, AssertionChain assertionChain)
			: base(keyValuePairs, assertionChain)
		{
		}
	}
	public class GenericDictionaryAssertions<TCollection, TKey, TValue, TAssertions> : GenericCollectionAssertions<TCollection, KeyValuePair<TKey, TValue>, TAssertions> where TCollection : IEnumerable<KeyValuePair<TKey, TValue>> where TAssertions : GenericDictionaryAssertions<TCollection, TKey, TValue, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "dictionary";

		public GenericDictionaryAssertions(TCollection keyValuePairs, AssertionChain assertionChain)
			: base(keyValuePairs, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TAssertions> Equal<T>(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where T : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare dictionary with <null>.");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to be equal to {0}{reason}, but found {1}.", expected, base.Subject);
			if (assertionChain.Succeeded)
			{
				IEnumerable<TKey> keys = GetKeys(base.Subject);
				IEnumerable<TKey> keys2 = GetKeys(expected);
				IEnumerable<TKey> enumerable = keys2.Except(keys);
				IEnumerable<TKey> enumerable2 = keys.Except(keys2);
				if (enumerable.Any())
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to be equal to {0}{reason}, but could not find keys {1}.", expected, enumerable);
				}
				if (enumerable2.Any())
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to be equal to {0}{reason}, but found additional keys {1}.", expected, enumerable2);
				}
				Func<TValue, TValue, bool> comparer = ObjectExtensions.GetComparer<TValue>();
				foreach (TKey item in keys2)
				{
					assertionChain.ForCondition(comparer(GetValue(base.Subject, item), GetValue(expected, item))).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to be equal to {0}{reason}, but {1} differs at key {2}.", expected, base.Subject, item);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotEqual<T>(T unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where T : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare dictionary with <null>.");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected dictionaries not to be equal{reason}, but found {0}.", base.Subject);
			if (assertionChain.Succeeded)
			{
				if ((object)base.Subject == (object)unexpected)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected dictionaries not to be equal{reason}, but they both reference the same object.");
				}
				IEnumerable<TKey> keys = GetKeys(base.Subject);
				IEnumerable<TKey> keys2 = GetKeys(unexpected);
				IEnumerable<TKey> source = keys2.Except(keys);
				IEnumerable<TKey> source2 = keys.Except(keys2);
				Func<TValue, TValue, bool> areSameOrEqual = ObjectExtensions.GetComparer<TValue>();
				if (!source.Any() && !source2.Any() && !keys.Any((TKey key) => !areSameOrEqual(GetValue(base.Subject, key), GetValue(unexpected, key))))
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Did not expect dictionaries {0} and {1} to be equal{reason}.", unexpected, base.Subject);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(TExpectation expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeEquivalentTo(expectation, (EquivalencyOptions<TExpectation> options) => options, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(TExpectation expectation, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<TExpectation> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<TExpectation>());
			EquivalencyValidationContext context = new EquivalencyValidationContext(Node.From<TExpectation>(() => base.CurrentAssertionChain.CallerIdentifier), equivalencyOptions)
			{
				Reason = new Reason(because, becauseArgs),
				TraceWriter = equivalencyOptions.TraceWriter
			};
			Comparands comparands = new Comparands
			{
				Subject = base.Subject,
				Expectation = expectation,
				CompileTimeType = typeof(TExpectation)
			};
			new EquivalencyValidator().AssertEquality(comparands, context);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public WhoseValueConstraint<TCollection, TKey, TValue, TAssertions> ContainKey(TKey expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AndConstraint<TAssertions> andConstraint = ContainKeys(new _003C_003Ez__ReadOnlySingleElementList<TKey>(expected), because, becauseArgs);
			TryGetValue(base.Subject, expected, out var value);
			return new WhoseValueConstraint<TCollection, TKey, TValue, TAssertions>(andConstraint.And, value);
		}

		public AndConstraint<TAssertions> ContainKeys(params TKey[] expected)
		{
			return ContainKeys(expected, string.Empty);
		}

		public AndConstraint<TAssertions> ContainKeys(IEnumerable<TKey> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot verify key containment against a <null> collection of keys");
			ICollection<TKey> collection = expected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "expected", "Cannot verify key containment against an empty sequence");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain keys {0}{reason}, but found <null>.", expected);
			if (assertionChain.Succeeded)
			{
				IEnumerable<TKey> enumerable = collection.Where((TKey key) => !ContainsKey(base.Subject, key));
				if (enumerable.Any())
				{
					if (collection.Count > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to contain keys {1}{reason}, but could not find {2}.", base.Subject, expected, enumerable);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to contain key {1}{reason}.", base.Subject, expected.First());
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainKey(TKey unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} not to contain key {0}{reason}, but found <null>.", unexpected);
			if (assertionChain.Succeeded && ContainsKey(base.Subject, unexpected))
			{
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} not to contain key {1}{reason}, but found it anyhow.", base.Subject, unexpected);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainKeys(params TKey[] unexpected)
		{
			return NotContainKeys(unexpected, string.Empty);
		}

		public AndConstraint<TAssertions> NotContainKeys(IEnumerable<TKey> unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot verify key containment against a <null> collection of keys");
			ICollection<TKey> collection = unexpected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "unexpected", "Cannot verify key containment against an empty sequence");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to not contain keys {0}{reason}, but found <null>.", collection);
			if (assertionChain.Succeeded)
			{
				IEnumerable<TKey> enumerable = collection.Where((TKey key) => ContainsKey(base.Subject, key));
				if (enumerable.Any())
				{
					if (collection.Count > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to not contain keys {1}{reason}, but found {2}.", base.Subject, collection, enumerable);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to not contain key {1}{reason}.", base.Subject, collection.First());
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndWhichConstraint<TAssertions, TValue> ContainValue(TValue expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AndWhichConstraint<TAssertions, IEnumerable<TValue>> andWhichConstraint = ContainValues(new _003C_003Ez__ReadOnlySingleElementList<TValue>(expected), because, becauseArgs);
			return new AndWhichConstraint<TAssertions, TValue>(andWhichConstraint.And, andWhichConstraint.Subject);
		}

		public AndWhichConstraint<TAssertions, IEnumerable<TValue>> ContainValues(params TValue[] expected)
		{
			return ContainValues(expected, string.Empty);
		}

		public AndWhichConstraint<TAssertions, IEnumerable<TValue>> ContainValues(IEnumerable<TValue> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot verify value containment against a <null> collection of values");
			ICollection<TValue> collection = expected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "expected", "Cannot verify value containment against an empty sequence");
			List<TValue> list = new List<TValue>(collection);
			Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain values {0}{reason}, but found <null>.", expected);
			if (assertionChain.Succeeded)
			{
				foreach (KeyValuePair<TKey, TValue> item in base.Subject)
				{
					if (list.Contains(item.Value))
					{
						dictionary.Add(item.Key, item.Value);
						list.Remove(item.Value);
					}
				}
				if (list.Count > 0)
				{
					if (collection.Count == 1)
					{
						assertionChain.FailWith("Expected {context:dictionary} {0} to contain value {1}{reason}.", base.Subject, collection.Single());
					}
					else
					{
						assertionChain.FailWith("Expected {context:dictionary} {0} to contain values {1}{reason}, but could not find {2}.", base.Subject, collection, (list.Count == 1) ? ((object)list.Single()) : list);
					}
				}
			}
			string pathPostfix = ((dictionary.Count > 0) ? ("[" + string.Join(" and ", dictionary.Keys) + "]") : "");
			return new AndWhichConstraint<TAssertions, IEnumerable<TValue>>((TAssertions)this, dictionary.Values, assertionChain, pathPostfix);
		}

		public AndConstraint<TAssertions> NotContainValue(TValue unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} not to contain value {0}{reason}, but found <null>.", unexpected);
			if (assertionChain.Succeeded && GetValues(base.Subject).Contains(unexpected))
			{
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} not to contain value {1}{reason}, but found it anyhow.", base.Subject, unexpected);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainValues(params TValue[] unexpected)
		{
			return NotContainValues(unexpected, string.Empty);
		}

		public AndConstraint<TAssertions> NotContainValues(IEnumerable<TValue> unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot verify value containment against a <null> collection of values");
			ICollection<TValue> collection = unexpected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "unexpected", "Cannot verify value containment with an empty sequence");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to not contain values {0}{reason}, but found <null>.", unexpected);
			if (assertionChain.Succeeded)
			{
				IEnumerable<TValue> enumerable = collection.Intersect(GetValues(base.Subject));
				if (enumerable.Any())
				{
					if (collection.Count > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to not contain value {1}{reason}, but found {2}.", base.Subject, unexpected, enumerable);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to not contain value {1}{reason}.", base.Subject, unexpected.First());
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Contain(params KeyValuePair<TKey, TValue>[] expected)
		{
			return Contain(expected, string.Empty);
		}

		public new AndConstraint<TAssertions> Contain(IEnumerable<KeyValuePair<TKey, TValue>> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot compare dictionary with <null>.");
			ICollection<KeyValuePair<TKey, TValue>> collection = expected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "expected", "Cannot verify key containment against an empty collection of key/value pairs");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain key/value pairs {0}{reason}, but dictionary is <null>.", expected);
			if (assertionChain.Succeeded)
			{
				TKey[] array = collection.Select((KeyValuePair<TKey, TValue> keyValuePair2) => keyValuePair2.Key).ToArray();
				IEnumerable<TKey> enumerable = array.Where((TKey key) => !ContainsKey(base.Subject, key));
				if (enumerable.Any())
				{
					if (collection.Count > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to contain key(s) {1}{reason}, but could not find keys {2}.", base.Subject, array, enumerable);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} {0} to contain key {1}{reason}.", base.Subject, array[0]);
					}
				}
				Func<TValue, TValue, bool> areSameOrEqual = ObjectExtensions.GetComparer<TValue>();
				KeyValuePair<TKey, TValue>[] array2 = collection.Where((KeyValuePair<TKey, TValue> keyValuePair2) => !areSameOrEqual(GetValue(base.Subject, keyValuePair2.Key), keyValuePair2.Value)).ToArray();
				if (array2.Length != 0)
				{
					if (array2.Length > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain {0}{reason}, but {context:dictionary} differs at keys {1}.", collection, array2.Select((KeyValuePair<TKey, TValue> keyValuePair2) => keyValuePair2.Key));
					}
					else
					{
						KeyValuePair<TKey, TValue> keyValuePair = array2[0];
						TValue value = GetValue(base.Subject, keyValuePair.Key);
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain value {0} at key {1}{reason}, but found {2}.", keyValuePair.Value, keyValuePair.Key, value);
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public new AndConstraint<TAssertions> Contain(KeyValuePair<TKey, TValue> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return Contain(expected.Key, expected.Value, because, becauseArgs);
		}

		public AndConstraint<TAssertions> Contain(TKey key, TValue value, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain value {0} at key {1}{reason}, but dictionary is <null>.", value, key);
			if (assertionChain.Succeeded)
			{
				if (TryGetValue(base.Subject, key, out var value2))
				{
					Func<TValue, TValue, bool> comparer = ObjectExtensions.GetComparer<TValue>();
					assertionChain.ForCondition(comparer(value2, value)).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain value {0} at key {1}{reason}, but found {2}.", value, key, value2);
				}
				else
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to contain value {0} at key {1}{reason}, but the key was not found.", value, key);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContain(params KeyValuePair<TKey, TValue>[] items)
		{
			return NotContain(items, string.Empty);
		}

		public new AndConstraint<TAssertions> NotContain(IEnumerable<KeyValuePair<TKey, TValue>> items, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(items, "items", "Cannot compare dictionary with <null>.");
			ICollection<KeyValuePair<TKey, TValue>> collection = items.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "items", "Cannot verify key containment against an empty collection of key/value pairs");
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to not contain key/value pairs {0}{reason}, but dictionary is <null>.", items);
			if (assertionChain.Succeeded)
			{
				KeyValuePair<TKey, TValue>[] array = collection.Where((KeyValuePair<TKey, TValue> keyValuePair2) => ContainsKey(base.Subject, keyValuePair2.Key)).ToArray();
				if (array.Length != 0)
				{
					Func<TValue, TValue, bool> areSameOrEqual = ObjectExtensions.GetComparer<TValue>();
					KeyValuePair<TKey, TValue>[] array2 = array.Where((KeyValuePair<TKey, TValue> keyValuePair2) => areSameOrEqual(GetValue(base.Subject, keyValuePair2.Key), keyValuePair2.Value)).ToArray();
					if (array2.Length != 0)
					{
						if (array2.Length > 1)
						{
							assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to not contain key/value pairs {0}{reason}, but found them anyhow.", collection);
						}
						else
						{
							KeyValuePair<TKey, TValue> keyValuePair = array2[0];
							assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} to not contain value {0} at key {1}{reason}, but found it anyhow.", keyValuePair.Value, keyValuePair.Key);
						}
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public new AndConstraint<TAssertions> NotContain(KeyValuePair<TKey, TValue> item, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotContain(item.Key, item.Value, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotContain(TKey key, TValue value, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.ForCondition(base.Subject != null).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} not to contain value {0} at key {1}{reason}, but dictionary is <null>.", value, key);
			if (assertionChain.Succeeded && TryGetValue(base.Subject, key, out var value2))
			{
				assertionChain.ForCondition(!ObjectExtensions.GetComparer<TValue>()(value2, value)).BecauseOf(because, becauseArgs).FailWith("Expected {context:dictionary} not to contain value {0} at key {1}{reason}, but found it anyhow.", value, key);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		private static IEnumerable<TKey> GetKeys(TCollection collection)
		{
			return collection.GetKeys<TCollection, TKey, TValue>();
		}

		private static IEnumerable<TKey> GetKeys<T>(T collection) where T : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			return collection.GetKeys<T, TKey, TValue>();
		}

		private static IEnumerable<TValue> GetValues(TCollection collection)
		{
			return collection.GetValues<TCollection, TKey, TValue>();
		}

		private static bool ContainsKey(TCollection collection, TKey key)
		{
			return collection.ContainsKey<TCollection, TKey, TValue>(key);
		}

		private static bool TryGetValue(TCollection collection, TKey key, out TValue value)
		{
			return collection.TryGetValue<TCollection, TKey, TValue>(key, out value);
		}

		private static TValue GetValue(TCollection collection, TKey key)
		{
			return collection.GetValue<TCollection, TKey, TValue>(key);
		}

		private static TValue GetValue<T>(T collection, TKey key) where T : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			return collection.GetValue<T, TKey, TValue>(key);
		}
	}
}

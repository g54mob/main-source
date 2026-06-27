using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Collections.MaximumMatching;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Execution;
using FluentAssertions.Formatting;
using FluentAssertions.Primitives;

namespace FluentAssertions.Collections
{
	[DebuggerNonUserCode]
	public class GenericCollectionAssertions<T> : GenericCollectionAssertions<IEnumerable<T>, T, GenericCollectionAssertions<T>>
	{
		public GenericCollectionAssertions(IEnumerable<T> actualValue, AssertionChain assertionChain)
			: base(actualValue, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class GenericCollectionAssertions<TCollection, T> : GenericCollectionAssertions<TCollection, T, GenericCollectionAssertions<TCollection, T>> where TCollection : IEnumerable<T>
	{
		public GenericCollectionAssertions(TCollection actualValue, AssertionChain assertionChain)
			: base(actualValue, assertionChain)
		{
		}
	}
	[DebuggerNonUserCode]
	public class GenericCollectionAssertions<TCollection, T, TAssertions> : ReferenceTypeAssertions<TCollection, TAssertions> where TCollection : IEnumerable<T> where TAssertions : GenericCollectionAssertions<TCollection, T, TAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "collection";

		public GenericCollectionAssertions(TCollection actualValue, AssertionChain assertionChain)
			: base(actualValue, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndWhichConstraint<TAssertions, IEnumerable<TExpectation>> AllBeAssignableTo<TExpectation>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected type to be {0}{reason}, but found {context:the collection} is <null>.", typeof(TExpectation).FullName);
			IEnumerable<TExpectation> subject = Array.Empty<TExpectation>();
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type to be {0}{reason}, ", typeof(TExpectation).FullName, delegate(AssertionChain chain)
				{
					chain.ForCondition(base.Subject.All((T x) => x != null)).FailWith("but found a null element.").Then.ForCondition(base.Subject.All((T x) => typeof(TExpectation).IsAssignableFrom(GetType(x)))).FailWith("but found {0}.", () => "[" + string.Join(", ", base.Subject.Select((T x) => GetType(x).FullName)) + "]");
				});
				subject = base.Subject.OfType<TExpectation>();
			}
			return new AndWhichConstraint<TAssertions, IEnumerable<TExpectation>>((TAssertions)this, subject);
		}

		public AndConstraint<TAssertions> AllBeAssignableTo(Type expectedType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedType, "expectedType");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type to be {0}{reason}, ", expectedType.FullName, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found {context:collection} is <null>.")
					.Then.ForCondition((TCollection subject) => subject.All((T x) => x != null)).FailWith("but found a null element.").Then.ForCondition((TCollection subject) => subject.All((T x) => expectedType.IsAssignableFrom(GetType(x)))).FailWith("but found {0}.", (TCollection subject) => "[" + string.Join(", ", subject.Select((T x) => GetType(x).FullName)) + "]");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> AllBeEquivalentTo<TExpectation>(TExpectation expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return AllBeEquivalentTo(expectation, (EquivalencyOptions<TExpectation> options) => options, because, becauseArgs);
		}

		public AndConstraint<TAssertions> AllBeEquivalentTo<TExpectation>(TExpectation expectation, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			TExpectation[] expectation2 = RepeatAsManyAs(expectation, base.Subject).ToArray();
			Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config2 = (EquivalencyOptions<TExpectation> x) => config(x).WithStrictOrderingFor((IObjectInfo s) => string.IsNullOrEmpty(s.Path));
			return BeEquivalentTo(expectation2, config2, because, becauseArgs);
		}

		public AndWhichConstraint<TAssertions, IEnumerable<TExpectation>> AllBeOfType<TExpectation>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected type to be {0}{reason}, but found {context:collection} is <null>.", typeof(TExpectation).FullName);
			IEnumerable<TExpectation> subject = Array.Empty<TExpectation>();
			if (assertionChain.Succeeded)
			{
				assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type to be {0}{reason}, ", typeof(TExpectation).FullName, delegate(AssertionChain chain)
				{
					chain.ForCondition(base.Subject.All((T x) => x != null)).FailWith("but found a null element.").Then.ForCondition(base.Subject.All((T x) => typeof(TExpectation) == GetType(x))).FailWith("but found {0}.", () => "[" + string.Join(", ", base.Subject.Select((T x) => GetType(x).FullName)) + "]");
				});
				subject = base.Subject.OfType<TExpectation>();
			}
			return new AndWhichConstraint<TAssertions, IEnumerable<TExpectation>>((TAssertions)this, subject);
		}

		public AndConstraint<TAssertions> AllBeOfType(Type expectedType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedType, "expectedType");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type to be {0}{reason}, ", expectedType.FullName, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found {context:collection} is <null>.")
					.Then.ForCondition((TCollection subject) => subject.All((T x) => x != null)).FailWith("but found a null element.").Then.ForCondition((TCollection subject) => subject.All((T x) => expectedType == GetType(x))).FailWith("but found {0}.", (TCollection subject) => "[" + string.Join(", ", subject.Select((T x) => GetType(x).FullName)) + "]");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			TCollection subject = base.Subject;
			T[] singleItemArray = ((subject != null) ? subject.Take(1).ToArray() : null);
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to be empty{reason}, ", delegate(AssertionChain chain)
			{
				chain.Given(() => singleItemArray).ForCondition((T[] array) => array != null).FailWith("but found <null>.")
					.Then.ForCondition((T[] array) => array.Length == 0).FailWith("but found at least one item {0}.", singleItemArray);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(IEnumerable<TExpectation> expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeEquivalentTo(expectation, (EquivalencyOptions<TExpectation> config) => config, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeEquivalentTo<TExpectation>(IEnumerable<TExpectation> expectation, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			EquivalencyOptions<IEnumerable<TExpectation>> equivalencyOptions = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<TExpectation>()).AsCollection();
			EquivalencyValidationContext context = new EquivalencyValidationContext(Node.From<IEnumerable<TExpectation>>(() => CallerIdentifier.DetermineCallerIdentity()), equivalencyOptions)
			{
				Reason = new Reason(because, becauseArgs),
				TraceWriter = equivalencyOptions.TraceWriter
			};
			Comparands comparands = new Comparands
			{
				Subject = base.Subject,
				Expectation = expectation,
				CompileTimeType = typeof(IEnumerable<TExpectation>)
			};
			new EquivalencyValidator().AssertEquality(comparands, context);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeInAscendingOrder(propertyExpression, GetComparer<TSelector>(), because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInAscendingOrder(IComparer<T> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return BeInOrder(comparer, SortOrder.Ascending, because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return BeOrderedBy(propertyExpression, comparer, SortOrder.Ascending, because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInAscendingOrder([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeInAscendingOrder(GetComparer<T>(), because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInAscendingOrder(Func<T, T, int> comparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeInOrder(Comparer<T>.Create((T x, T y) => comparison(x, y)), SortOrder.Ascending, because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeInDescendingOrder(propertyExpression, GetComparer<TSelector>(), because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInDescendingOrder(IComparer<T> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return BeInOrder(comparer, SortOrder.Descending, because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return BeOrderedBy(propertyExpression, comparer, SortOrder.Descending, because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInDescendingOrder([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeInDescendingOrder(GetComparer<T>(), because, becauseArgs);
		}

		public AndConstraint<SubsequentOrderingAssertions<T>> BeInDescendingOrder(Func<T, T, int> comparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeInOrder(Comparer<T>.Create((T x, T y) => comparison(x, y)), SortOrder.Descending, because, becauseArgs);
		}

		public AndConstraint<TAssertions> BeNullOrEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			TCollection subject = base.Subject;
			T[] array = ((subject != null) ? subject.Take(1).ToArray() : null);
			bool condition = array == null || array.Length == 0;
			assertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to be null or empty{reason}, but found at least one item {0}.", array);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeSubsetOf(IEnumerable<T> expectedSuperset, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedSuperset, "expectedSuperset", "Cannot verify a subset against a <null> collection.");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to be a subset of {0}{reason}, ", expectedSuperset, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found <null>.")
					.Then.Given((TCollection subject) => subject.Except(expectedSuperset)).ForCondition((IEnumerable<T> excessItems) => !excessItems.Any()).FailWith("but items {0} are not part of the superset.", (IEnumerable<T> excessItems) => excessItems);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndWhichConstraint<TAssertions, T> Contain(T expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain {0}{reason}, but found <null>.", expected);
			IEnumerable<T> subjects = Array.Empty<T>();
			if (assertionChain.Succeeded)
			{
				ICollection<T> collection = base.Subject.ConvertOrCastToCollection();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(collection.Contains(expected)).FailWith("Expected {context:collection} {0} to contain {1}{reason}.", collection, expected);
				subjects = collection.Where((T item) => EqualityComparer<T>.Default.Equals(item, expected));
			}
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, subjects, assertionChain);
		}

		public AndWhichConstraint<TAssertions, T> Contain(Expression<Func<T, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain {0}{reason}, but found <null>.", predicate.Body);
			IEnumerable<T> subjects = Array.Empty<T>();
			int? num = null;
			if (assertionChain.Succeeded)
			{
				Func<T, bool> func = predicate.Compile();
				foreach (var (arg, value) in base.Subject.Select((T item, int index) => (item: item, index: index)))
				{
					if (func(arg))
					{
						num = value;
						break;
					}
				}
				assertionChain.ForCondition(num.HasValue).BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to have an item matching {1}{reason}.", base.Subject, predicate.Body);
				subjects = base.Subject.Where(func);
			}
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, subjects, assertionChain, $"[{num}]");
		}

		public AndConstraint<TAssertions> Contain(IEnumerable<T> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot verify containment against a <null> collection");
			ICollection<T> collection = expected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "expected", "Cannot verify containment against an empty collection");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain {0}{reason}, but found <null>.", collection);
			if (assertionChain.Succeeded)
			{
				IEnumerable<T> enumerable = collection.Except(base.Subject);
				if (enumerable.Any())
				{
					if (collection.Count > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to contain {1}{reason}, but could not find {2}.", base.Subject, collection, enumerable);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to contain {1}{reason}.", base.Subject, collection.Single());
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndWhichConstraint<TAssertions, T> ContainEquivalentOf<TExpectation>(TExpectation expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return ContainEquivalentOf(expectation, (EquivalencyOptions<TExpectation> config) => config, because, becauseArgs);
		}

		public AndWhichConstraint<TAssertions, T> ContainEquivalentOf<TExpectation>(TExpectation expectation, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain equivalent of {0}{reason}, but found <null>.", expectation);
			if (assertionChain.Succeeded)
			{
				EquivalencyOptions<TExpectation> options = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<TExpectation>());
				using AssertionScope assertionScope = new AssertionScope();
				assertionChain.AddReportable("configuration", () => options.ToString());
				foreach (var item3 in base.Subject.Select((T item3, int index) => (item: item3, index: index)))
				{
					T item = item3.item;
					int item2 = item3.index;
					EquivalencyValidationContext context = new EquivalencyValidationContext(Node.From<TExpectation>(() => base.CurrentAssertionChain.CallerIdentifier), options)
					{
						Reason = new Reason(because, becauseArgs),
						TraceWriter = options.TraceWriter
					};
					Comparands comparands = new Comparands
					{
						Subject = item,
						Expectation = expectation,
						CompileTimeType = typeof(TExpectation)
					};
					new EquivalencyValidator().AssertEquality(comparands, context);
					if (assertionScope.Discard().Length == 0)
					{
						return new AndWhichConstraint<TAssertions, T>((TAssertions)this, item, assertionChain, $"[{item2}]");
					}
				}
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to contain equivalent of {1}{reason}.", base.Subject, expectation);
			}
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, default(T));
		}

		public AndConstraint<TAssertions> ContainInOrder(params T[] expected)
		{
			return ContainInOrder(expected, string.Empty);
		}

		public AndConstraint<TAssertions> ContainInOrder(IEnumerable<T> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot verify ordered containment against a <null> collection.");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain {0} in order{reason}, but found <null>.", expected);
			if (assertionChain.Succeeded)
			{
				IList<T> list = expected.ConvertOrCastToList();
				IList<T> items = base.Subject.ConvertOrCastToList();
				int num = 0;
				for (int i = 0; i < list.Count; i++)
				{
					T val = list[i];
					num = IndexOf(items, val, num);
					if (num == -1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to contain items {1} in order{reason}, but {2} (index {3}) did not appear (in the right order).", base.Subject, expected, val, i);
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainInConsecutiveOrder(params T[] expected)
		{
			return ContainInConsecutiveOrder(expected, string.Empty);
		}

		public AndConstraint<TAssertions> ContainInConsecutiveOrder(IEnumerable<T> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot verify ordered containment against a <null> collection.");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain {0} in order{reason}, but found <null>.", expected);
			if (assertionChain.Succeeded)
			{
				IList<T> list = expected.ConvertOrCastToList();
				if (list.Count == 0)
				{
					return new AndConstraint<TAssertions>((TAssertions)this);
				}
				IList<T> list2 = base.Subject.ConvertOrCastToList();
				int num = 0;
				int num2 = 0;
				while (num != -1)
				{
					num = IndexOf(list2, list[0], num);
					if (num != -1)
					{
						int num3 = ConsecutiveItemCount(list2, list, num);
						if (num3 == list.Count)
						{
							return new AndConstraint<TAssertions>((TAssertions)this);
						}
						num2 = Math.Max(num2, num3);
						num++;
					}
				}
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to contain items {1} in order{reason}, but {2} (index {3}) did not appear (in the right consecutive order).", base.Subject, expected, list[num2], num2);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> ContainItemsAssignableTo<TExpectation>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain at least one element assignable to type {0}{reason}, ", typeof(TExpectation).FullName, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).FailWith("but found <null>.").Then.Given(() => base.Subject.ConvertOrCastToCollection()).ForCondition((ICollection<T> subject) => subject.Any((T x) => typeof(TExpectation).IsAssignableFrom(GetType(x)))).FailWith("but found {0}.", (ICollection<T> subject) => subject.Select((T x) => GetType(x)));
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainItemsAssignableTo<TExpectation>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotContainItemsAssignableTo(typeof(TExpectation), because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotContainItemsAssignableTo(Type type, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(type, "type");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to not contain any elements assignable to type {0}{reason}, ", type.FullName, delegate(AssertionChain chain)
			{
				chain.ForCondition(base.Subject != null).FailWith("but found <null>.").Then.Given(() => base.Subject.ConvertOrCastToCollection()).ForCondition((ICollection<T> subject) => subject.All((T x) => !type.IsAssignableFrom(GetType(x)))).FailWith("but found {0}.", (ICollection<T> subject) => subject.Select((T x) => GetType(x)));
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndWhichConstraint<TAssertions, T> ContainSingle([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain a single item{reason}, but found <null>.");
			T subject = default(T);
			if (assertionChain.Succeeded)
			{
				ICollection<T> collection = base.Subject.ConvertOrCastToCollection();
				switch (collection.Count)
				{
				case 0:
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to contain a single item{reason}, but the collection is empty.");
					break;
				case 1:
					subject = collection.Single();
					break;
				default:
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to contain a single item{reason}, but found {0}.", base.Subject);
					break;
				}
			}
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, subject, assertionChain, "[0]");
		}

		public AndWhichConstraint<TAssertions, T> ContainSingle(Expression<Func<T, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain a single item matching {0}{reason}, but found <null>.", predicate);
			T[] array = Array.Empty<T>();
			if (assertionChain.Succeeded)
			{
				ICollection<T> collection = base.Subject.ConvertOrCastToCollection();
				assertionChain.ForCondition(collection.Count > 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to contain a single item matching {0}{reason}, but the collection is empty.", predicate);
				array = collection.Where(predicate.Compile()).ToArray();
				int num = array.Length;
				if (num == 0)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to contain a single item matching {0}{reason}, but no such item was found.", predicate);
				}
				else if (num > 1)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to contain a single item matching {0}{reason}, but " + num.ToString(CultureInfo.InvariantCulture) + " such items were found.", predicate);
				}
			}
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, array, assertionChain, "[0]");
		}

		public AndConstraint<TAssertions> EndWith(IEnumerable<T> expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return EndWith(expectation, (T a, T b) => EqualityComparer<T>.Default.Equals(a, b), because, becauseArgs);
		}

		public AndConstraint<TAssertions> EndWith<TExpectation>(IEnumerable<TExpectation> expectation, Func<T, TExpectation, bool> equalityComparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectation, "expectation", "Cannot compare collection with <null>.");
			AssertCollectionEndsWith(base.Subject, expectation.ConvertOrCastToCollection(), equalityComparison, because, becauseArgs);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> EndWith(T element, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return EndWith(new _003C_003Ez__ReadOnlySingleElementList<T>(element), ObjectExtensions.GetComparer<T>(), because, becauseArgs);
		}

		public AndConstraint<TAssertions> Equal(params T[] elements)
		{
			AssertSubjectEquality(elements, ObjectExtensions.GetComparer<T>(), string.Empty);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Equal<TExpectation>(IEnumerable<TExpectation> expectation, Func<T, TExpectation, bool> equalityComparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertSubjectEquality(expectation, equalityComparison, because, becauseArgs);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Equal(IEnumerable<T> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			AssertSubjectEquality(expected, ObjectExtensions.GetComparer<T>(), because, becauseArgs);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveCount(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain {0} item(s){reason}, but found <null>.", expected);
			if (assertionChain.Succeeded)
			{
				int num = base.Subject.Count();
				assertionChain.ForCondition(num == expected).BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to contain {0} item(s){reason}, but found {1}: {2}.", expected, num, base.Subject);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveCount(Expression<Func<int, bool>> countPredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(countPredicate, "countPredicate", "Cannot compare collection count against a <null> predicate.");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to contain {0} items{reason}, but found <null>.", countPredicate.Body);
			if (assertionChain.Succeeded)
			{
				Func<int, bool> func = countPredicate.Compile();
				int num = base.Subject.Count();
				if (!func(num))
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to have a count {0}{reason}, but count is {1}: {2}.", countPredicate.Body, num, base.Subject);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveCountGreaterThanOrEqualTo(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain at least {0} item(s){reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found <null>.")
					.Then.Given((TCollection subject) => subject.Count()).ForCondition((int actualCount) => actualCount >= expected).FailWith("but found {0}: {1}.", (int actualCount) => actualCount, (int _) => base.Subject);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveCountGreaterThan(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain more than {0} item(s){reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found <null>.")
					.Then.Given((TCollection subject) => subject.Count()).ForCondition((int actualCount) => actualCount > expected).FailWith("but found {0}: {1}.", (int actualCount) => actualCount, (int _) => base.Subject);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveCountLessThanOrEqualTo(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain at most {0} item(s){reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found <null>.")
					.Then.Given((TCollection subject) => subject.Count()).ForCondition((int actualCount) => actualCount <= expected).FailWith("but found {0}: {1}.", (int actualCount) => actualCount, (int _) => base.Subject);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveCountLessThan(int expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain fewer than {0} item(s){reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found <null>.")
					.Then.Given((TCollection subject) => subject.Count()).ForCondition((int actualCount) => actualCount < expected).FailWith("but found {0}: {1}.", (int actualCount) => actualCount, (int _) => base.Subject);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndWhichConstraint<TAssertions, T> HaveElementAt(int index, T element, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to have element at index {0}{reason}, but found <null>.", index);
			T val = default(T);
			if (assertionChain.Succeeded)
			{
				if (index < base.Subject.Count())
				{
					val = base.Subject.ElementAt(index);
					assertionChain.ForCondition(ObjectExtensions.GetComparer<T>()(val, element)).BecauseOf(because, becauseArgs).FailWith("Expected {0} at index {1}{reason}, but found {2}.", element, index, val);
				}
				else
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {0} at index {1}{reason}, but found no element.", element, index);
				}
			}
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, val, assertionChain, $"[{index}]");
		}

		public AndConstraint<TAssertions> HaveElementPreceding(T successor, T expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to have {0} precede {1}{reason}, ", expectation, successor, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but the collection is <null>.")
					.Then.ForCondition((TCollection subject) => subject.Any()).FailWith("but the collection is empty.").Then.ForCondition((TCollection subject) => HasPredecessor(successor, subject)).FailWith("but found nothing.").Then.Given((TCollection subject) => PredecessorOf(successor, subject)).ForCondition((T predecessor) => ObjectExtensions.GetComparer<T>()(predecessor, expectation)).FailWith("but found {0}.", (T predecessor) => predecessor);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveElementSucceeding(T predecessor, T expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to have {0} succeed {1}{reason}, ", expectation, predecessor, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but the collection is <null>.")
					.Then.ForCondition((TCollection subject) => subject.Any()).FailWith("but the collection is empty.").Then.ForCondition((TCollection subject) => HasSuccessor(predecessor, subject)).FailWith("but found nothing.").Then.Given((TCollection subject) => SuccessorOf(predecessor, subject)).ForCondition((T successor) => ObjectExtensions.GetComparer<T>()(successor, expectation)).FailWith("but found {0}.", (T successor) => successor);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> HaveSameCount<TExpectation>(IEnumerable<TExpectation> otherCollection, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(otherCollection, "otherCollection", "Cannot verify count against a <null> collection.");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to have ", delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("the same count as {0}{reason}, but found <null>.", otherCollection)
					.Then.Given((TCollection subject) => (actual: subject.Count(), expected: otherCollection.Count())).ForCondition(((int actual, int expected) count) => count.actual == count.expected).FailWith("{0} item(s){reason}, but found {1}.", ((int actual, int expected) count) => count.expected, ((int actual, int expected) count) => count.actual);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> IntersectWith(IEnumerable<T> otherCollection, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(otherCollection, "otherCollection", "Cannot verify intersection against a <null> collection.");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to intersect with {0}{reason}, but found <null>.", otherCollection);
			if (assertionChain.Succeeded)
			{
				IEnumerable<T> source = base.Subject.Intersect(otherCollection);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(source.Any()).FailWith("Expected {context:collection} to intersect with {0}{reason}, but {1} does not contain any shared items.", otherCollection, base.Subject);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} not to be empty{reason}", delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith(", but found <null>.")
					.Then.ForCondition((TCollection subject) => subject.Any()).FailWith(".");
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation> unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot verify inequivalence against a <null> collection.");
			if (base.Subject == null)
			{
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} not to be equivalent{reason}, but found <null>.");
			}
			if ((object)base.Subject == unexpected)
			{
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} not to be equivalent with collection {1}{reason}, but they both reference the same object.", base.Subject, unexpected);
			}
			return NotBeEquivalentTo(unexpected.ConvertOrCastToList(), (EquivalencyOptions<TExpectation> config) => config, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation> unexpected, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot verify inequivalence against a <null> collection.");
			if (base.Subject == null)
			{
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} not to be equivalent{reason}, but found <null>.");
			}
			string[] array;
			using (AssertionScope assertionScope = new AssertionScope())
			{
				BeEquivalentTo(unexpected, config, "");
				array = assertionScope.Discard();
			}
			assertionChain.ForCondition(array.Length != 0).BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} not to be equivalent to collection {1}{reason}.", base.Subject, unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeInAscendingOrder(propertyExpression, GetComparer<TSelector>(), because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInAscendingOrder(IComparer<T> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return NotBeInOrder(comparer, SortOrder.Ascending, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return NotBeOrderedBy(propertyExpression, comparer, SortOrder.Ascending, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInAscendingOrder([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeInAscendingOrder(GetComparer<T>(), because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInAscendingOrder(Func<T, T, int> comparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeInOrder(Comparer<T>.Create((T x, T y) => comparison(x, y)), SortOrder.Ascending, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeInDescendingOrder(propertyExpression, GetComparer<TSelector>(), because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInDescendingOrder(IComparer<T> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return NotBeInOrder(comparer, SortOrder.Descending, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(comparer, "comparer", "Cannot assert collection ordering without specifying a comparer.");
			return NotBeOrderedBy(propertyExpression, comparer, SortOrder.Descending, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInDescendingOrder([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeInDescendingOrder(GetComparer<T>(), because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeInDescendingOrder(Func<T, T, int> comparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeInOrder(Comparer<T>.Create((T x, T y) => comparison(x, y)), SortOrder.Descending, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeNullOrEmpty([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeNull(because, becauseArgs).And.NotBeEmpty(because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeSubsetOf(IEnumerable<T> unexpectedSuperset, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Cannot assert a <null> collection against a subset.");
			if (assertionChain.Succeeded)
			{
				if ((object)base.Subject == unexpectedSuperset)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Did not expect {context:collection} {0} to be a subset of {1}{reason}, but they both reference the same object.", base.Subject, unexpectedSuperset);
				}
				ICollection<T> collection = base.Subject.ConvertOrCastToCollection();
				if (collection.Intersect(unexpectedSuperset).Count() == collection.Count)
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Did not expect {context:collection} {0} to be a subset of {1}{reason}.", collection, unexpectedSuperset);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContain(T unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to not contain {0}{reason}, but found <null>.", unexpected);
			if (assertionChain.Succeeded)
			{
				ICollection<T> collection = base.Subject.ConvertOrCastToCollection();
				if (collection.Contains(unexpected))
				{
					assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to not contain {1}{reason}.", collection, unexpected);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContain(Expression<Func<T, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} not to contain {0}{reason}, but found <null>.", predicate.Body);
			if (assertionChain.Succeeded)
			{
				Func<T, bool> compiledPredicate = predicate.Compile();
				IEnumerable<T> enumerable = base.Subject.Where((T item) => compiledPredicate(item));
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!enumerable.Any()).FailWith("Expected {context:collection} {0} to not have any items matching {1}{reason}, but found {2}.", base.Subject, predicate, enumerable);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContain(IEnumerable<T> unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot verify non-containment against a <null> collection");
			ICollection<T> collection = unexpected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(collection, "unexpected", "Cannot verify non-containment against an empty collection");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to not contain {0}{reason}, but found <null>.", unexpected);
			if (assertionChain.Succeeded)
			{
				IEnumerable<T> enumerable = collection.Intersect(base.Subject);
				if (enumerable.Any())
				{
					if (collection.Count > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to not contain {1}{reason}, but found {2}.", base.Subject, unexpected, enumerable);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to not contain {1}{reason}.", base.Subject, collection.First());
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainEquivalentOf<TExpectation>(TExpectation unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotContainEquivalentOf(unexpected, (EquivalencyOptions<TExpectation> config) => config, because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotContainEquivalentOf<TExpectation>(TExpectation unexpected, Func<EquivalencyOptions<TExpectation>, EquivalencyOptions<TExpectation>> config, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(config, "config");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} not to contain equivalent of {0}{reason}, but collection is <null>.", unexpected);
			if (assertionChain.Succeeded)
			{
				EquivalencyOptions<TExpectation> options = config(AssertionConfiguration.Current.Equivalency.CloneDefaults<TExpectation>());
				List<int> foundIndices = new List<int>();
				using (AssertionScope assertionScope = new AssertionScope())
				{
					int num = 0;
					foreach (T item in base.Subject)
					{
						EquivalencyValidationContext context = new EquivalencyValidationContext(Node.From<TExpectation>(() => base.CurrentAssertionChain.CallerIdentifier), options)
						{
							Reason = new Reason(because, becauseArgs),
							TraceWriter = options.TraceWriter
						};
						Comparands comparands = new Comparands
						{
							Subject = item,
							Expectation = unexpected,
							CompileTimeType = typeof(TExpectation)
						};
						new EquivalencyValidator().AssertEquality(comparands, context);
						if (assertionScope.Discard().Length == 0)
						{
							foundIndices.Add(num);
						}
						num++;
					}
				}
				if (foundIndices.Count > 0)
				{
					using (new AssertionScope())
					{
						assertionChain.BecauseOf(because, becauseArgs).WithReportable("configuration", () => options.ToString()).WithExpectation("Expected {context:collection} {0} not to contain equivalent of {1}{reason}, ", base.Subject, unexpected, delegate(AssertionChain chain)
						{
							if (foundIndices.Count == 1)
							{
								chain.FailWith("but found one at index {0}.", foundIndices[0]);
							}
							else
							{
								chain.FailWith("but found several at indices {0}.", foundIndices);
							}
						});
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainInOrder(params T[] unexpected)
		{
			return NotContainInOrder(unexpected, string.Empty);
		}

		public AndConstraint<TAssertions> NotContainInOrder(IEnumerable<T> unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot verify absence of ordered containment against a <null> collection.");
			if (base.Subject == null)
			{
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Cannot verify absence of ordered containment in a <null> collection.");
				return new AndConstraint<TAssertions>((TAssertions)this);
			}
			IList<T> list = unexpected.ConvertOrCastToList();
			if (list.Any())
			{
				IList<T> items = base.Subject.ConvertOrCastToList();
				int num = 0;
				foreach (T item in list)
				{
					num = IndexOf(items, item, num);
					if (num == -1)
					{
						return new AndConstraint<TAssertions>((TAssertions)this);
					}
				}
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to not contain items {1} in order{reason}, but items appeared in order ending at index {2}.", base.Subject, unexpected, num - 1);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainInConsecutiveOrder(params T[] unexpected)
		{
			return NotContainInConsecutiveOrder(unexpected, string.Empty);
		}

		public AndConstraint<TAssertions> NotContainInConsecutiveOrder(IEnumerable<T> unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot verify absence of ordered containment against a <null> collection.");
			if (base.Subject == null)
			{
				assertionChain.BecauseOf(because, becauseArgs).FailWith("Cannot verify absence of ordered containment in a <null> collection.");
				return new AndConstraint<TAssertions>((TAssertions)this);
			}
			IList<T> list = unexpected.ConvertOrCastToList();
			if (list.Any())
			{
				IList<T> list2 = base.Subject.ConvertOrCastToList();
				if (list.Count > list2.Count)
				{
					return new AndConstraint<TAssertions>((TAssertions)this);
				}
				int num = 0;
				while (num != -1)
				{
					num = IndexOf(list2, list[0], num);
					if (num != -1)
					{
						int num2 = ConsecutiveItemCount(list2, list, num);
						if (num2 == list.Count)
						{
							assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to not contain items {1} in consecutive order{reason}, but items appeared in order ending at index {2}.", base.Subject, list, num + num2 - 2);
						}
						num++;
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainNulls<TKey>(Expression<Func<T, TKey>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TKey : class
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} not to contain <null>s{reason}, but collection is <null>.");
			if (assertionChain.Succeeded)
			{
				Func<T, TKey> compiledPredicate = predicate.Compile();
				T[] array = base.Subject.Where((T e) => compiledPredicate(e) == null).ToArray();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(array.Length == 0).FailWith("Expected {context:collection} not to contain <null>s on {0}{reason}, but found {1}.", predicate.Body, array);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotContainNulls([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} not to contain <null>s{reason}, but collection is <null>.");
			if (assertionChain.Succeeded)
			{
				int[] array = (from e in base.Subject.Select((T item, int index) => (Item: item, Index: index))
					where e.Item == null
					select e.Index).ToArray();
				if (array.Length != 0)
				{
					if (array.Length > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} not to contain <null>s{reason}, but found several at indices {0}.", array);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} not to contain <null>s{reason}, but found one at index {0}.", array[0]);
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotEqual(IEnumerable<T> unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpected, "unexpected", "Cannot compare collection with <null>.");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected collections not to be equal{reason}, ", delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found <null>.")
					.Then.ForCondition((TCollection subject) => (object)subject != unexpected).FailWith("but they both reference the same object.");
			}).Then.Given(() => base.Subject.ConvertOrCastToCollection()).ForCondition((ICollection<T> actualItems) => !actualItems.SequenceEqual(unexpected)).FailWith("Did not expect collections {0} and {1} to be equal{reason}.", (ICollection<T> _) => unexpected, (ICollection<T> actualItems) => actualItems);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveCount(int unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to not contain {0} item(s){reason}, ", unexpected, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but found <null>.")
					.Then.Given((TCollection subject) => subject.Count()).ForCondition((int actualCount) => actualCount != unexpected).FailWith("but found {0}.", (int actualCount) => actualCount);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotHaveSameCount<TExpectation>(IEnumerable<TExpectation> otherCollection, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(otherCollection, "otherCollection", "Cannot verify count against a <null> collection.");
			assertionChain.BecauseOf(because, becauseArgs).Given(() => base.Subject).ForCondition((TCollection subject) => subject != null)
				.FailWith("Expected {context:collection} to not have the same count as {0}{reason}, but found <null>.", otherCollection)
				.Then.ForCondition((TCollection subject) => (object)subject != otherCollection).FailWith("Expected {context:collection} {0} to not have the same count as {1}{reason}, but they both reference the same object.", (TCollection subject) => subject, (TCollection _) => otherCollection).Then.Given((TCollection subject) => (actual: subject.Count(), expected: otherCollection.Count())).ForCondition(((int actual, int expected) count) => count.actual != count.expected).FailWith("Expected {context:collection} to not have {0} item(s){reason}, but found {1}.", ((int actual, int expected) count) => count.expected, ((int actual, int expected) count) => count.actual);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotIntersectWith(IEnumerable<T> otherCollection, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(otherCollection, "otherCollection", "Cannot verify intersection against a <null> collection.");
			assertionChain.BecauseOf(because, becauseArgs).Given(() => base.Subject).ForCondition((TCollection subject) => subject != null)
				.FailWith("Did not expect {context:collection} to intersect with {0}{reason}, but found <null>.", otherCollection)
				.Then.ForCondition((TCollection subject) => (object)subject != otherCollection).FailWith("Did not expect {context:collection} {0} to intersect with {1}{reason}, but they both reference the same object.", (TCollection subject) => subject, (TCollection _) => otherCollection).Then.Given((TCollection subject) => subject.Intersect(otherCollection)).ForCondition((IEnumerable<T> sharedItems) => !sharedItems.Any()).FailWith("Did not expect {context:collection} to intersect with {0}{reason}, but found the following shared items {1}.", (IEnumerable<T> _) => otherCollection, (IEnumerable<T> sharedItems) => sharedItems);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> OnlyContain(Expression<Func<T, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			Func<T, bool> compiledPredicate = predicate.Compile();
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain only items matching {0}{reason}, ", predicate.Body, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but the collection is <null>.")
					.Then.Given((TCollection subject) => from item in subject.ConvertOrCastToCollection()
					where !compiledPredicate(item)
					select item).ForCondition((IEnumerable<T> mismatchingItems) => !mismatchingItems.Any()).FailWith("but {0} do(es) not match.", (IEnumerable<T> mismatchingItems) => mismatchingItems);
			});
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> OnlyHaveUniqueItems<TKey>(Expression<Func<T, TKey>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to only have unique items{reason}, but found <null>.");
			if (assertionChain.Succeeded)
			{
				Func<T, TKey> keySelector = predicate.Compile();
				IGrouping<TKey, T>[] array = (from g in base.Subject.GroupBy(keySelector)
					where g.Count() > 1
					select g).ToArray();
				if (array.Length != 0)
				{
					if (array.Length > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to only have unique items on {0}{reason}, but items {1} are not unique.", predicate.Body, array.SelectMany((IGrouping<TKey, T> g) => g));
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to only have unique items on {0}{reason}, but item {1} is not unique.", predicate.Body, array[0].First());
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> OnlyHaveUniqueItems([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to only have unique items{reason}, but found <null>.");
			if (assertionChain.Succeeded)
			{
				T[] array = (from o in base.Subject
					group o by o into g
					where g.Count() > 1
					select g.Key).ToArray();
				if (array.Length != 0)
				{
					if (array.Length > 1)
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to only have unique items{reason}, but items {0} are not unique.", array);
					}
					else
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to only have unique items{reason}, but item {0} is not unique.", array[0]);
					}
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> AllSatisfy(Action<T> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot verify against a <null> inspector");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain only items satisfying the inspector{reason}, ", delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but collection is <null>.");
			});
			if (assertionChain.Succeeded)
			{
				string[] array;
				using (CallerIdentifier.OverrideStackSearchUsingCurrentScope())
				{
					IEnumerable<Action<T>> elementInspectors = base.Subject.Select((T _) => expected);
					array = CollectFailuresFromInspectors(elementInspectors);
				}
				if (array.Length != 0)
				{
					string failureMessage = Environment.NewLine + string.Join(Environment.NewLine, array.Select((string x) => x.IndentLines()));
					assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to contain only items satisfying the inspector{reason}:", delegate(AssertionChain chain)
					{
						chain.FailWithPreFormatted(failureMessage);
					});
				}
				return new AndConstraint<TAssertions>((TAssertions)this);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> SatisfyRespectively(params Action<T>[] elementInspectors)
		{
			return SatisfyRespectively(elementInspectors, string.Empty);
		}

		public AndConstraint<TAssertions> SatisfyRespectively(IEnumerable<Action<T>> expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expected, "expected", "Cannot verify against a <null> collection of inspectors");
			ICollection<Action<T>> elementInspectors = expected.ConvertOrCastToCollection();
			Guard.ThrowIfArgumentIsEmpty(elementInspectors, "expected", "Cannot verify against an empty collection of inspectors");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to satisfy all inspectors{reason}, ", delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject).ForCondition((TCollection subject) => subject != null).FailWith("but collection is <null>.")
					.Then.ForCondition((TCollection subject) => subject.Any()).FailWith("but collection is empty.");
			}).Then.Given(() => (elements: base.Subject.Count(), inspectors: elementInspectors.Count)).ForCondition(((int elements, int inspectors) count) => count.elements == count.inspectors).FailWith("Expected {context:collection} to contain exactly {0} items{reason}, but it contains {1} items", ((int elements, int inspectors) count) => count.inspectors, ((int elements, int inspectors) count) => count.elements);
			if (assertionChain.Succeeded)
			{
				string[] array;
				using (CallerIdentifier.OverrideStackSearchUsingCurrentScope())
				{
					array = CollectFailuresFromInspectors(elementInspectors);
				}
				if (array.Length != 0)
				{
					string failureMessage = Environment.NewLine + string.Join(Environment.NewLine, array.Select((string x) => x.IndentLines()));
					assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to satisfy all inspectors{reason}, but some inspectors are not satisfied:", delegate(AssertionChain chain)
					{
						chain.FailWithPreFormatted(failureMessage);
					});
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Satisfy(params Expression<Func<T, bool>>[] predicates)
		{
			return Satisfy(predicates, string.Empty);
		}

		public AndConstraint<TAssertions> Satisfy(IEnumerable<Expression<Func<T, bool>>> predicates, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(predicates, "predicates", "Cannot verify against a <null> collection of predicates");
			IList<Expression<Func<T, bool>>> list = predicates.ConvertOrCastToList();
			Guard.ThrowIfArgumentIsEmpty(list, "predicates", "Cannot verify against an empty collection of predicates");
			assertionChain.BecauseOf(because, becauseArgs).Given(() => base.Subject).ForCondition((TCollection subject) => subject != null)
				.FailWith("Expected {context:collection} to satisfy all predicates{reason}, but collection is <null>.")
				.Then.ForCondition((TCollection subject) => subject.Any()).FailWith("Expected {context:collection} to satisfy all predicates{reason}, but collection is empty.");
			if (assertionChain.Succeeded)
			{
				MaximumMatchingSolution<T> maximumMatchingSolution = new MaximumMatchingProblem<T>(list, base.Subject).Solve();
				if (maximumMatchingSolution.UnmatchedPredicatesExist || maximumMatchingSolution.UnmatchedElementsExist)
				{
					string message = string.Empty;
					string text = Environment.NewLine + Environment.NewLine;
					List<FluentAssertions.Collections.MaximumMatching.Predicate<T>> unmatchedPredicates = maximumMatchingSolution.GetUnmatchedPredicates();
					if (unmatchedPredicates.Count > 0)
					{
						message = message + text + "The following predicates did not have matching elements:";
						message = message + text + string.Join(Environment.NewLine, unmatchedPredicates.Select((FluentAssertions.Collections.MaximumMatching.Predicate<T> predicate) => Formatter.ToString(predicate.Expression)));
					}
					List<Element<T>> unmatchedElements = maximumMatchingSolution.GetUnmatchedElements();
					if (unmatchedElements.Count > 0)
					{
						message = message + text + "The following elements did not match any predicate:";
						IEnumerable<string> values = unmatchedElements.Select((Element<T> element) => $"Index: {element.Index}, Element: {Formatter.ToString(element.Value)}");
						message = message + text + string.Join(text, values);
					}
					assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to satisfy all predicates{reason}, but:", delegate(AssertionChain chain)
					{
						chain.FailWithPreFormatted(message);
					});
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> StartWith(IEnumerable<T> expectation, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return StartWith(expectation, (T a, T b) => EqualityComparer<T>.Default.Equals(a, b), because, becauseArgs);
		}

		public AndConstraint<TAssertions> StartWith<TExpectation>(IEnumerable<TExpectation> expectation, Func<T, TExpectation, bool> equalityComparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectation, "expectation", "Cannot compare collection with <null>.");
			AssertCollectionStartsWith(base.Subject, expectation.ConvertOrCastToCollection(), equalityComparison, because, becauseArgs);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> StartWith(T element, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return StartWith(new _003C_003Ez__ReadOnlySingleElementList<T>(element), ObjectExtensions.GetComparer<T>(), because, becauseArgs);
		}

		internal AndConstraint<SubsequentOrderingAssertions<T>> BeOrderedBy<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, SortOrder direction, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			if (IsValidProperty(propertyExpression, because, becauseArgs))
			{
				ICollection<T> collection = base.Subject.ConvertOrCastToCollection();
				IOrderedEnumerable<T> expectation = GetOrderedEnumerable(propertyExpression, comparer, direction, collection);
				assertionChain.ForCondition(collection.SequenceEqual(expectation)).BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to be ordered {1}{reason} and result in {2}.", () => base.Subject, () => GetExpressionOrderString(propertyExpression), () => expectation);
				return new AndConstraint<SubsequentOrderingAssertions<T>>(new SubsequentOrderingAssertions<T>(base.Subject, expectation, assertionChain));
			}
			return new AndConstraint<SubsequentOrderingAssertions<T>>(new SubsequentOrderingAssertions<T>(base.Subject, from x in Enumerable.Empty<T>()
				orderby x
				select x, assertionChain));
		}

		internal virtual IOrderedEnumerable<T> GetOrderedEnumerable<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, SortOrder direction, ICollection<T> unordered)
		{
			Func<T, TSelector> keySelector = propertyExpression.Compile();
			if (direction != SortOrder.Ascending)
			{
				return unordered.OrderByDescending(keySelector, comparer);
			}
			return unordered.OrderBy(keySelector, comparer);
		}

		protected static IEnumerable<TExpectation> RepeatAsManyAs<TExpectation>(TExpectation value, IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				return Array.Empty<TExpectation>();
			}
			return RepeatAsManyAsIterator(value, enumerable);
		}

		protected void AssertCollectionEndsWith<TActual, TExpectation>(IEnumerable<TActual> actual, ICollection<TExpectation> expected, Func<TActual, TExpectation, bool> equalityComparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(equalityComparison, "equalityComparison");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to end with {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.Given(() => actual).AssertCollectionIsNotNull().Then.AssertCollectionHasEnoughItems(expected.Count).Then.AssertCollectionsHaveSameItems(expected, delegate(ICollection<TActual> a, ICollection<TExpectation> e)
				{
					int num = a.Count - e.Count;
					int num2 = a.Skip(num).IndexOfFirstDifferenceWith(e, equalityComparison);
					return (num2 < 0) ? num2 : (num2 + num);
				});
			});
		}

		protected void AssertCollectionStartsWith<TActual, TExpectation>(IEnumerable<TActual> actualItems, ICollection<TExpectation> expected, Func<TActual, TExpectation, bool> equalityComparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(equalityComparison, "equalityComparison");
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected {context:collection} to start with {0}{reason}, ", expected, delegate(AssertionChain chain)
			{
				chain.Given(() => actualItems).AssertCollectionIsNotNull().Then.AssertCollectionHasEnoughItems(expected.Count).Then.AssertCollectionsHaveSameItems(expected, (ICollection<TActual> a, ICollection<TExpectation> e) => a.Take(e.Count).IndexOfFirstDifferenceWith(e, equalityComparison));
			});
		}

		protected void AssertSubjectEquality<TExpectation>(IEnumerable<TExpectation> expectation, Func<T, TExpectation, bool> equalityComparison, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(equalityComparison, "equalityComparison");
			bool flag = base.Subject == null;
			bool flag2 = expectation == null;
			if (flag && flag2)
			{
				return;
			}
			Guard.ThrowIfArgumentIsNull(expectation, "expectation", "Cannot compare collection with <null>.");
			ICollection<TExpectation> expectedItems = expectation.ConvertOrCastToCollection();
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(!flag).FailWith("Expected {context:collection} to be equal to {0}{reason}, but found <null>.", expectedItems)
				.Then.WithExpectation("Expected {context:collection} to be equal to {0}{reason}, ", expectedItems, delegate(AssertionChain chain)
			{
				chain.Given(() => base.Subject.ConvertOrCastToCollection()).AssertCollectionsHaveSameCount(expectedItems.Count).Then.AssertCollectionsHaveSameItems(expectedItems, (ICollection<T> a, ICollection<TExpectation> e) => a.IndexOfFirstDifferenceWith(e, equalityComparison));
			});
		}

		private static string GetExpressionOrderString<TSelector>(Expression<Func<T, TSelector>> propertyExpression)
		{
			string text = propertyExpression.GetMemberPath().ToString();
			if (!(text == "\"\""))
			{
				return "by " + text;
			}
			return string.Empty;
		}

		private static Type GetType<TType>(TType o)
		{
			if (!(o is Type result))
			{
				return o.GetType();
			}
			return result;
		}

		private static bool HasPredecessor(T successor, TCollection subject)
		{
			return (object)subject.First() != (object)successor;
		}

		private static bool HasSuccessor(T predecessor, TCollection subject)
		{
			return (object)subject.Last() != (object)predecessor;
		}

		private static T PredecessorOf(T successor, TCollection subject)
		{
			IList<T> list = subject.ConvertOrCastToList();
			int num = list.IndexOf(successor);
			if (num <= 0)
			{
				return default(T);
			}
			return list[num - 1];
		}

		private static IEnumerable<TExpectation> RepeatAsManyAsIterator<TExpectation>(TExpectation value, IEnumerable<T> enumerable)
		{
			using IEnumerator<T> enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return value;
			}
		}

		private static T SuccessorOf(T predecessor, TCollection subject)
		{
			IList<T> list = subject.ConvertOrCastToList();
			int num = list.IndexOf(predecessor);
			if (num >= list.Count - 1)
			{
				return default(T);
			}
			return list[num + 1];
		}

		private string[] CollectFailuresFromInspectors(IEnumerable<Action<T>> elementInspectors)
		{
			using AssertionScope assertionScope = new AssertionScope();
			int num = 0;
			foreach (var (obj, action) in base.Subject.Zip(elementInspectors, (T element, Action<T> inspector) => (element: element, inspector: inspector)))
			{
				string[] array;
				using (AssertionScope assertionScope2 = new AssertionScope())
				{
					action(obj);
					array = assertionScope2.Discard();
				}
				if (array.Length != 0)
				{
					string arg = string.Join(Environment.NewLine, array.Select((string x) => x.IndentLines().TrimEnd(new char[1] { '.' })));
					assertionScope.AddPreFormattedFailure($"At index {num}:{Environment.NewLine}{arg}");
				}
				num++;
			}
			return assertionScope.Discard();
		}

		private bool IsValidProperty<TSelector>(Expression<Func<T, TSelector>> propertyExpression, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(propertyExpression, "propertyExpression", "Cannot assert collection ordering without specifying a property.");
			propertyExpression.ValidateMemberPath();
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to be ordered by {0}{reason} but found <null>.", () => propertyExpression.GetMemberPath());
			return assertionChain.Succeeded;
		}

		private AndConstraint<TAssertions> NotBeOrderedBy<TSelector>(Expression<Func<T, TSelector>> propertyExpression, IComparer<TSelector> comparer, SortOrder direction, [StringSyntax("CompositeFormat")] string because, object[] becauseArgs)
		{
			if (IsValidProperty(propertyExpression, because, becauseArgs))
			{
				ICollection<T> collection = base.Subject.ConvertOrCastToCollection();
				IOrderedEnumerable<T> expectation = GetOrderedEnumerable(propertyExpression, comparer, direction, collection);
				assertionChain.ForCondition(!collection.SequenceEqual(expectation)).BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} {0} to not be ordered {1}{reason} and not result in {2}.", () => base.Subject, () => GetExpressionOrderString(propertyExpression), () => expectation);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		private AndConstraint<SubsequentOrderingAssertions<T>> BeInOrder(IComparer<T> comparer, SortOrder expectedOrder, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			string text = ((expectedOrder == SortOrder.Ascending) ? "ascending" : "descending");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Expected {context:collection} to be in " + text + " order{reason}, but found <null>.");
			IOrderedEnumerable<T> orderedEnumerable = from x in Array.Empty<T>()
				orderby x
				select x;
			if (assertionChain.Succeeded)
			{
				IList<T> list = base.Subject.ConvertOrCastToList();
				orderedEnumerable = ((expectedOrder == SortOrder.Ascending) ? list.OrderBy((T item) => item, comparer) : list.OrderByDescending((T item) => item, comparer));
				T[] array = orderedEnumerable.ToArray();
				Func<T, T, bool> comparer2 = ObjectExtensions.GetComparer<T>();
				for (int num = 0; num < array.Length; num++)
				{
					if (!comparer2(list[num], array[num]))
					{
						assertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {context:collection} to be in " + text + " order{reason}, but found {0} where item at index {1} is in wrong order.", list, num);
						return new AndConstraint<SubsequentOrderingAssertions<T>>(new SubsequentOrderingAssertions<T>(base.Subject, from x in Enumerable.Empty<T>()
							orderby x
							select x, assertionChain));
					}
				}
			}
			return new AndConstraint<SubsequentOrderingAssertions<T>>(new SubsequentOrderingAssertions<T>(base.Subject, orderedEnumerable, assertionChain));
		}

		private AndConstraint<TAssertions> NotBeInOrder(IComparer<T> comparer, SortOrder order, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			string text = ((order == SortOrder.Ascending) ? "ascending" : "descending");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != null).FailWith("Did not expect {context:collection} to be in " + text + " order{reason}, but found <null>.");
			if (assertionChain.Succeeded)
			{
				IList<T> list = base.Subject.ConvertOrCastToList();
				T[] orderedItems = ((order == SortOrder.Ascending) ? list.OrderBy((T item) => item, comparer).ToArray() : list.OrderByDescending((T item) => item, comparer).ToArray());
				Func<T, T, bool> areSameOrEqual = ObjectExtensions.GetComparer<T>();
				bool condition = list.Where((T actualItem, int index) => !areSameOrEqual(actualItem, orderedItems[index])).Any();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(condition).FailWith("Did not expect {context:collection} to be in " + text + " order{reason}, but found {0}.", list);
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean BeSameAs(), Equal(), or BeEquivalentTo() instead?");
		}

		private static int IndexOf(IList<T> items, T item, int startIndex)
		{
			Func<T, T, bool> comparer = ObjectExtensions.GetComparer<T>();
			while (startIndex < items.Count)
			{
				if (comparer(items[startIndex], item))
				{
					startIndex++;
					return startIndex;
				}
				startIndex++;
			}
			return -1;
		}

		private static int ConsecutiveItemCount(IList<T> actualItems, IList<T> expectedItems, int startIndex)
		{
			for (int i = 1; i < expectedItems.Count; i++)
			{
				T item = expectedItems[i];
				int startNumber = startIndex;
				startIndex = IndexOf(actualItems, item, startIndex);
				if (startIndex == -1 || !startNumber.IsConsecutiveTo(startIndex))
				{
					return i;
				}
			}
			return expectedItems.Count;
		}

		private protected static IComparer<TItem> GetComparer<TItem>()
		{
			if (!(typeof(TItem) == typeof(string)))
			{
				return Comparer<TItem>.Default;
			}
			return (IComparer<TItem>)StringComparer.Ordinal;
		}
	}
}

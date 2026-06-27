using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentAssertions.Collections;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;
using FluentAssertions.Primitives;
using FluentAssertions.Specialized;
using FluentAssertions.Streams;
using FluentAssertions.Types;
using FluentAssertions.Xml;

namespace FluentAssertions
{
	[DebuggerNonUserCode]
	public static class AssertionExtensions
	{
		private static readonly AggregateExceptionExtractor Extractor;

		static AssertionExtensions()
		{
			Extractor = new AggregateExceptionExtractor();
			AssertionEngine.EnsureInitialized();
		}

		public static Action Invoking<T>(this T subject, Action<T> action)
		{
			Guard.ThrowIfArgumentIsNull(subject, "subject");
			Guard.ThrowIfArgumentIsNull(action, "action");
			return delegate
			{
				action(subject);
			};
		}

		public static Func<TResult> Invoking<T, TResult>(this T subject, Func<T, TResult> action)
		{
			Guard.ThrowIfArgumentIsNull(subject, "subject");
			Guard.ThrowIfArgumentIsNull(action, "action");
			return () => action(subject);
		}

		public static Func<Task> Awaiting<T>(this T subject, Func<T, Task> action)
		{
			return () => action(subject);
		}

		public static Func<Task<TResult>> Awaiting<T, TResult>(this T subject, Func<T, Task<TResult>> action)
		{
			return () => action(subject);
		}

		public static Func<Task> Awaiting<T>(this T subject, Func<T, ValueTask> action)
		{
			return () => action(subject).AsTask();
		}

		public static Func<Task<TResult>> Awaiting<T, TResult>(this T subject, Func<T, ValueTask<TResult>> action)
		{
			return () => action(subject).AsTask();
		}

		public static MemberExecutionTime<T> ExecutionTimeOf<T>(this T subject, Expression<Action<T>> action, StartTimer createTimer = null)
		{
			Guard.ThrowIfArgumentIsNull(subject, "subject");
			Guard.ThrowIfArgumentIsNull(action, "action");
			if (createTimer == null)
			{
				createTimer = () => new StopwatchTimer();
			}
			return new MemberExecutionTime<T>(subject, action, createTimer);
		}

		public static ExecutionTime ExecutionTime(this Action action, StartTimer createTimer = null)
		{
			if (createTimer == null)
			{
				createTimer = () => new StopwatchTimer();
			}
			return new ExecutionTime(action, createTimer);
		}

		public static ExecutionTime ExecutionTime(this Func<Task> action)
		{
			return new ExecutionTime(action, () => new StopwatchTimer());
		}

		public static ExecutionTimeAssertions Should(this ExecutionTime executionTime)
		{
			return new ExecutionTimeAssertions(executionTime, AssertionChain.GetOrCreate());
		}

		public static AssemblyAssertions Should([NotNull] this Assembly assembly)
		{
			return new AssemblyAssertions(assembly, AssertionChain.GetOrCreate());
		}

		public static XDocumentAssertions Should([NotNull] this XDocument actualValue)
		{
			return new XDocumentAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static XElementAssertions Should([NotNull] this XElement actualValue)
		{
			return new XElementAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static XAttributeAssertions Should([NotNull] this XAttribute actualValue)
		{
			return new XAttributeAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static StreamAssertions Should([NotNull] this Stream actualValue)
		{
			return new StreamAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static BufferedStreamAssertions Should([NotNull] this BufferedStream actualValue)
		{
			return new BufferedStreamAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static Action Enumerating(this Func<IEnumerable> enumerable)
		{
			return delegate
			{
				ForceEnumeration(enumerable);
			};
		}

		public static Action Enumerating<T>(this Func<IEnumerable<T>> enumerable)
		{
			return delegate
			{
				ForceEnumeration(enumerable);
			};
		}

		public static Action Enumerating<T, TResult>(this T subject, Func<T, IEnumerable<TResult>> enumerable)
		{
			return delegate
			{
				ForceEnumeration(subject, enumerable);
			};
		}

		private static void ForceEnumeration(Func<IEnumerable> enumerable)
		{
			foreach (object item in enumerable())
			{
				_ = item;
			}
		}

		private static void ForceEnumeration<T>(T subject, Func<T, IEnumerable> enumerable)
		{
			foreach (object item in enumerable(subject))
			{
				_ = item;
			}
		}

		public static ObjectAssertions Should([NotNull] this object actualValue)
		{
			return new ObjectAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static BooleanAssertions Should(this bool actualValue)
		{
			return new BooleanAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableBooleanAssertions Should([NotNull] this bool? actualValue)
		{
			return new NullableBooleanAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static GuidAssertions Should(this Guid actualValue)
		{
			return new GuidAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableGuidAssertions Should([NotNull] this Guid? actualValue)
		{
			return new NullableGuidAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static GenericCollectionAssertions<T> Should<T>([NotNull] this IEnumerable<T> actualValue)
		{
			return new GenericCollectionAssertions<T>(actualValue, AssertionChain.GetOrCreate());
		}

		public static StringCollectionAssertions Should([NotNull] this IEnumerable<string> @this)
		{
			return new StringCollectionAssertions(@this, AssertionChain.GetOrCreate());
		}

		public static GenericDictionaryAssertions<IDictionary<TKey, TValue>, TKey, TValue> Should<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> actualValue)
		{
			return new GenericDictionaryAssertions<IDictionary<TKey, TValue>, TKey, TValue>(actualValue, AssertionChain.GetOrCreate());
		}

		public static GenericDictionaryAssertions<IEnumerable<KeyValuePair<TKey, TValue>>, TKey, TValue> Should<TKey, TValue>([NotNull] this IEnumerable<KeyValuePair<TKey, TValue>> actualValue)
		{
			return new GenericDictionaryAssertions<IEnumerable<KeyValuePair<TKey, TValue>>, TKey, TValue>(actualValue, AssertionChain.GetOrCreate());
		}

		public static GenericDictionaryAssertions<TCollection, TKey, TValue> Should<TCollection, TKey, TValue>([NotNull] this TCollection actualValue) where TCollection : IEnumerable<KeyValuePair<TKey, TValue>>
		{
			return new GenericDictionaryAssertions<TCollection, TKey, TValue>(actualValue, AssertionChain.GetOrCreate());
		}

		public static DateTimeAssertions Should(this DateTime actualValue)
		{
			return new DateTimeAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static DateTimeOffsetAssertions Should(this DateTimeOffset actualValue)
		{
			return new DateTimeOffsetAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableDateTimeAssertions Should([NotNull] this DateTime? actualValue)
		{
			return new NullableDateTimeAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableDateTimeOffsetAssertions Should([NotNull] this DateTimeOffset? actualValue)
		{
			return new NullableDateTimeOffsetAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static ComparableTypeAssertions<T> Should<T>([NotNull] this IComparable<T> comparableValue)
		{
			return new ComparableTypeAssertions<T>(comparableValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<int> Should(this int actualValue)
		{
			return new Int32Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<int> Should([NotNull] this int? actualValue)
		{
			return new NullableInt32Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<uint> Should(this uint actualValue)
		{
			return new UInt32Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<uint> Should([NotNull] this uint? actualValue)
		{
			return new NullableUInt32Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<decimal> Should(this decimal actualValue)
		{
			return new DecimalAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<decimal> Should([NotNull] this decimal? actualValue)
		{
			return new NullableDecimalAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<byte> Should(this byte actualValue)
		{
			return new ByteAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<byte> Should([NotNull] this byte? actualValue)
		{
			return new NullableByteAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<sbyte> Should(this sbyte actualValue)
		{
			return new SByteAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<sbyte> Should([NotNull] this sbyte? actualValue)
		{
			return new NullableSByteAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<short> Should(this short actualValue)
		{
			return new Int16Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<short> Should([NotNull] this short? actualValue)
		{
			return new NullableInt16Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<ushort> Should(this ushort actualValue)
		{
			return new UInt16Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<ushort> Should([NotNull] this ushort? actualValue)
		{
			return new NullableUInt16Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<long> Should(this long actualValue)
		{
			return new Int64Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<long> Should([NotNull] this long? actualValue)
		{
			return new NullableInt64Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<ulong> Should(this ulong actualValue)
		{
			return new UInt64Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<ulong> Should([NotNull] this ulong? actualValue)
		{
			return new NullableUInt64Assertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<float> Should(this float actualValue)
		{
			return new SingleAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<float> Should([NotNull] this float? actualValue)
		{
			return new NullableSingleAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NumericAssertions<double> Should(this double actualValue)
		{
			return new DoubleAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableNumericAssertions<double> Should([NotNull] this double? actualValue)
		{
			return new NullableDoubleAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static StringAssertions Should([NotNull] this string actualValue)
		{
			return new StringAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static SimpleTimeSpanAssertions Should(this TimeSpan actualValue)
		{
			return new SimpleTimeSpanAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static NullableSimpleTimeSpanAssertions Should([NotNull] this TimeSpan? actualValue)
		{
			return new NullableSimpleTimeSpanAssertions(actualValue, AssertionChain.GetOrCreate());
		}

		public static TypeAssertions Should([NotNull] this Type subject)
		{
			return new TypeAssertions(subject, AssertionChain.GetOrCreate());
		}

		public static TypeSelectorAssertions Should(this TypeSelector typeSelector)
		{
			Guard.ThrowIfArgumentIsNull(typeSelector, "typeSelector");
			return new TypeSelectorAssertions(AssertionChain.GetOrCreate(), typeSelector.ToArray());
		}

		public static ConstructorInfoAssertions Should([NotNull] this ConstructorInfo constructorInfo)
		{
			return new ConstructorInfoAssertions(constructorInfo, AssertionChain.GetOrCreate());
		}

		public static MethodInfoAssertions Should([NotNull] this MethodInfo methodInfo)
		{
			return new MethodInfoAssertions(methodInfo, AssertionChain.GetOrCreate());
		}

		public static MethodInfoSelectorAssertions Should(this MethodInfoSelector methodSelector)
		{
			Guard.ThrowIfArgumentIsNull(methodSelector, "methodSelector");
			return new MethodInfoSelectorAssertions(AssertionChain.GetOrCreate(), methodSelector.ToArray());
		}

		public static PropertyInfoAssertions Should([NotNull] this PropertyInfo propertyInfo)
		{
			return new PropertyInfoAssertions(propertyInfo, AssertionChain.GetOrCreate());
		}

		public static PropertyInfoSelectorAssertions Should(this PropertyInfoSelector propertyInfoSelector)
		{
			Guard.ThrowIfArgumentIsNull(propertyInfoSelector, "propertyInfoSelector");
			return new PropertyInfoSelectorAssertions(AssertionChain.GetOrCreate(), propertyInfoSelector.ToArray());
		}

		public static ActionAssertions Should([NotNull] this Action action)
		{
			return new ActionAssertions(action, Extractor, AssertionChain.GetOrCreate());
		}

		public static NonGenericAsyncFunctionAssertions Should([NotNull] this Func<Task> action)
		{
			return new NonGenericAsyncFunctionAssertions(action, Extractor, AssertionChain.GetOrCreate());
		}

		public static GenericAsyncFunctionAssertions<T> Should<T>([NotNull] this Func<Task<T>> action)
		{
			return new GenericAsyncFunctionAssertions<T>(action, Extractor, AssertionChain.GetOrCreate());
		}

		public static FunctionAssertions<T> Should<T>([NotNull] this Func<T> func)
		{
			return new FunctionAssertions<T>(func, Extractor, AssertionChain.GetOrCreate());
		}

		public static TaskCompletionSourceAssertions<T> Should<T>(this TaskCompletionSource<T> tcs)
		{
			return new TaskCompletionSourceAssertions<T>(tcs, AssertionChain.GetOrCreate());
		}

		public static TTo As<TTo>(this object subject)
		{
			if (subject is TTo)
			{
				return (TTo)subject;
			}
			return default(TTo);
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TSubject, TAssertions>(this ReferenceTypeAssertions<TSubject, TAssertions> _) where TAssertions : ReferenceTypeAssertions<TSubject, TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TAssertions>(this BooleanAssertions<TAssertions> _) where TAssertions : BooleanAssertions<TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TAssertions>(this DateTimeAssertions<TAssertions> _) where TAssertions : DateTimeAssertions<TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TAssertions>(this DateTimeOffsetAssertions<TAssertions> _) where TAssertions : DateTimeOffsetAssertions<TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should(this ExecutionTimeAssertions _)
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TAssertions>(this GuidAssertions<TAssertions> _) where TAssertions : GuidAssertions<TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should(this MethodInfoSelectorAssertions _)
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TSubject, TAssertions>(this NumericAssertionsBase<TSubject, TSubject, TAssertions> _) where TSubject : struct, IComparable<TSubject> where TAssertions : NumericAssertions<TSubject, TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should(this PropertyInfoSelectorAssertions _)
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TAssertions>(this SimpleTimeSpanAssertions<TAssertions> _) where TAssertions : SimpleTimeSpanAssertions<TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should(this TaskCompletionSourceAssertionsBase _)
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should(this TypeSelectorAssertions _)
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TEnum, TAssertions>(this EnumAssertions<TEnum, TAssertions> _) where TEnum : struct, Enum where TAssertions : EnumAssertions<TEnum, TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TAssertions>(this DateTimeRangeAssertions<TAssertions> _) where TAssertions : DateTimeAssertions<TAssertions>
		{
			InvalidShouldCall();
		}

		[Obsolete("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'", true)]
		public static void Should<TAssertions>(this DateTimeOffsetRangeAssertions<TAssertions> _) where TAssertions : DateTimeOffsetAssertions<TAssertions>
		{
			InvalidShouldCall();
		}

		[DoesNotReturn]
		private static void InvalidShouldCall()
		{
			throw new InvalidOperationException("You are asserting the 'AndConstraint' itself. Remove the 'Should()' method directly following 'And'.");
		}
	}
}

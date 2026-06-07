using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gh
{
	public static class CommonExtensions
	{
		[CompilerGenerated]
		private sealed class _003CDistinctBy_003Ed__16<TSource, TKey> : IEnumerable<TSource>, IEnumerable, IEnumerator<TSource>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TSource _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<TSource> source;

			public IEnumerable<TSource> _003C_003E3__source;

			private Func<TSource, TKey> keySelector;

			public Func<TSource, TKey> _003C_003E3__keySelector;

			private HashSet<TKey> _003CseenKeys_003E5__2;

			private IEnumerator<TSource> _003C_003E7__wrap2;

			TSource IEnumerator<TSource>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(TSource);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDistinctBy_003Ed__16(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CFlatten_003Ed__62<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<IEnumerable<T>> enumeration;

			public IEnumerable<IEnumerable<T>> _003C_003E3__enumeration;

			private IEnumerator<IEnumerable<T>> _003C_003E7__wrap1;

			private IEnumerator<T> _003C_003E7__wrap2;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(T);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFlatten_003Ed__62(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CSelectManyNullSafe_003Ed__69<T, K> : IEnumerable<K>, IEnumerable, IEnumerator<K>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private K _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<T> list;

			public IEnumerable<T> _003C_003E3__list;

			private Func<T, IEnumerable<K>> selector;

			public Func<T, IEnumerable<K>> _003C_003E3__selector;

			private IEnumerator<T> _003C_003E7__wrap1;

			private IEnumerator<K> _003C_003E7__wrap2;

			K IEnumerator<K>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(K);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSelectManyNullSafe_003Ed__69(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<K> IEnumerable<K>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CToEnumerable_003Ed__56<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerator<T> enumerator;

			public IEnumerator<T> _003C_003E3__enumerator;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(T);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CToEnumerable_003Ed__56(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private const string EmailPattern = "^((?>[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+\\x20*|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\"\\x20*)*(?<angle><))?((?!\\.)(?>\\.?[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+)+|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\")@(((?!-)[a-zA-Z\\d\\-]+(?<!-)\\.)+[a-zA-Z]{2,}|\\[(((?(?<!\\[)\\.)(25[0-5]|2[0-4]\\d|[01]?\\d?\\d)){4}|[a-zA-Z\\d\\-]*[a-zA-Z\\d]:((?=[\\x01-\\x7f])[^\\\\\\[\\]]|\\\\[\\x01-\\x7f])+)\\])(?(angle)>)$";

		public static bool IsEqualToAny<T>(this T value, params T[] objects)
		{
			return false;
		}

		public static T CastToAnonymous<T>(this object value, T anonymousType)
		{
			return default(T);
		}

		public static IList<T> Clone<T>(this IList<T> list) where T : ICloneable
		{
			return null;
		}

		public static bool HasIndex<T>(this T[] arr, int index)
		{
			return false;
		}

		public static bool HasIndex(this IList list, int index)
		{
			return false;
		}

		public static T GetOrFallback<T>(this T[] arr, int index, T fallback)
		{
			return default(T);
		}

		public static T GetOrFallback<T>(this List<T> list, int index, T fallback)
		{
			return default(T);
		}

		public static int IndexOf<T>(this T[] array, T value)
		{
			return 0;
		}

		public static int FirstIndex<T>(this T[] array, Func<T, bool> predicate)
		{
			return 0;
		}

		public static List<T> Replace<T>(this List<T> list, T old, T @new)
		{
			return null;
		}

		public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> list, int amount)
		{
			return null;
		}

		public static int NonAllocatingCount<T>(this List<T> list, Predicate<T> predicate)
		{
			return 0;
		}

		public static bool CountIsAtLeast<T>(this IEnumerable<T> list, int min)
		{
			return false;
		}

		public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
		{
			return null;
		}

		public static void Swap(this IList list, int index1, int index2)
		{
		}

		public static T FromIndexOrLastOrDefault<T>(this IList<T> list, int index)
		{
			return default(T);
		}

		[IteratorStateMachine(typeof(_003CDistinctBy_003Ed__16<, >))]
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return null;
		}

		public static void AddIfNotPresent<T>(this IList enumerable, T value)
		{
		}

		public static K GetValueOrDefault<T, K>(this Dictionary<T, K> dict, T key)
		{
			return default(K);
		}

		public static void AddIfNotPresent<T, K>(this Dictionary<T, K> dict, T key, K value)
		{
		}

		public static string FormatWith(this string formatString, params object[] args)
		{
			return null;
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return false;
		}

		public static bool IsNullOrWhiteSpace(this string value)
		{
			return false;
		}

		public static string Capitalize(this string value)
		{
			return null;
		}

		public static string ReplaceFirst(this string value, string old, string @new)
		{
			return null;
		}

		public static string ReplaceLast(this string value, string old, string @new)
		{
			return null;
		}

		public static string Join(this IEnumerable<string> value, string seperator = "")
		{
			return null;
		}

		public static string Join(this IEnumerable<char> value, string seperator = "")
		{
			return null;
		}

		public static string Repeat(this string value, int count)
		{
			return null;
		}

		public static bool Contains(this string value, string toCheck, StringComparison comp)
		{
			return false;
		}

		public static int GetStableHashCode(this string str)
		{
			return 0;
		}

		public static string ExtractLeft(this string value, int startIndex, string delimiter)
		{
			return null;
		}

		public static string ExtractRight(this string value, int startIndex, string delimiter)
		{
			return null;
		}

		public static string[] Split(this string value, string separator)
		{
			return null;
		}

		public static string GeneralizeKey(this string key)
		{
			return null;
		}

		public static int GetWordCount(this string text)
		{
			return 0;
		}

		public static StringBuilder Reverse(this StringBuilder sb)
		{
			return null;
		}

		public static StringBuilderPool.DisposableStringBuilder Reverse(this StringBuilderPool.DisposableStringBuilder sb)
		{
			return null;
		}

		public static bool IsEmailValid(this string input)
		{
			return false;
		}

		public static StringBuilder Clear(this StringBuilder builder)
		{
			return null;
		}

		public static int IndexOf(this StringBuilder sb, string value, int startIndex, int maxSearchLength)
		{
			return 0;
		}

		public static int IndexOf(this StringBuilder sb, string value, int startIndex = 0)
		{
			return 0;
		}

		public static int IndexOf(this StringBuilderPool.DisposableStringBuilder sb, string value, int startIndex, int maxSearchLength)
		{
			return 0;
		}

		public static int IndexOf(this StringBuilderPool.DisposableStringBuilder sb, string value, int startIndex = 0)
		{
			return 0;
		}

		public static int LastIndexOf(this StringBuilder sb, string value, int? startIndex = null)
		{
			return 0;
		}

		public static int LastIndexOf(this StringBuilderPool.DisposableStringBuilder sb, string value, int? startIndex = null)
		{
			return 0;
		}

		public static StringBuilder ReplaceFirst(this StringBuilder sb, string value, string replaceValue)
		{
			return null;
		}

		public static StringBuilderPool.DisposableStringBuilder ReplaceFirst(this StringBuilderPool.DisposableStringBuilder sb, string value, string replaceValue)
		{
			return null;
		}

		public static string ExtractLeft(this StringBuilder value, int startIndex, string delimiter)
		{
			return null;
		}

		public static string ExtractRight(this StringBuilder value, int startIndex, string delimiter)
		{
			return null;
		}

		public static string ExtractToEndOfLine(this StringBuilder value, int startIndex)
		{
			return null;
		}

		public static string Substring(this StringBuilder sb, int startIndex, int length)
		{
			return null;
		}

		public static string Substring(this StringBuilderPool.DisposableStringBuilder sb, int startIndex, int length)
		{
			return null;
		}

		public static bool EndsWith(this StringBuilder sb, string text)
		{
			return false;
		}

		public static bool EndsWith(this StringBuilderPool.DisposableStringBuilder sb, string text)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CToEnumerable_003Ed__56<>))]
		public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
		{
			return null;
		}

		public static Tuple<List<T>, List<T>> Split<T>(this IEnumerable<T> enumerator, Func<T, bool> predicate)
		{
			return null;
		}

		public static bool AllSameValue<T, K>(this IEnumerable<T> list, Func<T, K> valueSelector)
		{
			return false;
		}

		public static IEnumerable<T> OrderByPositiveLargeNumbersThenByNegativeLargeNumbers<T>(this IEnumerable<T> values, Func<T, float> selector)
		{
			return null;
		}

		public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable)
		{
			return false;
		}

		public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CFlatten_003Ed__62<>))]
		public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> enumeration)
		{
			return null;
		}

		public static IEnumerable<T> ExcludeNulls<T>(this IEnumerable<T> list)
		{
			return null;
		}

		public static IEnumerable<T> ExceptItem<T>(this IEnumerable<T> list, T exclude)
		{
			return null;
		}

		public static IEnumerable<string> ExcludeEmptyStrings(this IEnumerable<string> list)
		{
			return null;
		}

		[Obsolete("Use normal foreach loop instead pls.")]
		public static void ForEach<T>(this IEnumerable<T> value, Action<T> action)
		{
		}

		public static IEnumerable<T> ToArrayDebug<T>(this IEnumerable<T> value)
		{
			return null;
		}

		public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSelectManyNullSafe_003Ed__69<, >))]
		public static IEnumerable<K> SelectManyNullSafe<T, K>(this IEnumerable<T> list, Func<T, IEnumerable<K>> selector)
		{
			return null;
		}

		public static decimal Clamp(this decimal value, decimal min, decimal max)
		{
			return default(decimal);
		}

		public static double Clamp(this double value, double min, double max)
		{
			return 0.0;
		}

		public static int Clamp(this int value, int min, int max)
		{
			return 0;
		}

		public static float Clamp(this float value, float min, float max)
		{
			return 0f;
		}

		public static int ClampToInt(this float value, float min, float max)
		{
			return 0;
		}

		public static long Clamp(this long value, long min, long max)
		{
			return 0L;
		}

		public static float ToHalfStep(this float value)
		{
			return 0f;
		}

		public static bool IsIntegerValue(this float number, float tolerance = 0.0001f)
		{
			return false;
		}

		public static int NextPowerOfTwo(this int value)
		{
			return 0;
		}

		public static bool IsInRange(this double value, double min, double max)
		{
			return false;
		}

		public static bool IsInRange(this float value, float min, float max)
		{
			return false;
		}

		public static bool IsInRange(this int value, int min, int max)
		{
			return false;
		}

		public static string ToStringWithSign(this float value, string format = null)
		{
			return null;
		}

		public static string ToStringWithSign(this int value, string format = null)
		{
			return null;
		}

		public static int ToPercentageChange(this float from, float to)
		{
			return 0;
		}

		public static int RoundToClosestInt(this float amount, int multipleOf)
		{
			return 0;
		}

		public static int RoundToClosestIntFive(this float amount)
		{
			return 0;
		}

		public static int RoundToClosestIntFive(this int amount)
		{
			return 0;
		}

		public static float ToFloorWithDecimals(this float value, int decimals)
		{
			return 0f;
		}

		public static float WeightedAverage<T>(this IEnumerable<T> items, Func<T, float> value, Func<T, float> weight)
		{
			return 0f;
		}

		public static float MapToRange(this float factor, int rangeStart, int rangeEnd)
		{
			return 0f;
		}

		public static float MapToRange(this float factor, float rangeStart, float rangeEnd)
		{
			return 0f;
		}

		public static float GetPositionOfValueInRange(this float value, float rangeStart, float rangeEnd)
		{
			return 0f;
		}

		public static void RaiseEvent(this EventHandler handler, object source)
		{
		}

		public static void RaiseEvent(this EventHandler handler, object source, EventArgs e)
		{
		}

		public static void RaiseEvent<TEventArgs>(this EventHandler<TEventArgs> handler, object source, TEventArgs e) where TEventArgs : EventArgs
		{
		}

		public static bool IsGenericList(this Type type)
		{
			return false;
		}

		public static bool IsArrayOf<T>(this Type type)
		{
			return false;
		}

		public static bool IsListOf<T>(this Type type)
		{
			return false;
		}

		public static bool IsDictionaryOf<TKey, TValue>(this Type type)
		{
			return false;
		}

		public static bool ImplementsInterface(this Type type, Type interfaceType)
		{
			return false;
		}

		public static T GetCustomAttribute<T>(this object obj, bool inherit) where T : Attribute
		{
			return null;
		}

		public static bool Is24Hrs(this CultureInfo cultureInfo)
		{
			return false;
		}
	}
}

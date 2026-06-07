using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ZLinq.Internal;
using ZLinq.Linq;

namespace ZLinq
{
	public static class ValueEnumerableExtensions
	{
		private const int StackallocCharBufferSizeLimit = 256;

		public static TSource Aggregate<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TSource, TSource> func) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(func, "func");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				if (span.Length == 0)
				{
					Throws.NoElements<TSource>();
				}
				TSource val2 = span[0];
				for (int i = 1; (uint)i < (uint)span.Length; i++)
				{
					val2 = func(val2, span[i]);
				}
				return val2;
			}
			if (!val.TryGetNext(out TSource current))
			{
				Throws.NoElements<TSource>();
			}
			TSource current2;
			while (val.TryGetNext(out current2))
			{
				current = func(current, current2);
			}
			return current;
		}

		public static TAccumulate Aggregate<TEnumerator, TSource, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(func, "func");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				TAccumulate val2 = seed;
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					val2 = func(val2, arg);
				}
				return val2;
			}
			TAccumulate val3 = seed;
			TSource current;
			while (val.TryGetNext(out current))
			{
				val3 = func(val3, current);
			}
			return val3;
		}

		public static TResult Aggregate<TEnumerator, TSource, TAccumulate, TResult>(this ValueEnumerable<TEnumerator, TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(func, "func");
			ArgumentNullException.ThrowIfNull(resultSelector, "resultSelector");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				TAccumulate val2 = seed;
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					val2 = func(val2, arg);
				}
				return resultSelector(val2);
			}
			TAccumulate val3 = seed;
			TSource current;
			while (val.TryGetNext(out current))
			{
				val3 = func(val3, current);
			}
			return resultSelector(val3);
		}

		public static ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>(new AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), seed, Throws.IfNull(func, "func"), null));
		}

		public static ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>(new AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), seed, Throws.IfNull(func, "func"), keyComparer));
		}

		public static ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>(new AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(seedSelector, "seedSelector"), Throws.IfNull(func, "func"), null));
		}

		public static ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>(new AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(seedSelector, "seedSelector"), Throws.IfNull(func, "func"), keyComparer));
		}

		public static bool All<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					if (!predicate(arg))
					{
						return false;
					}
				}
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (!predicate(current))
					{
						return false;
					}
				}
			}
			return true;
		}

		public static bool All<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate)
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TSource[] source2 = source.Enumerator.GetSource();
			if (source2.GetType() != typeof(TSource[]))
			{
				return All(source2, predicate);
			}
			ReadOnlySpan<TSource> readOnlySpan = source2;
			for (int i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
			{
				if (!predicate(readOnlySpan[i]))
				{
					return false;
				}
			}
			return true;
			[MethodImpl(MethodImplOptions.NoInlining)]
			static bool All(TSource[] array, Func<TSource, bool> func)
			{
				for (int j = 0; (uint)j < (uint)array.Length; j++)
				{
					if (!func(array[j]))
					{
						return false;
					}
				}
				return true;
			}
		}

		public static bool Any<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count))
			{
				return count > 0;
			}
			TSource current;
			return val.TryGetNext(out current);
		}

		public static bool Any<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					if (predicate(arg))
					{
						return true;
					}
				}
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (predicate(current))
					{
						return true;
					}
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Any<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate)
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TSource[] source2 = source.Enumerator.GetSource();
			if (source2.GetType() != typeof(TSource[]))
			{
				return Any(source2, predicate);
			}
			ReadOnlySpan<TSource> readOnlySpan = source2;
			for (int i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
			{
				if (predicate(readOnlySpan[i]))
				{
					return true;
				}
			}
			return false;
			[MethodImpl(MethodImplOptions.NoInlining)]
			static bool Any(TSource[] array, Func<TSource, bool> func)
			{
				for (int j = 0; (uint)j < (uint)array.Length; j++)
				{
					if (func(array[j]))
					{
						return true;
					}
				}
				return false;
			}
		}

		public static ValueEnumerable<Append<TEnumerator, TSource>, TSource> Append<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource element) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Append<TEnumerator, TSource>, TSource>(new Append<TEnumerator, TSource>(source.Enumerator, element));
		}

		public static float Average<TEnumerator>(this ValueEnumerable<TEnumerator, float> source) where TEnumerator : struct, IValueEnumerator<float>
		{
			using TEnumerator val = source.Enumerator;
			if (!val.TryGetNext(out var current))
			{
				Throws.NoElements();
			}
			double num = current;
			long num2 = 1L;
			while (val.TryGetNext(out current))
			{
				num += (double)current;
				num2++;
			}
			return (float)(num / (double)num2);
		}

		public static float? Average<TEnumerator>(this ValueEnumerable<TEnumerator, float?> source) where TEnumerator : struct, IValueEnumerator<float?>
		{
			using TEnumerator val = source.Enumerator;
			float? current;
			while (val.TryGetNext(out current))
			{
				if (!current.HasValue)
				{
					continue;
				}
				double num = current.GetValueOrDefault();
				long num2 = 1L;
				float? current2;
				while (val.TryGetNext(out current2))
				{
					if (current2.HasValue)
					{
						num += (double)current2.GetValueOrDefault();
						num2++;
					}
				}
				return (float)(num / (double)num2);
			}
			return null;
		}

		public static float Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, float> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Average();
		}

		public static float? Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, float?> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Average();
		}

		public static decimal Average<TEnumerator>(this ValueEnumerable<TEnumerator, decimal> source) where TEnumerator : struct, IValueEnumerator<decimal>
		{
			using TEnumerator val = source.Enumerator;
			if (!val.TryGetNext(out var current))
			{
				Throws.NoElements();
			}
			decimal num = current;
			long num2 = 1L;
			while (val.TryGetNext(out current))
			{
				num += current;
				num2++;
			}
			return num / (decimal)num2;
		}

		public static decimal? Average<TEnumerator>(this ValueEnumerable<TEnumerator, decimal?> source) where TEnumerator : struct, IValueEnumerator<decimal?>
		{
			using TEnumerator val = source.Enumerator;
			decimal? current;
			while (val.TryGetNext(out current))
			{
				if (!current.HasValue)
				{
					continue;
				}
				decimal valueOrDefault = current.GetValueOrDefault();
				long num = 1L;
				decimal? current2;
				while (val.TryGetNext(out current2))
				{
					if (current2.HasValue)
					{
						valueOrDefault += current2.GetValueOrDefault();
						num++;
					}
				}
				return valueOrDefault / (decimal)num;
			}
			return null;
		}

		public static decimal Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, decimal> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Average();
		}

		public static decimal? Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, decimal?> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Average();
		}

		public static double Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : struct
		{
			if (typeof(TSource) == typeof(float))
			{
				using (TEnumerator val = source.Enumerator)
				{
					if (!val.TryGetNext(out var current))
					{
						Throws.NoElements();
					}
					double num = Unsafe.As<TSource, float>(ref current);
					long num2 = 1L;
					while (val.TryGetNext(out current))
					{
						num += (double)Unsafe.As<TSource, float>(ref current);
						num2++;
					}
					return num / (double)num2;
				}
			}
			if (typeof(TSource) == typeof(byte))
			{
				using (TEnumerator val2 = source.Enumerator)
				{
					if (!val2.TryGetNext(out var current2))
					{
						Throws.NoElements();
					}
					byte b = Unsafe.As<TSource, byte>(ref current2);
					long num3 = 1L;
					while (val2.TryGetNext(out current2))
					{
						b = checked((byte)(b + Unsafe.As<TSource, byte>(ref current2)));
						num3++;
					}
					return (double)(int)b / (double)num3;
				}
			}
			if (typeof(TSource) == typeof(sbyte))
			{
				using (TEnumerator val3 = source.Enumerator)
				{
					if (!val3.TryGetNext(out var current3))
					{
						Throws.NoElements();
					}
					sbyte b2 = Unsafe.As<TSource, sbyte>(ref current3);
					long num4 = 1L;
					while (val3.TryGetNext(out current3))
					{
						b2 = checked((sbyte)(b2 + Unsafe.As<TSource, sbyte>(ref current3)));
						num4++;
					}
					return (double)b2 / (double)num4;
				}
			}
			if (typeof(TSource) == typeof(short))
			{
				using (TEnumerator val4 = source.Enumerator)
				{
					if (!val4.TryGetNext(out var current4))
					{
						Throws.NoElements();
					}
					short num5 = Unsafe.As<TSource, short>(ref current4);
					long num6 = 1L;
					while (val4.TryGetNext(out current4))
					{
						num5 = checked((short)(num5 + Unsafe.As<TSource, short>(ref current4)));
						num6++;
					}
					return (double)num5 / (double)num6;
				}
			}
			if (typeof(TSource) == typeof(ushort))
			{
				using (TEnumerator val5 = source.Enumerator)
				{
					if (!val5.TryGetNext(out var current5))
					{
						Throws.NoElements();
					}
					ushort num7 = Unsafe.As<TSource, ushort>(ref current5);
					long num8 = 1L;
					while (val5.TryGetNext(out current5))
					{
						num7 = checked((ushort)(num7 + Unsafe.As<TSource, ushort>(ref current5)));
						num8++;
					}
					return (double)(int)num7 / (double)num8;
				}
			}
			if (typeof(TSource) == typeof(int))
			{
				using (TEnumerator val6 = source.Enumerator)
				{
					if (!val6.TryGetNext(out var current6))
					{
						Throws.NoElements();
					}
					long num9 = Unsafe.As<TSource, int>(ref current6);
					long num10 = 1L;
					while (val6.TryGetNext(out current6))
					{
						num9 = checked(num9 + Unsafe.As<TSource, int>(ref current6));
						num10++;
					}
					return (double)num9 / (double)num10;
				}
			}
			if (typeof(TSource) == typeof(uint))
			{
				using (TEnumerator val7 = source.Enumerator)
				{
					if (!val7.TryGetNext(out var current7))
					{
						Throws.NoElements();
					}
					uint num11 = Unsafe.As<TSource, uint>(ref current7);
					long num12 = 1L;
					while (val7.TryGetNext(out current7))
					{
						num11 = checked(num11 + Unsafe.As<TSource, uint>(ref current7));
						num12++;
					}
					return (double)num11 / (double)num12;
				}
			}
			if (typeof(TSource) == typeof(long))
			{
				using (TEnumerator val8 = source.Enumerator)
				{
					if (!val8.TryGetNext(out var current8))
					{
						Throws.NoElements();
					}
					long num13 = Unsafe.As<TSource, long>(ref current8);
					long num14 = 1L;
					while (val8.TryGetNext(out current8))
					{
						num13 = checked(num13 + Unsafe.As<TSource, long>(ref current8));
						num14++;
					}
					return (double)num13 / (double)num14;
				}
			}
			if (typeof(TSource) == typeof(ulong))
			{
				using (TEnumerator val9 = source.Enumerator)
				{
					if (!val9.TryGetNext(out var current9))
					{
						Throws.NoElements();
					}
					ulong num15 = Unsafe.As<TSource, ulong>(ref current9);
					long num16 = 1L;
					while (val9.TryGetNext(out current9))
					{
						num15 = checked(num15 + Unsafe.As<TSource, ulong>(ref current9));
						num16++;
					}
					return (double)num15 / (double)num16;
				}
			}
			if (typeof(TSource) == typeof(double))
			{
				using (TEnumerator val10 = source.Enumerator)
				{
					if (!val10.TryGetNext(out var current10))
					{
						Throws.NoElements();
					}
					double num17 = Unsafe.As<TSource, double>(ref current10);
					long num18 = 1L;
					while (val10.TryGetNext(out current10))
					{
						num17 += Unsafe.As<TSource, double>(ref current10);
						num18++;
					}
					return num17 / (double)num18;
				}
			}
			if (typeof(TSource) == typeof(decimal))
			{
				using (TEnumerator val11 = source.Enumerator)
				{
					if (!val11.TryGetNext(out var current11))
					{
						Throws.NoElements();
					}
					decimal num19 = Unsafe.As<TSource, decimal>(ref current11);
					long num20 = 1L;
					while (val11.TryGetNext(out current11))
					{
						num19 += Unsafe.As<TSource, decimal>(ref current11);
						num20++;
					}
					return (double)num19 / (double)num20;
				}
			}
			if (typeof(TSource) == typeof(IntPtr))
			{
				using (TEnumerator val12 = source.Enumerator)
				{
					if (!val12.TryGetNext(out var current12))
					{
						Throws.NoElements();
					}
					nint num21 = Unsafe.As<TSource, IntPtr>(ref current12);
					long num22 = 1L;
					while (val12.TryGetNext(out current12))
					{
						checked
						{
							num21 += unchecked((nint)Unsafe.As<TSource, IntPtr>(ref current12));
						}
						num22++;
					}
					return (double)num21 / (double)num22;
				}
			}
			if (typeof(TSource) == typeof(UIntPtr))
			{
				using (TEnumerator val13 = source.Enumerator)
				{
					if (!val13.TryGetNext(out var current13))
					{
						Throws.NoElements();
					}
					nuint num23 = Unsafe.As<TSource, UIntPtr>(ref current13);
					long num24 = 1L;
					while (val13.TryGetNext(out current13))
					{
						checked
						{
							num23 += unchecked((nuint)Unsafe.As<TSource, UIntPtr>(ref current13));
						}
						num24++;
					}
					return (double)num23 / (double)num24;
				}
			}
			Throws.NotSupportedType(typeof(TSource));
			return 0.0;
		}

		public static double? Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource?> source) where TEnumerator : struct, IValueEnumerator<TSource?> where TSource : struct
		{
			if (typeof(TSource) == typeof(float))
			{
				using (TEnumerator val = source.Enumerator)
				{
					TSource? current;
					while (val.TryGetNext(out current))
					{
						if (current.HasValue)
						{
							TSource source2 = current.GetValueOrDefault();
							double num = Unsafe.As<TSource, float>(ref source2);
							long num2 = 1L;
							TSource? current2;
							while (val.TryGetNext(out current2))
							{
								if (current2.HasValue)
								{
									TSource source3 = current2.GetValueOrDefault();
									num += (double)Unsafe.As<TSource, float>(ref source3);
									num2++;
								}
							}
							return num / (double)num2;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(byte))
			{
				using (TEnumerator val2 = source.Enumerator)
				{
					TSource? current3;
					while (val2.TryGetNext(out current3))
					{
						if (current3.HasValue)
						{
							TSource source4 = current3.GetValueOrDefault();
							byte b = Unsafe.As<TSource, byte>(ref source4);
							long num3 = 1L;
							TSource? current4;
							while (val2.TryGetNext(out current4))
							{
								if (current4.HasValue)
								{
									TSource source5 = current4.GetValueOrDefault();
									b = checked((byte)(b + Unsafe.As<TSource, byte>(ref source5)));
									num3++;
								}
							}
							return (double)(int)b / (double)num3;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(sbyte))
			{
				using (TEnumerator val3 = source.Enumerator)
				{
					TSource? current5;
					while (val3.TryGetNext(out current5))
					{
						if (current5.HasValue)
						{
							TSource source6 = current5.GetValueOrDefault();
							sbyte b2 = Unsafe.As<TSource, sbyte>(ref source6);
							long num4 = 1L;
							TSource? current6;
							while (val3.TryGetNext(out current6))
							{
								if (current6.HasValue)
								{
									TSource source7 = current6.GetValueOrDefault();
									b2 = checked((sbyte)(b2 + Unsafe.As<TSource, sbyte>(ref source7)));
									num4++;
								}
							}
							return (double)b2 / (double)num4;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(short))
			{
				using (TEnumerator val4 = source.Enumerator)
				{
					TSource? current7;
					while (val4.TryGetNext(out current7))
					{
						if (current7.HasValue)
						{
							TSource source8 = current7.GetValueOrDefault();
							short num5 = Unsafe.As<TSource, short>(ref source8);
							long num6 = 1L;
							TSource? current8;
							while (val4.TryGetNext(out current8))
							{
								if (current8.HasValue)
								{
									TSource source9 = current8.GetValueOrDefault();
									num5 = checked((short)(num5 + Unsafe.As<TSource, short>(ref source9)));
									num6++;
								}
							}
							return (double)num5 / (double)num6;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(ushort))
			{
				using (TEnumerator val5 = source.Enumerator)
				{
					TSource? current9;
					while (val5.TryGetNext(out current9))
					{
						if (current9.HasValue)
						{
							TSource source10 = current9.GetValueOrDefault();
							ushort num7 = Unsafe.As<TSource, ushort>(ref source10);
							long num8 = 1L;
							TSource? current10;
							while (val5.TryGetNext(out current10))
							{
								if (current10.HasValue)
								{
									TSource source11 = current10.GetValueOrDefault();
									num7 = checked((ushort)(num7 + Unsafe.As<TSource, ushort>(ref source11)));
									num8++;
								}
							}
							return (double)(int)num7 / (double)num8;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(int))
			{
				using (TEnumerator val6 = source.Enumerator)
				{
					TSource? current11;
					while (val6.TryGetNext(out current11))
					{
						if (current11.HasValue)
						{
							TSource source12 = current11.GetValueOrDefault();
							long num9 = Unsafe.As<TSource, int>(ref source12);
							long num10 = 1L;
							TSource? current12;
							while (val6.TryGetNext(out current12))
							{
								if (current12.HasValue)
								{
									TSource source13 = current12.GetValueOrDefault();
									num9 = checked(num9 + Unsafe.As<TSource, int>(ref source13));
									num10++;
								}
							}
							return (double)num9 / (double)num10;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(uint))
			{
				using (TEnumerator val7 = source.Enumerator)
				{
					TSource? current13;
					while (val7.TryGetNext(out current13))
					{
						if (current13.HasValue)
						{
							TSource source14 = current13.GetValueOrDefault();
							uint num11 = Unsafe.As<TSource, uint>(ref source14);
							long num12 = 1L;
							TSource? current14;
							while (val7.TryGetNext(out current14))
							{
								if (current14.HasValue)
								{
									TSource source15 = current14.GetValueOrDefault();
									num11 = checked(num11 + Unsafe.As<TSource, uint>(ref source15));
									num12++;
								}
							}
							return (double)num11 / (double)num12;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(long))
			{
				using (TEnumerator val8 = source.Enumerator)
				{
					TSource? current15;
					while (val8.TryGetNext(out current15))
					{
						if (current15.HasValue)
						{
							TSource source16 = current15.GetValueOrDefault();
							long num13 = Unsafe.As<TSource, long>(ref source16);
							long num14 = 1L;
							TSource? current16;
							while (val8.TryGetNext(out current16))
							{
								if (current16.HasValue)
								{
									TSource source17 = current16.GetValueOrDefault();
									num13 = checked(num13 + Unsafe.As<TSource, long>(ref source17));
									num14++;
								}
							}
							return (double)num13 / (double)num14;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(ulong))
			{
				using (TEnumerator val9 = source.Enumerator)
				{
					TSource? current17;
					while (val9.TryGetNext(out current17))
					{
						if (current17.HasValue)
						{
							TSource source18 = current17.GetValueOrDefault();
							ulong num15 = Unsafe.As<TSource, ulong>(ref source18);
							long num16 = 1L;
							TSource? current18;
							while (val9.TryGetNext(out current18))
							{
								if (current18.HasValue)
								{
									TSource source19 = current18.GetValueOrDefault();
									num15 = checked(num15 + Unsafe.As<TSource, ulong>(ref source19));
									num16++;
								}
							}
							return (double)num15 / (double)num16;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(double))
			{
				using (TEnumerator val10 = source.Enumerator)
				{
					TSource? current19;
					while (val10.TryGetNext(out current19))
					{
						if (current19.HasValue)
						{
							TSource source20 = current19.GetValueOrDefault();
							double num17 = Unsafe.As<TSource, double>(ref source20);
							long num18 = 1L;
							TSource? current20;
							while (val10.TryGetNext(out current20))
							{
								if (current20.HasValue)
								{
									TSource source21 = current20.GetValueOrDefault();
									num17 += Unsafe.As<TSource, double>(ref source21);
									num18++;
								}
							}
							return num17 / (double)num18;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(decimal))
			{
				using (TEnumerator val11 = source.Enumerator)
				{
					TSource? current21;
					while (val11.TryGetNext(out current21))
					{
						if (current21.HasValue)
						{
							TSource source22 = current21.GetValueOrDefault();
							decimal num19 = Unsafe.As<TSource, decimal>(ref source22);
							long num20 = 1L;
							TSource? current22;
							while (val11.TryGetNext(out current22))
							{
								if (current22.HasValue)
								{
									TSource source23 = current22.GetValueOrDefault();
									num19 += Unsafe.As<TSource, decimal>(ref source23);
									num20++;
								}
							}
							return (double)num19 / (double)num20;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(IntPtr))
			{
				using (TEnumerator val12 = source.Enumerator)
				{
					TSource? current23;
					while (val12.TryGetNext(out current23))
					{
						if (current23.HasValue)
						{
							TSource source24 = current23.GetValueOrDefault();
							nint num21 = Unsafe.As<TSource, IntPtr>(ref source24);
							long num22 = 1L;
							TSource? current24;
							while (val12.TryGetNext(out current24))
							{
								if (current24.HasValue)
								{
									TSource source25 = current24.GetValueOrDefault();
									checked
									{
										num21 += unchecked((nint)Unsafe.As<TSource, IntPtr>(ref source25));
									}
									num22++;
								}
							}
							return (double)num21 / (double)num22;
						}
					}
					return null;
				}
			}
			if (typeof(TSource) == typeof(UIntPtr))
			{
				using (TEnumerator val13 = source.Enumerator)
				{
					TSource? current25;
					while (val13.TryGetNext(out current25))
					{
						if (current25.HasValue)
						{
							TSource source26 = current25.GetValueOrDefault();
							nuint num23 = Unsafe.As<TSource, UIntPtr>(ref source26);
							long num24 = 1L;
							TSource? current26;
							while (val13.TryGetNext(out current26))
							{
								if (current26.HasValue)
								{
									TSource source27 = current26.GetValueOrDefault();
									checked
									{
										num23 += unchecked((nuint)Unsafe.As<TSource, UIntPtr>(ref source27));
									}
									num24++;
								}
							}
							return (double)num23 / (double)num24;
						}
					}
					return null;
				}
			}
			Throws.NotSupportedType(typeof(TSource));
			return null;
		}

		public static double Average<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Average();
		}

		public static double? Average<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult?> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Average();
		}

		public static ValueEnumerable<Chunk<TEnumerator, TSource>, TSource[]> Chunk<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int size) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (size < 1)
			{
				Throws.ArgumentOutOfRange("size");
			}
			size = Math.Min(size, 2147483591);
			return new ValueEnumerable<Chunk<TEnumerator, TSource>, TSource[]>(new Chunk<TEnumerator, TSource>(source.Enumerator, size));
		}

		public static ValueEnumerable<Concat<TEnumerator1, TEnumerator2, TSource>, TSource> Concat<TEnumerator1, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator1, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator1 : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Concat<TEnumerator1, TEnumerator2, TSource>, TSource>(new Concat<TEnumerator1, TEnumerator2, TSource>(source.Enumerator, second.Enumerator));
		}

		public static ValueEnumerable<Concat<TEnumerator1, FromEnumerable<TSource>, TSource>, TSource> Concat<TEnumerator1, TSource>(this ValueEnumerable<TEnumerator1, TSource> source, IEnumerable<TSource> second) where TEnumerator1 : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(second, "second");
			return source.Concat(second.AsValueEnumerable());
		}

		public static bool Contains<TSource>(this ValueEnumerable<FromEnumerable<TSource>, TSource> source, TSource value)
		{
			if (source.Enumerator.GetSource() is ICollection<TSource> collection)
			{
				return collection.Contains(value);
			}
			return ContainsCore(ref source, value);
		}

		public static bool Contains<TSource>(this ValueEnumerable<FromHashSet<TSource>, TSource> source, TSource value)
		{
			return source.Enumerator.GetSource().Contains(value);
		}

		public static bool Contains<TSource>(this ValueEnumerable<FromSortedSet<TSource>, TSource> source, TSource value)
		{
			return source.Enumerator.GetSource().Contains(value);
		}

		public static bool Contains<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return ContainsCore(ref source, value);
		}

		private static bool ContainsCore<TEnumerator, TSource>(ref ValueEnumerable<TEnumerator, TSource> source, TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource x = readOnlySpan[i];
					if (EqualityComparer<TSource>.Default.Equals(x, value))
					{
						return true;
					}
				}
				return false;
			}
			TSource current;
			while (val.TryGetNext(out current))
			{
				if (EqualityComparer<TSource>.Default.Equals(current, value))
				{
					return true;
				}
			}
			return false;
		}

		public static bool Contains<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource value, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (comparer == null)
			{
				comparer = EqualityComparer<TSource>.Default;
			}
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource x = readOnlySpan[i];
					if (comparer.Equals(x, value))
					{
						return true;
					}
				}
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (comparer.Equals(current, value))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static int CopyTo<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Span<TSource> destination) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count) && val.TryCopyTo(destination, 0))
			{
				return Math.Min(count, destination.Length);
			}
			int num = 0;
			TSource current;
			while (val.TryGetNext(out current))
			{
				destination[num] = current;
				num++;
				if (num == destination.Length)
				{
					return num;
				}
			}
			return num;
		}

		public static void CopyTo<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, List<TSource> list) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(list, "list");
			list.Clear();
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count))
			{
				if (list.Capacity < count)
				{
					list.Capacity = count;
				}
				list.UnsafeSetCount(count);
				Span<TSource> destination = list.AsSpan();
				if (!val.TryCopyTo(destination, 0))
				{
					int num = 0;
					TSource current;
					while (val.TryGetNext(out current))
					{
						destination[num] = current;
						num++;
					}
				}
			}
			else
			{
				TSource current2;
				while (val.TryGetNext(out current2))
				{
					list.Add(current2);
				}
			}
		}

		public static int Count<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count))
			{
				return count;
			}
			count = 0;
			TSource current;
			while (val.TryGetNext(out current))
			{
				count = checked(count + 1);
			}
			return count;
		}

		public static int Count<TEnumerator, TSource>(this ValueEnumerable<Where<TEnumerator, TSource>, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator.GetSource();
			Func<TSource, bool> predicate = source.Enumerator.Predicate;
			int num = 0;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				for (int i = 0; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						num++;
					}
				}
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (predicate(current))
					{
						num = checked(num + 1);
					}
				}
			}
			return num;
		}

		public static int Count<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source)
		{
			TSource[] source2 = source.Enumerator.GetSource();
			Func<TSource, bool> predicate = source.Enumerator.Predicate;
			ReadOnlySpan<TSource> readOnlySpan = source2;
			int num = 0;
			for (int i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
			{
				if (predicate(readOnlySpan[i]))
				{
					num++;
				}
			}
			return num;
		}

		public static int Count<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source)
		{
			List<TSource> source2 = source.Enumerator.GetSource();
			Func<TSource, bool> predicate = source.Enumerator.Predicate;
			Span<TSource> span = source2.AsSpan();
			int num = 0;
			for (int i = 0; (uint)i < (uint)span.Length; i++)
			{
				if (predicate(span[i]))
				{
					num++;
				}
			}
			return num;
		}

		public static int Count<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			using TEnumerator val = source.Enumerator;
			int num = 0;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				for (int i = 0; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						num++;
					}
				}
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (predicate(current))
					{
						num = checked(num + 1);
					}
				}
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate)
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TSource[] source2 = source.Enumerator.GetSource();
			if (source2.GetType() != typeof(TSource[]))
			{
				return Count(source2, predicate);
			}
			int num = 0;
			ReadOnlySpan<TSource> readOnlySpan = source2;
			for (int i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
			{
				if (predicate(readOnlySpan[i]))
				{
					num++;
				}
			}
			return num;
			[MethodImpl(MethodImplOptions.NoInlining)]
			static int Count(TSource[] array, Func<TSource, bool> func)
			{
				int num2 = 0;
				for (int j = 0; (uint)j < (uint)array.Length; j++)
				{
					if (func(array[j]))
					{
						num2++;
					}
				}
				return num2;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, Func<TSource, bool> predicate)
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			List<TSource> source2 = source.Enumerator.GetSource();
			int num = 0;
			Span<TSource> span = source2.AsSpan();
			for (int i = 0; (uint)i < (uint)span.Length; i++)
			{
				if (predicate(span[i]))
				{
					num++;
				}
			}
			return num;
		}

		public static ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>> CountBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>>(new CountBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>> CountBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? keyComparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>>(new CountBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), keyComparer));
		}

		public static ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource> DefaultIfEmpty<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource>(new DefaultIfEmpty<TEnumerator, TSource>(source.Enumerator, default(TSource)));
		}

		public static ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource> DefaultIfEmpty<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource>(new DefaultIfEmpty<TEnumerator, TSource>(source.Enumerator, defaultValue));
		}

		public static ValueEnumerable<Distinct<TEnumerator, TSource>, TSource> Distinct<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Distinct<TEnumerator, TSource>, TSource>(new Distinct<TEnumerator, TSource>(source.Enumerator, null));
		}

		public static ValueEnumerable<Distinct<TEnumerator, TSource>, TSource> Distinct<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Distinct<TEnumerator, TSource>, TSource>(new Distinct<TEnumerator, TSource>(source.Enumerator, comparer));
		}

		public static ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource> DistinctBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource>(new DistinctBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource> DistinctBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource>(new DistinctBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static TSource ElementAt<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int index) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetElementAt<TEnumerator, TSource>(ref source2, index, out value) ? value : Throws.ArgumentOutOfRange<TSource>("index");
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource ElementAt<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Index index) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetElementAt<TEnumerator, TSource>(ref source2, index, out value) ? value : Throws.ArgumentOutOfRange<TSource>("index");
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? ElementAtOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int index) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (index < 0)
			{
				return default(TSource);
			}
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetElementAt<TEnumerator, TSource>(ref source2, index, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? ElementAtOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Index index) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetElementAt<TEnumerator, TSource>(ref source2, index, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		private static bool TryGetElementAt<TEnumerator, TSource>(ref TEnumerator source, Index index, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TSource reference = default(TSource);
			if (source.TryCopyTo(SingleSpan.Create(ref reference), index))
			{
				value = reference;
				return true;
			}
			if (EnumeratorHelper.TryConsumeGetAt<TEnumerator, TSource>(ref source, index, out reference))
			{
				value = reference;
				return true;
			}
			value = default(TSource);
			return false;
		}

		public static ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource> Except<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource>(new Except<TEnumerator, TEnumerator2, TSource>(source.Enumerator, second, null));
		}

		public static ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource> Except<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource>(new Except<TEnumerator, TEnumerator2, TSource>(source.Enumerator, second, comparer));
		}

		public static ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Except<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>(new Except<TEnumerator, FromEnumerable<TSource>, TSource>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), null));
		}

		public static ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Except<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>(new Except<TEnumerator, FromEnumerable<TSource>, TSource>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), comparer));
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey>
		{
			return new ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>(new ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>(source.Enumerator, second, Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey>
		{
			return new ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>(new ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>(source.Enumerator, second, Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> ExceptBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>(new ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> ExceptBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>(new ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static TSource First<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetFirst<TEnumerator, TSource>(ref source2, out value) ? value : Throws.NoElements<TSource>();
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource First<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetFirst(ref source2, predicate, out value) ? value : Throws.NoMatch<TSource>();
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetFirst<TEnumerator, TSource>(ref source2, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return (TSource)(TryGetFirst<TEnumerator, TSource>(ref source2, out value) ? ((object)value) : ((object)defaultValue));
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetFirst(ref source2, predicate, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return (TSource)(TryGetFirst(ref source2, predicate, out value) ? ((object)value) : ((object)defaultValue));
			}
			finally
			{
				source2.Dispose();
			}
		}

		private static bool TryGetFirst<TEnumerator, TSource>(ref TEnumerator source, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TSource reference = default(TSource);
			if (source.TryCopyTo(SingleSpan.Create(ref reference), 0))
			{
				value = reference;
				return true;
			}
			if (EnumeratorHelper.TryConsumeGetAt<TEnumerator, TSource>(ref source, 0, out reference))
			{
				value = reference;
				return true;
			}
			value = default(TSource);
			return false;
		}

		private static bool TryGetFirst<TEnumerator, TSource>(ref TEnumerator source, Func<TSource, bool> predicate, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val = readOnlySpan[i];
					if (predicate(val))
					{
						value = val;
						return true;
					}
				}
				value = default(TSource);
				return false;
			}
			TSource current;
			while (source.TryGetNext(out current))
			{
				if (predicate(current))
				{
					value = current;
					return true;
				}
			}
			value = default(TSource);
			return false;
		}

		public static ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>> GroupBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>>(new GroupBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>> GroupBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>>(new GroupBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>> GroupBy<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>>(new GroupBy2<TEnumerator, TSource, TKey, TElement>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(elementSelector, "elementSelector"), null));
		}

		public static ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>> GroupBy<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>>(new GroupBy2<TEnumerator, TSource, TKey, TElement>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(elementSelector, "elementSelector"), comparer));
		}

		public static ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult>(new GroupBy3<TEnumerator, TSource, TKey, TResult>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult>(new GroupBy3<TEnumerator, TSource, TKey, TResult>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TElement, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult>(new GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(elementSelector, "elementSelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TElement, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult>(new GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), Throws.IfNull(elementSelector, "elementSelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<Index<TEnumerator, TSource>, (int Index, TSource Item)> Index<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Index<TEnumerator, TSource>, (int, TSource)>(new Index<TEnumerator, TSource>(source.Enumerator));
		}

		public static ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource> Intersect<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource>(new Intersect<TEnumerator, TEnumerator2, TSource>(source.Enumerator, second, null));
		}

		public static ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource> Intersect<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource>(new Intersect<TEnumerator, TEnumerator2, TSource>(source.Enumerator, second, comparer));
		}

		public static ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Intersect<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>(new Intersect<TEnumerator, FromEnumerable<TSource>, TSource>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), null));
		}

		public static ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Intersect<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>(new Intersect<TEnumerator, FromEnumerable<TSource>, TSource>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), comparer));
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey>
		{
			return new ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>(new IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>(source.Enumerator, second, Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey>
		{
			return new ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>(new IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>(source.Enumerator, second, Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> IntersectBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>(new IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> IntersectBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>(new IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable(), Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		private static string FastAllocateString(int length)
		{
			return new string('\0', length);
		}

		public static string JoinToString<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, string separator) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, char separator) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ReadOnlySpan<char> separator) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			Span<char> initialBuffer;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				if (typeof(TSource) == typeof(string))
				{
					return JoinToString(MemoryMarshal.CreateReadOnlySpan(ref Unsafe.As<TSource, string>(ref MemoryMarshal.GetReference(span)), span.Length), separator);
				}
				if (span.Length == 0)
				{
					return "";
				}
				if (span.Length == 1)
				{
					return span[0].ToString() ?? "";
				}
				initialBuffer = stackalloc char[256];
				ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
				if (separator.Length == 0)
				{
					for (int i = 0; (uint)i < (uint)span.Length; i++)
					{
						valueStringBuilder.Append(span[i]);
					}
				}
				else if (separator.Length == 1)
				{
					char value = separator[0];
					valueStringBuilder.Append(span[0]);
					for (int j = 1; (uint)j < (uint)span.Length; j++)
					{
						valueStringBuilder.Append(value);
						valueStringBuilder.Append(span[j]);
					}
				}
				else
				{
					valueStringBuilder.Append(span[0]);
					for (int k = 1; (uint)k < (uint)span.Length; k++)
					{
						valueStringBuilder.Append(separator);
						valueStringBuilder.Append(span[k]);
					}
				}
				return valueStringBuilder.ToStringAndClear();
			}
			if (!val.TryGetNext(out TSource current))
			{
				return "";
			}
			if (!val.TryGetNext(out TSource current2))
			{
				return current.ToString() ?? "";
			}
			initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder2 = new ValueStringBuilder(initialBuffer);
			if (separator.Length == 0)
			{
				valueStringBuilder2.Append(current);
				valueStringBuilder2.Append(current2);
				TSource current3;
				while (val.TryGetNext(out current3))
				{
					valueStringBuilder2.Append(current3);
				}
			}
			else if (separator.Length == 1)
			{
				char value2 = separator[0];
				valueStringBuilder2.Append(current);
				valueStringBuilder2.Append(value2);
				valueStringBuilder2.Append(current2);
				TSource current4;
				while (val.TryGetNext(out current4))
				{
					valueStringBuilder2.Append(value2);
					valueStringBuilder2.Append(current4);
				}
			}
			else
			{
				valueStringBuilder2.Append(current);
				valueStringBuilder2.Append(separator);
				valueStringBuilder2.Append(current2);
				TSource current5;
				while (val.TryGetNext(out current5))
				{
					valueStringBuilder2.Append(separator);
					valueStringBuilder2.Append(current5);
				}
			}
			return valueStringBuilder2.ToStringAndClear();
		}

		private unsafe static string JoinToString(ReadOnlySpan<string> source, ReadOnlySpan<char> separator)
		{
			if (source.Length == 0)
			{
				return "";
			}
			if (source.Length == 1)
			{
				return source[0];
			}
			int num = 0;
			for (int i = 0; (uint)i < (uint)source.Length; i++)
			{
				num += source[i]?.Length ?? 0;
			}
			num += (source.Length - 1) * separator.Length;
			string text = FastAllocateString(num);
			fixed (char* pointer = text.AsSpan())
			{
				Span<char> destination = new Span<char>(pointer, num);
				source[0]?.CopyTo(destination);
				destination = destination.Slice(source[0]?.Length ?? 0);
				if (separator.Length == 0)
				{
					for (int j = 1; (uint)j < (uint)source.Length; j++)
					{
						source[j]?.CopyTo(destination);
						destination = destination.Slice(source[j]?.Length ?? 0);
					}
				}
				else if (separator.Length == 1)
				{
					char c = separator[0];
					for (int k = 1; (uint)k < (uint)source.Length; k++)
					{
						destination[0] = c;
						source[k]?.CopyTo(destination.Slice(1));
						destination = destination.Slice((source[k]?.Length ?? 0) + 1);
					}
				}
				else
				{
					for (int l = 1; (uint)l < (uint)source.Length; l++)
					{
						separator.CopyTo(destination);
						destination = destination.Slice(separator.Length);
						source[l]?.CopyTo(destination);
						destination = destination.Slice(source[l]?.Length ?? 0);
					}
				}
			}
			return text;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			TSource[] source2 = source.Enumerator.GetSource();
			if (typeof(TSource) == typeof(string))
			{
				return JoinToString(Unsafe.As<TSource[], string[]>(ref source2), separator);
			}
			if (source2.Length == 0)
			{
				return "";
			}
			if (source2.Length == 1)
			{
				return source2[0].ToString() ?? "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			if (separator.Length == 0)
			{
				for (int i = 0; (uint)i < (uint)source2.Length; i++)
				{
					valueStringBuilder.Append(source2[i]);
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				valueStringBuilder.Append(source2[0]);
				for (int j = 1; (uint)j < (uint)source2.Length; j++)
				{
					valueStringBuilder.Append(value);
					valueStringBuilder.Append(source2[j]);
				}
			}
			else
			{
				valueStringBuilder.Append(source2[0]);
				for (int k = 1; (uint)k < (uint)source2.Length; k++)
				{
					valueStringBuilder.Append(separator);
					valueStringBuilder.Append(source2[k]);
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			List<TSource> source2 = source.Enumerator.GetSource();
			if (typeof(TSource) == typeof(string))
			{
				return JoinToString(Unsafe.As<List<TSource>, List<string>>(ref source2).AsSpan(), separator);
			}
			Span<TSource> span = source2.AsSpan();
			if (span.Length == 0)
			{
				return "";
			}
			if (span.Length == 1)
			{
				return span[0].ToString() ?? "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			if (separator.Length == 0)
			{
				for (int i = 0; (uint)i < (uint)span.Length; i++)
				{
					valueStringBuilder.Append(span[i]);
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				valueStringBuilder.Append(span[0]);
				for (int j = 1; (uint)j < (uint)span.Length; j++)
				{
					valueStringBuilder.Append(value);
					valueStringBuilder.Append(span[j]);
				}
			}
			else
			{
				valueStringBuilder.Append(span[0]);
				for (int k = 1; (uint)k < (uint)span.Length; k++)
				{
					valueStringBuilder.Append(separator);
					valueStringBuilder.Append(span[k]);
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			TSource[] source2 = source.Enumerator.source;
			Func<TSource, TResult> selector = source.Enumerator.selector;
			if (source2.Length == 0)
			{
				return "";
			}
			if (source2.Length == 1)
			{
				TResult val = selector(source2[0]);
				return ((val != null) ? val.ToString() : null) ?? "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			valueStringBuilder.Append(selector(source2[0]));
			int i = 1;
			if (separator.Length == 0)
			{
				for (; (uint)i < (uint)source2.Length; i++)
				{
					valueStringBuilder.Append(selector(source2[i]));
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				for (; (uint)i < (uint)source2.Length; i++)
				{
					valueStringBuilder.Append(value);
					valueStringBuilder.Append(selector(source2[i]));
				}
			}
			else
			{
				for (; (uint)i < (uint)source2.Length; i++)
				{
					valueStringBuilder.Append(separator);
					valueStringBuilder.Append(selector(source2[i]));
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			TSource[] source2 = source.Enumerator.GetSource();
			Func<TSource, bool> predicate = source.Enumerator.Predicate;
			if (source2.Length == 0)
			{
				return "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			int i;
			for (i = 0; (uint)i < (uint)source2.Length; i++)
			{
				if (predicate(source2[i]))
				{
					valueStringBuilder.Append(source2[i]);
					i++;
					break;
				}
			}
			if (separator.Length == 0)
			{
				for (; (uint)i < (uint)source2.Length; i++)
				{
					if (predicate(source2[i]))
					{
						valueStringBuilder.Append(source2[i]);
					}
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				for (; (uint)i < (uint)source2.Length; i++)
				{
					if (predicate(source2[i]))
					{
						valueStringBuilder.Append(value);
						valueStringBuilder.Append(source2[i]);
					}
				}
			}
			else
			{
				for (; (uint)i < (uint)source2.Length; i++)
				{
					if (predicate(source2[i]))
					{
						valueStringBuilder.Append(separator);
						valueStringBuilder.Append(source2[i]);
					}
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			TSource[] source2 = source.Enumerator.GetSource();
			Func<TSource, bool> predicate = source.Enumerator.Predicate;
			Func<TSource, TResult> selector = source.Enumerator.Selector;
			if (source2.Length == 0)
			{
				return "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			int i;
			for (i = 0; (uint)i < (uint)source2.Length; i++)
			{
				if (predicate(source2[i]))
				{
					valueStringBuilder.Append(selector(source2[i]));
					i++;
					break;
				}
			}
			if (separator.Length == 0)
			{
				for (; (uint)i < (uint)source2.Length; i++)
				{
					if (predicate(source2[i]))
					{
						valueStringBuilder.Append(selector(source2[i]));
					}
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				for (; (uint)i < (uint)source2.Length; i++)
				{
					if (predicate(source2[i]))
					{
						valueStringBuilder.Append(value);
						valueStringBuilder.Append(selector(source2[i]));
					}
				}
			}
			else
			{
				for (; (uint)i < (uint)source2.Length; i++)
				{
					if (predicate(source2[i]))
					{
						valueStringBuilder.Append(separator);
						valueStringBuilder.Append(selector(source2[i]));
					}
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			List<TSource> source2 = source.Enumerator.source;
			Func<TSource, TResult> selector = source.Enumerator.selector;
			Span<TSource> span = source2.AsSpan();
			if (span.Length == 0)
			{
				return "";
			}
			if (span.Length == 1)
			{
				TResult val = selector(span[0]);
				return ((val != null) ? val.ToString() : null) ?? "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			valueStringBuilder.Append(selector(span[0]));
			int i = 1;
			if (separator.Length == 0)
			{
				for (; (uint)i < (uint)span.Length; i++)
				{
					valueStringBuilder.Append(selector(span[i]));
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				for (; (uint)i < (uint)span.Length; i++)
				{
					valueStringBuilder.Append(value);
					valueStringBuilder.Append(selector(span[i]));
				}
			}
			else
			{
				for (; (uint)i < (uint)span.Length; i++)
				{
					valueStringBuilder.Append(separator);
					valueStringBuilder.Append(selector(span[i]));
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			List<TSource> source2 = source.Enumerator.GetSource();
			Func<TSource, bool> predicate = source.Enumerator.Predicate;
			Span<TSource> span = source2.AsSpan();
			if (span.Length == 0)
			{
				return "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			int i;
			for (i = 0; (uint)i < (uint)span.Length; i++)
			{
				if (predicate(span[i]))
				{
					valueStringBuilder.Append(span[i]);
					i++;
					break;
				}
			}
			if (separator.Length == 0)
			{
				for (; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						valueStringBuilder.Append(span[i]);
					}
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				for (; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						valueStringBuilder.Append(value);
						valueStringBuilder.Append(span[i]);
					}
				}
			}
			else
			{
				for (; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						valueStringBuilder.Append(separator);
						valueStringBuilder.Append(span[i]);
					}
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source, string separator)
		{
			return source.JoinToString(separator.AsSpan());
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source, char separator)
		{
			ReadOnlySpan<char> separator2 = stackalloc char[1] { separator };
			return source.JoinToString(separator2);
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			List<TSource> source2 = source.Enumerator.GetSource();
			Func<TSource, bool> predicate = source.Enumerator.Predicate;
			Func<TSource, TResult> selector = source.Enumerator.Selector;
			Span<TSource> span = source2.AsSpan();
			if (span.Length == 0)
			{
				return "";
			}
			Span<char> initialBuffer = stackalloc char[256];
			ValueStringBuilder valueStringBuilder = new ValueStringBuilder(initialBuffer);
			int i;
			for (i = 0; (uint)i < (uint)span.Length; i++)
			{
				if (predicate(span[i]))
				{
					valueStringBuilder.Append(selector(span[i]));
					i++;
					break;
				}
			}
			if (separator.Length == 0)
			{
				for (; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						valueStringBuilder.Append(selector(span[i]));
					}
				}
			}
			else if (separator.Length == 1)
			{
				char value = separator[0];
				for (; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						valueStringBuilder.Append(value);
						valueStringBuilder.Append(selector(span[i]));
					}
				}
			}
			else
			{
				for (; (uint)i < (uint)span.Length; i++)
				{
					if (predicate(span[i]))
					{
						valueStringBuilder.Append(separator);
						valueStringBuilder.Append(selector(span[i]));
					}
				}
			}
			return valueStringBuilder.ToStringAndClear();
		}

		public static TSource Last<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetLast<TEnumerator, TSource>(ref source2, out value) ? value : Throws.NoElements<TSource>();
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource Last<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetLast(ref source2, predicate, out value) ? value : Throws.NoMatch<TSource>();
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetLast<TEnumerator, TSource>(ref source2, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return (TSource)(TryGetLast<TEnumerator, TSource>(ref source2, out value) ? ((object)value) : ((object)defaultValue));
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetLast(ref source2, predicate, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return (TSource)(TryGetLast(ref source2, predicate, out value) ? ((object)value) : ((object)defaultValue));
			}
			finally
			{
				source2.Dispose();
			}
		}

		private static bool TryGetLast<TEnumerator, TSource>(ref TEnumerator source, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TSource reference = default(TSource);
			if (source.TryCopyTo(SingleSpan.Create(ref reference), ^1))
			{
				value = reference;
				return true;
			}
			if (EnumeratorHelper.TryConsumeGetAt<TEnumerator, TSource>(ref source, ^1, out reference))
			{
				value = reference;
				return true;
			}
			value = default(TSource);
			return false;
		}

		private static bool TryGetLast<TEnumerator, TSource>(ref TEnumerator source, Func<TSource, bool> predicate, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				for (int num = span.Length - 1; num >= 0; num--)
				{
					ref readonly TSource reference = ref span[num];
					if (predicate(reference))
					{
						value = reference;
						return true;
					}
				}
				value = default(TSource);
				return false;
			}
			TSource current;
			while (source.TryGetNext(out current))
			{
				if (!predicate(current))
				{
					continue;
				}
				TSource current2;
				while (source.TryGetNext(out current2))
				{
					if (predicate(current2))
					{
						current = current2;
					}
				}
				value = current;
				return true;
			}
			value = default(TSource);
			return false;
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static long LongCount<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count))
			{
				return count;
			}
			long num = 0L;
			TSource current;
			while (val.TryGetNext(out current))
			{
				num = checked(num + 1);
			}
			return num;
		}

		public static long LongCount<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				long num = 0L;
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					if (predicate(arg))
					{
						num = checked(num + 1);
					}
				}
				return num;
			}
			long num2 = 0L;
			TSource current;
			while (val.TryGetNext(out current))
			{
				if (predicate(current))
				{
					num2 = checked(num2 + 1);
				}
			}
			return num2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long LongCount<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate)
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TSource[] source2 = source.Enumerator.GetSource();
			if (source2.GetType() != typeof(TSource[]))
			{
				return LongCount(source2, predicate);
			}
			int num = 0;
			ReadOnlySpan<TSource> readOnlySpan = source2;
			for (int i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
			{
				if (predicate(readOnlySpan[i]))
				{
					num++;
				}
			}
			return num;
			[MethodImpl(MethodImplOptions.NoInlining)]
			static long LongCount(TSource[] array, Func<TSource, bool> func)
			{
				int num2 = 0;
				for (int j = 0; (uint)j < (uint)array.Length; j++)
				{
					if (func(array[j]))
					{
						num2++;
					}
				}
				return num2;
			}
		}

		public static TResult? Max<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Max();
		}

		public static TSource? Max<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.Max(null);
		}

		public static TSource? Max<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (comparer == null)
			{
				comparer = Comparer<TSource>.Default;
			}
			using TEnumerator val = source.Enumerator;
			TSource current = default(TSource);
			if (current == null)
			{
				do
				{
					if (!val.TryGetNext(out TSource current2))
					{
						return current;
					}
					current = current2;
				}
				while (current == null);
				TSource current3;
				while (val.TryGetNext(out current3))
				{
					if (current3 != null && comparer.Compare(current3, current) > 0)
					{
						current = current3;
					}
				}
				return current;
			}
			if (!val.TryGetNext(out current))
			{
				Throws.NoElements();
			}
			if (comparer == Comparer<TSource>.Default)
			{
				TSource current4;
				while (val.TryGetNext(out current4))
				{
					if (Comparer<TSource>.Default.Compare(current4, current) > 0)
					{
						current = current4;
					}
				}
				return current;
			}
			TSource current5;
			while (val.TryGetNext(out current5))
			{
				if (comparer.Compare(current5, current) > 0)
				{
					current = current5;
				}
			}
			return current;
		}

		public static TSource? MaxBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return source.MaxBy(keySelector, null);
		}

		public static TSource? MaxBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			using TEnumerator val = source.Enumerator;
			if (!val.TryGetNext(out TSource current))
			{
				if (default(TSource) == null)
				{
					return default(TSource);
				}
				Throws.NoElements();
			}
			TKey val2 = keySelector(current);
			if (default(TKey) == null)
			{
				if (val2 == null)
				{
					TSource result = current;
					do
					{
						if (!val.TryGetNext(out TSource current2))
						{
							return result;
						}
						current = current2;
						val2 = keySelector(current);
					}
					while (val2 == null);
				}
				TSource current3;
				while (val.TryGetNext(out current3))
				{
					TKey val3 = keySelector(current3);
					if (val3 != null && comparer.Compare(val3, val2) > 0)
					{
						val2 = val3;
						current = current3;
					}
				}
			}
			else
			{
				if (comparer == Comparer<TKey>.Default)
				{
					TSource current4;
					while (val.TryGetNext(out current4))
					{
						TKey val4 = keySelector(current4);
						if (Comparer<TKey>.Default.Compare(val4, val2) > 0)
						{
							val2 = val4;
							current = current4;
						}
					}
					return current;
				}
				TSource current5;
				while (val.TryGetNext(out current5))
				{
					TKey val5 = keySelector(current5);
					if (comparer.Compare(val5, val2) > 0)
					{
						val2 = val5;
						current = current5;
					}
				}
			}
			return current;
		}

		public static TResult? Min<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Min();
		}

		public static TSource? Min<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.Min(null);
		}

		public static TSource? Min<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (comparer == null)
			{
				comparer = Comparer<TSource>.Default;
			}
			using TEnumerator val = source.Enumerator;
			TSource current = default(TSource);
			if (current == null)
			{
				do
				{
					if (!val.TryGetNext(out TSource current2))
					{
						return current;
					}
					current = current2;
				}
				while (current == null);
				TSource current3;
				while (val.TryGetNext(out current3))
				{
					if (current3 != null && comparer.Compare(current3, current) < 0)
					{
						current = current3;
					}
				}
				return current;
			}
			if (!val.TryGetNext(out current))
			{
				Throws.NoElements();
			}
			if (comparer == Comparer<TSource>.Default)
			{
				TSource current4;
				while (val.TryGetNext(out current4))
				{
					if (Comparer<TSource>.Default.Compare(current4, current) < 0)
					{
						current = current4;
					}
				}
				return current;
			}
			TSource current5;
			while (val.TryGetNext(out current5))
			{
				if (comparer.Compare(current5, current) < 0)
				{
					current = current5;
				}
			}
			return current;
		}

		public static TSource? MinBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return source.MinBy(keySelector, null);
		}

		public static TSource? MinBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			if (comparer == null)
			{
				comparer = Comparer<TKey>.Default;
			}
			using TEnumerator val = source.Enumerator;
			if (!val.TryGetNext(out TSource current))
			{
				if (default(TSource) == null)
				{
					return default(TSource);
				}
				Throws.NoElements();
			}
			TKey val2 = keySelector(current);
			if (default(TKey) == null)
			{
				if (val2 == null)
				{
					TSource result = current;
					do
					{
						if (!val.TryGetNext(out TSource current2))
						{
							return result;
						}
						current = current2;
						val2 = keySelector(current);
					}
					while (val2 == null);
				}
				TSource current3;
				while (val.TryGetNext(out current3))
				{
					TKey val3 = keySelector(current3);
					if (val3 != null && comparer.Compare(val3, val2) < 0)
					{
						val2 = val3;
						current = current3;
					}
				}
			}
			else
			{
				if (comparer == Comparer<TKey>.Default)
				{
					TSource current4;
					while (val.TryGetNext(out current4))
					{
						TKey val4 = keySelector(current4);
						if (Comparer<TKey>.Default.Compare(val4, val2) < 0)
						{
							val2 = val4;
							current = current4;
						}
					}
					return current;
				}
				TSource current5;
				while (val.TryGetNext(out current5))
				{
					TKey val5 = keySelector(current5);
					if (comparer.Compare(val5, val2) < 0)
					{
						val2 = val5;
						current = current5;
					}
				}
			}
			return current;
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> Order<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>(new OrderBy<TEnumerator, TSource, TSource>(source.Enumerator, _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__UnsafeFunctions<TSource, TSource>.Identity, null, null, descending: false));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> Order<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>(new OrderBy<TEnumerator, TSource, TSource>(source.Enumerator, _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__UnsafeFunctions<TSource, TSource>.Identity, comparer, null, descending: false));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> OrderDescending<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>(new OrderBy<TEnumerator, TSource, TSource>(source.Enumerator, _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__UnsafeFunctions<TSource, TSource>.Identity, null, null, descending: true));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> OrderDescending<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>(new OrderBy<TEnumerator, TSource, TSource>(source.Enumerator, _003COrderBy_003EF20F22F0783C758479CC59FC23C7FEAF81F289B10B31CBE866E87C24F818E06F4__UnsafeFunctions<TSource, TSource>.Identity, comparer, null, descending: true));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>(new OrderBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), null, null, descending: false));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>(new OrderBy<TEnumerator, TSource, TKey>(source.Enumerator, keySelector, comparer, null, descending: false));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderByDescending<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>(new OrderBy<TEnumerator, TSource, TKey>(source.Enumerator, Throws.IfNull(keySelector, "keySelector"), null, null, descending: true));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderByDescending<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>(new OrderBy<TEnumerator, TSource, TKey>(source.Enumerator, keySelector, comparer, null, descending: true));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource> ThenBy<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>(source.Enumerator.ThenBy(Throws.IfNull(keySelector, "keySelector")));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource> ThenBy<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>(source.Enumerator.ThenBy(Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource> ThenByDescending<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>(source.Enumerator.ThenByDescending(Throws.IfNull(keySelector, "keySelector")));
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource> ThenByDescending<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>(source.Enumerator.ThenByDescending(Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> Skip<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>(new OrderBySkipTake<TEnumerator, TSource, TKey>(source.Enumerator, Math.Max(0, count), int.MaxValue));
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> Take<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			count = Math.Max(0, count);
			return new ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>(new OrderBySkipTake<TEnumerator, TSource, TKey>(source.Enumerator, 0, count - 1));
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> Skip<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>(source.Enumerator.Skip(Math.Max(0, count)));
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> Take<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			count = Math.Max(0, count);
			return new ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>(source.Enumerator.Take(count));
		}

		public static ValueEnumerable<Prepend<TEnumerator, TSource>, TSource> Prepend<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource element) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Prepend<TEnumerator, TSource>, TSource>(new Prepend<TEnumerator, TSource>(source.Enumerator, element));
		}

		public static ValueEnumerable<Reverse<TEnumerator, TSource>, TSource> Reverse<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Reverse<TEnumerator, TSource>, TSource>(new Reverse<TEnumerator, TSource>(source.Enumerator));
		}

		public static ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner>
		{
			return new ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>(new RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(source.Enumerator, inner.Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), null));
		}

		public static ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter>
		{
			return new ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>(new RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>(source.Enumerator, Throws.IfNull(inner, "inner").AsValueEnumerable().Enumerator, Throws.IfNull(outerKeySelector, "outerKeySelector"), Throws.IfNull(innerKeySelector, "innerKeySelector"), Throws.IfNull(resultSelector, "resultSelector"), comparer));
		}

		public static ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> Select<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult>(new Select<TEnumerator, TSource, TResult>(source.Enumerator, Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<Select2<TEnumerator, TSource, TResult>, TResult> Select<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Select2<TEnumerator, TSource, TResult>, TResult>(new Select2<TEnumerator, TSource, TResult>(source.Enumerator, Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<RangeSelect<TResult>, TResult> Select<TResult>(this ValueEnumerable<FromRange, int> source, Func<int, TResult> selector)
		{
			return new ValueEnumerable<RangeSelect<TResult>, TResult>(new RangeSelect<TResult>(source.Enumerator, Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<SelectWhere<TEnumerator, TSource, TResult>, TResult> Where<TEnumerator, TSource, TResult>(this ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> source, Func<TResult, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SelectWhere<TEnumerator, TSource, TResult>, TResult>(source.Enumerator.Where(Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<ArraySelect<TSource, TResult>, TResult> Select<TSource, TResult>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return new ValueEnumerable<ArraySelect<TSource, TResult>, TResult>(new ArraySelect<TSource, TResult>(source.Enumerator.GetSource(), Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<ArraySelectWhere<TSource, TResult>, TResult> Where<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, Func<TResult, bool> predicate)
		{
			return new ValueEnumerable<ArraySelectWhere<TSource, TResult>, TResult>(source.Enumerator.Where(Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<ListSelect<TSource, TResult>, TResult> Select<TSource, TResult>(this ValueEnumerable<FromList<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return new ValueEnumerable<ListSelect<TSource, TResult>, TResult>(new ListSelect<TSource, TResult>(source.Enumerator.GetSource(), Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<ListSelectWhere<TSource, TResult>, TResult> Where<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, Func<TResult, bool> predicate)
		{
			return new ValueEnumerable<ListSelectWhere<TSource, TResult>, TResult>(source.Enumerator.Where(Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<SelectMany<TEnumerator, TEnumerator2, TSource, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, ValueEnumerable<TEnumerator2, TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TResult>
		{
			return new ValueEnumerable<SelectMany<TEnumerator, TEnumerator2, TSource, TResult>, TResult>(new SelectMany<TEnumerator, TEnumerator2, TSource, TResult>(source.Enumerator, Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<SelectMany2<TEnumerator, TEnumerator2, TSource, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, ValueEnumerable<TEnumerator2, TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TResult>
		{
			return new ValueEnumerable<SelectMany2<TEnumerator, TEnumerator2, TSource, TResult>, TResult>(new SelectMany2<TEnumerator, TEnumerator2, TSource, TResult>(source.Enumerator, Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<SelectMany3<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, ValueEnumerable<TEnumerator2, TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TCollection>
		{
			return new ValueEnumerable<SelectMany3<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult>(new SelectMany3<TEnumerator, TEnumerator2, TSource, TCollection, TResult>(source.Enumerator, Throws.IfNull(collectionSelector, "collectionSelector"), Throws.IfNull(resultSelector, "resultSelector")));
		}

		public static ValueEnumerable<SelectMany4<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, ValueEnumerable<TEnumerator2, TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TCollection>
		{
			return new ValueEnumerable<SelectMany4<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult>(new SelectMany4<TEnumerator, TEnumerator2, TSource, TCollection, TResult>(source.Enumerator, Throws.IfNull(collectionSelector, "collectionSelector"), Throws.IfNull(resultSelector, "resultSelector")));
		}

		public static ValueEnumerable<SelectMany<TEnumerator, TSource, TResult>, TResult> SelectMany<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, IEnumerable<TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SelectMany<TEnumerator, TSource, TResult>, TResult>(new SelectMany<TEnumerator, TSource, TResult>(source.Enumerator, Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<SelectMany2<TEnumerator, TSource, TResult>, TResult> SelectMany<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, IEnumerable<TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SelectMany2<TEnumerator, TSource, TResult>, TResult>(new SelectMany2<TEnumerator, TSource, TResult>(source.Enumerator, Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<SelectMany3<TEnumerator, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SelectMany3<TEnumerator, TSource, TCollection, TResult>, TResult>(new SelectMany3<TEnumerator, TSource, TCollection, TResult>(source.Enumerator, Throws.IfNull(collectionSelector, "collectionSelector"), Throws.IfNull(resultSelector, "resultSelector")));
		}

		public static ValueEnumerable<SelectMany4<TEnumerator, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SelectMany4<TEnumerator, TSource, TCollection, TResult>, TResult>(new SelectMany4<TEnumerator, TSource, TCollection, TResult>(source.Enumerator, Throws.IfNull(collectionSelector, "collectionSelector"), Throws.IfNull(resultSelector, "resultSelector")));
		}

		public static bool SequenceEqual<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.SequenceEqual(Throws.IfNull(second, "second").AsValueEnumerable(), null);
		}

		public static bool SequenceEqual<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.SequenceEqual(Throws.IfNull(second, "second").AsValueEnumerable(), comparer);
		}

		public static bool SequenceEqual<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return source.SequenceEqual(second, null);
		}

		public static bool SequenceEqual<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			using TEnumerator2 val2 = second.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count) && val2.TryGetNonEnumeratedCount(out var count2) && count != count2)
			{
				return false;
			}
			if (comparer == null)
			{
				comparer = EqualityComparer<TSource>.Default;
			}
			TSource current;
			while (val.TryGetNext(out current))
			{
				if (!val2.TryGetNext(out TSource current2) || !comparer.Equals(current, current2))
				{
					return false;
				}
			}
			TSource current3;
			return !val2.TryGetNext(out current3);
		}

		public static ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> Shuffle<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource>(new Shuffle<TEnumerator, TSource>(source.Enumerator));
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> Take<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>(new ShuffleSkipTake<TEnumerator, TSource>(source.Enumerator.source, 0, Math.Max(0, count)));
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>(new ShuffleSkipTake<TEnumerator, TSource>(source.Enumerator.source, Math.Max(0, count), int.MaxValue));
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> TakeLast<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>(new ShuffleSkipTake<TEnumerator, TSource>(source.Enumerator.source, 0, Math.Max(0, count)));
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> SkipLast<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>(new ShuffleSkipTake<TEnumerator, TSource>(source.Enumerator.source, Math.Max(0, count), int.MaxValue));
		}

		public static TSource Single<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetSingle<TEnumerator, TSource>(ref source2, out value) ? value : Throws.NoElements<TSource>();
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource Single<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetSingle(ref source2, predicate, out value) ? value : Throws.NoMatch<TSource>();
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetSingle<TEnumerator, TSource>(ref source2, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return (TSource)(TryGetSingle<TEnumerator, TSource>(ref source2, out value) ? ((object)value) : ((object)defaultValue));
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource? SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return TryGetSingle(ref source2, predicate, out value) ? value : default(TSource);
			}
			finally
			{
				source2.Dispose();
			}
		}

		public static TSource SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(predicate, "predicate");
			TEnumerator source2 = source.Enumerator;
			try
			{
				TSource value;
				return (TSource)(TryGetSingle(ref source2, predicate, out value) ? ((object)value) : ((object)defaultValue));
			}
			finally
			{
				source2.Dispose();
			}
		}

		private static bool TryGetSingle<TEnumerator, TSource>(ref TEnumerator source, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				if (span.Length == 1)
				{
					value = span[0];
					return true;
				}
				if (span.Length != 0)
				{
					Throws.MoreThanOneElement();
				}
			}
			else if (source.TryGetNext(out value))
			{
				if (source.TryGetNext(out TSource _))
				{
					Throws.MoreThanOneElement();
				}
				return true;
			}
			value = default(TSource);
			return false;
		}

		private static bool TryGetSingle<TEnumerator, TSource>(ref TEnumerator source, Func<TSource, bool> predicate, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			value = default(TSource);
			bool flag = false;
			if (source.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val = readOnlySpan[i];
					if (predicate(val))
					{
						if (flag)
						{
							Throws.MoreThanOneMatch();
						}
						flag = true;
						value = val;
					}
				}
				if (flag)
				{
					return true;
				}
			}
			else
			{
				TSource current;
				while (source.TryGetNext(out current))
				{
					if (predicate(current))
					{
						if (flag)
						{
							Throws.MoreThanOneMatch();
						}
						flag = true;
						value = current;
					}
				}
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public static ValueEnumerable<Skip<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Skip<TEnumerator, TSource>, TSource>(new Skip<TEnumerator, TSource>(source.Enumerator, count));
		}

		public static ValueEnumerable<SkipLast<TEnumerator, TSource>, TSource> SkipLast<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SkipLast<TEnumerator, TSource>, TSource>(new SkipLast<TEnumerator, TSource>(source.Enumerator, count));
		}

		public static ValueEnumerable<SkipWhile<TEnumerator, TSource>, TSource> SkipWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SkipWhile<TEnumerator, TSource>, TSource>(new SkipWhile<TEnumerator, TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<SkipWhile2<TEnumerator, TSource>, TSource> SkipWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<SkipWhile2<TEnumerator, TSource>, TSource>(new SkipWhile2<TEnumerator, TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static TResult Sum<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Sum();
		}

		public static TResult? Sum<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult?> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			ArgumentNullException.ThrowIfNull(selector, "selector");
			return source.Select(selector).Sum();
		}

		public static TSource? Sum<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource?> source) where TEnumerator : struct, IValueEnumerator<TSource?> where TSource : struct
		{
			return (from x in source
				where x.HasValue
				select x.GetValueOrDefault()).Sum();
		}

		public static TSource Sum<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : struct
		{
			if (typeof(TSource) == typeof(float))
			{
				using (TEnumerator val = source.Enumerator)
				{
					double num = 0.0;
					TSource current;
					while (val.TryGetNext(out current))
					{
						num += (double)Unsafe.As<TSource, float>(ref current);
					}
					float source2 = (float)num;
					return Unsafe.As<float, TSource>(ref source2);
				}
			}
			checked
			{
				if (typeof(TSource) == typeof(byte))
				{
					using (TEnumerator val2 = source.Enumerator)
					{
						byte source3 = 0;
						TSource current2;
						while (val2.TryGetNext(out current2))
						{
							source3 += Unsafe.As<TSource, byte>(ref current2);
						}
						return Unsafe.As<byte, TSource>(ref source3);
					}
				}
				if (typeof(TSource) == typeof(sbyte))
				{
					using (TEnumerator val3 = source.Enumerator)
					{
						sbyte source4 = 0;
						TSource current3;
						while (val3.TryGetNext(out current3))
						{
							source4 += Unsafe.As<TSource, sbyte>(ref current3);
						}
						return Unsafe.As<sbyte, TSource>(ref source4);
					}
				}
				if (typeof(TSource) == typeof(short))
				{
					using (TEnumerator val4 = source.Enumerator)
					{
						short source5 = 0;
						TSource current4;
						while (val4.TryGetNext(out current4))
						{
							source5 += Unsafe.As<TSource, short>(ref current4);
						}
						return Unsafe.As<short, TSource>(ref source5);
					}
				}
				if (typeof(TSource) == typeof(ushort))
				{
					using (TEnumerator val5 = source.Enumerator)
					{
						ushort source6 = 0;
						TSource current5;
						while (val5.TryGetNext(out current5))
						{
							source6 += Unsafe.As<TSource, ushort>(ref current5);
						}
						return Unsafe.As<ushort, TSource>(ref source6);
					}
				}
				if (typeof(TSource) == typeof(int))
				{
					using (TEnumerator val6 = source.Enumerator)
					{
						int source7 = 0;
						TSource current6;
						while (val6.TryGetNext(out current6))
						{
							source7 += Unsafe.As<TSource, int>(ref current6);
						}
						return Unsafe.As<int, TSource>(ref source7);
					}
				}
				if (typeof(TSource) == typeof(uint))
				{
					using (TEnumerator val7 = source.Enumerator)
					{
						uint source8 = 0u;
						TSource current7;
						while (val7.TryGetNext(out current7))
						{
							source8 += Unsafe.As<TSource, uint>(ref current7);
						}
						return Unsafe.As<uint, TSource>(ref source8);
					}
				}
				if (typeof(TSource) == typeof(long))
				{
					using (TEnumerator val8 = source.Enumerator)
					{
						long source9 = 0L;
						TSource current8;
						while (val8.TryGetNext(out current8))
						{
							source9 += Unsafe.As<TSource, long>(ref current8);
						}
						return Unsafe.As<long, TSource>(ref source9);
					}
				}
				if (typeof(TSource) == typeof(ulong))
				{
					using (TEnumerator val9 = source.Enumerator)
					{
						ulong source10 = 0uL;
						TSource current9;
						while (val9.TryGetNext(out current9))
						{
							source10 += Unsafe.As<TSource, ulong>(ref current9);
						}
						return Unsafe.As<ulong, TSource>(ref source10);
					}
				}
				if (typeof(TSource) == typeof(double))
				{
					using (TEnumerator val10 = source.Enumerator)
					{
						double source11 = 0.0;
						TSource current10;
						while (val10.TryGetNext(out current10))
						{
							source11 += Unsafe.As<TSource, double>(ref current10);
						}
						return Unsafe.As<double, TSource>(ref source11);
					}
				}
				if (typeof(TSource) == typeof(decimal))
				{
					using (TEnumerator val11 = source.Enumerator)
					{
						decimal source12 = default(decimal);
						TSource current11;
						while (val11.TryGetNext(out current11))
						{
							source12 += Unsafe.As<TSource, decimal>(ref current11);
						}
						return Unsafe.As<decimal, TSource>(ref source12);
					}
				}
				if (typeof(TSource) == typeof(IntPtr))
				{
					using (TEnumerator val12 = source.Enumerator)
					{
						nint source13 = 0;
						TSource current12;
						while (val12.TryGetNext(out current12))
						{
							source13 += unchecked((nint)Unsafe.As<TSource, IntPtr>(ref current12));
						}
						return Unsafe.As<IntPtr, TSource>(ref source13);
					}
				}
				if (typeof(TSource) == typeof(UIntPtr))
				{
					using (TEnumerator val13 = source.Enumerator)
					{
						nuint source14 = 0u;
						TSource current13;
						while (val13.TryGetNext(out current13))
						{
							source14 += unchecked((nuint)Unsafe.As<TSource, UIntPtr>(ref current13));
						}
						return Unsafe.As<UIntPtr, TSource>(ref source14);
					}
				}
				Throws.NotSupportedType(typeof(TSource));
				return default(TSource);
			}
		}

		public static ValueEnumerable<Take<TEnumerator, TSource>, TSource> Take<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Take<TEnumerator, TSource>, TSource>(new Take<TEnumerator, TSource>(source.Enumerator, count));
		}

		public static ValueEnumerable<TakeRange<TEnumerator, TSource>, TSource> Take<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Range range) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<TakeRange<TEnumerator, TSource>, TSource>(new TakeRange<TEnumerator, TSource>(source.Enumerator, range));
		}

		public static ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<Take<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource>(source.Enumerator.Skip(count));
		}

		public static ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource>(source.Enumerator.Skip(count));
		}

		public static ValueEnumerable<TakeLast<TEnumerator, TSource>, TSource> TakeLast<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<TakeLast<TEnumerator, TSource>, TSource>(new TakeLast<TEnumerator, TSource>(source.Enumerator, count));
		}

		public static ValueEnumerable<TakeWhile<TEnumerator, TSource>, TSource> TakeWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<TakeWhile<TEnumerator, TSource>, TSource>(new TakeWhile<TEnumerator, TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<TakeWhile2<TEnumerator, TSource>, TSource> TakeWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<TakeWhile2<TEnumerator, TSource>, TSource>(new TakeWhile2<TEnumerator, TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static TSource[] ToArray<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count))
			{
				if (count == 0)
				{
					return Array.Empty<TSource>();
				}
				TSource[] array = GC.AllocateUninitializedArray<TSource>(count);
				if (val.TryCopyTo(array.AsSpan(), 0))
				{
					return array;
				}
				int num = 0;
				TSource current;
				while (val.TryGetNext(out current))
				{
					array[num] = current;
					num++;
				}
				return array;
			}
			Span<TSource> initialBuffer = default(InlineArray16<TSource>).AsSpan();
			SegmentedArrayProvider<TSource> segmentedArrayProvider = new SegmentedArrayProvider<TSource>(initialBuffer);
			Span<TSource> span = segmentedArrayProvider.GetSpan();
			int num2 = 0;
			TSource current2;
			while (val.TryGetNext(out current2))
			{
				if (num2 == span.Length)
				{
					segmentedArrayProvider.Advance(num2);
					span = segmentedArrayProvider.GetSpan();
					num2 = 0;
				}
				span[num2] = current2;
				num2++;
			}
			segmentedArrayProvider.Advance(num2);
			count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TSource>();
			}
			TSource[] array2 = GC.AllocateUninitializedArray<TSource>(count);
			segmentedArrayProvider.CopyToAndClear(array2);
			return array2;
		}

		public static TResult[] ToArray<TEnumerator, TSource, TResult>(this ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator.source;
			Func<TSource, TResult> selector = source.Enumerator.selector;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				if (span.Length == 0)
				{
					return Array.Empty<TResult>();
				}
				TResult[] array = GC.AllocateUninitializedArray<TResult>(span.Length);
				for (int i = 0; (uint)i < (uint)span.Length; i++)
				{
					array[i] = selector(span[i]);
				}
				return array;
			}
			Span<TResult> initialBuffer = default(InlineArray16<TResult>).AsSpan();
			SegmentedArrayProvider<TResult> segmentedArrayProvider = new SegmentedArrayProvider<TResult>(initialBuffer);
			Span<TResult> span2 = segmentedArrayProvider.GetSpan();
			int num = 0;
			TSource current;
			while (val.TryGetNext(out current))
			{
				if (num == span2.Length)
				{
					segmentedArrayProvider.Advance(num);
					span2 = segmentedArrayProvider.GetSpan();
					num = 0;
				}
				span2[num] = selector(current);
				num++;
			}
			segmentedArrayProvider.Advance(num);
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array2 = GC.AllocateUninitializedArray<TResult>(count);
			segmentedArrayProvider.CopyToAndClear(array2);
			return array2;
		}

		public static TResult[] ToArray<TResult>(this ValueEnumerable<RangeSelect<TResult>, TResult> source)
		{
			int num = source.Enumerator.start;
			int count = source.Enumerator.count;
			Func<int, TResult> selector = source.Enumerator.selector;
			if (count == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array = GC.AllocateUninitializedArray<TResult>(count);
			for (int i = 0; (uint)i < (uint)array.Length; i++)
			{
				array[i] = selector(num);
				num++;
			}
			return array;
		}

		public static TResult[] ToArray<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source)
		{
			TSource[] source2 = source.Enumerator.source;
			Func<TSource, TResult> selector = source.Enumerator.selector;
			if (source2.Length == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array = GC.AllocateUninitializedArray<TResult>(source2.Length);
			for (int i = 0; (uint)i < (uint)source2.Length; i++)
			{
				array[i] = selector(source2[i]);
			}
			return array;
		}

		public static TSource[] ToArray<TEnumerator, TSource>(this ValueEnumerable<Where<TEnumerator, TSource>, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			Where<TEnumerator, TSource> enumerator = source.Enumerator;
			Func<TSource, bool> predicate = enumerator.Predicate;
			using TEnumerator val = enumerator.GetSource();
			Span<TSource> initialBuffer = default(InlineArray16<TSource>).AsSpan();
			SegmentedArrayProvider<TSource> segmentedArrayProvider = new SegmentedArrayProvider<TSource>(initialBuffer);
			Span<TSource> span = segmentedArrayProvider.GetSpan();
			int num = 0;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span2))
			{
				ReadOnlySpan<TSource> readOnlySpan = span2;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val2 = readOnlySpan[i];
					if (predicate(val2))
					{
						if (num == span.Length)
						{
							segmentedArrayProvider.Advance(num);
							span = segmentedArrayProvider.GetSpan();
							num = 0;
						}
						span[num] = val2;
						num++;
					}
				}
				segmentedArrayProvider.Advance(num);
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (predicate(current))
					{
						if (num == span.Length)
						{
							segmentedArrayProvider.Advance(num);
							span = segmentedArrayProvider.GetSpan();
							num = 0;
						}
						span[num] = current;
						num++;
					}
				}
				segmentedArrayProvider.Advance(num);
			}
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TSource>();
			}
			TSource[] array = GC.AllocateUninitializedArray<TSource>(count);
			segmentedArrayProvider.CopyToAndClear(array);
			return array;
		}

		public static TSource[] ToArray<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source)
		{
			ArrayWhere<TSource> enumerator = source.Enumerator;
			Func<TSource, bool> predicate = enumerator.Predicate;
			TSource[] source2 = enumerator.GetSource();
			Span<TSource> initialBuffer = default(InlineArray16<TSource>).AsSpan();
			SegmentedArrayProvider<TSource> segmentedArrayProvider = new SegmentedArrayProvider<TSource>(initialBuffer);
			Span<TSource> span = segmentedArrayProvider.GetSpan();
			int num = 0;
			TSource[] array = source2;
			foreach (TSource val in array)
			{
				if (predicate(val))
				{
					if (num == span.Length)
					{
						segmentedArrayProvider.Advance(num);
						span = segmentedArrayProvider.GetSpan();
						num = 0;
					}
					span[num] = val;
					num++;
				}
			}
			segmentedArrayProvider.Advance(num);
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TSource>();
			}
			TSource[] array2 = GC.AllocateUninitializedArray<TSource>(count);
			segmentedArrayProvider.CopyToAndClear(array2);
			return array2;
		}

		public static TResult[] ToArray<TEnumerator, TSource, TResult>(this ValueEnumerable<WhereSelect<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			WhereSelect<TEnumerator, TSource, TResult> enumerator = source.Enumerator;
			Func<TSource, bool> predicate = enumerator.Predicate;
			Func<TSource, TResult> selector = enumerator.Selector;
			using TEnumerator val = enumerator.GetSource();
			Span<TResult> initialBuffer = default(InlineArray16<TResult>).AsSpan();
			SegmentedArrayProvider<TResult> segmentedArrayProvider = new SegmentedArrayProvider<TResult>(initialBuffer);
			Span<TResult> span = segmentedArrayProvider.GetSpan();
			int num = 0;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span2))
			{
				ReadOnlySpan<TSource> readOnlySpan = span2;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					if (predicate(arg))
					{
						if (num == span.Length)
						{
							segmentedArrayProvider.Advance(num);
							span = segmentedArrayProvider.GetSpan();
							num = 0;
						}
						span[num] = selector(arg);
						num++;
					}
				}
				segmentedArrayProvider.Advance(num);
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (predicate(current))
					{
						if (num == span.Length)
						{
							segmentedArrayProvider.Advance(num);
							span = segmentedArrayProvider.GetSpan();
							num = 0;
						}
						span[num] = selector(current);
						num++;
					}
				}
				segmentedArrayProvider.Advance(num);
			}
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array = GC.AllocateUninitializedArray<TResult>(count);
			segmentedArrayProvider.CopyToAndClear(array);
			return array;
		}

		public static TResult[] ToArray<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source)
		{
			ArrayWhereSelect<TSource, TResult> enumerator = source.Enumerator;
			Func<TSource, bool> predicate = enumerator.Predicate;
			Func<TSource, TResult> selector = enumerator.Selector;
			TSource[] source2 = enumerator.GetSource();
			Span<TResult> initialBuffer = default(InlineArray16<TResult>).AsSpan();
			SegmentedArrayProvider<TResult> segmentedArrayProvider = new SegmentedArrayProvider<TResult>(initialBuffer);
			Span<TResult> span = segmentedArrayProvider.GetSpan();
			int num = 0;
			TSource[] array = source2;
			foreach (TSource arg in array)
			{
				if (predicate(arg))
				{
					if (num == span.Length)
					{
						segmentedArrayProvider.Advance(num);
						span = segmentedArrayProvider.GetSpan();
						num = 0;
					}
					span[num] = selector(arg);
					num++;
				}
			}
			segmentedArrayProvider.Advance(num);
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array2 = GC.AllocateUninitializedArray<TResult>(count);
			segmentedArrayProvider.CopyToAndClear(array2);
			return array2;
		}

		public static TSource[] ToArray<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source)
		{
			ListWhere<TSource> enumerator = source.Enumerator;
			Func<TSource, bool> predicate = enumerator.Predicate;
			Span<TSource> span = enumerator.GetSource().AsSpan();
			Span<TSource> initialBuffer = default(InlineArray16<TSource>).AsSpan();
			SegmentedArrayProvider<TSource> segmentedArrayProvider = new SegmentedArrayProvider<TSource>(initialBuffer);
			Span<TSource> span2 = segmentedArrayProvider.GetSpan();
			int num = 0;
			Span<TSource> span3 = span;
			for (int i = 0; i < span3.Length; i++)
			{
				TSource val = span3[i];
				if (predicate(val))
				{
					if (num == span2.Length)
					{
						segmentedArrayProvider.Advance(num);
						span2 = segmentedArrayProvider.GetSpan();
						num = 0;
					}
					span2[num] = val;
					num++;
				}
			}
			segmentedArrayProvider.Advance(num);
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TSource>();
			}
			TSource[] array = GC.AllocateUninitializedArray<TSource>(count);
			segmentedArrayProvider.CopyToAndClear(array);
			return array;
		}

		public static TResult[] ToArray<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source)
		{
			ListWhereSelect<TSource, TResult> enumerator = source.Enumerator;
			Func<TSource, bool> predicate = enumerator.Predicate;
			Func<TSource, TResult> selector = enumerator.Selector;
			Span<TSource> span = enumerator.GetSource().AsSpan();
			Span<TResult> initialBuffer = default(InlineArray16<TResult>).AsSpan();
			SegmentedArrayProvider<TResult> segmentedArrayProvider = new SegmentedArrayProvider<TResult>(initialBuffer);
			Span<TResult> span2 = segmentedArrayProvider.GetSpan();
			int num = 0;
			Span<TSource> span3 = span;
			for (int i = 0; i < span3.Length; i++)
			{
				TSource arg = span3[i];
				if (predicate(arg))
				{
					if (num == span2.Length)
					{
						segmentedArrayProvider.Advance(num);
						span2 = segmentedArrayProvider.GetSpan();
						num = 0;
					}
					span2[num] = selector(arg);
					num++;
				}
			}
			segmentedArrayProvider.Advance(num);
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array = GC.AllocateUninitializedArray<TResult>(count);
			segmentedArrayProvider.CopyToAndClear(array);
			return array;
		}

		public static TResult[] ToArray<TEnumerator, TSource, TResult>(this ValueEnumerable<OfType<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator.GetSource();
			Span<TResult> initialBuffer = default(InlineArray16<TResult>).AsSpan();
			SegmentedArrayProvider<TResult> segmentedArrayProvider = new SegmentedArrayProvider<TResult>(initialBuffer);
			Span<TResult> span = segmentedArrayProvider.GetSpan();
			int num = 0;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span2))
			{
				ReadOnlySpan<TSource> readOnlySpan = span2;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val2 = readOnlySpan[i];
					if (val2 is TResult val3)
					{
						if (num == span.Length)
						{
							segmentedArrayProvider.Advance(num);
							span = segmentedArrayProvider.GetSpan();
							num = 0;
						}
						span[num] = val3;
						num++;
					}
				}
				segmentedArrayProvider.Advance(num);
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					if (current is TResult val4)
					{
						if (num == span.Length)
						{
							segmentedArrayProvider.Advance(num);
							span = segmentedArrayProvider.GetSpan();
							num = 0;
						}
						span[num] = val4;
						num++;
					}
				}
				segmentedArrayProvider.Advance(num);
			}
			int count = segmentedArrayProvider.Count;
			if (count == 0)
			{
				return Array.Empty<TResult>();
			}
			TResult[] array = GC.AllocateUninitializedArray<TResult>(count);
			segmentedArrayProvider.CopyToAndClear(array);
			return array;
		}

		public static PooledArray<TSource> ToArrayPool<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count))
			{
				TSource[] array = ArrayPool<TSource>.Shared.Rent(count);
				if (array.Length == 0)
				{
					return new PooledArray<TSource>(array, count);
				}
				if (val.TryCopyTo(array.AsSpan(0, count), 0))
				{
					return new PooledArray<TSource>(array, count);
				}
				int num = 0;
				TSource current;
				while (val.TryGetNext(out current))
				{
					array[num] = current;
					num++;
				}
				return new PooledArray<TSource>(array, num);
			}
			Span<TSource> initialBuffer = default(InlineArray16<TSource>).AsSpan();
			SegmentedArrayProvider<TSource> segmentedArrayProvider = new SegmentedArrayProvider<TSource>(initialBuffer);
			Span<TSource> span = segmentedArrayProvider.GetSpan();
			int num2 = 0;
			TSource current2;
			while (val.TryGetNext(out current2))
			{
				if (num2 == span.Length)
				{
					segmentedArrayProvider.Advance(num2);
					span = segmentedArrayProvider.GetSpan();
					num2 = 0;
				}
				span[num2] = current2;
				num2++;
			}
			segmentedArrayProvider.Advance(num2);
			TSource[] array2 = ArrayPool<TSource>.Shared.Rent(segmentedArrayProvider.Count);
			segmentedArrayProvider.CopyToAndClear(array2);
			return new PooledArray<TSource>(array2, segmentedArrayProvider.Count);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, KeyValuePair<TKey, TValue>> source) where TEnumerator : struct, IValueEnumerator<KeyValuePair<TKey, TValue>> where TKey : notnull
		{
			return source.ToDictionary(null);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<KeyValuePair<TKey, TValue>> where TKey : notnull
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<KeyValuePair<TKey, TValue>> span))
			{
				Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(span.Length, comparer);
				ReadOnlySpan<KeyValuePair<TKey, TValue>> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					KeyValuePair<TKey, TValue> keyValuePair = readOnlySpan[i];
					dictionary.Add(keyValuePair.Key, keyValuePair.Value);
				}
				return dictionary;
			}
			int count;
			Dictionary<TKey, TValue> dictionary2 = (val.TryGetNonEnumeratedCount(out count) ? new Dictionary<TKey, TValue>(count, comparer) : new Dictionary<TKey, TValue>(comparer));
			KeyValuePair<TKey, TValue> current;
			while (val.TryGetNext(out current))
			{
				dictionary2.Add(current.Key, current.Value);
			}
			return dictionary2;
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, (TKey Key, TValue Value)> source) where TEnumerator : struct, IValueEnumerator<(TKey Key, TValue Value)> where TKey : notnull
		{
			return source.ToDictionary(null);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, (TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<(TKey Key, TValue Value)> where TKey : notnull
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<(TKey, TValue)> span))
			{
				Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(span.Length, comparer);
				ReadOnlySpan<(TKey, TValue)> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					(TKey, TValue) tuple = readOnlySpan[i];
					dictionary.Add(tuple.Item1, tuple.Item2);
				}
				return dictionary;
			}
			int count;
			Dictionary<TKey, TValue> dictionary2 = (val.TryGetNonEnumeratedCount(out count) ? new Dictionary<TKey, TValue>(count, comparer) : new Dictionary<TKey, TValue>(comparer));
			(TKey, TValue) current;
			while (val.TryGetNext(out current))
			{
				dictionary2.Add(current.Item1, current.Item2);
			}
			return dictionary2;
		}

		public static Dictionary<TKey, TSource> ToDictionary<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TKey : notnull
		{
			return source.ToDictionary(keySelector, null);
		}

		public static Dictionary<TKey, TSource> ToDictionary<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TKey : notnull
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>(span.Length, comparer);
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val2 = readOnlySpan[i];
					dictionary.Add(keySelector(val2), val2);
				}
				return dictionary;
			}
			int count;
			Dictionary<TKey, TSource> dictionary2 = (val.TryGetNonEnumeratedCount(out count) ? new Dictionary<TKey, TSource>(count, comparer) : new Dictionary<TKey, TSource>(comparer));
			TSource current;
			while (val.TryGetNext(out current))
			{
				dictionary2.Add(keySelector(current), current);
			}
			return dictionary2;
		}

		public static Dictionary<TKey, TElement> ToDictionary<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TKey : notnull
		{
			return source.ToDictionary(keySelector, elementSelector, null);
		}

		public static Dictionary<TKey, TElement> ToDictionary<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TKey : notnull
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			ArgumentNullException.ThrowIfNull(elementSelector, "elementSelector");
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>(span.Length, comparer);
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					dictionary.Add(keySelector(arg), elementSelector(arg));
				}
				return dictionary;
			}
			int count;
			Dictionary<TKey, TElement> dictionary2 = (val.TryGetNonEnumeratedCount(out count) ? new Dictionary<TKey, TElement>(count, comparer) : new Dictionary<TKey, TElement>(comparer));
			TSource current;
			while (val.TryGetNext(out current))
			{
				dictionary2.Add(keySelector(current), elementSelector(current));
			}
			return dictionary2;
		}

		public static HashSet<TSource> ToHashSet<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.ToHashSet(null);
		}

		public static HashSet<TSource> ToHashSet<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				HashSet<TSource> hashSet = new HashSet<TSource>(span.Length, comparer);
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource item = readOnlySpan[i];
					hashSet.Add(item);
				}
				return hashSet;
			}
			int count;
			HashSet<TSource> hashSet2 = (val.TryGetNonEnumeratedCount(out count) ? new HashSet<TSource>(count, comparer) : new HashSet<TSource>(comparer));
			TSource current;
			while (val.TryGetNext(out current))
			{
				hashSet2.Add(current);
			}
			return hashSet2;
		}

		internal static HashSetSlim<TSource> ToHashSetSlim<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				HashSetSlim<TSource> hashSetSlim = new HashSetSlim<TSource>(span.Length, comparer);
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource item = readOnlySpan[i];
					hashSetSlim.Add(item);
				}
				return hashSetSlim;
			}
			int count;
			HashSetSlim<TSource> hashSetSlim2 = (val.TryGetNonEnumeratedCount(out count) ? new HashSetSlim<TSource>(count, comparer) : new HashSetSlim<TSource>(comparer));
			TSource current;
			while (val.TryGetNext(out current))
			{
				hashSetSlim2.Add(current);
			}
			return hashSetSlim2;
		}

		public static List<TSource> ToList<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			if (val.TryGetNonEnumeratedCount(out var count))
			{
				List<TSource> list = new List<TSource>(count);
				list.UnsafeSetCount(count);
				Span<TSource> destination = list.AsSpan();
				if (!val.TryCopyTo(destination, 0))
				{
					int num = 0;
					TSource current;
					while (val.TryGetNext(out current))
					{
						destination[num] = current;
						num++;
					}
				}
				return list;
			}
			Span<TSource> initialBuffer = default(InlineArray16<TSource>).AsSpan();
			SegmentedArrayProvider<TSource> segmentedArrayProvider = new SegmentedArrayProvider<TSource>(initialBuffer);
			Span<TSource> span = segmentedArrayProvider.GetSpan();
			int num2 = 0;
			TSource current2;
			while (val.TryGetNext(out current2))
			{
				if (num2 == span.Length)
				{
					segmentedArrayProvider.Advance(num2);
					span = segmentedArrayProvider.GetSpan();
					num2 = 0;
				}
				span[num2] = current2;
				num2++;
			}
			segmentedArrayProvider.Advance(num2);
			count = segmentedArrayProvider.Count;
			List<TSource> list2 = new List<TSource>(count);
			list2.UnsafeSetCount(count);
			Span<TSource> destination2 = list2.AsSpan();
			segmentedArrayProvider.CopyToAndClear(destination2);
			return list2;
		}

		public static List<TResult> ToList<TEnumerator, TSource, TResult>(this ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator.source;
			Func<TSource, TResult> selector = source.Enumerator.selector;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				List<TResult> list = new List<TResult>(span.Length);
				list.UnsafeSetCount(span.Length);
				Span<TResult> span2 = list.AsSpan();
				for (int i = 0; (uint)i < (uint)span.Length; i++)
				{
					span2[i] = selector(span[i]);
				}
				return list;
			}
			Span<TResult> initialBuffer = default(InlineArray16<TResult>).AsSpan();
			SegmentedArrayProvider<TResult> segmentedArrayProvider = new SegmentedArrayProvider<TResult>(initialBuffer);
			Span<TResult> span3 = segmentedArrayProvider.GetSpan();
			int num = 0;
			TSource current;
			while (val.TryGetNext(out current))
			{
				if (num == span3.Length)
				{
					segmentedArrayProvider.Advance(num);
					span3 = segmentedArrayProvider.GetSpan();
					num = 0;
				}
				span3[num] = selector(current);
				num++;
			}
			segmentedArrayProvider.Advance(num);
			int count = segmentedArrayProvider.Count;
			List<TResult> list2 = new List<TResult>(count);
			list2.UnsafeSetCount(count);
			Span<TResult> destination = list2.AsSpan();
			segmentedArrayProvider.CopyToAndClear(destination);
			return list2;
		}

		public static List<TResult> ToList<TResult>(this ValueEnumerable<RangeSelect<TResult>, TResult> source)
		{
			int num = source.Enumerator.start;
			int count = source.Enumerator.count;
			Func<int, TResult> selector = source.Enumerator.selector;
			List<TResult> list = new List<TResult>(count);
			list.UnsafeSetCount(count);
			Span<TResult> span = list.AsSpan();
			for (int i = 0; (uint)i < (uint)span.Length; i++)
			{
				span[i] = selector(num);
				num++;
			}
			return list;
		}

		public static List<TResult> ToList<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source)
		{
			TSource[] source2 = source.Enumerator.source;
			Func<TSource, TResult> selector = source.Enumerator.selector;
			List<TResult> list = new List<TResult>(source2.Length);
			list.UnsafeSetCount(source2.Length);
			Span<TResult> span = list.AsSpan();
			for (int i = 0; (uint)i < (uint)source2.Length; i++)
			{
				span[i] = selector(source2[i]);
			}
			return list;
		}

		public static List<TResult> ToList<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source)
		{
			Span<TSource> span = source.Enumerator.source.AsSpan();
			Func<TSource, TResult> selector = source.Enumerator.selector;
			List<TResult> list = new List<TResult>(span.Length);
			list.UnsafeSetCount(span.Length);
			Span<TResult> span2 = list.AsSpan();
			for (int i = 0; (uint)i < (uint)span.Length; i++)
			{
				span2[i] = selector(span[i]);
			}
			return list;
		}

		public static ILookup<TKey, TSource> ToLookup<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.ToLookup(keySelector, null);
		}

		public static ILookup<TKey, TSource> ToLookup<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			LookupBuilder<TKey, TSource> lookupBuilder = new LookupBuilder<TKey, TSource>(comparer ?? EqualityComparer<TKey>.Default);
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource val2 = readOnlySpan[i];
					lookupBuilder.Add(keySelector(val2), val2);
				}
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					lookupBuilder.Add(keySelector(current), current);
				}
			}
			return lookupBuilder.BuildAndClear();
		}

		public static ILookup<TKey, TElement> ToLookup<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return source.ToLookup(keySelector, elementSelector, null);
		}

		public static ILookup<TKey, TElement> ToLookup<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			ArgumentNullException.ThrowIfNull(elementSelector, "elementSelector");
			LookupBuilder<TKey, TElement> lookupBuilder = new LookupBuilder<TKey, TElement>(comparer ?? EqualityComparer<TKey>.Default);
			using TEnumerator val = source.Enumerator;
			if (val.TryGetSpan(out ReadOnlySpan<TSource> span))
			{
				ReadOnlySpan<TSource> readOnlySpan = span;
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					TSource arg = readOnlySpan[i];
					lookupBuilder.Add(keySelector(arg), elementSelector(arg));
				}
			}
			else
			{
				TSource current;
				while (val.TryGetNext(out current))
				{
					lookupBuilder.Add(keySelector(current), elementSelector(current));
				}
			}
			return lookupBuilder.BuildAndClear();
		}

		public static bool TryGetNonEnumeratedCount<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, out int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			using TEnumerator val = source.Enumerator;
			return val.TryGetNonEnumeratedCount(out count);
		}

		public static ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource> Union<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource>(new Union<TEnumerator, TEnumerator2, TSource>(source.Enumerator, second.Enumerator, null));
		}

		public static ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource> Union<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource>(new Union<TEnumerator, TEnumerator2, TSource>(source.Enumerator, second.Enumerator, comparer));
		}

		public static ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Union<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>(new Union<TEnumerator, FromEnumerable<TSource>, TSource>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable().Enumerator, null));
		}

		public static ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Union<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>(new Union<TEnumerator, FromEnumerable<TSource>, TSource>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable().Enumerator, comparer));
		}

		public static ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> UnionBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>(new UnionBy<TEnumerator, TEnumerator2, TSource, TKey>(source.Enumerator, second.Enumerator, Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> UnionBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>(new UnionBy<TEnumerator, TEnumerator2, TSource, TKey>(source.Enumerator, second.Enumerator, Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource> UnionBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return new ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource>(new UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable().Enumerator, Throws.IfNull(keySelector, "keySelector"), null));
		}

		public static ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource> UnionBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
			return new ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource>(new UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable().Enumerator, Throws.IfNull(keySelector, "keySelector"), comparer));
		}

		public static ValueEnumerable<Where<TEnumerator, TSource>, TSource> Where<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Where<TEnumerator, TSource>, TSource>(new Where<TEnumerator, TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<Where2<TEnumerator, TSource>, TSource> Where<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<Where2<TEnumerator, TSource>, TSource>(new Where2<TEnumerator, TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<WhereSelect<TEnumerator, TSource, TResult>, TResult> Select<TEnumerator, TSource, TResult>(this ValueEnumerable<Where<TEnumerator, TSource>, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return new ValueEnumerable<WhereSelect<TEnumerator, TSource, TResult>, TResult>(source.Enumerator.Select(Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<ArrayWhere<TSource>, TSource> Where<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate)
		{
			return new ValueEnumerable<ArrayWhere<TSource>, TSource>(new ArrayWhere<TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> Select<TSource, TResult>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return new ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult>(source.Enumerator.Select(Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<ListWhere<TSource>, TSource> Where<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, Func<TSource, bool> predicate)
		{
			return new ValueEnumerable<ListWhere<TSource>, TSource>(new ListWhere<TSource>(source.Enumerator, Throws.IfNull(predicate, "predicate")));
		}

		public static ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> Select<TSource, TResult>(this ValueEnumerable<ListWhere<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return new ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult>(source.Enumerator.Select(Throws.IfNull(selector, "selector")));
		}

		public static ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond>, (TFirst First, TSecond Second)> Zip<TEnumerator, TEnumerator2, TFirst, TSecond>(this ValueEnumerable<TEnumerator, TFirst> source, ValueEnumerable<TEnumerator2, TSecond> second) where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond>
		{
			return new ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond>, (TFirst, TSecond)>(new Zip<TEnumerator, TEnumerator2, TFirst, TSecond>(source.Enumerator, second.Enumerator));
		}

		public static ValueEnumerable<Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird>, (TFirst First, TSecond Second, TThird Third)> Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird>(this ValueEnumerable<TEnumerator, TFirst> source, ValueEnumerable<TEnumerator2, TSecond> second, ValueEnumerable<TEnumerator3, TThird> third) where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond> where TEnumerator3 : struct, IValueEnumerator<TThird>
		{
			return new ValueEnumerable<Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird>, (TFirst, TSecond, TThird)>(new Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird>(source.Enumerator, second.Enumerator, third.Enumerator));
		}

		public static ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult>, TResult> Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult>(this ValueEnumerable<TEnumerator, TFirst> source, ValueEnumerable<TEnumerator2, TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond>
		{
			return new ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult>, TResult>(new Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult>(source.Enumerator, second.Enumerator, Throws.IfNull(resultSelector, "resultSelector")));
		}

		public static ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond>, (TFirst First, TSecond Second)> Zip<TEnumerator, TFirst, TSecond>(this ValueEnumerable<TEnumerator, TFirst> source, IEnumerable<TSecond> second) where TEnumerator : struct, IValueEnumerator<TFirst>
		{
			return new ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond>, (TFirst, TSecond)>(new Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable().Enumerator));
		}

		public static ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, FromEnumerable<TThird>, TFirst, TSecond, TThird>, (TFirst First, TSecond Second, TThird Third)> Zip<TEnumerator, TFirst, TSecond, TThird>(this ValueEnumerable<TEnumerator, TFirst> source, IEnumerable<TSecond> second, IEnumerable<TThird> third) where TEnumerator : struct, IValueEnumerator<TFirst>
		{
			return new ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, FromEnumerable<TThird>, TFirst, TSecond, TThird>, (TFirst, TSecond, TThird)>(new Zip<TEnumerator, FromEnumerable<TSecond>, FromEnumerable<TThird>, TFirst, TSecond, TThird>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable().Enumerator, Throws.IfNull(third, "third").AsValueEnumerable().Enumerator));
		}

		public static ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond, TResult>, TResult> Zip<TEnumerator, TFirst, TSecond, TResult>(this ValueEnumerable<TEnumerator, TFirst> source, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TFirst>
		{
			return new ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond, TResult>, TResult>(new Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond, TResult>(source.Enumerator, Throws.IfNull(second, "second").AsValueEnumerable().Enumerator, Throws.IfNull(resultSelector, "resultSelector")));
		}

		public static ValueEnumerator<TEnumerator, T> GetEnumerator<TEnumerator, T>(this in ValueEnumerable<TEnumerator, T> valueEnumerable) where TEnumerator : struct, IValueEnumerator<T>
		{
			return new ValueEnumerator<TEnumerator, T>(valueEnumerable.Enumerator);
		}
	}
}

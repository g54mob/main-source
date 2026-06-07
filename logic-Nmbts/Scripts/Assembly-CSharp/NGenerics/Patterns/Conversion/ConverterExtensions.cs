using System;
using System.Collections.Generic;
using NGenerics.Extensions;

namespace NGenerics.Patterns.Conversion
{
	public static class ConverterExtensions
	{
		public static IEnumerable<TOutput> ConvertAll<TInput, TOutput>(this IConverter<TInput, TOutput> converter, IEnumerable<TInput> input)
		{
			return ConvertInternal(input, converter.Convert);
		}

		public static IEnumerable<T2> ConvertAll<T1, T2>(this IBidirectionalConverter<T1, T2> converter, IEnumerable<T1> input)
		{
			return ConvertInternal(input, converter.Convert);
		}

		public static IEnumerable<TOutput> ConvertAll<TInput, TOutput>(this IEnumerable<TInput> value, IConverter<TInput, TOutput> converter)
		{
			return converter.ConvertAll(value);
		}

		public static IEnumerable<TOutput> Convert<TInput, TOutput>(this IEnumerable<TInput> items, IConverter<TInput, TOutput> converter)
		{
			return converter.ConvertAll(items);
		}

		public static IEnumerable<TOutput> Convert<TInput, TOutput>(this IEnumerable<TInput> items, IBidirectionalConverter<TInput, TOutput> converter)
		{
			return converter.ConvertAll(items);
		}

		public static TOutput Convert<TInput, TOutput>(this TInput value, IConverter<TInput, TOutput> converter)
		{
			return converter.Convert(value);
		}

		private static IEnumerable<TOutput> ConvertInternal<TInput, TOutput>(IEnumerable<TInput> input, Converter<TInput, TOutput> converter)
		{
			List<TOutput> list = new List<TOutput>();
			input.ForEach(delegate(TInput x)
			{
				list.Add(converter(x));
			});
			return list;
		}
	}
}
